using AstroClient.components;
using AstroClient.variables;
using UnhollowerRuntimeLib;

namespace AstroClient.Startup
{
    public class ComponentHelper : Overridables
    {
        public override void OnApplicationStart()
        {
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

            ClassInjector.RegisterTypeInIl2Cpp<VRChatESP>();

            ClassInjector.RegisterTypeInIl2Cpp<SingleTag>();

            ClassInjector.RegisterTypeInIl2Cpp<JarRoleESP>();

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
        }

        public override void OnUpdate()
        {
            DamnItMeap.MakeInstance();
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