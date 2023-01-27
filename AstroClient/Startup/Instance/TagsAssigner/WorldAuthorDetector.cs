using System.Drawing;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;
using AstroClient.Constants;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using VRC;

namespace AstroClient.Startup.Instance.TagsAssigner
{
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

