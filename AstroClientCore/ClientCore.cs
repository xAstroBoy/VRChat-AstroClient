namespace AstroClientCore
{
	#region Imports

	using AstroClientCore.Managers;
	using AstroClientCore.Variables;
	using AstroLibrary.Console;
	using MelonLoader;

	#endregion

	public class ClientCore : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.ModName = "AstroClient";
			ModConsole.Log($"Welcome to AstroClient, {GlobalVariables.Version}");

			ModuleManager.LoadModules();
		}

		public override void OnUpdate()
		{
			ModuleManager.Update();
			EventManager.Update?.Invoke(null, new System.EventArgs());
		}

		public override void OnLateUpdate()
		{
			ModuleManager.LateUpdate();
			EventManager.LateUpdate?.Invoke(null, new System.EventArgs());
		}

		public override void VRChat_OnUiManagerInit()
		{
			ModuleManager.VRChat_OnUiManagerInit();
			EventManager.VRChat_OnUiManagerInit?.Invoke(null, new System.EventArgs());
		}

		public override void OnApplicationQuit()
		{
			ModuleManager.OnApplicationQuit();
		}

		public override void OnGUI()
		{
			ModuleManager.OnGUI();
		}
	}
}