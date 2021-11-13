﻿namespace AstroClient
{
    using AstroLibrary;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using AstroButtonAPI;
    using MelonLoader;

    internal class Welcome : GameEvents
    {
        internal static bool HasDisplayed { get; private set; }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasDisplayed)
            {
               //MelonCoroutines.Start(Extensions.FixTabSpacing());
                PopupUtils.QueHudMessage($"Welcome Back <Color=#c242f5>{PlayerUtils.DisplayName()}</color>\n<color=#42f5f2>AstroClient</color> Made By\n <color=#2A3EBF>AstroBoy</color> and <color=#F79239>Cheetos</color>");
                HasDisplayed = true;
            }
        }
    }
}