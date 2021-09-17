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

    internal class QuickMenuHooks : GameEvents
    {


        public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerSelected;


        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(QuickMenuHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
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
                foreach (var patch in Patches)
                {
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

        public override void ExecutePriorityPatches()
        {
            InitPatch();
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

        private static bool OnSelectedPlayerPatch(VRC.Player player)
        {
            ModConsole.DebugLog($"Test OnSelected {player.DisplayName()}");
            Event_OnPlayerSelected.SafetyRaise(new VRCPlayerEventArgs(player));
            return true;
        }


    }
}