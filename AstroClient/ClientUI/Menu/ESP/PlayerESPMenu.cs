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
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class PlayerESPMenu : AstroEvents
    {
        internal static Action<bool> Event_OnPlayerESPPropertyChanged;

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
                Event_OnPlayerESPPropertyChanged.SafetyRaiseWithParams(value);
            }
        }

        internal override void OnPlayerJoined(Player player)
        {
            MiscUtils.DelayFunction(2, () =>
            {
                if (Toggle_Player_ESP && player != null)
                {
                    player.gameObject.GetOrAddComponent<PlayerESP>();
                }
            });

        }

        private static void AddESPToAllPlayers()
        {
            for (int i = 0; i < WorldUtils.Players.Count; i++)
            {
                Player item = WorldUtils.Players[i];
                if (item != GameInstances.LocalPlayer.GetPlayer() && !item.gameObject.GetComponent<PlayerESP>())
                {
                    _ = item.gameObject.AddComponent<PlayerESP>();
                }
            }
        }

        private static void RemoveAllActivePlayerESPs()
        {
            for (int i = 0; i < WorldUtils.Players.Count; i++)
            {
                Player player = WorldUtils.Players[i];
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