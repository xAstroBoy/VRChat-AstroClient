namespace AstroClient
{
    #region Imports

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
    using AstroLibrary.Extensions;
    using AstroClient.Variables;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using VRC.Core;

    #endregion

    public class WorldUtils_Old : GameEvents
    {
        public static List<GameObject> Get_Prefabs()
        {
            try
            {
                var list1 = VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs.ToArray().Where(x => x.gameObject != null).ToList();
                if (list1.AnyAndNotNull())
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
            var players = WorldUtils.GetPlayers().ToList();
            if (players.AnyAndNotNull())
            {
                foreach (var player in players)
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
            ModConsole.Log("This instance has " + WorldUtils.GetPlayers().Count() + " Players.", Color.Gold);
        }

        public static List<GameObject> Get_Pickups()
        {
            try
            {
                List<GameObject> result = new List<GameObject>();
                var list1 = GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_Pickup>()
                        .Select(i => i.gameObject)
                        .Where(x => x.gameObject != null)
                        .Where(x2 => x2.name != "AvatarDebugConsole")
                        .Where(x3 => x3.transform != CameraTweaker.ViewFinder)
                        .ToList();
                if (list1.AnyAndNotNull())
                {
                    result = list1;
                }
                else
                {
                    var list2 = GameObjectFinder.GetRootGameObjectsComponents<VRCSDK2.VRC_Pickup>()
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
                        var list3 = GameObjectFinder.GetRootGameObjectsComponents<VRCPickup>()
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
                var list1 = GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_Interactable>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList();
                if (list1.AnyAndNotNull())
                {
                    return list1;
                }
                else
                {
                    var list2 = GameObjectFinder.GetRootGameObjectsComponents<VRCSDK2.VRC_Interactable>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList();
                    if (list2 != null && list2.Count() != 0)
                    {
                        return list2;
                    }
                    else
                    {
                        var list3 = GameObjectFinder.GetRootGameObjectsComponents<VRCInteractable>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList();
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
                var list1 = GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_Trigger>().Select(i => i.gameObject).Where(x => x != null).ToList();
                if (list1.AnyAndNotNull())
                {
                    return list1;
                }
                else
                {
                    var list2 = GameObjectFinder.GetRootGameObjectsComponents<VRCSDK2.VRC_Trigger>().Select(i => i.gameObject).Where(x => x != null).ToList();
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

        public static List<AudioSource> Get_AudioSources()
        {
            try
            {
                return GameObjectFinder.GetRootGameObjectsComponents<AudioSource>(true, false);

            }
            catch (Exception e)
            {
                ModConsole.Error("Error parsing World Triggers");
                ModConsole.ErrorExc(e);
                return new List<AudioSource>();
            }
            return new List<AudioSource>();
        }

        public static List<string> Get_World_Pedestrals_Avatar_ids()
        {
            List<string> ids = new List<string>();
            var SDK_VRC_AvatarPedestrals = Get_SDKBase_VRC_AvatarPedestal();
            var SimpleAvatarPedestrals = Get_SimpleAvatarPedestal();
            var AvatarPedestals = Get_AvatarPedestal();
            var VRC_AvatarPedestal = Get_VRC_AvatarPedestal();
            var VRCAvatarPedestal = Get_VRCAvatarPedestal();
            if (SimpleAvatarPedestrals.Count() != 0)
            {
                foreach (var item in SimpleAvatarPedestrals)
                {
                    if (!ids.Contains(item.field_Internal_ApiAvatar_0.id))
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

        public static List<ApiAvatar> GetAvatarsFromPedestals()
        {
            List<ApiAvatar> avatars = new List<ApiAvatar>();

            var SDK_VRC_AvatarPedestrals = Get_SDKBase_VRC_AvatarPedestal();
            var VRC_AvatarPedestal = Get_VRC_AvatarPedestal();
            var VRCAvatarPedestal = Get_VRCAvatarPedestal();
            var SimpleAvatarPedestrals = Get_SimpleAvatarPedestal();
            var AvatarPedestals = Get_AvatarPedestal();

            if (SDK_VRC_AvatarPedestrals.AnyAndNotNull())
            {
                foreach (var pedestal in SDK_VRC_AvatarPedestrals)
                {
                    var avatar = AvatarUtils.GetApiAvatar(pedestal.blueprintId);
                    if (avatar != null)
                    {
                        AddAvatar(avatar);
                    }
                }
            }

            if (VRC_AvatarPedestal.AnyAndNotNull())
            {
                foreach (var pedestal in VRC_AvatarPedestal)
                {
                    var avatar = AvatarUtils.GetApiAvatar(pedestal.blueprintId);
                    if (avatar != null)
                    {
                        AddAvatar(avatar);
                    }
                }
            }

            if (VRCAvatarPedestal.AnyAndNotNull())
            {
                foreach (var pedestal in VRCAvatarPedestal)
                {
                    var avatar = AvatarUtils.GetApiAvatar(pedestal.blueprintId);
                    if (avatar != null)
                    {
                        AddAvatar(avatar);
                    }
                }
            }

            if (SimpleAvatarPedestrals.AnyAndNotNull())
            {
                foreach (var pedestal in SimpleAvatarPedestrals)
                {
                    AddAvatar(pedestal.field_Internal_ApiAvatar_0);
                }
            }

            if (AvatarPedestals.AnyAndNotNull())
            {
                foreach (var pedestal in AvatarPedestals)
                {
                    AddAvatar(pedestal.field_Private_ApiAvatar_0);
                }
            }

            void AddAvatar(ApiAvatar avatar)
            {
                if (avatars.Where(other => other.id.Equals(avatar.id)).Any()) return;
                avatars.Add(avatar);
            }

            return avatars;
        }

        public static List<VRCAvatarPedestal> Get_VRCAvatarPedestal()
        {
            try
            {
                var list1 = GameObjectFinder.GetRootGameObjectsComponents<VRCAvatarPedestal>()
                    .Where(
                    i => i.blueprintId.IsNotNullOrEmptyOrWhiteSpace()
                    && i.blueprintId.IsAvatarID()
                    ).ToList();
                if (list1.AnyAndNotNull())
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
                    i.field_Internal_ApiAvatar_0.id.IsNotNullOrEmptyOrWhiteSpace() &&
                    i.field_Internal_ApiAvatar_0.id.IsAvatarID()
                    && !i.transform.IsChildOf(VRChatObjects_Old.AvatarPreviewBase_MainAvatar)
                    && !i.transform.IsChildOf(VRChatObjects_Old.AvatarPreviewBase_FallbackAvatar)
                    && i.field_Internal_ApiAvatar_0.assetUrl.IsNotNullOrEmptyOrWhiteSpace()
                    ).ToList();
                if (list1.AnyAndNotNull())
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
                    i.field_Private_ApiAvatar_0.id.IsNotNullOrEmptyOrWhiteSpace() &&
                    i.field_Private_ApiAvatar_0.id.IsAvatarID()
                    && i.field_Private_ApiAvatar_0.assetUrl.IsNotNullOrEmptyOrWhiteSpace()
                    ).ToList();
                if (list1.AnyAndNotNull())
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
                    i => i.blueprintId.IsNotNullOrEmptyOrWhiteSpace()
                    && i.blueprintId.IsAvatarID()
                    ).ToList();
                if (list1.AnyAndNotNull())
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
                    i => i.blueprintId.IsNotNullOrEmptyOrWhiteSpace()
                    && i.blueprintId.IsAvatarID()
                    ).ToList();
                if (list1.AnyAndNotNull())
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
            var list = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
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

        public static VRCSDK2.VRC_SceneDescriptor GetSDK2Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>();
        }

        public static VRCSceneDescriptor GetSDK3Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRCSceneDescriptor>();
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