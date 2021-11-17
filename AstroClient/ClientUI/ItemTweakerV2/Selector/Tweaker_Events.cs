namespace AstroClient.ClientUI.ItemTweakerV2.Selector
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using AstroMonos.Components.Tools;
    using Handlers;
    using TweakerEventArgs;
    using UnityEngine;

    internal class Tweaker_Events : AstroEvents
    {
        public Tweaker_Events()
        {
            Tweaker_Selector.Event_On_New_GameObject_Selected += Internal_On_New_GameObject_Selected;
            Tweaker_Selector.Event_On_Old_GameObject_Removed += Internal_On_Old_GameObject_Removed;

            ListenerHandler.Event_OnSelectedObject_Enabled += Internal_OnSelectedObject_Enabled;
            ListenerHandler.Event_OnSelectedObject_Disabled += Internal_OnSelectedObject_Disabled;
            ListenerHandler.Event_OnSelectedObject_Destroyed += Internal_OnSelectedObject_Destroyed;

            PickupControllerHandler.Event_OnPickupControllerSelected += Internal_OnPickupController_Selected;
            PickupControllerHandler.Event_OnPickupControllerPropertyChanged += Internal_OnPickupController_PropertyChanged;
            PickupControllerHandler.Event_OnPickupController_OnUpdate += Internal_OnPickupController_OnUpdate;

            RigidBodyControllerHandler.Event_OnRigidBodyControllerSelected += Internal_OnRigidBodyControllerSelected;
            RigidBodyControllerHandler.Event_OnRigidBodyControllerPropertyChanged += Internal_OnRigidBodyController_PropertyChanged;
            RigidBodyControllerHandler.Event_OnRigidBodyController_OnUpdate += Internal_OnRigidBodyController_OnUpdate;

            RocketBehaviourHandler.Event_OnRocketBehaviourPropertyChanged += internal_OnRocketBehaviour_OnPropertyChanged;
            CrazyBehaviourHandler.Event_OnCrazyBehaviourPropertyChanged+= internal_OnCrazyBehaviour_OnPropertyChanged;
            SpinnerBehaviourHandler.Event_OnSpinnerBehaviourPropertyChanged+= internal_OnSpinnerBehaviour_OnPropertyChanged;

            InflaterBehaviourHandler.Event_OnInflaterBehaviourPropertyChanged+= Internal_OnInflaterBehaviour_PropertyChanged;
            InflaterBehaviourHandler.Event_OnInflaterBehaviourUpdate += Internal_OnInflaterBehaviour_OnUpdate;

            // TODO : Figure a way to add Event and Getter Listeners as well for certain Components.
        }

        private void Internal_On_New_GameObject_Selected(object sender, SelectedObjectArgs e)
        {
            On_New_GameObject_Selected(e.GameObject);
        }

        private void Internal_On_Old_GameObject_Removed(object sender, SelectedObjectArgs e)
        {
            On_Old_GameObject_Removed(e.GameObject);
        }

        private void Internal_OnSelectedObject_Enabled(object sender, EventArgs e)
        {
            OnSelectedObject_Enabled();
        }

        private void Internal_OnSelectedObject_Disabled(object sender, EventArgs e)
        {
            OnSelectedObject_Disabled();
        }

        private void Internal_OnSelectedObject_Destroyed(object sender, EventArgs e)
        {
            OnSelectedObject_Destroyed();
        }

        private void Internal_OnPickupController_Selected(object sender, OnPickupControllerArgs e)
        {
            OnPickupController_Selected(e.PickupController);
        }

        private void Internal_OnPickupController_PropertyChanged(object sender, OnPickupControllerArgs e)
        {
            OnPickupController_PropertyChanged(e.PickupController);
        }

        private void Internal_OnPickupController_OnUpdate(object sender, OnPickupControllerArgs e)
        {
            OnPickupController_OnUpdate(e.PickupController);
        }

        private void Internal_OnRigidBodyControllerSelected(object sender, OnRigidBodyControllerArgs e)
        {
            OnRigidBodyController_Selected(e.RigidBodyController);
        }

        private void Internal_OnRigidBodyController_PropertyChanged(object sender, OnRigidBodyControllerArgs e)
        {
            OnRigidBodyController_PropertyChanged(e.RigidBodyController);
        }

        private void Internal_OnRigidBodyController_OnUpdate(object sender, OnRigidBodyControllerArgs e)
        {
            OnRigidBodyController_OnUpdate(e.RigidBodyController);
        }

        private void internal_OnRocketBehaviour_OnPropertyChanged(object sender, OnRocketBehaviourArgs e)
        {
            OnRocketBehaviour_OnPropertyChanged(e.RocketBehaviour);
        }
        private void internal_OnCrazyBehaviour_OnPropertyChanged(object sender, OnCrazyBehaviourArgs e)
        {
            OnCrazyBehaviour_OnPropertyChanged(e.CrazyBehaviour);

        }
        private void internal_OnSpinnerBehaviour_OnPropertyChanged(object sender, OnSpinnerBehaviourArgs e)
        {
            OnSpinnerBehaviour_OnPropertyChanged(e.SpinnerBehaviour);
        }

        private void Internal_OnInflaterBehaviour_PropertyChanged(object sender, OnInflaterBehaviourArgs e)
        {
            OnInflaterBehaviour_PropertyChanged(e.InflaterBehaviour);
        }


        private void Internal_OnInflaterBehaviour_OnUpdate(object sender, OnInflaterBehaviourArgs e)
        {
            OnInflaterBehaviour_OnUpdate(e.InflaterBehaviour);
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