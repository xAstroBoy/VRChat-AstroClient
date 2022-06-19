using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Handlers
{
    internal class RigidBodyControllerHandler : AstroEvents
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
                RigidBodyController RigidBodyController = ComponentUtils.GetOrAddComponent<RigidBodyController>(obj);
                if (RigidBodyController != null)
                {
                    TweakerEventActions.OnRigidBodyControllerSelected.SafetyRaiseWithParams(RigidBodyController);

                    RigidBodyController.SetRigidBodyPropertyChanged(() =>
                    {
                        TweakerEventActions.OnRigidBodyControllerPropertyChanged.SafetyRaiseWithParams(RigidBodyController); // Dunno if it works.
                    });

                    RigidBodyController.SetOnRigidbodyControllerOnUpdate(() =>
                    {
                        TweakerEventActions.OnRigidBodyController_OnUpdate.SafetyRaiseWithParams(RigidBodyController); // Dunno if it works.
                    });
                }
            }
        }

        private void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                RigidBodyController RigidBodyController = ComponentUtils.GetOrAddComponent<RigidBodyController>(obj);
                if (RigidBodyController != null)
                {
                    RigidBodyController.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                }
            }
        }
    }
}