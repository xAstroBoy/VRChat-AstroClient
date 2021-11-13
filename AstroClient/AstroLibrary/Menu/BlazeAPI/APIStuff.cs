﻿using System;
using Apollo.Utils.API.Wings;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using Object = UnityEngine.Object;

namespace Apollo.Utils.API
{
    public static class APIStuff
    {
        private static readonly System.Random rnd = new();
        private static VRC.UI.Elements.QuickMenu QuickMenuInstance;
        private static MenuStateController MenuStateControllerInstance;
        private static GameObject SingleButtonReference;
        private static GameObject ToggleButtonReference;
        private static GameObject ButtonGroupReference;
        private static GameObject ButtonGroupHeaderReference;
        private static GameObject InfoPanelReference;
        private static GameObject SliderReference;
        private static GameObject MenuPageReference;
        private static GameObject MenuTabReference;
        private static Sprite onIconSprite;
        private static Sprite offIconSprite;
        private static Sprite personIconSprite;
        internal static BaseWing Left = new();
        internal static BaseWing Right = new();
        internal static Action<BaseWing> OnWingInit = _ => { };

        internal static Action Init_L = () => 
        {
            Init_L = () => { };
            OnWingInit(Left);
        };

        internal static Action Init_R = () =>
        {
            Init_R = () => { };
            OnWingInit(Right);
        };
        
        public static VRC.UI.Elements.QuickMenu GetQuickMenuInstance()
        {
            if (QuickMenuInstance == null)
            {
                QuickMenuInstance = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)").gameObject.GetComponent<VRC.UI.Elements.QuickMenu>();
            }
            return QuickMenuInstance;
        }
        
        public static MenuStateController GetMenuStateControllerInstance()
        {
            if (MenuStateControllerInstance == null)
            {
                MenuStateControllerInstance = GetQuickMenuInstance().GetComponent<MenuStateController>();
            }
            return MenuStateControllerInstance;
        }

        public static GameObject GetSingleButtonTemplate()
        {
            if (SingleButtonReference == null)
            {
                SingleButtonReference = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn").gameObject;
            }
            return SingleButtonReference;
        }

        public static GameObject GetToggleButtonTemplate()
        {
            if (ToggleButtonReference == null)
            {
                ToggleButtonReference = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo").gameObject;
            }
            return ToggleButtonReference;
        }

        public static GameObject GetButtonGroupTemplate()
        {
            if (ButtonGroupReference == null)
            {
                ButtonGroupReference = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions").gameObject;
            }
            return ButtonGroupReference;
        }

        public static GameObject GetButtonGroupHeaderTemplate()
        {
            if (ButtonGroupHeaderReference == null)
            {
                ButtonGroupHeaderReference = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions").gameObject;
            }
            return ButtonGroupHeaderReference;
        }
        
        public static GameObject GetInfoPanelTemplate()
        {
            if (InfoPanelReference == null)
            {
                InfoPanelReference = GameObject.Find("UserInterface").transform.Find("MenuContent/Popups/PerformanceSettingsPopup/Popup/Pages/Page_LimitAvatarPerformance/Tooltip_Details").gameObject;
            }
            return InfoPanelReference;
        }

        public static GameObject GetSliderTemplate()
        {
            if (SliderReference == null)
            {
                SliderReference = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Audio/VolumeSlider_Master").gameObject;
            }
            return SliderReference;
        }

        public static GameObject GetMenuPageTemplate()
        {
            if (MenuPageReference == null)
            {
                MenuPageReference = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").gameObject;
            }
            return MenuPageReference;
        }

        public static GameObject GetMenuTabTemplate()
        {
            if (MenuTabReference == null)
            {
                MenuTabReference = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").gameObject;
            }
            return MenuTabReference;
        }

        public static Sprite GetOnIconSprite()
        {
            if (onIconSprite == null)
            {
                onIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Notifications/Panel_NoNotifications_Message/Icon").GetComponent<Image>().sprite;
            }
            return onIconSprite;
        }
        
        public static Sprite GetOffIconSprite()
        {
            if (offIconSprite == null)
            {
                offIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo/Icon_Off").GetComponent<Image>().sprite;
            }
            return offIconSprite;
        }

        public static Sprite GetPersonIconSprite()
        {
            if (personIconSprite == null)
            {
                personIconSprite = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile/Container/Icon").gameObject.GetComponent<Image>().sprite;
            }
            return personIconSprite;
        }
        
        internal static string RandomNumbers()
        {
            return rnd.Next(1000, 9999).ToString();
        }
        
        internal static void DestroyChildren(this Transform transform)
        {
            transform.DestroyChildren(null);
        }
        
        internal static void DestroyChildren(this Transform transform, Func<Transform, bool> exclude)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                if (exclude == null || exclude(transform.GetChild(i)))
                {
                    Object.DestroyImmediate(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}