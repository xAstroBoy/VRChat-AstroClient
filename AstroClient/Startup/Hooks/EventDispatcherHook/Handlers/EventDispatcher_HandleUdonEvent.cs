
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
            try
            {
                Event_OnUdonSyncRPC?.SafetyRaiseWithParams(sender, TargetObject, Action);
            }
            catch{}


            bool isBlocked = Bools.BlockUdon;
            try
            {
                if(Player_RPC_Firewall.IsBlocked(sender))
                {
                    isBlocked = true;
                }

                if (!isBlocked)
                {
                    var user = sender.GetVRCPlayerApi();
                    if (user != null)
                    {
                        if (user.isLocal)
                        {
                            if (!GameObject_RPC_Firewall.Event_AllowLocalSender(TargetObject, Action))
                            {
                                isBlocked = true;
                            }
                        }
                        else
                        {
                            if (!GameObject_RPC_Firewall.Event_AllowRemoteSender(TargetObject, Action))
                            {
                                isBlocked = true;
                            }

                        }

                    }
                    else
                    {
                        if (!GameObject_RPC_Firewall.Event_AllowRemoteSender(TargetObject, Action))
                        {
                            isBlocked = true;
                        }

                    }
                    
                }


                if (ConfigManager.General.LogUdonEvents)
                {
                    if (isBlocked)
                    {
                        Log.Write($"[UDON RPC Firewall] : BLOCKED RPC: Sender : {sender.Get_SenderName()} , GameObject : {TargetObject.name}, Action : {Action}", System.Drawing.Color.Orange);
                    }
                    else
                    {
                        Log.Write($"Udon RPC: Sender : {sender.Get_SenderName()} , GameObject : {TargetObject.name}, Action : {Action}");
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