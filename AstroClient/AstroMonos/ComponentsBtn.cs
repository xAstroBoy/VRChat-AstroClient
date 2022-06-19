using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;

namespace AstroClient.AstroMonos
{
    using System;
    using Components.Custom.Random;
    using Components.Malicious;
    using Components.Malicious.Orbit;
    using Constants;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal static class ComponentsBtn
    {
        internal static void InitButtons(QMGridTab menu)
        {
            var temp = new QMNestedGridMenu(menu, "Component Menu", "Control Object Custom Components!");
            if (Bools.AllowAttackerComponent)
            {
                _ = new QMSingleButton(temp,  "Make Held object attack Target (No Collisions)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AttackTarget(true); }), "Make Held object attack Target!");
                _ = new QMSingleButton(temp, "Make Held object attack Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AttackTarget(); }), "Make Held object attack Target!");

                _ = new QMSingleButton(temp,  "Remove Attacker\ncomponent from\nobject", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_PlayerAttacker_Component(); ; }), "Remove Attacker\ncomponent from\nobject");
                _ = new QMSingleButton(temp,  "Kill \nPlayers \n Attackers", new Action(() => { KillAttackers(); }), "Kill \nPlayers \n Attackers");
            }
            if (Bools.AllowOrbitComponent)
            {
                _ = new QMSingleButton(temp, "Make Held object Orbit around Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().OrbitTarget(); }), "Make Held object Orbit around Target!");
                _ = new QMSingleButton(temp, "Remove Orbiting component", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Orbit_Component(); }), "Remove Orbiting component!");
                _ = new QMSingleButton(temp, "Kill all Orbiting Objects", new Action(() => { OrbitManager_Old.RemoveAllOrbitObjects(); }), "Kill all Orbiting Objects!");
            }
            _ = new QMSingleButton(temp, "Make Held object Watch Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().WatchTarget(); }), "Make Held object Stare at Target!");
            _ = new QMSingleButton(temp, "Remove Watcher\ncomponent from\nobject", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_PlayerWatcher_Component(); }), "Remove Watcher\ncomponent from\nobject");
            _ = new QMSingleButton(temp, "Kill \nPlayers \n Watchers", new Action(() => { KillWatchers(); }), "Kill \nPlayers \n Watchers");
        }

        internal static void KillAttackers()
        {
            UnhollowerBaseLib.Il2CppArrayBase<PlayerAttacker> list = Resources.FindObjectsOfTypeAll<PlayerAttacker>();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].DestroyMeLocal();
            }
        }

        internal static void KillWatchers()
        {
            UnhollowerBaseLib.Il2CppArrayBase<PlayerWatcher> list = Resources.FindObjectsOfTypeAll<PlayerWatcher>();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].DestroyMeLocal();
            }
        }
    }
}