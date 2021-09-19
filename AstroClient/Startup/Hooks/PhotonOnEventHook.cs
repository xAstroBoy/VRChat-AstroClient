namespace AstroClient
{
    #region Imports

    using AstroClient.Features.Player.Movement.Exploit;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using HarmonyLib;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    #endregion Imports

    internal class PhotonOnEventHook : GameEvents
    {
        public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerBlockedYou;
        public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerUnblockedYou;

        public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerMutedYou;
        public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerUnmutedYou;

        private static bool UnblockPatchTest { get; set; } = true;

        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(PhotonOnEventHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        public class Patch
        {
            private static List<Patch> Patches = new List<Patch>();
            public MethodInfo TargetMethod { get; set; }
            public HarmonyMethod PrefixMethod { get; set; }
            public HarmonyMethod PostfixMethod { get; set; }
            public Harmony Instance { get; set; }

            public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
            {
                if (targetMethod == null || (Before == null && After == null))
                {
                    ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
                    return;
                }
                Instance = new Harmony($"Patch:{targetMethod.DeclaringType.FullName}.{targetMethod.Name}");
                TargetMethod = targetMethod;
                PrefixMethod = Before;
                PostfixMethod = After;
                Patches.Add(this);
            }

            public static async void DoPatches()
            {
                for (int i = 0; i < Patches.Count; i++)
                {
                    Patch patch = Patches[i];
                    try
                    {
                        ModConsole.DebugLog($"[Patches] Patching {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {patch.PrefixMethod?.method.Name}{patch.PostfixMethod?.method.Name}");
                        _ = patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
                    }
                    catch (Exception e)
                    {
                        ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
                        ModConsole.ErrorExc(e);
                    }
                }
                ModConsole.DebugLog($"[Patches] Done! Patched {Patches.Count} Methods!");
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

        public override void ExecutePriorityPatches()
        {
            InitPatch();
        }

        private void InitPatch()
        {
            try
            {
                new Patch(typeof(Photon.Realtime.LoadBalancingClient).GetMethod(nameof(Photon.Realtime.LoadBalancingClient.OnEvent)), GetPatch(nameof(OnEvent)));
                Patch.DoPatches();
            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }

        private static void OnEvent(ref EventData __0)
        {
            try
            {
                object DictionaryObj = Serialization.FromIL2CPPToManaged<object>(__0.Parameters);
                Dictionary<byte, object> dictionary = DictionaryObj as Dictionary<byte, object>;
                Dictionary<byte, object> dictionary2 = dictionary[245] as Dictionary<byte, object>;
                int num = int.Parse(dictionary2[0].ToString());
                int photonID = int.Parse(dictionary2[1].ToString());

                if (num == 21)
                {
                    if (dictionary2[10] != null && dictionary2[11] != null)
                    {
                        if (dictionary2.ContainsKey(1))
                        {
                            //int photonID = int.Parse(dictionary2[1].ToString());
                            Player player = PlayerUtils.PlayerManager.GetPlayerIDPhoton(photonID);
                            bool blockedyou = bool.Parse(dictionary2[10].ToString());
                            bool mutedyou = bool.Parse(dictionary2[11].ToString());
                            if (blockedyou)
                            {
                                if (!BlockedYouPlayers.Contains(player))
                                {
                                    BlockedYouPlayers.Add(player);
                                    Event_OnPlayerBlockedYou.SafetyRaise(new VRCPlayerEventArgs(player));
                                }
                                if(UnblockPatchTest)
                                {
                                    dictionary2[11] = false;
                                }

                            }
                            if (!blockedyou && BlockedYouPlayers.Contains(player))
                            {
                                BlockedYouPlayers.Remove(player);
                                Event_OnPlayerUnblockedYou.SafetyRaise(new VRCPlayerEventArgs(player));
                            }
                            if (mutedyou && !MutedYouPlayers.Contains(player))
                            {
                                MutedYouPlayers.Add(player);
                                Event_OnPlayerMutedYou.SafetyRaise(new VRCPlayerEventArgs(player));
                            }
                            if (!mutedyou && MutedYouPlayers.Contains(player))
                            {
                                MutedYouPlayers.Remove(player);
                                Event_OnPlayerUnmutedYou.SafetyRaise(new VRCPlayerEventArgs(player));
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public static List<Player> BlockedYouPlayers { get; private set; } = new List<Player>();

        public static List<Player> MutedYouPlayers { get; private set; } = new List<Player>();

    }
}