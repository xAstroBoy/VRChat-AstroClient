using AstroClient.Components;
using AstroClient.ItemTweakerV2.Handlers;
using AstroClient.ItemTweakerV2.TweakerEventArgs;
using System;
using UnityEngine;

namespace AstroClient.ItemTweakerV2.Selector
{
	public class Tweaker_Events : GameEvents
	{
		public Tweaker_Events()
		{
			Tweaker_Selector.Event_On_New_GameObject_Selected += Internal_On_New_GameObject_Selected;
			Tweaker_Selector.Event_On_Old_GameObject_Removed += Internal_On_Old_GameObject_Removed;
			
			ListenerHandler.Event_OnSelectedObject_Enabled += Internal_OnSelectedObject_Enabled;
			ListenerHandler.Event_OnSelectedObject_Disabled += Internal_OnSelectedObject_Disabled;
			ListenerHandler.Event_OnSelectedObject_Destroyed += Internal_OnSelectedObject_Destroyed;

			PickupControllerHandler.Event_OnPickupControllerSelected += Internal_OnPickupControllerSelected;
			PickupControllerHandler.Event_OnPickupControllerPropertyChanged += Internal_OnPickupController_PropertyChanged;
			PickupControllerHandler.Event_OnPickupController_OnUpdate += Internal_OnPickupController_OnUpdate;

			RigidBodyControllerHandler.Event_OnRigidBodyControllerSelected += Internal_OnRigidBodyControllerSelected;
			RigidBodyControllerHandler.Event_OnRigidBodyControllerPropertyChanged += Internal_OnRigidBodyControllerSelected;
			RigidBodyControllerHandler.Event_OnRigidBodyController_OnUpdate += Internal_OnRigidBodyController_OnUpdate;

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

		private void Internal_OnPickupControllerSelected(object sender, OnPickupControllerArgs e)
		{
			OnPickupControllerSelected(e.control);
		}

		private void Internal_OnPickupController_PropertyChanged(object sender, OnPickupControllerArgs e)
		{
			OnPickupController_PropertyChanged(e.control);
		}
		private void Internal_OnPickupController_OnUpdate(object sender, OnPickupControllerArgs e)
		{
			OnPickupController_OnUpdate(e.control);
		}

		private void Internal_OnRigidBodyControllerSelected(object sender, OnRigidBodyControllerArgs e)
		{
			OnRigidBodyControllerSelected(e.control);
		}

		private void Internal_OnRigidBodyController_PropertyChanged(object sender, OnRigidBodyControllerArgs e)
		{
			OnRigidBodyController_PropertyChanged(e.control);
		}


		private void Internal_OnRigidBodyController_OnUpdate(object sender, OnRigidBodyControllerArgs e)
		{
			OnRigidBodyController_OnUpdate(e.control);
		}


		public virtual void On_Old_GameObject_Removed(GameObject obj)
		{
		}

		public virtual void On_New_GameObject_Selected(GameObject obj)
		{
		}

		public virtual void OnSelectedObject_Enabled()
		{
		}

		public virtual void OnSelectedObject_Disabled()
		{
		}

		public virtual void OnSelectedObject_Destroyed()
		{
		}

		public virtual void OnRigidBodyControllerSelected(RigidBodyController control)
		{
		}

		public virtual void OnRigidBodyController_PropertyChanged(RigidBodyController control)
		{
		}
		public virtual void OnRigidBodyController_OnUpdate(RigidBodyController control)
		{
		}

		public virtual void OnPickupControllerSelected(PickupController control)
		{
		}

		public virtual void OnPickupController_PropertyChanged(PickupController control)
		{
		}

		public virtual void OnPickupController_OnUpdate(PickupController control)
		{
		}
	}
}