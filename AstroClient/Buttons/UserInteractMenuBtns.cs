namespace AstroClient.Startup.Buttons
{
	using AstroClient.AvatarMods;
	using AstroClient.Cheetos;
	using AstroClient.Components.SitOnPlayer;
	using AstroClient.Variables;
	using AstroLibrary.Utility;
	using RubyButtonAPI;
	using System;
	using UnityEngine;
	using Finder = AstroLibrary.Finder;

	internal class UserInteractMenuBtns : GameEvents
    {
        public static GameObject OldCloneButton;

        public static void InitButtons(float x, float y, bool btnHalf)
        {
            OldCloneButton = Finder.GameObjectFinder.Find("UserInterface/QuickMenu/UserInteractMenu/CloneAvatarButton");
            OldCloneButton?.SetActive(false);
            Init_UserMenu_Exploits(x, y, true);
            //new QMSingleButton("UserInteractMenu", x, y + 0.5f, "AstroClient : Set Target.", new Action(ObjectMiscOptions.MarkPlayerAsTarget), "Mark this player as target.", null, null, btnHalf).SetResizeTextForBestFit(true);
            AvatarModifier.InitUserMenu(x, y + 0.5f, true);
            var forceClone = new QMSingleButton("UserInteractMenu", 5, 0, "Force Clone", () => { ForceClone.ClonePlayer(); }, "Force Clone This Player's Avatar", null, null, false);
        }

		public static void Init_UserMenu_Exploits(float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton("UserInteractMenu", x, y, "AstroClient Exploits", "AstroClient Menu", null, null, null, null, btnHalf);
			menu.GetMainButton().SetResizeTextForBestFit(true);

			_ = new QMSingleButton(menu, 1, 0, "Teleport All\nPickups\nTo\nplayer.", new Action(ObjectMiscOptions.TeleportAllWorldPickupsToPlayer), "Teleport World Pickups To Player.", null, null); ;
			if (Bools.AllowOrbitComponent)
			{
				_ = new QMSingleButton(menu, 2, 0, "All\nPickups\nOrbits around \nplayer.", new Action(ObjectMiscOptions.AllWorldPickupsOrbitsOnTarget), "Make that dirty pickup thief regret stealing from you.", null, null);
				//new QMSingleButton(menu, 2, 1, "Remove\nPlayer (bound) Orbiting Items", new Action(ObjectMiscOptions.RemoveAllOrbitPlayer), "Removes any Orbiting Items bound to this player.", null, null);
			}
			if (Bools.AllowAttackerComponent)
			{
				_ = new QMSingleButton(menu, 3, 0, "All Pickups Attack player.", new Action(ObjectMiscOptions.AllWorldPickupsAttackTarget), "Make that dirty pickup thief regret stealing from you.", null, null);
				//new QMSingleButton(menu, 3, 0, "Remove\nPlayer (bound) Attackers", new Action(ObjectMiscOptions.RemoveAllAttackPlayer), "Removes any Attackers bound to this player.", null, null);
			}
			//new QMSingleButton(menu, 1, 2, "Remove\nPlayer (bound) Watchers", new Action(ObjectMiscOptions.RemoveAllWatchersPlayer), "Removes any Watchers bound to this player.", null, null);
			_ = new QMSingleButton(menu, 4, 0, "All Pickups Watch player.", new Action(ObjectMiscOptions.AllWorldPickupsWatchTarget), "Make the victim feel observed.", null, null);

			var sitMenu = new QMNestedButton(menu, 1, 2, "Sit", "Sit on selected player");
			_ = new QMSingleButton(sitMenu, 1, 0, "Sit On Head", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.GetSelectedPlayer(), HumanBodyBones.Head); }, "Sit On Head", null, null);
			_ = new QMSingleButton(sitMenu, 2, 1, "Sit On LeftHand", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.GetSelectedPlayer(), HumanBodyBones.LeftHand); }, "Sit On LeftHand", null, null);
			_ = new QMSingleButton(sitMenu, 2, 2, "Sit On RightHand", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.GetSelectedPlayer(), HumanBodyBones.RightHand); }, "Sit On RightHand", null, null);
			_ = new QMSingleButton(sitMenu, 3, 1, "Sit On LeftFoot", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.GetSelectedPlayer(), HumanBodyBones.LeftFoot); }, "Sit On LeftFoot", null, null);
			_ = new QMSingleButton(sitMenu, 3, 2, "Sit On RightFoot", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.GetSelectedPlayer(), HumanBodyBones.RightFoot); }, "Sit On RightFoot", null, null);

			//var setHeightButton = new QMSingleButton(sitMenu, 3, 0, $"Set\nHeight\n{SitOnPlayer.Height}", () =>
			//{
			//	CheetosHelpers.PopupCall("Set Height Value", "Done", "Enter Height. . .", true, delegate (string text)
			//	{
			//		float value = 0f;

			//		try
			//		{
			//			value = float.Parse(text);
			//		}
			//		catch
			//		{
			//			ModConsole.Error("Input value must be a float value!");
			//		}
			//		finally
			//		{
			//			SitOnPlayer.Height = value / 100;
			//		}
			//	});
			//}, $"{SitOnPlayer.Height}");

			new QMSingleButton(menu, 4, 2, "Remove\n Everything", () =>
            {
                ObjectMiscOptions.RemoveAllAttackPlayer();
                ObjectMiscOptions.RemoveAllOrbitPlayer();
                ObjectMiscOptions.RemoveAllWatchersPlayer();
            }
            , "Removes everything bound to this player.", null, null);
        }

        public override void OnLateUpdate()
        {
            OldCloneButton?.SetActive(false);
        }
    }
}