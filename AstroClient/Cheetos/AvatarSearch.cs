namespace AstroClient.Cheetos
{
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;

	class AvatarSearch : GameEvents
	{
		public override void VRChat_OnUiManagerInit()
		{
			// Avatar Search
			new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Search", -850f, 125f, delegate ()
			{
				Utils.VRCUiPopupManager.AskInGameInput("Astro Avatar Search", "Search", delegate (string text)
				{
					Search(text);
				}, "Enter Avatar name. . .");
			}, 1.45f, 1f);
		}

		public static void Search(string query)
		{
			// Refresh UI
			NetworkingManager.AvatarSearch(query);
		}
	}
}
