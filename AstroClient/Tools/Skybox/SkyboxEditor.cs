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
    using CubemapTools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using Object = UnityEngine.Object;

    internal class SkyboxEditor : AstroEvents
    {
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


        internal static bool isSupportedSkybox { get; private set; }= false;

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasLoadedCachedSkyboxes)
            {
                ModConsole.DebugLog("[Skybox Loader] : This will Probably take awhile...");
                FindAndLoadSkyboxes();
                HasLoadedCachedSkyboxes = true;
            }

            OriginalSkybox = RenderSettings.skybox;
            var texlist = OriginalSkybox.GetTexturePropertyNames();
            if (texlist.Contains("_UpTex") && texlist.Contains("_DownTex") && texlist.Contains("_BackTex") && texlist.Contains("_FrontTex") && texlist.Contains("_LeftTex") && texlist.Contains("_RightTex"))
            {
                isSupportedSkybox = true;
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            OriginalSkybox = null;
            isSupportedSkybox = false;
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
                                ModConsole.DebugLog("Found File in " + imagepaths);
                                if (Up == null && imagepaths.EndsWith(Side_Up + ".png"))
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

                                if (Down == null && imagepaths.EndsWith(Side_Down + ".png"))
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

                                if (Back == null && imagepaths.EndsWith(Side_Back + ".png"))
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

                                if (Front == null && imagepaths.EndsWith(Side_Front + ".png"))
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

                                if (Left == null && imagepaths.EndsWith(Side_Left + ".png"))
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

                                if (Right == null && imagepaths.EndsWith(Side_Right + ".png"))
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

                            var GeneratedMaterial = BuildSixSidedMaterial(Up, Down, Back, Front, Left, Right);
                            if (GeneratedMaterial != null)
                            {
                                var SkyboxName = GeneratedMaterial.name = Path.GetFileName(dir);
                                GeneratedMaterial.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                var cachedskybox = new AssetBundleSkyboxes(SkyboxName, new BundleContent(Up, Down, Back, Front, Left, Right, null, null, GeneratedMaterial), false);
                                if (LoadedSkyboxesBundles != null) LoadedSkyboxesBundles.Add(cachedskybox);
                            }

                            yield return new WaitForSeconds(0.001f);
                        }
                        else
                        {
                            ModConsole.Warning("Skipping Registered Yoinked Skybox :" + Path.GetFileName(dir));
                        }
                    }
                else
                    ModConsole.Warning("No Skyboxes Found here : " + YoinkedSkyboxesPath);
            }
            else
            {
                Directory.CreateDirectory(YoinkedSkyboxesPath);
            }

            yield return null;
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
                            var stream = File.ReadAllBytes(file);
                            var bundle = AssetBundle.LoadFromMemory(stream.ToArray(), 0u);
                            bundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            Texture2D Up = null;
                            Texture2D Down = null;
                            Texture2D Back = null;
                            Texture2D Front = null;
                            Texture2D Left = null;
                            Texture2D Right = null;
                            Texture2D CubeMapToTexture = null;
                            var isCubeMap = false;
                            Material Material = null;
                            foreach (var paths in bundle.GetAllAssetNames())
                            {
                                if (!paths.ToLower().EndsWith(".mat") || !(Material == null)) continue;
                                Material = bundle.LoadAsset_Internal(paths, Il2CppType.Of<Material>()).Cast<Material>();
                                if (!(Material != null)) continue;
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
                                ModConsole.DebugLog("Failed to parse " + file + ", Due to Material being null!");
                            }

                            yield return new WaitForSeconds(0.001f);
                        }
                        else
                        {
                            ModConsole.Warning("Skipping Registered Skybox :" + Path.GetFileName(file));
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
            MelonCoroutines.Start(LoadBundleSkyboxes());
            MelonCoroutines.Start(LoadPNGsSkyboxes());
            ModConsole.Log("Done checking for skyboxes.");
        }

        internal static bool ExportSkybox()
        {
            if (OriginalSkybox == null) return false;
            if (!Directory.Exists(YoinkedSkyboxesPath)) Directory.CreateDirectory(YoinkedSkyboxesPath);
            ModConsole.DebugLog("[Skybox INFO] : Material name : " + OriginalSkybox.name);
            ModConsole.DebugLog("[Skybox INFO] : Material Shader : " + OriginalSkybox.shader.name);
            foreach (var textureID in OriginalSkybox.GetTexturePropertyNames()) ModConsole.DebugLog("[Skybox INFO] : Texture name : " + textureID);
            string SkyboxType = "Skybox";

            foreach (var textureID in OriginalSkybox.GetTexturePropertyNames())
            {
                if (textureID.isMatch("_Tex"))
                {
                    SkyboxType = "CubeMap";
                    return false; // Till we find a way, just disable everything if is not supported.
                    break;
                }
            }


            var savepath = Path.Combine(YoinkedSkyboxesPath, $"{SkyboxType}_" + OriginalSkybox.name);
            if (!Directory.Exists(savepath)) Directory.CreateDirectory(savepath);
            foreach (var TextureName in OriginalSkybox.GetTexturePropertyNames())
            {
                var MaterialTexture = OriginalSkybox.GetTexture(TextureName);
                //if (TextureName.isMatch("_Tex") && MaterialTexture != null)
                //{
                //    ModConsole.DebugLog("This is a cubemap Texture!");
                //    var cubemap = MaterialTexture.TryCast<Texture>().CreateReadableCopy();
                //    if (cubemap != null)
                //    {
                //        ModConsole.DebugLog($"Created Copy of {cubemap.name}");
                //        SaveTexture(cubemap.ToTexture2D(), savepath, Texture_Name_Cubemap);
                //    }
                //    break;
                //}

                if (TextureName.isMatch("_UpTex")) SaveTexture(MaterialTexture.ToTexture2D(), savepath, Side_Up);
                if (TextureName.isMatch("_DownTex")) SaveTexture(MaterialTexture.ToTexture2D(), savepath, Side_Down);
                if (TextureName.isMatch("_BackTex")) SaveTexture(MaterialTexture.ToTexture2D(), savepath, Side_Back);
                if (TextureName.isMatch("_FrontTex")) SaveTexture(MaterialTexture.ToTexture2D(), savepath, Side_Front);
                if (TextureName.isMatch("_LeftTex")) SaveTexture(MaterialTexture.ToTexture2D(), savepath, Side_Left);
                if (TextureName.isMatch("_RightTex")) SaveTexture(MaterialTexture.ToTexture2D(), savepath, Side_Right);
                return true;
            }

            return true;
        }

        private static void YoinkCubeMaps(Cubemap map)
        {
            if (map != null)
            {
                ModConsole.DebugLog("Found Cubemap " + map.name);
                var savepath = Path.Combine(YoinkedSkyboxesPath, "Cubemap_" + map.name);
                if (!Directory.Exists(savepath)) Directory.CreateDirectory(savepath);
                CubeMapAndTexture2D.SaveCubemapToFile(map, savepath);
            }
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
                ModConsole.DebugLog("Failed Material Generation " + reason.ToString());
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
            var bytes = ImageConversion.EncodeToPNG(texture).ToArray();
            var filepath = Path.Combine(path, direction + ".png");
            File.WriteAllBytes(filepath, bytes);
            ModConsole.DebugLog("Generated Skybox File : " + filepath);
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
                ModConsole.DebugError("Set a valid Skybox Name , Got " + name);
                return false;
            }

            if (LoadedSkyboxesBundles.IsEmpty())
            {
                ModConsole.Error("There are no skybox Registered, unable to set a custom skybox.");
                return false;
            }

            foreach (var skybox in LoadedSkyboxesBundles)
                if (skybox != null && skybox.SkyboxName.ToLower().Equals(name.ToLower()))
                {
                    SetRenderSettingSkybox(skybox);
                    return true;
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