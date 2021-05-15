namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using Harmony;
	using System;
	using System.Reflection;
	using VRC;
	using VRC.SDKBase;

	#endregion

	public class RPCEventHook : GameEvents
	{
		public static event EventHandler<UdonSyncRPCEventArgs> Event_OnUdonSyncRPC;

		//public static
		private HarmonyInstance harmony1;

		private HarmonyInstance harmony2;

		public override void ExecutePriorityPatches()
		{
			MiscUtility.DelayFunction(1f, new Action(() =>
			{
				HookRPCEvent1();
			}));
		}

		public void HookRPCEvent1()
		{
			try
			{
				if (harmony1 == null)
				{
					harmony1 = HarmonyInstance.Create(BuildInfo.Name + " RPCEventHook1");
				}

				harmony1.Patch(AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), new HarmonyMethod(typeof(RPCEventHook).GetMethod(nameof(OnRPCEvent1), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
				ModConsole.DebugLog("Hooked VRC_EventDispatcherRFC 1");
			}
			catch
			{
				harmony1.UnpatchAll();
				HookRPCEvent1();
			}
		}


		private static bool OnRPCEvent1(Player __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
		{
			string actionstring = string.Empty;
			string actiontext = string.Empty;
			string GameObjName = string.Empty;
			string name = string.Empty;
			string parameter = string.Empty;
			string eventtype = string.Empty;
			string broadcasttype = string.Empty;
			string sender = string.Empty;

			try
			{
				if (__1.ParameterBytes != null && __1.ParameterBytes.Count != 0)
				{
					actionstring = System.Text.Encoding.UTF8.GetString(__1.ParameterBytes);
					actiontext = actionstring.Length >= 6 ? actionstring.Substring(6) : "Unknown Event";
				}
				else
				{
					actiontext = "null";
				}
			}
			catch
			{
				return true;
			}

			name = __1.ParameterObject != null ? __1.ParameterObject.name : "null";
			parameter = __1.ParameterString != null ? __1.ParameterString : "null";
			eventtype = __1.EventType != null ? __1.EventType.ToString() : "null";
			broadcasttype = __2 != null ? __2.ToString() : "Null";

			bool log = ConfigManager.General.LogRPCEvents;

			if (name.Equals("USpeak"))
			{
				log = false;
			}

			//if (name.Equals("SceneEventHandlerAndInstantiator"))
			//{
			//	log = true;
			//}

			GameObjName = __1.ParameterObject != null ? __1.ParameterObject.name : "null";

			if (__0 != null)
			{
				sender = __0.GetAPIUser() != null ? __0.GetAPIUser().displayName : "null";
			}
			else
			{
				sender = "null";
			}

			if (parameter.Equals("UdonSyncRunProgramAsRPC"))
			{
				Event_OnUdonSyncRPC?.Invoke(null, new UdonSyncRPCEventArgs(__0, __1.ParameterObject, actiontext));
				if (ConfigManager.General.LogUdonEvents)
				{
					ModConsole.Log($"Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
				}
				return true;
			}

			if (log)
			{
				if (parameter != "UdonSyncRunProgramAsRPC")
				{
					ModConsole.Log($"RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}");
				}
			}

			return true;
		}


	}
}