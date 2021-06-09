﻿namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using RubyButtonAPI;

	internal class VRC_TriggersScrollMenu
	{
		public static void Init_VRC_TriggersScrollMenu(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Interact Triggers", "Interact with Selected Pickup Triggers", null, null, null, null, btnHalf);
			var scroll = new QMScrollMenu(menu);
			scroll.SetAction(delegate
			{
				foreach (var trigger in Tweaker_Object.GetGameObjectToEdit().Get_Triggers())
				{
					scroll.Add(
					new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {trigger.name}", delegate
					{
						trigger.TriggerClick();
					}, $"Click {trigger.name}", null, trigger.Get_GameObject_Active_ToColor()));
				}
			});
		}
	}
}