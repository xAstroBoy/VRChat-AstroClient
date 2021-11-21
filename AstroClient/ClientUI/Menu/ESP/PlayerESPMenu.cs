namespace AstroClient.ClientUI.Menu.ESP
{
    using System;
    using AstroEventArgs;
    using AstroMonos.Components.ESP.Player;
    using Config;
    using RandomSubmenus;
    using Tools.Colors;
    using Tools.Extensions;
    using UnityEngine;
    using VRC;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class PlayerESPMenu : AstroEvents
    {
        internal static EventHandler<BoolEventsArgs> Event_OnPlayerESPPropertyChanged;

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            var main = new QMNestedGridMenu(menu, "ESP Menu", "ESP Options");

            PlayerESPToggleBtn = new QMToggleButton(main, "Player ESP", () => { Toggle_Player_ESP = true; }, () => { Toggle_Player_ESP = false; }, "Toggles Player ESP");
            PlayerESPToggleBtn.SetToggleState(ConfigManager.ESP.PlayerESP);
            ESPColorSelector.InitButtons(main);
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

        }

        private static void AddESPToAllPlayers()
        {
            foreach (var item in WorldUtils.Players)
            {
                if (item != GameInstances.LocalPlayer.GetPlayer())
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