namespace AstroClient
{
	#region Imports
	using AstroClient.Cheetos;
	using AstroClient.ConsoleUtils;
	using AstroClient.Finder;
	using AstroClient.variables;
	#endregion Imports

	public class CheetosPrivateStuff : GameEvents
	{
		public override void VRChat_OnUiManagerInit()
		{
			string VRChatVersion = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_1;
			string VRChatBuild = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_0;

			var userInterface = GameObjectFinder.Find("UserInterface");
			userInterface.AddComponent<CheetoMenu>();

			var infoBar = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar");

			if (infoBar != null)
			{
				infoBar.transform.localPosition -= new UnityEngine.Vector3(0, 110, 0);
			}

			ModConsole.CheetoLog($"VRChat Version: {VRChatVersion}, {VRChatBuild}");

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

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (Bools.IsDeveloper)
			{
				CheetosHelpers.SendHudNotification("Developer Mode!");
			}
		}
	}
}