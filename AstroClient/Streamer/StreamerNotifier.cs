namespace AstroClient.Streamer
{
    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;

    public class StreamerNotifier : GameEvents
    {

        public override void OnStreamerJoined(Player player)
        {
            if (!Bools.IsDeveloper)
            {
                return;
            }
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {

                    CheetosHelpers.SendHudNotification($"Streamer : {apiuser.displayName} Joined!");
                    ModConsole.Warning($"Streamer : {apiuser.displayName} Joined!");
                }
            }
        }

        public override void OnStreamerLeft(Player player)
        {
            if (!Bools.IsDeveloper)
            {
                return;
            }
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    CheetosHelpers.SendHudNotification($"Streamer : {apiuser.displayName} Left!");
                    ModConsole.Warning($"Streamer : {apiuser.displayName} Left!");
                }
            }
        }
    }
}
