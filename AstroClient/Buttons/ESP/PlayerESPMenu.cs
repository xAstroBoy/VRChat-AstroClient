namespace AstroClient.Startup.Buttons
{
    using AstroClient.Components;
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System;
    using UnityEngine;
    using VRC;

    internal class PlayerESPMenu : GameEvents
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "ESP Menu", "ESP Options", null, null, null, null, btnHalf);

            PlayerESPToggleBtn = new QMSingleToggleButton(main, 1, 0f, "Player ESP ON", new Action(() => { Toggle_Player_ESP = true; }), "Player ESP OFF", new Action(() => { Toggle_Player_ESP = false; }), "Toggles Player ESP", Color.green, Color.red, null, false, true);
            PlayerESPToggleBtn.SetToggleState(ConfigManager.ESP.PlayerESP);

            // TOOD : ADD A STRING Parser and allow people  to set HEX colors as well.
            var PublicESP = new QMNestedButton(main, 2, 0, "Global ESP Colors", "Set Player ESP Default Color", null, null, null, null, true);
            new QMSingleButton(PublicESP, 1, 0, "Blue", () => { ConfigManager.PublicESPColor = Color.blue; }, null, null, null, true);
            new QMSingleButton(PublicESP, 1, 0.5f, "Red", () => { ConfigManager.PublicESPColor = Color.red; }, null, null, null, true);
            new QMSingleButton(PublicESP, 1, 1, "Green", () => { ConfigManager.PublicESPColor = Color.green; }, null, null, null, true);
            new QMSingleButton(PublicESP, 1, 1.5f, "Yellow", () => { ConfigManager.PublicESPColor = Color.yellow; }, null, null, null, true);
            new QMSingleButton(PublicESP, 1, 2, "Cyan", () => { ConfigManager.PublicESPColor = Color.cyan; }, null, null, null, true);
            new QMSingleButton(PublicESP, 1, 2.5f, "White", () => { ConfigManager.PublicESPColor = Color.white; }, null, null, null, true);

            var FriendESP = new QMNestedButton(main, 2, 0.5f, "Friend ESP Colors", "Set Player ESP Friend Color", null, null, null, null, true);
            new QMSingleButton(FriendESP, 1, 0, "Blue", () => { ConfigManager.ESPFriendColor = Color.blue; }, null, null, null, true);
            new QMSingleButton(FriendESP, 1, 0.5f, "Red", () => { ConfigManager.ESPFriendColor = Color.red; }, null, null, null, true);
            new QMSingleButton(FriendESP, 1, 1, "Green", () => { ConfigManager.ESPFriendColor = Color.green; }, null, null, null, true);
            new QMSingleButton(FriendESP, 1, 1.5f, "Yellow", () => { ConfigManager.ESPFriendColor = Color.yellow; }, null, null, null, true);
            new QMSingleButton(FriendESP, 1, 2, "Cyan", () => { ConfigManager.ESPFriendColor = Color.cyan; }, null, null, null, true);
            new QMSingleButton(FriendESP, 1, 2.5f, "White", () => { ConfigManager.ESPFriendColor = Color.white; }, null, null, null, true);

            var BlockedESP = new QMNestedButton(main, 2, 1f, "Blocked ESP Colors", "Set Player ESP Blocked Color", null, null, null, null, true);
            new QMSingleButton(BlockedESP, 1, 0, "Blue", () => { ConfigManager.ESPBlockedColor = Color.blue; }, null, null, null, true);
            new QMSingleButton(BlockedESP, 1, 0.5f, "Red", () => { ConfigManager.ESPBlockedColor = Color.red; }, null, null, null, true);
            new QMSingleButton(BlockedESP, 1, 1, "Green", () => { ConfigManager.ESPBlockedColor = Color.green; }, null, null, null, true);
            new QMSingleButton(BlockedESP, 1, 1.5f, "Yellow", () => { ConfigManager.ESPBlockedColor = Color.yellow; }, null, null, null, true);
            new QMSingleButton(BlockedESP, 1, 2, "Cyan", () => { ConfigManager.ESPBlockedColor = Color.cyan; }, null, null, null, true);
            new QMSingleButton(BlockedESP, 1, 2.5f, "White", () => { ConfigManager.ESPBlockedColor = Color.white; }, null, null, null, true);
        }

        private static QMSingleToggleButton PlayerESPToggleBtn;

        #region playerESP

        // TODO: MAKE ESP FRIEND COLOR BE SETTABLE
        public static bool Toggle_Player_ESP
        {
            get
            {
                return ConfigManager.ESP.PlayerESP;
            }
            set
            {
                if (value)
                {
                    AddESPToAllPlayers();
                }
                else
                {
                    RemoveAllActivePlayerESPs();
                }

                ConfigManager.ESP.PlayerESP = value;
                if (PlayerESPToggleBtn != null)
                {
                    PlayerESPToggleBtn.SetToggleState(value);
                }
            }
        }

        public override void OnPlayerJoined(Player player)
        {
            if (Toggle_Player_ESP)
            {
                if (player != null && player != Utils.LocalPlayer.GetPlayer())
                {
                    if (!player.gameObject.GetComponent<PlayerESP>())
                    {
                        player.gameObject.AddComponent<PlayerESP>();
                    }
                }
            }
        }

        private static void AddESPToAllPlayers()
        {
            foreach (var item in WorldUtils.GetPlayers())
            {
                if (item != Utils.LocalPlayer.GetPlayer())
                {
                    if (!item.gameObject.GetComponent<PlayerESP>())
                    {
                        item.gameObject.AddComponent<PlayerESP>();
                    }
                }
            }
        }

        private static void RemoveAllActivePlayerESPs()
        {
            foreach (var player in WorldUtils.GetPlayers())
            {
                var esp = player.gameObject.GetComponent<PlayerESP>();
                if (esp != null)
                {
                    UnityEngine.Object.Destroy(esp);
                }
            }
        }

        #endregion playerESP
    }
}