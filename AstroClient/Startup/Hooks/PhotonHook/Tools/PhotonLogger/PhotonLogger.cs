namespace AstroClient.Startup.Hooks.PhotonHook.Tools.PhotonLogger;

using System.Text;
using AstroClient.Tools;
using Config;
using ExitGames.Client.Photon;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Il2CppSystem.Collections.Generic;
using Newtonsoft.Json;
using Structs;
using Structs.ModerationStructures;
using Structs.PhotonBytes;
using Translators;
using xAstroBoy.Extensions;
using xAstroBoy.Utility;
using Exception = System.Exception;

internal class PhotonLogger
{

    private static bool EventCodeToLog(byte code)
    {
        switch (code)
        {
            case VRChat_Photon_Events.OpRemoveCache_etc: return false;
            case VRChat_Photon_Events.USpeaker_Voice_Data: return false;
            case VRChat_Photon_Events.Disconnect_Message: return true;
            case VRChat_Photon_Events.Cached_Events: return false;
            case VRChat_Photon_Events.Master_allowing_player_to_join: return true;
            case VRChat_Photon_Events.RPC: return false;
            case VRChat_Photon_Events.Motion: return false;
            case VRChat_Photon_Events.interest: return false;
            case VRChat_Photon_Events.Reliable: return false;
            case VRChat_Photon_Events.Moderations: return true;
            case VRChat_Photon_Events.OpCleanRpcBuffer: return false;
            case VRChat_Photon_Events.SendSerialize: return false;
            case VRChat_Photon_Events.Instantiation: return false;
            case VRChat_Photon_Events.CloseConnection: return false;
            case VRChat_Photon_Events.Destroy: return false;
            case VRChat_Photon_Events.RemoveCachedRPCs: return false;
            case VRChat_Photon_Events.SendSerializeReliable: return false;
            case VRChat_Photon_Events.Destroy_Player: return false;
            case VRChat_Photon_Events.SetMasterClient: return false;
            case VRChat_Photon_Events.Request_Ownership: return false;
            case VRChat_Photon_Events.Transfer_Ownership: return false;
            case VRChat_Photon_Events.VacantViewIds: return false;
            case VRChat_Photon_Events.UploadAvatar: return false;
            case VRChat_Photon_Events.Custom_Properties: return true;
            case VRChat_Photon_Events.Leaving_World: return false;
            case VRChat_Photon_Events.Joining_World: return false;
            default:
                return false;
        }
    }

    internal static void PrintEvent(ref EventData PhotonData, HookAction HookAction, bool isDictionary, bool isHashtable, bool isUnknownType)
    {
        if (ConfigManager.General.LogEvents)
        {
            StringBuilder line = new StringBuilder();
            StringBuilder prefix = new StringBuilder();
            StringBuilder ContainerType = new StringBuilder();
            try
            {
                if (EventCodeToLog(PhotonData.Code))
                {
                    var PhotonSender = GameInstances.LoadBalancingPeer.GetPhotonPlayer(PhotonData.sender);
                    var translated = Photon_StructToString.TranslateEventData(PhotonData.Code);
                    if (translated.IsNotNullOrEmptyOrWhiteSpace())
                        prefix.Append($"[Event ({PhotonData.Code})][{translated}]: ");
                    else
                        prefix.Append($"[Event ({PhotonData.Code})] ");

                    line.Append($"from: ({PhotonData.Sender}) ");
                    if (WorldUtils.IsInWorld && PhotonSender != null)
                        line.Append($"'{PhotonSender.GetDisplayName()}'");
                    else
                        line.Append("'NULL' ");

                    if (PhotonData.CustomData != null)
                    {

                        if (isDictionary)
                        {
                            ContainerType.Append($"[Dictionary] : ");

                            var casteddict = PhotonData.CustomData.Cast<Dictionary<byte, Object>>();
                            if (casteddict != null)
                            {
                                // If Is a moderation event, get the moderation Type name 
                                if (PhotonData.Code == VRChat_Photon_Events.Moderations)
                                {
                                    var moderationevent = casteddict[ModerationCode.EventCode].Unbox<byte>();
                                    var moderationeventname = Photon_StructToString.TranslateModerationEvent(moderationevent);
                                    if (moderationeventname.IsNotNullOrEmptyOrWhiteSpace()) prefix.Append($"{moderationeventname} ");
                                }

                                line.AppendLine();
                                line.AppendLine(JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(casteddict), Formatting.Indented));
                            }
                        }

                        if (isHashtable)
                        {
                            ContainerType.Append("[Hashtable] : ");
                            var CastedHashtable = PhotonData.CustomData.Cast<Hashtable>();
                            if (CastedHashtable != null)
                            {
                                line.AppendLine();
                                line.AppendLine(JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(CastedHashtable), Formatting.Indented));
                            }
                        }

                        if (isUnknownType)
                        {
                            ModConsole.DebugWarning($"Unknown Type Detected : {PhotonData.CustomData.GetIl2CppType().FullName}");
                            return;
                        }
                    }

                    ModConsole.Log($"{Photon_StructToString.HookActionToString(HookAction)}{ContainerType}{prefix}{line}");
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
        }
    }
}