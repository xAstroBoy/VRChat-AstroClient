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
            StartPickupBlockerSystem(); // Add everything only if we need to prevent trolls from accessing pickup interaction
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (!IsPickupBlockedUser(id))
                {
                    ModConsole.DebugLog($"Added Block for Player {player.GetDisplayName()}  from using Pickups.");
                    var tag = player.AddSingleTag(Color.Orange, "Pickup Blocked");
                    var newentry = new BlockedUsersFromPickups(id, tag);
                    blockeduserids.Add(newentry);
                }
            }
        }

        internal static void RemovePlayer(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                var entry = GetBlockedUser(id);
                if (entry != null)
                {
                    ModConsole.DebugLog($"Removed Block for Player {player.GetDisplayName()}  from using Pickups.");
                    if (entry.BlockedUserTag != null)
                    {
                        entry.BlockedUserTag.DestroyMeLocal();
                    }
                    blockeduserids.Remove(entry);
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
            return GetBlockedUser(UserID) != null;
        }

        internal override void OnPlayerJoined(Player player)
        {
            if (blockeduserids.Count == 0) return;
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                var entry = GetBlockedUser(id);
                if (entry != null)
                {
                    if (entry.BlockedUserTag == null)
                    {
                        entry.BlockedUserTag = player.AddSingleTag(Color.Orange, "Pickup Blocked");
                    }
                }
            }
        }

        internal override void OnPlayerLeft(Player player)
        {
            if (blockeduserids.Count == 0) return;
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                var entry = GetBlockedUser(id);
                if (entry != null)
                {
                    if (entry.BlockedUserTag != null)
                    {
                        entry.BlockedUserTag.DestroyMeLocal();
                        entry.BlockedUserTag = null;
                    }
                }
            }
        }

        internal static BlockedUsersFromPickups GetBlockedUser(string UserID)
        {
            if (blockeduserids.Count == 0) return null;
            if (blockeduserids.Count != 0)
            {
                foreach (var entry in blockeduserids)
                {
                    if (entry.UserID.Equals(UserID))
                    {
                        return entry;
                    }
                }
            }

            return null;
        }

        internal static List<BlockedUsersFromPickups> blockeduserids { get; private set; } = new List<BlockedUsersFromPickups>();

        internal class BlockedUsersFromPickups
        {
            internal SingleTag BlockedUserTag { get; set; }
            internal string UserID { get; set; }

            internal BlockedUsersFromPickups(string UserID, SingleTag Tag)
            {
                this.UserID = UserID;
                this.BlockedUserTag = Tag;
            }
        }
    }
}