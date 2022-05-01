﻿using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2
{
    using AstroMonos.Components.Tools;
    using ClientResources;
    using ClientResources.Loaders;
    using Selector;
    using Submenus.Pickup;
    using Target;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using UnityEngine;
    using VRC;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.WingsAPI;
    using xAstroBoy.Extensions;

    internal class TweakerWings : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.OnPickupController_OnUpdate += OnPickupController_OnUpdate;
            ClientEventActions.OnTargetSet += OnTargetSet;
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

        internal static QMWings TweakerMainWings;

        // Future Wings.
           //_ = new QMSingleButton(menu, 1, 0f, "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().TryTakeOwnership(); }), "Make Whatever Player, drop the object.", null, Color.cyan, true);
           // AntiTheftInteractor = new QMSingleToggleButton(menu, 1, 0.5f, "AntiTheft ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(true); }, "AntiTheft OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(false); }, "Toggles PickupController WIP antitheft", Color.green, Color.red, null, false, true);
           // ProtectionInteractor = new QMSingleToggleButton(menu, 1, 1, "Interaction block ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, "Interaction block OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object", Color.green, Color.red, null, false, true);
           // new QMSingleToggleButton(menu, 2, 1.5f, "Selected Item ESP : ON", () => { EspHandler.TweakerESPEnabled = true; }, "Selected Item ESP : OFF", () => { EspHandler.TweakerESPEnabled = false; }, "Toggles Selected item ESP", Color.green, Color.red, null, false, true);
           // LockHoldItem = new QMSingleToggleButton(menu, 2, 2.5f, "Lock ON", () => { Tweaker_Object.LockItem = true; }, "Lock OFF", () => { Tweaker_Object.LockItem = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)", Color.green, Color.red, null, false, true);
           // ObjectToEditBtn = new QMSingleButton(menu, 1, 2f, "None", new Action(() => { _ = Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", null, null);

        internal static void InitTweakerWings()
        {
            TweakerMainWings = new QMWings(1011, true, "Tweaker", "Item Tweaker",  Icons.box_sprite);
            Pickup_CurrentObjectOwner = new QMWingSingleButton(TweakerMainWings, "Current Owner : null", () => { }, "Who is the current object owner,", null);
            Pickup_IsHeldStatus = new QMWingSingleButton(TweakerMainWings, "", () => { }, "Held : No.", null);
            Pickup_CurrentObjectHolder = new QMWingSingleButton(TweakerMainWings, "Current holder : null", () => { }, "Who is the Holding the object", null);
            TeleportToMe = new QMWingSingleButton(TweakerMainWings, ButtonStringExtensions.Generate_TeleportToMe_ButtonText(Tweaker_Selector.SelectedObject), () => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }, ButtonStringExtensions.Generate_TeleportToMe_ButtonText(Tweaker_Selector.SelectedObject), null);
            TeleportToTarget = new QMWingSingleButton(TweakerMainWings, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), () => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), null);
          
            
            //AntiTheftInteractor = new QMWingToggleButton(WingsMenu, "AntiTheft", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object");
            //ProtectionInteractor = new QMWingToggleButton(WingsMenu, "Interaction block", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object");
            //LockHoldItem = new QMWingToggleButton(WingsMenu, "Lock", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object");


            new QMWingSingleButton(TweakerMainWings, "DANGER : Destroy item.", () => { Tweaker_Object.GetGameObjectToEdit().DestroyObject(); }, "Destroys Object , You need to reload the world to restore it back.", Color.red);

            PickupSubmenu.InitWings(TweakerMainWings);
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