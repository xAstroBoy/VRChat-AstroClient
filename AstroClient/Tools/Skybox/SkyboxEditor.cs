using AstroClient.ClientActions;

namespace AstroClient.Tools.Skybox
{
    using CheetoLibrary.Utility;
    using Extensions;
    using Il2CppSystem.Text;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Constants;
    using CubemapTools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using Object = UnityEngine.Object;

    // TODO : Rewrite and optimize loading system.
    internal class SkyboxEditor : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
            ClientEventActions.Event_OnWorldReveal += OnWorldReveal;

        }

        private static bool HasLoadedCachedSkyboxes;

        private static string Side_Up { get; } = "Up";

        private static string Side_Down { get; } = "Down";

        private static string Side_Back { get; } = "Back";

        private static string Side_Front { get; } = "Front";

        private static string Side_Left { get; } = "Left";

        private static string Side_Right { get; } = "Right";

        private static string Texture_Name_Panoramic { get; } = "Panoramic";
        private static string Texture_Name_Cubemap { get; } = "Cubemap";

        private static string Cubemap_positiveX { get; } = "PositiveX";

        private static string Cubemap_NegativeX { get; } = "NegativeX";

        private static string Cubemap_positiveY { get; } = "PositiveY";

        private static string Cubemap_NegativeY { get; } = "NegativeY";

        private static string Cubemap_positiveZ { get; } = "PositiveZ";

        private static string Cubemap_NegativeZ { get; } = "NegativeZ";

        internal static string SkyboxesPath => Path.Combine(Environment.CurrentDirectory, "AstroSkyboxes");

        internal static string BundlesPath => Path.Combine(SkyboxesPath, "Bundles");

        internal static string YoinkedSkyboxesPath => Path.Combine(SkyboxesPath, "YoinkedSkyboxes");

        internal static List<AssetBundleSkyboxes> LoadedSkyboxesBundles { get; } = new();

        internal static Material OriginalSkybox { get; private set; }

        internal static bool isSupportedSkybox { get; private set; } = false;

        internal static List<AssetBundle> FailedLoadedBundles { get; } = new();
        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasLoadedCachedSkyboxes)
            {
                Log.Debug("[Skybox Loader] : This will Probably take awhile...");
                FindAndLoadSkyboxes();
                HasLoadedCachedSkyboxes = true;
            }

            OriginalSkybox = RenderSettings.skybox;
            if (OriginalSkybox != null)
            {
                Log.Debug("[Skybox INFO] : Material name : " + OriginalSkybox.name);
                Log.Debug("[Skybox INFO] : Material Shader : " + OriginalSkybox.shader.name);
                var textureIDs = OriginalSkybox.GetTexturePropertyNames().ToList();
                for (int i = 0; i < textureIDs.Count; i++)
                {
                    Log.Debug("[Skybox INFO] : Texture name : " + textureIDs[i]);
                }

                if (textureIDs.Contains("_UpTex") && textureIDs.Contains("_DownTex") && textureIDs.Contains("_BackTex") &&
                    textureIDs.Contains("_FrontTex") && textureIDs.Contains("_LeftTex") && textureIDs.Contains("_RightTex"))
                {
                    Log.Debug("This Skybox can be Yoinked!");
                    if (Bools.IsDeveloper)
                    {
                        PopupUtils.QueHudMessage("This Skybox can Be Yoinked!");
                    }
                    isSupportedSkybox = true;
                }
            }
            else
            {
                isSupportedSkybox = false;
            }
        }

        private void OnRoomLeft()
        {
            isSupportedSkybox = false;
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
                    for (var i1 = 0; i1 < YoinkedSkyboxesDirs.Count; i1++)
                    {
                        var dir = YoinkedSkyboxesDirs[i1];
                        if (!IsBundleAlreadyRegistered(Path.GetFileName(dir)))
                        {
                            var images = Directory.GetFiles(dir).ToList();
                            if (images.IsEmpty()) continue;
                            Texture2D Up = null;
                            Texture2D Down = null;
                            Texture2D Back = null;
                            Texture2D Front = null;
                            Texture2D Left = null;
                            Texture2D Right = null;
                            foreach (var imagepaths in images)
                            {
                                //Log.Debug("Found File in " + imagepaths);
                                if (Up == null && imagepaths.EndsWith(Side_Up + ".png"))
                                {
                                    Up = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Up != null)
                                    {
                                        Up.wrapMode = TextureWrapMode.Clamp;
                                        Up.Apply();
                                        Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Down == null && imagepaths.EndsWith(Side_Down + ".png"))
                                {
                                    Down = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Down != null)
                                    {
                                        Down.wrapMode = TextureWrapMode.Clamp;
                                        Down.Apply();
                                        Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Back == null && imagepaths.EndsWith(Side_Back + ".png"))
                                {
                                    Back = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Back != null)
                                    {
                                        Back.wrapMode = TextureWrapMode.Clamp;
                                        Back.Apply();
                                        Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Front == null && imagepaths.EndsWith(Side_Front + ".png"))
                                {
                                    Front = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Front != null)
                                    {
                                        Front.wrapMode = TextureWrapMode.Clamp;
                                        Front.Apply();
                                        Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Left == null && imagepaths.EndsWith(Side_Left + ".png"))
                                {
                                    Left = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Left != null)
                                    {
                                        Left.wrapMode = TextureWrapMode.Clamp;
                                        Left.Apply();
                                        Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Right == null && imagepaths.EndsWith(Side_Right + ".png"))
                                {
                                    Right = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Right != null)
                                    {
                                        Right.wrapMode = TextureWrapMode.Clamp;
                                        Right.Apply();
                                        Right.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }
                            }

                            var GeneratedMaterial = BuildSixSidedMaterial(Up, Down, Back, Front, Left, Right);
                            if (GeneratedMaterial != null)
                            {
                                var SkyboxName = GeneratedMaterial.name = Path.GetFileName(dir);
                                GeneratedMaterial.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                var cachedskybox = new AssetBundleSkyboxes(SkyboxName, new BundleContent(Up, Down, Back, Front, Left, Right, null, null, GeneratedMaterial), false);
                                if (LoadedSkyboxesBundles != null) LoadedSkyboxesBundles.Add(cachedskybox);
                            }
                            else
                            {
                                Log.Error($"Unable to Generate Material For {Path.GetFileName(dir)}");
                            }

                            yield return new WaitForSeconds(0.001f);
                        }
                        else
                        {
                            Log.Warn("Skipping Registered Yoinked Skybox :" + Path.GetFileName(dir));
                        }
                    }
                else
                    Log.Warn("No Skyboxes Found here : " + YoinkedSkyboxesPath);
            }
            else
            {
                Directory.CreateDirectory(YoinkedSkyboxesPath);
            }

            yield return null;
        }

        internal static AssetBundle GetValidBundle(string BundlePath)
        {


            var bundle = AssetBundle.LoadFromFile(BundlePath, 0u);
            if (bundle != null)
            {
                if (bundle.name.IsNotNullOrEmptyOrWhiteSpace())
                {
                    if (bundle.GetAllAssetNames().Count != 0)
                    {
                        bundle.hideFlags = HideFlags.DontUnloadUnusedAsset;
                        return bundle;
                    }
                }
            }
            return null;
        }


        private static IEnumerator LoadBundleSkyboxes()
        {
            if (Directory.Exists(BundlesPath))
            {
                var files = Directory.GetFiles(BundlesPath).ToList();
                if (files.IsNotEmpty())
                    for (var i1 = 0; i1 < files.Count; i1++)
                    {
                        var file = files[i1];
                        if (!IsBundleAlreadyRegistered(Path.GetFileName(file)))
                        {
                            var bundle = GetValidBundle(file);

                            LoadSkyboxBundle(file, bundle);

                            yield return null;


                        }
                        else
                        {
                            Log.Warn("Skipping Registered Skybox :" + Path.GetFileName(file));
                        }
                    }
            }
            else
            {
                Directory.CreateDirectory(BundlesPath);
                Log.Warn("To Add custom Skyboxes , import the skyboxes assetbundles here : " + BundlesPath);
            }

            yield break;
        }


        private static void LoadSkyboxBundle(string file, AssetBundle bundle)
        {
            if(bundle == null)
            {
                Log.Warn($"Bundle Is null for File {file}");
                return;
            }
            Texture2D Up = null;
            Texture2D Down = null;
            Texture2D Back = null;
            Texture2D Front = null;
            Texture2D Left = null;
            Texture2D Right = null;
            Texture2D CubeMapToTexture = null;
            var isCubeMap = false;
            Material Material = null;
            foreach(var paths in bundle.GetAllAssetNames())
            {
                Log.Write($"Checking {bundle.name} Path {paths}");



                if (!paths.ToLower().EndsWith(".mat")) continue;
                Material = bundle.LoadAsset(paths, Il2CppType.Of<Material>()).Cast<Material>();
                Material.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                foreach (var TextureName in Material.GetTexturePropertyNames())
                {
                    var MaterialTexture = Material.GetTexture(TextureName);
                    if (Up == null && TextureName.isMatch("_UpTex"))
                    {
                        Up = MaterialTexture.ToTexture2D();
                        if (Up != null) Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    if (Down == null && TextureName.isMatch("_DownTex"))
                    {
                        Down = MaterialTexture.ToTexture2D();
                        if (Down != null) Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    if (Back == null && TextureName.isMatch("_BackTex"))
                    {
                        Back = MaterialTexture.ToTexture2D();
                        if (Back != null) Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    if (Front == null && TextureName.isMatch("_FrontTex"))
                    {
                        Front = MaterialTexture.ToTexture2D();
                        if (Front != null) Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    if (Left == null && TextureName.isMatch("_LeftTex"))
                    {
                        Left = MaterialTexture.ToTexture2D();
                        if (Left != null) Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    if (Right == null && TextureName.isMatch("_RightTex"))
                    {
                        Right = MaterialTexture.ToTexture2D();
                        if (Right != null) Right.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    if (CubeMapToTexture == null && TextureName.isMatch("_Tex"))
                    {
                        isCubeMap = true;
                        //CubeMapToTexture = MaterialTexture.TryCast<Cubemap>().ToTexture2D();
                        //if (CubeMapToTexture != null) CubeMapToTexture.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }
                }

            }
            if (Material != null)
            {
                var cachedskybox = new AssetBundleSkyboxes(Path.GetFileName(file), new BundleContent(Up, Down, Back, Front, Left, Right, CubeMapToTexture, null, Material), isCubeMap);
                if (LoadedSkyboxesBundles != null) LoadedSkyboxesBundles.Add(cachedskybox);
            }
            else
            {
                Log.Debug("Failed to parse " + file + ", Due to Material being null!");
                FailedLoadedBundles.Add(bundle); 
            }
        }

        internal static void FindAndLoadSkyboxes()
        {
            //MelonCoroutines.Start(LoadBundleSkyboxes());
            MelonCoroutines.Start(LoadPNGsSkyboxes());
            Log.Write("Done checking for skyboxes.");
        }

        internal static bool ExportSixSidedSkybox()
        {
            if (!isSupportedSkybox) return false;
            if (OriginalSkybox == null) return false;
            if (!Directory.Exists(YoinkedSkyboxesPath)) Directory.CreateDirectory(YoinkedSkyboxesPath);
            string SkyboxType = "Skybox";

            //foreach (var textureID in OriginalSkybox.GetTexturePropertyNames())
            //{
            //    if (textureID.isMatch("_Tex"))
            //    {
            //        SkyboxType = "CubeMap";
            //        return false; // Till we find a way, just disable everything if is not supported.
            //        break;
            //    }
            //}
            //if (TextureName.isMatch("_Tex") && MaterialTexture != null)
            //{
            //    Log.Debug("This is a cubemap Texture!");
            //    var cubemap = MaterialTexture.TryCast<Texture>().CreateReadableCopy();
            //    if (cubemap != null)
            //    {
            //        Log.Debug($"Created Copy of {cubemap.name}");
            //        SaveTexture(cubemap.ToTexture2D(), savepath, Texture_Name_Cubemap);
            //    }
            //    break;
            //}

            var savepath = Path.Combine(YoinkedSkyboxesPath, $"{SkyboxType}_" + OriginalSkybox.name);
            if (!Directory.Exists(savepath)) Directory.CreateDirectory(savepath);

            try
            {
                TextureTools.SaveTextureAsPNG(OriginalSkybox.GetTexture("_UpTex"), savepath, Side_Up);
                TextureTools.SaveTextureAsPNG(OriginalSkybox.GetTexture("_DownTex"), savepath, Side_Down);
                TextureTools.SaveTextureAsPNG(OriginalSkybox.GetTexture("_BackTex"), savepath, Side_Back);
                TextureTools.SaveTextureAsPNG(OriginalSkybox.GetTexture("_FrontTex"), savepath, Side_Front);
                TextureTools.SaveTextureAsPNG(OriginalSkybox.GetTexture("_LeftTex"), savepath, Side_Left);
                TextureTools.SaveTextureAsPNG(OriginalSkybox.GetTexture("_RightTex"), savepath, Side_Right);
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return false;
            }

            return true;
        }

        private static Material BuildSixSidedMaterial(Texture2D Up, Texture2D Down, Texture2D Back, Texture2D Front, Texture2D Left, Texture2D Right)
        {
            var reason = new StringBuilder();
            if (Up == null) reason.AppendLine("Up Texture is missing!");
            if (Down == null) reason.AppendLine("Down Texture is missing!");
            if (Back == null) reason.AppendLine("Back Texture is missing!");
            if (Front == null) reason.AppendLine("Front Texture is missing!");
            if (Left == null) reason.AppendLine("Left Texture is missing!");
            if (Right == null) reason.AppendLine("Right Texture is missing!");
            if (Up == null || Down == null || Back == null || Front == null || Left == null || Right == null)
            {
                Log.Debug("Failed Material Generation " + reason.ToString());
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
                Log.Error("Set a valid Skybox Name , Got " + name);
                return false;
            }

            if (LoadedSkyboxesBundles.IsEmpty())
            {
                Log.Error("There are no skybox Registered, unable to set a custom skybox.");
                return false;
            }

            for (int i = 0; i < LoadedSkyboxesBundles.Count; i++)
            {
                AssetBundleSkyboxes skybox = LoadedSkyboxesBundles[i];
                if (skybox != null && skybox.SkyboxName.ToLower().Equals(name.ToLower()))
                {
                    SetRenderSettingSkybox(skybox);
                    return true;
                }
            }

            return false;
        }

        internal class AssetBundleSkyboxes
        {
            internal AssetBundleSkyboxes(string SkyboxName, BundleContent content, bool isCubeMap)
            {
                this.SkyboxName = SkyboxName;
                this.content = content;
                this.isCubeMap = isCubeMap;
            }

            internal string SkyboxName { get; set; }

            internal BundleContent content { get; set; }

            internal bool isCubeMap { get; set; }
        }

        internal class BundleContent
        {
            internal BundleContent(Texture2D Up, Texture2D Down, Texture2D Back, Texture2D Front, Texture2D Left, Texture2D Right, Texture2D CubeMap, Texture2D Panorama, Material Material)
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

            internal Texture2D Up { get; set; }

            internal Texture2D Down { get; set; }

            internal Texture2D Back { get; set; }

            internal Texture2D Front { get; set; }

            internal Texture2D Left { get; set; }

            internal Texture2D Right { get; set; }

            internal Texture2D PanoramicSkybox { get; set; }

            internal Texture2D CubeMap { get; set; }

            internal Material Material { get; set; }

            internal void Destroy()
            {
                Object.Destroy(Up);
                Object.Destroy(Down);
                Object.Destroy(Back);
                Object.Destroy(Front);
                Object.Destroy(Left);
                Object.Destroy(Right);
                Object.Destroy(CubeMap);
                Object.Destroy(Material);
            }
        }
    }
}