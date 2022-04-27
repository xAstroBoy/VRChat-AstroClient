﻿namespace AstroClient.Cheetos
{
    #region Imports

    using System;
    using System.Collections;
    using System.Linq;
    using System.Reflection;
    using Cheetah;
    using Constants;
    using HarmonyLib;
    using MelonLoader;
    using Photon.Realtime;
    using UnityEngine;
    using VRC.Core;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using ConfigManager = Config.ConfigManager;
    using Player = Photon.Realtime.Player;
    using Il2CppSystem.Collections;
    using VRC.UI.Elements;


    #endregion Imports

    [ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class CheetosHooks : AstroEvents
    {
        internal static event System.Action<VRCUiPage> Event_OnShowScreen;
        internal static event System.Action<Player> Event_OnPhotonPlayerJoined;
        internal static event System.Action<Player> Event_OnPhotonPlayerLeft;
        internal static event System.Action<Player> Event_OnMasterClientSwitched;
        internal static event System.Action Event_OnRoomLeft;
        internal static event System.Action Event_OnRoomJoined;
        internal static event System.Action<APIUser> Event_OnFriended;
        internal static event System.Action<string> Event_OnUnfriended;
        internal static event System.Action<ApiWorld, ApiWorldInstance> Event_OnEnterWorld;
        internal static event System.Action<VRCPlayer, Il2CppSystem.Collections.Hashtable> Event_OnSetupFlagsReceived;
        internal static event System.Action Event_OnShowSocialRankChanged;
        internal static event System.Action<AvatarLoadingBar, float, long> Event_OnAvatarDownloadProgress;
        internal static event System.Action<VRCAvatarManager, ApiAvatar, GameObject> Event_OnAvatarInstantiated;


        [ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(CheetosHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            try
            {
                //new AstroPatch(typeof(AssetBundleDownloadManager).GetMethod(nameof(AssetBundleDownloadManager.Method_Internal_Void_ApiAvatar_PDM_0)), GetPatch(nameof(OnAvatarDownload)));
                new AstroPatch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
                new AstroPatch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));
                new AstroPatch(typeof(VRCUiManager).GetMethod(XrefTesting.ShowScreenMethod.Name), GetPatch(nameof(OnShowScreenPatch)));
                new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnMasterClientSwitched)), GetPatch(nameof(OnMasterClientSwitchedPatch)));
                new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnLeftRoom)), GetPatch(nameof(OnRoomLeftPatch)));
                new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedRoom)), GetPatch(nameof(OnRoomJoinedPatch)));
                //new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnLeftLobby)), GetPatch(nameof(OnLobbyLeftPatch)));
                //new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedLobby)), GetPatch(nameof(OnLobbyJoinedPatch)));
                //new AstroPatch(typeof(PortalInternal).GetMethod(nameof(PortalInternal.ConfigurePortal)), GetPatch(nameof(OnConfigurePortal)));
                //new AstroPatch(typeof(PortalInternal).GetMethod(nameof(PortalInternal.Method_Public_Void_0)), GetPatch(nameof(OnEnterPortal)));
                //new AstroPatch(typeof(PlayerNameplate).GetMethod(nameof(PlayerNameplate.Method_Private_Void_1)), GetPatch(nameof(NameplatePatch)));
                new AstroPatch(typeof(APIUser).GetMethod(nameof(APIUser.LocalAddFriend)), GetPatch(nameof(OnFriended)));
                new AstroPatch(typeof(APIUser).GetMethod(nameof(APIUser.UnfriendUser)), GetPatch(nameof(OnUnfriended)));
                //new AstroPatch(AccessTools.Property(typeof(APIUser), nameof(APIUser.canSeeAllUsersStatus)).GetMethod, null, GetPatch(nameof(APIUserBypassTrue)));
                //new AstroPatch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasScriptingAccess)).GetMethod, null, GetPatch(nameof(APIUserBypassTrue)));
                //new AstroPatch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasVIPAccess)).GetMethod, null, GetPatch(nameof(APIUserBypassTrue)));
                //new AstroPatch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasNoPowers)).GetMethod, null, GetPatch(nameof(APIUserBypassFalse)));
                //new AstroPatch(AccessTools.Property(typeof(APIUser), nameof(APIUser.developerType)).GetMethod, null, GetPatch(nameof(APIUserDeveloper)));

                //new AstroPatch(AccessTools.Property(typeof(Time), nameof(Time.smoothDeltaTime)).GetMethod, null, GetPatch(nameof(SpoofFPS)));
                //new AstroPatch(AccessTools.Property(typeof(PhotonPeer), nameof(PhotonPeer.RoundTripTime)).GetMethod, null, GetPatch(nameof(SpoofPing)));
                //new AstroPatch(AccessTools.Property(typeof(Tools), nameof(Tools.Platform)).GetMethod, null, GetPatch(nameof(SpoofQuest)));

                new AstroPatch(typeof(Cursor).GetProperty(nameof(Cursor.lockState)).GetSetMethod(), GetPatch(nameof(MousePatch)));

                //new AstroPatch(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.Method_Public_Boolean_String_Object_Boolean_PDM_0)), GetPatch(nameof(LoadBalancingClient_OpWebRpc)));
                new AstroPatch(typeof(VRCPlayer).GetMethods().First((MethodInfo mb) => mb.Name.StartsWith("Awake")), null, GetPatch(nameof(OnPlayerAwake)));

                new AstroPatch(typeof(APIUser).GetMethod(nameof(APIUser.UnfriendUser)), GetPatch(nameof(OnUnfriended)));

                typeof(RoomManager).GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .Where(m => m.Name.StartsWith("Method_Public_Static_Boolean_ApiWorld_ApiWorldInstance_String_Int32_"))
                    .ToList().ForEach(m => new AstroPatch(m, GetPatch(nameof(OnEnterWorldEvent))));
                MethodInfo SetupFlagsMethod = typeof(VRCPlayer).GetMethods().First((MethodInfo mi) => mi.Name.StartsWith("Method_Public_Void_Hashtable_Boolean_"));
                new AstroPatch(SetupFlagsMethod, null, GetPatch(nameof(Internal_OnSetupFlagsReceived)));

                foreach (MethodInfo OnSocialRankChangedMethod in from method in typeof(ProfileWingMenu).GetMethods()
                                                                 where method.Name.StartsWith("Method_Private_Void_Boolean_")
                                                                 select method)
                {
                    new AstroPatch(OnSocialRankChangedMethod, null, GetPatch(nameof(Internal_OnShowSocialRankChanged)));
                }
                foreach (MethodInfo OnAvatarDownloadMethod in from mb in typeof(AvatarLoadingBar).GetMethods()
                                                              where mb.Name.Contains("Method_Public_Void_Single_Int64_")
                                                              select mb)
                {
                    new AstroPatch(OnAvatarDownloadMethod, GetPatch(nameof(Internal_OnAvatarDownloadProgress)));

                }

            }
            catch (Exception e)
            {
                Log.Error($"{ConsoleUtils.ForegroundColor(Cheetah.Color.HTML.Yellow)}[Cheetos Patches]{ConsoleUtils.ForegroundColor(Cheetah.Color.HTML.Red)} Error in applying patches : {e}");
            }
            finally
            {
                Log.Debug($"{ConsoleUtils.ForegroundColor(Cheetah.Color.HTML.Yellow)}[Cheetos' Patches]{ConsoleUtils.ForegroundColor(Cheetah.Color.HTML.Green)} Patches applied!");
            }
        }

        private static void OnPlayerAwake(VRCPlayer __instance)
        {
            __instance.Method_Public_add_Void_OnAvatarIsReady_0(new Action(()
                => OnAvatarInstantiate(__instance.prop_VRCAvatarManager_0, __instance.field_Private_ApiAvatar_0, __instance.field_Internal_GameObject_0))
            );
        }


        private static void OnAvatarInstantiate(VRCAvatarManager manager, ApiAvatar apiAvatar, GameObject avatar)
        {
            if (manager == null || apiAvatar == null || avatar == null)
            {
                return;
            }
            Event_OnAvatarInstantiated.SafetyRaiseWithParams(manager, apiAvatar, avatar);
        }


        private static bool NameplatePatch(PlayerNameplate __instance) => false;

        private static void MousePatch(ref bool __0)
        {
            if (!WorldUtils.IsInWorld)
            {
                __0 = false;
            }
        }

        private static void Internal_OnSetupFlagsReceived(VRCPlayer __instance, Il2CppSystem.Collections.Hashtable __0)
        {
            if (__0 == null)
            {
                return;
            }
            Event_OnSetupFlagsReceived.SafetyRaiseWithParams(__instance, __0);

        }


        private static void Internal_OnShowSocialRankChanged()
        {
            Event_OnShowSocialRankChanged.SafetyRaise();
        }

        private static void OnEnterWorldEvent(ApiWorld __0, ApiWorldInstance __1) => Event_OnEnterWorld.SafetyRaiseWithParams(__0, __1);

        private static void OnMasterClientSwitchedPatch(Player __0) => Event_OnMasterClientSwitched?.SafetyRaiseWithParams(__0);

        private static void OnFriended(ref APIUser __0) => Event_OnFriended?.SafetyRaiseWithParams(__0);

        private static void OnUnfriended(ref string __0, ref Action __1, ref Action __2) => Event_OnUnfriended?.SafetyRaiseWithParams(__0);


        private static void OnRoomLeftPatch() => Event_OnRoomLeft?.SafetyRaise();

        private static void OnRoomJoinedPatch() => Event_OnRoomJoined?.SafetyRaise();

        private static bool LoadBalancingClient_OpWebRpc(LoadBalancingClient __instance, ref string __0, ref object __1, ref bool __2)
        {
            string text = $"LoadBalancingClient_OpWebRpc: {__0}, ";
            if (__1 != null)
            {
                string str = text;
                object obj = __1;
                Log.Debug($"{str}{obj}, {__2.ToString()}");
            }
            else
            {
                Log.Debug($"{text}null, {__2.ToString()}");
            }

            return true;
        }
        private static void APIUserBypassFalse(APIUser __instance, ref bool __result)
        {
            if (__instance.IsSelf)
            {
                __result = false;
            }
        }
        private static void APIUserDeveloper(APIUser __instance, ref APIUser.DeveloperType __result)
        {
            if (__instance.IsSelf)
            {
                __result = APIUser.DeveloperType.Internal;
            }
        }

        private static void APIUserBypassTrue(APIUser __instance, ref bool __result)
        {
            if (__instance.IsSelf)
            {
                __result = true;
            }
        }

        private static bool OnShowScreenPatch(ref VRCUiPage __0)
        {
            if (__0 != null)
            {
                Event_OnShowScreen?.SafetyRaiseWithParams(__0);
            }

            return true;
        }

        private static bool OnConfigurePortal(PortalInternal __instance, ref string __0, ref string __1, ref int __2, ref VRC.Player __3)
        {

            Log.Write($"Portal Spawned: {__instance.name}: {__3.DisplayName()}");
            PopupUtils.QueHudMessage($"Portal Spawned: {__instance.name}: {__3.DisplayName()}");
            return true;
        }

        private static bool OnEnterPortal(PortalInternal __instance)
        {
            if (Bools.AntiPortal)
            {
                Log.Write($"{__instance.name}: Portal Entry Blocked!");
                return false;
            }

            Log.Write($"{__instance.name}: Portal Entered");
            return true;
        }

        private static void SpoofQuest(ref string __result)
        {
            try
            {
                if (ConfigManager.General.SpoofQuest && !WorldUtils.IsInWorld)
                {
                    __result = "android";
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
        }

        private static void SpoofPing(ref int __result)
        {
            try
            {
                if (ConfigManager.General.SpoofPing && WorldUtils.IsInWorld)
                {
                    Temporary.RealPing = __result;
                    __result = ConfigManager.General.SpoofedPing;
                }
            }
            catch
            {
            }
        }

        private static void SpoofFPS(ref float __result)
        {
            try
            {
                if (ConfigManager.General.SpoofFPS && WorldUtils.IsInWorld)
                {
                    Temporary.RealFPS = __result;
                    __result = 1f / ConfigManager.General.SpoofedFPS;
                }
            }
            catch
            {
            }
        }

        private static void Internal_OnAvatarDownloadProgress(AvatarLoadingBar __instance, float __0, long __1)
        {
            Event_OnAvatarDownloadProgress.SafetyRaiseWithParams(__instance, __0, __1);
        }

        //private static bool OnAvatarDownload(ref ApiAvatar __0)
        //{
        //    try
        //    {
        //        if (__0 != null)
        //        {
        //            var avatarData = new AvatarData
        //            {
        //                AssetURL = __0.assetUrl,
        //                AuthorID = __0.authorId,
        //                AuthorName = __0.authorName,
        //                Description = __0.description,
        //                AvatarID = __0.id,
        //                ImageURL = __0.imageUrl,
        //                ThumbnailURL = __0.thumbnailImageUrl,
        //                Name = __0.name,
        //                ReleaseStatus = __0.releaseStatus,
        //                Version = __0.version,
        //                SupportedPlatforms = __0.supportedPlatforms.ToString()
        //            };

        //            if (avatarData != null)
        //            {
        //                var json = JsonConvert.SerializeObject(avatarData);
        //                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_DATA, json));
        //                //Log.Write(json);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }

        //    return true;
        //}

        private static void OnPhotonPlayerJoin(ref Player __0)
        {
            Event_OnPhotonPlayerJoined?.SafetyRaiseWithParams(__0);
        }

        private static void OnPhotonPlayerLeft(ref Player __0)
        {
            Event_OnPhotonPlayerLeft?.SafetyRaiseWithParams(__0);
        }
    }
}