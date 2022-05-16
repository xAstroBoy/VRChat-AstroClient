
namespace AstroClient.ClientUI.ActionMenu
{
    using Gompoc.ActionMenuAPI.Api;
    using System.Drawing;
    using AstroMonos;
    using AstroMonos.Components.Malicious.Orbit;
    using ClientActions;
    using Menu.ItemTweakerV2.Selector;
    using Constants;
    using AstroClient.Tools.Extensions;

    internal class ComponentsModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Component Menu", () =>
            {
                if (Bools.AllowAttackerComponent)
                {

                    CustomSubMenu.AddSubMenu("Attacker Component", () =>
                    {
                        CustomSubMenu.AddButton("Make Held object attack Target (No Collisions)", () =>
                        {
                            Tweaker_Object.GetGameObjectToEdit().AttackTarget(true); 
                        }, null, false);
                        CustomSubMenu.AddButton("Make Held object attack Target", () =>
                        {
                            Tweaker_Object.GetGameObjectToEdit().AttackTarget();
                        }, null, false);
                        CustomSubMenu.AddButton("Remove Attacker\ncomponent from\nobject", () =>
                        {
                            Tweaker_Object.GetGameObjectToEdit().Remove_PlayerAttacker_Component();
                        }, null, false);
                        CustomSubMenu.AddButton("Kill \nPlayers \n Attackers", () =>
                        {
                            ComponentsBtn.KillAttackers();
                        }, null, false);

                    });
                }
                if (Bools.AllowOrbitComponent)
                {

                    CustomSubMenu.AddSubMenu("Orbit Component", () =>
                    {
                        CustomSubMenu.AddButton("Make Held object Orbit around Target", () =>
                        {
                            Tweaker_Object.GetGameObjectToEdit().OrbitTarget();
                        }, null, false);
                        CustomSubMenu.AddButton("Remove Orbiting component", () =>
                        {
                            Tweaker_Object.GetGameObjectToEdit().Remove_Orbit_Component();
                        }, null, false);
                        CustomSubMenu.AddButton("Kill all Orbiting Objects", () =>
                        {
                            OrbitManager_Old.RemoveAllOrbitObjects();
                        }, null, false);

                    });
                }
                CustomSubMenu.AddSubMenu("Watcher Component", () =>
                {
                    CustomSubMenu.AddButton("Make Held object Watch Target", () =>
                    {
                        Tweaker_Object.GetGameObjectToEdit().WatchTarget();
                    }, null, false);
                    CustomSubMenu.AddButton("Remove Watcher\ncomponent from\nobject", () =>
                    {
                        Tweaker_Object.GetGameObjectToEdit().Remove_PlayerWatcher_Component();
                    }, null, false);
                    CustomSubMenu.AddButton("Kill \nPlayers \n Watchers", () =>
                    {
                        ComponentsBtn.KillWatchers();
                    }, null, false);

                });

            });

            Log.Write("Component Module is ready!", Color.Green);
        }
    }
}