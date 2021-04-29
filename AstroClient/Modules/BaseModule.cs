namespace AstroClient.Modules
{
	using AstroClient.ConsoleUtils;

	public class BaseModule
	{
		public BaseModule()
		{
			ModConsole.DebugLog($"Module {GetType()} Loaded!");
		}
	}
}
