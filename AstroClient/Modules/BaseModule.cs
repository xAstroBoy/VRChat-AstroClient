namespace AstroClient.Modules
{
	using AstroClient.ConsoleUtils;
	using System;

	public class BaseModule
	{
		public BaseModule()
		{
			ModConsole.DebugLog($"Module {GetType()} Loaded!");
		}
	}
}
