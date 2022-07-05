using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.Target;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.Tools.World;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI;
using AstroClient.xAstroBoy.Extensions;
using UnityEngine;
using VRC;
using VRC.UI.Elements;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.ScrollMenus.Pickup
{
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
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
            TweakerEventActions.On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.OnPickupController_OnUpdate += OnPickupController_OnUpdate;
            ClientEventActions.OnTargetSet += OnTargetSet;

        }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
        }

        private static QMWingSingleButton Pickup_IsHeldStatus;
        private static QMWingSingleButton Pickup_CurrentObjectHolder;
        private static QMWingSingleButton Pickup_CurrentObjectOwner;
        private static QMWingSingleButton TeleportToMe;
        private static QMWingSingleButton TeleportToTarget;

        private static QMWingSingleButton ObjectToEditBtn;

        private static QMWingToggleButton LockHoldItem;
        private static QMWingToggleButton AntiTheftInteractor;
        private static QMWingToggleButton ProtectionInteractor;

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
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
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
                    var btn = new QMSingleButton(CurrentScrollMenu, $"Select {pickup.name}", () => { Tweaker_Object.SetObjectToEdit(pickup, true); }, $"Select {pickup.name}", pickup.Get_GameObject_Active_ToColor());

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
            IsUIPageListenerActive = true;
            Regenerate();
        }

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType, bool Toggle2)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.isPage(CurrentScrollMenu.GetPage()))
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu, 1008, true, "Tweaker Pickups", "Select Pickup To modify!");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            Pickup_CurrentObjectOwner = new QMWingSingleButton(WingMenu, "Current Owner : null", () => { }, "Who is the current object owner,", null);
            Pickup_IsHeldStatus = new QMWingSingleButton(WingMenu, "", () => { }, "Held : No.", null);
            Pickup_CurrentObjectHolder = new QMWingSingleButton(WingMenu, "Current holder : null", () => { }, "Who is the Holding the object", null);
            TeleportToMe = new QMWingSingleButton(WingMenu, ButtonStringExtensions.Generate_TeleportToMe_ButtonText(Tweaker_Selector.SelectedObject), () => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }, ButtonStringExtensions.Generate_TeleportToMe_ButtonText(Tweaker_Selector.SelectedObject), null);
            TeleportToTarget = new QMWingSingleButton(WingMenu, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), () => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), null);
            WingMenu.SetActive(false);
        }

        private void OnPickupController_OnUpdate(PickupController control)
        {
            if (control != null)
            {
                if (Pickup_IsHeldStatus != null)
                {
                    Pickup_IsHeldStatus.SetButtonText(control.Get_IsHeld_ButtonText());
                    Pickup_IsHeldStatus.SetTextColor(control.Get_IsHeld_ButtonColor());
                }
                if (Pickup_CurrentObjectOwner != null)
                {
                    Pickup_CurrentObjectOwner.SetButtonText(control.Get_PickupOwner_ButtonText());
                }
                if (Pickup_CurrentObjectHolder != null)
                {
                    Pickup_CurrentObjectHolder.SetButtonText(control.Get_IsHeldBy_ButtonText());
                }
            }
        }

        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
            }
            if (TeleportToMe != null)
            {
                TeleportToMe.SetButtonText(obj.Generate_TeleportToMe_ButtonText());
                TeleportToMe.SetToolTip(obj.Generate_TeleportToMe_ButtonText());
            }
        }

        private void OnTargetSet(Player player)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
            }
        }
        
    }
}