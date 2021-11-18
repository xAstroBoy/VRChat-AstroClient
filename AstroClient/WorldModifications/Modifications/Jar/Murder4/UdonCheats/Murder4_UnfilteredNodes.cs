namespace AstroClient.WorldModifications.Modifications.Jar.Murder4.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Tools.Listeners;
    using UnhollowerBaseLib;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI;

    internal class Murder4_UnfilteredNodes : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();
        private static List<QMSingleButton> generatedButtons = new List<QMSingleButton>();

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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Unfiltered Nodes", "Control Player Nodes events");
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
                    var filterstring = new List<string>();
                    if (JarRoleController.JarRoleLinks.Count() != 0)
                    {
                        for (int i = 0; i < JarRoleController.JarRoleLinks.Count; i++)
                        {
                            JarRoleController.LinkedNodes Component = JarRoleController.JarRoleLinks[i];
                            Il2CppArrayBase<UdonBehaviour> list = Component.Node.GetComponentsInChildren<UdonBehaviour>();
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

                                    var page = new QMNestedGridMenu(CurrentScrollMenu, btnname, action.interactText);
                                    GenerateInternal(page, action);

                                    GeneratedPages.Add(page);
                                    filterstring.Add(btnname);
                                }
                            }
                        }
                    }
                    else
                    {
                        var NoNodesFound = new QMSingleButton(CurrentScrollMenu, "No Nodes Found", null, "No Nodes Found");
                    }
                }
                catch (Exception e)
                {
                    ModConsole.Error("[MURDER 4]: Error in Unfiltered Nodes Button!");
                    ModConsole.ErrorExc(e);
                    var errorbtn = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE");
                    generatedButtons.Add(errorbtn);
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
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(GeneratedPages) && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1030, true, "Murder 4 Unfiltered Nodes", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }

    }
}