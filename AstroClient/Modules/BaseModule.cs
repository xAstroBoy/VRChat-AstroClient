namespace AstroClient.Modules
{
	using AstroClient.ConsoleUtils;

	public class BaseModule : GameEvents
	{
		public BaseModule()
		{
			ModConsole.DebugLog($"Module {GetType()} Loaded!");
		}
	}
}