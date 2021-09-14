// Credits to Blaze and DayOfThePlay

namespace AstroLibrary.Utility
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Rendering.PostProcessing;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;
    using VRC.Udon;

    public static class WorldUtils
    {
        public static ApiWorld GetWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0;
        }

        public static ApiWorldInstance GetWorldInstance()
        {
            return RoomManager.field_Internal_Static_ApiWorldInstance_0;
        }

        public static bool IsInWorld
        {
            get
            {
                return GetWorld() != null && GetWorldInstance() != null;
            }
        }

        public static IEnumerable<Player> GetPlayers_Array()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        }


        public static List<Player> GetPlayers()
        {
            return GetPlayers_Array().ToList();
        }


        public static List<Player> GetPlayers(this PlayerManager Instance)
        {
            return Instance.field_Private_List_1_Player_0.ToArray().ToList();
        }

        public static int GetPlayerCount()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count;
        }

        public static VRCPlayer GetInstanceMaster()
        {
            foreach (var p in GetPlayers().Where(p => p._vrcplayer.IsInstanceMaster()))
            {
                return p._vrcplayer;
            }

            return null;
        }

        public static string GetWorldID()
        {
            return GetWorld().id;
        }

        public static string GetWorldName()
        {
            return GetWorld().name;
        }

        public static string GetWorldAuthorName()
        {
            return GetWorld().authorName;
        }


        public static List<string> GetWorldTags()
        {
            var instance = GetWorld();
            if (instance != null)
            {
                if (instance.tags != null)
                {
                    return instance.tags.ToArray().ToList();
                }
            }
            return null;
        }

        public static string GetWorldAssetURL()
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

        public static string GetFullID()
        {
            return $"{RoomManager.field_Internal_Static_ApiWorld_0.id}#{RoomManager.field_Internal_Static_ApiWorldInstance_0.id}";
        }

        public static int GetWorldOccupants()
        {
            return GetWorld().occupants;
        }

        public static int GetWorldCapacity()
        {
            return GetWorld().capacity;
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

        public static void JoinWorld(string fullID)
        {
            if (!fullID.ToLower().StartsWith("wrld_") || !fullID.ToLower().Contains('#'))
            {
                ModConsole.Error("INVALID JOIN ID!");
                Utils.VRCUiPopupManager.Alert("INVALID JOIN ID!", "The world ID you entered was invalid", "Ok", () => { });
                return;
            }
            else
            {
                Networking.GoToRoom(fullID);
            }
        }

        public static void JoinWorld(string worldID, string instanceID)
        {
            if (!worldID.ToLower().StartsWith("wrld_"))
            {
                ModConsole.Error("INVALID WORLD ID!");
                return;
            }
            else
            {
                new PortalInternal().Method_Private_Void_String_String_PDM_0(worldID, instanceID);
            }
        }

        public static bool IsDefaultScene(string name)
        {
            var lower = name.ToLower();
            string[] scenes = { "application2", "ui", "empty", "dontdestroyonload", "hideanddontsave", "samplescene" };
            return scenes.Contains(lower);
        }

        public static List<GameObject> GetPrefabs()
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

        public static Player GetPlayerByDisplayName(string name)
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

        public static VRCSDK2.VRC_SceneDescriptor GetSDK2Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>();
        }

        public static VRC.SDK3.Components.VRCSceneDescriptor GetSDK3Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRC.SDK3.Components.VRCSceneDescriptor>();
        }

        public static List<VRC_Pickup> GetPickups()
        {
            return Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToList();
        }

        public static VRC_Pickup[] GetActivePickups()
        {
            return UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
        }

        public static VRC_Interactable[] GetInteractables()
        {
            return Resources.FindObjectsOfTypeAll<VRC_Interactable>();
        }

        public static VRC_Interactable[] GetActiveInteractables()
        {
            return UnityEngine.Object.FindObjectsOfType<VRC_Interactable>();
        }

        public static PostProcessVolume[] GetBloom()
        {
            return Resources.FindObjectsOfTypeAll<PostProcessVolume>();
        }

        public static PostProcessVolume[] GetActiveBloom()
        {
            return UnityEngine.Object.FindObjectsOfType<PostProcessVolume>();
        }

        public static UdonBehaviour[] GetUdonScripts()
        {
            return Resources.FindObjectsOfTypeAll<UdonBehaviour>();
        }

        public static UdonBehaviour[] GetActiveUdonScripts()
        {
            return UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();
        }

        public static VRC_MirrorReflection[] GetMirrors()
        {
            return Resources.FindObjectsOfTypeAll<VRC_MirrorReflection>();
        }

        public static VRC_MirrorReflection[] GetActiveMirrors()
        {
            return UnityEngine.Object.FindObjectsOfType<VRC_MirrorReflection>();
        }
    }
}
