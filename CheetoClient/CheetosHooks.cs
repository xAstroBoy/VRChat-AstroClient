namespace CheetoClient
{
    #region Imports

    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using DayClientML2.Utility;
    using Harmony;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    #endregion Imports

    [Obfuscation(Feature = "HarmonyRenamer")]
    internal class CheetosHooks
    {
        public static EventHandler<EventArgs> Event_OnPhotonJoin { get; set; }
        public static EventHandler<EventArgs> Event_OnPhotonLeft { get; set; }

        public class Patch
        {
            public static List<Patch> Patches { get; set; } = new List<Patch>();
            public MethodInfo TargetMethod { get; set; }
            public HarmonyMethod PrefixMethod { get; set; }
            public HarmonyMethod PostfixMethod { get; set; }
            public HarmonyLib.Harmony Instance { get; set; }

            public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
            {
                if (targetMethod == null || Before == null && After == null)
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

        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(CheetosHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        public static void ExecutePriorityPatches()
        {
            MelonCoroutines.Start(Init());
        }

        private static IEnumerator Init()
        {
            InitPatch();
            yield break;
        }

        public static async void InitPatch()
        {
            try
            {
                ModConsole.Log("[Cheetos Patches] Appying Patches.");
                new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
                new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));
                ModConsole.Log($"[Cheetos Patches] Done patching {Patch.Patches.Count} methods!");
                Patch.DoPatches();
            }
            catch (Exception e) { ModConsole.Error($"[Cheetos Patches] Error in applying patches : {e}"); }
            finally { }
        }

        private static void OnPhotonPlayerJoin(ref Photon.Realtime.Player __0)
        {
            if (__0 != null)
            {
                var stopwatch = Stopwatch.StartNew();
                var name = __0.GetDisplayName();
                stopwatch.Stop();
                ModConsole.Log($"[Photon] Player Joined: {name}");
                ModConsole.Log($"PhotonPlayer.GetDisplayName() took {stopwatch.ElapsedMilliseconds}ms");
            }
        }

        private static void OnPhotonPlayerLeft(ref Photon.Realtime.Player __0)
        {
            if (__0 != null)
            {
                var stopwatch = Stopwatch.StartNew();
                var name = __0.GetDisplayName();
                stopwatch.Stop();
                ModConsole.Log($"[Photon] Player Left: {name}");
                ModConsole.Log($"PhotonPlayer.GetDisplayName() took {stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}
