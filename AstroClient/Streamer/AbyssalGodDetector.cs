
using System.Collections.Generic;
using AstroClient.ClientActions;

namespace AstroClient.Streamer
{
    using System.Drawing;
    using Constants;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;
    using SystemColors = Tools.Colors.SystemColors;

    internal class AbyssalGodDetector : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerJoin += OnPlayerJoined;
        }

        private static readonly List<string> AbyssalGodAlts = new List<string>
        {
            "usr_76ae15a4-72b1-439c-86b8-4116a435aaf0",
            "usr_6fc1f301-3a52-46c3-837b-ebcb501c4636",
        };

        private void OnPlayerJoined(Player player)
        {

            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (AbyssalGodAlts.Contains(apiuser.GetUserID()))
                    {
                        player.AddSingleTag("<bounce>"+"AbyssalGod (TROLL!)".AddRichColorTag(Color.OrangeRed)+"</bounce>");
                        PopupUtils.QueHudMessage("AbyssalGod Detected".AddRichColorTag(Color.OrangeRed) + $" : {apiuser.displayName} Joined!");
                        Log.Warn($"AbyssalGod Detected : {apiuser.displayName} Joined!");
                    }
                }
            }
        }
    }
}

