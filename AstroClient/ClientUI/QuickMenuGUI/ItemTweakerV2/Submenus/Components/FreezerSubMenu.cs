using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components
{
    internal class FreezerSubMenu 
    {
        internal static void Init_FreezerMenu(QMNestedGridMenu menu)
        {
            var mainmenu = new QMNestedGridMenu(menu, "Freeze", "Freeze Pickups in a Location!");
            _ = new QMSingleButton(mainmenu, "Add Object Freezer", () => { ComponentUtils.GetOrAddComponent<ObjectFreezer>(Tweaker_Object.GetGameObjectToEdit()); }, "Make it Stay into a Location!");
            _ = new QMSingleButton(mainmenu, "Remove Object Freezer", () => { Tweaker_Object.GetGameObjectToEdit().Remove_ObjectFreezer(); }, "Kill the Object Freeze!!");
        }
    }
}