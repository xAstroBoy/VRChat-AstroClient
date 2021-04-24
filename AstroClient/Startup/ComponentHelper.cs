using AstroClient.components;
using AstroClient.variables;
using UnhollowerRuntimeLib;

namespace AstroClient.Startup
{
    public class ComponentHelper : GameEvents
    {
        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<GameEventsBehaviour>();

            ClassInjector.RegisterTypeInIl2Cpp<RocketManager>();
            ClassInjector.RegisterTypeInIl2Cpp<RocketObject>();

            ClassInjector.RegisterTypeInIl2Cpp<ObjectSpinnerManager>();
            ClassInjector.RegisterTypeInIl2Cpp<ObjectSpinner>();

            ClassInjector.RegisterTypeInIl2Cpp<CrazyObjectManager>();
            ClassInjector.RegisterTypeInIl2Cpp<CrazyObject>();

            ClassInjector.RegisterTypeInIl2Cpp<RigidBodyController>();

            ClassInjector.RegisterTypeInIl2Cpp<ItemInflaterManager>();
            ClassInjector.RegisterTypeInIl2Cpp<ItemInflater>();

            ClassInjector.RegisterTypeInIl2Cpp<PickupController>();

            ClassInjector.RegisterTypeInIl2Cpp<SingleTag>();

            ClassInjector.RegisterTypeInIl2Cpp<JarRoleESP>();

            ClassInjector.RegisterTypeInIl2Cpp<ObjectESP>();

            ClassInjector.RegisterTypeInIl2Cpp<PlayerESP>();

            ClassInjector.RegisterTypeInIl2Cpp<Murder4PatronUnlocker>();

            if (Bools.AllowAttackerComponent)
            {
                ClassInjector.RegisterTypeInIl2Cpp<PlayerAttackerManager>();
                ClassInjector.RegisterTypeInIl2Cpp<PlayerAttacker>();
            }

            if (Bools.AllowOrbitComponent)
            {
                ClassInjector.RegisterTypeInIl2Cpp<OrbitManager>();
                ClassInjector.RegisterTypeInIl2Cpp<Orbit>();
            }
            ClassInjector.RegisterTypeInIl2Cpp<PlayerWatcherManager>();
            ClassInjector.RegisterTypeInIl2Cpp<PlayerWatcher>();
            ClassInjector.RegisterTypeInIl2Cpp<Astro_Interactable>();

            ClassInjector.RegisterTypeInIl2Cpp<CheetoMenu>();
        }

        public override void OnUpdate()
        {
            CheetoMenu.MakeInstance();
            RocketManager.MakeInstance();
            CrazyObjectManager.MakeInstance();
            ObjectSpinnerManager.MakeInstance();
            ItemInflaterManager.MakeInstance();
            if (Bools.AllowAttackerComponent)
            {
                PlayerAttackerManager.MakeInstance();
            }
            if (Bools.AllowOrbitComponent)
            {
                OrbitManager.MakeInstance();
            }
            PlayerWatcherManager.MakeInstance();
        }
    }
}