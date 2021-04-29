using AstroClient.variables;
using RubyButtonAPI;
using System;

namespace AstroClient.Startup.Buttons
{
	internal class UserInteractMenuBtns
	{
		public static void InitButtons(float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton("UserInteractMenu", x, y, "AstroClient Menu.", "AstroClient Menu", null, null, null, null, btnHalf);
			var tmp = new QMSingleButton("UserInteractMenu", x, y + 0.5f, "AstroClient : Set Target.", new Action(ObjectMiscOptions.MarkPlayerAsTarget), "Mark this player as target.", null, null, true); ;
			tmp.SetResizeTextForBestFit(true);

			new QMSingleButton(menu, 1, 0, "Teleport All\nPickups\nTo\nplayer.", new Action(ObjectMiscOptions.TeleportAllWorldPickupsToPlayer), "Teleport World Pickups To Player.", null, null); ;
			if (Bools.AllowAttackerComponent)
			{
				new QMSingleButton(menu, 2, 0, "All Pickups Attack player.", new Action(ObjectMiscOptions.AllWorldPickupsAttackTarget), "Make that dirty pickup thief regret stealing from you.", null, null);
				new QMSingleButton(menu, 3, 0, "Remove\nPlayer (bound) Attackers", new Action(ObjectMiscOptions.RemoveAllAttackPlayer), "Removes any Attackers bound to this player.", null, null);
			}
			if (Bools.AllowOrbitComponent)
			{
				new QMSingleButton(menu, 1, 1, "All\nPickups\nOrbits around \nplayer.", new Action(ObjectMiscOptions.AllWorldPickupsOrbitsOnTarget), "Make that dirty pickup thief regret stealing from you.", null, null);
				new QMSingleButton(menu, 2, 1, "Remove\nPlayer (bound) Orbiting Items", new Action(ObjectMiscOptions.RemoveAllOrbitPlayer), "Removes any Orbiting Items bound to this player.", null, null);
			}
			new QMSingleButton(menu, 1, 2, "Remove\nPlayer (bound) Watchers", new Action(ObjectMiscOptions.RemoveAllWatchersPlayer), "Removes any Watchers bound to this player.", null, null);
			new QMSingleButton(menu, 2, 2, "All Pickups Watch player.", new Action(ObjectMiscOptions.AllWorldPickupsWatchTarget), "Make the victim feel observed.", null, null);

			LewdVRChat.InitUserMenu(menu, 4, 1);
		}
	}
}