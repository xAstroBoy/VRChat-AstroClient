namespace AstroClient
{
	using AstroClient.components;
	using AstroClient.ConsoleUtils;
	using AstroClient.Variables;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using Exception = System.Exception;

	[Obsolete("This Class will be deleted, as the new ESP Can edit colors and it has identifiers!")]
	public class GameObjectESP : GameEvents
	{


		public static void AddESPToMurderProps()
		{
			isMurderItemsESPActivated = true;
			try
			{
				foreach (var item in MurderESPItems)
				{
					if (item != null)
					{
						item.AddComponent<ObjectESP>();
					}
				}
			}
			catch (Exception) { }
		}

		public static void RemoveESPToMurderProps()
		{
			isMurderItemsESPActivated = false;
			try
			{
				foreach (var item in MurderESPItems)
				{
					if (item != null)
					{
						var ESP = item.GetComponent<ObjectESP>();
						if (ESP != null)
						{
							UnityEngine.Object.Destroy(ESP);
						}
					}
				}
			}
			catch (Exception) { }
		}


		public override void OnLevelLoaded()
		{
			if (Murder4ESPtoggler != null)
			{
				Murder4ESPtoggler.setToggleState(false);
			}
			if (Murder2ESPtoggler != null)
			{
				Murder2ESPtoggler.setToggleState(false);
			}
			MurderESPItems.Clear();
		}

		public static bool isMurderItemsESPActivated = false;
		public static List<GameObject> MurderESPItems = new List<GameObject>();

		public static QMSingleToggleButton Murder2ESPtoggler;
		public static QMSingleToggleButton Murder4ESPtoggler;
	}
}