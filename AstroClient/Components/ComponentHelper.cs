namespace AstroClient.Startup
{
	using AstroClient.Cheetos;
	using AstroClient.Components;
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using System;
	using System.Collections.Generic;
	using UnhollowerRuntimeLib;

	public class ComponentHelper : GameEvents
    {
        public static void RegisterComponent<T>() where T : class
        {
            try
            {
                ClassInjector.RegisterTypeInIl2Cpp<T>();
                ModConsole.DebugLog($"Registered: {typeof(T).FullName}");
                if (!RegisteredComponentsTypes.Contains(typeof(T)))
                {
                    RegisteredComponentsTypes.Add(typeof(T));
                }
            }
            catch (Exception e)
            {
                ModConsole.Error($"Failed to Register: {typeof(T).FullName}");
                ModConsole.ErrorExc(e);
            }
        }

        public override void OnApplicationStart()
        {
            RegisterComponent<GameEventsBehaviour>();
            RegisterComponent<MainThreadRunner>();

            RegisterComponent<RocketManager>();
            RegisterComponent<RocketObject>();

            RegisterComponent<ObjectSpinnerManager>();
            RegisterComponent<ObjectSpinner>();

            RegisterComponent<CrazyObjectManager>();
            RegisterComponent<CrazyObject>();

            RegisterComponent<RigidBodyController>();

            RegisterComponent<ItemInflaterManager>();
            RegisterComponent<ItemInflater>();

            RegisterComponent<PickupController>();

            RegisterComponent<SingleTag>();

            RegisterComponent<JarRoleESP>();

            RegisterComponent<ESP_Pickup>();
            RegisterComponent<ESP_Trigger>();
            RegisterComponent<ESP_ItemTweaker>();
            RegisterComponent<ESP_UdonBehaviour>();
            RegisterComponent<ESP_VRCInteractable>();

            RegisterComponent<PlayerESP>();

            //RegisterComponent<Murder4PatronUnlocker>();

            if (Bools.AllowAttackerComponent)
            {
                RegisterComponent<PlayerAttackerManager>();
                RegisterComponent<PlayerAttacker>();
            }

            if (Bools.AllowOrbitComponent)
            {
                RegisterComponent<OrbitManager>();
                RegisterComponent<Orbit>();
            }
            RegisterComponent<PlayerWatcherManager>();
            RegisterComponent<PlayerWatcher>();
            RegisterComponent<Astro_Interactable>();

            RegisterComponent<Bouncer>();
            RegisterComponent<Lewdifier>();
            RegisterComponent<MaskRemover>();

            RegisterComponent<TweakerListener>();
			RegisterComponent<ScrollMenuListener>();

			RegisterComponent<EmojiBypasser>();

		}

		public override void OnUpdate()
        {
            MainThreadRunner.MakeInstance();
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

        public static List<Type> RegisteredComponentsTypes { get; } = new List<Type>();
    }
}