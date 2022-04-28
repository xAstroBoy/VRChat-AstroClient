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
            ClientEventActions.OnUiPageToggled += OnUiPageToggled;
        }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
        }


        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Spawn Prefabs", "Spawn World Prefabs");
            CurrentScrollMenu.SetBackButtonAction(menu, () => { OnCloseMenu(); });
            CurrentScrollMenu.AddOpenAction(() => { OnOpenMenu(); });
            InitWingPage();
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
            if (DestroyOnMenuClose) DestroyGeneratedButtons();
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

        private void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(WingMenu.CurrentPage))
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1013, true, "Tweaker Prefabs", "Prefabs Menu");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}