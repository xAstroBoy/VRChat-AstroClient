namespace AstroClient.extensions
{
	using AstroClient.components;
	using AstroClient.ConsoleUtils;
	using System.Collections.Generic;
	using UnityEngine;

	public static class EspExtensions
	{

		// TODO : REMOVE THIS
		// MAKE GAMEOBJECTESP OBSOLETE AND NOT NEEDED ANYMORE AND IS GOING TO BE DELETED!
		public static void RegisterMurderItemEsp(this GameObject obj)
		{
			if (obj != null)
			{
				if (obj != null)
				{
					if (!GameObjectESP.MurderESPItems.Contains(obj))
					{
						GameObjectESP.MurderESPItems.Add(obj);
					}
				}
			}
		}

		public static void RegisterMurderItemEsp(this List<GameObject> list)
		{
			foreach (var obj in list)
			{
				if (obj != null)
				{
					if (!GameObjectESP.MurderESPItems.Contains(obj))
					{
						GameObjectESP.MurderESPItems.Add(obj);
					}
				}
			}
		}
	}
}