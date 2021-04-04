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
        public class Skyboxes
        {
            public AssetBundle SkyboxBundle { get; set; }
            public string SkyboxName { get; set; }
            public string SkyboxMaterialPath { get; set; }
            public Skyboxes(AssetBundle SkyboxBundle, string SkyboxName, string SkyboxMaterialPath)
            {
                this.SkyboxBundle = SkyboxBundle;
                this.SkyboxName = SkyboxName;
                this.SkyboxMaterialPath = SkyboxMaterialPath;
            }
        }

        public static List<Skyboxes> LoadedSkyboxes = new List<Skyboxes>();

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

        public static bool IsFileAlreadyRegistered(string filename)
        {
            return LoadedSkyboxes.Where(x => x.SkyboxName == filename).Any();;
        }

        public static IEnumerator FindAndLoadBundle()
        {
            if (Directory.Exists(SkyboxesPath))
            {
                
                var files = Directory.GetFiles(SkyboxesPath).ToList();
                if (files.isNotEmpty())
                {
                    foreach (var file in files)
                    {
                        if (!IsFileAlreadyRegistered(Path.GetFileName(file)))
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
                                var cachedskybox = new Skyboxes(bundle, Path.GetFileName(file), materialpath);
                                if (LoadedSkyboxes != null)
                                {
                                    if (!LoadedSkyboxes.Contains(cachedskybox))
                                    {
                                        ModConsole.DebugLog($"Saved Skybox in list");
                                        LoadedSkyboxes.Add(cachedskybox);
                                    }
                                }
                            }
                            else
                            {
                                ModConsole.Warning($"Failed to parse Skybox : {Path.GetFileName(file)} Succesfully!");
                            }
                        }
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
                scroll.Refresh();
            }, "", null, null, true);
            new QMSingleButton(menu, 0, 0.5f, "Reset Skybox", delegate
            {
                SetNewSkybox(OriginalSkybox);
            }, "", null, null, true);
            new QMSingleButton(menu, 0, 0f, "Reload bundles", delegate
            {
                ModConsole.Log("[Skybox Loader (VR MODE) ] : This will Probably take awhile...");
                MelonLoader.MelonCoroutines.Start(FindAndLoadBundle());
            }, "", null, null, true);
            scroll.SetAction(delegate
            {
                if (LoadedSkyboxes.Count() != 0)
                {
                    foreach (var skybox in LoadedSkyboxes)
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
