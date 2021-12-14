namespace AstroClient.Experiments
{
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class EmojiCooldownKiller : AstroEvents
    {
        internal override void OnPlayerJoined(Player player)
        {


            MiscUtils.DelayFunction(3f, () =>
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

        }
    }
}