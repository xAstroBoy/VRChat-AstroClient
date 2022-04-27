using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Tools.Listeners;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class AmongUS_UnfilteredNodes : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
            ClientEventActions.Event_OnQuickMenuClose += OnQuickMenuClose;
            ClientEventActions.Event_OnUiPageToggled += OnUiPageToggled;
        }

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();

        private static bool isGenerating { get; set; }
        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = true;

        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }

            isGenerating = false;
        }

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Unfiltered Nodes", "Control Player Nodes Events");
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

        private static bool isDebugging = true;

        private static void Debug(string msg)
        {
            if (isDebugging)
            {
                Log.Debug(msg);
            }
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                try
                {
                    var filterstring = new List<string>();
                    if (JarRoleController.JarRoleLinks.Count() != 0)
                    {
                        for (int i = 0; i < JarRoleController.JarRoleLinks.Count; i++)
                        {
                            JarRoleController.LinkedNodes Component = JarRoleController.JarRoleLinks[i];
                            UnhollowerBaseLib.Il2CppArrayBase<UdonBehaviour> list = Component.Node.GetComponentsInChildren<UdonBehaviour>();
                            for (int i1 = 0; i1 < list.Count; i1++)
                            {
                                UdonBehaviour action = list[i1];
                                if (action != null)
                                {
                                    string btnname = string.Empty;
                                    if (Component.NodeReader.VRCPlayerAPI != null && Component.NodeReader != null)
                                    {
                                        btnname = Component.NodeReader.VRCPlayerAPI.displayName;
                                    }
                                    else
                                    {
                                        btnname = action.gameObject.name;
                                    }

                                    if (filterstring.Contains(btnname))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        var Page = new QMNestedGridMenu(CurrentScrollMenu, btnname, action.interactText);
                                        GenerateInternal(Page, action);
                                        GeneratedPages.Add(Page);
                                        filterstring.Add(btnname);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var NoNodesFound = new QMSingleButton(CurrentScrollMenu, "No Nodes Found", null, "No Nodes Found");
                        GeneratedButtons.Add(NoNodesFound);
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"[AMONG US]: Error in Unfiltered Nodes Button!");
                    Log.Exception(e);
                    var btnerror = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE");
                    GeneratedButtons.Add(btnerror);
                }

                HasGenerated = true;
                isGenerating = false;
            }
        }

        private static void GenerateInternal(QMNestedGridMenu menu, UdonBehaviour action)
        {
            var eventKeys = action.Get_EventKeys();
            if (eventKeys != null)
            {
                for (int UdonKeys = 0; UdonKeys < eventKeys.Length; UdonKeys++)
                {
                    var key = eventKeys[UdonKeys];
                    var anothertmplist = new List<string>();
                    // RENAME SyncVotedFor With Node Name.
                    if (key.ToLower().StartsWith("syncvotedfor"))
                    {
                        var LinkedComponent = JarRoleController.AmongUS_GetLinkedComponent(AmongUS_Utils.RemoveSyncVotedForText(key));
                        if (LinkedComponent != null && LinkedComponent.LinkedNode != null)
                        {
                            if (LinkedComponent.LinkedNode.NodeReader.VRCPlayerAPI != null)
                            {
                                var LinkedNodeTranslated = LinkedComponent.LinkedNode.NodeReader.VRCPlayerAPI.displayName;

                                if (anothertmplist.Contains(LinkedNodeTranslated))
                                {
                                    continue;
                                }
                                else
                                {
                                    var SyncVotedForBtn = new QMSingleButton(menu, 0f, 0f, "Vote: " + LinkedNodeTranslated, delegate
                                    {
                                        action.SendUdonEvent(key);
                                    }, action.gameObject?.ToString() + " Run " + "Vote: " + LinkedNodeTranslated, null, null, true);
                                    if (LinkedComponent.RoleToColor != null && LinkedComponent.RoleToColor.HasValue)
                                    {
                                        SyncVotedForBtn.SetTextColor(LinkedComponent.RoleToColor.GetValueOrDefault());
                                    }

                                    anothertmplist.Add(LinkedNodeTranslated);
                                }
                            }
                            else
                            {
                                var SyncVotedForBtn = new QMSingleButton(menu, key, delegate
                                {
                                    action.SendUdonEvent(key);
                                }, action.gameObject?.ToString() + " Run " + key);
                            }
                        }
                    }
                    else
                    {
                        new QMSingleButton(menu, key, delegate
                        {
                            action.SendUdonEvent(key);
                        }, action.gameObject?.ToString() + " Run " + key);
                    }
                }
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;

            if (GeneratedPages.Count != 0)
            {
                foreach (var item in GeneratedPages) item.DestroyMe();
            }

            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }
            if (Listeners.Count != 0)
            {
                foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            }
        }

        private void OnQuickMenuClose()
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

            if (!isGenerating)
            {
                Regenerate();
            }
        }

                private void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
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
            WingMenu = new QMWings(1032, true, "Among US Active Nodes", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}