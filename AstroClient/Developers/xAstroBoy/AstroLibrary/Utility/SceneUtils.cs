

using System;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
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
            NoFallHeightLimit = false;
            _SDK_Base = null;
            _SDK_2 = null;
            _SDK_3 = null;
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

                if (SDK_2 != null)
                {
                    return SDK_2.ForbidUserPortals;
                }
                else if (SDK_3 != null)
                {
                    return SDK_3.ForbidUserPortals;
                }
                else
                {
                    return default;
                }
            }
            set
            {

                if (SDK_2 != null)
                {
                    SDK_2.ForbidUserPortals = value;
                }
                else if (SDK_3 != null)
                {
                    SDK_3.ForbidUserPortals = value;
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

                if (SDK_2 != null)
                {
                    if (SDK_2.spawns != null)
                    {
                        return SDK_2.spawns.ToArray();
                    }
                }
                else if (SDK_3 != null)
                {
                    if (SDK_3.spawns != null)
                    {
                        return SDK_3.spawns.ToArray();
                    }
                }
                return null;
            }
        }
        internal static Vector3 SpawnPosition
        {
            get
            {

                if (SDK_2 != null)
                {
                    return SDK_2.SpawnPosition;
                }
                else if (SDK_3 != null)
                {
                    return SDK_3.SpawnPosition;
                }
                return default(Vector3);
            }
        }
        internal static Transform SpawnLocation
        {
            get
            {

                if (SDK_2 != null)
                {
                    if (SDK_2.SpawnLocation != null)
                    {
                        return SDK_2.SpawnLocation;
                    }
                }
                else if (SDK_3 != null)
                {
                    if (SDK_3.SpawnLocation != null)
                    {
                        return SDK_3.SpawnLocation;
                    }
                }
                return null;
            }
        }

        internal static GameObject[] DynamicPrefabs
        {
            get
            {
                if (SDK_2 != null)
                {
                    if (SDK_2.DynamicPrefabs != null)
                    {
                        return SDK_2.DynamicPrefabs.ToArray();
                    }
                }
                else if (SDK_3 != null)
                {
                    if (SDK_3.DynamicPrefabs != null)
                    {
                        return SDK_3.DynamicPrefabs.ToArray();
                    }
                }
                return null;
            }
        }


        public static int SDKVersion
        {
            get
            {
                if (SDK_2 != null)
                    return 2;
                else if (SDK_3 != null)
                    return 3;
                else
                    return 1;
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
                if (SDK_2 != null)
                {
                    return SDK_2.RespawnHeightY;
                }
                else if (SDK_3 != null)
                {
                    return SDK_3.RespawnHeightY;
                }
                else
                {
                    return -100f;
                }
            }
            set
            { 
                if (SDK_2 != null)
                {
                    SDK_2.RespawnHeightY = value;
                }
                else if (SDK_3 != null)
                {
                    SDK_3.RespawnHeightY = value;
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
                 if (SDK_2 != null)
                {
                    return SDK_2.ObjectBehaviourAtRespawnHeight;
                }
                else if (SDK_3 != null)
                {
                    return SDK_3.ObjectBehaviourAtRespawnHeight;
                }
                else
                {
                    return VRC_SceneDescriptor.RespawnHeightBehaviour.Respawn;
                }
            }
            set
            { 
                if (SDK_2 != null)
                {
                    SDK_2.ObjectBehaviourAtRespawnHeight = value;
                }
                else if (SDK_3 != null)
                {
                    SDK_3.ObjectBehaviourAtRespawnHeight = value;
                }
            }
        }
        private static VRC_SceneDescriptor _SDK_Base = null;
        internal static VRC_SceneDescriptor SDK_Base
        {
            get
            {
                if (_SDK_Base == null)
                {
                    return _SDK_Base = UnityEngine.Object.FindObjectOfType<VRC_SceneDescriptor>();
                }
                return _SDK_Base;
            }
        }

        private static VRCSDK2.VRC_SceneDescriptor _SDK_2 = null;
        internal static VRCSDK2.VRC_SceneDescriptor SDK_2
        {
            get
            {
                if(_SDK_2 == null)
                {
                   return _SDK_2 = UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>(); 
                }
                return _SDK_2;
            }
        }

        private static VRC.SDK3.Components.VRCSceneDescriptor _SDK_3 = null;
        internal static VRC.SDK3.Components.VRCSceneDescriptor SDK_3
        {
            get
            {
                if (_SDK_3 == null)
                {
                    return _SDK_3 = UnityEngine.Object.FindObjectOfType<VRC.SDK3.Components.VRCSceneDescriptor>();
                }
                return _SDK_3;
            }
        }


        private static bool _NoFallHeightLimit = false;

        internal static bool NoFallHeightLimit
        {
            get => _NoFallHeightLimit;
            set
            {
                if (GameInstances.CurrentUser != null)
                {
                    if (value)
                    {
                        // this is more than enought lol
                        SceneUtils.Set_Scene_RespawnHeightY(-99999);
                        GameInstances.CurrentUser.Set_RespawnHeightY(-99999);
                    }
                    else
                    {
                        SceneUtils.Restore_DefaultRespawnHeightY();
                        GameInstances.CurrentUser.Set_RespawnHeightY(SceneUtils.RespawnHeightY);
                    }
                }
                else
                {
                    value = false;
                }
                _NoFallHeightLimit = value;
                if (ToggleNoFallHeightLimiter != null)
                {
                    ToggleNoFallHeightLimiter.SetToggleState(value);
                }
                OnNoFallHeightLimitToggled.SafetyRaise();
            }
        }

        internal static QMToggleButton ToggleNoFallHeightLimiter;
        internal static Action OnNoFallHeightLimitToggled { get; set; }

    }
}
