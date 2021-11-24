namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components
{
    using Bouncer;
    using Crazy;
    using Fun;
    using Rocket;
    using Selector;
    using Spinner;
    using Tools.Extensions;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class ComponentSubMenu : Tweaker_Events
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

            _ = new QMSingleButton(main, "Remove All Components", () => { KillCustomComponents(); }, "Kill All Custom Add-ons.");
        }

        internal static void KillCustomComponents()
        {
            CrazyComponentSubMenu.KillCrazyObjects();
            RocketComponentSubMenu.KillAllRockets();
            SpinnerSubMenu.KillAllSpinners();
            ItemTweakerV2.Selector.Tweaker_Object.GetGameObjectToEdit().KillCustomComponents(false, false);
        }
    }
}