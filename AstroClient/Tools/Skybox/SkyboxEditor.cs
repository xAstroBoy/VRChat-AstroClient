using AstroClient.ClientActions;
using AstroClient.Tools.Skybox.SkyboxClasses;
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

        private static string Side_Up { get; } = "Up";

        private static string Side_Down { get; } = "Down";

        private static string Side_Back { get; } = "Back";

        private static string Side_Front { get; } = "Front";

        private static string Side_Left { get; } = "Left";

        private static string Side_Right { get; } = "Right";

        private static string Texture_Name_Panoramic { get; } = "Panoramic";

        internal static string SkyboxesPath => Path.Combine(Environment.CurrentDirectory, "AstroSkyboxes");

        internal static string BundlesPath => Path.Combine(SkyboxesPath, "Bundles");

        internal static string ExportedSkyboxPath => Path.Combine(SkyboxesPath, "ExportedSkyboxes");
        internal static string SixSidedCubePath => Path.Combine(ExportedSkyboxPath, "6 Sided");
        internal static string CubemapsPath => Path.Combine(ExportedSkyboxPath, "Cubemaps");

        internal static List<GeneratedSkyboxes> GeneratedSkyboxesList { get; } = new();

        private static Material OriginalSkybox { get; set; } = null;

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
                        Log.Debug("This Skybox can be Yoinked!");
                        isSupportedSkybox = true;
                        if (Bools.IsDeveloper)
                        {
                            PopupUtils.QueHudMessage("This Skybox can Be Yoinked!");
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
            return GeneratedSkyboxesList != null && GeneratedSkyboxesList.Where(x => x.Name == filename).Any();
        }

        private static IEnumerator LoadSixSidedSkyboxes()
        {
            if (Directory.Exists(SixSidedCubePath))
            {
                var YoinkedSkyboxesDirs = Directory.GetDirectories(SixSidedCubePath).ToList();
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
                            var cachedskybox = new GeneratedSkyboxes(Up, Down, Back, Front, Left, Right, Path.GetFileName(dir));
                            if (cachedskybox != null)
                            {
                                if (cachedskybox.Material != null)
                                {
                                    GeneratedSkyboxesList.Add(cachedskybox);
                                }
                                else
                                {
                                    Log.Error($"Unable to Generate Material For {Path.GetFileName(dir)}");
                                    cachedskybox.Destroy();
                                }
                            }



                            yield return new WaitForSeconds(0.001f);
                        }
                        else
                        {
                            Log.Warn("Skipping Registered Yoinked Skybox :" + Path.GetFileName(dir));
                        }
                    }
                else
                    Log.Warn("No Skyboxes Found here : " + SixSidedCubePath);
            }
            else
            {
                Directory.CreateDirectory(SixSidedCubePath);
            }
            yield return null;
        }
         private static IEnumerator LoadCubemaps()
        {
            if (Directory.Exists(CubemapsPath))
            {
                var CubeMapsFolders = Directory.GetDirectories(CubemapsPath).ToList();
                if (CubeMapsFolders.IsNotEmpty())
                    for (var i1 = 0; i1 < CubeMapsFolders.Count; i1++)
                    {
                        var dir = CubeMapsFolders[i1];
                        if (!IsBundleAlreadyRegistered(Path.GetFileName(dir)))
                        {
                            var images = Directory.GetFiles(dir).ToList();
                            if (images.IsEmpty()) continue;
                            Texture2D Right = null;
                            Texture2D Left = null;
                            Texture2D Up = null;
                            Texture2D Down = null;
                            Texture2D Back = null;
                            Texture2D Front = null;
                            foreach (var imagepaths in images)
                            {
                                if (Right == null && imagepaths.EndsWith(CubemapFace.PositiveX + ".png"))
                                {
                                    Right = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Right != null)
                                    {
                                        Right.wrapMode = TextureWrapMode.Clamp;
                                        Right.Apply();
                                        Right.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Left == null && imagepaths.EndsWith(CubemapFace.NegativeX + ".png"))
                                {
                                    Left = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Left != null)
                                    {
                                        Left.wrapMode = TextureWrapMode.Clamp;
                                        Left.Apply();
                                        Left.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Up == null && imagepaths.EndsWith(CubemapFace.PositiveY + ".png"))
                                {
                                    Up = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Up != null)
                                    {
                                        Up.wrapMode = TextureWrapMode.Clamp;
                                        Up.Apply();
                                        Up.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Down == null && imagepaths.EndsWith(CubemapFace.NegativeY + ".png"))
                                {
                                    Down = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Down != null)
                                    {
                                        Down.wrapMode = TextureWrapMode.Clamp;
                                        Down.Apply();
                                        Down.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Back == null && imagepaths.EndsWith(CubemapFace.PositiveZ + ".png"))
                                {
                                    Back = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Back != null)
                                    {
                                        Back.wrapMode = TextureWrapMode.Clamp;
                                        Back.Apply();
                                        Back.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }

                                if (Front == null && imagepaths.EndsWith(CubemapFace.NegativeZ + ".png"))
                                {
                                    Front = CheetoUtils.LoadPNGFromDir(imagepaths);
                                    if (Front != null)
                                    {
                                        Front.wrapMode = TextureWrapMode.Clamp;
                                        Front.Apply();
                                        Front.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                                    }
                                }
                            }
                            var cachedskybox = new GeneratedSkyboxes(Up, Down, Back, Front, Left, Right, Path.GetFileName(dir));
                            if (cachedskybox != null)
                            {
                                if (cachedskybox.Material != null)
                                {
                                    GeneratedSkyboxesList.Add(cachedskybox);
                                }
                                else
                                {
                                    Log.Error($"Unable to Generate Material For {Path.GetFileName(dir)}");
                                    cachedskybox.Destroy();
                                }
                            }



                            yield return new WaitForSeconds(0.001f);
                        }
                        else
                        {
                            Log.Warn("Skipping Registered Yoinked Skybox :" + Path.GetFileName(dir));
                        }
                    }
                else
                    Log.Warn("No Skyboxes Found here : " + CubemapsPath);
            }
            else
            {
                Directory.CreateDirectory(CubemapsPath);
            }
            yield return null;
        }




        internal static void FindAndLoadSkyboxes()
        {
            //MelonCoroutines.Start(LoadBundleSkyboxes());
            MelonCoroutines.Start(LoadSixSidedSkyboxes());
            MelonCoroutines.Start(LoadCubemaps());
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
                    RenderSettings.skybox.GetTexture("_UpTex").SaveTextureAsPNG(savepath, Side_Up);
                    RenderSettings.skybox.GetTexture("_DownTex").SaveTextureAsPNG(savepath, Side_Down);
                    RenderSettings.skybox.GetTexture("_BackTex").SaveTextureAsPNG(savepath, Side_Back);
                    RenderSettings.skybox.GetTexture("_FrontTex").SaveTextureAsPNG(savepath, Side_Front);
                    RenderSettings.skybox.GetTexture("_LeftTex").SaveTextureAsPNG(savepath, Side_Left);
                    RenderSettings.skybox.GetTexture("_RightTex").SaveTextureAsPNG(savepath, Side_Right);
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
            if (!isUsingCustomSkybox)
            {
                OriginalSkybox = RenderSettings.skybox;
                isUsingCustomSkybox = true;
            }
            RenderSettings.skybox = mat;
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

            for (int i = 0; i < GeneratedSkyboxesList.Count; i++)
            {
                GeneratedSkyboxes skybox = GeneratedSkyboxesList[i];
                if (skybox != null && skybox.Name.ToLower().Equals(name.ToLower()))
                {
                    SetRenderSettingSkybox(skybox);
                    return true;
                }
            }


            return false;
        }



    
    }
}