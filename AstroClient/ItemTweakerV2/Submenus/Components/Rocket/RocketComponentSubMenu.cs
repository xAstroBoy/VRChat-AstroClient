namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using RubyButtonAPI;
	using System;

	public class RocketComponentSubMenu : Tweaker_Events
	{
		public static void Init_RocketComponentSubMenu(QMNestedButton menu, float x, float y, bool btnHalf)
		{
			var submenu = new QMNestedButton(menu, x, y, "Rocket Maker", "Turn Items Into Rockets, Be careful as they will explode on impact!", null, null, null, null, btnHalf);
			new QMSingleButton(submenu, 1, 0, "Rocket Object Direction (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithG(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 2, 0, "Rocket Object Direction (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutG(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 1, 1, "Rocket Always UP (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithGAndGoUp(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 2, 1, "Rocket Always UP (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutGAndGoUp(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 5, 0, "Remove all rockets", new Action(RocketManager.KillRockets), "Removes all Rockets components from objects!", null, null);
			RocketManager.RocketTimer = new QMSingleButton(submenu, 4, 0, "none", null, "Tells What's the Rocket Speed!", null, null);
			new QMSingleButton(submenu, 1, 2, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncRocketSpeed(); }), "Edits the Rocket Speed", null, null);
			new QMSingleButton(submenu, 2, 2, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecRocketSpeed(); }), "Edits the Rocket Speed", null, null);
		}
	}
}