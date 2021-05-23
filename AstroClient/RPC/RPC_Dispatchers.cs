namespace AstroClient.RPC
{
	using AstroLibrary.Finder;
	using UnityEngine;
	using VRC.SDKBase;

	public static class RPC_Dispatchers
	{
		public static GameObject _SceneEventHandlerAndInstantiator_GameObject;

		public static GameObject SceneEventHandlerAndInstantiator_GameObject
		{
			get
			{
				if (_SceneEventHandlerAndInstantiator_GameObject == null)
				{
					var obj = GameObjectFinder.Find("/SceneEventHandlerAndInstantiator");
					_SceneEventHandlerAndInstantiator_GameObject = obj;
					return _SceneEventHandlerAndInstantiator_GameObject;
				}
				else
				{
					return _SceneEventHandlerAndInstantiator_GameObject;
				}
			}
		}

		public static VRC_EventDispatcher _SceneEventHandlerAndInstantiator_Dispatcher;

		public static VRC_EventDispatcher SceneEventHandlerAndInstantiator_Dispatcher
		{
			get
			{
				if (_SceneEventHandlerAndInstantiator_Dispatcher == null)
				{
					_SceneEventHandlerAndInstantiator_Dispatcher = SceneEventHandlerAndInstantiator_GameObject.GetComponent<VRC_EventDispatcher>();
					return _SceneEventHandlerAndInstantiator_Dispatcher;
				}
				else
				{
					return _SceneEventHandlerAndInstantiator_Dispatcher;
				}
			}
		}

		public static GameObject _Dispatcher_GameObject;

		public static GameObject Dispatcher_GameObject
		{
			get
			{
				if (_Dispatcher_GameObject == null)
				{
					var obj = GameObjectFinder.Find("/VRC_OBJECTS/Dispatcher");
					_Dispatcher_GameObject = obj;
					return _Dispatcher_GameObject;
				}
				else
				{
					return _Dispatcher_GameObject;
				}
			}
		}

		public static VRC_EventDispatcher _Dispatcher;

		public static VRC_EventDispatcher Dispatcher
		{
			get
			{
				if (_Dispatcher == null)
				{
					_Dispatcher = Dispatcher_GameObject.GetComponent<VRC_EventDispatcher>();
					return _Dispatcher;
				}
				else
				{
					return _Dispatcher;
				}
			}
		}
	}
}