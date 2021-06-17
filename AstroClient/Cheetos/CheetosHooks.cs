namespace AstroClient.Cheetos
{
	using AstroClient.Variables;
	#region Imports

	using AstroClientCore.Events;
	using AstroLibrary.Console;
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility;
	using ExitGames.Client.Photon;
	using Harmony;
	using MelonLoader;
	using Newtonsoft.Json;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using UnhollowerBaseLib;
	using UnityEngine;
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
            public HarmonyInstance Instance { get; set; }

            public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
            {
                if (targetMethod == null || (Before == null && After == null))
                {
                    ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
                    return;
                }
                Instance = HarmonyInstance.Create($"Patch:{targetMethod.DeclaringType.FullName}.{targetMethod.Name}");
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
                new Patch(AccessTools.Property(typeof(Time), nameof(Time.smoothDeltaTime)).GetMethod, null, GetPatch(nameof(SpoofFPS)));
                new Patch(AccessTools.Property(typeof(PhotonPeer), nameof(PhotonPeer.RoundTripTime)).GetMethod, null, GetPatch(nameof(SpoofPing)));

                //new Patch(typeof(VRCStandaloneInputModule).GetMethod(XrefTesting.OnTest.Name), GetPatch(nameof(OnTestPatch)));

                ModConsole.DebugLog("[Client Cheetos Patches] DONE!");
                Patch.DoPatches();
            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }

        private static bool OnTestPatch(ref Il2CppStructArray<bool> __0)
        {
            ModConsole.Log("Test!");
            return true;
        }

        private static void SpoofPing(ref int __result)
        {
            try
            {
                if (AstroClient.ConfigManager.General.SpoofPing)
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
                if (AstroClient.ConfigManager.General.SpoofFPS)
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