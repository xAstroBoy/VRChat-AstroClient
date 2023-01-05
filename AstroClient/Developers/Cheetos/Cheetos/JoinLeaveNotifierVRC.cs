using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;

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
            ConfigEventActions.JoinLeaveNotifier_PropertyChanged += JoinLeaveNotifierPropertyChanged;
            if (ConfigManager.General.JoinLeave)
            {
                ClientEventActions.OnPlayerJoin += OnPlayerJoined;
                ClientEventActions.OnPlayerLeft += OnPlayerLeft;
            }
        }

        private void JoinLeaveNotifierPropertyChanged(bool value)
        {
            if (value)
            {
                ClientEventActions.OnPlayerJoin += OnPlayerJoined;
                ClientEventActions.OnPlayerLeft += OnPlayerLeft;
            }
            else
            {
                ClientEventActions.OnPlayerJoin -= OnPlayerJoined;
                ClientEventActions.OnPlayerLeft -= OnPlayerLeft;
            }
        }

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
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (apiuser.IsSelf) return;
                    var HudTag = GenerateTags(apiuser, true);
                    var consoletag = GenerateTags(apiuser, false);
                    {
                        HudNotifier.WriteHudMessage($"{HudTag} {player.GetDisplayName()} <color=green>Joined</color>!");
                        Log.Write($"{consoletag} {player.GetDisplayName()} Joined!");
                    }
                }
            }
        }



        private void OnPlayerLeft(Player player)
        {
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (apiuser.IsSelf) return;
                    var HudTag = GenerateTags(apiuser, true);
                    var consoletag = GenerateTags(apiuser, false);
                    HudNotifier.WriteHudMessage($"{HudTag} {player.GetDisplayName()} <color=red>Left</color>!");
                    Log.Write($"{consoletag} {player.GetDisplayName()} Left!");
                }
            }
        }
    }
}
