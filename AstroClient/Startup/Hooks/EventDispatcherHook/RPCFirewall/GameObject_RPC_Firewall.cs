
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

    internal class GameObject_RPC_Firewall : AstroEvents
    {
        internal override void OnRoomLeft()
        {
            BlockedGameObjectRPCEvents.Clear(); 
        }

        internal static ConcurrentDictionary<GameObject, List<string>> BlockedGameObjectRPCEvents = new ConcurrentDictionary<GameObject, List<string>>();

        internal static bool HasBlockedEvent(GameObject parent, string EventKey)
        {
            if (parent == null) return true;
            if (EventKey.IsNullOrEmptyOrWhiteSpace()) return true;
            if (BlockedGameObjectRPCEvents != null)
            {
                if(BlockedGameObjectRPCEvents.ContainsKey(parent))
                {
                    var keys = BlockedGameObjectRPCEvents[parent];
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

        internal static void Remove_UdonFirewall_Rule(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                Remove_UdonFirewall_Rule(item.UdonBehaviour, item.EventKey);
            }
        }
        internal static void Add_UdonFirewall_Rule(UdonBehaviour udon, string EventKey)
        {
            if (udon != null)
            {
                if (udon.isEventKeyValid(EventKey))
                {
                    EditRule(udon.gameObject, EventKey, false);
                }
            }
        }

        internal static void Remove_UdonFirewall_Rule(UdonBehaviour udon, string EventKey)
        {
            if (udon != null)
            {
                if (udon.isEventKeyValid(EventKey))
                {
                    EditRule(udon.gameObject, EventKey, true);
                }
            }
        }



        internal static void EditRule(GameObject gameObject, string EventKey, bool remove = false)
        {
            if (BlockedGameObjectRPCEvents != null)
            {
                if (BlockedGameObjectRPCEvents.ContainsKey(gameObject))
                {
                    var keys = BlockedGameObjectRPCEvents[gameObject];
                    if (keys != null && keys.Count != 0)
                    {
                        if (BlockedGameObjectRPCEvents[gameObject].Contains(EventKey))
                        {
                            if (remove)
                            {
                                Log.Debug($"[RPC GameObject Firewall] : Removed Block for  {gameObject.name} event : {EventKey}", Color.Orange);
                                BlockedGameObjectRPCEvents[gameObject].Remove(EventKey);
                            }
                        }
                        else
                        {
                            if(!remove)
                            {
                                Log.Debug($"[RPC GameObject Firewall] : Added Block for  {gameObject.name} event : {EventKey}", Color.LimeGreen);
                                BlockedGameObjectRPCEvents[gameObject].Add(EventKey);
                            }
                        }
                    }
                }
                else
                {
                    BlockedGameObjectRPCEvents.TryAdd(gameObject, new List<string>());
                    if (BlockedGameObjectRPCEvents.ContainsKey(gameObject))
                    {
                        var keys = BlockedGameObjectRPCEvents[gameObject];
                        if (keys != null && keys.Count != 0)
                        {
                            if (BlockedGameObjectRPCEvents[gameObject].Contains(EventKey))
                            {
                                if (remove)
                                {
                                    Log.Debug($"[RPC GameObject Firewall] : Removed Block for  {gameObject.name} event : {EventKey}", Color.Orange);
                                    BlockedGameObjectRPCEvents[gameObject].Remove(EventKey);
                                }
                            }
                            else
                            {
                                if (!remove)
                                {
                                    Log.Debug($"[RPC GameObject Firewall] : Added Block for  {gameObject.name} event : {EventKey}", Color.LimeGreen);
                                    BlockedGameObjectRPCEvents[gameObject].Add(EventKey);
                                }
                            }
                        }

                    }
                }
            }

        }


    }
}
