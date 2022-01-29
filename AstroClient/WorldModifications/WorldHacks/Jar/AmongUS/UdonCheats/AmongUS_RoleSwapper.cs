namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds.Roles;
    using AstroMonos.Components.Tools.Listeners;
    using UnhollowerBaseLib;
    using UnityEngine;
    using VRC.Udon;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class AmongUS_RoleSwapper : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static List<QMSingleButton> Generated = new List<QMSingleButton>();

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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Swap Roles", "Control The Game!");
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
                try
                {
                    if (JarRoleController.AmongUS_ESPs.Count() != 0)
                    {
                        var tmplist = new List<string>();
                        for (int i = 0; i < JarRoleController.AmongUS_ESPs.Count; i++)
                        {
                            AmongUS_ESP TargetComponent = JarRoleController.AmongUS_ESPs[i];
                            if (TargetComponent != null && TargetComponent.LinkedNode != null)
                            {
                                Il2CppArrayBase<UdonBehaviour> list = TargetComponent.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                                for (int i1 = 0; i1 < list.Count; i1++)
                                {
                                    UdonBehaviour action = list[i1];
                                    if (action != null)
                                    {
                                        if (TargetComponent.LinkedNode.NodeReader.VRCPlayerAPI != null)
                                        {
                                            var NodeTranslated = TargetComponent.LinkedNode.NodeReader.VRCPlayerAPI.displayName;

                                            if (tmplist.Contains(NodeTranslated))
                                            {
                                                continue;
                                            }

                                            var playerbtn = new QMSingleButton(CurrentScrollMenu, NodeTranslated, null, "Swap Role with " + NodeTranslated);
                                            playerbtn.SetAction(new Action(() =>
                                            {
                                                AmongUs_Roles SelfRole = AmongUs_Roles.None;
                                                AmongUs_Roles TargetRole = AmongUs_Roles.None;
                                                var LocalPlayer = JarRoleController.CurrentPlayer_AmongUS_ESP;
                                                if (LocalPlayer != null)
                                                {
                                                  SelfRole = LocalPlayer.CurrentRole;
                                                }
                                                if (TargetComponent != null)
                                                {
                                                    TargetRole = TargetComponent.CurrentRole;
                                                }

                                                TargetComponent.SetRole(SelfRole);
                                                LocalPlayer.SetRole(TargetRole);
                                            }));

                                            if (TargetComponent.RoleToColor != null)
                                            {
                                                playerbtn.SetTextColor(TargetComponent.RoleToColor.GetValueOrDefault());
                                            }

                                            Generated.Add(playerbtn);
                                            tmplist.Add(NodeTranslated);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var NoNodesFound = new QMSingleButton(CurrentScrollMenu, 0f, 0f, "No Nodes Found", null, "No Nodes Found", null, null, true);
                        Generated.Add(NoNodesFound);
                    }
                }
                catch (Exception e)
                {
                    ModConsole.Error("[MURDER 4]: Error in Role Swapper Button!");
                    ModConsole.ErrorExc(e);
                    var btnerror = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE", Color.red);
                    Generated.Add(btnerror);
                }


                HasGenerated = true;
                isGenerating = false;
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;

            if (Generated.Count != 0)
            {
                foreach (var item in Generated) item.DestroyMe();
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
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1031, true, "Among USSwap Roles", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }

    }
}