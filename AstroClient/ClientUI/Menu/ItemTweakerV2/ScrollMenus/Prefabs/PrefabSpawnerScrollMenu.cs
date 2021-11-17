namespace AstroClient.ClientUI.Menu.ItemTweakerV2.ScrollMenus.Prefabs
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;
    using Submenus.Spawner;
    using UnityEngine;
    using VRC.SDKBase;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class PrefabSpawnerScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();



        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = false;

        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }


        internal override void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }
        }


        internal static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Spawn Prefabs", "Spawn World Prefabs", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                OnOpenMenu();
            });
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
                        var position = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Position(HumanBodyBones.RightHand);
                        var Rotation = prefab.transform.rotation;

                        if (position != null)
                        {
                            var newprefab = Networking.Instantiate(broadcast, prefabinfo, position.Value, Rotation);
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
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }
            if (Listeners.Count != 0)
            {
                foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            }

        }

        internal override void OnQuickMenuClose()
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
            isOpen = false;

        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowLeftWingPage();
            }
            Regenerate();
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (!isOpen) return;

            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
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