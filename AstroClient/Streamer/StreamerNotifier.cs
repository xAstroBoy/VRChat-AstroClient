namespace AstroClient.Streamer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Constants;
    using VRC;
    using xAstroBoy.Utility;

    internal class StreamerNotifier : AstroEvents
    {

        internal override void OnStreamerJoined(Player player)
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

                    PopupUtils.QueHudMessage($"Streamer : {apiuser.displayName} Joined!");
                    ModConsole.Warning($"Streamer : {apiuser.displayName} Joined!");
                }
            }
        }

        internal override void OnStreamerLeft(Player player)
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
                    PopupUtils.QueHudMessage($"Streamer : {apiuser.displayName} Left!");
                    ModConsole.Warning($"Streamer : {apiuser.displayName} Left!");
                }
            }
        }
    }
}
