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
	class VRC_InteractableScrollMenu
	{
		public static void Init_VRC_InteractableScrollMenu(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Internal VRC_Interactable ", "Interact with Internal VRC_Interactable Triggers", null, null, null, null, btnHalf);
			menu.GetMainButton().SetResizeTextForBestFit(true);
			var scroll = new QMScrollMenu(menu);
			new QMSingleButton(menu, 0, -1, "Refresh", delegate
			{
				scroll.Refresh();
			}, "", null, null, true);
			scroll.SetAction(delegate
			{
				foreach (var obj in Tweaker_Object.GetGameObjectToEdit().Get_VRCInteractables())
				{
					scroll.Add(
					new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {obj.name}", delegate
					{
						obj.VRC_Interactable_Click();
					}, $"Click {obj.name}", null, obj.Get_GameObject_Active_ToColor()));
				}
			});
		}
	}
}
