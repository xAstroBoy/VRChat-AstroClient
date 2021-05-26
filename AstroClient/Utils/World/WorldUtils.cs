namespace AstroClient
{
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
			var PrefabList = new List<GameObject>();
			if (VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs != null)
			{
				if (VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs.Count != 0)
				{
					foreach (var obj in VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs)
					{
						if (obj != null)
						{
							if (!PrefabList.Contains(obj))
							{
								PrefabList.Add(obj);
							}
						}
					}
					ModConsole.DebugLog("Returned SDKBase Dynamic Prefabs");
					return PrefabList;
				}
			}
			if (VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs != null)
			{
				if (VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs.Count == 0 && VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs.Count != 0)
				{
					foreach (var obj in VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs)
					{
						if (obj != null)
						{
							if (!PrefabList.Contains(obj))
							{
								PrefabList.Add(obj);
							}
						}
					}
					ModConsole.DebugLog("Returned VRCSDK2 Dynamic Prefabs");
					return PrefabList;
				}
			}
			return PrefabList;
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
				var Pickups = new List<GameObject>();
				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>();
				var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Pickup>();
				var list3 = Resources.FindObjectsOfTypeAll<VRCPickup>();
				if (list1.Count() != 0)
				{
					foreach (var item in list1)
					{
						if (item.gameObject.name == "ViewFinder")
						{
							continue;
						}
						if (item.gameObject.name == "AvatarDebugConsole")
						{
							continue;
						}
						if (!Pickups.Contains(item.gameObject))
						{
							Pickups.Add(item.gameObject);
						}
					}
					ModConsole.DebugLog("Returned only SDKBase Pickups");
					return Pickups;
				}
				if (list2.Count() != 0 && list1.Count() == 0)
				{
					foreach (var item in list2)
					{
						if (item.gameObject.name == "ViewFinder")
						{
							continue;
						}
						if (item.gameObject.name == "AvatarDebugConsole")
						{
							continue;
						}
						if (!Pickups.Contains(item.gameObject))
						{
							Pickups.Add(item.gameObject);
						}
					}
					ModConsole.DebugLog("Returned only VRCSDK2 Pickups");

					return Pickups;
				}
				if (list3.Count() != 0 && list1.Count() == 0 && list2.Count() == 0)
				{
					foreach (var item in list3)
					{
						if (item.gameObject.name == "ViewFinder")
						{
							continue;
						}
						if (item.gameObject.name == "AvatarDebugConsole")
						{
							continue;
						}
						if (!Pickups.Contains(item.gameObject))
						{
							Pickups.Add(item.gameObject);
						}
					}
					ModConsole.DebugLog("Returned only VRCSDK3 Pickups");

					return Pickups;
				}
				return Pickups;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static List<GameObject> Get_VRCInteractables()
		{
			try
			{
				var VRC_Interactables = new List<GameObject>();
				var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Interactable>();
				var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Interactable>();
				var list3 = Resources.FindObjectsOfTypeAll<VRCInteractable>();
				if (list1.Count() != 0)
				{
					foreach (var item in list1)
					{
						if (!VRC_Interactables.Contains(item.gameObject))
						{
							VRC_Interactables.Add(item.gameObject);
						}
					}
					ModConsole.DebugLog("Returned only SDKBase VRC_Interactable");
					return VRC_Interactables;
				}
				if (list2.Count() != 0 && list1.Count() == 0)
				{
					foreach (var item in list2)
					{
						if (!VRC_Interactables.Contains(item.gameObject))
						{
							VRC_Interactables.Add(item.gameObject);
						}
					}
					ModConsole.DebugLog("Returned only VRCSDK2 VRC_Interactable");

					return VRC_Interactables;
				}
				if (list3.Count() != 0 && list1.Count() == 0 && list2.Count() == 0)
				{
					foreach (var item in list3)
					{
						if (!VRC_Interactables.Contains(item.gameObject))
						{
							VRC_Interactables.Add(item.gameObject);
						}
					}
					ModConsole.DebugLog("Returned only VRCSDK3 VRC_Interactable");

					return VRC_Interactables;
				}
				return VRC_Interactables;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static List<GameObject> Get_Triggers()
		{
			var Triggers = new List<GameObject>();
			var list = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Trigger>();
			var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Trigger>();
			if (list.Count() != 0)
			{
				foreach (var item in list)
				{
					if (!Triggers.Contains(item.gameObject))
					{
						Triggers.Add(item.gameObject);
					}
				}
				ModConsole.DebugLog("Returned only SDKBase VRC_Trigger");
				return Triggers;
			}
			if (list2.Count() != 0 && list.Count() == 0)
			{
				foreach (var item in list2)
				{
					if (!Triggers.Contains(item.gameObject))
					{
						Triggers.Add(item.gameObject);
					}
				}
				ModConsole.DebugLog("Returned only VRCSDK2 VRC_Trigger");
				return Triggers;
			}
			return Triggers;
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