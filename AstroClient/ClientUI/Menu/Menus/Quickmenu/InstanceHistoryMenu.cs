namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ActionMenu.AvatarParametersModule.Menu;
    using ClientResources.Loaders;
    using Tools.Extensions;
    using Tools.InstanceHistory;
    using Tools.Skybox;
    using UnityEngine;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;
    using Color = System.Drawing.Color;

    internal class InstanceHistoryMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static List<QMSingleButton> GeneratedButtons = new();
        private static QMGridTab TabMenu { get; set; }

        //private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();

        private static bool HasThrownException { get; set; }
        private static bool CleanOnRoomLeave { get; } = false;
        private static bool DestroyOnMenuClose { get; } = true;

        private static bool HasGenerated { get; set; }
        private static bool isOpen { get; set; }

        internal override void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
        }

        internal static void InitButtons(int index)
        {
            TabMenu = new QMGridTab(index, "History Menu", null, null, null, Icons.history_sprite);
            TabMenu.SetBackButtonAction(() => { OnCloseMenu(); });
            TabMenu.AddOpenAction(() => { OnOpenMenu(); });
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
                        foreach (var instance in InstanceManager.instances)
                        {
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
                    ModConsole.ErrorExc(e);
                    HasThrownException = true;
                }

                HasGenerated = true;
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;
            if (GeneratedButtons.Count != 0)
                foreach (var item in GeneratedButtons)
                    item.DestroyMe();
            //if (Listeners.Count != 0)
            //{
            //    foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            //}
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (DestroyOnMenuClose || HasThrownException) DestroyGeneratedButtons();
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

            Regenerate();
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.ContainsPage(TabMenu.page) && !Page.ContainsPage(WingMenu.CurrentPage))
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1037, true, "Instance Options", "Manage Instance Options");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                SkyboxEditor.FindAndLoadSkyboxes();
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh Instance History");

            WingMenu.SetActive(false);
        }
    }
}