using AstroClient.components;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;

namespace AstroClient
{
    class Test : GameEvents
    {
        // USE THIS TO TEST NEW GOODS AND COMMENT IT AWAY ONCE THE TEST HAS BEEN DONE.




        public override void OnPlayerJoined(Player player)
        {
            if (player != null)
            {
                player.gameObject.AddComponent<PlayerESP>();
            }
        }


        public override void OnWorldReveal(string id, string Name, string AssetURL)
        {



        }


    }
}
