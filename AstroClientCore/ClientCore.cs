namespace AstroClientCore
{
	#region Imports

	using AstroClientCore.Managers;
	using AstroClientCore.Variables;
	using AstroLibrary.Console;
	using MelonLoader;
	using System;
	using System.Linq;

	#endregion

	public class ClientCore : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.Initialize("AstroClientCore");
			ModConsole.Log($"Welcome to AstroClient, {GlobalVariables.Version}");

			ModuleManager.LoadModules();
			InitializeOverridables();
		}

		public static void InitializeOverridables()
		{
			foreach (var assembly in ModuleManager.Assemblies)
			{
				foreach (var type in assembly.GetTypes().Where(t => t.BaseType.Equals(typeof(GameEvents))))
				{
					GameEvents component = assembly.CreateInstance(type.ToString(), true) as GameEvents;
					component.OnApplicationStart();
					ModConsole.Log($"GameEvent Component Loaded: {type}");
				}
			}
		}

		public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			switch (buildIndex)
			{
				case 0: // app
				case 1: // ui
					break;

				default:
					EventManager.LevelLoaded?.Invoke(this, new EventArgs());
					break;
			}
		}

		public override void OnUpdate()
		{
			ModuleManager.Update();
			EventManager.Update?.Invoke(null, new EventArgs());
		}

		public override void OnLateUpdate()
		{
			ModuleManager.LateUpdate();
			EventManager.LateUpdate?.Invoke(null, new EventArgs());
		}

		public override void VRChat_OnUiManagerInit()
		{
			ModuleManager.VRChat_OnUiManagerInit();
			EventManager.UiManagerInit?.Invoke(null, new EventArgs());
		}

		public override void OnApplicationQuit()
		{
			ModuleManager.OnApplicationQuit();
			EventManager.ApplicationQuit?.Invoke(null, new EventArgs());
		}

		public override void OnGUI()
		{
			ModuleManager.OnGUI();
			EventManager.GUI?.Invoke(null, new EventArgs());
		}
	}
}