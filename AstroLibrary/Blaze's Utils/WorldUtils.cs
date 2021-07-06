﻿namespace Blaze.Utils
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
        public static IEnumerable<Player> GetPlayers()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
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
            foreach (Player p in GetPlayers())
            {
                if (p._vrcplayer.IsInstanceMaster())
                {
                    return p._vrcplayer;
                }
            }
            return null;
        }

        public static ApiWorld GetCurrentWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0;
        }

        public static ApiWorldInstance GetCurrentInstance()
        {
            return RoomManager.field_Internal_Static_ApiWorldInstance_0;
        }

        public static bool IsInWorld()
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null) return true;
            else return false;
        }

        public static string GetWorldID()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0.id;
        }

        public static string GetFullID()
        {
            return $"{RoomManager.field_Internal_Static_ApiWorld_0.id}#{RoomManager.field_Internal_Static_ApiWorldInstance_0.id}";
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
                Logs.Debug("<color=red>INVALID JOIN ID!</color>");
                Logs.Msg("INVALID JOIN ID!", ConsoleColor.Red);
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
                //Logs.Debug("<color=red>INVALID WORLD ID!</color>");
                Logs.Msg("INVALID WORLD ID!", ConsoleColor.Red);
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
            if (scenes.Contains(lower))
                return true;
            else return false;
        }

        public static VRCSDK2.VRC_SceneDescriptor GetSDK2Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>();
        }

        public static VRC.SDK3.Components.VRCSceneDescriptor GetSDK3Descriptor()
        {
            return UnityEngine.Object.FindObjectOfType<VRC.SDK3.Components.VRCSceneDescriptor>();
        }

        public static VRC_Pickup[] GetPickups()
        {
            return Resources.FindObjectsOfTypeAll<VRC_Pickup>();
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