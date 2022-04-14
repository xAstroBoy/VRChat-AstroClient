
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

    internal class EventDispatcher_HandleUdonEvent
    {
        internal static event System.Action<Player, GameObject, string> Event_OnUdonSyncRPC;

        internal static bool Handle_UdonEvent(ref VRC_EventHandler.VrcEvent VrcEvent, Player sender, GameObject TargetObject, string Action)
        {
            // Event is Invalid if Sender or TargetObject are both null, so let's just block it.
            if (sender == null || TargetObject == null) return false;
                
            Event_OnUdonSyncRPC?.SafetyRaiseWithParams(sender, TargetObject, Action);
            bool isBlocked = Bools.BlockUdon;
            try
            {
                bool isPlayerBlocked = false;
                isPlayerBlocked = Player_RPC_Firewall.IsBlocked(sender);
                if(isPlayerBlocked)
                {
                    isBlocked = true;
                }
                else
                {
                    isBlocked = GameObject_RPC_Firewall.Event_AllowLocalSender(TargetObject, Action);
                }

                // First let's check the sender 

                // Missing : Sender Firewall support (WIll skip the firewall step if sender is blocked)


                // Then let's check if the behaviour and it's event is in the Udon firewall 


                if (ConfigManager.General.LogUdonEvents)
                {
                    if (isBlocked)
                    {
                        Log.Write($"BLOCKED Udon RPC: Sender : {sender} , GameObject : {TargetObject.name}, Action : {Action}");
                    }
                    else
                    {
                        Log.Write($"Udon RPC: Sender : {sender} , GameObject : {TargetObject.name}, Action : {Action}");
                    }
                }
                return !isBlocked;

            }
            catch { }

            return !isBlocked;

        }


    }
}