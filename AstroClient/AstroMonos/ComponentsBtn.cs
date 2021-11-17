namespace AstroClient.AstroMonos
{
    using System;
    using ClientUI.Menu.ItemTweakerV2.Selector;
    using Components.Custom.Random;
    using Components.Malicious;
    using Components.Malicious.Orbit;
    using Constants;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;

    internal static class ComponentsBtn
    {
        internal static void InitButtons(QMGridTab menu)
        {
            var temp = new QMNestedGridMenu(menu, "Component Menu", "Control Object Custom Components!");
            if (Bools.AllowAttackerComponent)
            {
                _ = new QMSingleButton(temp, 1, 0, "Make Held object attack Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AttackTarget(); }), "Make Held object attack Target!", null, null);
                _ = new QMSingleButton(temp, 2, 0, "Remove Attacker\ncomponent from\nobject", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_PlayerAttacker_Component(); ; }), "Remove Attacker\ncomponent from\nobject", null, null);
                _ = new QMSingleButton(temp, 3, 0, "Kill \nPlayers \n Attackers", new Action(() => { KillAttackers(); }), "Kill \nPlayers \n Attackers", null, null);
            }
            if (Bools.AllowOrbitComponent)
            {
                _ = new QMSingleButton(temp, 1, 1, "Make Held object Orbit around Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().OrbitTarget(); }), "Make Held object Orbit around Target!", null, null);
                _ = new QMSingleButton(temp, 2, 1, "Remove Orbiting component", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Orbit_Component(); }), "Remove Orbiting component!", null, null);
                _ = new QMSingleButton(temp, 3, 1, "Kill all Orbiting Objects", new Action(() => { OrbitManager_Old.RemoveAllOrbitObjects(); }), "Kill all Orbiting Objects!", null, null);
            }
            _ = new QMSingleButton(temp, 1, 2, "Make Held object Watch Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().WatchTarget(); }), "Make Held object Stare at Target!", null, null);
            _ = new QMSingleButton(temp, 2, 2, "Remove Watcher\ncomponent from\nobject", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_PlayerWatcher_Component(); }), "Remove Watcher\ncomponent from\nobject", null, null);
            _ = new QMSingleButton(temp, 3, 2, "Kill \nPlayers \n Watchers", new Action(() => { KillWatchers(); }), "Kill \nPlayers \n Watchers", null, null);
        }

        internal static void KillAttackers()
        {
            foreach (var item in Resources.FindObjectsOfTypeAll<PlayerAttacker>())
            {
                item.DestroyMeLocal();
            }
        }

        internal static void KillWatchers()
        {
            foreach (var item in Resources.FindObjectsOfTypeAll<PlayerWatcher>())
            {
                item.DestroyMeLocal();
            }
        }
    }
}