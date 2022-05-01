using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Tools;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.Utility;

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
                RigidBodyController RigidBodyController = obj.GetOrAddComponent<RigidBodyController>();
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
                RigidBodyController RigidBodyController = obj.GetOrAddComponent<RigidBodyController>();
                if (RigidBodyController != null)
                {
                    RigidBodyController.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                }
            }
        }
    }
}