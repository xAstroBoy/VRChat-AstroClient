using System;
using AstroLibrary.Utility;
using Photon.Realtime;
using VRC.Core;

namespace AstroClient.Moderation
{
    public static class ModerationExtensions
    {
        public static bool HasBlockedYou(this APIUser user)
        {
            if (PhotonModerationHandler.BlockedYouPlayers.Count != 0)
            {
                foreach (Player player in PhotonModerationHandler.BlockedYouPlayers)
                {
                    if (player != null)
                    {
                        if (PlayerUtils.GetUserID(user).Equals(PhotonUtils.GetUserID(player)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool HasMutedYou(this APIUser user)
        {
            if (PhotonModerationHandler.MutedYouPlayers.Count != 0)
            {
                foreach (Player player in PhotonModerationHandler.MutedYouPlayers)
                {
                    if (player != null)
                    {
                        if (PlayerUtils.GetUserID(user).Equals(PhotonUtils.GetUserID(player)))
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
