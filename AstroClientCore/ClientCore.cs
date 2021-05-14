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
	}
}