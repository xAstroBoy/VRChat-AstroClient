namespace AstroClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using MelonLoader;
    using Udon;
    using Udon.UdonEditor;
    using UnityEngine;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;

    internal class VRC_InteractableSubMenu : GameEvents
    {

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        internal override void OnRoomLeft()
        {
            DestroyGeneratedButtons();
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "VRC_Interactables", "Interact VRC_Interactable", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                if (WingMenu != null)
                {
                    WingMenu.SetActive(true);
                }
                Regenerate();
            });
            InitWingPage();
        }


        private static void Regenerate()
        {
            foreach (var obj in WorldUtils_Old.Get_VRCInteractables())
            {
                var btn = new QMSingleButton(CurrentScrollMenu, $"Click {obj.name}", () => { obj.VRC_Interactable_Click(); }, $"Interact with {obj.name}", obj.Get_GameObject_Active_ToColor());
                var listener = obj.GetOrAddComponent<ScrollMenuListener>();
                if (listener != null)
                {
                    listener.SingleButton = btn;
                }
                GeneratedButtons.Add(btn);
            }
        }

        internal static void OnCloseMenu()
        {
            WingMenu.SetActive(false);
            DestroyGeneratedButtons();
        }

        internal static void DestroyGeneratedButtons()
        {
            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }
        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (Page != null)
            {
                if (!Page.Equals(CurrentScrollMenu.page))
                {
                    WingMenu.SetActive(false);
                    OnCloseMenu();
                }
            }
        }



        private static void InitWingPage()
        {
            WingMenu = new QMWings(1002, true, "VRC Interactables Menu", "Interact with VRC_Interactable Triggers");
            new QMWingSingleButton(WingMenu, "Refresh", () => { DestroyGeneratedButtons();   Regenerate(); }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }


    }
}