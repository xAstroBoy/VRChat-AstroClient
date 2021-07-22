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
	using VRC.SDKBase;
	using VRC.Udon;
	using Color = System.Drawing.Color;
	using AstroLibrary.Extensions;
	using VRC.Core;
	using AstroClient.Extensions;
	using AstroClient.Variables;
	using AstroLibrary.Finder;

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
                    if (list2 != null && list2.Count() != 0)
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
            return PlayerManager.prop_PlayerManager_0.prop_ArrayOf_Player_0;
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
                var list1 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>()
						.Select(i => i.gameObject)
						.Where(x => x.gameObject != null)
						.Where(x2 => x2.name != "AvatarDebugConsole")
						.Where(x3 => x3.transform != CameraTweaker.ViewFinder)
						.ToList();
				if (list1 != null && list1.Count() != 0)
				{
                    result = list1;
                }
                else
                {
                    var list2 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Pickup>()
						.Select(i => i.gameObject)
						.Where(x => x.gameObject != null)
						.Where(x2 => x2.name != "AvatarDebugConsole")
						.Where(x3 => x3.transform != CameraTweaker.ViewFinder)
						.ToList();

					if (list2 != null && list2.Count() != 0)
					{
                        result = list2;
                    }
                    else
                    {
                        var list3 = Resources.FindObjectsOfTypeAll<VRCPickup>()
						.Select(i => i.gameObject)
						.Where(x => x.gameObject != null)
						.Where(x2 => x2.name != "AvatarDebugConsole")
						.Where(x3 => x3.transform != CameraTweaker.ViewFinder)
						.ToList();
						if (list3 != null && list3.Count() != 0)
						{
                            result = list3;
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
            catch (Exception e)
            {
                ModConsole.Error("Error parsing World Triggers");
                ModConsole.ErrorExc(e);
                return new List<GameObject>();
            }
            return new List<GameObject>();
        }

		public static List<UnityEngine.AudioSource> Get_AudioSources()
		{
			try
			{
				return GameObjectFinder.GetRootGameObjectsComponents<UnityEngine.AudioSource>(true, false);

			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World Triggers");
				ModConsole.ErrorExc(e);
				return new List<UnityEngine.AudioSource>();
			}
			return new List<UnityEngine.AudioSource>();
		}



		public static List<string> Get_World_Pedestrals_Avatar_ids()
		{
			List<string> ids = new List<string>();
			var SDK_VRC_AvatarPedestrals = Get_SDKBase_VRC_AvatarPedestal();
			var SimpleAvatarPedestrals = Get_SimpleAvatarPedestal();
			var AvatarPedestals = Get_AvatarPedestal();
			var VRC_AvatarPedestal = Get_VRC_AvatarPedestal();
			var VRCAvatarPedestal = Get_VRCAvatarPedestal();
			if(SimpleAvatarPedestrals.Count() != 0)
			{
				foreach(var item in SimpleAvatarPedestrals)
				{
					if(!ids.Contains(item.field_Internal_ApiAvatar_0.id))
					{
						ids.Add(item.field_Internal_ApiAvatar_0.id);
					}
				}
			}
			if (AvatarPedestals.Count() != 0)
			{
				foreach (var item in AvatarPedestals)
				{
					if (!ids.Contains(item.field_Private_ApiAvatar_0.id))
					{
						ids.Add(item.field_Private_ApiAvatar_0.id);
					}
				}
			}

			if (VRC_AvatarPedestal.Count() != 0)
			{
				foreach (var item in VRC_AvatarPedestal)
				{
					if (!ids.Contains(item.blueprintId))
					{
						ids.Add(item.blueprintId);
					}
				}
			}
			if (SDK_VRC_AvatarPedestrals.Count() != 0)
			{
				foreach (var item in SDK_VRC_AvatarPedestrals)
				{
					if (!ids.Contains(item.blueprintId))
					{
						ids.Add(item.blueprintId);
					}
				}
			}
			if (VRCAvatarPedestal.Count() != 0)
			{
				foreach (var item in VRCAvatarPedestal)
				{
					if (!ids.Contains(item.blueprintId))
					{
						ids.Add(item.blueprintId);
					}
				}
			}
			return ids.Distinct().ToList();
		}





		public static List<VRCAvatarPedestal> Get_VRCAvatarPedestal()
		{
			try
			{
				var list1 = GameObjectFinder.GetRootGameObjectsComponents<VRCAvatarPedestal>()
					.Where(
					i => i.blueprintId.isNotNullOrEmptyOrWhiteSpace()
					&& i.blueprintId.isAvatarID()
					).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World VRCSDK2 VRC_AvatarPedestal");
				ModConsole.ErrorExc(e);
				return new List<VRCAvatarPedestal>();
			}
			return new List<VRCAvatarPedestal>();
		}


		public static List<SimpleAvatarPedestal> Get_SimpleAvatarPedestal()
		{
			try
			{
				var list1 = GameObjectFinder.GetRootGameObjectsComponents<SimpleAvatarPedestal>()
					.Where(
					i => i.field_Internal_ApiAvatar_0 != null &&
					i.field_Internal_ApiAvatar_0.id.isNotNullOrEmptyOrWhiteSpace() &&
					i.field_Internal_ApiAvatar_0.id.isAvatarID()
					&& !i.transform.IsChildOf(VRChatObjects.AvatarPreviewBase_MainAvatar)
					&& !i.transform.IsChildOf(VRChatObjects.AvatarPreviewBase_FallbackAvatar)
					).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World SimpleAvatarPedestal");
				ModConsole.ErrorExc(e);
				return new List<SimpleAvatarPedestal>();
			}
			return new List<SimpleAvatarPedestal>();
		}



		public static List<AvatarPedestal> Get_AvatarPedestal()
		{
			try
			{
				var list1 = GameObjectFinder.GetRootGameObjectsComponents<AvatarPedestal>()
					.Where(
					i => i.field_Private_ApiAvatar_0 != null && 
					i.field_Private_ApiAvatar_0.id.isNotNullOrEmptyOrWhiteSpace() && 
					i.field_Private_ApiAvatar_0.id.isAvatarID()
					).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World SDKBase VRC_AvatarPedestal");
				ModConsole.ErrorExc(e);
				return new List<AvatarPedestal>();
			}
			return new List<AvatarPedestal>();
		}
		public static List<VRC.SDKBase.VRC_AvatarPedestal> Get_SDKBase_VRC_AvatarPedestal()
		{
			try
			{
				var list1 = GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_AvatarPedestal>()
					.Where(
					i => i.blueprintId.isNotNullOrEmptyOrWhiteSpace()
					&& i.blueprintId.isAvatarID()
					).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World VRCSDK2 VRC_AvatarPedestal");
				ModConsole.ErrorExc(e);
				return new List<VRC.SDKBase.VRC_AvatarPedestal>();
			}
			return new List<VRC.SDKBase.VRC_AvatarPedestal>();
		}


		public static List<VRCSDK2.VRC_AvatarPedestal> Get_VRC_AvatarPedestal()
		{
			try
			{
				var list1 = GameObjectFinder.GetRootGameObjectsComponents<VRCSDK2.VRC_AvatarPedestal>()
					.Where(
					i => i.blueprintId.isNotNullOrEmptyOrWhiteSpace() 
					&& i.blueprintId.isAvatarID()
					).ToList();
				if (list1 != null && list1.Count() != 0)
				{
					return list1;
				}
			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing World VRCSDK2 VRC_AvatarPedestal");
				ModConsole.ErrorExc(e);
				return new List<VRCSDK2.VRC_AvatarPedestal>();
			}
			return new List<VRCSDK2.VRC_AvatarPedestal>();
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

		public static VRCSDK2.VRC_SceneDescriptor GetSDK2Descriptor()
		{
			return UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>();
		}

		public static VRC.SDK3.Components.VRCSceneDescriptor GetSDK3Descriptor()
		{
			return UnityEngine.Object.FindObjectOfType<VRC.SDK3.Components.VRCSceneDescriptor>();
		}

		public static bool IsInWorld()
		{
			if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null) return true;
			else return false;
		}

		public static bool IsDefaultScene(string name)
		{
			var lower = name.ToLower();
			string[] scenes = { "application2", "ui", "empty", "dontdestroyonload", "hideanddontsave", "samplescene" };
			return scenes.Contains(lower);
		}

		public static string GetSDKType()
		{
			if (GetSDK2Descriptor() != null)
				return "SDK2";
			else if (GetSDK3Descriptor() != null)
				return "SDK3";
			else
				return "not found";
		}
	}
}