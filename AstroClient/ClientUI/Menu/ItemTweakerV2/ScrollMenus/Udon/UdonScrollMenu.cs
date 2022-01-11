namespace AstroClient.ClientUI.Menu.ItemTweakerV2.ScrollMenus.Udon
{
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;
    using Tools.Extensions;
    using Tools.UdonEditor;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class UdonScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();

        private static bool isGenerating { get; set; }
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

            isGenerating = false;
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal Udon Events", "Interact with Internal Udon Events", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () => { OnCloseMenu(); });
            CurrentScrollMenu.AddOpenAction(() => { OnOpenMenu(); });
            InitWingPage();
        }

        private static bool isDebugging = true;

        private static void Debug(string msg)
        {
            if (isDebugging)
            {
                ModConsole.DebugLog(msg);
            }
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                var udonevents = Tweaker_Object.GetGameObjectToEdit().Get_UdonBehaviours();
                if (udonevents != null && udonevents.Count() != 0)
                {
                    for (var index = 0; index < udonevents.Count; index++)
                    {
                        var action = udonevents[index];
                        if (action._eventTable.Count != 0)
                        {
                            var udon = new QMNestedGridMenu(CurrentScrollMenu, action.gameObject.name, $"Open Events of {action.gameObject.name}");
                            GeneratedPages.Add(udon);
                            GenerateInternal(udon, action);
                            udon.AddOpenAction(() =>
                            {
                                if (CurrentUnboxBehaviourToConsole != null)
                                {
                                    CurrentUnboxBehaviourToConsole.SetButtonText($"Unbox {action.gameObject.name}");
                                    CurrentUnboxBehaviourToConsole.SetToolTip($"Attempts to unbox  {action.gameObject.name} in console");
                                    CurrentUnboxBehaviourToConsole.setAction(() => { action.UnboxUdonEventToConsole(); });
                                    CurrentUnboxBehaviourToConsole.SetActive(true);
                                }

                                if (DisassembleUdonBehaviourProgram != null)
                                {
                                    DisassembleUdonBehaviourProgram.SetButtonText($"Disassemble  {action.gameObject.name} Program");
                                    DisassembleUdonBehaviourProgram.SetToolTip($"Attempts to Disassemble  {action.gameObject.name} Program to file");
                                    DisassembleUdonBehaviourProgram.setAction(() => { action.DumpUdonProgramCode(); });
                                    DisassembleUdonBehaviourProgram.SetActive(true);
                                }

                            });
                            udon.SetBackButtonAction(CurrentScrollMenu, () =>
                            {
                                if (CurrentUnboxBehaviourToConsole != null)
                                {
                                    CurrentUnboxBehaviourToConsole.SetButtonText($"Unavailable");
                                    CurrentUnboxBehaviourToConsole.SetToolTip($"Unavailable");
                                    CurrentUnboxBehaviourToConsole.setAction(() => { });
                                    CurrentUnboxBehaviourToConsole.SetActive(false);
                                }

                                if (DisassembleUdonBehaviourProgram != null)
                                {
                                    DisassembleUdonBehaviourProgram.SetButtonText($"Unavailable");
                                    DisassembleUdonBehaviourProgram.SetToolTip($"Unavailable");
                                    DisassembleUdonBehaviourProgram.setAction(() => { });
                                    DisassembleUdonBehaviourProgram.SetActive(false);
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
                isGenerating = false;
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
                }, $"Invoke Event {subaction.Key} of {action.gameObject?.ToString()} (Interaction : {action.interactText})");
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
                WingMenu.ShowWingsPage();
            }

            if (CurrentUnboxBehaviourToConsole != null)
            {
                CurrentUnboxBehaviourToConsole.SetButtonText($"Unavailable");
                CurrentUnboxBehaviourToConsole.SetToolTip($"Unavailable");
                CurrentUnboxBehaviourToConsole.setAction(() => { });
                CurrentUnboxBehaviourToConsole.SetActive(false);
            }

            if (DisassembleUdonBehaviourProgram != null)
            {
                DisassembleUdonBehaviourProgram.SetButtonText($"Unavailable");
                DisassembleUdonBehaviourProgram.SetToolTip($"Unavailable");
                DisassembleUdonBehaviourProgram.setAction(() => { });
                DisassembleUdonBehaviourProgram.SetActive(false);
            }

            if (!isGenerating)
            {
                Regenerate();
            }
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
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
            WingMenu = new QMWings(1005, true, "Udon Behaviours (Tweaker)", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            CurrentUnboxBehaviourToConsole = new QMWingSingleButton(WingMenu, "Unbox null", () => { }, "Attempts to unbox null in console..");
            DisassembleUdonBehaviourProgram = new QMWingSingleButton(WingMenu, "Disassemble null Program", () => { }, "Attempts to Disassemble null Program to file..");
            DisassembleUdonBehaviourProgram.SetActive(false);
            CurrentUnboxBehaviourToConsole.SetActive(false);
            WingMenu.SetActive(false);
        }

        private static QMWingSingleButton CurrentUnboxBehaviourToConsole;
        private static QMWingSingleButton DisassembleUdonBehaviourProgram;

    }
}