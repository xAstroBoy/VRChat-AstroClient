using AstroClient.components;
using AstroClient.variables;
using RubyButtonAPI;
using System;

namespace AstroClient.Components
{
    public static class ComponentsBtn
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var temp = new QMNestedButton(menu, x, y, "Component Menu", "Control Object Custom Components!", null, null, null, null, btnHalf);
            if (Bools.AllowAttackerComponent)
            {
                new QMSingleButton(temp, 1, 0, "Make Held object attack Target", new Action(() => { ObjectMiscOptions.MakeObjectAttackTarget(HandsUtils.GetGameObjectToEdit()); }), "Make Held object attack Target!", null, null);
                new QMSingleButton(temp, 2, 0, "Remove Attacker\ncomponent from\nobject", new Action(() => { ObjectMiscOptions.RemoveAttackerFromobj(HandsUtils.GetGameObjectToEdit()); }), "Remove Attacker\ncomponent from\nobject", null, null);
                new QMSingleButton(temp, 3, 0, "Kill \nPlayers \n Attackers", new Action(() => { PlayerAttackerManager.KillPlayerAttackers(); }), "Kill \nPlayers \n Attackers", null, null);

            }
            if (Bools.AllowOrbitComponent)
            {
                new QMSingleButton(temp, 1, 1, "Make Held object Orbit around Target", new Action(() => { ObjectMiscOptions.MakeHeldItemOrbitAroundTarget(HandsUtils.GetGameObjectToEdit()); }), "Make Held object Orbit around Target!", null, null);
                new QMSingleButton(temp, 2, 1, "Remove Orbiting component", new Action(() => { ObjectMiscOptions.RemoveOrbitingObject(HandsUtils.GetGameObjectToEdit()); }), "Remove Orbiting component!", null, null);
                new QMSingleButton(temp, 3, 1, "Kill all Orbiting Objects", new Action(() => { OrbitManager.RemoveAllOrbitObjects(); }), "Kill all Orbiting Objects!", null, null);
            }
            new QMSingleButton(temp, 1, 2, "Make Held object Watch Target", new Action(() => { ObjectMiscOptions.MakeObjectWatchTarget(HandsUtils.GetGameObjectToEdit()); }), "Make Held object Stare at Target!", null, null);
            new QMSingleButton(temp, 2, 2, "Remove Watcher\ncomponent from\nobject", new Action(() => { ObjectMiscOptions.RemoveWatcherFromobj(HandsUtils.GetGameObjectToEdit()); }), "Remove Watcher\ncomponent from\nobject", null, null);
            new QMSingleButton(temp, 3, 2, "Kill \nPlayers \n Watchers", new Action(() => { PlayerWatcherManager.KillPlayerWatchers(); }), "Kill \nPlayers \n Watchers", null, null);

        }
    }
}