namespace AstroClient.EmojiMenu
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;

    internal class EmojiCooldownKiller: GameEvents
    {

        internal override void OnPlayerJoined(Player player)
        {
            if (player != null)
            {
                var vrcplayer = player.GetVRCPlayer();
                if (vrcplayer != null)
                {
                    if (vrcplayer.Get_Emoji_Cooldown() != 0)
                    {
                        vrcplayer.Set_Emoji_Cooldown(0);
                        ModConsole.DebugLog($"[EmojiBypasser] : Removed Player {player.DisplayName()} 's Emoji Cooldown.");
                    }
                }
            }
        }



    }
}
