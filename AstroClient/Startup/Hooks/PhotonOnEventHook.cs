namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using Moderation;
    using Photon.Realtime;
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
                new AstroPatch(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.OnEvent)), GetPatch(nameof(OnEventPatch)));
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

        private static bool EventCodeToLog(byte code)
        {
            switch (code)
            {
                case EventCode.OpRemoveCache_etc: return false;
                case EventCode.USpeaker_Voice_Data: return false;
                case EventCode.Disconnect_Message: return false;
                case EventCode.Cached_Events: return false;
                case EventCode.Master_allowing_player_to_join: return true;
                case EventCode.RPC: return false;
                case EventCode.Motion: return false;
                case EventCode.interest: return false;
                case EventCode.Reliable: return false;
                case EventCode.Moderations: return true;
                case EventCode.OpCleanRpcBuffer: return false;
                case EventCode.SendSerialize: return false;
                case EventCode.Instantiation: return false;
                case EventCode.CloseConnection: return false;
                case EventCode.Destroy: return false;
                case EventCode.RemoveCachedRPCs: return false;
                case EventCode.SendSerializeReliable: return false;
                case EventCode.Destroy_Player: return false;
                case EventCode.SetMasterClient: return false;
                case EventCode.Request_Ownership: return false;
                case EventCode.Transfer_Ownership: return false;
                case EventCode.VacantViewIds: return false;
                case EventCode.UploadAvatar: return false;
                case EventCode.Custom_Properties: return false;
                case EventCode.Leaving_World: return false;
                case EventCode.Joining_World: return false;
                default:
                    return true;
            }
        }
        private enum HookAction
        {
            Nothing,
            Patch, // Flag this if you modify the event. (it will replace the event data)
            Block, // Flag this if needed to make the event not continue
            Empty,// Flag this if you want to modify the event with a empty key.
            Reset, // Flag this if you need to clear the event entirely (might break something!)
        }

        private static string HookActionToString(HookAction action)
        {
            switch(action)
            {
                case HookAction.Patch: return "PATCHED ";
                case HookAction.Block: return "BLOCKED ";
                case HookAction.Empty: return "EMPTIED ";
                case HookAction.Reset: return "RESET ";
                default:
                    return string.Empty;    
            }
        }


    private unsafe static bool OnEventPatch(ref EventData __0)
        {
            HookAction Currentaction = HookAction.Nothing;
            try
            {
                Dictionary<byte, Il2CppSystem.Object> ConvertedToNormalDict = new Dictionary<byte, Il2CppSystem.Object>();
                if (__0 != null)
                {
                    var PhotonSender = Utils.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                    var PhotonID = __0.sender;
                    StringBuilder line = new StringBuilder();
                    StringBuilder prefix = new StringBuilder();
                    string translated = TranslateEventData(__0.Code);
                    if (translated.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        prefix.Append($"[Event ({__0.Code})][{translated}]: ");
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
                                            ConvertedToNormalDict.Add(key, originaldict[key]);
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    ModConsole.DebugError("Failed to Cast event !");
                                    ModConsole.DebugErrorExc(e);
                                }
                            }
                            if (customdataobj == null)
                            {
                                return true; // There's no need to continue to read and translate.
                            }
                            if (ConvertedToNormalDict != null && ConvertedToNormalDict.Count != 0)
                            {
                                switch (__0.Code)
                                {
                                    //case EventCode.USpeaker_Voice_Data:// Voice Data TODO : (Parrot Mode)
                                    //    log = true;
                                    //    break;

                                    case EventCode.Motion: // I believe this is motion, key 245 appears to be base64
                                        break;

                                    //case EventCode.Disconnect_Message: // Kick Message?
                                    //    string kickMessage = (Serialization.FromIL2CPPToManaged<object>(__0.Parameters) as Dictionary<byte, object>)[245].ToString();
                                    //    break;

                                    //case EventCode.RPC:
                                    //    break;

                                    //case EventCode.interest: // Interest - Interested in events
                                    //    break;

                                    case EventCode.Moderations: // Moderations

                                        #region Moderation Handler

                                        try
                                        {
                                            if (ConvertedToNormalDict.ContainsKey(0))
                                            {
                                                byte moderationevent = ConvertedToNormalDict[0].Unpack_Byte().Value;
                                                var moderationeventname = TranslateModerationEvent(moderationevent);
                                                if (moderationeventname.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    prefix.Append($"{moderationeventname} ");
                                                }
                                                switch (moderationevent)
                                                {
                                                    case ModerationCode.Warning: // Warnings.
                                                        break;

                                                    case ModerationCode.Mod_Mute: // Mod Mute
                                                        break;

                                                    case ModerationCode.Friend_State: // Friend State
                                                        break;

                                                    case ModerationCode.VoteKick: // VoteKick
                                                        break;

                                                    case (byte)ModerationCode.Block_Or_Mute:

                                                        #region Blocking and Muting Events.

                                                        byte photonid = 1;
                                                        byte blockbyte = 10;
                                                        byte mutebyte = 11;

                                                        // Single Moderation Event (one player)
                                                        if (ConvertedToNormalDict.Count == 4)
                                                        {
                                                            if (ConvertedToNormalDict.ContainsKey(photonid))
                                                            {
                                                                int RemoteModerationPhotonID = ConvertedToNormalDict[photonid].Unpack_Int32().Value;
                                                                var PhotonPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(RemoteModerationPhotonID);
                                                                if (ConvertedToNormalDict.ContainsKey(blockbyte))
                                                                {
                                                                    bool blocked = ConvertedToNormalDict[blockbyte].Unpack_Boolean().Value;
                                                                    switch (blocked)
                                                                    {
                                                                        case true:
                                                                            {
                                                                                PhotonModerationHandler.OnPlayerBlockedYou_Invoker(PhotonPlayer);
                                                                                ConvertedToNormalDict[blockbyte] = Il2CppConverter.Generate_Il2CPPObject(false);
                                                                                Currentaction = HookAction.Patch;
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
                                                                if (ConvertedToNormalDict.ContainsKey(mutebyte))
                                                                {
                                                                    bool muted = ConvertedToNormalDict[mutebyte].Unpack_Boolean().Value;
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

                                                        // Multiple Moderation Events (Usually happens when you enter the room)
                                                        else if (ConvertedToNormalDict.Count == 3)
                                                        {
                                                            // Blocked List
                                                            if (ConvertedToNormalDict.ContainsKey(blockbyte))
                                                            {
                                                                var blockedlistObject = ConvertedToNormalDict[blockbyte];
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
                                                                            ConvertedToNormalDict[blockbyte] = new Il2CppSystem.Object(BlockedPlayersArray.Pointer);
                                                                            Currentaction = HookAction.Patch;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            // Muted List
                                                            if (ConvertedToNormalDict.ContainsKey(mutebyte))
                                                            {
                                                                var MutedlistObject = ConvertedToNormalDict[mutebyte];
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

                                                        #endregion Blocking and Muting Events.

                                                        break;

                                                    case (byte)ModerationCode.Unknown: // Unknown, seems affecting users on reset
                                                        break;

                                                    default:
                                                        prefix.Append($"Unregistered Event {moderationevent}:");
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

                                    //case EventCode.Destroy: // Destroy
                                    //    log = true;
                                    //    break;

                                    //case EventCode.Transfer_Ownership:
                                    //    break;

                                    //case EventCode.UploadAvatar: // This fired with what looked like base64 png data when I uploaded a VRC+ avatar
                                    //    break;

                                    //case EventCode.Custom_Properties: // I think this is avatar switching related
                                    //    break;

                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    switch (Currentaction)
                    {
                        case HookAction.Patch:
                            {
                                if (ConvertedToNormalDict != null && ConvertedToNormalDict.Count != 0)
                                {
                                    var ModifiedEvent = new Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>();
                                    foreach (var key in ConvertedToNormalDict.Keys)
                                    {
                                        ModifiedEvent.System_Collections_IDictionary_Add(Il2CppConverter.Generate_Il2CPPObject(key), ConvertedToNormalDict[key]);
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
                                break;
                            }
                        case HookAction.Empty:
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
                                break;
                            }
                        default:
                            break;
                    }
                    if (EventCodeToLog(__0.Code) && ConfigManager.General.LogEvents && __0.Parameters != null)
                    {
                        line.Append($"\n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(__0.Parameters), Newtonsoft.Json.Formatting.Indented)}");
                        ModConsole.Log($"{HookActionToString(Currentaction)}{prefix.ToString()}{line.ToString()}");
                    }
                    line.Clear();
                }
                switch (Currentaction)
                {
                    case HookAction.Block:
                        return false;
                        break;
                    case HookAction.Reset:
                        __0.Reset();
                        return true;
                        break;
                    default:
                        return true;
                        break;
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugError("Exception in OnEvent");
                ModConsole.ErrorExc(e);
                return true;
            }
            return true;
        }
    }
}