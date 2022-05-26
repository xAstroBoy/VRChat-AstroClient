using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS.UdonCheats
{
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Tools.Listeners;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.Udon;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class AmongUS_ForceVotePlayer : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }

        //private static bool _IsUIPageListenerActive = false;

        //private static bool IsUIPageListenerActive
        //{
        //    get => _IsUIPageListenerActive;
        //    set
        //    {
        //        if (_IsUIPageListenerActive != value)
        //        {
        //            if (value)
        //            {
        //                ClientEventActions.OnUiPageToggled += OnUiPageToggled;
        //            }
        //            else
        //            {
        //                ClientEventActions.OnUiPageToggled -= OnUiPageToggled;
        //            }
        //        }
        //        _IsUIPageListenerActive = value;
        //    }
        //}

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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Force Vote", "Control Player Nodes Events (Filtered, only active nodes)");
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
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
                        Log.Error($"[AMONG US]: Error in Force Vote Button!");
                        Log.Exception(e);
                        var btnerror = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE", Color.red);
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
            var eventkeys = action.Get_EventKeys();
            if (eventkeys != null)
            {
                for (int eventkey = 0; eventkey < eventkeys.Length; eventkey++)
                {
                    var key = eventkeys[eventkey];
                    var anothertmplist = new List<string>();
                    // RENAME SyncVotedFor With Node Name.
                    if (key.ToLower().StartsWith("syncvotedfor"))
                    {
                        var LinkedComponent = JarRoleController.AmongUS_GetLinkedComponent(AmongUS_Utils.RemoveSyncVotedForText(key));
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
                                        var SyncVotedForBtn = new QMSingleButton(menu, btnactionname, delegate { if (!Component.HasVoted) { action.SendUdonEvent(key); } }, action.gameObject?.ToString() + " Run " + btnactionname);
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
                    if (key.ToLower().StartsWith("syncabstainedvoting"))
                    {
                        new QMSingleButton(menu, "Skip Voting", delegate
                        {
                            if (Component.AmongUSCanVote)
                            {
                                action.SendUdonEvent(key);
                            }
                        }, action.gameObject?.ToString() + " Run " + "Skip Voting", Color.green);
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
            isOpen = false;
          //  IsUIPageListenerActive = false;
            if (DestroyOnMenuClose)
            {
                DestroyGeneratedButtons();
            }
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
            //IsUIPageListenerActive = true;
            if (!isGenerating)
            {
                Regenerate();
            }
        }

        //private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType, bool Toggle2)
        //{
        //    if (!isOpen) return;
        //    if (Page != null)
        //    {
        //        if (!Page.isPage(CurrentScrollMenu.GetPage()) && GeneratedPages.ContainsPage(Page))
        //        {
        //            OnCloseMenu();
        //        }
        //    }
        //}

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu,1034, true, "Among US Force Voting", "Interact with udon behaviours");
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