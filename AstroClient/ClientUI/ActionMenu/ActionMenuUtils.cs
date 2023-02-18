using System;
using System.Linq;
using System.Reflection;
using AstroClient.ClientActions;
using AstroClient.Gompoc.ActionMenuAPI.Api;
using AstroClient.Tools;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using UnityEngine;
using UnityEngine.UI;
using VRC.Animation;
using VRC.Core;
using VRC.SDKBase;

namespace AstroClient.ClientUI.ActionMenu
{
    internal class ActionMenuUtils : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            VRCActionMenuPage.AddSubMenu(ActionMenuPage.Options, "SOS",
                () =>
                {
                    //Respawn
                    CustomSubMenu.AddButton("Respawn", Respawn, ClientResources.Loaders.Icons.Refresh);
                    CustomSubMenu.AddButton("Reset Avatar", ResetAvatar, ClientResources.Loaders.Icons.Avatar);
                    CustomSubMenu.AddButton("Rejoin Instance", RejoinInstance, ClientResources.Loaders.Icons.Pin);
                    CustomSubMenu.AddButton("Go Home", Home, ClientResources.Loaders.Icons.Home);
                }, ClientResources.Loaders.Icons.Help);
        }




        private static GoHomeDelegate goHomeDelegate;
        public static GoHomeDelegate GetGoHomeDelegate
        {
            get
            {
                if (goHomeDelegate != null) return goHomeDelegate;
                MethodInfo goHomeMethod = typeof(VRCFlowManager).GetMethods(BindingFlags.Public | BindingFlags.Instance).First(
                    m => m.GetParameters().Length == 0 && m.ReturnType == typeof(void) && m.XRefScanFor("Going to Home Location: "));

                goHomeDelegate = (GoHomeDelegate)Delegate.CreateDelegate(
                    typeof(GoHomeDelegate),
                    VRCFlowManager.prop_VRCFlowManager_0,
                    goHomeMethod);
                return goHomeDelegate;
            }
        }
        public static void GoHome() => GetGoHomeDelegate();
        public delegate void GoHomeDelegate();

        private static Button _RespawnButton { get; set; }

        internal static Button RespawnButton
        {
            get
            {
                if(_RespawnButton == null)
                {
                    var ButtonPath = QuickMenuTools.Canvas_QuickMenu.Find("CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn");
                    if (ButtonPath != null)
                    {
                        var btn = ButtonPath.GetComponent<Button>();
                        if(btn != null)
                        {
                            return _RespawnButton = btn;
                        }
                    }
                    else return null;
                }
                return _RespawnButton;
            }
        }

        public static void Respawn()
        {
            RespawnButton.onClick.Invoke();
            VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<VRCMotionState>().Reset();
        }
        public static void RejoinInstance()
        {
            var instance = RoomManager.field_Internal_Static_ApiWorldInstance_0;
            Networking.GoToRoom($"{instance.world.id}:{instance.instanceId}");
        }

        public static void Home()
        {
            GoHome();
        }

        public static void ResetAvatar()
        {
            // Method_Public_Static_Void_ApiAvatar_String_ApiAvatar_0
            ObjectPublicAbstractSealedApObApStApApUnique.Method_Public_Static_Void_ApiAvatar_String_ApiAvatar_Boolean_0(API.Fetch<ApiAvatar>("avtr_c38a1615-5bf5-42b4-84eb-a8b6c37cbd11"), "fallbackAvatar");
        }

    }
}