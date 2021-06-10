namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;

	public class CrazyComponentSubMenu : Tweaker_Events
    {
        public static void Init_CrazyComponentSubMenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var submenu = new QMNestedButton(menu, x, y, "Crazy Object", "Make Items fly in random directions lol!", null, null, null, null, btnHalf);
            new QMSingleButton(submenu, 1, 0, "Crazy Object (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithGravity(); }), "Make Held Object Go Nuts!", null, null);
            new QMSingleButton(submenu, 2, 0, "Crazy Object (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithoutGravity(); }), "Make Held Object Go Nuts!", null, null);
            new QMSingleButton(submenu, 3, 0, "Remove all Crazy Objects", new Action(CrazyObjectManager.KillCrazyObjects), "Removes all Rockets components from objects!", null, null);
            CrazyObjectManager.CrazyTimerBtn = new QMSingleButton(submenu, 4, 0, "none", null, "Tells CrazyObj Speed", null, null);
            new QMSingleButton(submenu, 1, 1, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncCrazySpeed(); }), "Edits the CrazyObj Speed", null, null);
            new QMSingleButton(submenu, 2, 1, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecCrazySpeed(); }), "Edits the CrazyObj Speed", null, null);
        }
    }
}