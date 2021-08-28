namespace AstroClient.ItemTweakerV2.Handlers
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroClient.ItemTweakerV2.TweakerEventArgs;
    using AstroLibrary.Extensions;
    using System;
    using UnityEngine;

    public class RigidBodyControllerHandler : Tweaker_Events
    {
        public static event EventHandler<OnRigidBodyControllerArgs> Event_OnRigidBodyControllerSelected;

        public static event EventHandler<OnRigidBodyControllerArgs> Event_OnRigidBodyControllerPropertyChanged;

        public static event EventHandler<OnRigidBodyControllerArgs> Event_OnRigidBodyController_OnUpdate;

        public override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                RigidBodyController RigidBodyController = obj.GetOrAddComponent<RigidBodyController>();
                if (RigidBodyController != null)
                {
                    Event_OnRigidBodyControllerSelected.SafetyRaise(new OnRigidBodyControllerArgs(RigidBodyController));
                    RigidBodyController.SetRigidBodyPropertyChanged(() =>
                    {
                        Event_OnRigidBodyControllerPropertyChanged.SafetyRaise(new OnRigidBodyControllerArgs(RigidBodyController)); // Dunno if it works.
                    });

                    RigidBodyController.SetOnRigidbodyControllerOnUpdate(() =>
                    {
                        Event_OnRigidBodyController_OnUpdate.SafetyRaise(new OnRigidBodyControllerArgs(RigidBodyController)); // Dunno if it works.
                    });
                }
            }
        }

        public override void On_Old_GameObject_Removed(GameObject obj)
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