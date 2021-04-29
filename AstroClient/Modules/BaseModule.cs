namespace AstroClient.Modules
{
	using AstroClient.ConsoleUtils;

	public class BaseModule : GameEventsBehaviour
	{
		public BaseModule()
		{
			ModConsole.DebugLog($"Module {GetType()} Loaded!");
		}
	}
}
