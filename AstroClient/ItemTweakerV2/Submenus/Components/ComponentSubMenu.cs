﻿namespace AstroClient.ItemTweakerV2.Submenus
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using RubyButtonAPI;

    internal class ComponentSubMenu : Tweaker_Events
    {
        internal static void Init_ComponentSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "Astro Components", "Custom Component Editor Menu!", null, null, null, null, btnHalf);
            RocketComponentSubMenu.Init_RocketComponentSubMenu(main, 1, 0, true);
            CrazyComponentSubMenu.Init_CrazyComponentSubMenu(main, 1, 0.5f, true);
            SpinnerSubMenu.Init_SpinnerSubMenu(main, 1, 1, true);
            BouncerSubMenu.Init_BouncerMenu(main, 1, 1.5f, true);

            _ = new QMSingleButton(main, 4, 0f, "Remove All Components", () => { ComponentSubMenu.KillCustomComponents(); }, "Kill All Custom Add-ons.", null, null, true);
        }

        internal static void KillCustomComponents()
        {
            CrazyObjectManager.KillCrazyObjects();
            RocketManager.KillRockets();
            ObjectSpinnerManager.KillObjectSpinners();
            ItemTweakerV2.Selector.Tweaker_Object.GetGameObjectToEdit().KillCustomComponents(false, false);
        }
    }
}