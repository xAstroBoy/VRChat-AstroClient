﻿namespace AstroClient.Startup.Hooks
{
    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using MelonLoader;
    using Photon.Realtime;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using UnhollowerBaseLib;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class PhotonOnEventHook : GameEvents
    {
        internal override void ExecutePriorityPatches()
        {
            HookPhotonOnEvent();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static IntPtr GetPointerPatch(string patch)
        {
            return typeof(PhotonOnEventHook).GetMethod(patch, BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer();
        }

        private static void HookPhotonOnEvent()
        {
            unsafe
            {
                ModConsole.DebugLog("Hooking Photon OnEvent");
                var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.OnEvent))).GetValue(null);
                MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), GetPointerPatch(nameof(OnEventPatch)));
                _OnEventDelegate = Marshal.GetDelegateForFunctionPointer<OnEventDelegate>(originalMethod);
                if (_OnEventDelegate != null)
                {
                    ModConsole.DebugLog("Hooked Photon OnEvent");
                }
                else
                {
                    ModConsole.Error("Failed to hook Photon OnEvent!");
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnEventDelegate(IntPtr thisPtr, IntPtr OnEventPtr);

        private static OnEventDelegate _OnEventDelegate;

        private unsafe static void OnEventPatch(IntPtr thisPtr, IntPtr OnEventPtr)
        {
            try
            {
                if (thisPtr != IntPtr.Zero && OnEventPtr != IntPtr.Zero)
                {
                    // first let's convert the OnEventPtr in something legible
                    var EventObject = new Il2CppSystem.Object(OnEventPtr);
                    if (EventObject != null)
                    {
                        var eventData = EventObject.Cast<EventData>();
                        if (eventData != null)
                        {
                            bool isPatched = false;
                            var code = eventData.Code;
                            var PhotonSender = Utils.LoadBalancingPeer.GetPhotonPlayer(eventData.sender);
                            var PhotonID = eventData.sender;
                            bool log = false;
                            StringBuilder line = new StringBuilder();
                            StringBuilder prefix = new StringBuilder();
                            prefix.Append($"[Event ({code})] ");
                            line.Append($"from: ({eventData.Sender}) ");
                            if (WorldUtils.IsInWorld && PhotonSender != null)
                            {
                                line.Append($"'{PhotonSender.GetDisplayName()}'");
                            }
                            else
                            {
                                line.Append($"'NULL' ");
                            }
                            if (eventData.Parameters != null)
                            {
                                var customdataobj = eventData.Parameters[245];
                                if (customdataobj != null)
                                {
                                    Il2CppSystem.Collections.Generic.Dictionary<byte, IntPtr> DataDict = customdataobj.Cast<Il2CppSystem.Collections.Generic.Dictionary<byte, IntPtr>>();
                                    if (DataDict.Count != 0)
                                    {
                                        ModConsole.DebugLog("Data Cast Done.");
                                        switch (code)
                                        {
                                            case 1:// Voice Data TODO : (Parrot Mode)
                                                break;

                                            case 7: // I believe this is motion, key 245 appears to be base64
                                                break;

                                            case 2: // Kick Message?
                                                string kickMessage = (Serialization.FromIL2CPPToManaged<object>(eventData.Parameters) as Dictionary<byte, object>)[245].ToString();
                                                break;

                                            case 6:
                                                break;

                                            case 8: // Interest - Interested in events
                                                break;

                                            case 33: // Moderations

                                                #region Moderation Handler

                                                if (DataDict.ContainsKey(0))
                                                {
                                                    byte moderationbyte = *(byte*)IL2CPP.il2cpp_object_unbox(DataDict[0]).ToPointer();
                                                    switch (moderationbyte)
                                                    {
                                                        case 2:
                                                            break;

                                                        case 8:
                                                            break;

                                                        case 10:
                                                            break;

                                                        case 13:
                                                            break;

                                                        case 21:

                                                            #region Blocking and Muting Events.

                                                            // Single Moderation Event (one player)
                                                            if (DataDict.count == 4)
                                                            {
                                                                if (DataDict.ContainsKey(1))
                                                                {
                                                                    int RemoteModerationPhotonID = *(int*)IL2CPP.il2cpp_object_unbox(DataDict[1]).ToPointer();
                                                                    var PhotonPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(RemoteModerationPhotonID);
                                                                    bool blocked = false;
                                                                    bool muted = false;
                                                                    IntPtr BlockedPtr = DataDict[10];
                                                                    if (BlockedPtr != IntPtr.Zero)
                                                                    {
                                                                        blocked = *(bool*)IL2CPP.il2cpp_object_unbox(BlockedPtr).ToPointer();
                                                                        if (blocked)
                                                                        {
                                                                            PhotonModerationHandler.OnPlayerBlockedYou_Invoker(PhotonPlayer);
                                                                            DataDict[10] = Il2CppConverter.Generate_Il2CPPObject(false).Pointer;
                                                                            isPatched = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            PhotonModerationHandler.OnPlayerUnblockedYou_Invoker(PhotonPlayer);
                                                                        }
                                                                    }
                                                                    IntPtr MutedPtr = DataDict[10];
                                                                    if (MutedPtr != IntPtr.Zero)
                                                                    {
                                                                        muted = *(bool*)IL2CPP.il2cpp_object_unbox(MutedPtr).ToPointer();
                                                                        if (muted)
                                                                        {
                                                                            PhotonModerationHandler.OnPlayerMutedYou_Invoker(PhotonPlayer);
                                                                        }
                                                                        else
                                                                        {
                                                                            PhotonModerationHandler.OnPlayerUnmutedYou_Invoker(PhotonPlayer);
                                                                        }
                                                                    }
                                                                }
                                                                // Multiple Moderation Events (Usually happens when you enter the room)
                                                                else if (DataDict.count == 3)
                                                                {
                                                                    // Blocked List
                                                                    if (DataDict.ContainsKey(10))
                                                                    {
                                                                        IntPtr blockedlistptr = DataDict[10];
                                                                        if (blockedlistptr != IntPtr.Zero)
                                                                        {
                                                                            var blockedlistObject = new Il2CppSystem.Object(blockedlistptr);
                                                                            if (blockedlistObject != null)
                                                                            {
                                                                                Il2CppStructArray<int> BlockedPlayersArray = blockedlistObject.Cast<Il2CppStructArray<int>>();
                                                                                if (BlockedPlayersArray != null)
                                                                                {
                                                                                    if (BlockedPlayersArray.Count != 0)
                                                                                    {
                                                                                        int count = BlockedPlayersArray.Count;
                                                                                        for (int i = 0; i < count; i++)
                                                                                        {
                                                                                            BlockedPlayersArray[i] = -1;
                                                                                        }
                                                                                        DataDict[10] = BlockedPlayersArray.Pointer;
                                                                                        isPatched = true;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    // Muted List
                                                                    if (DataDict.ContainsKey(10))
                                                                    {
                                                                        IntPtr Mutedlistptr = DataDict[10];
                                                                        if (Mutedlistptr != IntPtr.Zero)
                                                                        {
                                                                            var MutedlistObject = new Il2CppSystem.Object(Mutedlistptr);
                                                                            if (MutedlistObject != null)
                                                                            {
                                                                                Il2CppStructArray<int> MutePlayersArray = MutedlistObject.Cast<Il2CppStructArray<int>>();
                                                                                if (MutePlayersArray != null)
                                                                                {
                                                                                    if (MutePlayersArray.Count != 0)
                                                                                    {
                                                                                        int count = MutePlayersArray.Count;
                                                                                        for (int i = 0; i < count; i++)
                                                                                        {
                                                                                            var MutePlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(MutePlayersArray[i]);
                                                                                            PhotonModerationHandler.OnPlayerMutedYou_Invoker(MutePlayer);
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                            #endregion Blocking and Muting Events.

                                                            break;

                                                        case 20:
                                                            break;

                                                        default:
                                                            ModConsole.DebugError($"Unknown Moderation Byte Detected : {moderationbyte}");
                                                            break;
                                                    }
                                                }

                                                #endregion Moderation Handler

                                                break;

                                            case 203: // Destroy
                                                prefix.Append("Destroy: ");
                                                log = true;
                                                break;

                                            case 210:
                                                break;

                                            case 223: // This fired with what looked like base64 png data when I uploaded a VRC+ avatar
                                                break;

                                            case 253: // I think this is avatar switching related
                                                break;

                                            default:
                                                log = true;
                                                break;
                                        }
                                    }

                                    
                                }
                                if (log && ConfigManager.General.LogEvents)
                                {
                                    line.Append($"\n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(eventData.Parameters), Newtonsoft.Json.Formatting.Indented)}");
                                    if (!isPatched)
                                    {
                                        ModConsole.Log($"{prefix.ToString()}{line.ToString()}");
                                    }
                                    else
                                    {
                                        ModConsole.Log($"PATCHED : {prefix.ToString()}{line.ToString()}");
                                    }
                                }
                                line.Clear();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                _OnEventDelegate(thisPtr, OnEventPtr);
            }
        }
    }
}