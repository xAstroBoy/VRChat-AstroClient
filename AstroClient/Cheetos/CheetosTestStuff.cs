﻿namespace AstroClient.Cheetos
{
    #region Imports

    using AstroClient.Components;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using AstroLibrary;
    using System.Collections.Generic;
    using UnityEngine.UI;
    using UnityEngine;
    using VRC;

    #endregion

    internal class CheetosTestStuff : GameEvents
    {
        private static bool DoOnce;

        public override void VRChat_OnUiManagerInit()
        {

            var infoBar = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar");
            var infobartext = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/EarlyAccessText").GetComponent<Text>();

            infobartext.color = new Color(1, 0, 1, 1);

            infoBar.transform.localPosition -= new Vector3(0, 110, 0);
            infobartext.text = "AstroClient";
        }

        public override void OnPlayerJoined(Player player)
        {
            if (!ModDetector.FindMods.IsNotoriousPresent)
            {
                player.gameObject.AddComponent<NamePlates>();
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            Player player = PlayerUtils.GetPlayer();
            if (player.gameObject.GetComponent<SitOnPlayer>() == null)
            {
                player.gameObject.AddComponent<SitOnPlayer>();
            }

            if (Bools.IsDeveloper)
            {
                if (!DoOnce)
                {
                    CheetosHelpers.SendHudNotification("Developer Mode!");
                    DoOnce = true;
                }
            }
        }

        public override void OnPlayerSelected(Player player)
        {
            ModConsole.Log($"Player Selected: {player.name}");
        }
    }
}