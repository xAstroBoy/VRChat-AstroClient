using AstroClient.components;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;

namespace AstroClient
{
    class PlayerESPControl : GameEvents
    {

        public static QMSingleToggleButton PlayerESPToggleBtn;
        private static bool _EnableESP;

        public static bool EnabledESP
        {
            get
            {
                return _EnableESP;
            }
            set
            {
                if (value)
                {
                    AddESPToAllPlayers();
                }
                else
                {
                    RemoveAllActivePlayerEsps();
                }

                _EnableESP = value;
                if(PlayerESPToggleBtn != null)
                {
                    PlayerESPToggleBtn.setToggleState(value);
                }
            }
        }


        public override void OnPlayerJoined(Player player)
        {
            if (EnabledESP)
            {
                if (player != null)
                {
                    player.gameObject.AddComponent<PlayerESP>();
                }
            }
        }


        public static void AddESPToAllPlayers()
        {
            foreach (var item in WorldUtils.GetAllPlayers0())
            {
                if(item.gameObject.GetComponent<PlayerESP>() == null)
                {
                    item.gameObject.AddComponent<PlayerESP>();
                }
            }
        }



        public static void RemoveAllActivePlayerEsps()
        {
            foreach(var item in Resources.FindObjectsOfTypeAll<PlayerESP>())
            {
                UnityEngine.Object.Destroy(item);
            }
        }

    }
}
