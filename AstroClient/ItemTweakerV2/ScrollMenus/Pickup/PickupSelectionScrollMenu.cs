namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using UnityEngine;
	using VRC;

	public class PickupSelectionScrollMenu : Tweaker_Events
	{
		public static void Init_PickupSelectionQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Select Pickup", "Select World Pickup to edit", null, null, null, null, btnHalf);
			var PickupQMScroll = new QMScrollMenu(menu);
			new QMSingleButton(menu, 0, -1, "Refresh", delegate
			{
				PickupQMScroll.Refresh();
			}, "", null, null, true);

			TeleportToMe = new QMSingleButton(menu, 0, -0.5f, Tweaker_Selector.Component_Get_SelectedObject.Generate_TeleportToMe_ButtonText(), delegate
		   {
			   Tweaker_Object.GetGameObjectToEdit().TeleportToMe();
		   }, Tweaker_Selector.Component_Get_SelectedObject.Generate_TeleportToMe_ButtonText());
			TeleportToMe.SetResizeTextForBestFit(true);

			TeleportToTarget = new QMSingleButton(menu, 0, 0.5f, Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), delegate
			{
				Tweaker_Object.GetGameObjectToEdit().TeleportToTarget();
			}, Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget));
			TeleportToTarget.SetResizeTextForBestFit(true);


			new QMSingleButton(menu, 0, 1.5f, "Spawn Clone", new Action(() => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }), "Instantiates a copy of The selected object.", null, null, true);

			PickupQMScroll.SetAction(delegate
			{
				foreach (var pickup in WorldUtils.Get_Pickups())
				{
					PickupQMScroll.Add(
					new QMSingleButton(PickupQMScroll.BaseMenu, 0, 0, $"Select {pickup.name}", delegate
					{
						Tweaker_Object.SetObjectToEdit(pickup);
					}, $"Select {pickup.name}", null, pickup.Get_GameObject_Active_ToColor()));
				}
			});
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
	}
}