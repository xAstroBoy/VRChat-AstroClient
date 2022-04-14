using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
using VRC;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.Handlers
{

    #region Imports

    using System;
    using System.Reflection;
    using AstroEventArgs;
    using AstroMonos.Components.Spoofer;
    using Cheetos;
    using Config;
    using Constants;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using HarmonyLib;
    using WorldModifications.WorldsIds;

    #endregion Imports

    internal static class EventDispatcher_HandleRPCEvents
    {

        internal static bool Handle_OtherRPCEvent(ref VRC_EventHandler.VrcEvent VrcEvent, Player sender, GameObject TargetObject, string EventKey, string parameter, string eventtype, string broadcasttype)
        {
            bool isBlocked = Bools.BlockRPC;
            try
            {

                if (Player_RPC_Firewall.IsBlocked(sender))
                {
                    isBlocked = true;
                }

                if (!isBlocked)
                {
                    if (sender.Get_SenderAPIUser().IsSelf)
                    {
                        if (!GameObject_RPC_Firewall.Event_AllowLocalSender(TargetObject, EventKey))
                        {
                            Log.Debug("Firewall Should block Local Sender event...");
                            isBlocked = true;
                        }
                    }
                    else
                    {
                        if (!GameObject_RPC_Firewall.Event_AllowRemoteSender(TargetObject, EventKey))
                        {
                            Log.Debug("Firewall Should block Remote Sender event...");
                            isBlocked = true;
                        }

                    }
                }
                if (ConfigManager.General.LogRPCEvents)
                {
                    if (isBlocked)
                    {
                        Log.Debug($"[RPC Firewall] Blocked : {sender.Get_SenderName()}, {TargetObject.name}, {parameter}, [{EventKey}], {eventtype}, {broadcasttype}", System.Drawing.Color.Orange);
                    }
                    else
                    {
                        Log.Write($"RPC: {sender.Get_SenderName()}, {TargetObject.name}, {parameter}, [{EventKey}], {eventtype}, {broadcasttype}");
                    }
                }
                
                if(isBlocked)
                {
                    return false;
                }

            }
            catch(Exception e)
            {
                Log.Exception(e);
            }

            if(isBlocked)
            {
                return false;
            }
            return true;

        }
    }
}