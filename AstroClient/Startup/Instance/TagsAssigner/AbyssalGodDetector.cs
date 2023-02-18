﻿using System.Collections.Generic;
using System.Drawing;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using VRC;

namespace AstroClient.Startup.Instance.TagsAssigner
{
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
                        player.AddSingleTag("<swing>Troll Warning : AbyssalGod </swing>", Color.OrangeRed);
                        HudNotifier.WriteHudMessage("AbyssalGod Detected".AddRichColorTag(Color.OrangeRed) + $" : {apiuser.displayName} Joined!");
                        Log.Warn($"AbyssalGod Detected : {apiuser.displayName} Joined!");
                    }
                }
            }
        }
    }
}
