namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Bouncer
{
    using System;
    using Selector;
    using Tools.Extensions.Components_exts;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class FreezerSubMenu : Tweaker_Events
    {
        internal static void Init_FreezerMenu(QMNestedGridMenu menu)
        {
            var mainmenu = new QMNestedButton(menu, "Freeze", "Freeze Pickups in a Location!");
            _ = new QMSingleButton(mainmenu, 1, 0f, "Add Object Freezer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_ObjectFreezer(); }), "Make it Stay into a Location!", null, null, true);
            _ = new QMSingleButton(mainmenu, 1, 0.5f, "Remove Object Freezer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_ObjectFreezer(); }), "Kill the Object Freeze!!", null, null, true);
        }
    }
}