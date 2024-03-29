﻿using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClientResources.Loaders;
    using Tools.Instance.History;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;
    using xAstroBoy.Extensions;
    using Color = System.Drawing.Color;

    internal class InstanceHistoryMenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }


        private static QMWings WingMenu;
        private static List<QMSingleButton> GeneratedButtons = new();
        private static QMGridTab TabMenu { get; set; }

        private static bool HasThrownException { get; set; }
        private static bool CleanOnRoomLeave { get; } = false;
        private static bool DestroyOnMenuClose { get; } = true;

        private static bool HasGenerated { get; set; }
        private static bool isOpen { get; set; }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
        }

        internal static void InitButtons(int index)
        {
            TabMenu = new QMGridTab(index, "Instance History", null, null, null, Icons.history_sprite);

            TabMenu.OnOpenAction = (() => { OnOpenMenu(); });
            TabMenu.OnCloseAction = (() => { OnCloseMenu(); });
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                try
                {
                    if (InstanceManager.instances.Count() != 0)
                    {
                        for (int i = 0; i < InstanceManager.instances.Count; i++)
                        {
                            InstanceManager.WorldInstance instance = InstanceManager.instances[i];
                            var buttonText = (instance.worldName + ": " + instance.instanceId.Split('~')[0]).Truncate(60);
                            var Tooltip = instance.worldName + ": " + instance.instanceId.Split('~')[0];
                            var btn = new QMSingleButton(TabMenu, buttonText, () => WorldManager.EnterWorld(instance.worldId + ":" + instance.instanceId), Tooltip, System.Drawing.Color.White);
                            GeneratedButtons.Add(btn);
                        }
                    }
                    else
                    {
                        var empty = new QMSingleButton(TabMenu, "No Instances Logs Found", null, "No Instances Logs Found", Color.Red);
                        GeneratedButtons.Add(empty);
                    }
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                    HasThrownException = true;
                }

                HasGenerated = true;
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;
            if (GeneratedButtons.Count != 0)
            {
                for (int i = 0; i < GeneratedButtons.Count; i++)
                {
                    GeneratedButtons[i].DestroyMe();
                }
            }
            //if (Listeners.Count != 0)
            //{
            //    foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            //}
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (DestroyOnMenuClose || HasThrownException) DestroyGeneratedButtons();
            if (WingMenu != null)
            {
                WingMenu.SetActive(false);
                
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
            Regenerate();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu,1037, true, "Instance Options", "Manage Instance Options");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh Instance History");

            WingMenu.SetActive(false);
        }
    }
}