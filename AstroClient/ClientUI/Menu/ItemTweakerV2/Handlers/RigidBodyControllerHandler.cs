namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Tools;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.Utility;

    internal class RigidBodyControllerHandler : Tweaker_Events
    {
        internal static event Action<RigidBodyController> Event_OnRigidBodyControllerSelected;

        internal static event Action<RigidBodyController> Event_OnRigidBodyControllerPropertyChanged;

        internal static event Action<RigidBodyController> Event_OnRigidBodyController_OnUpdate;

        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                RigidBodyController RigidBodyController = obj.GetOrAddComponent<RigidBodyController>();
                if (RigidBodyController != null)
                {
                    Event_OnRigidBodyControllerSelected.SafetyRaiseWithParams(RigidBodyController);

                    RigidBodyController.SetRigidBodyPropertyChanged(() =>
                    {
                        Event_OnRigidBodyControllerPropertyChanged.SafetyRaiseWithParams(RigidBodyController); // Dunno if it works.
                    });

                    RigidBodyController.SetOnRigidbodyControllerOnUpdate(() =>
                    {
                        Event_OnRigidBodyController_OnUpdate.SafetyRaiseWithParams(RigidBodyController); // Dunno if it works.
                    });
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
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