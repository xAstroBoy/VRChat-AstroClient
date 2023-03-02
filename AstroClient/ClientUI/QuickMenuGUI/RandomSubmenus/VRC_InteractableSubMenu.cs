using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.World;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI;
using UnityEngine;
using VRC.UI.Elements;

namespace AstroClient.ClientUI.QuickMenuGUI.RandomSubmenus
{
    internal class VRC_InteractableSubMenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new();
        private static List<ScrollMenuListener> Listeners = new();


        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = false;

        private static bool HasGenerated { get; set; }
        private static bool isOpen { get; set; }


        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
        }

        internal static void InitButtons(QMGridTab menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "VRC_Interactables", "Interact VRC_Interactable");
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                foreach (var obj in WorldUtils_Old.Get_VRCInteractables())
                {
                    var btn = new QMSingleButton(CurrentScrollMenu, $"Click {obj.name}", () => { obj.VRC_Interactable_Click(); }, $"Interact with {obj.name}", obj.Get_GameObject_Active_ToColor());
                    var listener = obj.AddComponent<ScrollMenuListener>();
                    if (listener != null) listener.SingleButton = btn;
                    Listeners.Add(listener);
                    GeneratedButtons.Add(btn);
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
            if (Listeners.Count != 0)
                foreach (var item in Listeners)
                    Object.DestroyImmediate(item);
        }

        private static void OnCloseMenu()
        {
            isOpen = false;
            if (DestroyOnMenuClose) DestroyGeneratedButtons();
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
            Regenerate();
        }


        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu,1003, true, "VRC Interactables Menu", "Interact with VRC_Interactable Triggers");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}