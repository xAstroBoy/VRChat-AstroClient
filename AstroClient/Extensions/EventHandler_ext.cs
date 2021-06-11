namespace AstroLibrary.Extensions
{
	using AstroClient;
	using AstroClient.ItemTweakerV2.TweakerEventArgs;
	using AstroClientCore.Events;
	using AstroLibrary.Console;
	using System;
	using System.Linq;
	#region Imports

	using UnityEngine;
	using VRC.SDKBase;

	#endregion Imports

	public static class Eventhandler_ext
    {

		public static void SafetyRaise(this EventHandler eh)
		{
			if (eh == null)
				return;


			foreach (var handler in eh.GetInvocationList())
			{
				try
				{
					handler.DynamicInvoke(null, null);
				}
				catch (Exception exc)
				{
					ModConsole.DebugError($"Error in the Handler : {handler.Method.Name}");
					ModConsole.ErrorExc(exc);
				}
			}
		}

		public static void SafetyRaise<T>(this EventHandler<T> eh, T e) where T : EventArgs
		{
			if (eh == null)
				return;


			foreach (var handler in eh.GetInvocationList())
			{
				try
				{
					handler.DynamicInvoke(null, e);
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