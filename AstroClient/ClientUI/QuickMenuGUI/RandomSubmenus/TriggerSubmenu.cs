using AstroClient.ClientActions;
using AstroClient.Startup.Hooks;

namespace AstroClient.ClientUI.Menu.RandomSubmenus
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools.Listeners;
    using Tools.Extensions;
    using Tools.World;
    using UnityEngine;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class TriggerSubmenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new();
        private static List<ScrollMenuListener> Listeners = new();
        private static QMWingToggleButton isGlobalTriggerToggle;
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

        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = false;

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
        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
        }


        internal static void InitButtons(QMGridTab menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Triggers", "Interact with World Triggers");
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                foreach (var obj in WorldUtils_Old.Get_Triggers())
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
                    var listener = obj.gameObject.AddComponent<ScrollMenuListener>();
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
            isGlobalTrigger = false;
            IsUIPageListenerActive = false;
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

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.isPage(CurrentScrollMenu.GetPage()) )
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu,1006, true, "Triggers", "Interact with World Triggers");
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