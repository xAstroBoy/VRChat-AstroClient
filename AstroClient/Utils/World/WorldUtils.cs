namespace AstroClient
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

				var list1 = VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs.ToArray().Where(x => x.gameObject != null).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
				else
				{
					var list2 = VRCSDK2.VRC_SceneDescriptor._instance.DynamicPrefabs.ToArray().Where(x => x.gameObject != null).ToList();
					if(list2 != null && list2.Count() != 0)
					{
						return list2;
					}
				}
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World Prefabs");
				ModConsole.ErrorExc(e);
				return new List<GameObject>();
			}
			return new List<GameObject>();
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
				List<GameObject> result = new List<GameObject>();
				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>().Select(i => i.gameObject).Where(x => x.gameObject != null && x.name != "AvatarDebugConsole").ToList();
				if (list1 != null && list1.Count() != 0)
				{
					result =  list1;
				}
				else
				{
					var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Pickup>().Select(i => i.gameObject).Where(x => x.gameObject != null && x.name != "AvatarDebugConsole").ToList();
					if (list2 != null && list2.Count() != 0)
					{
						result =  list2;
					}
					else
					{
						var list3 = Resources.FindObjectsOfTypeAll<VRCPickup>().Select(i => i.gameObject).Where(x => x.gameObject != null && x.name != "AvatarDebugConsole").ToList();
						if (list3 != null && list3.Count() != 0)
						{
							result = list3;
						}
					}
				}


				if (result.Count() != 0) // Then Filter the ViewFinder (Player Camera)
				{
					if (CameraOnTweakerExperiment.ViewFinder.gameObject != null)
					{
						if (result.Contains(CameraOnTweakerExperiment.ViewFinder.gameObject))
						{
							result.Remove(CameraOnTweakerExperiment.ViewFinder.gameObject);
						}
					}
				}
				return result;
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World Pickups");
				ModConsole.ErrorExc(e);
				return new List<GameObject>();
			}
			return new List<GameObject>();
		}

		public static List<GameObject> Get_VRCInteractables()
		{
			try
			{
				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Interactable>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
				else
				{
					var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Interactable>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList();
					if (list2 != null && list2.Count() != 0)
					{
						return list2;
					}
					else
					{
						var list3 = Resources.FindObjectsOfTypeAll<VRCInteractable>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList();
						if (list3 != null && list3.Count() != 0)
						{
							return list3;
						}
					}
				}
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World VRC Interactables");
				ModConsole.ErrorExc(e);
				return new List<GameObject>();
			}
			return new List<GameObject>();
		}

		public static List<GameObject> Get_Triggers()
		{

			try
			{


				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Trigger>().Select(i => i.gameObject).Where(x => x != null).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
				else
				{
					var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Trigger>().Select(i => i.gameObject).Where(x => x != null).ToList();
					if (list2 != null && list2.Count() != 0)
					{
						return list2;
					}
				}
			}
			catch(Exception e)
			{
				ModConsole.Error("Error parsing World Triggers");
				ModConsole.ErrorExc(e);
				return new List<GameObject>();
			}
			return new List<GameObject>();
		}

		public static List<UdonBehaviour> Get_UdonBehaviours()
		{
			var UdonBehaviourObjects = new List<UdonBehaviour>();
			var list = Resources.FindObjectsOfTypeAll<UdonBehaviour>();
			if (list.Count() != 0)
			{
				foreach (var item in list)
				{
					if (item._eventTable.Keys.Count != 0)
					{
						if (!UdonBehaviourObjects.Contains(item))
						{
							UdonBehaviourObjects.Add(item);
						}
					}
				}
				return UdonBehaviourObjects;
			}
			return UdonBehaviourObjects;
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