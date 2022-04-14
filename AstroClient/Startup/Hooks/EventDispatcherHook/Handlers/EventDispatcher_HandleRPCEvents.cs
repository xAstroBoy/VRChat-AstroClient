﻿using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
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

        internal static bool Handle_OtherRPCEvent(ref VRC_EventHandler.VrcEvent VrcEvent, Player sender, GameObject TargetObject, string actionText, string parameter, string eventtype, string broadcasttype)
        {
            bool isBlocked = Bools.BlockRPC;
            try
            {

                bool isPlayerBlocked = false;
                isPlayerBlocked = Player_RPC_Firewall.IsBlocked(sender);
                if (isPlayerBlocked)
                {
                    isBlocked = true;
                }
                else
                {
                    if (sender.Get_SenderAPIUser().IsSelf)
                    {
                        isBlocked = !GameObject_RPC_Firewall.Event_AllowLocalSender(TargetObject, actionText);
                    }
                    else
                    {
                        isBlocked = !GameObject_RPC_Firewall.Event_AllowRemoteSender(TargetObject, actionText);

                    }
                }

                if (ConfigManager.General.LogRPCEvents)
                {
                    if (isBlocked)
                    {
                        Log.Debug($"[RPC Firewall] Blocked : {sender}, {TargetObject.name}, {parameter}, [{actionText}], {eventtype}, {broadcasttype}", System.Drawing.Color.Orange);
                    }
                    else
                    {
                        Log.Write($"RPC: {sender}, {TargetObject.name}, {parameter}, [{actionText}], {eventtype}, {broadcasttype}");
                    }
                }
                return !isBlocked;

            }
            catch { }

            return !isBlocked;

        }
    }
}