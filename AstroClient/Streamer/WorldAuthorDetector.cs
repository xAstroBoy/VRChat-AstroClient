using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;

namespace AstroClient.Streamer
{
    using System.Drawing;
    using Constants;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;
    using SystemColors = Tools.Colors.SystemColors;

    internal class WorldAuthorDetector : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerJoin += OnPlayerJoined;
        }

        private void OnPlayerJoined(Player player)
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
                    if (apiuser.IsWorldCreator())
                    {
                        player.AddSingleTag("<wave><rainb>World Author</rainb></wave>", Color.DarkOrange);
                        NewHudNotifier.WriteHudMessage($"World Author : {apiuser.displayName} Joined!");
                        Log.Warn($"World Author : {apiuser.displayName} Joined!");
                    }
                }
            }
        }
    }
}

