namespace AstroClient.Tools.Skybox
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using xAstroBoy.Extensions;

    internal class SkyboxEditor : AstroEvents
    {
        internal static string SkyboxesPath
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, $"AstroSkyboxes");
            }
        }

        internal class AssetBundleSkyboxes
        {
            internal AssetBundle SkyboxBundle { get; set; }
            internal string SkyboxName { get; set; }
            internal string SkyboxMaterialPath { get; set; }

            internal AssetBundleSkyboxes(AssetBundle SkyboxBundle, string SkyboxName, string SkyboxMaterialPath)
            {
                this.SkyboxBundle = SkyboxBundle;
                this.SkyboxName = SkyboxName;
                this.SkyboxMaterialPath = SkyboxMaterialPath;
            }
        }

        internal class MaterialSkyboxes
        {
            internal Material SkyboxBundle { get; set; }
            internal string SkyboxName { get; set; }
            internal string SkyboxMaterialPath { get; set; }

            internal MaterialSkyboxes(Material SkyboxBundle, string SkyboxName, string SkyboxMaterialPath)
            {
                this.SkyboxBundle = SkyboxBundle;
                this.SkyboxName = SkyboxName;
                this.SkyboxMaterialPath = SkyboxMaterialPath;
            }
        }

        internal static List<AssetBundleSkyboxes> LoadedSkyboxesBundles { get; private set; } = new List<AssetBundleSkyboxes>();
        //internal static List<MaterialSkyboxes> LoadedSkyboxesMaterials { get; private set; } = new List<MaterialSkyboxes>();

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
            if (Directory.Exists(SkyboxesPath))
            {
                var files = Directory.GetFiles(SkyboxesPath).ToList();
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
                            var materialpath = string.Empty;
                            UnhollowerBaseLib.Il2CppStringArray list = bundle.GetAllAssetNames();
                            for (int i = 0; i < list.Count; i++)
                            {
                                string assetname = list[i];
                                //ModConsole.DebugLog("Searching for Mat File in path : " + assetname);
                                if (assetname.ToLower().EndsWith(".mat"))
                                {
                                    //ModConsole.DebugLog("Found Material File :" + assetname);
                                    materialpath = assetname;
                                    break;
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(materialpath) && !string.IsNullOrEmpty(materialpath))
                            {
                                //ModConsole.Log($"Parsed Skybox : {Path.GetFileName(file)} Succesfully!");
                                var cachedskybox = new AssetBundleSkyboxes(bundle, Path.GetFileName(file), materialpath);
                                if (LoadedSkyboxesBundles != null)
                                {
                                    if (!LoadedSkyboxesBundles.Contains(cachedskybox))
                                    {
                                        //ModConsole.DebugLog($"Saved Skybox in list");
                                        LoadedSkyboxesBundles.Add(cachedskybox);
                                    }
                                }
                            }
                            else
                            {
                                ModConsole.Warning($"Failed to parse Skybox : {Path.GetFileName(file)} Succesfully!");
                            }
                        }

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
                    ModConsole.Warning("To Add custom Skyboxes , import the skyboxes assetbundles here : " + SkyboxesPath);
                }
            }
            else
            {
                _ = Directory.CreateDirectory(SkyboxesPath);
                ModConsole.Warning("To Add custom Skyboxes , import the skyboxes assetbundles here : " + SkyboxesPath);
            }

            ModConsole.Log("Done checking for skyboxes.");
            yield break;
        }

        internal static void SetRenderSettingSkybox(Material mat)
        {
            RenderSettings.skybox = mat;
        }
        internal static void SetRenderSettingSkybox(AssetBundleSkyboxes skybox)
        {
            SetRenderSettingSkybox(skybox.SkyboxBundle.LoadAsset_Internal(skybox.SkyboxMaterialPath, Il2CppType.Of<Material>()).Cast<Material>());
        }


        internal static bool SetSkyboxByFileName(string name)
        {
            if(!name.IsNotNullOrEmptyOrWhiteSpace())
            {
                ModConsole.DebugError($"Set a valid Skybox Name , Got {name}");
                return false;
            }
            if(LoadedSkyboxesBundles.Count() == 0)
            {
                ModConsole.Error($"There are no skybox Registered, unable to set a custom skybox.");
                return false;
            }
            if (LoadedSkyboxesBundles.Count() != 0)
            {
                foreach (var skybox in LoadedSkyboxesBundles)
                {
                    if(skybox != null)
                    {
                        if(skybox.SkyboxName.ToLower().Equals(name.ToLower()))
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