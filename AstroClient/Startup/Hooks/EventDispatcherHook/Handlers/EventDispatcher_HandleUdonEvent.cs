
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
                    if (sender.Get_SenderAPIUser().IsSelf)
                    {
                        isBlocked = !GameObject_RPC_Firewall.Event_AllowLocalSender(TargetObject, Action);
                    }
                    else
                    {
                        isBlocked = !GameObject_RPC_Firewall.Event_AllowRemoteSender(TargetObject, Action);

                    }
                }


                if (ConfigManager.General.LogUdonEvents)
                {
                    if (isBlocked)
                    {
                        Log.Debug($"[UDON RPC Firewall] : BLOCKED RPC: Sender : {sender.Get_SenderName()} , GameObject : {TargetObject.name}, Action : {Action}", System.Drawing.Color.Orange);
                    }
                    else
                    {
                        Log.Write($"Udon RPC: Sender : {sender.Get_SenderName()} , GameObject : {TargetObject.name}, Action : {Action}");
                    }
                }
                return !isBlocked;

            }
            catch { }

            return !isBlocked;

        }


    }
}