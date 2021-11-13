namespace AstroClient.ClientUI.QuickMenuButtons.ESP
{
    using System;
    using AstroButtonAPI;
    using AstroClientCore.Events;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.ESP.Player;
    using Boo.Lang.Useful.Collections;
    using CodeDebugTools;
    using UnityEngine;
    using VRC;

    internal class PlayerESPMenu : GameEvents
    {
        internal static EventHandler<BoolEventsArgs> Event_OnPlayerESPPropertyChanged;

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            var main = new QMNestedGridMenu(menu, "ESP Menu", "ESP Options");

            PlayerESPToggleBtn = new QMToggleButton(main, "Player ESP", () => { Toggle_Player_ESP = true; }, () => { Toggle_Player_ESP = false; }, "Toggles Player ESP");
            PlayerESPToggleBtn.SetToggleState(ConfigManager.ESP.PlayerESP);

            // TOOD : ADD A STRING Parser and allow people  to set HEX colors as well.
            var PublicESP = new QMNestedGridMenu(main, "Global ESP Colors", "Set Player ESP Default Color");

            new QMSingleButton(PublicESP, "Blue", () => { ConfigManager.PublicESPColor = Color.blue; }, "Set Public People ESP To Blue", Color.blue);
            new QMSingleButton(PublicESP, "Red", () => { ConfigManager.PublicESPColor = Color.red; }, "Set Public People ESP To Red", Color.red);
            new QMSingleButton(PublicESP, "Green", () => { ConfigManager.PublicESPColor = Color.green; }, "Set Public People ESP To green", Color.green);
            new QMSingleButton(PublicESP, "Yellow", () => { ConfigManager.PublicESPColor = Color.yellow; }, "Set Public People ESP To yellow", Color.yellow);
            new QMSingleButton(PublicESP, "Cyan", () => { ConfigManager.PublicESPColor = Color.cyan; }, "Set Public People ESP To Cyan", Color.cyan);
            new QMSingleButton(PublicESP, "White", () => { ConfigManager.PublicESPColor = Color.white; }, "Set Public People ESP To white", Color.white);


            var FriendESP = new QMNestedGridMenu(main,  "Friend ESP Colors", "Set Player ESP Friend Color");

            new QMSingleButton(FriendESP, "Blue", () => { ConfigManager.ESPFriendColor = Color.blue; }, "Set Friends People ESP To Blue", Color.blue);
            new QMSingleButton(FriendESP, "Red", () => { ConfigManager.ESPFriendColor = Color.red; }, "Set Friends People ESP To Red", Color.red);
            new QMSingleButton(FriendESP, "Green", () => { ConfigManager.ESPFriendColor = Color.green; }, "Set Friends People ESP To green", Color.green);
            new QMSingleButton(FriendESP, "Yellow", () => { ConfigManager.ESPFriendColor = Color.yellow; }, "Set Friends People ESP To yellow", Color.yellow);
            new QMSingleButton(FriendESP, "Cyan", () => { ConfigManager.ESPFriendColor = Color.cyan; }, "Set Friends People ESP To Cyan", Color.cyan);
            new QMSingleButton(FriendESP, "White", () => { ConfigManager.ESPFriendColor = Color.white; }, "Set Friends  ESP To white", Color.white);

            var BlockedESP = new QMNestedGridMenu(main,  "Blocked ESP Colors", "Set Player ESP Blocked Color");
            new QMSingleButton(BlockedESP, "Blue", () => { ConfigManager.ESPBlockedColor = Color.blue; }, "Set Blocked People ESP To Blue", Color.blue);
            new QMSingleButton(BlockedESP, "Red", () => { ConfigManager.ESPBlockedColor = Color.red; }, "Set Blocked People ESP To Red", Color.red);
            new QMSingleButton(BlockedESP, "Green", () => { ConfigManager.ESPBlockedColor = Color.green; }, "Set Blocked People ESP To green", Color.green);
            new QMSingleButton(BlockedESP, "Yellow", () => { ConfigManager.ESPBlockedColor = Color.yellow; }, "Set Blocked People ESP To yellow", Color.yellow);
            new QMSingleButton(BlockedESP, "Cyan", () => { ConfigManager.ESPBlockedColor = Color.cyan; }, "Set Blocked People ESP To Cyan", Color.cyan);
            new QMSingleButton(BlockedESP, "White", () => { ConfigManager.ESPBlockedColor = Color.white; }, "Set Blocked  ESP To white", Color.white);

        }

        private static QMToggleButton PlayerESPToggleBtn;

        #region playerESP

        // TODO: MAKE ESP FRIEND COLOR BE SETTABLE
        internal static bool Toggle_Player_ESP
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
                Event_OnPlayerESPPropertyChanged.SafetyRaise(new BoolEventsArgs(value));
            }
        }

        internal override void OnPlayerJoined(Player player)
        {
            CodeDebug.StopWatchDebug("PlayerESPMenu OnPlayerJoined", new Action(() =>
            {
                MiscUtils.DelayFunction(1, () =>
                {
                    if (Toggle_Player_ESP)
                    {
                        if (player != null && !player.GetAPIUser().IsSelf)
                        {
                            player.gameObject.GetOrAddComponent<PlayerESP>();
                        }
                    }
                });
            }));

        }

        private static void AddESPToAllPlayers()
        {
            foreach (var item in WorldUtils.Players)
            {
                if (item != Utils.LocalPlayer.GetPlayer())
                {
                    if (!item.gameObject.GetComponent<PlayerESP>())
                    {
                        _ = item.gameObject.AddComponent<PlayerESP>();
                    }
                }
            }
        }

        private static void RemoveAllActivePlayerESPs()
        {
            foreach (var player in WorldUtils.Players)
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