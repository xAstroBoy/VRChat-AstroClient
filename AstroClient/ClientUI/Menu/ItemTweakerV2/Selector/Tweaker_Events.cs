namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Selector
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using AstroMonos.Components.Tools;
    using Handlers;
    using UnityEngine;

    internal class Tweaker_Events : AstroEvents
    {
        public Tweaker_Events()
        {
            Tweaker_Selector.Event_On_New_GameObject_Selected += On_New_GameObject_Selected;
            Tweaker_Selector.Event_On_Old_GameObject_Removed += On_Old_GameObject_Removed;

            ListenerHandler.Event_OnSelectedObject_Enabled += OnSelectedObject_Enabled;
            ListenerHandler.Event_OnSelectedObject_Disabled += OnSelectedObject_Disabled;
            ListenerHandler.Event_OnSelectedObject_Destroyed += OnSelectedObject_Destroyed;

            PickupControllerHandler.Event_OnPickupControllerSelected += OnPickupController_Selected;
            PickupControllerHandler.Event_OnPickupControllerPropertyChanged += OnPickupController_PropertyChanged;
            PickupControllerHandler.Event_OnPickupController_OnUpdate += OnPickupController_OnUpdate;

            RigidBodyControllerHandler.Event_OnRigidBodyControllerSelected += OnRigidBodyController_Selected;
            RigidBodyControllerHandler.Event_OnRigidBodyControllerPropertyChanged += OnRigidBodyController_PropertyChanged;
            RigidBodyControllerHandler.Event_OnRigidBodyController_OnUpdate += OnRigidBodyController_OnUpdate;

            RocketBehaviourHandler.Event_OnRocketBehaviourPropertyChanged += OnRocketBehaviour_OnPropertyChanged;
            CrazyBehaviourHandler.Event_OnCrazyBehaviourPropertyChanged += OnCrazyBehaviour_OnPropertyChanged;
            SpinnerBehaviourHandler.Event_OnSpinnerBehaviourPropertyChanged += OnSpinnerBehaviour_OnPropertyChanged;

            InflaterBehaviourHandler.Event_OnInflaterBehaviourPropertyChanged += OnInflaterBehaviour_PropertyChanged;
            InflaterBehaviourHandler.Event_OnInflaterBehaviourUpdate += OnInflaterBehaviour_OnUpdate;

            // TODO : Figure a way to add Event and Getter Listeners as well for certain Components.
        }


        internal virtual void On_Old_GameObject_Removed(GameObject obj)
        {
        }

        internal virtual void On_New_GameObject_Selected(GameObject obj)
        {
        }

        internal virtual void OnSelectedObject_Enabled()
        {
        }

        internal virtual void OnSelectedObject_Disabled()
        {
        }

        internal virtual void OnSelectedObject_Destroyed()
        {
        }

        internal virtual void OnRigidBodyController_Selected(RigidBodyController control)
        {
        }

        internal virtual void OnRigidBodyController_PropertyChanged(RigidBodyController control)
        {
        }

        internal virtual void OnRigidBodyController_OnUpdate(RigidBodyController control)
        {
        }

        internal virtual void OnPickupController_Selected(PickupController control)
        {
        }

        internal virtual void OnPickupController_PropertyChanged(PickupController control)
        {
        }

        internal virtual void OnPickupController_OnUpdate(PickupController control)
        {
        }

        internal virtual void OnRocketBehaviour_OnPropertyChanged(RocketBehaviour RocketBehaviour)
        {
        }
        internal virtual void OnCrazyBehaviour_OnPropertyChanged(CrazyBehaviour CrazyBehaviour)
        {
        }
        internal virtual void OnSpinnerBehaviour_OnPropertyChanged(SpinnerBehaviour SpinnerBehaviour)
        {
        }
        internal virtual void OnInflaterBehaviour_PropertyChanged(InflaterBehaviour inflaterBehaviour)
        {
        }
        internal virtual void OnInflaterBehaviour_OnUpdate(InflaterBehaviour inflaterBehaviour)
        {
        }


    }
}