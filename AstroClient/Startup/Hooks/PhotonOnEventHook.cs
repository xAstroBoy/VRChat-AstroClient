namespace AstroClient.Startup.Hooks
{
    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using AstroClient.Features.Player.Movement.Exploit;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using Patch = AstroClient.Patch;
    using Photon.Realtime;
    using System.Text;
    using UnhollowerBaseLib;
    using UnhollowerRuntimeLib;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class PhotonOnEventHook : GameEvents
    {
        internal override void ExecutePriorityPatches()
        {
            HookPhotonOnEvent();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(PhotonOnEventHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static void HookPhotonOnEvent()
        {
            unsafe
            {
                ModConsole.DebugLog("Hooking Photon OnEvent");
                new Patch(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.OnEvent)), GetPatch(nameof(OnEventPatch)));

            }
        }

        private unsafe static bool OnEventPatch(ref EventData __0)
        {
            try
            {
                bool log = false;
                bool isBlocked = false; // Flag this if needed to make the event not continue
                bool isPatched = false; // Flag this if you modify the event. (it will replace the event data)
                bool toReset = false; // Flag this if you need to clear the event entirely (might break something!)
                Dictionary<byte, IntPtr> ConvertedToNormalDict = new Dictionary<byte, IntPtr>();
                if (__0 != null)
                {
                    var code = __0.Code;
                    var PhotonSender = Utils.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                    var PhotonID = __0.sender;
                    StringBuilder line = new StringBuilder();
                    StringBuilder prefix = new StringBuilder();
                    prefix.Append($"[Event ({code})] ");
                    line.Append($"from: ({__0.Sender}) ");
                    if (WorldUtils.IsInWorld && PhotonSender != null)
                    {
                        line.Append($"'{PhotonSender.GetDisplayName()}'");
                    }
                    else
                    {
                        line.Append($"'NULL' ");
                    }
                    if (__0.Parameters != null && __0.Parameters.ContainsKey(245))
                    {
                        var customdataobj = __0.Parameters[245];
                        if (customdataobj != null)
                        {
                            if (customdataobj.GetIl2CppType().Equals(Il2CppType.Of<Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>>()))
                            {
                                try
                                {
                                    var originaldict = customdataobj.Cast<Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>>();
                                    if (originaldict != null && originaldict.Count != 0)
                                    {

                                        foreach (var key in originaldict.Keys)
                                        {
                                            ConvertedToNormalDict.Add(key, originaldict[key].Pointer);
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    ModConsole.DebugError("Failed to Cast event !");
                                    ModConsole.DebugErrorExc(e);
                                }
                            }
                            if(customdataobj == null)
                            {
                                return true; // There's no need to continue to read and translate, so let's continue.
                            }
                            if (ConvertedToNormalDict != null && ConvertedToNormalDict.Count != 0)
                            {

                                switch (code)
                                {
                                    case 1:// Voice Data TODO : (Parrot Mode)
                                        break;

                                    case 7: // I believe this is motion, key 245 appears to be base64
                                        break;

                                    case 2: // Kick Message?
                                        string kickMessage = (Serialization.FromIL2CPPToManaged<object>(__0.Parameters) as Dictionary<byte, object>)[245].ToString();
                                        break;

                                    case 6:
                                        break;

                                    case 8: // Interest - Interested in events
                                        break;

                                    case 33: // Moderations
                                        log = true;
                                        #region Moderation Handler
                                        try
                                        {
                                            if (ConvertedToNormalDict.ContainsKey(0))
                                            {
                                                byte moderationevent = *(byte*)IL2CPP.il2cpp_object_unbox(ConvertedToNormalDict[0]).ToPointer();
                                                switch (moderationevent)
                                                {
                                                    case 2: // Warnings.
                                                        prefix.Append("Moderation Warning: ");
                                                        log = true;
                                                        break;

                                                    case 8: // Mod Mute
                                                        prefix.Append("Moderation Mod-Mute: ");
                                                        log = true;
                                                        break;

                                                    case 10: // Friend State
                                                        prefix.Append("Moderation Friend State: ");
                                                        log = true;
                                                        break;

                                                    case 13: // VoteKick
                                                        prefix.Append("Moderation VoteKick : ");
                                                        log = true;
                                                        break;

                                                    case 21: // Mute , Blocking
                                                        prefix.Append("Moderation Block/Mute : ");
                                                        log = true;
                                                        #region Blocking and Muting Events.

                                                        // Single Moderation Event (one player)
                                                        if (ConvertedToNormalDict.Count == 4)
                                                        {
                                                            if (ConvertedToNormalDict.ContainsKey(1))
                                                            {
                                                                int RemoteModerationPhotonID = *(int*)IL2CPP.il2cpp_object_unbox(ConvertedToNormalDict[1]).ToPointer();
                                                                var PhotonPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(RemoteModerationPhotonID);
                                                                bool blocked = false;
                                                                bool muted = false;
                                                                if (ConvertedToNormalDict.ContainsKey(10))
                                                                {
                                                                    IntPtr BlockedPtr = ConvertedToNormalDict[10];
                                                                    if (BlockedPtr != IntPtr.Zero)
                                                                    {
                                                                        blocked = *(bool*)IL2CPP.il2cpp_object_unbox(BlockedPtr).ToPointer();
                                                                        if (blocked)
                                                                        {
                                                                            PhotonModerationHandler.OnPlayerBlockedYou_Invoker(PhotonPlayer);
                                                                            ConvertedToNormalDict[10] = Il2CppConverter.Generate_Il2CPPObject(false).Pointer;
                                                                            isPatched = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            PhotonModerationHandler.OnPlayerUnblockedYou_Invoker(PhotonPlayer);
                                                                        }
                                                                    }
                                                                }
                                                                if (ConvertedToNormalDict.ContainsKey(11))
                                                                {
                                                                    IntPtr MutedPtr = ConvertedToNormalDict[11];
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
                                                            }
                                                        }
                                                        // Multiple Moderation Events (Usually happens when you enter the room)
                                                        else if (ConvertedToNormalDict.Count == 3)
                                                        {
                                                            // Blocked List
                                                            if (ConvertedToNormalDict.ContainsKey(10))
                                                            {
                                                                IntPtr blockedlistptr = ConvertedToNormalDict[10];
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
                                                                                ConvertedToNormalDict[10] = BlockedPlayersArray.Pointer;
                                                                                isPatched = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            // Muted List
                                                            if (ConvertedToNormalDict.ContainsKey(11))
                                                            {
                                                                IntPtr Mutedlistptr = ConvertedToNormalDict[11];
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
                                                        #endregion Blocking and Muting Events.

                                                        break;

                                                    case 20: // Unknown, seems affecting users on reset 
                                                        prefix.Append($"Moderation Event {moderationevent}:");
                                                        log = true;
                                                        break;

                                                    default:
                                                        prefix.Append($"Moderation Event {moderationevent}:");
                                                        log = true;
                                                        break;
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            ModConsole.DebugError("Exception in OnEvent Moderation Handler");
                                            ModConsole.ErrorExc(e);

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
                    }
                    if (isPatched)
                    {
                        if (ConvertedToNormalDict != null && ConvertedToNormalDict.Count != 0)
                        {
                            var ModifiedEvent = new Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>();
                            foreach (var key in ConvertedToNormalDict.Keys)
                            {
                                ModifiedEvent.System_Collections_IDictionary_Add(Il2CppConverter.Generate_Il2CPPObject(key), new Il2CppSystem.Object(ConvertedToNormalDict[key]));
                            }

                            var modifiedparams = new Dictionary<byte, Il2CppSystem.Object>();
                            foreach (var key in __0.Parameters.Keys)
                            {
                                if (key != 245)
                                {
                                    modifiedparams.Add(key, __0.Parameters[key]);
                                }
                                else
                                {
                                    modifiedparams.Add(key, ModifiedEvent);
                                }
                            }

                            __0.Parameters.Clear();
                            __0.Parameters = null;
                            __0.Parameters = new Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>();
                            foreach (var key in modifiedparams.Keys)
                            {
                                __0.Parameters.System_Collections_IDictionary_Add(Il2CppConverter.Generate_Il2CPPObject(key), modifiedparams[key]);
                            }
                        }
                    }
                    string eventstring = string.Empty;
                    if(isPatched)
                    {
                        eventstring = "PATCHED :";
                    }
                    else if(isBlocked)
                    {
                        eventstring = "BLOCKED :";
                    }
                    else if(toReset)
                    {
                        eventstring = "RESET :";
                    }
                    if (log && ConfigManager.General.LogEvents && __0.Parameters != null)
                    {
                        line.Append($"\n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(__0.Parameters), Newtonsoft.Json.Formatting.Indented)}");
                        ModConsole.Log($"{eventstring}{prefix.ToString()}{line.ToString()}");
                    }
                    line.Clear();
                }
                if (isBlocked)
                {
                    return false;
                }
                else
                {
                    if(toReset)
                    {
                        __0.Reset();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugError("Exception in OnEvent");
                ModConsole.ErrorExc(e);
                return true;
            }
            ModConsole.DebugLog($"HOOK END Without Exceptions");
            return true;
        }
    }
}