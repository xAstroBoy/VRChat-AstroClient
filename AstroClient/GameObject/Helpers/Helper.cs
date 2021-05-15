namespace AstroClient
{
	using AstroLibrary.Console;
	using System.Collections.Generic;
	using UnityEngine;

	public class GameObjHelper
	{
		public static List<GameObject> _GameObjects;

		//Recursive
		public static void CheckTransform(Transform transform)
		{
			_GameObjects = new List<GameObject>();

			//MelonLoader.MelonLogger.ModConsole.Log("Debug: Start CheckTransform Recursive Checker");

			if (transform == null)
			{
				ModConsole.Log("Debug: CheckTransform transform is null");
				return;
			}

			GetChildren(transform);
		}

		public static void GetChildren(Transform transform)
		{
			//MelonLogger.ModConsole.Log("Debug: GetChildren current transform: " + transform.gameObject.name);

			_GameObjects.Add(transform.gameObject);

			for (var i = 0; i < transform.childCount; i++)
			{
				GetChildren(transform.GetChild(i));
			}
		}
	}
}