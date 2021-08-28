namespace AstroClient
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using Harmony;
    using System;
    using System.Reflection;
    using UnhollowerBaseLib;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    #endregion Imports

    public class RPCEventHook : GameEvents
    {
        public static event EventHandler<UdonSyncRPCEventArgs> Event_OnUdonSyncRPC;

        //public static
        private HarmonyLib.Harmony harmony;

        public override void ExecutePriorityPatches()
        {
            MiscUtils.DelayFunction(1f, new Action(() =>
            {
                InitPatches();
            }));
        }

        public void InitPatches()
        {
            try
            {
                if (harmony == null)
                {
                    harmony = new HarmonyLib.Harmony(BuildInfo.Name + " RPCEventHook");
                }

                harmony.Patch(AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), new HarmonyMethod(typeof(RPCEventHook).GetMethod(nameof(OnRPCEvent), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                ModConsole.DebugLog("RPC Hooks Done");
            }
            catch
            {
                harmony.UnpatchAll();
                InitPatches();
            }
        }

        private static bool OnRPCEvent(ref Player __0, ref VRC_EventHandler.VrcEvent __1, ref VRC_EventHandler.VrcBroadcastType __2, ref int __3, ref float __4)
        {
            if (__1 == null) return false;

            bool log = ConfigManager.General.LogRPCEvents;
            bool blocked = Bools.BlockRPC;

            if (__1.Name.Length >= 100 || __1.ParameterString.Length >= 100)
            {
                ModConsole.Log($"{__0.DisplayName()}: Sent Malicious RPC!");
                return false;
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
                bool? UnknownBool = Parameters[3].Unbox<Boolean>();
                Int32? UnknownInt = Parameters[4].Unbox<System.Int32>();

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
                Event_OnUdonSyncRPC.SafetyRaise(new UdonSyncRPCEventArgs(__0, __1.ParameterObject, actiontext));
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