namespace AstroClient
{
    #region Imports

    using AstroClient.Variables;
    using AstroClientCore.Events;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using Photon.Realtime;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using UnityEngine;
    using VRC.SDKBase;

    #endregion Imports

    public class RPCEventHook : GameEvents
    {
        #region OnEvent Events

        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerBlockedYou;

        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnblockedYou;

        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerMutedYou;

        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnmutedYou;

        #endregion OnEvent Events

        #region PlayerModerations
        public override void OnRoomLeft()
        {
            BlockedYouPlayers.Clear();
            MutedYouPlayers.Clear();
        }

        public override void OnPhotonLeft(Player player)
        {
            var userID = player.GetUserID();
            if (BlockedYouPlayers.Contains(userID))
            {
                BlockedYouPlayers.Remove(userID);
            }
            if (MutedYouPlayers.Contains(userID))
            {
                MutedYouPlayers.Remove(userID);
            }
        }


        public static List<string> BlockedYouPlayers { get; private set; } = new List<string>();

        public static List<string> MutedYouPlayers { get; private set; } = new List<string>();

        #endregion PlayerModerations

        public static event System.EventHandler<UdonSyncRPCEventArgs> Event_OnUdonSyncRPC;

        //public static
        private HarmonyLib.Harmony harmony;

