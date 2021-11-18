namespace AstroClient.UdonExploits.AmongUS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI;

    internal class AmongUS_KillPlayers : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Kill Players", "Control Player Nodes Events (Filtered, only active nodes)");
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

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                if (JarRoleController.RoleEspComponents.Count() != 0)
                {
                    try
                    {
                        if (JarRoleController.RoleEspComponents.Count() != 0)
                        {
                            var tmplist = new List<string>();
                            for (int i = 0; i < JarRoleController.RoleEspComponents.Count; i++)
                            {
                                JarRoleESP Component = JarRoleController.RoleEspComponents[i];
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
                                                    foreach (var subaction in action._eventTable)
                                                    {
                                                        if (subaction.key == "SyncKill")
                                                        {
                                                            KillPlayerBtn.SetAction(new Action(() =>
                                                            {
                                                                action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                                                            }));
                                                            break;
                                                        }
                                                    }

                                                    var textcolor = Component.AmongUsGetNamePlateColor();
                                                    if (textcolor != null)
                                                    {
                                                        KillPlayerBtn.SetTextColor(textcolor.Value);
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
                        ModConsole.Error($"[AMONG US]: Error in Kill Nodes Button!");
                        ModConsole.ErrorExc(e);
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

            if (!isGenerating)
            {
                Regenerate();
            }
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (!isOpen) return;
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
            WingMenu = new QMWings(1032, true, "Among US Kill Players", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }

    }
}