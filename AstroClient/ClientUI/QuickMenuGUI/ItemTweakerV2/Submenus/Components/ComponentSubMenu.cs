namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components
{
    using System.Drawing;
    using AstroMonos.Components.Tools;
    using Bouncer;
    using Crazy;
    using Freezer;
    using Fun;
    using Rocket;
    using Selector;
    using Spinner;
    using Tools.Extensions;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

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
            new QMSingleButton(main, "Reveal Current Object Keycode ", () => { Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<KeypadRevealer>(); }, "(works only with keycodes Objects.)");

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