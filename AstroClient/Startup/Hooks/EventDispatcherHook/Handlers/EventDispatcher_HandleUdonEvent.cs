
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
    using AstroClient.Config;
    using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

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

                // TODO: ADD UDON & SENDER FIREWALL SUPPORT
                
                if (ConfigManager.General.LogUdonEvents)
                {
                    if (isBlocked)
                    {
                        Log.Write($"BLOCKED Udon RPC: Sender : {sender} , GameObject : {TargetObject.name}, Action : {Action}");
                        return false;
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