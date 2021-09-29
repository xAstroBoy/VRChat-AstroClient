namespace AstroClient.Startup.Hooks
{
    #region Imports

    using AstroClient.Features.Player.Movement.Exploit;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using HarmonyLib;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    #endregion Imports


    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class QuickMenuHooks : GameEvents
    {


        public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerSelected;


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
            return new HarmonyMethod(typeof(QuickMenuHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
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


        private void InitPatch()
        {
            try
            {
                new Patch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.Method_Public_Void_Player_0)), GetPatch(nameof(OnSelectedPlayerPatch)));

                Patch.DoPatches();
            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }

        private static void OnSelectedPlayerPatch(ref VRC.Player __0)
        {
            Event_OnPlayerSelected.SafetyRaise(new VRCPlayerEventArgs(__0));
        }


    }
}