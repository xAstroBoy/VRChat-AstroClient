namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.variables;
	using AstroLibrary;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using UnityEngine;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRC.Udon.Common.Interfaces;
	using Color = UnityEngine.Color;
	class VRC_TriggersScrollMenu
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
