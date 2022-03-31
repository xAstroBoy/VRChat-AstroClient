namespace AstroClient.Tools.Extensions
{
    using Moderation;
    using VRC.Core;
    using xAstroBoy.Utility;

    internal static class ModerationExtensions
    {
        internal static bool HasBlockedYou(this APIUser user)
        {
            if (PhotonModerationHandler.PlayerModerations != null)
            {
                if (PhotonModerationHandler.PlayerModerations.ContainsKey(user.id))
                {
                    return PhotonModerationHandler.PlayerModerations[user.id].Blocked;
                }
            }
            return false;

        }

        internal static bool HasMutedYou(this APIUser user)
        {
            if(PhotonModerationHandler.PlayerModerations != null)
            {
                if(PhotonModerationHandler.PlayerModerations.ContainsKey(user.id))
                {
                    return PhotonModerationHandler.PlayerModerations[user.id].Muted;
                }
            }
            return false;
        }
    }
}
