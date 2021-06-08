namespace AstroClient.ItemTweakerV2.Handlers
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.TweakerEventArgs;
	using System;
	using UnityEngine;

	public class PickupControllerHandler : ObjectSelectorHelper
	{
		public static event EventHandler<OnPickupControllerArgs> Event_OnPickupControllerSelected;

		public static event EventHandler<OnPickupControllerArgs> Event_OnPickupControllerPropertyChanged;

		public static event EventHandler<OnPickupControllerArgs> Event_OnPickupController_OnUpdate;

		public override void On_New_GameObject_Selected(GameObject obj)
		{
			if (obj != null)
			{
				PickupController PickupController = obj.GetOrAddComponent<PickupController>();
				if (PickupController != null)
				{
					Event_OnPickupControllerSelected?.Invoke(null, new OnPickupControllerArgs(PickupController));
				}
				PickupController.SetOnPickupPropertyChanged(() =>
				{
				Event_OnPickupControllerPropertyChanged?.Invoke(null, new OnPickupControllerArgs(PickupController)); // Dunno if it works.
				});

				PickupController.SetOnPickup_OnUpdate(() =>
				{
					Event_OnPickupController_OnUpdate?.Invoke(null, new OnPickupControllerArgs(PickupController)); // Dunno if it works.
				});
			}
		}

		public override void On_Old_GameObject_Removed(GameObject obj)
		{
			if (obj != null)
			{
				PickupController PickupController = obj.GetOrAddComponent<PickupController>();
				if (PickupController != null)
				{
					PickupController.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
				}
			}
		}


	}
}