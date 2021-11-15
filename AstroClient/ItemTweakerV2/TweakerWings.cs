﻿namespace AstroClient.ItemTweakerV2
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroMonos.Components.Tools;
    using CheetoLibrary;
    using Selector;
    using System.Reflection;
    using UnityEngine;
    using VRC;

    internal class TweakerWings : Tweaker_Events
    {
        private static QMWingSingleButton Pickup_IsHeldStatus;
        private static QMWingSingleButton Pickup_CurrentObjectHolder;
        private static QMWingSingleButton Pickup_CurrentObjectOwner;
        private static QMWingSingleButton TeleportToMe;
        private static QMWingSingleButton TeleportToTarget;

        private static QMWingSingleButton ObjectToEditBtn;

        private static QMWingToggleButton LockHoldItem;
        private static QMWingToggleButton AntiTheftInteractor;
        private static QMWingToggleButton ProtectionInteractor;

        private static QMWings WingsMenu;

        internal static void InitTweakerWings()
        {
            WingsMenu = new QMWings(1011, true, "Tweaker", "Item Tweaker", null, null);
            WingsMenu.LoadIcon(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.box.png"));
            Pickup_CurrentObjectOwner = new QMWingSingleButton(WingsMenu, "Current Owner : null", () => { }, "Who is the current object owner,", null);
            Pickup_IsHeldStatus = new QMWingSingleButton(WingsMenu, "", () => { }, "Held : No.", null);
            Pickup_CurrentObjectHolder = new QMWingSingleButton(WingsMenu, "Current holder : null", () => { }, "Who is the Holding the object", null);
            TeleportToMe = new QMWingSingleButton(WingsMenu, ButtonStringExtensions.Generate_TeleportToMe_ButtonText(Tweaker_Selector.SelectedObject), () => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }, ButtonStringExtensions.Generate_TeleportToMe_ButtonText(Tweaker_Selector.SelectedObject), null);
            TeleportToTarget = new QMWingSingleButton(WingsMenu, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), () => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), null);
          
            
            //AntiTheftInteractor = new QMWingToggleButton(WingsMenu, "AntiTheft", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object");
            //ProtectionInteractor = new QMWingToggleButton(WingsMenu, "Interaction block", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object");
            //LockHoldItem = new QMWingToggleButton(WingsMenu, "Lock", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object");


            new QMWingSingleButton(WingsMenu, "DANGER : Destroy item.", () => { Tweaker_Object.GetGameObjectToEdit().DestroyObject(); }, "Destroys Object , You need to reload the world to restore it back.", Color.red);


        }

        internal override void OnPickupController_OnUpdate(PickupController control)
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

        internal override void On_New_GameObject_Selected(GameObject obj)
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

        internal override void OnTargetSet(Player player)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
            }
        }
    }
}