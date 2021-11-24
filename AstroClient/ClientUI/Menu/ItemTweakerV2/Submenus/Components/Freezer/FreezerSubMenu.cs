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
            var mainmenu = new QMNestedGridMenu(menu, "Freeze", "Freeze Pickups in a Location!");
            _ = new QMSingleButton(mainmenu, "Add Object Freezer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_ObjectFreezer(); }), "Make it Stay into a Location!");
            _ = new QMSingleButton(mainmenu, "Remove Object Freezer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_ObjectFreezer(); }), "Kill the Object Freeze!!");
        }
    }
}