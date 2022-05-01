using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Tools;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.Utility;

    internal class PickupControllerHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.On_Old_GameObject_Removed += On_Old_GameObject_Removed;
        }
    

        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                var PickupController = obj.GetOrAddComponent<PickupController>();
                if (PickupController != null)
                {
                    TweakerEventActions.OnPickupControllerSelected.SafetyRaiseWithParams(PickupController);

                    PickupController.SetOnPickupPropertyChanged(() =>
                    {
                        TweakerEventActions.OnPickupControllerPropertyChanged.SafetyRaiseWithParams(PickupController); // Dunno if it works.
                    });

                    PickupController.SetOnPickup_OnUpdate(() =>
                    {
                        TweakerEventActions.OnPickupController_OnUpdate.SafetyRaiseWithParams(PickupController); // Dunno if it works.
                    });
                }
            }
        }

        private void On_Old_GameObject_Removed(GameObject obj)
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