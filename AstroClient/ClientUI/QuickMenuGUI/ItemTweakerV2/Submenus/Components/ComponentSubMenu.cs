using System.Drawing;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components.Bouncer;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components.Crazy;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components.Freezer;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components.Fun;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components.Rocket;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components.Spinner;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components
{
    internal class ComponentSubMenu 
    {
        internal static void Init_ComponentSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedGridMenu(menu, x, y, "Astro Components", "Custom Component Editor Menu!", null, null, null, null, btnHalf);
            RocketComponentSubMenu.Init_RocketComponentSubMenu(main);
            CrazyComponentSubMenu.Init_CrazyComponentSubMenu(main);
            SpinnerSubMenu.Init_SpinnerSubMenu(main);
            BouncerSubMenu.Init_BouncerMenu(main);
            FunBehavioursSubMenu.Init_FunMenu(main);
            FreezerSubMenu.Init_FreezerMenu(main);
            new QMSingleButton(main, "Reveal Current Object Keycode ", () => { ComponentUtils.GetOrAddComponent<KeypadRevealer>(Tweaker_Object.GetGameObjectToEdit()); }, "(works only with keycodes Objects.)");

            _ = new QMSingleButton(main, "Remove All Components", () => { KillCustomComponents(); }, "Kill All Custom Add-ons.", Color.Red);
        }

        internal static void KillCustomComponents()
        {
            CrazyComponentSubMenu.KillCrazyObjects();
            RocketComponentSubMenu.KillAllRockets();
            SpinnerSubMenu.KillAllSpinners();
            Tweaker_Object.GetGameObjectToEdit().KillCustomComponents();
        }
    }
}