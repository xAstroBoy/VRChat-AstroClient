// Credits to Blaze and DayOfThePlay

namespace AstroClient.xAstroBoy.Utility
{
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
        /// <summary>
        /// Returns the current ApiWorld
        /// </summary>
        public static ApiWorld World
        {
            get
            {
                return RoomManager.field_Internal_Static_ApiWorld_0;
            }
        }

        /// <summary>
        /// Returns the current ApiWorldInstance
        /// </summary>
        public static ApiWorldInstance Instance
        {
            get
            {
                return RoomManager.field_Internal_Static_ApiWorldInstance_0;
            }
        }

        /// <summary>
        /// Returns true if the current player is currently in a world
        /// </summary>
        public static bool IsInWorld
        {
            get
            {
                return World != null && Instance != null;
            }
        }

        public static IEnumerable<Player> PlayersArray
        {
            get
            {
                return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
            }
        }

        /// <summary>
        /// Returns a list of players in the current world
        /// </summary>
        public static List<Player> Players
        {
            get
            {
                return PlayersArray.ToList();
            }
        }


        public static List<Player> GetPlayers(this PlayerManager Instance)
        {
            return Instance.field_Private_List_1_Player_0.ToArray().ToList();
        }

        public static int PlayerCount
        {
            get
            {
                return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count;
            }
        }

        public static VRCPlayer InstanceMaster
        {
            get
            {
                foreach (var p in Players.Where(p => PlayerUtils.IsInstanceMaster((VRCPlayer)p._vrcplayer)))
                {
                    return p._vrcplayer;
                }

                return null;
            }
        }

        public static string WorldID
        {
            get
            {
                return World.id;
            }
        }

        public static string WorldName
        {
            get
            {
                return World.name;
            }
        }

        public static string AuthorName
        {
            get
            {
                return World.authorName;
            }
        }

        public static List<string> WorldTags
        {
            get
            {
                var instance = World;
                if (instance != null)
                {
                    if (instance.tags != null)
                    {
                        return instance.tags.ToArray().ToList();
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Returns the asset URL for the current world
        /// </summary>
        /// <returns></returns>
        public static string AssetURL
        {
            get
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

        /// <summary>
        /// Returns the full Instance ID of the current world
        /// </summary>
        public static string FullID
        {
            get
            {
                return $"{RoomManager.field_Internal_Static_ApiWorld_0.id}#{RoomManager.field_Internal_Static_ApiWorldInstance_0.id}";
            }
        }

        public static int WorldOccupants => World.occupants;

        public static int WorldCapacity => World.capacity;

        public static string SDKType
        {
            get
            {
                if (SDK2Descriptor != null)
                    return "SDK2";
                else if (SDK3Descriptor != null)
                    return "SDK3";
                else
                    return "not found";
            }
        }

        public static void JoinWorld(string fullID)
        {
            if (!fullID.ToLower().StartsWith("wrld_") || !fullID.ToLower().Contains('#'))
            {
                Log.Error("INVALID JOIN ID!");
                GameInstances.VRCUiPopupManager.Alert("INVALID JOIN ID!", "The world ID you entered was invalid", "Ok", () => { });
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
                Log.Error("INVALID WORLD ID!");
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

        public static List<GameObject> Prefabs
        {
            get
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
                    Log.Error("Error parsing World Prefabs");
                    Log.Exception(e);
                    return new List<GameObject>();
                }
                return new List<GameObject>();
            }
        }

        public static Player GetPlayerByDisplayName(string name)
        {
            var players = WorldUtils.Players;
            if (players != null && players.Any())
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Player player = players[i];
                    if (player != null && player.prop_APIUser_0 != null && player.prop_APIUser_0.displayName == name)
                    {
                        return player;
                    }
                }
            }
            return null;
        }

        public static VRCSDK2.VRC_SceneDescriptor SDK2Descriptor => UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>();

        public static VRC.SDK3.Components.VRCSceneDescriptor SDK3Descriptor => UnityEngine.Object.FindObjectOfType<VRC.SDK3.Components.VRCSceneDescriptor>();

        public static List<VRC_Pickup> Pickups => Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToList();

        public static VRC_Pickup[] ActivePickups => UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();

        public static VRC_Interactable[] Interactables => Resources.FindObjectsOfTypeAll<VRC_Interactable>();

        public static VRC_Interactable[] ActiveInteractables => UnityEngine.Object.FindObjectsOfType<VRC_Interactable>();

        public static PostProcessVolume[] Bloom => Resources.FindObjectsOfTypeAll<PostProcessVolume>();

        public static PostProcessVolume[] ActiveBloom => UnityEngine.Object.FindObjectsOfType<PostProcessVolume>();

        public static UdonBehaviour[] UdonScripts => Resources.FindObjectsOfTypeAll<UdonBehaviour>();

        public static UdonBehaviour[] ActiveUdonScripts => UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();

        public static VRC_MirrorReflection[] Mirrors => Resources.FindObjectsOfTypeAll<VRC_MirrorReflection>();

        public static VRC_MirrorReflection[] ActiveMirrors => UnityEngine.Object.FindObjectsOfType<VRC_MirrorReflection>();
    }
}
