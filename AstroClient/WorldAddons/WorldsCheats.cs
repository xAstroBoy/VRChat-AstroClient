namespace AstroClient.Worlds
{
    #region Imports

    using AstroClient.Variables;
    using AstroClient.World.Hub;
    using AstroClient.WorldAddons;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using RubyButtonAPI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using UnityEngine;

    #endregion

    public class WorldsCheats : GameEvents
    {
        public static void InitButtons(float pos)
        {
            QMTabMenu WorldCheats = new QMTabMenu(pos, "WorldCheats Menu", null, null, null, CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.thief.png"));
            Murder2Cheats.Murder2CheatsButtons(WorldCheats, 1, 0, true);
            Murder4Cheats.Murder4CheatsButtons(WorldCheats, 1, 0.5f, true);
            AmongUSCheats.AmongUSCheatsButtons(WorldCheats, 1, 1f, true);
            VRChatHub.InitButtons(WorldCheats, 1, 1.5f, true);
            //FreezeTag.InitButtons(WorldCheats, 1, 2, true);
            AimFactory.InitButtons(WorldCheats, 1, 2.5f, true);
            BOMBERio.InitButtons(WorldCheats, 2, 0);
            BClubWorld.InitButtons(WorldCheats, 4, 2);
            JustHParty.InitButtons(WorldCheats, 4, 3);
            VoidClub.InitButtons(WorldCheats, 4, 4);
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.VRChatDefaultHub)
            {
                if (VRChatHub.VRChat_Hub_Addons != null)
                {
                    ModConsole.Log($"Recognized {Name} World, revealing Hub Addons Submenu Button!", System.Drawing.Color.Green);
                    VRChatHub.VRChat_Hub_Addons.GetMainButton().SetIntractable(true);
                    VRChatHub.VRChat_Hub_Addons.GetMainButton().SetTextColor(Color.green);
                }
            }
            else
            {
                if (VRChatHub.VRChat_Hub_Addons != null)
                {
                    VRChatHub.VRChat_Hub_Addons.GetMainButton().SetIntractable(false);
                    VRChatHub.VRChat_Hub_Addons.GetMainButton().SetTextColor(Color.red);
                }
            }

            if (id == WorldIds.TermalTreatment)
            {
                ModConsole.Log($"Recognized {Name} World, Finding Platforms Gameobjects!...");
                List<GameObject> list = GameObjectFinder.ListFind("Platforms");
                if (list != null && list.Count() != 0)
                {
                    list.AddToWorldUtilsMenu();
                }
            }
            if (id == WorldIds.DontTripWorld)
            {
                ModConsole.Log($"Recognized {Name} World, Finding Entity Gameobjects!...");
                GameObjectFinder.Find("GameObject/Level/cube (5)/what the fuck").AddToWorldUtilsMenu();
            }
        }
    }
}