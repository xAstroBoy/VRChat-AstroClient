using AstroClient.ClientActions;
using AstroClient.Startup.Hooks;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.ScrollMenus.VRC_Interactable
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;
    using xAstroBoy.Utility;

    internal class VRC_InteractableScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMWingToggleButton isGlobalTriggerToggle;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new();
        private static List<ScrollMenuListener> Listeners = new();


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
                if(isGlobalTriggerToggle != null)
                {
                    isGlobalTriggerToggle.SetToggleState(value);
                }
            }
        }
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
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
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal VRC_Interactable", "Interact with Internal VRC_Interactables", null, null, null, null, btnHalf);
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;

            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                List<GameObject> list = Tweaker_Object.GetGameObjectToEdit().Get_Triggers();
                for (int i = 0; i < list.Count; i++)
                {
                    GameObject obj = list[i];
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
                    var listener = obj.gameObject.GetOrAddComponent<ScrollMenuListener>();
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
            {
                for (int i = 0; i < GeneratedButtons.Count; i++)
                {
                    GeneratedButtons[i].DestroyMe();
                }

                if (Listeners.Count != 0)
                {
                    for (int i1 = 0; i1 < Listeners.Count; i1++)
                    {
                        Object.DestroyImmediate(Listeners[i1]);
                    }
                }
            }
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

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.isPage(CurrentScrollMenu.GetPage()) )
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu,1004, true, "Tweaker VRC_interactables", "Interact with Internal VRC_interactables");
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