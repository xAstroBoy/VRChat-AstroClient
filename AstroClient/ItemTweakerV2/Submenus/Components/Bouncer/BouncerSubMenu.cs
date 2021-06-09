﻿namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using RubyButtonAPI;
	using System;

	public class BouncerSubMenu : Tweaker_Events
	{
		public static void Init_BouncerMenu(QMNestedButton main, float x, float y, bool btnhalf)
		{
			var mainmenu = new QMNestedButton(main, x, y, "Bouncers", "Make Pickups Bouncy!", null, null, null, null, true);
			new QMSingleButton(mainmenu, 1, 0f, "Make It bouncy", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_Bouncer(); }), "Make It Bouncy!", null, null, true);
			new QMSingleButton(mainmenu, 1, 0.5f, "Make It bouncy toward player", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_Bouncer(true); }), "Make It bouncy toward player!", null, null, true).SetResizeTextForBestFit(true);
			new QMSingleButton(mainmenu, 1, 1f, "Remove Bouncy", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Bouncer(); }), "Kill the Bouncyness!!", null, null, true);
		}
	}
}