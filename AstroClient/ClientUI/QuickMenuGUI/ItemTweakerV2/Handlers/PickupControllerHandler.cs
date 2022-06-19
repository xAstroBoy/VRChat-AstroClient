using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Handlers
{
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
                var PickupController = ComponentUtils.GetOrAddComponent<PickupController>(obj);
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
                PickupController PickupController = ComponentUtils.GetOrAddComponent<PickupController>(obj);
                if (PickupController != null)
                {
                    PickupController.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                    PickupController.AntiTheft = false; // Only one antitheft for pickup controller.
                }
            }
        }
    }
}