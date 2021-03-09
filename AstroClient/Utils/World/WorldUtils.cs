using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.SDK3.Components;

#region AstroClient Imports

using AstroClient.ConsoleUtils;

#endregion AstroClient Imports

namespace AstroClient
{
    public class WorldUtils
    {
        public static void OnLevelLoad()
        {
        }

        public static List<GameObject> GetAllWorldPrefabs()
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
                    ModConsole.Log("Returned SDKBase Dynamic Prefabs");
                    return PrefabList;
                }
            }
            if (VRCSDK2.VRC_SceneDescriptor._instance.DynamicPrefabs != null)
            {
                if (VRC.SDKBase.VRC_SceneDescriptor._instance.DynamicPrefabs.Count == 0 && VRCSDK2.VRC_SceneDescriptor._instance.DynamicPrefabs.Count != 0)
                {
                    foreach (var obj in VRCSDK2.VRC_SceneDescriptor._instance.DynamicPrefabs)
                    {
                        if (obj != null)
                        {
                            if (!PrefabList.Contains(obj))
                            {
                                PrefabList.Add(obj);
                            }
                        }
                    }
                    ModConsole.Log("Returned VRCSDK2 Dynamic Prefabs");
                    return PrefabList;
                }
            }
            return PrefabList;
        }

        public static IEnumerable<Player> GetAllPlayers0()
        {
            return PlayerManager.Method_Public_Static_ArrayOf_Player_0();
        }

        public static Player GetPlayerByID(string id)
        {
            ModConsole.Log("GetPlayerID Called with params :" + id);

            var zero = PlayerManager.Method_Public_Static_Player_String_0(id);
            //var one = PlayerManager.Method_Public_Static_Player_String_PDM_0(id);
            //if (one != null)
            //{
            //    ModConsole.Log("returned Method_Public_Static_Player_String_1");
            //    return one;
            //}
            if (zero != null)
            {
                ModConsole.Log("returned Method_Public_Static_Player_String_PDM_0");
                return zero;
            }

            ModConsole.Log("GetPlayerById Failed to find A Player from ID.");
            return null;
        }


        public static Player GetPlayerByDisplayName(string name)
        {
            if (GetAllPlayers0() != null)
            {
                foreach (var player in GetAllPlayers0())
                {
                    if (player != null)
                    {
                        if(player.prop_APIUser_0 != null)
                        {
                            if(player.prop_APIUser_0.displayName == name)
                            {
                                return player;
                            }
                        }
                    }
                }
            }
            return null;
        }


        public static Player GetPlayerByVRCPlayer(VRCPlayer target)
        {
            return target.field_Private_Player_0;
        }

        public static void OnWorldReveal()
        {
            ModConsole.Log("This instance has " + GetAllPlayers0().Count() + " Players.", ConsoleColor.Green);
        }

        public static List<GameObject> GetAllWorldPickups()
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
                        if (!Pickups.Contains(item.gameObject))
                        {
                            Pickups.Add(item.gameObject);
                        }
                    }
                    ModConsole.Log("Returned only SDKBase Pickups");
                    return Pickups;
                }
                if (list2.Count() != 0 && list1.Count() == 0)
                {
                    foreach (var item in list2)
                    {
                        if (!Pickups.Contains(item.gameObject))
                        {
                            Pickups.Add(item.gameObject);
                        }
                    }
                    ModConsole.Log("Returned only VRCSDK2 Pickups");

                    return Pickups;
                }
                if (list3.Count() != 0 && list1.Count() == 0 && list2.Count() == 0)
                {
                    foreach (var item in list3)
                    {
                        if (!Pickups.Contains(item.gameObject))
                        {
                            Pickups.Add(item.gameObject);
                        }
                    }
                    ModConsole.Log("Returned only VRCSDK3 Pickups");

                    return Pickups;
                }
                return Pickups;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<GameObject> GetAllVRCInteractables()
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
                    ModConsole.Log("Returned only SDKBase VRC_Interactable");
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
                    ModConsole.Log("Returned only VRCSDK2 VRC_Interactable");

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
                    ModConsole.Log("Returned only VRCSDK3 VRC_Interactable");

                    return VRC_Interactables;
                }
                return VRC_Interactables;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<GameObject> GetAllWorldTriggers()
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
                ModConsole.Log("Returned only SDKBase VRC_Trigger");
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
                ModConsole.Log("Returned only VRCSDK2 VRC_Trigger");
                return Triggers;
            }
            return Triggers;
        }

        public static string GetWorldName()
        {
            var instance = RoomManager.field_Internal_Static_ApiWorld_0;
            if (instance != null)
            {
                if (instance.name != null)
                {
                    return instance.name;
                }
                else
                {
                    return "ASTROBOY_CLIENT_ERROR_WORLD_IS_NULL";
                }
            }
            else
            {
                return "ASTROBOY_CLIENT_ERROR_WORLD_IS_NULL";
            }
        }

        public static string GetWorldID()
        {
            var instance = RoomManager.field_Internal_Static_ApiWorld_0;
            if (instance != null)
            {
                if (instance.id != null)
                {
                    return instance.id;
                }
                else
                {
                    return "ASTROBOY_CLIENT_ERROR_WORLD_ID_IS_NULL";
                }
            }
            else
            {
                return "ASTROBOY_CLIENT_ERROR_WORLD_ID_IS_NULL";
            }
        }

        public static string GetWorldAssetURL()
        {
            var instance = RoomManager.field_Internal_Static_ApiWorld_0;
            if (instance != null)
            {
                if (instance.id != null)
                {
                    return instance.assetUrl;
                }
                else
                {
                    return "ASTROBOY_CLIENT_ERROR_WORLD_ID_IS_NULL";
                }
            }
            else
            {
                return "ASTROBOY_CLIENT_ERROR_WORLD_ID_IS_NULL";
            }
        }
    }
}