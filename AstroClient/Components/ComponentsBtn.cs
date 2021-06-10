namespace AstroClient.Components
{
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.variables;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;

	public static class ComponentsBtn
    {
        public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var temp = new QMNestedButton(menu, x, y, "Component Menu", "Control Object Custom Components!", null, null, null, null, btnHalf);
            if (Bools.AllowAttackerComponent)
            {
                new QMSingleButton(temp, 1, 0, "Make Held object attack Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AttackTarget(); }), "Make Held object attack Target!", null, null);
                new QMSingleButton(temp, 2, 0, "Remove Attacker\ncomponent from\nobject", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_PlayerAttacker_Component(); ; }), "Remove Attacker\ncomponent from\nobject", null, null);
                new QMSingleButton(temp, 3, 0, "Kill \nPlayers \n Attackers", new Action(() => { PlayerAttackerManager.KillPlayerAttackers(); }), "Kill \nPlayers \n Attackers", null, null);
            }
            if (Bools.AllowOrbitComponent)
            {
                new QMSingleButton(temp, 1, 1, "Make Held object Orbit around Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().OrbitTarget(); }), "Make Held object Orbit around Target!", null, null);
                new QMSingleButton(temp, 2, 1, "Remove Orbiting component", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Orbit_Component(); }), "Remove Orbiting component!", null, null);
                new QMSingleButton(temp, 3, 1, "Kill all Orbiting Objects", new Action(() => { OrbitManager.RemoveAllOrbitObjects(); }), "Kill all Orbiting Objects!", null, null);
            }
            new QMSingleButton(temp, 1, 2, "Make Held object Watch Target", new Action(() => { Tweaker_Object.GetGameObjectToEdit().WatchTarget(); }), "Make Held object Stare at Target!", null, null);
            new QMSingleButton(temp, 2, 2, "Remove Watcher\ncomponent from\nobject", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_PlayerWatcher_Component(); }), "Remove Watcher\ncomponent from\nobject", null, null);
            new QMSingleButton(temp, 3, 2, "Kill \nPlayers \n Watchers", new Action(() => { PlayerWatcherManager.KillPlayerWatchers(); }), "Kill \nPlayers \n Watchers", null, null);
        }
    }
}