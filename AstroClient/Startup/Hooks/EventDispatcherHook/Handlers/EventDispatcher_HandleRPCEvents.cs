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

                // TODO: ADD SENDER FIREWALL SUPPORT

                if (ConfigManager.General.LogRPCEvents)
                {
                    if (isBlocked)
                    {
                        Log.Write($"BLOCKED RPC: {sender}, {TargetObject.name}, {parameter}, [{actionText}], {eventtype}, {broadcasttype}");
                        return false;
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