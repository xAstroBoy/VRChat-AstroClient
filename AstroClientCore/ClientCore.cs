namespace AstroClientCore
{
	#region Imports

	using AstroClientCore.ConsoleUtils;
	using AstroClientCore.Managers;
	using MelonLoader;

	#endregion

	public class ClientCore : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.Log("Welcome to AstroClient");

			ModuleManager.LoadModules();
		}
	}
}