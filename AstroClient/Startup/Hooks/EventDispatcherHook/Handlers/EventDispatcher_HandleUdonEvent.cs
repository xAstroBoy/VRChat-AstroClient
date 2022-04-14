
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;

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
    using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
    using VRC;

    #endregion Imports

    internal static class EventDispatcher_HandleUdonEvent
    {
        internal static event System.Action<Player, GameObject, string> Event_OnUdonSyncRPC;

        internal static bool Handle_UdonEvent(VRC_EventHandler.VrcEvent VrcEvent, Player sender, GameObject gameObject, string EventKey)
        {
            try
            {
                Event_OnUdonSyncRPC?.SafetyRaiseWithParams(sender, gameObject, EventKey);
            }
            catch{}


            bool isBlocked = Bools.BlockUdon;
            try
            {

                isBlocked = RPCFirewallEnforcer.isRPCEventBlocked(sender, gameObject.transform, EventKey);
                Log.Debug($"isBlocked : {isBlocked}");

                if (ConfigManager.General.LogUdonEvents)
                {
                    if (isBlocked)
                    {
                        Log.Write($"[UDON RPC Firewall] : BLOCKED RPC: Sender : {sender.Get_SenderName()} , GameObject : {gameObject.name}, EventKey : {EventKey}", System.Drawing.Color.Orange);
                    }
                    else
                    {
                        Log.Write($"Udon RPC: Sender : {sender.Get_SenderName()} , GameObject : {gameObject.name}, Action : {EventKey}");
                    }
                }
            }
            catch(Exception e)
            {
                Log.Exception(e);
            }
            if (isBlocked)
            {
                return false;
            }
            else
            {
                return true;
            }


        }


    }
}