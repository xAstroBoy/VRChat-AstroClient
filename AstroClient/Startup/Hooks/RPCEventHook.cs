namespace AstroClient
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using Il2CppSystem;
    using Photon.Realtime;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;

    #endregion Imports

    public class RPCEventHook : GameEvents
    {
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

        private static bool OnEvent(EventData __0)
        {
            try
            {
                object data = MiscUtils_Old.Serialization.FromIL2CPPToManaged<object>(__0.Parameters);
                var code = __0.Code;
                var player = Utils.PlayerManager.GetPlayerID(__0.sender);
                var photon = Utils.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                bool log = false;
                bool block = false;

                StringBuilder line = new StringBuilder();
                StringBuilder prefix = new StringBuilder();
                prefix.Append($"[Event ({code})] ");

                line.Append($"from: ({__0.sender}) ");
                if (WorldUtils.IsInWorld && player != null)
                {
                    line.Append($"'{player.DisplayName()}' ");
                }
                else if (WorldUtils.IsInWorld && photon != null)
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
                        PopupUtils.QueHudMessage("Moderation Event");
                        log = true;
                        break;
                    case 203: // Destroy
                        prefix.Append("Destroy: ");
                        log = true;
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
                if (log && ConfigManager.General.LogEvents || block)
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