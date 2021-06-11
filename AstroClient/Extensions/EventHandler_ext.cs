namespace AstroLibrary.Extensions
{
	using AstroClient;
	using AstroLibrary.Console;
	using System;
	using System.Linq;
	#region Imports

	using UnityEngine;
	using VRC.SDKBase;

	#endregion Imports

	public static class Eventhandler_ext
    {

		public static void SafetyRaise(this EventHandler eh, object sender, EventArgs e)
		{
			if (eh == null)
				return;


			foreach (EventHandler handler in eh.GetInvocationList())
			{
				try
				{
					handler(sender, e);
				}
				catch (Exception exc)
				{
					ModConsole.DebugError($"Error in the Handler : {handler.Method.Name}");
					ModConsole.ErrorExc(exc);
				}
			}
		}

		public static void SafetyRaise<T>(this EventHandler<T> eh, object sender, T e) where T : EventArgs
		{
			if (eh == null)
				return;


			foreach (EventHandler handler in eh.GetInvocationList())
			{
				try
				{
					handler(sender, e);
				}
				catch (Exception exc)
				{
					ModConsole.DebugError($"Error in the Handler : {handler.Method.Name}");
					ModConsole.ErrorExc(exc);
				}
			}
		}
	}
}