﻿namespace AstroClient.EmojiMenu
{
    using System;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using CodeDebugTools;
    using VRC;

    internal class EmojiCooldownKiller : GameEvents
    {
        internal override void OnPlayerJoined(Player player)
        {


            CodeDebug.StopWatchDebug("EmojiCoolDownKiller OnPlayerJoined", new Action(() =>
            {
            MiscUtils.DelayFunction(1f, () =>
            {
                if (player != null)
                {
                    var vrcplayer = player.GetVRCPlayer();
                    if (vrcplayer != null)
                    {
                        vrcplayer.Set_Emoji_Cooldown(0);
                        ModConsole.DebugLog($"[EmojiBypasser] : Removed Player {player.DisplayName()} 's Emoji Cooldown.");
                    }
                }
            });

            }));

        }
    }
}