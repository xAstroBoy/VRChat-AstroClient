namespace AstroClient
{
	#region Imports

	using AstroLibrary.Finder;

	#endregion Imports

	public class VRCPlusHider : GameEvents
	{
		public override void VRChat_OnUiManagerInit()
		{
			if (ConfigManager.UI.RemoveVRCPlusMenu)
			{
				var found = GameObjectFinder.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab");
				if (found != null)
				{
					found.SetActive(false);
				}
			}

			if (ConfigManager.UI.RemoveReportButton)
			{
				var found = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/ReportWorldButton");
				if (found != null)
				{
					found.SetActive(false);
				}
			}

			if (ConfigManager.UI.RemoveUserIconButton)
			{
				var found = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconButton");
				if (found != null)
				{
					found.SetActive(false);
				}
			}

			if (ConfigManager.UI.RemoveVRCPlusMiniBanner)
			{
				var found = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner");
				var found_2 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner/Image");
				if (found != null)
				{
					found.SetActive(false);
				}
				if (found_2 != null)
				{
					found_2.SetActive(false);
				}
			}

			if (ConfigManager.UI.RemoveVRCPlusBanner)
			{
				var found = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner");
				if (found != null)
				{
					found.SetActive(false);
				}
			}

			if (ConfigManager.UI.RemoveUserIconCameraButton)
			{
				var found = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconCameraButton");
				if (found != null)
				{
					found.SetActive(false);
				}
			}

			if (ConfigManager.UI.RemoveVRCPlusThankYou)
			{
				var found = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou");
				if (found != null)
				{
					found.SetActive(false);
				}
			}
		}
	}
}