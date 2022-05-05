using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class RPCFirewallEnforcer
    {

        internal static FirewallRule GetTheGoddamnFirewallRule(GameObject gameObject, string EventKey)
        {
            
            if(GameObject_RPC_Firewall.BlockedGameObjectRPCEvents.ContainsKey(gameObject.name))
            {
                var EventRules = GameObject_RPC_Firewall.BlockedGameObjectRPCEvents[gameObject.name];
                if(EventRules != null)
                {
                    if(EventRules.ContainsKey(EventKey))
                    {
                        return EventRules[EventKey];
                    }
                }
            }


            //foreach(var FirewallRulesDict in GameObject_RPC_Firewall.BlockedGameObjectRPCEvents)
            //{
            //    if (FirewallRulesDict.Key != null)
            //    {
            //        if (FirewallRulesDict.Key.Equals(transform))
            //        {
            //            foreach(var EventRules in FirewallRulesDict.Value)
            //            {
            //                if(EventRules.Key.Equals(EventKey))
            //                {
            //                    return EventRules.Value;
            //                }
            //            }
            //        }
            //    }
            //}
            return null;
        }

        


        internal static bool isRPCEventBlocked(Player sender, GameObject gameObject, string EventKey)
        {
            if (Player_RPC_Firewall.IsBlocked(sender))
            {
                return false;
            }
            var Rules = GameObject_RPC_Firewall.BlockedGameObjectRPCEvents;
            if (Rules != null)
            {
                if (Rules.Count != 0) // Skip all Events if is empty!
                {

                    var EventRule = GetTheGoddamnFirewallRule(gameObject, EventKey);
                    if (EventRule != null)
                    {
                        //Log.Write("Got Rule Container!");

                        if (sender != null)
                        {
                            var user = sender.GetVRCPlayerApi();

                            // Log.Write("Checking Player Rules...!");
                            if (user.isLocal)
                            {
                                return !EventRule.AllowLocalSender;
                            }
                            else
                            {
                                return !EventRule.AllowRemoteSender;
                            }
                        }
                        else
                        {

                            // This is covering all _ udonbehaviour events.
                            return !EventRule.AllowLocalSender;

                        }

                    }
                    else
                    {
                        //Log.Write("Firewall Rule is null!");

                    }


                }
            }
            return false;
        }


    }
}
