namespace AstroClientCore
{
	#region Imports

	using AstroClientCore.Managers;
	using AstroClientCore.Variables;
	using AstroLibrary.Console;
	using MelonLoader;
	using System;

	#endregion

	public class ClientCore : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.ModName = "AstroClient";
			ModConsole.Log($"Welcome to AstroClient, {GlobalVariables.Version}");

			ModuleManager.LoadModules();
			EventManager.ApplicationStart?.Invoke(null, new EventArgs());
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