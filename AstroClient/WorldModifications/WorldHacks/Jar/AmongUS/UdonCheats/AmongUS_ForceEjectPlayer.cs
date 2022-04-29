using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class AmongUS_ForceEjectPlayer : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
            ClientEventActions.OnUiPageToggled += OnUiPageToggled;
        }

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();

        private static bool _isGenerating { get; set; }
        private static bool _cleanOnRoomLeave { get; } = true;
        private static bool _destroyOnMenuClose { get; } = true;
        private static bool _hasGenerated { get; set; } = false;
        private static bool _isOpen { get; set; }
        private static bool _isDebugging { get; set; } = true;

        private void OnRoomLeft()
        {
            if (_cleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }
            _isGenerating = false;
        }

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Eject Players Control", "Control Player Nodes Events (Filtered, only active nodes)");
            CurrentScrollMenu.OnOpenAction = (() => { OnOpenMenu(); });
            CurrentScrollMenu.OnCloseAction = (() => { OnCloseMenu(); });
            InitWingPage();
        }


        private static void Debug(string msg)
        {
            if (_isDebugging)
            {
                Log.Debug(msg);
            }
        }

        private static void Regenerate()
        {
            if (!_hasGenerated)
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
                                AmongUS_ESP Component = JarRoleController.AmongUS_ESPs[i];
                                if (Component != null && Component.LinkedNode != null)
                                {
                                    UnhollowerBaseLib.Il2CppArrayBase<UdonBehaviour> list = Component.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                                    for (int i1 = 0; i1 < list.Count; i1++)
                                    {
                                        UdonBehaviour action = list[i1];
                                        if (action != null)
                                        {
                                            if (Component.LinkedNode.NodeReader.VRCPlayerAPI != null)
                                            {
                                                string NodeName = Component.LinkedNode.NodeReader.VRCPlayerAPI.displayName;

                                                if (tmplist.Contains(NodeName))
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    var KillPlayerBtn = new QMSingleButton(CurrentScrollMenu, "Eject " + NodeName, null, "Eject " + NodeName);
                                                    // FIND THE KILL ACTION
                                                    var udonkeys = action.Get_EventKeys();
                                                    if(udonkeys != null)
                                                    {
                                                        for (int i2 = 0; i2 < udonkeys.Length; i2++)
                                                        {
                                                            var key = udonkeys[i2];
                                                            if (key == "SyncVotedOut")
                                                            {
                                                                KillPlayerBtn.SetAction(new Action(() =>
                                                                {
                                                                    action.SendUdonEvent(key);
                                                                }));
                                                                break;
                                                            }
                                                        }

                                                    }
                                                    if (Component.RoleToColor != null && Component.RoleToColor.HasValue)
                                                    {
                                                        KillPlayerBtn.SetTextColor(Component.RoleToColor.GetValueOrDefault());
                                                    }
                                                    GeneratedButtons.Add(KillPlayerBtn);
                                                    tmplist.Add(NodeName);
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
                        Log.Error($"[AMONG US]: Error in Eject Nodes Button!");
                        Log.Exception(e);
                        var btnerror = new QMSingleButton(CurrentScrollMenu,  "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE");
                        GeneratedButtons.Add(btnerror);
                    }
                    
                    _hasGenerated = true;
                    _isGenerating = false;
                }
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            _hasGenerated = false;

            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();

            }
            
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (_destroyOnMenuClose)
            {
                DestroyGeneratedButtons();
            }
            if (WingMenu != null)
            {
                WingMenu.SetActive(false);
                WingMenu.ClickBackButton();
            }
            _isOpen = false;

        }

        private static void OnOpenMenu()
        {
            _isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowWingsPage();
            }

            if (!_isGenerating)
            {
                Regenerate();
            }
        }

        private void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!_isOpen) return;
            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page)  && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1035, true, "Among US Force Votes", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}