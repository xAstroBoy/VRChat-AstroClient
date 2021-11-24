namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Bouncer
{
    using System;
    using Selector;
    using Tools.Extensions.Components_exts;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class FreezerSubMenu : Tweaker_Events
    {
        internal static void Init_FreezerMenu(QMNestedButton main, float x, float y, bool btnhalf)
        {
            var mainmenu = new QMNestedButton(main, x, y, "Freeze", "Freeze Pickups in a Location!", null, null, null, null, true);
            _ = new QMSingleButton(mainmenu, 1, 0f, "Add Object Freezer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_Bouncer(); }), "Make it Stay into a Location!", null, null, true);
            _ = new QMSingleButton(mainmenu, 1, 1f, "Remove Object Freezer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Bouncer(); }), "Kill the Object Freeze!!", null, null, true);
        }
    }
}