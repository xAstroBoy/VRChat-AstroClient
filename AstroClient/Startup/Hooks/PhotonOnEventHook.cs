﻿namespace AstroClient.Startup.Hooks
{
    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using AstroClient.Features.Player.Movement.Exploit;
    using AstroLibrary.Extensions;
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


        private struct EventCode
        {
            internal const byte OpRemoveCache_etc = 0;
            internal const byte USpeaker_Voice_Data = 1;
            internal const byte Disconnect_Message = 2;
            internal const byte Cached_Events = 4; // Wut?
            internal const byte Master_allowing_player_to_join = 5;
            internal const byte RPC = 6;
            internal const byte Motion = 7;
            internal const byte interest = 8; // Wut
            internal const byte Reliable = 9;
            internal const byte Moderations = 33;
            internal const byte OpCleanRpcBuffer = 200; // (int actorNumber)
            internal const byte SendSerialize = 201;
            internal const byte Instantiation = 202;
            internal const byte CloseConnection = 203; // (PhotonPlayer kickPlayer)
            internal const byte Destroy = 204;
            internal const byte RemoveCachedRPCs = 205;
            internal const byte SendSerializeReliable = 206;
            internal const byte Destroy_Player = 207;
            internal const byte SetMasterClient = 208; // (int playerId; bool sync)
            internal const byte Request_Ownership = 209;
            internal const byte Transfer_Ownership = 210;
            internal const byte VacantViewIds = 211;
            internal const byte UploadAvatar = 223;
            internal const byte Custom_Properties = 253;
            internal const byte Leaving_World = 254;
            internal const byte Joining_World = 255;
        }



        private struct ModerationCode
        {
            internal const byte Warning = 2;
            internal const byte Mod_Mute = 8;
            internal const byte Friend_State = 10;
            internal const byte VoteKick = 13;
            internal const byte Unknown = 20;  // Unknown, seems affecting users on reset 
            internal const byte Block_Or_Mute = 21;
        }

        private static string TranslateModerationEvent(byte moderationEvent)
        {
            switch (moderationEvent)
            {
                case ModerationCode.Warning: return "Warning";
                case ModerationCode.Mod_Mute: return "Mod Mute";
                case ModerationCode.Friend_State: return "Friend State";
                case ModerationCode.VoteKick: return "VoteKick";
                case ModerationCode.Unknown: return "Unknown";
                case ModerationCode.Block_Or_Mute: return "Block Or Mute";
                default:
                    return null;

            }
        }

        private static string TranslateEventData(byte code)
        {
            switch (code)
            {
                case EventCode.OpRemoveCache_etc: return "OpRemoveCache , etc...";
                case EventCode.USpeaker_Voice_Data: return "USpeak voice Data";
                case EventCode.Disconnect_Message: return "Disconnect (Kick)";
                case EventCode.Cached_Events: return "Cached Events";
                case EventCode.Master_allowing_player_to_join: return "Master allowing player to join";
                case EventCode.RPC: return "RPC";
                case EventCode.Motion: return "Motion";
                case EventCode.interest: return "Interest";
                case EventCode.Reliable: return "Reliable";
                case EventCode.Moderations: return "Moderation";
                case EventCode.OpCleanRpcBuffer: return "OPCleanRPCBuffer (int actorNumber)";
                case EventCode.SendSerialize: return "SendSerialize";
                case EventCode.Instantiation: return "Instantiation";
                case EventCode.CloseConnection: return "CloseConnection (PhotonPlayer kickPlayer)";
                case EventCode.Destroy: return "Destroy";
                case EventCode.RemoveCachedRPCs: return "RemoveCachedRPCs";
                case EventCode.SendSerializeReliable: return "SendSerializeReliable";
                case EventCode.Destroy_Player: return "Destroy Player";
                case EventCode.SetMasterClient: return "SetMasterClient (int playerId, bool sync)";
                case EventCode.Request_Ownership: return "Request Ownership";
                case EventCode.Transfer_Ownership: return "Transfer Ownership";
                case EventCode.VacantViewIds: return "VacantViewIds";
                case EventCode.UploadAvatar: return "UploadAvatar";
                case EventCode.Custom_Properties: return "Custom Properties";
                case EventCode.Leaving_World: return "Leaving World";
                case EventCode.Joining_World: return "Joining World";
                default:
                    return null;

            }
        }

        private unsafe static bool OnEventPatch(ref EventData __0)
        {
            try
            {
                bool log = false;
                bool isBlocked = false; // Flag this if needed to make the event not continue
                bool isPatched = false; // Flag this if you modify the event. (it will replace the event data)
                bool ToEmpty = false; // Flag this if you want to modify the event with a empty key.
                bool toReset = false; // Flag this if you need to clear the event entirely (might break something!)
                Dictionary<byte, IntPtr> ConvertedToNormalDict = new Dictionary<byte, IntPtr>();
                if (__0 != null)
                {
                    var PhotonSender = Utils.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                    var PhotonID = __0.sender;
                    StringBuilder line = new StringBuilder();
                    StringBuilder prefix = new StringBuilder();
                    string translated = TranslateEventData(__0.Code);
                    if (translated.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        prefix.Append($"[Event ({__0.Code}) {translated}] ");
                    }
                    else
                    {
                        prefix.Append($"[Event ({__0.Code})] ");
                    }
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
                                 
                                switch (__0.Code)
                                {
                                    case EventCode.USpeaker_Voice_Data:// Voice Data TODO : (Parrot Mode)
                                        break;

                                    case EventCode.Motion: // I believe this is motion, key 245 appears to be base64
                                        break;

                                    case EventCode.Disconnect_Message: // Kick Message?
                                        string kickMessage = (Serialization.FromIL2CPPToManaged<object>(__0.Parameters) as Dictionary<byte, object>)[245].ToString();
                                        break;

                                    case EventCode.RPC:
                                        break;

                                    case EventCode.interest: // Interest - Interested in events
                                        break;

                                    case EventCode.Moderations: // Moderations
                                        log = true;
                                        #region Moderation Handler
                                        try
                                        {
                                            if (ConvertedToNormalDict.ContainsKey(0))
                                            {
                                                byte moderationevent = *(byte*)IL2CPP.il2cpp_object_unbox(ConvertedToNormalDict[0]).ToPointer();
                                                var moderationeventname = TranslateModerationEvent(moderationevent);
                                                if(moderationeventname.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    prefix.Append($"[Moderation {moderationeventname}");
                                                }
                                                switch (moderationevent)
                                                {
                                                    case ModerationCode.Warning: // Warnings.
                                                        log = true;
                                                        break;

                                                    case ModerationCode.Mod_Mute: // Mod Mute
                                                        log = true;
                                                        break;

                                                    case ModerationCode.Friend_State: // Friend State
                                                        log = true;
                                                        break;

                                                    case ModerationCode.VoteKick: // VoteKick
                                                        log = true;
                                                        break;

                                                    case(byte) ModerationCode.Block_Or_Mute: 
                                                        log = true;
                                                        #region Blocking and Muting Events.

                                                        byte photonid = 1;
                                                        byte blockbyte = 10;
                                                        byte mutebyte = 11;
                                                        
                                                        // Single Moderation Event (one player)
                                                        if (ConvertedToNormalDict.Count == 4)
                                                        {
                                                            if (ConvertedToNormalDict.ContainsKey(photonid))
                                                            {
                                                                int RemoteModerationPhotonID = *(int*)IL2CPP.il2cpp_object_unbox(ConvertedToNormalDict[photonid]).ToPointer();
                                                                var PhotonPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(RemoteModerationPhotonID);
                                                                if (ConvertedToNormalDict.ContainsKey(blockbyte))
                                                                {
                                                                    IntPtr BlockedPtr = ConvertedToNormalDict[blockbyte];
                                                                    if (BlockedPtr != IntPtr.Zero)
                                                                    {
                                                                        bool blocked = *(bool*)IL2CPP.il2cpp_object_unbox(BlockedPtr).ToPointer();
                                                                        switch (blocked)
                                                                        {
                                                                            case true:
                                                                                {
                                                                                    PhotonModerationHandler.OnPlayerBlockedYou_Invoker(PhotonPlayer);
                                                                                    ConvertedToNormalDict[blockbyte] = Il2CppConverter.Generate_Il2CPPObject(false).Pointer;
                                                                                    isPatched = true;
                                                                                    break;
                                                                                }
                                                                            case false:
                                                                                {

                                                                                    PhotonModerationHandler.OnPlayerUnblockedYou_Invoker(PhotonPlayer);
                                                                                    break;
                                                                                }
                                                                            default:
                                                                                break;
                                                                        }
                                                                    }
                                                                }
                                                                if (ConvertedToNormalDict.ContainsKey(mutebyte))
                                                                {
                                                                    IntPtr MutedPtr = ConvertedToNormalDict[mutebyte];
                                                                    if (MutedPtr != IntPtr.Zero)
                                                                    {
                                                                        bool muted = *(bool*)IL2CPP.il2cpp_object_unbox(MutedPtr).ToPointer();
                                                                        switch (muted)
                                                                        {
                                                                            case true:
                                                                                {
                                                                                    PhotonModerationHandler.OnPlayerMutedYou_Invoker(PhotonPlayer);
                                                                                    break;
                                                                                }
                                                                            case false:
                                                                                {
                                                                                    PhotonModerationHandler.OnPlayerUnmutedYou_Invoker(PhotonPlayer);
                                                                                    break;
                                                                                }
                                                                            default:
                                                                                break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        // Multiple Moderation Events (Usually happens when you enter the room)
                                                        else if (ConvertedToNormalDict.Count == 3)
                                                        {
                                                            // Blocked List
                                                            if (ConvertedToNormalDict.ContainsKey(blockbyte))
                                                            {
                                                                IntPtr blockedlistptr = ConvertedToNormalDict[blockbyte];
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
                                                                                    var blockedplayers = Utils.LoadBalancingPeer.GetPhotonPlayer(BlockedPlayersArray[i]);
                                                                                    PhotonModerationHandler.OnPlayerBlockedYou_Invoker(blockedplayers);
                                                                                    BlockedPlayersArray[i] = -1;
                                                                                }
                                                                                ConvertedToNormalDict[blockbyte] = BlockedPlayersArray.Pointer;
                                                                                isPatched = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            // Muted List
                                                            if (ConvertedToNormalDict.ContainsKey(mutebyte))
                                                            {
                                                                IntPtr Mutedlistptr = ConvertedToNormalDict[mutebyte];
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

                                                    case (byte) ModerationCode.Unknown: // Unknown, seems affecting users on reset 
                                                        log = true;
                                                        break;

                                                    default:
                                                        prefix.Append($"Unregistered Event {moderationevent}:");
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

                                    case EventCode.Destroy: // Destroy
                                        log = true;
                                        break;

                                    case EventCode.Transfer_Ownership:
                                        break;

                                    case EventCode.UploadAvatar: // This fired with what looked like base64 png data when I uploaded a VRC+ avatar
                                        break;

                                    case EventCode.Custom_Properties: // I think this is avatar switching related
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
                    else if(ToEmpty)
                    {
                        var modifiedparams = new Dictionary<byte, Il2CppSystem.Object>();
                        foreach (var key in __0.Parameters.Keys)
                        {
                            if (key != 245)
                            {
                                modifiedparams.Add(key, __0.Parameters[key]);
                            }
                            else
                            {
                                modifiedparams.Add(key, new Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>());
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
                    string eventstring = string.Empty;
                    if(isPatched)
                    {
                        eventstring = "PATCHED : ";
                    }
                    else if(isBlocked)
                    {
                        eventstring = "BLOCKED : ";
                    }
                    else if(toReset)
                    {
                        eventstring = "RESET : ";
                    }
                    else if(ToEmpty)
                    {
                        eventstring = "EMPTIED : ";
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