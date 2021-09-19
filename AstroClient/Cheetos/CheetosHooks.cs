namespace AstroClient.Cheetos
{
    #region Imports

    using AstroClient.Variables;
    using AstroClientCore.Events;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using DayClientML2.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using MelonLoader;
    using Newtonsoft.Json;
    using Photon.Realtime;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using UnityEngine;
    using VRC;
    using VRC.Core;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class CheetosHooks : GameEvents
    {
        public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonJoin { get; set; }
        public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonLeft { get; set; }
        public static EventHandler<PhotonPlayerEventArgs> Event_OnMasterClientSwitched { get; set; }
        public static EventHandler<EventArgs> Event_OnRoomLeft { get; set; }
        public static EventHandler<EventArgs> Event_OnRoomJoined { get; set; }
        public static EventHandler<EventArgs> Event_OnFriended { get; set; }
        public static EventHandler<EventArgs> Event_OnUnfriended { get; set; }
        public static EventHandler<EventArgs> Event_OnAvatarPageOpen { get; set; }
        public static EventHandler<EventArgs> Event_OnQuickMenuOpen { get; set; }
        public static EventHandler<EventArgs> Event_OnQuickMenuClose { get; set; }

        public class Patch
        {
            public static List<Patch> Patches { get; set; } = new List<Patch>();
            public MethodInfo TargetMethod { get; set; }
            public HarmonyMethod PrefixMethod { get; set; }
            public HarmonyMethod PostfixMethod { get; set; }
            public HarmonyLib.Harmony Instance { get; set; }

            public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
            {
                if (targetMethod == null || (Before == null && After == null))
                {
                    ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
                    return;
                }
                Instance = new HarmonyLib.Harmony($"Patch:{targetMethod.DeclaringType.FullName}.{targetMethod.Name}");
                TargetMethod = targetMethod;
                PrefixMethod = Before;
                PostfixMethod = After;
                Patches.Add(this);
            }

            public static async void DoPatches()
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < Patches.Count; i++)
                {
                    Patch patch = Patches[i];
                    try
                    {
                        patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
                    }
                    catch (Exception e)
                    {
                        ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
                        ModConsole.Error(e.Message);
                        ModConsole.ErrorExc(e);
                    }
                    finally
                    {
                        ModConsole.DebugLog($"[Patches] Patched {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {patch.PrefixMethod?.method.Name}{patch.PostfixMethod?.method.Name}");
                    }
                }

                stopwatch.Stop();
                ModConsole.DebugLog($"[Patches] Done! Patched {Patches.Count} Methods: {stopwatch.ElapsedMilliseconds}ms");
            }

            public static async void UnDoPatches()
            {
                for (int i = 0; i < Patches.Count; i++)
                {
                    Patch patch = Patches[i];
                    try
                    {
                        patch.Instance.UnpatchAll();
                    }
                    catch (Exception e)
                    {
                        ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | {patch.PostfixMethod?.method.Name}");
                        ModConsole.ErrorExc(e);
                    }
                }
                ModConsole.DebugLog($"[Patches] Done! UnPatched {Patches.Count} Methods!");
            }
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(CheetosHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        public override void ExecutePriorityPatches()
        {
            MelonCoroutines.Start(Init());
        }

        private IEnumerator Init()
        {
            InitPatch();
            yield break;
        }

        public static async void InitPatch()
        {
            try
            {
                ModConsole.Log("[Cheetos Patches] Appying Patches.");
                new Patch(typeof(AssetBundleDownloadManager).GetMethod(nameof(AssetBundleDownloadManager.Method_Internal_Void_ApiAvatar_PDM_0)), GetPatch(nameof(OnAvatarDownload)));
                new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
                new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));
                new Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnMasterClientSwitched)), GetPatch(nameof(OnMasterClientSwitchedPatch)));
                new Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnLeftRoom)), GetPatch(nameof(OnRoomLeftPatch)));
                new Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedRoom)), GetPatch(nameof(OnRoomJoinedPatch)));
                new Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnLeftLobby)), GetPatch(nameof(OnLobbyLeftPatch)));
                new Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedLobby)), GetPatch(nameof(OnLobbyJoinedPatch)));
                new Patch(typeof(PortalInternal).GetMethod(nameof(PortalInternal.ConfigurePortal)), GetPatch(nameof(OnConfigurePortal)));
                new Patch(typeof(PortalInternal).GetMethod(nameof(PortalInternal.Method_Public_Void_0)), GetPatch(nameof(OnEnterPortal)));
                new Patch(typeof(PlayerNameplate).GetMethod(nameof(PlayerNameplate.Method_Private_Void_1)), GetPatch(nameof(NameplatePatch)));
                new Patch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.Method_Private_Void_Boolean_0)), GetPatch(nameof(QuickMenuPatch)));
                new Patch(typeof(APIUser).GetMethod(nameof(APIUser.LocalAddFriend)), GetPatch(nameof(OnFriended)));
                new Patch(typeof(APIUser).GetMethod(nameof(APIUser.UnfriendUser)), GetPatch(nameof(OnUnfriended)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.canSeeAllUsersStatus)).GetMethod, null, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasScriptingAccess)).GetMethod, null, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasVIPAccess)).GetMethod, null, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(Time), nameof(Time.smoothDeltaTime)).GetMethod, null, GetPatch(nameof(SpoofFPS)));
                new Patch(AccessTools.Property(typeof(PhotonPeer), nameof(PhotonPeer.RoundTripTime)).GetMethod, null, GetPatch(nameof(SpoofPing)));
                new Patch(AccessTools.Property(typeof(Tools), nameof(Tools.Platform)).GetMethod, null, GetPatch(nameof(SpoofQuest)));
                new Patch(typeof(Cursor).GetProperty(nameof(Cursor.lockState)).GetSetMethod(), GetPatch(nameof(MousePatch)), null);

                // Experiments
                new Patch(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.Method_Public_Boolean_String_Object_Boolean_PDM_0)), GetPatch(nameof(LoadBalancingClient_OpWebRpc)));

                ModConsole.Log($"[Cheetos Patches] Done patching {Patch.Patches.Count} methods!");
                Patch.DoPatches();
            }
            catch (Exception e) { ModConsole.Error($"[Cheetos Patches] Error in applying patches : {e}"); }
            finally { }
        }

        private static bool NameplatePatch(PlayerNameplate __instance) => false;

        private static void MousePatch(ref bool __0)
        {
            if (!WorldUtils.IsInWorld)
            {
                __0 = false;
            }
        }

        private static void OnMasterClientSwitchedPatch(Photon.Realtime.Player __0) => Event_OnMasterClientSwitched?.SafetyRaise(new PhotonPlayerEventArgs(__0));

        private static void OnFriended(ref APIUser __0) => Event_OnFriended?.SafetyRaise(new EventArgs());

        private static void OnUnfriended(ref string __0, ref Il2CppSystem.Action __1, ref Il2CppSystem.Action __2) => Event_OnUnfriended?.SafetyRaise(new EventArgs());

        private static void OnLobbyLeftPatch() => ModConsole.Log("Lobby Left.");

        private static void OnLobbyJoinedPatch() => ModConsole.Log("Lobby Joined.");

        private static void OnRoomLeftPatch() => Event_OnRoomLeft?.SafetyRaise(new EventArgs());

        private static void OnRoomJoinedPatch() => Event_OnRoomJoined?.SafetyRaise(new EventArgs());

        private static bool LoadBalancingClient_OpWebRpc(LoadBalancingClient __instance, ref string __0, ref object __1, ref bool __2)
        {
            string text = $"LoadBalancingClient_OpWebRpc: {__0}, ";
            if (__1 != null)
            {
                string str = text;
                object obj = __1;
                ModConsole.Log($"{str}{obj?.ToString()}, {__2.ToString()}");
            }
            else
            {
                ModConsole.Log($"{text}null, {__2.ToString()}");
            }
            return true;
        }

        private static void APIUserBypass(APIUser __instance, ref bool __result)
        {
            if (__instance.IsSelf)
            {
                __result = true;
            }
        }

        private static bool QuickMenuPatch(ref QuickMenu __instance, ref bool __0)
        {
            if (!__0)
            {
                Event_OnQuickMenuOpen?.SafetyRaise(new EventArgs());
            }
            else
            {
                Event_OnQuickMenuClose?.SafetyRaise(new EventArgs());
            }

            return true;
        }

        private static bool OnConfigurePortal(PortalInternal __instance, ref string __0, ref string __1, ref int __2, ref VRC.Player __3)
        {
            ModConsole.Log($"Portal Spawned: {__instance.name}: {__0}, {__1}, {__2}, {__3.DisplayName()}");
            var worldId = __0;

            if (!worldId.StartsWith("wrld_"))
            {
                ModConsole.Log("Blocking Bad Portal Spawn: Bad World ID");
                CheetosHelpers.SendHudNotification("Blocking Bad Portal Spawn: Bad World ID");
                return false;
            }
            return true;
        }

        private static bool OnEnterPortal(PortalInternal __instance)
        {
            if (Bools.AntiPortal)
            {
                ModConsole.Log($"{__instance.name}: Portal Entry Blocked!");
                return false;
            }
            else
            {
                ModConsole.Log($"{__instance.name}: Portal Entered");
                return true;
            }
        }

        private static void SpoofQuest(ref string __result)
        {
            try
            {
                if (AstroClient.ConfigManager.General.SpoofQuest && !WorldUtils.IsInWorld)
                {
                    __result = "android";
                }
            }
            catch (Exception e)
            {
                ModConsole.LogExc(e);
            }
        }

        private static void SpoofPing(ref int __result)
        {
            try
            {
                if (AstroClient.ConfigManager.General.SpoofPing && WorldUtils.IsInWorld)
                {
                    Temporary.RealPing = __result;
                    __result = AstroClient.ConfigManager.General.SpoofedPing;
                    return;
                }
            }
            catch { }
        }

        private static void SpoofFPS(ref float __result)
        {
            try
            {
                if (AstroClient.ConfigManager.General.SpoofFPS && WorldUtils.IsInWorld)
                {
                    Temporary.RealFPS = __result;
                    __result = (float)1f / AstroClient.ConfigManager.General.SpoofedFPS;
                    return;
                }
            }
            catch { }
        }

        private static bool OnAvatarDownload(ref ApiAvatar __0)
        {
            try
            {
                if (__0 != null)
                {
                    var avatarData = new AvatarData()
                    {
                        AssetURL = __0.assetUrl,
                        AuthorID = __0.authorId,
                        AuthorName = __0.authorName,
                        Description = __0.description,
                        AvatarID = __0.id,
                        ImageURL = __0.imageUrl,
                        ThumbnailURL = __0.thumbnailImageUrl,
                        Name = __0.name,
                        ReleaseStatus = __0.releaseStatus,
                        Version = __0.version,
                        SupportedPlatforms = __0.supportedPlatforms.ToString()
                    };

                    if (avatarData != null)
                    {
                        var json = JsonConvert.SerializeObject(avatarData);
                        AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_DATA, json));
                    }
                }
            }
            catch { }

            return true;
        }

        private static void OnPhotonPlayerJoin(ref Photon.Realtime.Player __0)
        {
            if (__0 != null)
            {
                Event_OnPhotonJoin?.SafetyRaise(new PhotonPlayerEventArgs(__0));
            }
            else
            {
                ModConsole.Error($"[Photon] OnPhotonPlayerJoin Failed! __0 was null.");
            }
        }

        private static void OnPhotonPlayerLeft(ref Photon.Realtime.Player __0)
        {
            if (__0 != null && Event_OnPhotonLeft != null)
            {
                Event_OnPhotonLeft?.SafetyRaise(new PhotonPlayerEventArgs(__0));
            }
            else
            {
                ModConsole.Error($"[Photon] OnPhotonPlayerLeft Failed! __0 was null.");
            }
        }
    }
}
