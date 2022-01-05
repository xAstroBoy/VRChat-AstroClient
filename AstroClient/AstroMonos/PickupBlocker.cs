﻿namespace AstroClient.AstroMonos
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Components.UI.SingleTag;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;

    internal class PickupBlocker : AstroEvents
    {

        internal static void RegisterPlayer(Player player)
        {
            var vrcplayer = player.GetVRCPlayerApi();
            if (vrcplayer != null)
            {
                vrcplayer.EnablePickups(false);
            }

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
            var vrcplayer = player.GetVRCPlayerApi();
            if (vrcplayer != null)
            {
                vrcplayer.EnablePickups(true);
            }

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
            blockeduserids.Clear();
        }

        internal static bool IsPickupBlockedUser(string UserID)
        {
            return GetBlockedUser(UserID) != null;
        }

        internal override void OnPlayerJoined(Player player)
        {
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