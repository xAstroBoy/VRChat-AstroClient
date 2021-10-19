﻿namespace CheetoLibrary
{
    using AstroClient;
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

    internal class UIHooks : GameEvents
    {
        internal static HarmonyLib.Harmony HarmonyNew = new HarmonyLib.Harmony("UIHooks");

        internal static IEnumerator GeneralPatchesInit()
        {
            try
            {
                //Patch Patch6 = new Patch(AccessTools.Method(typeof(QuickMenu), "OnEnable", null, null), GetPatchGeneral("QMOnEnable"));
            }
            catch (Exception ex)
            {
                ModConsole.Exception(ex);
            }

            ModConsole.Log("ChingChong Patched!");
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