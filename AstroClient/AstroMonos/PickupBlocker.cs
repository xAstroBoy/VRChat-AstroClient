using System.Collections.Concurrent;
using Il2CppSystem.Xml;

namespace AstroClient.AstroMonos
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Components.Tools;
    using Components.UI.SingleTag;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;

    internal class PickupBlocker : AstroEvents
    {
        private static bool HasPickupControllerBeenAdded = false;

        private static void StartPickupBlockerSystem()
        {
            if (!HasPickupControllerBeenAdded)
            {
                foreach (var item in WorldUtils.Pickups)
                {
                    item.GetOrAddComponent<PickupController>();
                }

                HasPickupControllerBeenAdded = true;
            }

        }

        internal static void RegisterPlayer(Player player)
        {
            // TODO : Get Rid of PickupController dependency for PickupBlocker System

            // We might not need that anymore as We are testing the Owner detection system from PlayerList Hook.

            StartPickupBlockerSystem(); // Add everything only if we need to prevent trolls from accessing pickup interaction
            
            // For now let's leave it temporarily 

            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (blockeduserids.ContainsKey(id))
                {
                    if (blockeduserids.ContainsKey(id))
                    {
                        if (!blockeduserids[id].Blocked)
                        {
                            ModConsole.DebugLog($"Added Block for Player {player.GetDisplayName()}  from using Pickups.");
                            blockeduserids[id].Blocked = true;
                        }
                    }
                }
            }
        }

        internal static void RemovePlayer(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (blockeduserids.ContainsKey(id))
                {
                    if (blockeduserids.ContainsKey(id))
                    {
                        if (blockeduserids[id].Blocked)
                        {
                            ModConsole.DebugLog($"Removed Block for Player {player.GetDisplayName()}  from using Pickups.");
                            blockeduserids[id].Blocked = false;
                        }
                    }
                }
            }
        }

        internal override void OnRoomLeft()
        {
            HasPickupControllerBeenAdded = false;
            blockeduserids.Clear();
        }

        internal static bool IsPickupBlockedUser(string UserID)
        {
            if(blockeduserids != null)
            {
                if(blockeduserids.ContainsKey(UserID))
                {
                    return blockeduserids[UserID].Blocked;
                }
            }
            return false;
        }

        internal override void OnPlayerJoined(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (!blockeduserids.ContainsKey(id))
                {
                    blockeduserids.TryAdd(id, new PickupBlockerData(player));
                }
                else
                {
                    if (blockeduserids.ContainsKey(id))
                    {
                        blockeduserids[id].player = player;
                        if(blockeduserids[id].Blocked)
                        {
                            blockeduserids[id].SpawnTag();
                        }
                    }
                }
            }
        }

        internal override void OnPlayerLeft(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (blockeduserids.ContainsKey(id))
                {
                    blockeduserids[id].player = null;
                }
            }
        }


        internal static ConcurrentDictionary<string, PickupBlockerData> blockeduserids = new ConcurrentDictionary<string, PickupBlockerData>();

        internal class PickupBlockerData
        {
            
            internal Player player { get; set; }
            private SingleTag BlockedTag { get; set; }
            private bool _Blocked { get; set; }
            internal bool Blocked
            {
                get => _Blocked;
                set
                {
                    _Blocked = value;
                    if (value)
                    {
                        SpawnTag();
                    }
                    else
                    {
                        DestroyTag();
                    }
                }
            }

            internal void SpawnTag()
            {
                if (player != null)
                {
                    if (BlockedTag == null)
                    {
                        BlockedTag = player.AddSingleTag(Color.Orange, "Pickup Blocked");
                    }

                }
            }

            internal void DestroyTag()
            {
                if (BlockedTag != null)
                {
                    BlockedTag.DestroyMeLocal(true);
                }
            }

            internal PickupBlockerData(Player player, bool Blocked = false)
            {
                this.player = player;
                this.Blocked = Blocked;
            }
        }
    }
}