using AstroClient;
using AstroClient.xAstroBoy;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace WorldAPI
{
    internal class APIBase
    {
        internal static string autoColorHex { get; set; } = null;

        internal static Sprite DefaultButtonSprite { get; set; } // Override these if u want custom ones
        internal static Sprite OnSprite { get; set; } // Override these if u want custom ones
        internal static Sprite OffSprite { get; set; }  // Override these if u want custom ones

        internal static Transform Button { get; set; } = null;
        internal static Transform Toggle { get; set; } = null;
        internal static Transform Tab { get; set; } = null;
        internal static Transform MenuTab { get; set; } = null;
        internal static GameObject ColpButtonGrp { get; set; } = null;
        internal static GameObject ButtonGrp { get; set; } = null;
        internal static GameObject ButtonGrpText { get; set; } = null;
        internal static Transform Slider { get; set; }
        internal static GameObject QuickMenu { get; set; }
        internal static Transform LastButtonParent { get; set; }
        private static bool HasChecked { get; set; }

        internal static GameObject MMM { get; set; }
        internal static GameObject MMMpageTemplate { get; set; }
        internal static GameObject MMMTabTemplate { get; set; }

        internal static GameObject WPageTemplate { get; set; }
        internal static GameObject WBtnTemplate { get; set; }
        internal static GameObject WBtnPgTemplate { get; set; }
        internal static GameObject WLDefMenu { get; set; }
        internal static GameObject WRDefMenu { get; set; }

        internal static bool IsReady()
        {
            if (HasChecked) return true;
            if ((QuickMenu = Finder.Find("Canvas_QuickMenu(Clone)")) == null)
            {
                Log.Error("QuickMenu Is Null!");
                return false;
            }
            if ((MMM = Finder.Find("Canvas_MainMenu(Clone)")) == null)
            {
                Log.Error("MainMenu Is Null!");
                return false;
            }
            if ((Button = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn")) == null)
            {
                Log.Error("Button Is Null!");
                return false;
            }
            if ((Toggle = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug_Row_1/Button_PinFPSAndPing")) == null)
            {
                Log.Error("Toggle Is Null!");
                return false;
            }
            if ((Slider = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_AudioSettings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Audio/VolumeSlider_World")) == null)
            {
                Log.Error("Slider Is Null!");
                return false;
            }
            if ((MenuTab = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Dashboard")) == null)
            {
                Log.Error("MenuTab Is Null!");
                return false;
            }
            if ((OffSprite = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_AvInteractions/Button_ToggleSelfInteract/Icon_Off").GetComponent<Image>().sprite) == null)
            {
                Log.Error("OffSprite Is Null!");
                return false;
            }
            if ((OnSprite = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Controls_ColorFilters/EnableFilters/Toggle_ColorFiltersEnable/ButtonElement_CheckBox/Checkmark").GetComponent<UIWidgets.ImageAdvanced>().sprite) == null)
            {
                Log.Error("OnSprite Is Null!");
                return false;
            }
            if ((Tab = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools")) == null)
            {
                Log.Error("Tab Is Null!");
                return false;
            }
            if ((ButtonGrp = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions").gameObject) == null)
            {
                Log.Error("ButtonGrp Is Null!");
                return false;
            }
            if ((ButtonGrpText = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions").gameObject) == null)
            {
                Log.Error("ButtonGrpText Is Null!");
                return false;
            }
            if ((ColpButtonGrp = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/QM_Foldout_Accessibility").gameObject) == null)
            {
                Log.Error("ColpButtonGrp Is Null!");
                return false;
            }
            if ((WPageTemplate = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/Profile").gameObject) == null)
            {
                Log.Error("WPageTemplate Is Null!");
                return false;
            }
            if ((WBtnTemplate = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile").gameObject) == null)
            {
                Log.Error("WBtnTemplate Is Null!");
                return false;
            }
            if ((WBtnPgTemplate = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/Profile/ScrollRect/Viewport/VerticalLayoutGroup/InfoPanel/Status").gameObject) == null)
            {
                Log.Error("WBtnPgTemplate Is Null!");
                return false;
            }
            if (WBtnPgTemplate.GetComponent<VRC.UI.Elements.Analytics.AnalyticsController>() != null)
                GameObject.Destroy(WBtnPgTemplate.GetComponent<VRC.UI.Elements.Analytics.AnalyticsController>()); // Fuck Analytics
            if ((WRDefMenu = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/Wing_Right/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup").gameObject) == null)
            {
                Log.Error("WRDefMenu Is Null!");
                return false;
            }
            if ((WLDefMenu = QuickMenu.transform.FindObject("CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup").gameObject) == null)
            {
                Log.Error("WLDefMenu Is Null!");
                return false;
            }
            if ((MMMpageTemplate = MMM.transform.FindObject("Container/MMParent/Menu_MM_Profile").gameObject) == null)
            {
                Log.Error("Main Menu Template Is Null!");
                return false;
            }
            if ((MMMTabTemplate = MMM.transform.FindObject("Container/PageButtons/HorizontalLayoutGroup/Page_Profile").gameObject) == null)
            {
                Log.Error("Main Menu Tab Is Null!");
                return false;
            }
            HasChecked = true;
            return true;
        }

        internal static void SafelyInvoke(Action action, string name)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Log.Error($"Error in : {name}");
                Log.Exception(e);
            }
        }

        internal static void SafelyInvoke(bool state, Action<bool> action, string name)
        {
            try
            {
                action.Invoke(state);
            }
            catch (Exception e)
            {
                Log.Error($"Error in : {name}");
                Log.Exception(e);
            }
        }

        internal enum WingSide
        {
            Left,
            Right
        }
    }
}