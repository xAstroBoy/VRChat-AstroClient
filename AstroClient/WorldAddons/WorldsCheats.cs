namespace AstroClient.Worlds
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroLibrary.Finder;
	using AstroClient.Variables;
	using AstroClient.World.Hub;
	using RubyButtonAPI;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class WorldsCheats : GameEvents
	{
		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			QMTabMenu WorldCheats = new QMTabMenu(5f, "WorldCheats Menu", null, null, null, "AstroClient.Resources.thief.png");
			Murder2Cheats.Murder2CheatsButtons(WorldCheats, 1, 0, true);
			Murder4Cheats.Murder4CheatsButtons(WorldCheats, 1, 0.5f, true);
			AmongUSCheats.AmongUSCheatsButtons(WorldCheats, 1, 1f, true);
			HubButtonsControl.InitButtons(WorldCheats, 1, 1.5f, true);
			FreezeTag.InitButtons(WorldCheats, 1, 2, true);
			AimFactory.InitButtons(WorldCheats, 1, 2.5f, true);
		}

		public override void OnWorldReveal(string id, string Name, string tags, string AssetURL)
		{
			if (id == WorldIds.VRChatDefaultHub)
			{
				if (HubButtonsControl.VRChat_Hub_Addons != null)
				{
					ModConsole.Log($"Recognized {Name} World, revealing Hub Addons Submenu Button!", System.Drawing.Color.Green);
					HubButtonsControl.VRChat_Hub_Addons.GetMainButton().SetIntractable(true);
					HubButtonsControl.VRChat_Hub_Addons.GetMainButton().SetTextColor(Color.green);
				}
			}
			else
			{
				if (HubButtonsControl.VRChat_Hub_Addons != null)
				{
					HubButtonsControl.VRChat_Hub_Addons.GetMainButton().SetIntractable(false);
					HubButtonsControl.VRChat_Hub_Addons.GetMainButton().SetTextColor(Color.red);
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