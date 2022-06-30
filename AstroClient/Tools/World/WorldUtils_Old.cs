using AstroClient.AstroMonos.Components.Tools;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.Tools.Regexes;
using AstroClient.Tools.UdonEditor;
using VRC.SDKBase;

namespace AstroClient.Tools.World
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Experiments;
    using FavCat.Database.Stored;
    using UdonSearcher;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;
    using Color = System.Drawing.Color;

    #endregion Imports

    internal class WorldUtils_Old : AstroEvents
    {


        internal static List<GameObject> Get_Pickups()
        {
            try
            { 
                // All 3 Pickups Components inherit this.


                return GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_Pickup>()
                           .Select(i => i.gameObject)
                           .Where(x => x.gameObject != null)
                           .Where(x2 => x2.name != "AvatarDebugConsole")
                           .Where(x3 => x3.transform != CameraTweaker.ViewFinder)
                           .Where(x4 => x4.gameObject.Pickup_Get_ForceComponent() == false)
                           .ToList();


            }
            catch (Exception e)
            {
                Log.Error("Error parsing World Pickups");
                Log.Exception(e);
                return new List<GameObject>();
            }
            return new List<GameObject>();
        }
        internal static List<GameObject> Get_Mirrors()
        {
            try
            {
                return GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_MirrorReflection>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList();
     
            }
            catch (Exception e)
            {
                Log.Error("Error parsing World Mirrors");
                Log.Exception(e);
                return new List<GameObject>();
            }
            return new List<GameObject>();
        }


        internal static List<GameObject> Get_VRCInteractables()
        {
            try
            {
                // All 2 extra component inherit this.
                return GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_Interactable>().Select(i => i.gameObject).Where(x => x.gameObject != null).ToList(); 
                
            }
            catch (Exception e)
            {
                Log.Error("Error parsing World VRC Interactables");
                Log.Exception(e);
                return new List<GameObject>();
            }
            return new List<GameObject>();
        }

        internal static List<GameObject> Get_Triggers()
        {
            try
            {
                var list = GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_Trigger>().Select(i => i.gameObject).Where(x => x != null).ToList();
                if (list.AnyAndNotNull())
                {
                    return list;
                }
            }
            catch (Exception e)
            {
                Log.Error("Error parsing World Triggers");
                Log.Exception(e);
                return new List<GameObject>();
            }
            return new List<GameObject>();
        }

        internal static List<AudioSource> Get_AudioSources()
        {
            try
            {
                return GameObjectFinder.GetRootGameObjectsComponents<AudioSource>(true, false);
            }
            catch (Exception e)
            {
                Log.Error("Error parsing World Triggers");
                Log.Exception(e);
                return new List<AudioSource>();
            }
            return new List<AudioSource>();
        }

        internal static List<string> Get_World_Pedestrals_Avatar_ids()
        {
            List<string> ids = new List<string>();
            var SDK_VRC_AvatarPedestrals = Get_SDKBase_VRC_AvatarPedestal();
            var SimpleAvatarPedestrals = Get_SimpleAvatarPedestal();
            var AvatarPedestals = Get_AvatarPedestal();
            var VRC_AvatarPedestal = Get_VRC_AvatarPedestal();
            var VRCAvatarPedestal = Get_VRCAvatarPedestal();
            if (SimpleAvatarPedestrals.Count() != 0)
            {
                for (int i = 0; i < SimpleAvatarPedestrals.Count; i++)
                {
                    SimpleAvatarPedestal item = SimpleAvatarPedestrals[i];
                    if (!ids.Contains(item.field_Internal_ApiAvatar_0.id))
                    {
                        ids.Add(item.field_Internal_ApiAvatar_0.id);
                    }
                }
            }
            if (AvatarPedestals.Count() != 0)
            {
                for (int i = 0; i < AvatarPedestals.Count; i++)
                {
                    AvatarPedestal item = AvatarPedestals[i];
                    if (!ids.Contains(item.field_Private_ApiAvatar_0.id))
                    {
                        ids.Add(item.field_Private_ApiAvatar_0.id);
                    }
                }
            }

            if (VRC_AvatarPedestal.Count() != 0)
            {
                for (int i = 0; i < VRC_AvatarPedestal.Count; i++)
                {
                    VRCSDK2.VRC_AvatarPedestal item = VRC_AvatarPedestal[i];
                    if (!ids.Contains(item.blueprintId))
                    {
                        ids.Add(item.blueprintId);
                    }
                }
            }
            if (SDK_VRC_AvatarPedestrals.Count() != 0)
            {
                for (int i = 0; i < SDK_VRC_AvatarPedestrals.Count; i++)
                {
                    VRC.SDKBase.VRC_AvatarPedestal item = SDK_VRC_AvatarPedestrals[i];
                    if (!ids.Contains(item.blueprintId))
                    {
                        ids.Add(item.blueprintId);
                    }
                }
            }
            if (VRCAvatarPedestal.Count() != 0)
            {
                for (int i = 0; i < VRCAvatarPedestal.Count; i++)
                {
                    VRCAvatarPedestal item = VRCAvatarPedestal[i];
                    if (!ids.Contains(item.blueprintId))
                    {
                        ids.Add(item.blueprintId);
                    }
                }
            }
            return ids.Distinct().ToList();
        }

        internal static List<string> GetAvatarsFromPedestals()
        {
            List<string> avatars = new List<string>();

            var SDK_VRC_AvatarPedestrals = Get_SDKBase_VRC_AvatarPedestal();
            var VRC_AvatarPedestal = Get_VRC_AvatarPedestal();
            var VRCAvatarPedestal = Get_VRCAvatarPedestal();
            var SimpleAvatarPedestrals = Get_SimpleAvatarPedestal();
            var AvatarPedestals = Get_AvatarPedestal();
            var EmbededUdonPedestrals = UdonSearch.FindUdonAvatarPedestrals();
            if (SDK_VRC_AvatarPedestrals.AnyAndNotNull())
            {
                for (int i = 0; i < SDK_VRC_AvatarPedestrals.Count; i++)
                {
                    VRC.SDKBase.VRC_AvatarPedestal pedestal = SDK_VRC_AvatarPedestrals[i];
                    if (pedestal.blueprintId.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        AddAvatar(pedestal.blueprintId);
                    }
                }
            }

            if (VRC_AvatarPedestal.AnyAndNotNull())
            {
                for (int i = 0; i < VRC_AvatarPedestal.Count; i++)
                {
                    VRCSDK2.VRC_AvatarPedestal pedestal = VRC_AvatarPedestal[i];
                    if (pedestal.blueprintId.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        AddAvatar(pedestal.blueprintId);
                    }
                }
            }

            if (VRCAvatarPedestal.AnyAndNotNull())
            {
                for (int i = 0; i < VRCAvatarPedestal.Count; i++)
                {
                    VRCAvatarPedestal pedestal = VRCAvatarPedestal[i];

                    if (pedestal.blueprintId.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        AddAvatar(pedestal.blueprintId);
                    }
                }
            }

            if (SimpleAvatarPedestrals.AnyAndNotNull())
            {
                for (int i = 0; i < SimpleAvatarPedestrals.Count; i++)
                {
                    SimpleAvatarPedestal pedestal = SimpleAvatarPedestrals[i];
                    AddAvatar(pedestal.field_Internal_ApiAvatar_0.id);
                }
            }

            if (AvatarPedestals.AnyAndNotNull())
            {
                for (int i = 0; i < AvatarPedestals.Count; i++)
                {
                    AvatarPedestal pedestal = AvatarPedestals[i];
                    AddAvatar(pedestal.field_Private_ApiAvatar_0.id);
                }
            }
            if (EmbededUdonPedestrals.AnyAndNotNull())
            {
                for (int i = 0; i < EmbededUdonPedestrals.Count; i++)
                {
                    string avatarid = EmbededUdonPedestrals[i];
                    if (avatarid.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        AddAvatar(avatarid);
                    }
                }
            }

            void AddAvatar(string avatarid)
            {
                if (!avatars.Contains(avatarid))
                {
                    avatars.Add(avatarid);
                }

            }

            return avatars;
        }

        internal static List<VRCAvatarPedestal> Get_VRCAvatarPedestal()
        {
            try
            {
                var list = GameObjectFinder.GetRootGameObjectsComponents<VRCAvatarPedestal>();
                if (list.Count() != 0)
                {
                    foreach (var item in list)
                    {
                        if (!item.grantBlueprintAccess)
                        {
                            item.grantBlueprintAccess = true;
                        }
                    }
                }
                var result = list
                    .Where(
                    i => i.blueprintId.IsNotNullOrEmptyOrWhiteSpace()
                    && i.blueprintId.IsAvatarID()
                    ).ToList();

                if (result.AnyAndNotNull())
                {
                    return result;
                }
            }
            catch (Exception e)
            {
                Log.Error("Error parsing World VRCSDK2 VRC_AvatarPedestal");
                Log.Exception(e);
                return new List<VRCAvatarPedestal>();
            }
            return new List<VRCAvatarPedestal>();
        }

        internal static List<SimpleAvatarPedestal> Get_SimpleAvatarPedestal()
        {
            try
            {
                var list = GameObjectFinder.GetRootGameObjectsComponents<SimpleAvatarPedestal>();
                var result = list
                    .Where(
                    i => i.field_Internal_ApiAvatar_0 != null &&
                    i.field_Internal_ApiAvatar_0.id.IsNotNullOrEmptyOrWhiteSpace() &&
                    i.field_Internal_ApiAvatar_0.id.IsAvatarID()
                    && !i.transform.IsChildOf(UserInterfaceObjects.AvatarPreviewBase_MainAvatar)
                    && !i.transform.IsChildOf(UserInterfaceObjects.AvatarPreviewBase_FallbackAvatar)
                    && i.field_Internal_ApiAvatar_0.assetUrl.IsNotNullOrEmptyOrWhiteSpace()
                    ).ToList();

                if (result.AnyAndNotNull())
                {
                    return result;
                }
            }
            catch (Exception e)
            {
                Log.Error("Error parsing World SimpleAvatarPedestal");
                Log.Exception(e);
                return new List<SimpleAvatarPedestal>();
            }
            return new List<SimpleAvatarPedestal>();
        }

        internal static List<AvatarPedestal> Get_AvatarPedestal()
        {
            try
            {
                var list = GameObjectFinder.GetRootGameObjectsComponents<AvatarPedestal>();
                if (list.Count() != 0)
                {
                    foreach (var item in list)
                    {
                        if (item.field_Private_VRC_AvatarPedestal_0 != null)
                        {
                            if (!item.field_Private_VRC_AvatarPedestal_0.grantBlueprintAccess)
                            {
                                item.field_Private_VRC_AvatarPedestal_0.grantBlueprintAccess = true;
                            }
                        }
                    }
                }

                var list1 = list
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
                Log.Error("Error parsing World SDKBase VRC_AvatarPedestal");
                Log.Exception(e);
                return new List<AvatarPedestal>();
            }
            return new List<AvatarPedestal>();
        }

        internal static List<VRC.SDKBase.VRC_AvatarPedestal> Get_SDKBase_VRC_AvatarPedestal()
        {
            try
            {
                var list = GameObjectFinder.GetRootGameObjectsComponents<VRC.SDKBase.VRC_AvatarPedestal>();
                if (list.Count() != 0)
                {
                    foreach (var item in list)
                    {
                        if (!item.grantBlueprintAccess)
                        {
                            item.grantBlueprintAccess = true;
                        }
                    }
                }

                var result = list
                    .Where(
                    i => i.blueprintId.IsNotNullOrEmptyOrWhiteSpace()
                    && i.blueprintId.IsAvatarID()
                    ).ToList();
                if (result.AnyAndNotNull())
                {
                    return result;
                }
            }
            catch (Exception e)
            {
                Log.Error("Error parsing World VRCSDK2 VRC_AvatarPedestal");
                Log.Exception(e);
                return new List<VRC.SDKBase.VRC_AvatarPedestal>();
            }
            return new List<VRC.SDKBase.VRC_AvatarPedestal>();
        }

        internal static List<VRCSDK2.VRC_AvatarPedestal> Get_VRC_AvatarPedestal()
        {
            try
            {
                var list = GameObjectFinder.GetRootGameObjectsComponents<VRCSDK2.VRC_AvatarPedestal>();
                if (list.Count() != 0)
                {
                    foreach (var item in list)
                    {
                        if (item != null)
                        {
                            if (!item.grantBlueprintAccess)
                            {
                                item.grantBlueprintAccess = true;
                            }
                        }
                    }
                }
                var list1 = list
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
                Log.Error("Error parsing World VRCSDK2 VRC_AvatarPedestal");
                Log.Exception(e);
                return new List<VRCSDK2.VRC_AvatarPedestal>();
            }
            return new List<VRCSDK2.VRC_AvatarPedestal>();
        }

        internal static List<UdonBehaviour> Get_UdonBehaviours()
        {
            var UdonBehaviourObjects = new List<UdonBehaviour>();
            var list = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            if (list.Count() != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    UdonBehaviour item = list[i];
                    var keys = item.Get_EventKeys();
                    if (keys == null) continue;
                    UdonBehaviourObjects.Add(item);
                }
                return UdonBehaviourObjects;
            }
            return UdonBehaviourObjects;
        }

        internal static string Get_World_Name()
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

        internal static string Get_World_ID()
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

        internal static VRCSDK2.VRC_SceneDescriptor GetSDK2Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>();
        }

        internal static VRCSceneDescriptor GetSDK3Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRCSceneDescriptor>();
        }

        internal static bool IsInWorld()
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null) return true;
            else return false;
        }

        internal static bool IsDefaultScene(string name)
        {
            var lower = name.ToLower();
            string[] scenes = { "application2", "ui", "empty", "dontdestroyonload", "hideanddontsave", "samplescene" };
            return scenes.Contains(lower);
        }

    }
}