﻿namespace AstroClient.ItemTweakerV2.Handlers
{
	using AstroClient.Components;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.TweakerEventArgs;
	using AstroLibrary.Extensions;
	using System;
	using UnityEngine;

	public class PickupControllerHandler : Tweaker_Events
    {
        public static event EventHandler<OnPickupControllerArgs> Event_OnPickupControllerSelected;

        public static event EventHandler<OnPickupControllerArgs> Event_OnPickupControllerPropertyChanged;

        public static event EventHandler<OnPickupControllerArgs> Event_OnPickupController_OnUpdate;

        public override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                PickupController PickupController = obj.GetOrAddComponent<PickupController>();
                if (PickupController != null)
                {
                    Event_OnPickupControllerSelected.SafetyRaise(new OnPickupControllerArgs(PickupController));
                }
                PickupController.SetOnPickupPropertyChanged(() =>
                {
                    Event_OnPickupControllerPropertyChanged.SafetyRaise(new OnPickupControllerArgs(PickupController)); // Dunno if it works.
                });

                PickupController.SetOnPickup_OnUpdate(() =>
                {
                    Event_OnPickupController_OnUpdate.SafetyRaise(new OnPickupControllerArgs(PickupController)); // Dunno if it works.
                });
            }
        }

        public override void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                PickupController PickupController = obj.GetOrAddComponent<PickupController>();
                if (PickupController != null)
                {
                    PickupController.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                }
            }
        }
    }
}