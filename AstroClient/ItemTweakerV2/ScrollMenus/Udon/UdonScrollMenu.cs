namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ItemTweakerV2.Selector;
    using Udon;
    using Udon.UdonEditor;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;

    internal class UdonScrollMenu : GameEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();

        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = true;

        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }

        internal override void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal Udon Events", "Interact with Internal Udon Events", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                OnOpenMenu();
            });
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                var udonevents = Tweaker_Object.GetGameObjectToEdit().Get_UdonBehaviours();
                if (udonevents != null && udonevents.Count() != 0)
                {
                    for (int i = 0; i < udonevents.Count; i++)
                    {
                        VRC.Udon.UdonBehaviour action = udonevents[i];
                        if (action._eventTable.Count != 0)
                        {
                            var udon = new QMNestedGridMenu(CurrentScrollMenu, action.gameObject.name, "Open Events of " + action.gameObject.name);
                            GeneratedPages.Add(udon);
                            udon.AddOpenAction(() =>
                            {
                                if (CurrentUnboxBehaviourToConsole != null)
                                {
                                    CurrentUnboxBehaviourToConsole.SetButtonText($"Unbox {action.gameObject.name}");
                                    CurrentUnboxBehaviourToConsole.setButtonToolTip($"Attempts to unbox  {action.gameObject.name} in console");
                                    CurrentUnboxBehaviourToConsole.setAction(() => { action.UnboxUdonEventToConsole(); });
                                    CurrentUnboxBehaviourToConsole.SetActive(true);
                                }

                                GenerateInternal(udon, action);
                            });
                            udon.SetBackButtonAction(CurrentScrollMenu, () =>
                            {
                                if (CurrentUnboxBehaviourToConsole != null)
                                {
                                    CurrentUnboxBehaviourToConsole.SetButtonText($"Unavailable");
                                    CurrentUnboxBehaviourToConsole.setButtonToolTip($"Unavailable");
                                    CurrentUnboxBehaviourToConsole.setAction(() => { });
                                    CurrentUnboxBehaviourToConsole.SetActive(false);
                                }
                            });

                            var listener = action.gameObject.AddComponent<ScrollMenuListener>();
                            if (listener != null)
                            {
                                listener.NestedGridButton = udon;
                                Listeners.Add(listener);
                            }
                        }
                    }
                }
                HasGenerated = true;
            }
        }

        private static void GenerateInternal(QMNestedGridMenu menu, UdonBehaviour action)
        {
            foreach (var subaction in action._eventTable)
            {
                new QMSingleButton(menu, subaction.Key, () =>
                {
                    if (subaction.key.StartsWith("_"))
                    {
                        action.SendCustomEvent(subaction.Key);
                    }
                    else
                    {
                        action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                    }
                }, $"Invoke Event {subaction.Key} of {action.gameObject?.ToString()} (Interaction : {action.interactText})", null, false);
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;

            if (GeneratedPages.Count != 0)
            {
                foreach (var item in GeneratedPages) item.DestroyMe();
            }
            if (Listeners.Count != 0)
            {
                foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            }
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (DestroyOnMenuClose)
            {
                DestroyGeneratedButtons();
            }
            if (WingMenu != null)
            {
                WingMenu.SetActive(false);
                WingMenu.ClickBackButton();
            }
            isOpen = false;

        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowLeftWingPage();
            }
            Regenerate();
            if (CurrentUnboxBehaviourToConsole != null)
            {
                CurrentUnboxBehaviourToConsole.SetButtonText($"Unavailable");
                CurrentUnboxBehaviourToConsole.setButtonToolTip($"Unavailable");
                CurrentUnboxBehaviourToConsole.setAction(() => { });
                CurrentUnboxBehaviourToConsole.SetActive(false);
            }
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (!isOpen) return;
            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(GeneratedPages) && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1005, true, "Udon Behaviours (Tweaker)", "Udon Behaviours (Tweaker) Interact with behaviours internally.");
            CurrentUnboxBehaviourToConsole = new QMWingSingleButton(WingMenu, "Not Available", () => { }, "Not Available");
            CurrentUnboxBehaviourToConsole.SetActive(false);
            WingMenu.SetActive(false);
        }

        private static QMWingSingleButton CurrentUnboxBehaviourToConsole;

        
    }
}