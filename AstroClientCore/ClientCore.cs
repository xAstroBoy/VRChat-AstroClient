namespace AstroClientCore
{
	#region Imports

	using AstroClientCore.ConsoleUtils;
	using AstroClientCore.Managers;
	using AstroClientCore.Variables;
	using MelonLoader;

	#endregion

	public class ClientCore : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.Log($"Welcome to AstroClient, {GlobalVariables.Version}");

			ModuleManager.LoadModules();
		}

		public override void OnUpdate()
		{
			ModuleManager.Update();
		}

		public override void OnLateUpdate()
		{
			ModuleManager.LateUpdate();
		}

		public override void VRChat_OnUiManagerInit()
		{
			ModuleManager.VRChat_OnUiManagerInit();
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