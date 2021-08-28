namespace AstroClient.Cheetos
{
    #region Imports

    using AstroClient.Variables;
    using AstroClientCore.Events;
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
    using System.Reflection;
    using UnhollowerBaseLib;
    using UnityEngine;
    using VRC;
    using VRC.Core;

    #endregion Imports

    internal class CheetosHooks : GameEvents
    {
        public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonJoin;

        public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonLeft;

        public class Patch
        {
            private static List<Patch> Patches = new List<Patch>();
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
                foreach (var patch in Patches)
                {
                    try
                    {
                        ModConsole.DebugLog($"[Patches] Patching {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {patch.PrefixMethod?.method.Name}{patch.PostfixMethod?.method.Name}");
                        patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
                    }
                    catch (Exception e)
                    {
                        ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
                        ModConsole.Error(e.Message);
                        ModConsole.ErrorExc(e);
                    }
                }
                ModConsole.DebugLog($"[Patches] Done! Patched {Patches.Count} Methods!");
            }

            public static async void UnDoPatches()
            {
                foreach (var patch in Patches)
                {
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
                ModConsole.Log("[AstroClient Cheetos Patches] Start. . .");

                new Patch(typeof(AssetBundleDownloadManager).GetMethod(nameof(AssetBundleDownloadManager.Method_Internal_Void_ApiAvatar_PDM_0)), GetPatch(nameof(OnAvatarDownload)));
                new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
                new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));
                new Patch(typeof(PortalInternal).GetMethod(nameof(PortalInternal.ConfigurePortal)), GetPatch(nameof(OnConfigurePortal)));
                new Patch(typeof(PortalInternal).GetMethod(nameof(PortalInternal.Method_Public_Void_0)), GetPatch(nameof(OnEnterPortal)));
                //new Patch(typeof(APIUser).GetMethod(nameof(APIUser.developerType)), null, GetPatch(nameof(APIUserBypass3)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.canSeeAllUsersStatus)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasModerationPowers)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasScriptingAccess)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasSuperPowers)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasVIPAccess)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.isEarlyAdopter)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.isSupporter)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.canSetStatusOffline)).GetMethod, GetPatch(nameof(APIUserBypass)));
                new Patch(AccessTools.Property(typeof(APIUser), nameof(APIUser.hasNoPowers)).GetMethod, GetPatch(nameof(APIUserBypass2)));
                new Patch(AccessTools.Property(typeof(Time), nameof(Time.smoothDeltaTime)).GetMethod, null, GetPatch(nameof(SpoofFPS)));
                new Patch(AccessTools.Property(typeof(PhotonPeer), nameof(PhotonPeer.RoundTripTime)).GetMethod, null, GetPatch(nameof(SpoofPing)));
                new Patch(AccessTools.Property(typeof(Tools), nameof(Tools.Platform)).GetMethod, null, GetPatch(nameof(SpoofQuest)));

                // Experiments
                new Patch(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.Method_Public_Boolean_String_Object_Boolean_PDM_0)), GetPatch(nameof(LoadBalancingClient_OpWebRpc)));

                ModConsole.Log("[Client Cheetos Patches] DONE!");
                Patch.DoPatches();
            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }

        private static bool LoadBalancingClient_OpWebRpc(LoadBalancingClient __instance, ref string __0, ref object __1, ref bool __2)
        {
            string text = "LoadBalancingClient_OpWebRpc: " + __0 + ", ";
            if (__1 != null)
            {
                string str = text;
                object obj = __1;
                ModConsole.Log(str + ((obj != null) ? obj.ToString() : null) + ", " + __2.ToString());
            }
            else
            {
                ModConsole.Log(text + "null, " + __2.ToString());
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

        private static void APIUserBypass2(APIUser __instance, ref bool __result)
        {
            if (__instance.IsSelf)
            {
                __result = false;
            }
        }

        private static bool OnConfigurePortal(PortalInternal __instance, ref string __0, ref string __1, ref int __2, ref VRC.Player __3)
        {
            ModConsole.Log($"Portal Spawned: {__0}, {__1}, {__2}, {__3.DisplayName()}");
            return true;
        }

        private static bool OnEnterPortal(PortalInternal __instance)
        {
            if (Bools.AntiPortal)
            {
                ModConsole.Log("Portal Entry Blocked!");
                return false;
            }
            else
            {
                ModConsole.Log($"Portal Entered");
                return true;
            }
        }

        private static bool OnTestPatch(ref Il2CppStructArray<bool> __0)
        {
            ModConsole.Log("Test!");
            return true;
        }

        private static void SpoofQuest(ref string __result)
        {
            try
            {
                if (AstroClient.ConfigManager.General.SpoofQuest)
                {
                    if (!WorldUtils.IsInWorld())
                    {
                        __result = "android";
                    }
                }
            }
            catch
            {
            }
        }

        private static void SpoofPing(ref int __result)
        {
            try
            {
                if (AstroClient.ConfigManager.General.SpoofPing && WorldUtils.IsInWorld())
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
                if (AstroClient.ConfigManager.General.SpoofFPS && WorldUtils.IsInWorld())
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
                Event_OnPhotonJoin.Invoke(__0, new PhotonPlayerEventArgs(__0));
            }
            else
            {
                ModConsole.Error($"[Photon] OnPhotonPlayerJoin Failed! __0 was null.");
            }
        }

        private static void OnPhotonPlayerLeft(ref Photon.Realtime.Player __0)
        {
            if (__0 != null)
            {
                if (Event_OnPhotonLeft != null)
                {
                    Event_OnPhotonLeft.Invoke(__0, new PhotonPlayerEventArgs(__0));
                }
            }
            else
            {
                ModConsole.Error($"[Photon] OnPhotonPlayerLeft Failed! __0 was null.");
            }
        }
    }
}