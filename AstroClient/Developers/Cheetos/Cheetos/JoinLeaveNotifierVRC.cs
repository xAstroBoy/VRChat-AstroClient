using AstroClient.ClientActions;

namespace AstroClient.Cheetos
{
    using System.Collections.Generic;
    using System.Text;
    using Streamer;
    using VRC;
    using VRC.Core;
    using xAstroBoy.Utility;
    using ConfigManager = Config.ConfigManager;

    internal class JoinLeaveNotifierVRC : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnPlayerJoin += OnPlayerJoined;
            ClientEventActions.Event_OnPlayerLeft  += OnPlayerLeft;

            ClientEventActions.Event_OnRoomLeft+= OnRoomLeft;
            ClientEventActions.Event_OnWorldReveal += OnWorldReveal;


        }
        private bool isReady = false;
        private const string BracketColor = "yellow";
        private const string StreamerTextColor = "orange";
        private const string FriendTextColor = "green";
        private string GenerateTags(APIUser player, bool WithColor = false)
        {
            if (player == null) return null;
            StringBuilder sb = new StringBuilder();

            if (StreamerIdentifier.IsAStreamer(player.id))
            {
                if (WithColor)
                {
                    sb.Append($"<color={BracketColor}>[</color><color={StreamerTextColor}>STREAMER</color><color={BracketColor}>]</color>");
                }
                else
                {
                    sb.Append("[STREAMER]");
                }
            }

            if (player.isFriend)
            {
                if (WithColor)
                {
                    sb.Append($"<color={BracketColor}>[</color><color={FriendTextColor}>FRIEND</color><color={BracketColor}>]</color>");
                }
                else
                {
                    sb.Append("[FRIEND]");
                }
            }

            return sb.ToString();
        }

        private void OnPlayerJoined(Player player)
        {
            if (!isReady) return;
            if (!ConfigManager.General.JoinLeave) return;
            if (player != null)
            {

                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (apiuser.IsSelf) return;
                    var HudTag = GenerateTags(apiuser, true);
                    var consoletag = GenerateTags(apiuser, false);
                    {
                        PopupUtils.QueHudMessage($"{HudTag} {player.GetDisplayName()} <color=green>Joined</color>!");
                        Log.Write($"{consoletag} {player.GetDisplayName()} Joined!");
                    }
                }
            }
        }

        private void OnRoomLeft()
        {
            isReady = false;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            MiscUtils.DelayFunction(1, () => { isReady = true; });
        }

        private void OnPlayerLeft(Player player)
        {
            if (!isReady) return;
            if (!ConfigManager.General.JoinLeave) return;
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (apiuser.IsSelf) return;
                    var HudTag = GenerateTags(apiuser, true);
                    var consoletag = GenerateTags(apiuser, false);
                    PopupUtils.QueHudMessage($"{HudTag} {player.GetDisplayName()} <color=red>Left</color>!");
                    Log.Write($"{consoletag} {player.GetDisplayName()} Left!");
                }
            }
        }
    }
}
