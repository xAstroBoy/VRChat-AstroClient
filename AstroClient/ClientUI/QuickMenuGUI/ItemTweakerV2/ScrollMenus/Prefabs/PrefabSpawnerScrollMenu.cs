using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Spawner;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.SDKBase;
using VRC.UI.Elements;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.ScrollMenus.Prefabs
{
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
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
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
                foreach (var prefab in SceneUtils.DynamicPrefabs)
                {
                    var btn = new QMSingleButton(CurrentScrollMenu, 0, 0, $"Spawn {prefab.name}", () =>
                    {
                        Vector3? buttonPosition = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
                        Quaternion? buttonRotation = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;

                        if (buttonPosition.HasValue && buttonRotation.HasValue)
                        {
                            var newprefab = Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, prefab.name, buttonPosition.GetValueOrDefault(), buttonRotation.GetValueOrDefault());
                            if (newprefab != null)
                            {
                                Tweaker_Object.SetObjectToEdit(newprefab);
                                newprefab.AddToWorldUtilsMenu();
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


    }
}