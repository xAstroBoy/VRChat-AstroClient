using AstroClient.ClientActions;
using UnhollowerBaseLib.Attributes;

namespace AstroClient.ClientUI.Menu.ESP
{
    using System;
    
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

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            var main = new QMNestedGridMenu(menu, "ESP Menu", "ESP Options");

            PlayerESPToggleBtn = new QMToggleButton(main, "Player ESP", () => { Toggle_Player_ESP = true; }, () => { Toggle_Player_ESP = false; }, "Toggles Player ESP");
            PlayerESPToggleBtn.SetToggleState(ConfigManager.ESP.PlayerESP);
            HasSubscribed = ConfigManager.ESP.PlayerESP;
            ESPColorSelector.InitButtons(main);
        }


        private static bool _HasSubscribed = false;
        private static bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnPlayerJoin += OnPlayerJoined;

                    }
                    else
                    {

                        ClientEventActions.OnPlayerJoin -= OnPlayerJoined;

                    }
                }
                _HasSubscribed = value;
            }
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
                HasSubscribed = value;
                ConfigEventActions.OnPlayerESPPropertyChanged.SafetyRaiseWithParams(value);
            }
        }

        private static void OnPlayerJoined(Player player)
        {
            if (Toggle_Player_ESP && player != null && player != GameInstances.LocalPlayer.GetPlayer() && !player.gameObject.GetComponent<PlayerESP>())
            {
                player.gameObject.GetOrAddComponent<PlayerESP>();
            }
        }

        private static void AddESPToAllPlayers()
        {
            for (int i = 0; i < WorldUtils.Players.Count; i++)
            {
                Player item = WorldUtils.Players[i];
                if (item != GameInstances.LocalPlayer.GetPlayer() && !item.gameObject.GetComponent<PlayerESP>())
                {
                    _ = item.gameObject.GetOrAddComponent<PlayerESP>();
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