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

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.ScrollMenus.VRC_Interactable
{
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
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
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
            Regenerate();
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