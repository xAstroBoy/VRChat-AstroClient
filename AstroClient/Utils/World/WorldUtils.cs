﻿namespace AstroClient
{
	using AstroClient.Experiments;
	using AstroLibrary.Console;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using VRC.SDK3.Components;
	using VRC.Udon;
	using Color = System.Drawing.Color;

	public class WorldUtils : GameEvents
	{
		public static List<GameObject> Get_Prefabs()
		{

			try
			{
				var result = new List<GameObject>();
				var list1 = VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs.ToArray().ToList();
				var list2 = VRCSDK2.VRC_SceneDescriptor._instance.DynamicPrefabs.ToArray().ToList();

				// Unite The lists In one.
				result = (list1 ?? Enumerable.Empty<GameObject>())
					.Union(list2 ?? Enumerable.Empty<GameObject>())
					.ToList()
					.Where(x => x.gameObject != null)
					.ToList(); // Never null.
				return result;

			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World Prefabs");
				ModConsole.ErrorExc(e);
				return null;
			}
		}

		public static IEnumerable<Player> Get_Players()
		{
			return PlayerManager.Method_Public_Static_ArrayOf_Player_0();
		}

		public static Player Get_Player_By_ID(string id)
		{
			var zero = PlayerManager.Method_Public_Static_Player_String_0(id);
			if (zero != null)
			{
				ModConsole.DebugLog("returned Method_Public_Static_Player_String_PDM_0");
				return zero;
			}

			ModConsole.Warning("GetPlayerById Failed to find A Player from ID.");
			return null;
		}

		public static Player Get_Player_With_DisplayName(string name)
		{
			if (Get_Players() != null)
			{
				foreach (var player in Get_Players())
				{
					if (player != null)
					{
						if (player.prop_APIUser_0 != null)
						{
							if (player.prop_APIUser_0.displayName == name)
							{
								return player;
							}
						}
					}
				}
			}
			return null;
		}


		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			ModConsole.Log("This instance has " + Get_Players().Count() + " Players.", Color.Gold);
		}

		public static List<GameObject> Get_Pickups()
		{
			try
			{
				var result = new List<GameObject>();
				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>().Select(i => i.gameObject).ToList();
				var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Pickup>().Select(i => i.gameObject).ToList();
				var list3 = Resources.FindObjectsOfTypeAll<VRCPickup>().Select(i => i.gameObject).ToList();

				// Unite The lists In one (avoiding duplicates).
				result = (list1 ?? Enumerable.Empty<GameObject>())
					.Union(list2 ?? Enumerable.Empty<GameObject>())
					.Union(list3 ?? Enumerable.Empty<GameObject>())
					.ToList()
					.Where(x => x.gameObject != null)
					.ToList(); // Never null.


							   // Then Filter the ViewFinder and AvatarDebugConsole
				if (result.Count() != 0)
				{
					if (CameraOnTweakerExperiment.ViewFinder.gameObject != null)
					{
						if (result.Contains(CameraOnTweakerExperiment.ViewFinder.gameObject))
						{
							ModConsole.DebugLog("Filtering ViewFinder From Pickup List...");
							result.Remove(CameraOnTweakerExperiment.ViewFinder.gameObject);
						}
					}

					GameObject AvatarDebugConsole = result.Where(x => x.name == "AvatarDebugConsole").FirstOrDefault(null);
					if (AvatarDebugConsole != null)
					{
						ModConsole.DebugLog("Filtering AvatarDebugConsole From Pickup List...");
						result.Remove(AvatarDebugConsole);
					}
				}
				return result;

			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World Pickups");
				ModConsole.ErrorExc(e);
				return null;
			}
		}

		public static List<GameObject> Get_VRCInteractables()
		{


			try
			{
				List<GameObject> result = new List<GameObject>();
				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Interactable>().Select(i => i.gameObject).ToList();
				var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Interactable>().Select(i => i.gameObject).ToList();
				var list3 = Resources.FindObjectsOfTypeAll<VRCInteractable>().Select(i => i.gameObject).ToList();

				// Unite The lists In one (avoiding duplicates).
				result =  (list1 ?? Enumerable.Empty<GameObject>())
					.Union(list2 ?? Enumerable.Empty<GameObject>())
					.Union(list3 ?? Enumerable.Empty<GameObject>())
					.ToList()
					.Where(x => x.gameObject != null)
					.ToList(); // Never null.
				
				return result;

			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World VRC Interactables");
				ModConsole.ErrorExc(e);
				return null;
			}
		}

		public static List<GameObject> Get_Triggers()
		{

			try
			{
				List<GameObject> result = new List<GameObject>();
				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Trigger>().Select(i => i.gameObject).ToList();
				var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Trigger>().Select(i => i.gameObject).ToList();

				// Unite The lists In one (avoiding duplicates).
				result = (list1 ?? Enumerable.Empty<GameObject>())
					.Union(list2 ?? Enumerable.Empty<GameObject>())
					.ToList()
					.Where(x => x.gameObject != null)
					.ToList(); // Never null.				return result;
				
				return result;
			}
			catch(Exception e)
			{
				ModConsole.Error("Error parsing World Triggers");
				ModConsole.ErrorExc(e);
				return null;
			}
		}

		public static List<UdonBehaviour> Get_UdonBehaviours()
		{
			List<UdonBehaviour> worldbehaviours = new List<UdonBehaviour>();
			worldbehaviours = Resources.FindObjectsOfTypeAll<UdonBehaviour>().Where(i => i._eventTable.keys.Count != 0).ToList();
			return worldbehaviours;
		}

		public static string Get_World_Name()
		{
			var instance = RoomManager.field_Internal_Static_ApiWorld_0;
			if (instance != null)
			{
				if (instance.name != null)
				{
					return instance.name;
				}
			}
			return null;
		}

		public static List<string> Get_World_tags()
		{
			var instance = RoomManager.field_Internal_Static_ApiWorld_0;
			if (instance != null)
			{
				if (instance.tags != null)
				{
					return instance.tags.ToArray().ToList();
				}
			}
			return null;
		}


		public static string Get_World_ID()
		{
			var instance = RoomManager.field_Internal_Static_ApiWorld_0;
			if (instance != null)
			{
				if (instance.id != null)
				{
					return instance.id;
				}
			}
			return null;
		}

		public static string Get_World_AssetUrl()
		{
			var instance = RoomManager.field_Internal_Static_ApiWorld_0;
			if (instance != null)
			{
				if (instance.assetUrl != null)
				{
					return instance.assetUrl;
				}
			}
			return null;
		}
	}
}