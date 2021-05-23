namespace AstroClient.RPC
{
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using VRC.SDKBase;

	public static class RPC_Experiments
	{
		
		public static VRC_EventDispatcher GetRandomVRC_EventDispatcher()
		{
			var list = Resources.FindObjectsOfTypeAll<VRC_EventDispatcher>();
			foreach (var item in list)
			{
				if (item.isActiveAndEnabled && item.gameObject.active)
				{
					return item;
				}
			}
			return null;
		}

		private static VRC_EventHandler _CurrentEventHandler;

		public static VRC_EventHandler CurrentVRC_EventHandler
		{
			get
			{
				if (_CurrentEventHandler != null)
				{
					ModConsole.Log($"Current VRC_EventHandler {_CurrentEventHandler.name}, Path : {GameObjectFinder.GetGameObjectPath(_CurrentEventHandler.gameObject)}");
				}
				if (_CurrentEventHandler == null)
				{
					var eventhandler = GetRandomVRC_EventHandler();
					_CurrentEventHandler = eventhandler;
					return eventhandler;
				}
				else if (!_CurrentEventHandler.isActiveAndEnabled)
				{
					var eventhandler = GetRandomVRC_EventHandler();
					_CurrentEventHandler = eventhandler;
					return eventhandler;
				}
				else
				{
					return _CurrentEventHandler;
				}
			}
		}
		public static VRC_EventHandler GetRandomVRC_EventHandler()
		{
			var List = Resources.FindObjectsOfTypeAll<VRC_EventHandler>();
			foreach (var item in List)
			{
				ModConsole.DebugLog($"Found VRC_EventHandler {item.name}, Current Path is : {GameObjectFinder.GetGameObjectPath(item.gameObject)}");
			}
			foreach (var item in List)
			{
				if (item.isActiveAndEnabled && item.gameObject.active)
				{
					return item;
				}
			}
			return null;
		}




		public static void SetActiveGameObjectRPC(GameObject obj)
		{
			if (RPC_Dispatchers.SceneEventHandlerAndInstantiator_Dispatcher != null && CurrentVRC_EventHandler)
			{
				ModConsole.DebugLog($"sending SetGameObjectActive RPC Globally With Existing VRC_EventHandler.");
				ModConsole.DebugLog("Sent SpawnObject RPC.");
				RPC_Dispatchers.SceneEventHandlerAndInstantiator_Dispatcher.TriggerEvent(CurrentVRC_EventHandler,
					new VRC_EventHandler.VrcEvent
					{
						Name = "SetGameObjectActive",
						EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive,
						ParameterInt = 3,
						ParameterString = "SetGameObjectActive",
						ParameterObjects = new GameObject[] { obj },
					},
					VRC_EventHandler.VrcBroadcastType.Always,
					0,
					1);
			}
		}

		//public static void GenerateInstantiateObject(GameObject obj)
		//{
		//	foreach(var action in RPC_Dispatchers.SceneEventHandlerAndInstantiator_Dispatcher.)
		//}

		public static void SendSpawnobject(GameObject obj)
		{
			if (RPC_Dispatchers.SceneEventHandlerAndInstantiator_Dispatcher != null && CurrentVRC_EventHandler)
			{
				ModConsole.DebugLog($"sending SpawnObject RPC Globally With Existing VRC_EventHandler.");
				ModConsole.DebugLog("Sent SpawnObject RPC.");
				RPC_Dispatchers.SceneEventHandlerAndInstantiator_Dispatcher.TriggerEvent(CurrentVRC_EventHandler,
					new VRC_EventHandler.VrcEvent
					{
						Name = "SpawnObject",
						EventType = VRC_EventHandler.VrcEventType.SendRPC,
						ParameterInt = 3,
						ParameterString = "SpawnObject",
						ParameterObjects = new GameObject[] { obj },
					},
					VRC_EventHandler.VrcBroadcastType.Always,
					0,
					1);
			}
		}
	}
}
			

			
		
	

