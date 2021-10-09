namespace AstroClient
{
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;

    internal class PickupBlocker : GameEvents
    {

        internal override void OnPlayerLeft(Player player)
        {
            var id = player.GetAPIUser().GetUserID();

            if(blockeduserids.Contains(id))
            {
                blockeduserids.Remove(id);
            }
        }


        internal static void RegisterPlayer(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (!blockeduserids.Contains(id))
            {
                blockeduserids.Add(id);
            }

        }

        internal static void RemovePlayer(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (blockeduserids.Contains(id))
            {
                blockeduserids.Remove(id);
            }

        }


        internal override void OnRoomLeft()
        {
            blockeduserids.Clear();
        }


        internal static List<string> blockeduserids { get; private set; } = new List<string>();
    }
}
