namespace AstroClient.AstroMonos
{
    using System.Collections.Generic;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using UnhollowerBaseLib.Attributes;
    using VRC;

    internal class PickupBlocker : GameEvents
    {
        internal override void OnPlayerLeft(Player player)
        {
            var id = player.GetAPIUser().GetUserID();

            if (blockeduserids.Contains(id))
            {
                blockeduserids.Remove(id);
            }
        }

        internal static void RegisterPlayer(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (!blockeduserids.Contains(id))
            {
                ModConsole.DebugLog($"Added Block for Player {player.GetDisplayName()}  from using Pickups.");
                blockeduserids.Add(id);
            }
        }

        internal static void RemovePlayer(Player player)
        {
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

        internal static List<string> blockeduserids { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } = new List<string>();
    }
}