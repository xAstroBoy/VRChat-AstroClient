namespace AstroClient.Modules
{
	using AstroClient.ConsoleUtils;
	using System;

	public class BaseModule : GameEventsBehaviour
	{
		public BaseModule(IntPtr obj0) : base(obj0)
		{
			ModConsole.DebugLog($"Module {GetType()} Loaded!");
		}
	}
}
