namespace AstroClient.Tools.Extensions
{
    using Moderation;
    using VRC.Core;
    using xAstroBoy.Utility;

    internal static class ModerationExtensions
    {
        internal static bool HasBlockedYou(this APIUser user)
        {
            if (PhotonModerationHandler.BlockedYouPlayers.Count != 0)
            {
                for (int i = 0; i < PhotonModerationHandler.BlockedYouPlayers.Count; i++)
                {
                    string playerid = PhotonModerationHandler.BlockedYouPlayers[i];
                    if (playerid != null)
                    {
                        if (PlayerUtils.GetUserID(user).Equals(playerid))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        internal static bool HasMutedYou(this APIUser user)
        {
            if (PhotonModerationHandler.MutedYouPlayers.Count != 0)
            {
                for (int i = 0; i < PhotonModerationHandler.MutedYouPlayers.Count; i++)
                {
                    string playerid = PhotonModerationHandler.MutedYouPlayers[i];
                    if (playerid != null)
                    {
                        if (PlayerUtils.GetUserID(user).Equals(playerid))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
