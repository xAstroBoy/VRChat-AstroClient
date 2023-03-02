using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using System.Collections.Generic;
using AstroClient.ClientUI.Hud.Notifier;
using AstroClient.Constants;

namespace AstroClient.Startup
{
    using System.Collections.Generic;
    using xAstroBoy.Utility;

    internal class Welcome : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private  float WelcomeDuration { get; } = 3f;
        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            NewHudNotifier.WriteHudMessage($"Welcome Back <color=#c242f5>{PlayerUtils.DisplayName()}</color>");
            NewHudNotifier.WriteHudMessage("<color=#42f5f2>AstroClient</color> Made By");
            NewHudNotifier.WriteHudMessage("<rainb>AstroBoy</rainb> and <color=#F79239>Cheetos</color>");

            if (Bools.IsDeveloper)
            {
                NewHudNotifier.WriteHudMessage("<rainb>Developer Mode!</rainb>");
            }

            ClientEventActions.OnWorldReveal -= OnWorldReveal;
        }
    }
}