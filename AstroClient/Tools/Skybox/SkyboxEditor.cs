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
    using System.Windows.Forms.VisualStyles;
    using CheetoLibrary.Utility;
    using Il2CppSystem.Text;

    internal class SkyboxEditor : AstroEvents
    {

        private static string Side_Up { get; } = "Up";
        private static string Side_Down { get; } = "Down";
        private static string Side_Back { get; } = "Back";
        private static string Side_Front { get; } = "Front";
        private static string Side_Left { get; } = "Left";
        private static string Side_Right { get; } = "Right";

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

        internal static string YoinkedSkyboxesPath
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
                FindAndLoadSkyboxes();
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

        private static IEnumerator LoadPNGsSkyboxes()
        {
            if (Directory.Exists(YoinkedSkyboxesPath))
            {
                var YoinkedSkyboxesDirs = Directory.GetDirectories(YoinkedSkyboxesPath).ToList();
                if (YoinkedSkyboxesDirs.IsNotEmpty())
                {
                    for (int i1 = 0; i1 < YoinkedSkyboxesDirs.Count; i1++)
                    {
                        string dir = YoinkedSkyboxesDirs[i1];
                        if (!IsBundleAlreadyRegistered(Path.GetFileName(dir)))
                        {
                            //ModConsole.Log("Found Custom Skybox : " + Path.GetFileName(file));

                            #region bundle Resource searcher.


                            #region Loading Bundle Textures (For Previewing in the buttons)

                            var images = Directory.GetFiles(dir).ToList();
                            if (images.IsEmpty()) continue;


                            Texture2D Up = null;
                            Texture2D Down = null;
                            Texture2D Back = null;
                            Texture2D Front = null;
                            Texture2D Left = null;
                            Texture2D Right = null;
                            Material GeneratedMaterial = null;
                            foreach (var imagepaths in images)
                            {
                                ModConsole.DebugLog($"Found File in {imagepaths}");

                                if (Up == null)
                                {
                                    if (imagepaths.EndsWith($"{Side_Up}.png"))
                                    {
                                        Up = CheetoUtils.LoadPNGFromDir(imagepaths);
                                        if (Up != null)
                                        {
                                            Up.wrapMode = TextureWrapMode.Clamp;
                                            Up.Apply();
                                            Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                        }
                                        else
                                        {
                                            ModConsole.DebugLog("Up is Missing");
                                        }
                                    }
                                }
                                if (Down == null)
                                {
                                    if (imagepaths.EndsWith($"{Side_Down}.png"))
                                    {
                                        Down = CheetoUtils.LoadPNGFromDir(imagepaths);
                                        if (Down != null)
                                        {
                                            Down.wrapMode = TextureWrapMode.Clamp;
                                            Down.Apply();
                                            Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                        }
                                        else
                                        {
                                            ModConsole.DebugLog("Down is Missing");
                                        }
                                    }
                                }
                                if (Back == null)
                                {
                                    if (imagepaths.EndsWith($"{Side_Back}.png"))
                                    {
                                        Back = CheetoUtils.LoadPNGFromDir(imagepaths);
                                        if (Back != null)
                                        {
                                            Back.wrapMode = TextureWrapMode.Clamp;
                                            Back.Apply();
                                            Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                        }
                                        else
                                        {
                                            ModConsole.DebugLog("Back is Missing");
                                        }
                                    }
                                }
                                if (Front == null)
                                {
                                    if (imagepaths.EndsWith($"{Side_Front}.png"))
                                    {
                                        Front = CheetoUtils.LoadPNGFromDir(imagepaths);
                                        if (Front != null)
                                        {
                                            Front.wrapMode = TextureWrapMode.Clamp;
                                            Front.Apply();
                                            Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                        }
                                        else
                                        {
                                            ModConsole.DebugLog("Front is Missing");
                                        }
                                    }
                                }
                                if (Left == null)
                                {
                                    if (imagepaths.EndsWith($"{Side_Left}.png"))
                                    {
                                        Left = CheetoUtils.LoadPNGFromDir(imagepaths);
                                        if (Left != null)
                                        {
                                            Left.wrapMode = TextureWrapMode.Clamp;
                                            Left.Apply();
                                            Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                        }
                                        else
                                        {
                                            ModConsole.DebugLog("Left is Missing");
                                        }
                                    }
                                }
                                if (Right == null)
                                {
                                    if (imagepaths.EndsWith($"{Side_Right}.png"))
                                    {
                                        Right = CheetoUtils.LoadPNGFromDir(imagepaths);
                                        if (Right != null)
                                        {
                                            Right.wrapMode = TextureWrapMode.Clamp;
                                            Right.Apply();
                                            Right.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                        }
                                        else
                                        {
                                            ModConsole.DebugLog("Right is Missing or failed conversion");
                                        }
                                    }
                                }

                            }

                            #endregion Generating Material

                            GeneratedMaterial = BuildMaterial(Up, Down, Back, Front, Left, Right);
                            if (GeneratedMaterial != null)
                            {
                                var SkyboxName = Path.GetFileName(dir);
                                GeneratedMaterial.name = SkyboxName;
                                GeneratedMaterial.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                var cachedskybox = new AssetBundleSkyboxes(SkyboxName, new BundleContent(Up, Down, Back, Front, Left, Right, null, GeneratedMaterial), false);
                                if (LoadedSkyboxesBundles != null)
                                {
                                    LoadedSkyboxesBundles.Add(cachedskybox);
                                }

                            }




                            #endregion

                        }



                        else
                        {
                            ModConsole.Warning("Skipping Registered Yoinked Skybox :" + Path.GetFileName(dir));
                            continue;
                        }
                        yield return new WaitForSeconds(0.001f);
                    }
                }
                else
                {
                    ModConsole.Warning("No Skyboxes Found here : " + YoinkedSkyboxesPath);
                }
            }
            else
            {
                _ = Directory.CreateDirectory(YoinkedSkyboxesPath);

            }

            yield return null;
        }

        private static IEnumerator LoadBundleSkyboxes()
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
                        else
                        {
                            ModConsole.Warning("Skipping Registered Skybox :" + Path.GetFileName(file));
                            continue;
                        }

                        yield return new WaitForSeconds(0.001f);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(BundlesPath);
                ModConsole.Warning("To Add custom Skyboxes , import the skyboxes assetbundles here : " + BundlesPath);
            }

            yield return null;
        }

        internal static void FindAndLoadSkyboxes()
        {

            MelonLoader.MelonCoroutines.Start(LoadBundleSkyboxes());
            MelonLoader.MelonCoroutines.Start(LoadPNGsSkyboxes());

            ModConsole.Log("Done checking for skyboxes.");
        }


        internal static void YoinkSkybox()
        {
            Texture2D Up = null;
            Texture2D Down = null;
            Texture2D Back = null;
            Texture2D Front = null;
            Texture2D Left = null;
            Texture2D Right = null;

            if (OriginalSkybox != null)
            {
                foreach (var TextureName in OriginalSkybox.GetTexturePropertyNames())
                {
                    var MaterialTexture = OriginalSkybox.GetTexture(TextureName);
                    //ModConsole.DebugLog($"Texture name : {TextureNames}, Material Name {mattexture.name}");

                    if (TextureName.isMatch("_Tex"))
                    {
                        ModConsole.DebugLog("This Skybox is Unsupported! (is a CubeMap)");
                        break;
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


                #region Caching Bundle and The results.


                // Save Skybox in File

                if (!Directory.Exists(YoinkedSkyboxesPath))
                {
                    Directory.CreateDirectory(YoinkedSkyboxesPath);
                }

                var savepath = Path.Combine(YoinkedSkyboxesPath, $"Skybox_{OriginalSkybox.name}");
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

                SaveTexture(Up, savepath, Side_Up);
                SaveTexture(Down, savepath, Side_Down);
                SaveTexture(Back, savepath, Side_Back);
                SaveTexture(Front, savepath, Side_Front);
                SaveTexture(Left, savepath, Side_Left);
                SaveTexture(Right, savepath, Side_Right);

                #endregion Caching Bundle and The results.

            }
        }


        private static Material BuildMaterial(Texture2D Up, Texture2D Down, Texture2D Back, Texture2D Front, Texture2D Left, Texture2D Right)
        {
            var reason = new StringBuilder();
            if (Up == null)
            {
                reason.AppendLine("Up Texture is missing!");
            }
            if (Down == null)
            {
                reason.AppendLine("Down Texture is missing!");
            }
            if (Back == null)
            {
                reason.AppendLine("Back Texture is missing!");
            }
            if (Front == null)
            {
                reason.AppendLine("Front Texture is missing!");
            }
            if (Left == null)
            {
                reason.AppendLine("Left Texture is missing!");
            }
            if (Right == null)
            {
                reason.AppendLine("Right Texture is missing!");
            }

            if (Up == null || Down == null || Back == null || Front == null || Left == null || Right == null)
            {
                ModConsole.DebugLog($"Failed Material Generation {reason.ToString()}");
                reason.Clear();
                return null;
            }
            reason.Clear();

            var shader = Shader.Find("Skybox/6 Sided");
            if (shader != null)
            {
                var result = new Material(shader);
                if (result != null)
                {
                    result.SetPass(0);
                    result.SetTexture("_UpTex", Up);
                    result.SetTexture("_DownTex", Down);
                    result.SetTexture("_BackTex", Back);
                    result.SetTexture("_FrontTex", Front);
                    result.SetTexture("_LeftTex", Left);
                    result.SetTexture("_RightTex", Right);

                    return result;
                }

            }

            return null;
        }

        private static void SaveTexture(Texture2D texture, string path, string direction)
        {
            byte[] bytes = ImageConversion.EncodeToPNG(texture).ToArray();
            File.WriteAllBytes(Path.Combine(path, $"{direction}.png"), bytes);
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