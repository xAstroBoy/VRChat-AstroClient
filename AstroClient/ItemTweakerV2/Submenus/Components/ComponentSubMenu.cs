namespace AstroClient.ItemTweakerV2.Submenus
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using Selector;

    internal class ComponentSubMenu : Tweaker_Events
    {
        internal static void Init_ComponentSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "Astro Components", "Custom Component Editor Menu!", null, null, null, null, btnHalf);
            RocketComponentSubMenu.Init_RocketComponentSubMenu(main, 1, 0, true);
            CrazyComponentSubMenu.Init_CrazyComponentSubMenu(main, 1, 0.5f, true);
            SpinnerSubMenu.Init_SpinnerSubMenu(main, 1, 1, true);
            BouncerSubMenu.Init_BouncerMenu(main, 1, 1.5f, true);
            FunBehavioursSubMenu.Init_FunMenu(main, 1, 2, true);

            _ = new QMSingleButton(main, 4, 0f, "Remove All Components", () => { ComponentSubMenu.KillCustomComponents(); }, "Kill All Custom Add-ons.", null, null, true);

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