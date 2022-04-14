using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
using VRC;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.Handlers
{
    #region Imports

    using Config;
    using Constants;
    using System;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    #endregion Imports

    internal static class EventDispatcher_HandleRPCEvents
    {
        internal static bool Handle_OtherRPCEvent(VRC_EventHandler.VrcEvent VrcEvent, Player sender, GameObject gameObject, string EventKey, string parameter, string eventtype, string broadcasttype)
        {
            bool isBlocked = Bools.BlockRPC;
            try
            {
                isBlocked = RPCFirewallEnforcer.isRPCEventBlocked(sender, gameObject, EventKey);
                if (ConfigManager.General.LogRPCEvents)
                {
                    if (isBlocked)
                    {
                        Log.Debug($"[RPC Firewall] Blocked : {sender.Get_SenderName()}, {gameObject.name}, {parameter}, [{EventKey}], {eventtype}, {broadcasttype}", System.Drawing.Color.Orange);
                    }
                    else
                    {
                        Log.Write($"RPC: {sender.Get_SenderName()}, {gameObject.name}, {parameter}, [{EventKey}], {eventtype}, {broadcasttype}");
                    }
                }
                return !isBlocked;
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }

            return !isBlocked;
        }
    }
}