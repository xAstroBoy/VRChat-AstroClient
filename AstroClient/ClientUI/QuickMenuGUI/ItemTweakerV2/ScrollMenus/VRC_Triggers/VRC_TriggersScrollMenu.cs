using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.Startup.Hooks;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.UI.Elements;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.ScrollMenus.VRC_Triggers
{
    internal class VRC_TriggersScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new();
        private static List<ScrollMenuListener> Listeners = new();
        private static QMWingToggleButton isGlobalTriggerToggle;


        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = true;

        private static bool HasGenerated { get; set; }
        private static bool isOpen { get; set; }

        private static bool _isGlobalTrigger = false;

        private static bool isGlobalTrigger
        {
            get => _isGlobalTrigger;
            set
            {
                _isGlobalTrigger = value;
                if (isGlobalTriggerToggle != null)
                {
                    isGlobalTriggerToggle.SetToggleState(value);
                }
            }
        }
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
        }
        private static bool _IsUIPageListenerActive = false;
        private static bool IsUIPageListenerActive
        {
            get => _IsUIPageListenerActive;
            set
            {
                if (_IsUIPageListenerActive != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnUiPageToggled += OnUiPageToggled;

                    }
                    else
                    {
                        ClientEventActions.OnUiPageToggled -= OnUiPageToggled;

                    }

                }
                _IsUIPageListenerActive = value;
            }
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal Triggers", "Interact with Internal Triggers", null, null, null, null, btnHalf);
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                foreach (var obj in Tweaker_Object.GetGameObjectToEdit().Get_Triggers())
                {
                    var btn = new QMSingleButton(CurrentScrollMenu, $"Click {obj.name}", () =>
                    {
                        if (isGlobalTrigger)
                        {
                            WorldTriggerHook.SendTriggerToEveryone = true;
                            obj.TriggerClick();
                            WorldTriggerHook.SendTriggerToEveryone = false;
                        }
                        else
                        {
                            obj.TriggerClick();
                        }
                    }, $"Click {obj.name}", obj.Get_GameObject_Active_ToColor());
                    var listener = ComponentUtils.GetOrAddComponent<ScrollMenuListener>(obj.gameObject);
                    if (listener != null) listener.SingleButton = btn;
                    Listeners.Add(listener);
                    GeneratedButtons.Add(btn);
                }


                HasGenerated = true;
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;
            if (GeneratedButtons.Count != 0)
                foreach (var item in GeneratedButtons)
                    item.DestroyMe();
            if (Listeners.Count != 0)
                foreach (var item in Listeners)
                    Object.DestroyImmediate(item);
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            IsUIPageListenerActive = false;
            isGlobalTrigger = false;
            isOpen = false;
            if (DestroyOnMenuClose) DestroyGeneratedButtons();
            if (WingMenu != null)
            {
                
                WingMenu.SetActive(false);
            }
        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowWingsPage();
            }
            IsUIPageListenerActive = true;
            Regenerate();
        }

        private static  void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.isPage(CurrentScrollMenu.GetPage()) )
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu,1002, true, "Tweaker Triggers", "Interact with Internal Triggers");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            isGlobalTriggerToggle = new QMWingToggleButton(WingMenu, "World Trigger", () => { isGlobalTrigger = true; }, () => { isGlobalTrigger = false; }, "Invoke Trigger for everyone");

            WingMenu.SetActive(false);
        }
    }
}