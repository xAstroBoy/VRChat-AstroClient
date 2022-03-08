namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Cheetos;
    using Config;
    using ExitGames.Client.Photon;
    using Harmony;
    using Moderation;
    using Photon.Realtime;
    using Tools;
    using Tools.Extensions;
    using Tools.UdonEditor;
    using UnhollowerBaseLib;
    using UnhollowerRuntimeLib;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using Object = Il2CppSystem.Object;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class PhotonOnEventHook : AstroEvents
    {

        internal override void ExecutePriorityPatches()
        {
            //HookPhotonOnEvent();
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
            internal const byte Unknown = 20; // Unknown, seems affecting users on reset
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
                case EventCode.Disconnect_Message: return true;
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
                    return false;
            }
        }

        /// <summary>
        /// Actions that the hook Needs to do.
        /// </summary
        private enum HookAction
        {
            /// <summary>Do Nothing</summary>
            Nothing,

            /// <summary>Applies any edit you put in the Reflected HashTable/Dictionary in the current parameterDict</summary>
            Patch,

            /// <summary>Empties the ParameterDictionary with a empty Dictionary/Hashtable Content (Might break some stuff)</summary>
            Empty,

            /// <summary>Block the Event completely (Will break some stuff)</summary>
            Block,

            /// <summary>Resets the EventData (Breaks Every event that you reset!)</summary>
            Reset,
        }

        private static string HookActionToString(HookAction action)
        {
            switch (action)
            {
                case HookAction.Patch: return "PATCHED ";
                case HookAction.Block: return "BLOCKED ";
                case HookAction.Empty: return "EMPTIED ";
                case HookAction.Reset: return "RESET ";
                default:
                    return string.Empty;
            }
        }

        // Current Targeted Byte 
        private static byte CustomDataByte => 245;

        private unsafe static bool OnEventPatch(ref EventData __0)
        {
            HookAction Currentaction = HookAction.Nothing;
            bool isHashtableData = false;
            try
            {
                System.Collections.Generic.Dictionary<byte, Il2CppSystem.Object> ConvertedToNormalDict = new System.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>();
                System.Collections.Hashtable ConvertedToNormalTable = new System.Collections.Hashtable();

                if (__0 != null)
                {
                    var PhotonSender = GameInstances.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                    var PhotonID = __0.sender;
                    StringBuilder line = new StringBuilder();
                    StringBuilder prefix = new StringBuilder();
                    StringBuilder ContainerType = new StringBuilder();

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

                    if (__0.Parameters.ContainsKey(CustomDataByte) && __0.Parameters.paramDict != null && __0.Parameters.paramDict.ContainsKey(CustomDataByte))
                    {
                        var customdataobj = __0.Parameters[CustomDataByte];
                        if (customdataobj == null)
                        {
                            return true; // There's no need to continue to read and translate.
                        }

                        if (customdataobj != null)
                        {
                            #region Dictionary Parsing

                            if (customdataobj.GetIl2CppType().Equals(Il2CppType.Of<Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>>()))
                            {
                                isHashtableData = false;
                                ContainerType.Append($"[Dictionary] : ");
                                try
                                {
                                    var originaldict = customdataobj.Cast<Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>>();
                                    if (originaldict != null && originaldict.Count != 0)
                                    {
                                        foreach (byte key in originaldict.Keys)
                                        {
                                            ConvertedToNormalDict.Add(key, originaldict[key]);
                                        }
                                    }

                                }
                                catch (Exception e)
                                {
                                    ModConsole.DebugError("Failed to Cast Dictionary !");
                                    ModConsole.DebugErrorExc(e);
                                }

                                #endregion

                                #region Dictionary Patching

                                if (ConvertedToNormalDict != null && ConvertedToNormalDict.Count != 0)
                                {
                                    switch (__0.Code)
                                    {
                                        //case EventCode.USpeaker_Voice_Data:// Voice Data TODO : (Parrot Mode)
                                        //    log = true;
                                        //    break;

                                        case EventCode.Motion: // I believe this is motion, key 245 appears to be base64
                                            break;

                                        case EventCode.Disconnect_Message: // Kick Message?
                                            // TODO : Intercept the kick message, if is a votekick, force the game to go to the home world to avoid a bug.
                                            break;

                                        //case EventCode.RPC:
                                        //    break;

                                        //case EventCode.interest: // Interest - Interested in events
                                        //    break;
                                        //case EventCode.Master_allowing_player_to_join:
                                        //{

                                        //    Currentaction = HookAction.Reset;
                                        //    break;
                                        //}
                                        case EventCode.Custom_Properties:
                                            {

                                                break;
                                            }

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

                                                            PopupUtils.QueHudMessage($"<color=#FFA500>A Votekick has Been started (Check console!)</color>");
                                                            ModConsole.DebugWarning("VOTEKICK DETECTED : ");
                                                            break;

                                                        case ModerationCode.Block_Or_Mute:

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
                                                                    var PhotonPlayer = GameInstances.LoadBalancingPeer.GetPhotonPlayer(RemoteModerationPhotonID);
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
                                                                                    var blockedplayers = GameInstances.LoadBalancingPeer.GetPhotonPlayer(BlockedPlayersArray[i]);
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
                                                                                    var MutePlayer = GameInstances.LoadBalancingPeer.GetPhotonPlayer(MutePlayersArray[i]);
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

                                #endregion

                            }
                            else if (customdataobj.GetIl2CppType().Equals(Il2CppType.Of<Il2CppSystem.Collections.Hashtable>()))
                            {
                                isHashtableData = true;
                                ContainerType.Append($"[Hashtable]");
                                try
                                {
                                    var castedhashtable = __0.Parameters.paramDict[CustomDataByte].Cast<Il2CppSystem.Collections.Hashtable>();
                                    if (castedhashtable != null && castedhashtable.Count != 0)
                                    {
                                        // Use serialization since hashtable is serializable.
                                        ConvertedToNormalTable = Serialization.FromIL2CPPToManaged<System.Collections.Hashtable>(castedhashtable);
                                    }

                                }
                                catch (Exception e)
                                {
                                    ModConsole.DebugError("Failed to Cast Hashtable !");
                                    ModConsole.DebugErrorExc(e);
                                }
                            }
                        }
                    }

                    switch (Currentaction)
                    {
                        case HookAction.Patch:
                            {
                                try
                                {
                                    if (!isHashtableData)
                                    {
                                        ReplaceParameterData_Dictionary(ref __0, ConvertedToNormalDict);
                                    }
                                    else
                                    {
                                        ReplaceParameterData_Hashtable(ref __0, ConvertedToNormalTable);
                                    }

                                }
                                catch (Exception e)
                                {
                                    ModConsole.DebugError($"Exception in Patching OnEvent {ContainerType} Parameters");
                                    ModConsole.ErrorExc(e);
                                    return true;
                                }

                                break;
                            }
                        case HookAction.Empty:
                            {
                                try
                                {

                                    if (!isHashtableData)
                                    {
                                        ReplaceParameterData_Dictionary(ref __0, new Dictionary<byte, Object>());
                                    }
                                    else
                                    {
                                        ReplaceParameterData_Hashtable(ref __0, new Hashtable());
                                    }
                                }
                                catch (Exception e)
                                {
                                    ModConsole.DebugError($"Exception in Emptying OnEvent {ContainerType} Parameters");
                                    ModConsole.ErrorExc(e);
                                    return true;
                                }

                                break;
                            }
                        default:
                            break;
                    }

                    if (ConfigManager.General.LogEvents)
                    {
                        if (EventCodeToLog(__0.Code) && __0.Parameters.paramDict != null)
                        {
                            var CustomData = __0.Parameters.paramDict[CustomDataByte];
                            if (CustomData != null)
                            {
                                if (!isHashtableData)
                                {
                                    line.AppendLine();
                                    line.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(CustomData.Cast<Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>>()), Newtonsoft.Json.Formatting.Indented));
                                }
                                else
                                {
                                    line.AppendLine();
                                    line.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(CustomData.Cast<Il2CppSystem.Collections.Hashtable>()), Newtonsoft.Json.Formatting.Indented));

                                }

                            }

                            ModConsole.Log($"{HookActionToString(Currentaction)}{ContainerType.ToString()}{prefix.ToString()}{line.ToString()}");
                        }
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

        private static void ReplaceParameterData_Dictionary(ref EventData __0, Dictionary<byte, Il2CppSystem.Object> ConvertedToNormalDict)
        {
            try
            {
                if (__0.Parameters[CustomDataByte].GetIl2CppType().Equals(Il2CppType.Of<Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>>()))
                {
                    var ModifiedEvent = new Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>();
                    // Fills it if not empty!
                    if (ConvertedToNormalDict != null && ConvertedToNormalDict.Count != 0)
                    {
                        foreach (byte key in ConvertedToNormalDict.Keys)
                        {
                            ModifiedEvent.System_Collections_IDictionary_Add(Il2CppConverter.Generate_Il2CPPObject(key), ConvertedToNormalDict[key]);
                        }
                    }

                    var rebuiltparams = new NonAllocDictionary<byte, Object>();
                    for (byte i = 0; i <= byte.MaxValue; i++)
                    {
                        if (__0.Parameters.paramDict.ContainsKey(i))
                        {
                            // Replace here
                            if (i == CustomDataByte)
                            {
                                rebuiltparams.Add(i, ModifiedEvent);
                            }
                            else
                            {
                                __0.Parameters.TryGetValue(i, out var value);
                                if (value != null)
                                {
                                    rebuiltparams.Add(i, value);
                                }

                            }
                        }
                    }

                    // Clear parameters Dict
                    __0.Parameters.paramDict.Clear();
                    __0.Parameters.paramDict = null;
                    __0.Parameters.paramDict = new NonAllocDictionary<byte, Object>();
                    // Fill back everything
                    for (byte i = 0; i <= byte.MaxValue; i++)
                    {
                        if (rebuiltparams.ContainsKey(i))
                        {
                            if (!__0.Parameters.paramDict.ContainsKey(i))
                            {
                                rebuiltparams.TryGetValue(i, out var value);
                                if (value != null)
                                {
                                    __0.Parameters.paramDict.Add(i, value);
                                }
                            }
                        }

                    }
                }

            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
        }

        private static void ReplaceParameterData_Hashtable(ref EventData __0, System.Collections.Hashtable ConvertedToNormalTable)
        {
            try
            {
                if (__0.Parameters[CustomDataByte].GetIl2CppType().Equals(Il2CppType.Of<Il2CppSystem.Collections.Hashtable>()))
                {
                    var ModifiedEvent = new Il2CppSystem.Collections.Hashtable();
                    // Fills it if not empty!
                    foreach (byte key in ConvertedToNormalTable.Keys)
                    {
                        ModifiedEvent.Add(Il2CppConverter.Generate_Il2CPPObject(key), Serialization.FromManagedToIL2CPP<Il2CppSystem.Object>(ConvertedToNormalTable[key]));
                    }

                    var rebuiltparams = new NonAllocDictionary<byte, Object>();
                    for (byte i = 0; i <= byte.MaxValue; i++)
                    {
                        if (__0.Parameters.paramDict.ContainsKey(i))
                        {
                            // Replace here
                            if (i == CustomDataByte)
                            {
                                rebuiltparams.Add(i, ModifiedEvent);
                            }
                            else
                            {
                                __0.Parameters.TryGetValue(i, out var value);
                                if (value != null)
                                {
                                    rebuiltparams.Add(i, value);
                                }

                            }
                        }
                    }

                    // Clear parameters Dict
                    __0.Parameters.paramDict.Clear();
                    __0.Parameters.paramDict = null;
                    __0.Parameters.paramDict = new NonAllocDictionary<byte, Object>();
                    // Fill back everything
                    for (byte i = 0; i <= byte.MaxValue; i++)
                    {
                        if (rebuiltparams.ContainsKey(i))
                        {
                            if (!__0.Parameters.paramDict.ContainsKey(i))
                            {
                                rebuiltparams.TryGetValue(i, out var value);
                                if (value != null)
                                {
                                    __0.Parameters.paramDict.Add(i, value);
                                }
                            }
                        }

                    }

                }
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
        }

    }
}