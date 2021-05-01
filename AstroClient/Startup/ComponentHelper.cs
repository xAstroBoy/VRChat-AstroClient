namespace AstroClient.Startup
{
	using AstroClient.components;
	using AstroClient.ConsoleUtils;
	using AstroClient.variables;
	using System;
	using UnhollowerRuntimeLib;

	public class ComponentHelper : GameEvents
	{
		public static void RegisterComponent<T>() where T : class
		{
			try
			{
				ClassInjector.RegisterTypeInIl2Cpp<T>();
				ModConsole.DebugLog($"Registered: {typeof(T).FullName}");
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

			RegisterComponent<Murder4PatronUnlocker>();

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

			RegisterComponent<CheetoMenu>();
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