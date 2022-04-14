
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

    internal class UdonEvents_Firewall : AstroEvents
    {
        internal override void OnRoomLeft()
        {
            BlockedUdonEvents.Clear(); 
        }

        internal static ConcurrentDictionary<GameObject, List<string>> BlockedUdonEvents = new ConcurrentDictionary<GameObject, List<string>>();

        internal static bool HasBlockedEvent(GameObject parent, string EventKey)
        {
            if (parent == null) return true;
            if (EventKey.IsNullOrEmptyOrWhiteSpace()) return true;
            if (BlockedUdonEvents != null)
            {
                if(BlockedUdonEvents.ContainsKey(parent))
                {
                    var keys = BlockedUdonEvents[parent];
                    if(keys != null && keys.Count != 0)
                    {
                        return keys.Contains(EventKey);
                    }
                }
            }

            return false;
        }

        internal static void Add_UdonFirewall_Rule(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                Add_UdonFirewall_Rule(item.UdonBehaviour, item.EventKey);
            }
        }

        internal static void Add_UdonFirewall_Rule(UdonBehaviour udon, string key)
        {
            if (udon != null)
            {
                if (udon.isEventKeyValid(key))
                {
                    if (BlockedUdonEvents != null)
                    {
                        if (BlockedUdonEvents.ContainsKey(udon.gameObject))
                        {
                            var keys = BlockedUdonEvents[udon.gameObject];
                            if (keys != null && keys.Count != 0)
                            {
                                if (!BlockedUdonEvents[udon.gameObject].Contains(key))
                                {
                                    Log.Debug($"[UDON FIREWALL :] Added Block for  {udon.gameObject.name} event : {key}", Color.LimeGreen);
                                    BlockedUdonEvents[udon.gameObject].Add(key);
                                }
                            }
                        }
                        else
                        {
                            BlockedUdonEvents.TryAdd(udon.gameObject, new List<string>());
                            if (BlockedUdonEvents.ContainsKey(udon.gameObject))
                            {
                                var keys = BlockedUdonEvents[udon.gameObject];
                                if (keys != null && keys.Count != 0)
                                {
                                    if (!BlockedUdonEvents[udon.gameObject].Contains(key))
                                    {
                                        Log.Debug($"[UDON FIREWALL :] Added Block for  {udon.gameObject.name} event : {key}", Color.LimeGreen);
                                        BlockedUdonEvents[udon.gameObject].Add(key);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        internal static void Remove_UdonFirewall_Rule(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                Remove_UdonFirewall_Rule(item.UdonBehaviour, item.EventKey);
            }
        }

        internal static void Remove_UdonFirewall_Rule(UdonBehaviour udon, string key)
        {
            if (udon != null)
            {
                if (udon.isEventKeyValid(key))
                {
                    if (BlockedUdonEvents != null)
                    {
                        if (BlockedUdonEvents.ContainsKey(udon.gameObject))
                        {
                            var keys = BlockedUdonEvents[udon.gameObject];
                            if (keys != null && keys.Count != 0)
                            {
                                if (BlockedUdonEvents[udon.gameObject].Contains(key))
                                {
                                    Log.Debug($"[UDON FIREWALL :] Removed Block for  {udon.gameObject.name} event : {key}", Color.Orange);
                                    BlockedUdonEvents[udon.gameObject].Remove(key);
                                }
                            }
                        }
                        else
                        {
                            BlockedUdonEvents.TryAdd(udon.gameObject, new List<string>());
                            if (BlockedUdonEvents.ContainsKey(udon.gameObject))
                            {
                                var keys = BlockedUdonEvents[udon.gameObject];
                                if (keys != null && keys.Count != 0)
                                {
                                    if (BlockedUdonEvents[udon.gameObject].Contains(key))
                                    {
                                        Log.Debug($"[UDON FIREWALL :] Removed Block for  {udon.gameObject.name} event : {key}", Color.Orange);
                                        BlockedUdonEvents[udon.gameObject].Remove(key);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

    }
}
