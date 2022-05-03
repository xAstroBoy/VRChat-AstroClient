using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.ScrollMenus.Prefabs
{
    using System.Collections.Generic;
    using Selector;
    using Submenus.Spawner;
    using UnityEngine;
    using VRC.SDKBase;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;
    using xAstroBoy.Utility;

    internal class PrefabSpawnerScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new();


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
        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Spawn Prefabs", "Spawn World Prefabs");

            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;

            WingMenu = new QMWings(CurrentScrollMenu,1013, true, "Tweaker Prefabs", "Prefabs Menu");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);


        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                foreach (var prefab in WorldUtils.Prefabs)
                {
                    var btn = new QMSingleButton(CurrentScrollMenu, 0, 0, $"Spawn {prefab.name}", () =>
                    {
                        var broadcast = VRC_EventHandler.VrcBroadcastType.Always;
                        var prefabinfo = prefab.name;
                        var position = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(HumanBodyBones.RightHand).position;
                        var Rotation = prefab.transform.rotation;

                        if (position != null)
                        {
                            var newprefab = Networking.Instantiate(broadcast, prefabinfo, position, Rotation);
                            if (newprefab != null)
                            {
                                SpawnerSubmenu.RegisterPrefab(newprefab);
                                Tweaker_Object.SetObjectToEdit(newprefab);
                            }
                        }
                    }, $"Spawn {prefab.name}");
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
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            IsUIPageListenerActive = false;
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
            IsUIPageListenerActive = true;
            Regenerate();
        }

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.isPage(CurrentScrollMenu.GetPage()) )
                    OnCloseMenu();
        }

    }
}