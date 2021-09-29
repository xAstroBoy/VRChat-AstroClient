namespace AstroClient.RPC
{
	using AstroLibrary.Finder;
	using UnityEngine;
	using VRC.SDKBase;

	internal static class RPC_Events
	{
		internal static GameObject _InstantiateObject_GameObject;

		internal static GameObject InstantiateObject_GameObject
		{
			get
			{
				if (_InstantiateObject_GameObject == null)
				{
					var obj = GameObjectFinder.Find("/SceneEventHandlerAndInstantiator");
					_InstantiateObject_GameObject = obj;
					return _InstantiateObject_GameObject;
				}
				else
				{
					return _InstantiateObject_GameObject;
				}
			}
		}

		internal static VRC_EventDispatcher _InstantiateObject_Event;
		

//		private static void SearchForEvent(VRC_EventDispatcher entry , string eventname)
//		{
//foreach(var item in entry.)
//		}
//		internal static VRC_EventHandler.VrcEvent InstantiateObject_Event
//		{
//			get
//			{
//				if (_InstantiateObject_Event == null)
//				{
//					_InstantiateObject_Event = 
//					return _InstantiateObject_Event;
//				}
//				else
//				{
//					return _InstantiateObject_Event;
//				}
//			}
//		}

	}
}