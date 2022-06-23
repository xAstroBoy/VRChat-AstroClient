using AstroClient.ClientActions;
using AstroClient.Tools.Skybox.SkyboxClasses;
using AstroClient.Tools.Skybox.SkyboxStructs;
using AstroClient.Tools.TextureTools;

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
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnWorldReveal += OnWorldReveal;

        }

        private static bool HasLoadedCachedSkyboxes;


        private static string Texture_Name_Panoramic { get; } = "Panoramic";

        internal static string SkyboxesPath => Path.Combine(Environment.CurrentDirectory, "AstroSkyboxes");

        internal static string BundlesPath => Path.Combine(SkyboxesPath, "Bundles");

        internal static string SixSidedCubePath => Path.Combine(SkyboxesPath, "6 Sided");
        internal static string CubemapsPath => Path.Combine(SkyboxesPath, "Cubemaps");

        internal static Dictionary<string, GeneratedSkyboxes> GeneratedSkyboxesList { get; set; } = new();

        internal static List<Material> ExportedSkyboxes { get; set; } = new();
        internal static GeneratedSkyboxes SelectedSkybox { get; set; }
        internal static Material OriginalSkybox { get; set; } = null;

        internal static bool isUsingCustomSkybox { get; set; } = false;

        internal static bool isSixSidedCube { get; private set; } = false;
        internal static bool isCubeMap { get; private set; } = false;

        internal static List<AssetBundle> FailedLoadedBundles { get; } = new();

        internal static void RefreshMaterialTextures()
        {
            if (SelectedSkybox != null)
            {
                MelonCoroutines.Start(SelectedSkybox.UpdateTextures());
            }
        }

        internal static bool hasExportedSkybox()
        {
            if (!isUsingCustomSkybox)
            {
                if (!CanExtract())
                {
                    return false;
                }
                if (ExportedSkyboxes != null)
                {
                    if (ExportedSkyboxes.Count != 0)
                    {
                        if (ExportedSkyboxes.Contains(RenderSettings.skybox))
                        {
                            return true;

                        }
                    }
                }
            }
            return false;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasLoadedCachedSkyboxes)
            {
                Log.Debug("[Skybox Loader] : This will Probably take awhile...");
                FindAndLoadSkyboxes();
                HasLoadedCachedSkyboxes = true;
            }
            isUsingCustomSkybox = false;
            PrintSkyboxInfo();
            if(CanExtract())
            {
                Log.Debug("This Skybox can be Exported!");
                if (Bools.IsDeveloper)
                {
                    PopupUtils.QueHudMessage("This Skybox can Be Exported!".RainbowRichText());
                }
            }

        }


        internal static bool CanExtract()
        {
            if (!isUsingCustomSkybox)
            {
                if (RenderSettings.skybox != null)
                {
                    var textureIDs = RenderSettings.skybox.GetTexturePropertyNames().ToList();
                    if (textureIDs.Contains("_UpTex") && textureIDs.Contains("_DownTex") && textureIDs.Contains("_BackTex") &&
                        textureIDs.Contains("_FrontTex") && textureIDs.Contains("_LeftTex") && textureIDs.Contains("_RightTex"))
                    {
                        isSixSidedCube = true;
                        isCubeMap = false;
                        return true;
                    }
                    else if (textureIDs.Contains("_Tex"))
                    {
                        if (RenderSettings.skybox.shader.name.ToLower().Contains("cubemap"))
                        {
                            var textureType = RenderSettings.skybox.GetTexture("_Tex").GetIl2CppType().FullName;
                            if (textureType.Contains("Cubemap"))
                            {
                                isSixSidedCube = false;
                                isCubeMap = true;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        isSixSidedCube = false;
                        isCubeMap = false;
                        return false;
                    }
                }
            }
            return false;
        }

        internal static void PrintSkyboxInfo()
        {
            try
            {
                if (!isUsingCustomSkybox)
                {
                    if (RenderSettings.skybox != null)
                    {
                        Log.Debug("[Skybox INFO] : Material name : " + RenderSettings.skybox.name);
                        Log.Debug("[Skybox INFO] : Material Shader : " + RenderSettings.skybox.shader.name);
                        var texturelist = RenderSettings.skybox.GetTexturePropertyNames();
                        if (texturelist != null)
                        {
                            if (texturelist.Count != 0)
                            {
                                for (int i = 0; i < texturelist.Count; i++)
                                {
                                    var name = texturelist[i];
                                    Log.Debug($"[Skybox INFO] : Texture name : {name}, Type : {RenderSettings.skybox.GetTexture(name).GetIl2CppType().FullName} ");
                                }
                            }
                        }
                    }
                }
            }
            catch{}
        }

        private void OnRoomLeft()
        {
            isSixSidedCube = false;
            isCubeMap = false;
            isUsingCustomSkybox = false;
            OriginalSkybox = null;
            SelectedSkybox = null;
            ExportedSkyboxes.Clear();
        }

        internal static bool IsBundleAlreadyRegistered(string filename)
        {
            if (GeneratedSkyboxesList.Count != 0)
            {
                return GeneratedSkyboxesList.ContainsKey(filename);
            }
            return false;
        }
        private static IEnumerator LoadFromPath(string MainFolder, string Image_Up, string Image_Down, string Image_Back, string Image_Front, string Image_Left, string Image_Right)
        {
            if (Directory.Exists(MainFolder))
            {
                var YoinkedSkyboxesDirs = Directory.GetDirectories(MainFolder);
                if (YoinkedSkyboxesDirs.IsNotEmpty())
                    for (var i1 = 0; i1 < YoinkedSkyboxesDirs.Length; i1++)
                    {
                        var dir = YoinkedSkyboxesDirs[i1];
                        var foldername = Path.GetFileName(dir);
                        if (!IsBundleAlreadyRegistered(foldername))
                        {
                            var images = Directory.GetFiles(dir);
                            if (images.IsEmpty()) continue;
                            Texture2D Up = null;
                            Texture2D Down = null;
                            Texture2D Back = null;
                            Texture2D Front = null;
                            Texture2D Left = null;
                            Texture2D Right = null;
                            string  Path_Up = null;
                            string  Path_Down = null;
                            string  Path_Back = null;
                            string  Path_Front = null;
                            string  Path_Left = null;
                            string  Path_Right = null;

                            foreach (var image_path in images)
                            {
                                //Log.Debug("Found File in " + imagepaths);
                                if (Up == null && image_path.EndsWith(Image_Up + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Path_Up = image_path;
                                    Up = CheetoUtils.LoadPNGFromDir(image_path);
                                    if (Up != null)
                                    {
                                        Up.wrapMode = TextureWrapMode.Clamp;
                                        Up.Apply();
                                        Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Down == null && image_path.EndsWith(Image_Down + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Path_Down = image_path;

                                    Down = CheetoUtils.LoadPNGFromDir(image_path);
                                    if (Down != null)
                                    {
                                        Down.wrapMode = TextureWrapMode.Clamp;
                                        Down.Apply();
                                        Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Back == null && image_path.EndsWith(Image_Back + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Path_Back = image_path;

                                    Back = CheetoUtils.LoadPNGFromDir(image_path);
                                    if (Back != null)
                                    {
                                        Back.wrapMode = TextureWrapMode.Clamp;
                                        Back.Apply();
                                        Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Front == null && image_path.EndsWith(Image_Front + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Path_Front = image_path;
                                    Front = CheetoUtils.LoadPNGFromDir(image_path);
                                    if (Front != null)
                                    {
                                        Front.wrapMode = TextureWrapMode.Clamp;
                                        Front.Apply();
                                        Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Left == null && image_path.EndsWith(Image_Left + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Path_Left = image_path;

                                    Left = CheetoUtils.LoadPNGFromDir(image_path);
                                    if (Left != null)
                                    {
                                        Left.wrapMode = TextureWrapMode.Clamp;
                                        Left.Apply();
                                        Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Right == null && image_path.EndsWith(Image_Right + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Path_Right = image_path;
                                    Right = CheetoUtils.LoadPNGFromDir(image_path);
                                    if (Right != null)
                                    {
                                        Right.wrapMode = TextureWrapMode.Clamp;
                                        Right.Apply();
                                        Right.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }
                            }
                            try
                            {

                                var cachedskybox = new GeneratedSkyboxes(Up, Path_Up, Down, Path_Down, Back, Path_Back, Front, Path_Front, Left, Path_Left, Right, Path_Right, foldername);
                                if (cachedskybox != null)
                                {
                                    GeneratedSkyboxesList.Add(cachedskybox.Name, cachedskybox);
                                }

                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                            }
                            yield return new WaitForSeconds(0.001f);
                        }

                    }
                else
                    Log.Warn("No Skyboxes Found here : " + MainFolder);
            }
            else
            {
                Directory.CreateDirectory(MainFolder);
            }
            yield return null;
        }




        internal static void FindAndLoadSkyboxes()
        {
            //MelonCoroutines.Start(LoadBundleSkyboxes());
            MelonCoroutines.Start(LoadFromPath(SixSidedCubePath, SixSidedFaces.UpTex, SixSidedFaces.DownTex, SixSidedFaces.BackTex, SixSidedFaces.FrontTex, SixSidedFaces.LeftTex, SixSidedFaces.RightTex));
            MelonCoroutines.Start(LoadFromPath(CubemapsPath, CubemapFace.PositiveY.ToString(), CubemapFace.NegativeY.ToString(), CubemapFace.PositiveZ.ToString(), CubemapFace.NegativeZ.ToString(), CubemapFace.NegativeX.ToString(), CubemapFace.PositiveX.ToString()));
            Log.Write("Done checking for skyboxes.");
        }

        private static string SavePath(string path, string SkyboxName, int count = 0)
        {
            var result = Path.Combine(path, SkyboxName); ;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                var files = Directory.GetFiles(path);
                if (files.Length != 0)
                {
                    var duplicate = count++;
                    return SavePath(path, SkyboxName + "_" + duplicate, duplicate);
                }
            }
            return result;
        }

        internal static void ExportSkybox()
        {
            if (isUsingCustomSkybox) return;
            if (RenderSettings.skybox == null) return;
            
            if (!Directory.Exists(SkyboxesPath)) Directory.CreateDirectory(SkyboxesPath);
            if (isSixSidedCube)
            {
                ExportSixSidedSkybox();
            }
            else if (isCubeMap)
            {
                ExportCubeMap();
            }
        }
        private static void ExportSixSidedSkybox()
        {
            var savepath = SavePath(SixSidedCubePath, RenderSettings.skybox.name);
            if (!Directory.Exists(savepath)) Directory.CreateDirectory(savepath);
            try
            {
                RenderSettings.skybox.GetTexture("_UpTex").SaveTextureAsPNG(savepath, SixSidedFaces.UpTex);
                RenderSettings.skybox.GetTexture("_DownTex").SaveTextureAsPNG(savepath, SixSidedFaces.DownTex);
                RenderSettings.skybox.GetTexture("_BackTex").SaveTextureAsPNG(savepath, SixSidedFaces.BackTex);
                RenderSettings.skybox.GetTexture("_FrontTex").SaveTextureAsPNG(savepath, SixSidedFaces.FrontTex);
                RenderSettings.skybox.GetTexture("_LeftTex").SaveTextureAsPNG(savepath, SixSidedFaces.LeftTex);
                RenderSettings.skybox.GetTexture("_RightTex").SaveTextureAsPNG(savepath, SixSidedFaces.RightTex);

                if (!ExportedSkyboxes.Contains(RenderSettings.skybox))
                {
                    ExportedSkyboxes.Add(RenderSettings.skybox);
                }
                return;
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return;
            }


        }

        private static void ExportCubeMap()
        {
            var savepath = SavePath(CubemapsPath, RenderSettings.skybox.name);
            if (!Directory.Exists(savepath)) Directory.CreateDirectory(savepath);
            try
            {
                var Tex = RenderSettings.skybox.GetTexture("_Tex").Cast<Cubemap>();
                if (Tex != null)
                {
                    Log.Debug("This is a Cubemap! Attempting to save...");
                    CubeMapAndTexture2D.SaveCubemapToFile(Tex, savepath);
                    if (!ExportedSkyboxes.Contains(RenderSettings.skybox))
                    {
                        ExportedSkyboxes.Add(RenderSettings.skybox);
                    }
                }
                return;
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return;
            }

        }

        internal static void SetRenderSettingSkybox(GeneratedSkyboxes Skybox)
        {
            if (Skybox != null)
            {
                if (!isUsingCustomSkybox)
                {
                    OriginalSkybox = RenderSettings.skybox;
                    isUsingCustomSkybox = true;
                }
                SelectedSkybox = Skybox;
                RenderSettings.skybox = Skybox.Material;
            }
        }
        internal static void RestoreOriginalSkybox()
        {
            if (isUsingCustomSkybox)
            {
                isUsingCustomSkybox = false;
                RenderSettings.skybox = OriginalSkybox;
                OriginalSkybox = null;
                SelectedSkybox = null;

            }
        }


        internal static bool SetSkyboxByFileName(string name)
        {
            if (!name.IsNotNullOrEmptyOrWhiteSpace())
            {
                Log.Error("Set a valid Skybox Name , Got " + name);
                return false;
            }
            if (GeneratedSkyboxesList.ContainsKey(name))
            {
                SetRenderSettingSkybox(GeneratedSkyboxesList[name]);
                return true;
            }
            else
            {
                Log.Error("Skybox Not Found : " + name);
                return false;
            }

            return false;
        }

    
    }
}