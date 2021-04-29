namespace AstroClient.Startup.Hooks
{
	using AstroClient.ConsoleUtils;
	using Harmony;
	using System;
	using System.Reflection;
	using UnhollowerRuntimeLib.XrefScans;
	using VRC_EventHandler = VRC.SDKBase.VRC_EventHandler;

	public class TriggerEventHook : GameEvents
	{
		private HarmonyInstance harmony;

		public static event EventHandler<VRC_EventDispatcherRFC_TriggerEventArgs> Event_VRC_EventDispatcherRFC_triggerEvent;

		public override void ExecutePriorityPatches()
		{
			HookTriggerEvent();
		}

		private void HookTriggerEvent()
		{
			if (harmony == null)
			{
				harmony = HarmonyInstance.Create(BuildInfo.Name + " TriggerEventHook");
			}
			ModConsole.Log("Hooking TriggerEvent");
			var xrefs = XrefScanner.XrefScan(typeof(VRC_EventDispatcherRFC).GetMethod(nameof(VRC_EventDispatcherRFC.TriggerEvent)));
			foreach (var x in xrefs)
			{
				if (x.Type == XrefType.Method && x.TryResolve() != null && x.TryResolve().DeclaringType == typeof(VRC_EventDispatcherRFC))
				{
					var methodToPatch = (MethodInfo)x.TryResolve();
					harmony.Patch(methodToPatch, new HarmonyMethod(typeof(TriggerEventHook).GetMethod(nameof(TriggerEventHookEvent), BindingFlags.Public | BindingFlags.Static)));
					break;
				}
			}
		}

		public static bool TriggerEventHookEvent(VRC_EventHandler __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
		{
			try
			{
				if (ConfigManager.General.LogTriggerEvents)
				{
					string eventhandler = string.Empty;
					string vrcevent = string.Empty;
					if (__0 != null)
					{
						eventhandler = __0.ToString();
					}
					else
					{
						eventhandler = "null";
					}

					if (__1.ParameterObject != null)
					{
						vrcevent = __1.ParameterObject.name;
					}
					else
					{
						vrcevent = "null";
					}

					ModConsole.DebugLog($"Event : VRC_EventHandler : {eventhandler}, VrcEvent : {vrcevent}, VrcBroadcastType : {__2}, UnknownInt : {__3}, UnknownFloat : {__4}");
				}

				Event_VRC_EventDispatcherRFC_triggerEvent?.Invoke(null, new VRC_EventDispatcherRFC_TriggerEventArgs(__0, __1, __2, __3, __4));
				return true;
			}
			catch { }
			{
				return true;
			}
		}
	}
}