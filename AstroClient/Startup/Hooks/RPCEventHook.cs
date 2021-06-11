namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using Harmony;
	using System;
	using System.Reflection;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	#endregion Imports

	public class RPCEventHook : GameEvents
    {
        public static event EventHandler<UdonSyncRPCEventArgs> Event_OnUdonSyncRPC;

        //public static
        private HarmonyInstance harmony1;

        private HarmonyInstance harmony2;

        public override void ExecutePriorityPatches()
        {
            MiscUtility.DelayFunction(1f, new Action(() =>
            {
                HookRPCEvent1();
            }));
        }

        public void HookRPCEvent1()
        {
            try
            {
                if (harmony1 == null)
                {
                    harmony1 = HarmonyInstance.Create(BuildInfo.Name + " RPCEventHook1");
                }

                harmony1.Patch(AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), new HarmonyMethod(typeof(RPCEventHook).GetMethod(nameof(OnRPCEvent1), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                ModConsole.DebugLog("Hooked VRC_EventDispatcherRFC 1");
            }
            catch
            {
                harmony1.UnpatchAll();
                HookRPCEvent1();
            }
        }

        private static bool OnRPCEvent1(Player __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
        {
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

            bool log = ConfigManager.General.LogRPCEvents;

            if (name.Equals("USpeak"))
            {
                log = false;
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
                OnTeleportRPCArgs message = null;
                var Parameters = Networking.DecodeParameters(__1.ParameterBytes);
                Vector3? Pos = Parameters[0].Unbox<Vector3>();
                Quaternion? rot = Parameters[1].Unbox<Quaternion>();
                VRC_SceneDescriptor.SpawnOrientation? spawnpos = Parameters[2].Unbox<VRC_SceneDescriptor.SpawnOrientation>();
                bool? UnknownBool = Parameters[3].Unbox<Boolean>();
                Int32? UnknownInt = Parameters[4].Unbox<System.Int32>();

                message = new OnTeleportRPCArgs(Pos.Value, rot.Value, spawnpos.Value, UnknownBool.Value, UnknownInt.Value);

                //foreach (var item in )
                //{
                //	Convert items
                //	if (item.Equals(Il2CppType.Of<Vector3>()))
                //	{
                //		Pos = item.Unbox<Vector3>();
                //	}
                //	else if (item.Equals(Il2CppType.Of<Quaternion>()))
                //	{
                //		rot = item.Unbox<Quaternion>();
                //	}
                //	else if (item.Equals(Il2CppType.Of<VRC_SceneDescriptor.SpawnOrientation>()))
                //	{
                //		spawnpos = item.Unbox<VRC_SceneDescriptor.SpawnOrientation>();
                //	}
                //}

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
                    ModConsole.Log($"Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
                }
                return true;
            }

            if (log)
            {
                if (parameter != "UdonSyncRunProgramAsRPC")
                {
                    ModConsole.Log($"RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}");
                }
            }

            return true;
        }
    }
}