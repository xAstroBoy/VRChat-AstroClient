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


        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            MiscUtils.DelayFunction(5f, () =>
            {
                HudNotifier.WriteHudMessage($"Welcome Back <color=#c242f5>{PlayerUtils.DisplayName()}</color>", 10f);
                HudNotifier.WriteHudMessage("<color=#42f5f2>AstroClient</color> Made By", 10f);
                HudNotifier.WriteHudMessage("<rainb>AstroBoy</rainb> and <color=#F79239>Cheetos</color>", 10f);

                if (Bools.IsDeveloper)
                {
                    HudNotifier.WriteHudMessage("<rainb>Developer Mode!</rainb>", 10f);
                }

                ClientEventActions.OnWorldReveal -= OnWorldReveal;

            });
        }
    }
}