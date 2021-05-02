namespace AstroClient.Cheetos
{
	using AstroClient.ConsoleUtils;
	using System;
	using System.Diagnostics;

	internal class Priority
	{
		public static ProcessPriorityClass CurrentPriority
		{
			get
			{
				return Process.GetCurrentProcess().PriorityClass;
			}
			set
			{
				SetPriority(value);
			}
		}

		private static void SetPriority(ProcessPriorityClass priority)
		{
			try
			{
				using (Process process = Process.GetCurrentProcess())
				{
					process.PriorityClass = priority;
					ModConsole.Log($"Process priority: {priority}");
				}
			}
			catch (Exception e)
			{
				ModConsole.Error($"Failed to set process priority: {e.Message}");
			}
		}
	}
}
