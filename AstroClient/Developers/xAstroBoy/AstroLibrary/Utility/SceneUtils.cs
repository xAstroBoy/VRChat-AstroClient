

using Mono.CSharp;

namespace AstroClient.xAstroBoy.Utility
{
    using System.Collections.Generic;
    using ClientActions;
    using System.Linq;
    using UnityEngine;
    using VRC.SDKBase;

    internal class SceneUtils : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnRoomLeft += OnRoomLeft;

        }

        private void OnRoomLeft()
        {
            Restore_DefaultRespawnHeightY();
            HasRespawnHeightYModified = false;
            OriginalRespawnHeightY = -100f;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasRespawnHeightYModified)
            {
                OriginalRespawnHeightY = RespawnHeightY;
            }
            if(ForbidUserPortals)
            {
                Log.Debug("This World has User Portals Placement Forbidden! Removing...");
                ForbidUserPortals = false;
            }
        }

        private static bool HasRespawnHeightYModified = false;


        internal static void Set_Scene_RespawnHeightY(float NewRespawnHeightY)
        {
            if(!HasRespawnHeightYModified)
            {
                HasRespawnHeightYModified = true;
            }
            RespawnHeightY = NewRespawnHeightY;
        }

        internal static void Restore_DefaultRespawnHeightY()
        {
            if (HasRespawnHeightYModified)
            {
                RespawnHeightY = OriginalRespawnHeightY;
                HasRespawnHeightYModified = true;
            }

        }

        /// <summary>
        /// This prevents Portal drops from all users.
        /// </summary>
        internal static bool ForbidUserPortals
        {
            get
            {
                if (SDKBaseDescriptor != null)
                {
                    return SDKBaseDescriptor.ForbidUserPortals;
                }
                else if (SDK2Descriptor != null)
                {
                    return SDK2Descriptor.ForbidUserPortals;
                }
                else if (SDK3Descriptor != null)
                {
                    return SDK3Descriptor.ForbidUserPortals;
                }
                else
                {
                    return default;
                }
            }
            set
            {
                if (SDKBaseDescriptor != null)
                {
                    SDKBaseDescriptor.ForbidUserPortals = value;
                }
                else if (SDK2Descriptor != null)
                {
                    SDK2Descriptor.ForbidUserPortals = value;
                }
                else if (SDK3Descriptor != null)
                {
                    SDK3Descriptor.ForbidUserPortals = value;
                }
                RoomUtils.userPortalsForbidden = value;

            }
        }

        public static bool IsDefaultScene(string name)
        {
            var lower = name.ToLower();
            string[] scenes = { "application2", "ui", "empty", "dontdestroyonload", "hideanddontsave", "samplescene" };
            return scenes.Contains(lower);
        }


        internal static Transform[] Spawns
        {
            get
            {
                if (SDKBaseDescriptor != null)
                {
                    if (SDKBaseDescriptor.spawns != null)
                    {
                        return SDKBaseDescriptor.spawns.ToArray();
                    }
                }
                else if (SDK2Descriptor != null)
                {
                    if (SDK2Descriptor.spawns != null)
                    {
                        return SDK2Descriptor.spawns.ToArray();
                    }
                }
                else if (SDK3Descriptor != null)
                {
                    if (SDK3Descriptor.spawns != null)
                    {
                        return SDK3Descriptor.spawns.ToArray();
                    }
                }
                return null;
            }
        }
        internal static Vector3 SpawnPosition
        {
            get
            {
                if (SDKBaseDescriptor != null)
                {
                    return SDKBaseDescriptor.SpawnPosition;
                }
                else if (SDK2Descriptor != null)
                {
                    return SDK2Descriptor.SpawnPosition;
                }
                else if (SDK3Descriptor != null)
                {
                    return SDK3Descriptor.SpawnPosition;
                }
                return default(Vector3);
            }
        }
        internal static Transform SpawnLocation
        {
            get
            {
                if (SDKBaseDescriptor != null)
                {
                    if (SDKBaseDescriptor.SpawnLocation != null)
                    {
                        return SDKBaseDescriptor.SpawnLocation;
                    }
                }
                else if (SDK2Descriptor != null)
                {
                    if (SDK2Descriptor.SpawnLocation != null)
                    {
                        return SDK2Descriptor.SpawnLocation;
                    }
                }
                else if (SDK3Descriptor != null)
                {
                    if (SDK3Descriptor.SpawnLocation != null)
                    {
                        return SDK3Descriptor.SpawnLocation;
                    }
                }
                return null;
            }
        }

        internal static GameObject[] DynamicPrefabs
        {
            get
            {
                if (SDKBaseDescriptor != null)
                {
                    if (SDKBaseDescriptor.DynamicPrefabs != null)
                    {
                        return SDKBaseDescriptor.DynamicPrefabs.ToArray();
                    }
                }
                else if (SDK2Descriptor != null)
                {
                    if (SDK2Descriptor.DynamicPrefabs != null)
                    {
                        return SDK2Descriptor.DynamicPrefabs.ToArray();
                    }
                }
                else if (SDK3Descriptor != null)
                {
                    if (SDK3Descriptor.DynamicPrefabs != null)
                    {
                        return SDK3Descriptor.DynamicPrefabs.ToArray();
                    }
                }
                return null;
            }
        }


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

        // Defaulted to -100f, but let's check the SDK scene descriptors first
        private static float OriginalRespawnHeightY { get; set; } = -100f;

        /// <summary>
        ///  returns RespawnHeightY from Scene descriptor of the current world\
        ///  Editing this will set only the pickup ones, to set the player's one you need to edit VRCPlayer.field_Private_Single_2
        /// </summary>
        internal static float RespawnHeightY
        {
            get
            {
                if (SDKBaseDescriptor != null)
                {
                    return SDKBaseDescriptor.RespawnHeightY;
                }
                else if (SDK2Descriptor != null)
                {
                    return SDK2Descriptor.RespawnHeightY;
                }
                else if (SDK3Descriptor != null)
                {
                    return SDK3Descriptor.RespawnHeightY;
                }
                else
                {
                    return -100f;
                }
            }
            set
            {
                if (SDKBaseDescriptor != null)
                {
                    SDKBaseDescriptor.RespawnHeightY = value;
                }
                else if (SDK2Descriptor != null)
                {
                    SDK2Descriptor.RespawnHeightY = value;
                }
                else if (SDK3Descriptor != null)
                {
                    SDK3Descriptor.RespawnHeightY = value;
                }
            }
        }

        /// <summary>
        /// This handles how the objects are being treated after reaching <seealso cref="RespawnHeightY"/> Limits
        /// </summary>
        internal static VRC_SceneDescriptor.RespawnHeightBehaviour ObjectBehaviourAtRespawnHeight
        {
            get
            {
                if (SDKBaseDescriptor != null)
                {
                    return SDKBaseDescriptor.ObjectBehaviourAtRespawnHeight;
                }
                else if (SDK2Descriptor != null)
                {
                    return SDK2Descriptor.ObjectBehaviourAtRespawnHeight;
                }
                else if (SDK3Descriptor != null)
                {
                    return SDK3Descriptor.ObjectBehaviourAtRespawnHeight;
                }
                else
                {
                    return VRC_SceneDescriptor.RespawnHeightBehaviour.Respawn;
                }
            }
            set
            {
                if (SDKBaseDescriptor != null)
                {
                    SDKBaseDescriptor.ObjectBehaviourAtRespawnHeight = value;
                }
                else if (SDK2Descriptor != null)
                {
                    SDK2Descriptor.ObjectBehaviourAtRespawnHeight = value;
                }
                else if (SDK3Descriptor != null)
                {
                    SDK3Descriptor.ObjectBehaviourAtRespawnHeight = value;
                }
            }
        }
        private static VRC_SceneDescriptor SDKBaseDescriptor => UnityEngine.Object.FindObjectOfType<VRC_SceneDescriptor>();
        private static VRCSDK2.VRC_SceneDescriptor SDK2Descriptor => UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>();
        private static VRC.SDK3.Components.VRCSceneDescriptor SDK3Descriptor => UnityEngine.Object.FindObjectOfType<VRC.SDK3.Components.VRCSceneDescriptor>();

    }
}
