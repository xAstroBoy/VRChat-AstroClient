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

        internal static string ExportedSkyboxPath => Path.Combine(SkyboxesPath, "ExportedSkyboxes");
        internal static string SixSidedCubePath => Path.Combine(ExportedSkyboxPath, "6 Sided");
        internal static string CubemapsPath => Path.Combine(ExportedSkyboxPath, "Cubemaps");

        internal static Dictionary<string, GeneratedSkyboxes> GeneratedSkyboxesList { get; set; } = new();

        internal static Material OriginalSkybox { get; set; } = null;

        internal static bool isUsingCustomSkybox { get; set; } = false;

        internal static bool isSupportedSkybox { get; private set; } = false;
        internal static bool isSixSidedCube { get; private set; } = false;
        internal static bool isCubeMap { get; private set; } = false;

        internal static List<AssetBundle> FailedLoadedBundles { get; } = new();
        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasLoadedCachedSkyboxes)
            {
                Log.Debug("[Skybox Loader] : This will Probably take awhile...");
                FindAndLoadSkyboxes();
                HasLoadedCachedSkyboxes = true;
            }
            isUsingCustomSkybox = false;
            if (RenderSettings.skybox != null)
            {
                Log.Debug("[Skybox INFO] : Material name : " + RenderSettings.skybox.name);
                Log.Debug("[Skybox INFO] : Material Shader : " + RenderSettings.skybox.shader.name);
                var ReadTextureIDs = RenderSettings.skybox.GetTexturePropertyNames().ToList();
                for (int i = 0; i < ReadTextureIDs.Count; i++)
                {
                    var name = ReadTextureIDs[i];
                    Log.Debug($"[Skybox INFO] : Texture name : {name}, Type : {RenderSettings.skybox.GetTexture(name).GetIl2CppType().FullName} ");
                }

                if (RenderSettings.skybox.shader.name.Contains("Cubemap"))
                {
                    isCubeMap = true;
                    isSupportedSkybox = true;
                }
                else
                {


                    
                    var textureIDs = RenderSettings.skybox.GetTexturePropertyNames().ToList();
                    if (textureIDs.Contains("_UpTex") && textureIDs.Contains("_DownTex") && textureIDs.Contains("_BackTex") &&
                        textureIDs.Contains("_FrontTex") && textureIDs.Contains("_LeftTex") && textureIDs.Contains("_RightTex"))
                    {
                        isSixSidedCube = true;
                        isCubeMap = false;
                        Log.Debug("This Skybox can be Exported!");
                        isSupportedSkybox = true;
                        if (Bools.IsDeveloper)
                        {
                            PopupUtils.QueHudMessage("This Skybox can Be Exported!".ToRainbow());
                        }
                    }
                    else if (textureIDs.Contains("_Tex"))
                    {
                        var textureType = RenderSettings.skybox.GetTexture("_Tex").GetIl2CppType().FullName;
                        if (textureType.Contains("Cubemap"))
                        {
                            isSixSidedCube = false;
                            isCubeMap = true;
                            isSupportedSkybox = true;
                            Log.Debug("This Skybox can be Exported!");
                            if (Bools.IsDeveloper)
                            {
                                PopupUtils.QueHudMessage("This Skybox can Be Exported!".ToRainbow());
                            }
                            return;
                        }
                    }
                    else
                    {
                        isSixSidedCube = false;
                        isCubeMap = false;
                        isSupportedSkybox = true;
                    }
                }


            }
            else
            {
                isSixSidedCube = false;
                isCubeMap = false;
                isSupportedSkybox = false;
            }
        }

        private void OnRoomLeft()
        {
            isSixSidedCube = false;
            isSupportedSkybox = false;
            isUsingCustomSkybox = false;
            OriginalSkybox = null;
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
                        if (!IsBundleAlreadyRegistered(Path.GetFileName(dir)))
                        {
                            var images = Directory.GetFiles(dir);
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
                                if (Up == null && imagepaths.EndsWith(Image_Up + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Up = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Up != null)
                                    {
                                        Up.wrapMode = TextureWrapMode.Clamp;
                                        Up.Apply();
                                        Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Down == null && imagepaths.EndsWith(Image_Down + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Down = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Down != null)
                                    {
                                        Down.wrapMode = TextureWrapMode.Clamp;
                                        Down.Apply();
                                        Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Back == null && imagepaths.EndsWith(Image_Back + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Back = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Back != null)
                                    {
                                        Back.wrapMode = TextureWrapMode.Clamp;
                                        Back.Apply();
                                        Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Front == null && imagepaths.EndsWith(Image_Front + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Front = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Front != null)
                                    {
                                        Front.wrapMode = TextureWrapMode.Clamp;
                                        Front.Apply();
                                        Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Left == null && imagepaths.EndsWith(Image_Left + ".png", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Left = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Left != null)
                                    {
                                        Left.wrapMode = TextureWrapMode.Clamp;
                                        Left.Apply();
                                        Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Right == null && imagepaths.EndsWith(Image_Right + ".png", StringComparison.CurrentCultureIgnoreCase))
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
                            try
                            {
                                var cachedskybox = new GeneratedSkyboxes(Up, Down, Back, Front, Left, Right, Path.GetFileName(dir));
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
                        else
                        {
                            Log.Warn("Skipping Registered Exported Skybox :" + Path.GetFileName(dir));
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

        internal static bool ExportSkybox()
        {
            if (isUsingCustomSkybox) return false;
            if (!isSupportedSkybox) return false;
            if (RenderSettings.skybox == null) return false;
            if (!Directory.Exists(ExportedSkyboxPath)) Directory.CreateDirectory(ExportedSkyboxPath);
            if (isSixSidedCube)
            {
                
                var savepath = SavePath(SixSidedCubePath,  RenderSettings.skybox.name);
                if (!Directory.Exists(savepath)) Directory.CreateDirectory(savepath);
                try
                {
                    RenderSettings.skybox.GetTexture("_UpTex").SaveTextureAsPNG(savepath, SixSidedFaces.UpTex);
                    RenderSettings.skybox.GetTexture("_DownTex").SaveTextureAsPNG(savepath, SixSidedFaces.DownTex);
                    RenderSettings.skybox.GetTexture("_BackTex").SaveTextureAsPNG(savepath, SixSidedFaces.BackTex);
                    RenderSettings.skybox.GetTexture("_FrontTex").SaveTextureAsPNG(savepath, SixSidedFaces.FrontTex);
                    RenderSettings.skybox.GetTexture("_LeftTex").SaveTextureAsPNG(savepath, SixSidedFaces.LeftTex);
                    RenderSettings.skybox.GetTexture("_RightTex").SaveTextureAsPNG(savepath, SixSidedFaces.RightTex);
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                    return false;
                }
            }
            if (isCubeMap)
            {
                var savepath = SavePath(CubemapsPath,  RenderSettings.skybox.name);
                if (!Directory.Exists(savepath)) Directory.CreateDirectory(savepath);
                try
                {
                    var Tex = RenderSettings.skybox.GetTexture("_Tex").Cast<Cubemap>();
                    if(Tex != null)
                    {
                        Log.Debug("This is a Cubemap! Attempting to save...");
                        CubeMapAndTexture2D.SaveCubemapToFile(Tex, savepath);
                    }
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                    return false;
                }

            }




            return true;
        }

        internal static void SetRenderSettingSkybox(Material mat)
        {
            if (mat != null)
            {
                if (!isUsingCustomSkybox)
                {
                    OriginalSkybox = RenderSettings.skybox;
                    isUsingCustomSkybox = true;
                }
                RenderSettings.skybox = mat;
            }
        }
        internal static void RestoreOriginalSkybox()
        {
            if (isUsingCustomSkybox)
            {
                isUsingCustomSkybox = false;
                RenderSettings.skybox = OriginalSkybox;
                OriginalSkybox = null;
            }
        }

        internal static void SetRenderSettingSkybox(GeneratedSkyboxes skybox)
        {
            SetRenderSettingSkybox(skybox.Material);
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
                SetRenderSettingSkybox(GeneratedSkyboxesList[name].Material);
                return true;
            }
            else
            {
                Log.Error("Skybox Not Found : " + name);
                return false;
            }

            return false;
        }

        internal static void ClearAll()
        {

            RestoreOriginalSkybox();
            foreach (var skybox in GeneratedSkyboxesList)
            {
                skybox.Value.Destroy();
            }
            GeneratedSkyboxesList.Clear();
            HasLoadedCachedSkyboxes = false;
        }

    
    }
}