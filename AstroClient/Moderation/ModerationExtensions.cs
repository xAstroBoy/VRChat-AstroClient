using System;
using AstroLibrary.Utility;
using Photon.Realtime;
using VRC.Core;

namespace AstroClient.Moderation
{
    internal static class ModerationExtensions
    {
        internal static bool HasBlockedYou(this APIUser user)
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

        internal static bool HasMutedYou(this APIUser user)
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
