﻿using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.ScrollMenus.Pickup
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;
    using Tools.Extensions;
    using Tools.World;
    using UnityEngine;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class PickupSelectionScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new();
        private static List<ScrollMenuListener> Listeners = new();


        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = true;

        private static bool HasGenerated { get; set; }
        private static bool isOpen { get; set; }

        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
        }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
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

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Select Pickup", "Select World Pickup", null, null, null, null, btnHalf);
            CurrentScrollMenu.OnOpenAction = (() => { OnOpenMenu(); });
            CurrentScrollMenu.OnCloseAction = (() => { OnCloseMenu(); });
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                List<GameObject> list = WorldUtils_Old.Get_Pickups();
                for (int i = 0; i < list.Count; i++)
                {
                    GameObject pickup = list[i];
                    var btn = new QMSingleButton(CurrentScrollMenu, $"Select {pickup.name}", () => { Tweaker_Object.SetObjectToEdit(pickup); }, $"Select {pickup.name}", pickup.Get_GameObject_Active_ToColor());

                    var listener = pickup.AddComponent<ScrollMenuListener>();
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
                for (int i = 0; i < GeneratedButtons.Count; i++)
                {
                    GeneratedButtons[i].DestroyMe();
                }

            if (Listeners.Count != 0)
                for (int i1 = 0; i1 < Listeners.Count; i1++)
                {
                    Object.DestroyImmediate(Listeners[i1]);
                }
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (DestroyOnMenuClose) DestroyGeneratedButtons();
            if (WingMenu != null)
            {
                WingMenu.ClickBackButton();
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

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(WingMenu.CurrentPage))
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1008, true, "Tweaker Pickups", "Select Pickup To modify!");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}