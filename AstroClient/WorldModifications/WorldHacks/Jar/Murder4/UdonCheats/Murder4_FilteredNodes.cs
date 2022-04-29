using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.Murder4.UdonCheats
{
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

    internal class Murder4_FilteredNodes : AstroEvents
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
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();

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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Filtered Nodes", "Control Player Nodes Events (Filtered, only active nodes)");
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
                if (JarRoleController.Murder4_ESPs.Count() != 0)
                {
                    var tmplist = new List<string>(); // WHY SO SUDDENLY IT DECIDES TO HAVE MULTIPLE BUTTONS WITH THE SAME PLAYER? FFS
                    for (int i = 0; i < JarRoleController.Murder4_ESPs.Count; i++)
                    {
                        Murder4_ESP Component = JarRoleController.Murder4_ESPs[i];
                        if (Component != null && Component.LinkedNode != null)
                        {
                            Il2CppArrayBase<UdonBehaviour> list = Component.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                            for (int i1 = 0; i1 < list.Count; i1++)
                            {
                                UdonBehaviour action = list[i1];
                                if (Component.LinkedNode.NodeReader.VRCPlayerAPI != null)
                                {
                                    string PlayerNode = Component.LinkedNode.NodeReader.VRCPlayerAPI.displayName;

                                    if (tmplist.Contains(PlayerNode))
                                    {
                                        continue;
                                    }

                                    var Page = new QMNestedGridMenu(CurrentScrollMenu, PlayerNode, $"Mess with {PlayerNode} 's node");
                                    GenerateInternal(Page, action);
                                    if (Component.RoleToColor != null && Component.RoleToColor.HasValue)
                                    {
                                        Page.SetTextColor(Component.RoleToColor.GetValueOrDefault());
                                    }

                                    GeneratedPages.Add(Page);
                                    tmplist.Add(PlayerNode);
                                }


                            }
                        }
                    }
                    HasGenerated = true;
                    isGenerating = false;
                }
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
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(GeneratedPages) && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1032, true, "Murder 4 Active Nodes", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }

    }
}