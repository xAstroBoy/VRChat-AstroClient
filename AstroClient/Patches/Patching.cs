﻿using AstroClient.ConsoleUtils;
using AstroClient.variables;
using DayClientML2.Utility;
using DayClientML2.Utility.Extensions;
using ExitGames.Client.Photon;
using Harmony;
using Il2CppSystem.Collections;
using MelonLoader;
using RootMotion.FinalIK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Transmtn;
using Transmtn.DTO.Notifications;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using VRC.Management;
using VRC.SDKBase;
using VRCSDK2.Validation.Performance;
using static VRC.SDKBase.VRC_EventHandler;
using Action = System.Action;
using Console = System.Console;
using IntPtr = System.IntPtr;
using Random = System.Random;

using VRC_EventHandler = VRC.SDKBase.VRC_EventHandler;

namespace AstroClient.BetterPatch
{
    internal class Patching
    {
        public static HarmonyInstance Instance = HarmonyInstance.Create("AstroClientPatches");

        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(Patching).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        public class Patch
        {
            private static List<Patch> Patches = new List<Patch>();
            public MethodInfo TargetMethod { get; set; }
            public HarmonyMethod PrefixMethod { get; set; }
            public HarmonyMethod PostfixMethod { get; set; }
            public HarmonyInstance Instance { get; set; }

            public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
            {
                if (targetMethod == null || Before == null && After == null)
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

            public static void DoPatches()
            {
                foreach (var patch in Patches)
                {
                    try
                    {
                        ModConsole.Log($"[Patches] Patching {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {(patch.PrefixMethod?.method.Name)}{(patch.PostfixMethod?.method.Name)}");
                        patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
                    }
                    catch(Exception e)
                    {
                        ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
                        ModConsole.ErrorExc(e);
                    }
                }
                ModConsole.Log($"[Patches] Done! Patched {Patches.Count} Methods!");
            }
            public static void UnDoPatches()
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
                ModConsole.Log($"[Patches] Done! UnPatched {Patches.Count} Methods!");
            }
        }


        public static void InitPatch()
        {
            try
            {
                ModConsole.Log("[Patches] Start. . .");

                new Patch(typeof(Photon.Realtime.LoadBalancingClient).GetMethod(nameof(Photon.Realtime.LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OpRaiseEvent)));

                ModConsole.Log("[AstroClient Patches] DONE!");
                Patch.DoPatches();
            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }






        private static bool OpRaiseEvent(ref byte __0, ref Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object> __1, ref SendOptions __2)
        {
            try
            {
                if (__0 == 7 || __0 == 206 || __0 == 201 || __0 == 1)
                {
                    return !Bools.SerializerEnabled;
                }
            }
            catch { }
            return true;
        }

        private static readonly float PermanentNearClip = 0.1f;
        private static void nearClipPlane(ref float __result, ref Camera __instance)
        {
            if (__instance == null) return;
            try
            {
                if (__instance != null)
                {
                    if (__instance.nearClipPlane != PermanentNearClip)
                    {
                        __instance.nearClipPlane = PermanentNearClip;
                    }
                }
                if (__result != null)
                {
                    if (__result != PermanentNearClip)
                    {
                        __result = PermanentNearClip;
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.Error("Error in nearClipPlane");
                ModConsole.ErrorExc(e);
            }
        }



    }
}