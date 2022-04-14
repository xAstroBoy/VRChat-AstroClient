using VRC;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Reflection;
    using AstroEventArgs;
    using AstroMonos.Components.Spoofer;
    using Cheetos;
    using Config;
    using Constants;
    using Tools.Extensions;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using HarmonyLib;
    using WorldModifications.WorldsIds;

    #endregion Imports
    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class RPCEventHook : AstroEvents
    {

        internal static event System.Action<Player, GameObject, string> Event_OnUdonSyncRPC;

        //internal static 
        private HarmonyLib.Harmony harmony;

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(HarmonyLib.AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), GetPatch(nameof(OnRPCEvent)));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(RPCEventHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        // TODO : Clean and reorganize the entire event system 

        private static bool OnRPCEvent(ref VRC.Player __0, ref VRC_EventHandler.VrcEvent __1, ref VRC_EventHandler.VrcBroadcastType __2, ref int __3, ref float __4)
        {
            try
            {

                bool log = ConfigManager.General.LogRPCEvents;
                bool blocked = Bools.BlockRPC;

                if (__1.Name.Length >= 100 || __1.ParameterString.Length >= 100)
                {
                    if (__0 != null)
                    {
                        Log.Write($"Blocked Malicious RPC: {__0.DisplayName()}");
                    }
                    else
                    {
                        Log.Write($"Blocked Malicious RPC: NULL");
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

                if (__0.DisplayName() == "SysNetr")
                {
                    blocked = true;
                }

                if (name.Equals("USpeak"))
                {
                    log = false;
                    blocked = false;
                }

                string GameObjName = __1.ParameterObject != null ? __1.ParameterObject.name : "null";
                string sender;
                if (__0 != null)
                {
                    if (__0.GetAPIUser() != null)
                    {
                        if (__0.GetAPIUser().IsSelf)
                        {
                            if (PlayerSpooferUtils.IsSpooferActive)
                            {
                                sender = PlayerSpooferUtils.Original_DisplayName;
                            }
                            else
                            {
                                sender = __0.GetAPIUser().displayName;
                            }
                        }
                        else
                        {
                            sender = __0.GetAPIUser().displayName;
                        }
                    }
                    else
                    {
                        sender = "null";
                    }
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
                                Log.Write($"RPC: {sender}, {name}, {parameter}, [Position : {message.Position.ToString()}, Rotation : {message.Rotation.ToString()}, SpawnOrientation : {message.SpawnOrientation}], {eventtype}, {broadcasttype}");
                            }
                            else
                            {
                                Log.Write("Couldn't Cast TeleportRPC as message is null!");
                            }
                        }
                        catch
                        {
                            return true;
                        }

                        return true;
                    }
                }

                if (parameter.Equals("UdonSyncRunProgramAsRPC"))
                {
                    Event_OnUdonSyncRPC?.SafetyRaiseWithParams(__0, __1.ParameterObject, actiontext);

                    try
                    {

                        if (WorldUtils.WorldID.Equals(WorldIds.JustBClub) && __1.ParameterObject.name.Contains("Blue") && actiontext.Contains("Sit"))
                        {
                            if (!PlayerUtils.DisplayName().Equals(sender))
                            {
                                Log.Write($"BLOCKED Blue Chair: {sender}");
                                return false;
                            }
                        }

                        if (ConfigManager.General.LogUdonEvents)
                        {
                            if (Bools.BlockUdon)
                            {
                                Log.Write($"BLOCKED Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
                                return false;
                            }
                            else
                            {
                                Log.Write($"Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
                            }
                        }
                    }
                    catch
                    {
                        return true;
                    }

                    return true;
                }

                if (log)
                {
                    if (parameter != "UdonSyncRunProgramAsRPC")
                    {
                        if (blocked)
                        {
                            Log.Write($"BLOCKED RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}");
                            return false;
                        }
                        else
                        {
                            Log.Write($"RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}");
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return true;
            }

            return true;
        }
    }
}