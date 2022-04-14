using AstroClient.Config;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.Handlers
{

    internal class EventDispatcher_HandleTeleportRPC
    {
        internal static bool HandleTeleportRPC(ref VRC_EventHandler.VrcEvent __1, Player sender, GameObject ParameterObject, string parameter, string EventType, string BroadcastType)
        {

            bool isBlocked = false;

            bool isPlayerBlocked = false;
            isPlayerBlocked = Player_RPC_Firewall.IsBlocked(sender);
            if (isPlayerBlocked)
            {
                isBlocked = true;
            }

            try
            {

                var Parameters = Networking.DecodeParameters(__1.ParameterBytes);
                Vector3? Position = Parameters[0].Unbox<Vector3>();
                Quaternion? Rotation = Parameters[1].Unbox<Quaternion>();
                VRC_SceneDescriptor.SpawnOrientation? SpawnOrientation = Parameters[2].Unbox<VRC_SceneDescriptor.SpawnOrientation>();
                bool? UnknownBool = Parameters[3].Unbox<bool>();
                int? UnknownInt = Parameters[4].Unbox<int>();


                if (ConfigManager.General.LogRPCEvents)
                {
                    if (isBlocked)
                    {
                        Log.Write($"BLOCKED RPC: {sender.Get_SenderName()}, {ParameterObject.name}, {parameter}, [Position : {Position.ToString()}, Rotation : {Rotation.ToString()}, SpawnOrientation : {SpawnOrientation}], {EventType}, {BroadcastType}");
                    }
                    else
                    {
                        Log.Write($"RPC: {sender.Get_SenderName()}, {ParameterObject.name}, {parameter}, [Position : {Position.ToString()}, Rotation : {Rotation.ToString()}, SpawnOrientation : {SpawnOrientation}], {EventType}, {BroadcastType}");
                    }
                }
            }
            catch
            {
            }
            if (isBlocked)
            {
                return false;
            }
            return true;

        }


    }
}