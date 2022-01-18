﻿namespace AstroClient.WorldModifications.Modifications.Jar.AmongUS.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Tools.Listeners;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class AmongUS_ForceVotePlayer : AstroEvents
    {
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

        internal override void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }

            isGenerating = false;
        }

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Force Vote", "Control Player Nodes Events (Filtered, only active nodes)");
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
                ModConsole.DebugLog(msg);
            }
        }
        // TODO : Make a mechanism to prevent people who already voted so it doesn't make duplicate votes on instances lol

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                if (JarRoleController.AmongUS_ESPs.Count() != 0)
                {
                    try
                    {
                        if (JarRoleController.AmongUS_ESPs.Count() != 0)
                        {
                            var tmplist = new List<string>();
                            for (int i = 0; i < JarRoleController.AmongUS_ESPs.Count; i++)
                            {
                                AmongUS_ESP Reader = JarRoleController.AmongUS_ESPs[i];
                                if (Reader != null && Reader.LinkedNode != null)
                                {
                                    UnhollowerBaseLib.Il2CppArrayBase<UdonBehaviour> list = Reader.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                                    for (int i1 = 0; i1 < list.Count; i1++)
                                    {
                                        UdonBehaviour action = list[i1];
                                        if (action != null)
                                        {
                                            if (Reader.LinkedNode.NodeReader.VRCPlayerAPI != null)
                                            {
                                                var NodeTranslated = Reader.LinkedNode.NodeReader.VRCPlayerAPI.displayName;
                                                if (tmplist.Contains(NodeTranslated))
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    var Page = new QMNestedGridMenu(CurrentScrollMenu, NodeTranslated, action.interactText);
                                                    GenerateInternal(Page, action, Reader, NodeTranslated);

                                                    if (Reader.RoleToColor != null && Reader.RoleToColor.HasValue)
                                                    {
                                                        Page.SetTextColor(Reader.RoleToColor.GetValueOrDefault());
                                                    }
                                                    GeneratedPages.Add(Page);
                                                    tmplist.Add(NodeTranslated);
                                                }
                                            }
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
                        ModConsole.Error($"[AMONG US]: Error in Force Vote Button!");
                        ModConsole.ErrorExc(e);
                        var btnerror = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE",  Color.red);
                        GeneratedButtons.Add(btnerror);
                    }


                    HasGenerated = true;
                    isGenerating = false;
                }
            }
        }

        private static void GenerateInternal(QMNestedGridMenu menu, UdonBehaviour action, AmongUS_ESP Component, string NodeTranslated)
        {

            bool HasAddedEveryoneVoteBtn = false;
            foreach (var subaction in action._eventTable)
            {
                var anothertmplist = new List<string>();
                // RENAME SyncVotedFor With Node Name.
                if (subaction.Key.ToLower().StartsWith("syncvotedfor"))
                {
                    var LinkedComponent = JarRoleController.AmongUS_GetLinkedComponent(AmongUS_Utils.RemoveSyncVotedForText(subaction.key));
                    if (LinkedComponent != null)
                    {
                        if (LinkedComponent.LinkedNode != null)
                        {
                            if (LinkedComponent.LinkedNode.NodeReader.VRCPlayerAPI != null)
                            {
                                var btnactionname = "Vote: " + LinkedComponent.LinkedNode.NodeReader.VRCPlayerAPI.displayName;
                                if (anothertmplist.Contains(btnactionname))
                                {
                                    continue;
                                }
                                else
                                {
                                    var SyncVotedForBtn = new QMSingleButton(menu, btnactionname, delegate { if (!Component.HasVoted) { action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key); } }, action.gameObject?.ToString() + " Run " + btnactionname);
                                    if (LinkedComponent.RoleToColor != null && LinkedComponent.RoleToColor.HasValue)
                                    {
                                        SyncVotedForBtn.SetTextColor(LinkedComponent.RoleToColor.GetValueOrDefault());
                                    }
                                    if (!anothertmplist.Contains(btnactionname))
                                    {
                                        anothertmplist.Add(btnactionname);
                                    }
                                }
                            }
                        }
                    }
                }
                if (!HasAddedEveryoneVoteBtn)
                {
                    new QMSingleButton(menu, "Everyone vote : " + NodeTranslated, delegate { AmongUS_Utils.AllVoteFor(Component); }, action.gameObject?.ToString() + "Everyone votes : " + NodeTranslated, Color.green);
                    HasAddedEveryoneVoteBtn = true;
                }
                if (subaction.Key.ToLower().StartsWith("syncabstainedvoting"))
                {
                    new QMSingleButton(menu, "Skip Voting", delegate
                    {
                        if (Component.AmongUSCanVote)
                        {
                            action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                        }
                    }, action.gameObject?.ToString() + " Run " + "Skip Voting", Color.green);
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
            WingMenu = new QMWings(1034, true, "Among US Force Voting", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "All Skip voting", () => { AmongUS_Utils.AllSkipVote(); }, "Force Everyone to Skip Vote");

            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }

    }
}