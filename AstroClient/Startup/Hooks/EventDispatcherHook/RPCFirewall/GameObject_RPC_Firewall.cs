
using System;
using System.Drawing;
using AstroClient.xAstroBoy.Utility;
using Boo.Lang.Compiler.Ast;
using VRC;
using GameObject = UnityEngine.GameObject;
using Transform = UnityEngine.Transform;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using CustomClasses;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Extensions;
    using VRC.Udon;


    internal class GameObject_RPC_Firewall  : AstroEvents
    {
        internal override void OnRoomLeft()
        {
            BlockedGameObjectRPCEvents.Clear();
        }

        internal static ConcurrentDictionary<string, ConcurrentDictionary<string, FirewallRule>> BlockedGameObjectRPCEvents { get; } = new ConcurrentDictionary<string, ConcurrentDictionary<string, FirewallRule>>();




        internal static FirewallRule GetFirewallRule(string EventName, string EventKey, bool ShouldMake = true)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                if (BlockedGameObjectRPCEvents.ContainsKey(EventName))
                {
                    var FirewallRules = BlockedGameObjectRPCEvents[EventName];
                    if (FirewallRules != null)
                    {
                        if (FirewallRules.ContainsKey(EventKey))
                        {
                            FirewallRules.TryGetValue(EventKey, out var rule);
                            if (rule != null)
                            {
                                return rule;
                            }
                        }
                        else
                        {
                            if (ShouldMake)
                            {
                                // This spawns a new Firewall Rule for the event.
                                var newrule = new FirewallRule();
                                FirewallRules.TryAdd(EventKey, newrule);
                                return newrule;
                            }
                        }
                    }
                }
            }
            return null;
        }



        internal static bool RemoveFirewallRule(string EventName, string EventKey)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                if (BlockedGameObjectRPCEvents.ContainsKey(EventName))
                {
                    var rule = GetFirewallRule(EventName, EventKey, false);
                    if (rule != null)
                    {
                        rule.AllowRemoteSender = true;
                        rule.AllowLocalSender = true;
                        return true;
                    }
                }
            }
            return false;
        }



        internal static void Add_UdonFirewall_Rule(UdonBehaviour_Cached item, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
        {
            if (item != null)
            {
                Add_UdonFirewall_Rule(item.UdonBehaviour, item.EventKey, AllowLocalSender, AllowRemoteSender, PrintRuleChanges);
            }
        }

        internal static void Remove_UdonFirewall_Rule(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                Remove_UdonFirewall_Rule(item.UdonBehaviour, item.EventKey);
            }
        }
        internal static void Add_UdonFirewall_Rule(UdonBehaviour udon, string EventKey, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
        {
            if (udon != null)
            {
                if (udon.isEventKeyValid(EventKey))
                {
                    EditRule(udon.gameObject, EventKey, AllowLocalSender, AllowRemoteSender, PrintRuleChanges);
                }
            }
        }

        internal static void Remove_UdonFirewall_Rule(UdonBehaviour udon, string EventKey)
        {
            if (udon != null)
            {
                if (udon.isEventKeyValid(EventKey))
                {
                    RemoveRule(udon.gameObject, EventKey);
                }
            }
        }


        private static void EditRule(GameObject gameObject, string EventKey, bool AllowLocalSender = true, bool AllowRemoteSender = true, bool PrintRuleChanges = false)
        {
            EditRule(gameObject.name, EventKey, AllowLocalSender, AllowRemoteSender, PrintRuleChanges);
        }

        private static void EditRule(string EventName, string EventKey, bool AllowLocalSender = true, bool AllowRemoteSender = true, bool PrintRuleChanges = false)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                //  First let's check if the entry exists
                var FirewallRule = GetFirewallRule(EventName, EventKey, true);
                if(FirewallRule != null)
                {
                    FirewallRule.AllowLocalSender = AllowLocalSender;
                    FirewallRule.AllowRemoteSender = AllowRemoteSender;
                    if(PrintRuleChanges)
                    {
                        string AllowOrDenyLocalSender = null;
                        string AllowOrBlockRemoteSender = null;

                        if(FirewallRule.AllowLocalSender)
                        {
                            AllowOrDenyLocalSender = "Allow";
                        }
                        else
                        {
                            AllowOrDenyLocalSender = "Deny";
                        }
                        if (FirewallRule.AllowRemoteSender)
                        {
                            AllowOrBlockRemoteSender = "Allow";
                        }
                        else
                        {
                            AllowOrBlockRemoteSender = "Deny";
                        }

                        Log.Debug($"[RPC Firewall] : Firewall will {AllowOrDenyLocalSender} Local Sender & {AllowOrBlockRemoteSender} Remote Sender Event : {EventKey} on GameObject {EventName}", Color.Orange);

                    }
                }
                else
                {
                    BlockedGameObjectRPCEvents.TryAdd(EventName, new ConcurrentDictionary<string, FirewallRule>());
                    if (PrintRuleChanges)
                    {
                        Log.Debug($"[RPC Firewall] : Created New Rule For  {EventName}!", Color.Orange);
                    }
                    EditRule(EventName, EventKey, AllowLocalSender, AllowRemoteSender, PrintRuleChanges);
                }

            }
        }

        internal static void RemoveRule(GameObject gameObject, string EventKey)
        {
            RemoveRule(gameObject.name, EventKey);
        }

        internal static void RemoveRule(string EventName, string EventKey)
        {
            if (EventName != null)
            {
                if (BlockedGameObjectRPCEvents != null)
                {
                    if (RemoveFirewallRule(EventName, EventKey))
                    {
                        Log.Debug($"[RPC Firewall] : Removed Firewall block Event {EventKey} in  {EventName}!", Color.Orange);
                    }

                }
            }

        }


    }
}
