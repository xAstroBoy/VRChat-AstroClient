namespace CheetoLibrary
{
    using AstroLibrary.Console;
    using HarmonyLib;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class ChingChong
    {
        public class Patch
        {
            private static HarmonyMethod GetPatch(string name)
            {
                return new HarmonyMethod(typeof(GeneralPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
            }

            private static List<Patch> Patches = new List<Patch>();
            public MethodInfo TargetMethod { get; set; }
            public HarmonyMethod PrefixMethod { get; set; }
            public HarmonyMethod PostfixMethod { get; set; }
            public HarmonyMethod ExceptionFix { get; set; }
            public HarmonyLib.Harmony Instance { get; set; }

            public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
            {
                if (targetMethod == null || (Before == null && After == null))
                {
                    Console.WriteLine("[Patches] TargetMethod is NULL or Pre And PostFix are Null: ");
                    return;
                }
                Instance = new HarmonyLib.Harmony($"Patch:{targetMethod.DeclaringType.FullName}.{targetMethod.Name}");
                TargetMethod = targetMethod;
                PrefixMethod = Before;
                PostfixMethod = After;
                Patches.Add(this);
            }

            internal static void DoPatches()
            {
                foreach (var patch in Patches)
                {
                    try
                    {
                        Console.WriteLine($"[Patches] Patching {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with {patch.PrefixMethod?.method.Name}{patch.PostfixMethod?.method.Name}");
                        patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with {patch.PostfixMethod?.method.Name}");
                        Console.WriteLine(e.ToString());
                    }
                }
                Console.WriteLine($"[Patches] Done! Patched {Patches.Count} Methods!");
            }
        }

        internal class GeneralPatches
        {
            internal static HarmonyLib.Harmony HarmonyNew = new HarmonyLib.Harmony("PatchesGeneral");

            internal static HarmonyLib.HarmonyMethod GetPatchGeneral(string name)
            {
                return new HarmonyLib.HarmonyMethod(typeof(GeneralPatches).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static));
            }

            internal static IEnumerator GeneralPatchesInit()
            {
                try
                {
                    Patch Patch6 = new Patch(AccessTools.Method(typeof(QuickMenu), "OnEnable", null, null), GetPatchGeneral("QMOnEnable"));

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to patch General patches - did the game update?, take a sit and relax. Unreal is probably fixing it already: " + ex, true);
                }

                Patch.DoPatches();
                Console.WriteLine("GeneralPatchesInit finished!");
                yield break;
            }
            //public static MenuPage MainMenu { get; set; }
            //public static MenuPage TargetMenu { get; set; }
            private static bool initialized = false;
            private static void QMOnEnable()
            {
                if (!initialized)
                {
                    initialized = true;
                    ModConsole.Log("QMOnEnable");

                    //var category = new MenuCategory("RinClient", "RinClient");
                    //var vat2 = new MenuCategory("Cum", "Cum");
                    //try
                    //{
                    //    MainMenu = category.AddSubMenu("RinClientMain", "RinClient", "Tooltip");
                    //    MainMenu.AddSubMenu("Bots", "Bots", "Open the Bot Menu");
                    //    MainMenu.AddSubMenu("World", "World", "Open the World Menu");
                    //    MainMenu.AddSubMenu("Spoofing", "Spoofing", "Open the Spoof Menu");
                    //    MainMenu.AddSubMenu("Config", "Config", "Open the Config Menu");
                    //    new MenuPage("yes", "yes", true);
                    //}
                    //catch (Exception e) { Console.WriteLine("FAILED TO CREATE SUBMENUS"); Console.WriteLine(e.Message + "\n" + e.StackTrace); }

                    //try
                    //{
                    //    TargetMenu = new MenuPage("TargetMenu", "Target Menu");
                    //    var targetMenuButton = new MenuButton("TargetMenu", "RinClient <color=#00ff00>CE</color> Target Options",
                    //        "More options for this target", TargetMenu.Open,
                    //        QMStuff.GetQuickMenuInstance().container.Find("Window/QMParent/Menu_SelectedUser_Local")
                    //            .GetComponentInChildren<ScrollRect>().content.Find("Buttons_UserActions"));
                    //}
                    //catch (Exception e) { Console.WriteLine("FAILED TO CREATE TARGETMENU"); Console.WriteLine(e.Message + "\n" + e.StackTrace); }

                    //try
                    //{
                    //    WingButton.Create("RinClient", delegate () { MainMenu.Open(); }, WingButton.WingSide.Both, true, true, false);
                    //}
                    //catch (Exception e) { Console.WriteLine("FAILED TO CREATE WING"); Console.WriteLine(e.Message + "\n" + e.StackTrace); }

                    //try
                    //{
                    //    var dashboard = QMStuff.GetQuickMenuInstance().container.Find("Window/QMParent/Menu_Dashboard").GetComponent<UIPage>();
                    //    dashboard.GetComponentInChildren<ScrollRect>().content.Find("Carousel_Banners").gameObject.SetActive(false);
                    //    dashboard.GetComponentInChildren<ScrollRect>().content.Find("VRChat+_Banners").gameObject.SetActive(false);
                    //}
                    //catch (Exception e) { }
                }
            }
        }
    }
}