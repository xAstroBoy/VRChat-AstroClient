using AstroClient.ItemTweakerV2.TweakerEventArgs;
using System;
using UnityEngine;
using AstroClient.Extensions;
using AstroClient.Components;


namespace AstroClient.ItemTweakerV2.Selector
{
	public class Object_Selector : ObjectSelectorHelper
	{
		public static event EventHandler<SelectedObjectArgs> Event_On_New_GameObject_Selected;
		public static event EventHandler<SelectedObjectArgs> Event_On_Old_GameObject_Removed;

		public static event EventHandler<OnPickupControllerArgs> Event_OnPickupControllerSelected;
		public static event EventHandler<OnRigidBodyControllerArgs> Event_OnRigidBodyControllerSelected;

		public static event EventHandler<OnPickupControllerArgs> Event_OnPickupControllerUpdate;
		public static event EventHandler<OnRigidBodyControllerArgs> Event_OnRigidBodyControllerUpdate;

		private static GameObject _SelectedObject;
		public static GameObject SelectedObject
		{
			get
			{
				return _SelectedObject;
			}
			set
			{
				if (value == null)
				{
					Event_On_Old_GameObject_Removed?.Invoke(null, new SelectedObjectArgs(null));
					Event_On_New_GameObject_Selected?.Invoke(null, new SelectedObjectArgs(null));
					return;
				}
				if(value != _SelectedObject)
				{
					Event_On_Old_GameObject_Removed?.Invoke(null, new SelectedObjectArgs(_SelectedObject));
					Event_On_New_GameObject_Selected?.Invoke(null, new SelectedObjectArgs(value));
					if (value != null)
					{
						RigidBodyController RigidBodyController = value.GetOrAddComponent<RigidBodyController>();
						if(RigidBodyController != null)
						{
							Event_OnRigidBodyControllerSelected?.Invoke(null, new OnRigidBodyControllerArgs(RigidBodyController));
						}
						PickupController PickupController = value.GetOrAddComponent<PickupController>();
						if (PickupController != null)
						{
							Event_OnPickupControllerSelected?.Invoke(null, new OnPickupControllerArgs(PickupController));
						}
					}

				}
				_SelectedObject = value;
				
			}

		}
	}
}