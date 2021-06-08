namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Handlers;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus;
	using AstroClient.ItemTweakerV2.Submenus.ScrollMenus;
	using AstroClient.variables;
	using AstroLibrary;
	using RubyButtonAPI;
	using System;
	using System.Reflection;
	using UnityEngine;
	using Color = UnityEngine.Color;

	public class ComponentSubMenu : Tweaker_Events
	{
		public static void Init_ComponentSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "Astro Components", "Custom Component Editor Menu!", null, null, null, null, btnHalf);
			RocketComponentSubMenu.Init_RocketComponentSubMenu(main, 1, 0, true);
			CrazyComponentSubMenu.Init_CrazyComponentSubMenu(main, 1, 0.5f, true);
			SpinnerSubMenu.Init_SpinnerSubMenu(main, 1, 1, true);
			BouncerSubMenu.Init_BouncerMenu(main, 1, 1.5f, true);



			new QMSingleButton(main, 4, 0f, "Remove All Components", () => { ComponentSubMenu.KillCustomComponents(); }, "Kill All Custom Add-ons.", null, null, true);

		}

		public static void KillCustomComponents()
		{
			CrazyObjectManager.KillCrazyObjects();
			RocketManager.KillRockets();
			ObjectSpinnerManager.KillObjectSpinners();
		}
	}
}