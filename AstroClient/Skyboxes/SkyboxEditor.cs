using AstroClient.ConsoleUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using AstroClient.extensions;
using UnhollowerRuntimeLib;
using RubyButtonAPI;

namespace AstroClient.Skyboxes
{
    public class SkyboxEditor : Overridables
    {
        public static string SkyboxesPath
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, $"AstroSkyboxes");
            }
        }
        public class AssetBundleSkyboxes
        {
            public AssetBundle SkyboxBundle { get; set; }
            public string SkyboxName { get; set; }
            public string SkyboxMaterialPath { get; set; }
            public AssetBundleSkyboxes(AssetBundle SkyboxBundle, string SkyboxName, string SkyboxMaterialPath)
            {
                this.SkyboxBundle = SkyboxBundle;
                this.SkyboxName = SkyboxName;
                this.SkyboxMaterialPath = SkyboxMaterialPath;
            }
        }

        public class MaterialSkyboxes
        {
            public Material SkyboxBundle { get; set; }
            public string SkyboxName { get; set; }
            public string SkyboxMaterialPath { get; set; }
            public MaterialSkyboxes(Material SkyboxBundle, string SkyboxName, string SkyboxMaterialPath)
            {
                this.SkyboxBundle = SkyboxBundle;
                this.SkyboxName = SkyboxName;
                this.SkyboxMaterialPath = SkyboxMaterialPath;
            }
        }


        public static List<AssetBundleSkyboxes> LoadedSkyboxesBundles = new List<AssetBundleSkyboxes>();
        public static List<MaterialSkyboxes> LoadedSkyboxesMaterials = new List<MaterialSkyboxes>();

        private static bool HasLoadedCachedSkyboxes = false;

        private static Material OriginalSkybox;

        public override void OnWorldReveal()
        {
            if(!HasLoadedCachedSkyboxes)
            {

                ModConsole.Log("[Skybox Loader] : This will Probably take awhile...");
                MelonLoader.MelonCoroutines.Start(FindAndLoadBundle());
                HasLoadedCachedSkyboxes = true;
            }
            OriginalSkybox = RenderSettings.skybox;

        }

        public override void OnLevelLoaded()
        {
            OriginalSkybox = null;
        }

        public static bool IsBundleAlreadyRegistered(string filename)
        {
            return LoadedSkyboxesBundles.Where(x => x.SkyboxName == filename).Any();;
        }

        public static bool IsMaterialAlreadyRegistered(string filename)
        {
            return LoadedSkyboxesMaterials.Where(x => x.SkyboxName == filename).Any(); ;
        }



        //public static void SaveCurrentSkybox()
        //{
        //    if(OriginalSkybox != null)
        //    {
        //        File.WriteAllBytes(Path.Combine(SkyboxesPath, ".png"), UnityEngine.ImageConversion.EncodeToPNG(OriginalSkybox.mainTexture));
        //    }
        //}



        public static IEnumerator FindAndLoadBundle()
        {
            if (Directory.Exists(SkyboxesPath))
            {
                
                var files = Directory.GetFiles(SkyboxesPath).ToList();
                if (files.isNotEmpty())
                {
                    foreach (var file in files)
                    {
                        if (!IsBundleAlreadyRegistered(Path.GetFileName(file)))
                        {
                            ModConsole.Log("Found Custom Skybox : " + Path.GetFileName(file));
                            var stream = File.ReadAllBytes(file);
                            var bundle = AssetBundle.LoadFromMemory(stream.ToArray(), 0);
                            bundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            var materialpath = String.Empty;
                            foreach (var assetname in bundle.GetAllAssetNames())
                            {
                                ModConsole.DebugLog("Searching for Mat File in path : " + assetname);
                                if (assetname.ToLower().EndsWith(".mat"))
                                {
                                    ModConsole.DebugLog("Found Material File :" + assetname);
                                    materialpath = assetname;
                                    break;
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(materialpath) && !string.IsNullOrEmpty(materialpath))
                            {
                                ModConsole.Log($"Parsed Skybox : {Path.GetFileName(file)} Succesfully!");
                                var cachedskybox = new AssetBundleSkyboxes(bundle, Path.GetFileName(file), materialpath);
                                if (LoadedSkyboxesBundles != null)
                                {
                                    if (!LoadedSkyboxesBundles.Contains(cachedskybox))
                                    {
                                        ModConsole.DebugLog($"Saved Skybox in list");
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
                        //if (file.EndsWith(".astromat"))
                        //{
                        //    if (!IsMaterialAlreadyRegistered(Path.GetFileName(file)))
                        //    {
                        //        Material newmat = null;
                        //        byte[] Bytes = File.ReadAllBytes(file);
                        //         if(Bytes != null)
                        //        {
                        //            newmat = (Material)Bytes;
                        //            if (newmat == null)
                        //            {
                        //            }






                        //        }
                        //    }
                        //}
                        else
                        {
                            ModConsole.Warning("Skipping Registered Skybox :" + Path.GetFileName(file));
                            continue;
                        }
                    }
                }
                else
                {
                    ModConsole.Warning("To Add custom Skyboxes , import the skyboxes assetbundles here : " + SkyboxesPath);
                }
            }
            else
            {
                Directory.CreateDirectory(SkyboxesPath);
                ModConsole.Warning("To Add custom Skyboxes , import the skyboxes assetbundles here : " + SkyboxesPath);

            }
            yield return null;
        }


        private static void SetNewSkybox(Material mat)
        {
            RenderSettings.skybox = mat;
        }



        public static void CustomSkyboxesMenu(QMNestedButton main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Skyboxes", "Change Map Skybox with a custom one", null, null, null, null, btnHalf);
            var scroll = new QMHalfScroll(menu);
            new QMSingleButton(menu, 0, -1, "Refresh", delegate
            {
                ModConsole.Log("[Skybox Loader (VR MODE) ] : This will Probably take awhile...");
                MelonLoader.MelonCoroutines.Start(FindAndLoadBundle());
                scroll.Refresh();
            }, "", null, null, true);
            new QMSingleButton(menu, 0, 0.5f, "Reset Skybox", delegate
            {
                SetNewSkybox(OriginalSkybox);
            }, "", null, null, true);
            scroll.SetAction(delegate
            {
                if (LoadedSkyboxesBundles.Count() != 0)
                {
                    foreach (var skybox in LoadedSkyboxesBundles)
                    {
                        if (skybox != null)
                        {
                            var tmp = new QMSingleButton(scroll.BaseMenu, 0, 0, $"Set : {skybox.SkyboxName}", null, $"Load Skybox {skybox.SkyboxName} as map Skybox.", null, null, true);
                            tmp.SetResizeTextForBestFit(true);
                            tmp.setAction(new Action(() =>
                            {
                                SetNewSkybox(skybox.SkyboxBundle.LoadAsset_Internal(skybox.SkyboxMaterialPath, Il2CppType.Of<Material>()).Cast<Material>());

                            }));
                            scroll.Add(tmp);
                        }
                    }
                }
                else
                {
                    var empty = new QMSingleButton(scroll.BaseMenu, 0, 0, $"No Skyboxes Found...", null, $"No Skybox Found...", null, null, true);
                    scroll.Add(empty);
                }
            });
        }


    }
}
