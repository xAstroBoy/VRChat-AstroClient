namespace AstroClient.ItemTweakerV2.Handlers
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.TweakerEventArgs;
	using System;
	using UnityEngine;

	public class RigidBodyControllerHandler : ObjectSelectorHelper
	{
		public static event EventHandler<OnRigidBodyControllerArgs> Event_OnRigidBodyControllerSelected;

		public static event EventHandler<OnRigidBodyControllerArgs> Event_OnRigidBodyControllerUpdate;

		public override void On_New_GameObject_Selected(GameObject obj)
		{
			if (obj != null)
			{
				RigidBodyController RigidBodyController = obj.GetOrAddComponent<RigidBodyController>();
				if (RigidBodyController != null)
				{
					Event_OnRigidBodyControllerSelected?.Invoke(null, new OnRigidBodyControllerArgs(RigidBodyController));
				}
			}
		}
	}
}