namespace AstroClient
{
	using AstroLibrary.Console;
	using System.Linq;
	using UnityEngine;
	using VRC.Udon;
	using static AstroClient.variables.CustomLists;

	public static class UdonSearch
	{
		public static CachedUdonEvent FindUdonEvent(string action, string subaction)
		{
			var gameobjects = WorldUtils.Get_UdonBehaviours();

			var behaviour = gameobjects.Where(x => x.gameObject.name == action).DefaultIfEmpty(null).First();
			if (behaviour != null)
			{
				if (behaviour._eventTable.count != 0)
				{
					ModConsole.DebugLog($"Found Behaviour {behaviour.gameObject.name}, Searching for Action.");
					foreach (var actionkeys in behaviour._eventTable)
					{
						if (actionkeys.key == subaction)
						{
							ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {behaviour.gameObject.name}");
							return new CachedUdonEvent(behaviour, actionkeys.key);
						}
					}
				}
			}

			return null;
		}

		public static CachedUdonEvent FindUdonEvent(UdonBehaviour obj, string subaction)
		{
			if (obj != null)
			{
				if (obj._eventTable.count != 0)
				{
					foreach (var actionkeys in obj._eventTable)
					{
						if (actionkeys.key == subaction)
						{
							ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {obj.gameObject.name}");
							return new CachedUdonEvent(obj, actionkeys.key);
						}
					}
				}

			}
			return null;
		}



			public static CachedUdonEvent FindUdonEvent(GameObject obj, string subaction)
		{
			var actionObjects = obj.GetComponentsInChildren<UdonBehaviour>(true);

			foreach (var actionobject in actionObjects)
			{
				if (actionobject != null)
				{
					foreach (var actionkeys in actionobject._eventTable)
					{
						if (actionkeys.key == subaction)
						{
							ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {actionobject.gameObject.name}");
							return new CachedUdonEvent(actionobject, actionkeys.key);
						}
					}
				}
			}

			return null;
		}
	}
}