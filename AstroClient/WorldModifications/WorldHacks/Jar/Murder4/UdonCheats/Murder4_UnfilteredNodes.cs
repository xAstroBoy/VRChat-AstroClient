using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.Murder4.UdonCheats
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
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class Murder4_UnfilteredNodes : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
        }


        //private static bool _IsUIPageListenerActive = false;
        //private static bool IsUIPageListenerActive
        //{
        //    get => _IsUIPageListenerActive;
        //    set
        //    {
        //        if(_IsUIPageListenerActive != value)
        //        {
        //            if(value)
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
        private static List<QMSingleButton> generatedButtons = new List<QMSingleButton>();

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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Unfiltered Nodes", "Control Player Nodes events");
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
                    Log.Error("[MURDER 4]: Error in Unfiltered Nodes Button!");
                    Log.Exception(e);
                    var errorbtn = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE");
                    generatedButtons.Add(errorbtn);
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
                    new QMSingleButton(menu, key, () =>
                    {
                        action.SendUdonEvent(key);
                    }, $"Invoke Event {key} of {action.gameObject?.ToString()} (Interaction : {action.interactText})");
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
            //IsUIPageListenerActive = false;
            isOpen = false;
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
            if (!isGenerating)
            {
                Regenerate();
            }
            //IsUIPageListenerActive = true;
        }

        //private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
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
            WingMenu = new QMWings(CurrentScrollMenu,1030, true, "Murder 4 Unfiltered Nodes", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }

    }
}