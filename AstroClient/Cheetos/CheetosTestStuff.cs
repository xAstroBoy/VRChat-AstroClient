namespace AstroClient.Cheetos
{
    using AstroClient.Components;
    #region Imports

    using AstroClient.Components.SitOnPlayer;
    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using Blaze.Utils;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC;

    #endregion

    internal class CheetosTestStuff : GameEvents
    {
        private static bool DoOnce;

        public override void VRChat_OnUiManagerInit()
        {
            //string VRChatVersion = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_1;
            //string VRChatBuild = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_0;

            var infoBar = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar");
            var infobartext = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/EarlyAccessText").GetComponent<Text>();
            infobartext.color = new Color(1, 0, 1, 1);

            infoBar.transform.localPosition -= new Vector3(0, 110, 0);
            infobartext.GetComponent<Text>().text = "AstroClient";

            //ModConsole.Log($"VRChat Version: {VRChatVersion}, {VRChatBuild}");
        }

        public override void OnPlayerJoined(Player player)
        {
            player.gameObject.AddComponent<NamePlates>();
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            Player player = PlayerUtils.GetPlayer();
            if (player.gameObject.GetComponent<SitOnPlayer>() == null)
            {
                player.gameObject.AddComponent<SitOnPlayer>();
            }
            if (player.gameObject.GetComponent<NewOrbitManager>() == null)
            {
                player.gameObject.AddComponent<NewOrbitManager>();
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

        public override void OnPlayerSelected(VRC.Player player)
        {
            ModConsole.Log($"Player Selected: {player.name}");
        }
    }
}