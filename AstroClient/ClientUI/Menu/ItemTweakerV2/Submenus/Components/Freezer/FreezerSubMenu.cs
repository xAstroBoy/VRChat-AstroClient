namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Freezer
{
    using AstroMonos.Components.Tools;
    using Selector;
    using Tools.Extensions.Components_exts;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class FreezerSubMenu : Tweaker_Events
    {
        internal static void Init_FreezerMenu(QMNestedGridMenu menu)
        {
            var mainmenu = new QMNestedGridMenu(menu, "Freeze", "Freeze Pickups in a Location!");
            _ = new QMSingleButton(mainmenu, "Add Object Freezer", () => { Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<ObjectFreezer>(); }, "Make it Stay into a Location!");
            _ = new QMSingleButton(mainmenu, "Remove Object Freezer", () => { Tweaker_Object.GetGameObjectToEdit().Remove_ObjectFreezer(); }, "Kill the Object Freeze!!");
        }
    }
}