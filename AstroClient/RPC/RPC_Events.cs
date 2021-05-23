namespace AstroClient.RPC
{
	using AstroLibrary.Finder;
	using UnityEngine;
	using VRC.SDKBase;

	public static class RPC_Events
	{
		public static GameObject _InstantiateObject_GameObject;

		public static GameObject InstantiateObject_GameObject
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

		public static VRC_EventDispatcher _InstantiateObject_Event;
		

//		private static void SearchForEvent(VRC_EventDispatcher entry , string eventname)
//		{
//foreach(var item in entry.)
//		}
//		public static VRC_EventHandler.VrcEvent InstantiateObject_Event
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