namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using Selector;
    using System.Collections.Generic;
    using System.Linq;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;

    internal class UdonScrollMenu : GameEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static QMWingSingleButton CurrentUnboxBehaviourToConsole;
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();
        private static bool isOpen;

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

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowLeftWingPage();
            }
        }

        internal static void OnCloseMenu()
        {
            isOpen = false;
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
            if (!isOpen) return;
            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(GeneratedPages))
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
    }
}