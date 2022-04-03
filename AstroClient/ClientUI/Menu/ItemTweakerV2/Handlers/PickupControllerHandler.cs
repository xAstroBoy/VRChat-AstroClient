namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Tools;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.Utility;

    internal class PickupControllerHandler : Tweaker_Events
    {
        internal static event Action<PickupController> Event_OnPickupControllerSelected;

        internal static event Action<PickupController> Event_OnPickupControllerPropertyChanged;

        internal static event Action<PickupController> Event_OnPickupController_OnUpdate;

        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                var PickupController = obj.GetOrAddComponent<PickupController>();
                if (PickupController != null)
                {
                    Event_OnPickupControllerSelected.SafetyRaise(PickupController);

                    PickupController.SetOnPickupPropertyChanged(() =>
                    {
                        Event_OnPickupControllerPropertyChanged.SafetyRaise(PickupController); // Dunno if it works.
                    });

                    PickupController.SetOnPickup_OnUpdate(() =>
                    {
                        Event_OnPickupController_OnUpdate.SafetyRaise(PickupController); // Dunno if it works.
                    });
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                PickupController PickupController = obj.GetOrAddComponent<PickupController>();
                if (PickupController != null)
                {
                    PickupController.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                    PickupController.AntiTheft = false; // Only one antitheft for pickup controller.
                }
            }
        }
    }
}