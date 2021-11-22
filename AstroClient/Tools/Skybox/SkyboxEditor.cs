namespace AstroClient.Tools.Skybox
{
    using Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using UnityEngine;
    using UnityEngine.Networking;
    using System.Collections;
    using System.IO;

    internal class SkyboxEditor : AstroEvents
    {
        internal static string SkyboxesPath
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, $"AstroSkyboxes");
            }
        }
        internal static string BundlesPath
        {
            get
            {
                return Path.Combine(SkyboxesPath, $"Bundles");
            }
        }

        internal static string YoinkedSkyboxes
        {
            get
            {
                return Path.Combine(SkyboxesPath, $"YoinkedSkyboxes");
            }
        }

        internal class AssetBundleSkyboxes
        {
            internal string SkyboxName { get; set; }

            internal BundleContent content { get; set; }

            internal bool isCubeMap { get; set; } = false;

            internal AssetBundleSkyboxes(string SkyboxName, BundleContent content, bool isCubeMap)
            {
                this.SkyboxName = SkyboxName;
                this.content = content;
                this.isCubeMap = isCubeMap;
            }
        }

        internal class BundleContent
        {
            internal Texture2D Up { get; set; }
            internal Texture2D Down { get; set; }
            internal Texture2D Back { get; set; }
            internal Texture2D Front { get; set; }
            internal Texture2D Left { get; set; }
            internal Texture2D Right { get; set; }

            internal Texture2D CubeMap { get; set; } // This in case all of these previous ones are null, (reads and parses it from the .mat file)

            internal Material Material { get; set; }

            internal BundleContent(Texture2D Up, Texture2D Down, Texture2D Back, Texture2D Front, Texture2D Left, Texture2D Right, Texture2D CubeMap, Material Material)
            {
                this.Up = Up;
                this.Down = Down;
                this.Back = Back;
                this.Front = Front;
                this.Left = Left;
                this.Right = Right;
                this.CubeMap = CubeMap;
                this.Material = Material;
            }

            internal void Destroy()
            {
                UnityEngine.Object.Destroy(Up);
                UnityEngine.Object.Destroy(Down);
                UnityEngine.Object.Destroy(Back);
                UnityEngine.Object.Destroy(Front);
                UnityEngine.Object.Destroy(Left);
                UnityEngine.Object.Destroy(Right);
                UnityEngine.Object.Destroy(CubeMap);
                UnityEngine.Object.Destroy(Material);
            }
        }

        internal static List<AssetBundleSkyboxes> LoadedSkyboxesBundles { get; private set; } = new List<AssetBundleSkyboxes>();

        private static bool HasLoadedCachedSkyboxes = false;

        internal static Material OriginalSkybox { get; private set; }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasLoadedCachedSkyboxes)
            {
                ModConsole.DebugLog("[Skybox Loader] : This will Probably take awhile...");
                _ = MelonLoader.MelonCoroutines.Start(FindAndLoadBundle());
                HasLoadedCachedSkyboxes = true;
            }
            OriginalSkybox = RenderSettings.skybox;
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            OriginalSkybox = null;
        }

        internal static bool IsBundleAlreadyRegistered(string filename)
        {
            return LoadedSkyboxesBundles.Where(x => x.SkyboxName == filename).Any();
        }

        //internal static bool IsMaterialAlreadyRegistered(string filename)
        //{
        //    return LoadedSkyboxesMaterials.Where(x => x.SkyboxName == filename).Any(); ;
        //}

        //internal static void SaveCurrentSkybox()
        //{
        //    if(OriginalSkybox != null)
        //    {
        //        File.WriteAllBytes(Path.Combine(SkyboxesPath, ".png"), UnityEngine.ImageConversion.EncodeToPNG(OriginalSkybox.mainTexture));
        //    }
        //}

        internal static IEnumerator FindAndLoadBundle()
        {
            if (Directory.Exists(BundlesPath))
            {
                var files = Directory.GetFiles(BundlesPath).ToList();
                if (files.IsNotEmpty())
                {
                    for (int i1 = 0; i1 < files.Count; i1++)
                    {
                        string file = files[i1];
                        if (!IsBundleAlreadyRegistered(Path.GetFileName(file)))
                        {
                            //ModConsole.Log("Found Custom Skybox : " + Path.GetFileName(file));
                            var stream = File.ReadAllBytes(file);
                            var bundle = AssetBundle.LoadFromMemory(stream.ToArray(), 0);
                            bundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;

                            #region bundle Resource searcher.

                            Texture2D Up = null;
                            Texture2D Down = null;
                            Texture2D Back = null;
                            Texture2D Front = null;
                            Texture2D Left = null;
                            Texture2D Right = null;
                            Texture2D CubeMapToTexture = null;

                            bool isCubeMap = false;

                            Material Material = null;

                            #region Loading Bundle Textures (For Previewing in the buttons)

                            foreach (var paths in bundle.GetAllAssetNames())
                            {
                                if (paths.ToLower().EndsWith(".mat"))
                                {
                                    if (Material == null)
                                    {
                                        Material = bundle.LoadAsset_Internal(paths, Il2CppType.Of<Material>()).Cast<Material>();
                                        if (Material != null)
                                        {
                                            Material.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                            foreach (var TextureName in Material.GetTexturePropertyNames())
                                            {
                                                var MaterialTexture = Material.GetTexture(TextureName);
                                                //ModConsole.DebugLog($"Texture name : {TextureNames}, Material Name {mattexture.name}");

                                                if (Up == null)
                                                {
                                                    if (TextureName.isMatch("_UpTex"))
                                                    {
                                                        Up = MaterialTexture.ToTexture2D();
                                                        if (Up != null)
                                                        {
                                                            Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                                        }
                                                    }
                                                }

                                                if (Down == null)
                                                {
                                                    if (TextureName.isMatch("_DownTex"))
                                                    {
                                                        Down = MaterialTexture.ToTexture2D();
                                                        if (Down != null)
                                                        {
                                                            Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                                        }
                                                    }
                                                }

                                                if (Back == null)
                                                {
                                                    if (TextureName.isMatch("_BackTex"))
                                                    {
                                                        Back = MaterialTexture.ToTexture2D();
                                                        if (Back != null)
                                                        {
                                                            Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                                        }
                                                    }
                                                }

                                                if (Front == null)
                                                {
                                                    if (TextureName.isMatch("_FrontTex"))
                                                    {
                                                        Front = MaterialTexture.ToTexture2D();
                                                        if (Front != null)
                                                        {
                                                            Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                                        }
                                                    }
                                                }

                                                if (Left == null)
                                                {
                                                    if (TextureName.isMatch("_LeftTex"))
                                                    {
                                                        Left = MaterialTexture.ToTexture2D();
                                                        if (Left != null)
                                                        {
                                                            Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                                        }
                                                    }
                                                }

                                                if (Right == null)
                                                {
                                                    if (TextureName.isMatch("_RightTex"))
                                                    {
                                                        Right = MaterialTexture.ToTexture2D();
                                                        if (Right != null)
                                                        {
                                                            Right.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                                        }
                                                    }
                                                }

                                                if (CubeMapToTexture == null)
                                                {
                                                    if (TextureName.isMatch("_Tex"))
                                                    {
                                                        isCubeMap = true;
                                                        CubeMapToTexture = MaterialTexture.ToTexture2D();
                                                        if (CubeMapToTexture != null)
                                                        {
                                                            CubeMapToTexture.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion Loading Bundle Textures (For Previewing in the buttons)

                            if (Material != null)
                            {
                                #region Caching Bundle and The results.

                                // End of the Parsing mechanism.
                                var cachedskybox = new AssetBundleSkyboxes(Path.GetFileName(file), new BundleContent(Up, Down, Back, Front, Left, Right, CubeMapToTexture, Material), isCubeMap);
                                if (LoadedSkyboxesBundles != null)
                                {
                                    LoadedSkyboxesBundles.Add(cachedskybox);
                                }

                                #endregion Caching Bundle and The results.
                            }
                            else
                            {
                                ModConsole.DebugLog($"Failed to parse {file}, Due to Material being null!");
                            }
                        }

                        #endregion bundle Resource searcher.

                        // TODO : ADD SOMETHING TO YOINK WORLD SKYBOXES
                        else
                        {
                            ModConsole.Warning("Skipping Registered Skybox :" + Path.GetFileName(file));
                            continue;
                        }

                        yield return new WaitForSeconds(0.001f);
                    }
                }
                else
                {
                    ModConsole.Warning("To Add custom Skyboxes , import the skyboxes assetbundles here : " + BundlesPath);
                }
            }
            else
            {
                _ = Directory.CreateDirectory(BundlesPath);
                ModConsole.Warning("To Add custom Skyboxes , import the skyboxes assetbundles here : " + BundlesPath);
            }

            ModConsole.Log("Done checking for skyboxes.");
            yield break;
        }

        internal static void YoinkSkybox()
        {
            Texture2D Up = null;
            Texture2D Down = null;
            Texture2D Back = null;
            Texture2D Front = null;
            Texture2D Left = null;
            Texture2D Right = null;
            Texture2D CubeMapToTexture = null;

            bool isCubeMap = false;

            if (OriginalSkybox != null)
            {
                foreach (var TextureName in OriginalSkybox.GetTexturePropertyNames())
                {
                    var MaterialTexture = OriginalSkybox.GetTexture(TextureName);
                    //ModConsole.DebugLog($"Texture name : {TextureNames}, Material Name {mattexture.name}");

                    if (CubeMapToTexture == null)
                    {
                        if (TextureName.isMatch("_Tex"))
                        {
                            isCubeMap = true;
                            CubeMapToTexture = MaterialTexture.ToTexture2D();
                            if (CubeMapToTexture != null)
                            {
                                CubeMapToTexture.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }

                    if (Up == null)
                    {
                        if (TextureName.isMatch("_UpTex"))
                        {
                            Up = MaterialTexture.ToTexture2D();
                            if (Up != null)
                            {
                                Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }

                    if (Down == null)
                    {
                        if (TextureName.isMatch("_DownTex"))
                        {
                            Down = MaterialTexture.ToTexture2D();
                            if (Down != null)
                            {
                                Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }

                    if (Back == null)
                    {
                        if (TextureName.isMatch("_BackTex"))
                        {
                            Back = MaterialTexture.ToTexture2D();
                            if (Back != null)
                            {
                                Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }

                    if (Front == null)
                    {
                        if (TextureName.isMatch("_FrontTex"))
                        {
                            Front = MaterialTexture.ToTexture2D();
                            if (Front != null)
                            {
                                Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }

                    if (Left == null)
                    {
                        if (TextureName.isMatch("_LeftTex"))
                        {
                            Left = MaterialTexture.ToTexture2D();
                            if (Left != null)
                            {
                                Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }

                    if (Right == null)
                    {
                        if (TextureName.isMatch("_RightTex"))
                        {
                            Right = MaterialTexture.ToTexture2D();
                            if (Right != null)
                            {
                                Right.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }

                }

                if (!isCubeMap)
                {
                    #region Caching Bundle and The results.


                    // End of the Parsing mechanism.
                    var cachedskybox = new AssetBundleSkyboxes(OriginalSkybox.name, new BundleContent(Up, Down, Back, Front, Left, Right, CubeMapToTexture, OriginalSkybox), isCubeMap);
                    if (LoadedSkyboxesBundles != null)
                    {
                        LoadedSkyboxesBundles.Add(cachedskybox);
                    }

                    // Save Skybox in File

                    if (!Directory.Exists(YoinkedSkyboxes))
                    {
                        Directory.CreateDirectory(YoinkedSkyboxes);
                    }

                    var savepath = Path.Combine(YoinkedSkyboxes, $"Skybox_{OriginalSkybox.name}");
                    if (!Directory.Exists(savepath))
                    {
                        Directory.CreateDirectory(savepath);
                    }

                    SaveTexture(Up, savepath, "up");
                    SaveTexture(Down, savepath, "Down");
                    SaveTexture(Back, savepath, "Back");
                    SaveTexture(Front, savepath, "Front");
                    SaveTexture(Left, savepath, "Left");
                    SaveTexture(Right, savepath, "Right");

                    #endregion Caching Bundle and The results.

                }
                else
                {
                    ModConsole.DebugLog($"Failed to parse {OriginalSkybox.name}, Due to being unsupported!");
                }

            }
        }

        private static void SaveTexture(Texture2D texture, string path, string direction)
        {
            byte[] bytes = ImageConversion.EncodeToPNG(texture).ToArray();
            File.WriteAllBytes(Path.Combine(path, $"{direction}_.png"), bytes);
        }


        internal static void SetRenderSettingSkybox(Material mat)
        {
            RenderSettings.skybox = mat;
        }

        internal static void SetRenderSettingSkybox(AssetBundleSkyboxes skybox)
        {
            SetRenderSettingSkybox(skybox.content.Material);
        }

        internal static bool SetSkyboxByFileName(string name)
        {
            if (!name.IsNotNullOrEmptyOrWhiteSpace())
            {
                ModConsole.DebugError($"Set a valid Skybox Name , Got {name}");
                return false;
            }
            if (LoadedSkyboxesBundles.Count() == 0)
            {
                ModConsole.Error($"There are no skybox Registered, unable to set a custom skybox.");
                return false;
            }
            if (LoadedSkyboxesBundles.Count() != 0)
            {
                foreach (var skybox in LoadedSkyboxesBundles)
                {
                    if (skybox != null)
                    {
                        if (skybox.SkyboxName.ToLower().Equals(name.ToLower()))
                        {
                            SetRenderSettingSkybox(skybox);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}