namespace AstroClient.ItemTweakerV2.Submenus.Collider
{

	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus.Collider;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using UnityEngine;
	using VRC;

	internal class ColliderEditor : Tweaker_Events
	{

		public static void Init_ColliderEditor(QMNestedButton main, float x, float y, bool btnhalf)
		{
			var menu = new QMNestedButton(main, x, y, "Collider Editor", "Edit Collider Properties", null, null, null, null, btnhalf);


			Pickup_IsHeldStatus = new QMSingleButton(main, -1, -1f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

			Pickup_CurrentObjectHolder = new QMSingleButton(main, -1, -0.5f, "Current holder : null", null, "Who is the current object Holder.", null, null, false);
			Pickup_CurrentObjectHolder.SetResizeTextForBestFit(true);

			Pickup_CurrentObjectOwner = new QMSingleButton(main, -1, 0.5f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
			Pickup_CurrentObjectOwner.SetResizeTextForBestFit(true);



			TeleportToMe = new QMSingleButton(main, -1, 1.5f, Button_strings_ext.Generate_TeleportToMe_ButtonText(null), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }), Button_strings_ext.Generate_TeleportToMe_ButtonText(null), null, null);
			TeleportToMe.SetResizeTextForBestFit(true);

			TeleportToTarget = new QMSingleButton(main, -1, 2.5f, Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }), Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), null, null);
			TeleportToTarget.SetResizeTextForBestFit(true);






			new QMSingleButton(menu, 1, 0f, "Activates all Colliders", new Action(() => { Tweaker_Object.GetGameObjectToEdit().EnableColliders(); }), "Enables all colliders bound to the object", null, null, true);
			new QMSingleButton(menu, 1, 0.5f, "Add Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);
			new QMSingleButton(menu, 1, 1f, "Add Trigger Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddTriggerCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);

		}



		public override void OnPickupController_OnUpdate(PickupController control)
		{
			if (control != null)
			{

				if (Pickup_IsHeldStatus != null)
				{
					Pickup_IsHeldStatus.SetButtonText(control.Get_IsHeld_ButtonText());
					Pickup_IsHeldStatus.SetTextColor(control.Get_IsHeld_ButtonColor());
				}
				if (Pickup_CurrentObjectOwner != null)
				{
					Pickup_CurrentObjectOwner.SetButtonText(control.Get_PickupOwner_ButtonText());
				}
				if (Pickup_CurrentObjectHolder != null)
				{
					Pickup_CurrentObjectHolder.SetButtonText(control.Get_IsHeldBy_ButtonText());
				}
			}
		}

		public override void On_New_GameObject_Selected(GameObject obj)
		{
			if (TeleportToTarget != null)
			{
				TeleportToTarget.SetButtonText(Button_strings_ext.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
				TeleportToTarget.SetToolTip(Button_strings_ext.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
			}
			if (TeleportToMe != null)
			{
				TeleportToMe.SetButtonText(obj.Generate_TeleportToMe_ButtonText());
				TeleportToMe.SetToolTip(obj.Generate_TeleportToMe_ButtonText());
			}
		}

		public override void OnTargetSet(Player player)
		{
			if (TeleportToTarget != null)
			{
				TeleportToTarget.SetButtonText(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
				TeleportToTarget.SetToolTip(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
			}

		}


		public static QMSingleButton TeleportToMe;
		public static QMSingleButton TeleportToTarget;

		private static QMSingleButton Pickup_IsHeldStatus { get; set; }
		private static QMSingleButton Pickup_CurrentObjectHolder { get; set; }
		private static QMSingleButton Pickup_CurrentObjectOwner { get; set; }

	}
}