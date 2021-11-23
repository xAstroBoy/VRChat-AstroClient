namespace AstroClient.AstroMonos
{
    using System.Collections.Generic;
    using VRC;
    using xAstroBoy.Utility;

    internal class PickupBlocker : AstroEvents
    {
        internal override void OnPlayerLeft(Player player)
        {

            var id = player.GetAPIUser().GetUserID();

            if (blockeduserids.Contains(id)) blockeduserids.Remove(id);
        }

        internal static void RegisterPlayer(Player player)
        {
            var vrcplayer = player.GetVRCPlayerApi();
            if (vrcplayer != null)
            {
                vrcplayer.EnablePickups(false);
            }

            var id = player.GetAPIUser().GetUserID();
            if (!blockeduserids.Contains(id))
            {
                ModConsole.DebugLog($"Added Block for Player {player.GetDisplayName()}  from using Pickups.");
                blockeduserids.Add(id);
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
            if (blockeduserids.Contains(id))
            {
                ModConsole.DebugLog($"Removed Block for Player {player.GetDisplayName()}  from using Pickups.");
                blockeduserids.Remove(id);
            }
        }

        internal override void OnRoomLeft()
        {
            blockeduserids.Clear();
        }

        internal static List<string> blockeduserids {  get;  private set; } = new List<string>();
    }
}