namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using RubyButtonAPI;
	using System;

	public class PickupSelectionScrollMenu
	{
		public static void Init_PickupSelectionQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Select Pickup", "Select World Pickup to edit", null, null, null, null, btnHalf);
			var PickupQMScroll = new QMScrollMenu(menu);
			new QMSingleButton(menu, 0, -1, "Refresh", delegate
			{
				PickupQMScroll.Refresh();
			}, "", null, null, true);

			// TeleportToMePickup = new QMSingleButton(menu, 0, -0.5f, GetTeleportToMeBtnText, delegate
			//{
			//    Tweaker_Object.GetGameObjectToEdit().TeleportToMe();
			//}, GetTeleportToMeBtnText);
			// TeleportToMePickup.SetResizeTextForBestFit(true);

			// TeleportToTargetPickup = new QMSingleButton(menu, 0, 0.5f, GetTeleportToTargetText, delegate
			// {
			//     Tweaker_Object.GetGameObjectToEdit().TeleportToTarget();
			// }, GetTeleportToTargetText);
			// TeleportToTargetPickup.SetResizeTextForBestFit(true);
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
	}
}