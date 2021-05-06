namespace AstroClient
{
	using AstroClient.ConsoleUtils;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using Harmony;
	using Mono.CSharp;
	using System;
	using System.Reflection;
	using VRC;
	using VRC.SDKBase;

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
				ModConsole.Log("Hooked VRC_EventDispatcherRFC 1");
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

			if (__1.ParameterBytes != null && __1.ParameterBytes.Count != 0)
			{
				actionstring = System.Text.Encoding.UTF8.GetString(__1.ParameterBytes);
				if (actionstring.Length >= 6)
				{
					actiontext = actionstring.Substring(6);
				}
				else
				{
					actiontext = "Unknown Event";
				}
			}
			else
			{
				actiontext = "null";
			}

			if (__1.ParameterObject != null)
			{
				name = __1.ParameterObject.name;
			}
			else
			{
				name = "null";
			}

			if (__1.ParameterString != null)
			{
				parameter = __1.ParameterString;
			}
			else
			{
				parameter = "null";
			}

			if (__1.EventType != null)
			{
				eventtype = __1.EventType.ToString();
			}
			else
			{
				eventtype = "null";
			}

			if (__2 != null)
			{
				broadcasttype = __2.ToString();
			}
			else
			{
				broadcasttype = "Null";
			}
			bool log = ConfigManager.General.LogRPCEvents;

			if (name.Equals("USpeak"))
			{
				log = false;
			}

			//if (name.Equals("SceneEventHandlerAndInstantiator"))
			//{
			//	log = true;
			//}

			if (__1.ParameterObject != null)
			{
				GameObjName = __1.ParameterObject.name;
			}
			else
			{
				GameObjName = "null";
			}
			if(__0 != null)
			{
				if(__0.GetAPIUser() != null)
				{
					sender = __0.GetAPIUser().displayName;
				}
				else
				{
					sender = "null";
				}
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
					ModConsole.DebugLog($"Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
				}
				return true;
			}

			if (log)
			{
				if (parameter != "UdonSyncRunProgramAsRPC")
				{
					ModConsole.DebugLog($"RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}");
				}
			}

			return true;
		}

		
	}
}