using System;

namespace AstroClient.ClientActions
{
    // Put all actions here .

    // There goes all Hooks and other "global" actions.

    internal static class ConfigEventActions
    {
        internal static Action<UnityEngine.Color> Event_ESP_OnPublicColorChange { get; set; }
        internal static Action<UnityEngine.Color> Event_ESP_OnBlockedColorChange { get; set; }
        internal static Action<UnityEngine.Color> Event_ESP_OnFriendColorChange { get; set; }


        internal static Action OnPlayerListConfigChanged { get; set; }


        internal static Action<bool> Event_OnPlayerESPPropertyChanged{ get; set; }



    }
}
