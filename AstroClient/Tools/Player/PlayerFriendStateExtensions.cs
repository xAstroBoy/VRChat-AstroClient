namespace AstroClient.Tools.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using Config;
    using Extensions;
    using UnityEngine;
    using VRC;
    using xAstroBoy;
    using xAstroBoy.Utility;

    internal static class PlayerFriendStateExtensions
    {
        internal static Color FriendStateToColor(this Player obj)
        {
            if (obj.GetAPIUser().HasBlockedYou())
            {
                return ConfigManager.ESPBlockedColor;
            }
            else if (obj.IsFriend())
            {
                return ConfigManager.ESPFriendColor;
            }
            else
            {
                return ConfigManager.PublicESPColor;
            }
        }

        
    }
}