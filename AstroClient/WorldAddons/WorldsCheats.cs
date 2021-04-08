using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using AstroClient.World.Hub;
using RubyButtonAPI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AstroClient.Worlds
{
    public class WorldsCheats : GameEvents
    {


        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var WorldCheats = new QMNestedButton(menu, x, y, "World Cheats", "Manage Cheats", null, null, null, null, btnHalf);
            Murder2Cheats.Murder2CheatsButtons(WorldCheats, 1, 0, true);
            Murder4Cheats.Murder4CheatsButtons(WorldCheats, 1, 0.5f, true);
            AmongUSCheats.AmongUSCheatsButtons(WorldCheats, 1, 1f, true);
            HubButtonsControl.InitButtons(WorldCheats, 1, 1.5f, true);
            FreezeTag.InitButtons(WorldCheats, 1, 2, true);
        }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.VRChatDefaultHub)
            {
                if (HubButtonsControl.VRChat_Hub_Addons != null)
                {
                    ModConsole.Log($"Recognized {name} World, revealing Hub Addons Submenu Button!", System.Drawing.Color.Green);
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setIntractable(true);
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setTextColor(Color.green);
                }
            }
            else
            {
                if (HubButtonsControl.VRChat_Hub_Addons != null)
                {
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setIntractable(false);
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setTextColor(Color.red);
                }
            }

            if (id == WorldIds.TermalTreatment)
            {
                ModConsole.Log($"Recognized {name} World, Finding Platforms Gameobjects!...");
                var list = new List<GameObject>();
                list = GameObjectFinder.ListFind("Platforms");
                if (list != null && list.Count() != 0)
                {
                    list.AddToWorldUtilsMenu();
                }
            }
            if (id == WorldIds.DontTripWorld)
            {
                ModConsole.Log($"Recognized {name} World, Finding Entity Gameobjects!...");
                GameObjectFinder.Find("GameObject/Level/cube (5)/what the fuck").AddToWorldUtilsMenu();
            }
        }


    }
}