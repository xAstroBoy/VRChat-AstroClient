
using System.Drawing;
using GameObject = UnityEngine.GameObject;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using CustomClasses;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Extensions;
    using VRC.Udon;

    internal partial class GameObject_RPC_Firewall : AstroEvents
    {
        internal override void OnRoomLeft()
        {
            BlockedGameObjectRPCEvents.Clear(); 
        }

        internal static ConcurrentDictionary<GameObject, ConcurrentDictionary<string, FirewallRule>> BlockedGameObjectRPCEvents = new ConcurrentDictionary<GameObject, ConcurrentDictionary<string, FirewallRule>>();



        internal static FirewallRule GetFirewallRules(GameObject parent, string EventKey, bool AddIfNotExisting = false)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                if (BlockedGameObjectRPCEvents.ContainsKey(parent))
                {
                    var FirewallRules = BlockedGameObjectRPCEvents[parent];
                    if (FirewallRules != null)
                    {
                        if (FirewallRules.ContainsKey(EventKey))
                        {
                            return FirewallRules[EventKey];
                        }
                        else
                        {
                            if (AddIfNotExisting)
                            {
                                // This spawns a new Firewall Rule for the event.
                                if (FirewallRules.TryAdd(EventKey, new FirewallRule()))
                                {
                                    return FirewallRules[EventKey];
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        internal static bool RemoveFirewallRule(GameObject parent, string EventKey)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                if (BlockedGameObjectRPCEvents.ContainsKey(parent))
                {
                    var FirewallRules = BlockedGameObjectRPCEvents[parent];
                    if (FirewallRules != null)
                    {
                        if (FirewallRules.ContainsKey(EventKey))
                        {
                            return FirewallRules.TryRemove(EventKey, out _);
                        }

                    }
                }
            }
            return false;
        }
        internal static ConcurrentDictionary<string, FirewallRule> GetAllFirewallRules(GameObject parent)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                if (BlockedGameObjectRPCEvents.ContainsKey(parent))
                {
                    return BlockedGameObjectRPCEvents[parent];
                }
            }
            return null;
        }
        internal static bool Event_AllowLocalSender(GameObject parent, string EventKey)
        {
            if (parent == null) return true;
            if (EventKey.IsNullOrEmptyOrWhiteSpace()) return true;
            if (BlockedGameObjectRPCEvents != null)
            {
                var rules = GetFirewallRules(parent, EventKey, false);
                if(rules != null)
                {
                    return rules.AllowLocalSender;
                }
                
            }

            return false;
        }

        internal static bool Event_AllowRemoteSender(GameObject parent, string EventKey)
        {
            if (parent == null) return true;
            if (EventKey.IsNullOrEmptyOrWhiteSpace()) return true;
            if (BlockedGameObjectRPCEvents != null)
            {
                var rules = GetFirewallRules(parent, EventKey, false);
                if (rules != null)
                {
                    return rules.AllowRemoteSender;
                }
            }

            return false;
        }



        internal static void Add_UdonFirewall_Rule(UdonBehaviour_Cached item, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
        {
            if (item != null)
            {
                Add_UdonFirewall_Rule(item.UdonBehaviour, item.EventKey);
            }
        }

        internal static void Remove_UdonFirewall_Rule(UdonBehaviour_Cached item, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
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
                    EditRule(udon.gameObject, EventKey, false);
                }
            }
        }

        internal static void Remove_UdonFirewall_Rule(UdonBehaviour udon, string EventKey, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
        {
            if (udon != null)
            {
                if (udon.isEventKeyValid(EventKey))
                {
                    RemoveRule(udon.gameObject, EventKey);
                }
            }
        }




        internal static void EditRule(GameObject gameObject, string EventKey, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                //  First let's check if the entry exists
                var FirewallRule = GetFirewallRules(gameObject, EventKey);
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

                        Log.Debug($"[RPC Firewall] : Firewall will {AllowOrDenyLocalSender} Local Sender & {AllowOrBlockRemoteSender} Remote Sender Event : {EventKey} on GameObject {gameObject.name}", Color.Orange);

                    }
                }
                else
                {
                    BlockedGameObjectRPCEvents.TryAdd(gameObject, new ConcurrentDictionary<string, FirewallRule>());
                    if(PrintRuleChanges)
                    {
                        Log.Debug($"[RPC Firewall] : Created New Rule For  {gameObject.name}!", Color.Orange);
                    }
                    EditRule(gameObject, EventKey, AllowLocalSender, AllowRemoteSender, PrintRuleChanges);
                }
            }

        }

        internal static void RemoveAllRules(GameObject gameObject)
        {
            if (gameObject != null)
            {
                if (BlockedGameObjectRPCEvents != null)
                {
                    if (BlockedGameObjectRPCEvents.ContainsKey(gameObject))
                    {
                        Log.Debug($"[RPC Firewall] : Removed {GetAllFirewallRules(gameObject).Count} Firewall Rules for {gameObject.name}!", Color.Orange);
                    }

                }
            }

        }
        internal static void RemoveRule(GameObject gameObject, string EventKey)
        {
            if (gameObject != null)
            {
                if (BlockedGameObjectRPCEvents != null)
                {
                    if (RemoveFirewallRule(gameObject, EventKey))
                    {
                        Log.Debug($"[RPC Firewall] : Removed Firewall block Event {EventKey} in  {gameObject.name}!", Color.Orange);
                    }

                }
            }

        }


    }
}
