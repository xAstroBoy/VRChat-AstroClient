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

        internal static FirewallRule GetTheGoddamnFirewallRule(Transform transform, string EventKey)
        {
            foreach(var FirewallRulesDict in GameObject_RPC_Firewall.BlockedGameObjectRPCEvents)
            {
                if (FirewallRulesDict.Key != null)
                {
                    if (FirewallRulesDict.Key.Equals(transform))
                    {
                        foreach(var EventRules in FirewallRulesDict.Value)
                        {
                            if(EventRules.Key.Equals(EventKey))
                            {
                                return EventRules.Value;
                            }
                        }
                    }
                }
            }
            return null;
        }


        internal static bool isRPCEventBlocked(Player sender, Transform transform, string EventKey)
        {
            var Rules = GameObject_RPC_Firewall.BlockedGameObjectRPCEvents;
            if (Rules != null)
            {
                if (Rules.Count != 0) // Skip all Events if is empty!
                {

                    var EventRule = GetTheGoddamnFirewallRule(transform, EventKey);
                    if (EventRule != null)
                    {
                        Log.Write("Got Rule Container!");

                        if (sender != null)
                        {
                            Log.Write("Checking Player Rules...!");

                            var user = sender.GetVRCPlayerApi();
                            if (user != null)
                            {
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
                        Log.Write("Firewall Rule is null!");

                    }


                }
            }
            return false;
        }


    }
}
