namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using MelonLoader;
    using Selector;
    using Udon;
    using Udon.UdonEditor;
    using UnityEngine;
    using Variables;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;

    internal class UdonScrollMenu : GameEvents
    {

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static QMWingSingleButton CurrentUnboxBehaviourToConsole;
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal Udon Events", "Interact with Internal Udon Events", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                if (WingMenu != null)
                {
                    WingMenu.SetActive(true);
                    WingMenu.ShowLeftWingPage();
                }
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
                                if (WingMenu != null)
                                {
                                    WingMenu.SetActive(true);
                                    WingMenu.ShowLeftWingPage();
                                }
                                if (CurrentUnboxBehaviourToConsole != null)
                                {
                                    CurrentUnboxBehaviourToConsole.SetButtonText($"Unbox {action.gameObject.name}");
                                    CurrentUnboxBehaviourToConsole.setButtonToolTip($"Attempts to unbox  {action.gameObject.name} in console");
                                    CurrentUnboxBehaviourToConsole.setAction(() => { action.UnboxUdonEventToConsole(); });
                                    CurrentUnboxBehaviourToConsole.SetActive(true);
                                }
                                foreach (var subaction in action._eventTable)
                                {
                                    new QMSingleButton(udon, subaction.Key, () =>
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
                            });
                            udon.SetBackButtonAction(CurrentScrollMenu, () =>
                            {
                                if (WingMenu != null)
                                {
                                    WingMenu.SetActive(true);
                                    WingMenu.ShowLeftWingPage();
                                }

                                if (CurrentUnboxBehaviourToConsole != null)
                                {
                                    CurrentUnboxBehaviourToConsole.SetButtonText($"Not Available");
                                    CurrentUnboxBehaviourToConsole.setButtonToolTip($"Not Available");
                                    CurrentUnboxBehaviourToConsole.setAction(null);
                                    CurrentUnboxBehaviourToConsole.SetActive(false);
                                }
                            });
                        }
                    }
                }
            });
            InitWingPage();
        }

        internal static void OnCloseMenu()
        {
            WingMenu.SetActive(false);
            WingMenu.ClickBackButton();
            if (GeneratedPages.Count != 0)
            {
                foreach (var item in GeneratedPages) item.DestroyMe();
            }
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }
        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (Page != null)
            {
                if (QuickMenuTools.UIPageTemplate_Left() != null)
                {
                    if (Page.Equals(QuickMenuTools.UIPageTemplate_Left())) return;
                }
                if (QuickMenuTools.UIPageTemplate_Right() != null)
                {
                    if (Page.Equals(QuickMenuTools.UIPageTemplate_Right())) return;
                }

                if (Page.Equals(WingMenu.CurrentPage)) return;
                if (!Page.Equals(CurrentScrollMenu.page) || !GeneratedPages.ContainsPage(Page))
                {
                    WingMenu.SetActive(false);
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




       
    }
}