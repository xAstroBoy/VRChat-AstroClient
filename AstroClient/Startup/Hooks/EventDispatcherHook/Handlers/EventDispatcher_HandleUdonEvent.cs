
using System.Collections.Generic;
using System.Linq;
using AstroClient.ClientActions;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Tools.UdonEditor;
using VRC.Udon;
using VRC.Udon.Serialization.OdinSerializer.Utilities;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.Handlers
{
    #region Imports

    using System;
    using System.Reflection;
    
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

    internal class EventDispatcher_HandleUdonEvent : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }




        


        private static void OnRoomLeft()
        {
            CustomEventMessagesToIgnore.Clear();
        }

        private static List<string> CustomEventMessagesToIgnore { get; set; } = new();


        internal static bool Handle_UdonEvent(VRC_EventHandler.VrcEvent VrcEvent, Player sender, GameObject gameObject, string EventKey)
        {
            try
            {
                ClientEventActions.OnUdonSyncRPC?.SafetyRaiseWithParams(sender, gameObject, EventKey);
            }
            catch{}


            bool isBlocked = Bools.BlockUdon;
            try
            {

                isBlocked = RPCFirewallEnforcer.isRPCEventBlocked(sender, gameObject, EventKey);

                if (ConfigManager.General.LogUdonEvents)
                {
                    if (isBlocked)
                    {
                        Log.Write($"[UDON RPC Firewall] BLOCKED RPC: Sender : {sender.Get_SenderName()} , GameObject : {gameObject.name}, EventKey : {EventKey}", System.Drawing.Color.Orange);
                    }
                    else
                    {
                        Log.Write($"Udon RPC: Sender : {sender.Get_SenderName()} , GameObject : {gameObject.name}, Action : {EventKey}");
                    }
                }
                return !isBlocked;
            }
            catch
            {
                // Nobody cares lmao
            }
            return !isBlocked;


        }

        /// <summary>
        ///  Useful in world classes, register any eventkey is being spammed.
        /// </summary>
        /// <param name="eventkey"></param>
        internal static void IgnoreLogEventKey(string eventkey)
        {
            if(!CustomEventMessagesToIgnore.Contains(eventkey))
            {
                CustomEventMessagesToIgnore.Add(eventkey);
            }
        }

        /// <summary>
        /// Use this mostly for CustomEvent since is spammy as fuck.
        /// </summary>
        /// <param name="EventKey"></param>
        /// <returns></returns>
        private static bool IsEventLogIgnored(string EventKey)
        {
            if(CustomEventMessagesToIgnore.Count != 0)
            {
                if(CustomEventMessagesToIgnore.Contains(EventKey))
                {
                    return true;
                }
            }

            if (UdonCustomEventsLists.VRChatUdonSDKUpdateEvents.Contains(EventKey))
            {
                return true;
            }
            if (UdonCustomEventsLists.WorldKnownsSpammyKeys.Contains(EventKey))
            {
                return true;
            }
            return false;
        }

        internal static bool Handle_UdonEvent_CustomEvent(UdonBehaviour UdonEvent, string EventKey)
        {
            try
            {
                ClientEventActions.Udon_SendCustomEvent?.SafetyRaiseWithParams(UdonEvent, EventKey);
            }
            catch { }


            bool isBlocked = Bools.BlockUdon;


            bool isEventKeyLoggingIgnored = IsEventLogIgnored(EventKey);
            try
            {
                if (!Bools.BlockUdon)
                {
                    isBlocked = RPCFirewallEnforcer.isRPCEventBlocked(GameInstances.CurrentPlayer, UdonEvent.gameObject, EventKey);
                }



                if (ConfigManager.General.LogUdonCustomEvents)
                {
                    if (!isEventKeyLoggingIgnored)
                    {
                        if (isBlocked)
                        {
                            Log.Write($"[UDON RPC Firewall] BLOCKED RPC: Sender : {GameInstances.CurrentPlayer.Get_SenderName()} , Event : {UdonEvent.gameObject.name}, EventKey : {EventKey}", System.Drawing.Color.Orange);
                        }
                        else
                        {
                            Log.Write($"Udon RPC: Sender : {GameInstances.CurrentPlayer.Get_SenderName()} , Event : {UdonEvent.gameObject.name}, EventKey : {EventKey}");
                        }
                    }

                }
                return !isBlocked;
            }
            catch
            {
                // Nobody cares lmao
            }
            return !isBlocked;


        }



    }
}