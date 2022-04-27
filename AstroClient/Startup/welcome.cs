using AstroClient.ClientActions;

namespace AstroClient.Startup
{
    using System.Collections.Generic;
    using xAstroBoy.Utility;

    internal class Welcome : AstroEvents
    {
        private static bool HasDisplayed;
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnWorldReveal += OnWorldReveal;
        }


        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasDisplayed)
            {
                PopupUtils.QueHudMessage($"Welcome Back <Color=#c242f5>{PlayerUtils.DisplayName()}</color>\n<color=#42f5f2>AstroClient</color> Made By\n <color=#2A3EBF>AstroBoy</color> and <color=#F79239>Cheetos</color>");
                HasDisplayed = true;
            }
            ClientEventActions.Event_OnWorldReveal -= OnWorldReveal;
        }
    }
}