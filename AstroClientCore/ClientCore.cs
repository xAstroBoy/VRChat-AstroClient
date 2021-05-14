namespace AstroClientCore
{
	using AstroClientCore.ConsoleUtils;
	using MelonLoader;

	public class ClientCore : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.Log("Welcome to AstroClient");
		}
	}
}