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

    internal class AmongUS_KillPlayers : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
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
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Kill Players", "Control Player Nodes Events (Filtered, only active nodes)");
            CurrentScrollMenu.OnOpenAction = (() => { OnOpenMenu(); });
            CurrentScrollMenu.OnCloseAction = (() => { OnCloseMenu(); });
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
                                                    var KillPlayerBtn = new QMSingleButton(CurrentScrollMenu, "Kill " + NodeName, null, "Kill " + NodeName);
                                                    // FIND THE KILL ACTION
                                                    var eventKeys = action.Get_EventKeys();
                                                    if (eventKeys != null)
                                                    {
                                                        for (int UdonKeys = 0; UdonKeys < eventKeys.Length; UdonKeys++)
                                                        {
                                                            var key = eventKeys[UdonKeys];
                                                            if (key == "SyncKill")
                                                            {
                                                                KillPlayerBtn.SetAction(new Action(() =>
                                                                {
                                                                    action.SendUdonEvent(key);
                                                                }));
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    if (Component.RoleToColor != null)
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
                        Log.Error($"[AMONG US]: Error in Kill Nodes Button!");
                        Log.Exception(e);
                        var btnerror = new QMSingleButton(CurrentScrollMenu,  "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE");
                        GeneratedButtons.Add(btnerror);
                    }



                    HasGenerated = true;
                    isGenerating = false;
                }
            }
        }


        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;

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
            if (DestroyOnMenuClose)
            {
                DestroyGeneratedButtons();
            }
            if (WingMenu != null)
            {
                WingMenu.SetActive(false);
                WingMenu.ClickBackButton();
            }
            IsUIPageListenerActive = false;
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
            IsUIPageListenerActive = true;
            if (!isGenerating)
            {
                Regenerate();
            }
        }

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;
            if (Page != null)
            {
                if (!Page.isPage(CurrentScrollMenu.GetPage())  )
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1033, true, "Among US Kill Players", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }

    }
}