        public override void ExecutePriorityPatches()
        {
            MiscUtils.DelayFunction(1f, new System.Action(() =>
            {
                InitPatches();
            }));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        public void InitPatches()
        {
            try
            {
                if (harmony == null)
                {
                    harmony = new HarmonyLib.Harmony(BuildInfo.Name + " RPCEventHook");
                }

                _ = harmony.Patch(AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), new HarmonyMethod(typeof(RPCEventHook).GetMethod(nameof(OnRPCEvent), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                _ = harmony.Patch(AccessTools.Method(typeof(LoadBalancingClient), nameof(LoadBalancingClient.OnEvent)), new HarmonyMethod(typeof(RPCEventHook).GetMethod(nameof(OnEvent), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                ModConsole.DebugLog("RPC Hooks Done");
            }
            catch
            {
                harmony.UnpatchAll();
                InitPatches();
            }
        }

        private static bool OnEvent(ref EventData __0)
        {
            try
            {
                object data = MiscUtils_Old.Serialization.FromIL2CPPToManaged<object>(__0.Parameters);
                var code = __0.Code;
                var photon = Utils.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                bool log = false;
                bool block = false;

                StringBuilder line = new StringBuilder();
                StringBuilder prefix = new StringBuilder();
                prefix.Append($"[Event ({code})] ");

                line.Append($"from: ({__0.Sender}) ");
                if (WorldUtils.IsInWorld && photon != null)
                {
                    line.Append($"'{photon.GetDisplayName()}'");
                }
                else
                {
                    line.Append($"'NULL' ");
                }

                switch (code)
                {
                    case 1:// Voice Data
                           // WIP Parrot Mode
                        break;

                    case 2:
                        string kickMessage = (data as Dictionary<byte, object>)[245].ToString();
                        break;

                    case 6:
                        object obj = Serialization.FromIL2CPPToManaged<object>(__0.customData);

                        switch (obj.ToString())
                        {
                            case "System.Byte[]":
                                break;

                            default:
                                line.Append("Invaid Event: Possibly a bad actor! ");
                                block = true;
                                __0.Reset();
                                break;
                        }
                        break;

                    case 8: // Interest - Interested in events
                        break;

                    case 7: // I believe this is motion, key 245 appears to be base64
                        break;

                    case 33: // Moderations

                        object rawData = Serialization.FromIL2CPPToManaged<object>(__0.Parameters);
                        var parsedData = (rawData as Dictionary<byte, object>);
                        var infoData = parsedData[245] as Dictionary<byte, object>;
                        int eventType = int.Parse(infoData[0].ToString());
                        string userID = photon.GetUserID();

                        switch (eventType)
                        {
                            case 21: // 10 blocked, 11 muted

                                if (infoData[10] != null && infoData[11] != null)
                                {
                                    // If Key 1 exists then this is a direct moderation
                                    if (infoData.ContainsKey(1))
                                    {
                                        int SenderID = int.Parse(infoData[1].ToString());
                                        //var VRCPlayer = Utils.PlayerManager.GetPlayerID(SenderID);

                                        var PhotonPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(SenderID);
                                        string SenderName = "?";
                                        if (PhotonPlayer != null) SenderName = PhotonPlayer.GetDisplayName();

                                        bool Blocked = bool.Parse(infoData[10].ToString());
                                        bool Muted = bool.Parse(infoData[11].ToString());

                                        if (Blocked)
                                        {
                                            if (!BlockedYouPlayers.Contains(userID))
                                            {
                                                BlockedYouPlayers.Add(userID);
                                                Event_OnPlayerBlockedYou.SafetyRaise(new PhotonPlayerEventArgs(photon));
                                                PopupUtils.QueHudMessage($"[Moderation] '{SenderName}' Blocked You");
                                            }
                                        }
                                        else
                                        {
                                            if (BlockedYouPlayers.Contains(userID))
                                            {
                                                BlockedYouPlayers.Remove(userID);
                                                Event_OnPlayerUnblockedYou.SafetyRaise(new PhotonPlayerEventArgs(photon));
                                                PopupUtils.QueHudMessage($"[Moderation] '{SenderName}' Unblocked You");
                                            }
                                        }
                                        if (Muted)
                                        {
                                            if (!MutedYouPlayers.Contains(userID))
                                            {
                                                MutedYouPlayers.Add(userID);
                                                Event_OnPlayerMutedYou.SafetyRaise(new PhotonPlayerEventArgs(photon));
                                                PopupUtils.QueHudMessage($"[Moderation] '{SenderName}' Muted You");
                                            }
                                        }
                                        else
                                        {
                                            if (MutedYouPlayers.Contains(userID))
                                            {
                                                MutedYouPlayers.Remove(userID);
                                                Event_OnPlayerUnmutedYou.SafetyRaise(new PhotonPlayerEventArgs(photon));
                                                PopupUtils.QueHudMessage($"[Moderation] '{SenderName}' Unmuted You");
                                            }
                                        }

                                        return !Blocked;
                                    }
                                    else
                                    {
                                        // It sends the Arrays when the Block and Mute Event happen fast.
                                        // if 10 is an Array it has all the PhotonIds that Blocked You
                                        // if 11 is an Array it has all the PhotonIds that Muted You
                                        var BlockedList = infoData[10] as int[];
                                        var MuteList = infoData[11] as int[];

                                        if (BlockedList.Count() == 0)
                                        {
                                        }
                                        else
                                        {
                                            for (int i = 0; i < BlockedList.Length; i++)
                                            {
                                                int blockid = BlockedList[i];
                                                var BlockPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(blockid);

                                                if (photon != null)
                                                {
                                                    if (!BlockedYouPlayers.Contains(userID))
                                                    {
                                                        BlockedYouPlayers.Add(userID);
                                                        Event_OnPlayerBlockedYou.SafetyRaise(new PhotonPlayerEventArgs(photon));
                                                        line.Append($"{BlockPlayer.GetDisplayName()} has you blocked!");
                                                        PopupUtils.QueHudMessage($"{BlockPlayer.GetDisplayName()} has you blocked!");
                                                    }
                                                    block = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                        log = true;
                        PopupUtils.QueHudMessage($"Moderation Event: {eventType}");
                        break;

                    case 203: // Destroy
                        prefix.Append("Destroy: ");
                        log = true;
                        break;

                    case 210:
                        return false;
                        break;
                    case 223: // This fired with what looked like base64 png data when I uploaded a VRC+ avatar
                        break;
                    case 253: // I think this is avatar switching related
                        break;

                    default:
                        log = true;
                        break;
                }

                string blockText = string.Empty;
                if (block)
                {
                    blockText = "[BLOCKED] ";
                }
                if (log || ConfigManager.General.LogEvents || block)
                {
                    line.Append($"\n{Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented)}");
                    ModConsole.Log($"{blockText}{prefix.ToString()}{line.ToString()}");
                }

                if (block)
                {
                    return false;
                }
            }
            catch (System.Exception e)
            {
                ModConsole.DebugError("Error in Photon OnEvent : ");
                ModConsole.DebugErrorExc(e);
                return true;
            }

            return true;
        }

        private static bool OnRPCEvent(ref VRC.Player __0, ref VRC_EventHandler.VrcEvent __1, ref VRC_EventHandler.VrcBroadcastType __2, ref int __3, ref float __4)
        {
            if (__1 == null) return false;

            bool log = ConfigManager.General.LogRPCEvents;
            bool blocked = Bools.BlockRPC;

            if (__1.Name.Length >= 100 || __1.ParameterString.Length >= 100)
            {
                if (__0 != null)
                {
                    ModConsole.Log($"Blocked Malicious RPC: {__0.DisplayName()}");
                }
                else
                {
                    ModConsole.Log($"Blocked Malicious RPC: NULL");
                }
                blocked = true;
                log = true;
            }

            string actionstring = string.Empty;
            string actiontext;
            try
            {
                if (__1.ParameterBytes != null && __1.ParameterBytes.Count != 0)
                {
                    actionstring = System.Text.Encoding.UTF8.GetString(__1.ParameterBytes);
                    actiontext = actionstring.Length >= 6 ? actionstring.Substring(6) : "Unknown Event";
                }
                else
                {
                    actiontext = "null";
                }
            }
            catch
            {
                return true;
            }

            string name = __1.ParameterObject != null ? __1.ParameterObject.name : "null";
            string parameter = __1.ParameterString ?? "null";
            string eventtype = __1.EventType != null ? __1.EventType.ToString() : "null";
            string broadcasttype = __2 != null ? __2.ToString() : "Null";

            if (name.Equals("USpeak"))
            {
                log = false;
                blocked = false;
            }

            string GameObjName = __1.ParameterObject != null ? __1.ParameterObject.name : "null";
            string sender;
            if (__0 != null)
            {
                sender = __0.GetAPIUser() != null ? __0.GetAPIUser().displayName : "null";
            }
            else
            {
                sender = "null";
            }
            if (parameter.Equals("TeleportRPC"))
            {
                var Parameters = Networking.DecodeParameters(__1.ParameterBytes);
                Vector3? Pos = Parameters[0].Unbox<Vector3>();
                Quaternion? rot = Parameters[1].Unbox<Quaternion>();
                VRC_SceneDescriptor.SpawnOrientation? spawnpos = Parameters[2].Unbox<VRC_SceneDescriptor.SpawnOrientation>();
                bool? UnknownBool = Parameters[3].Unbox<bool>();
                int? UnknownInt = Parameters[4].Unbox<int>();

                OnTeleportRPCArgs message = new OnTeleportRPCArgs(Pos.Value, rot.Value, spawnpos.Value, UnknownBool.Value, UnknownInt.Value);

                if (log)
                {
                    try
                    {
                        if (message != null)
                        {
                            ModConsole.Log($"RPC: {sender}, {name}, {parameter}, [Position : {message.Position.ToString()}, Rotation : {message.Rotation.ToString()}, SpawnOrientation : {message.SpawnOrientation}], {eventtype}, {broadcasttype}");
                        }
                        else
                        {
                            ModConsole.Log("Couldn't Cast TeleportRPC as message is null!");
                        }
                    }
                    catch { }
                    return true;
                }
            }

            if (parameter.Equals("UdonSyncRunProgramAsRPC"))
            {
                Event_OnUdonSyncRPC?.SafetyRaise(new UdonSyncRPCEventArgs(__0, __1.ParameterObject, actiontext));

                if (WorldUtils.WorldID.Equals(WorldIds.BClub) && __1.ParameterObject.name.Contains("Blue") && actiontext.Contains("Sit"))
                {
                    if (!PlayerUtils.DisplayName().Equals(sender))
                    {
                        ModConsole.Log($"BLOCKED Blue Chair: {sender}");
                        return false;
                    }
                }

                if (ConfigManager.General.LogUdonEvents)
                {
                    if (Bools.BlockUdon)
                    {
                        ModConsole.Log($"BLOCKED Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
                        return false;
                    }
                    else
                    {
                        ModConsole.Log($"Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
                    }
                }
                return true;
            }

            if (log)
            {
                if (parameter != "UdonSyncRunProgramAsRPC")
                {
                    if (blocked)
                    {
                        ModConsole.Log($"BLOCKED RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}");
                        return false;
                    }
                    else
                    {
                        ModConsole.Log($"RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}");
                    }
                }
            }

            return true;
        }
    }
}