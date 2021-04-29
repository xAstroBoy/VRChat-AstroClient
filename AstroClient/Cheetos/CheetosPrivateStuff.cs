namespace AstroClient
{
	using AstroClient.ConsoleUtils;
	using AstroClient.extensions;
	using AstroClient.Finder;
	using CheetosConsole;
	using DayClientML2.Utility.Extensions;

	public class CheetosPrivateStuff : GameEvents
	{
		public override void VRChat_OnUiManagerInit()
		{
#if CHEETOS
			CheetosConsole.Console.WriteFigletWithGradient(FigletFont.LoadFromAssembly("Larry3D.flf"), "Cheetos Mode", System.Drawing.Color.LightYellow, System.Drawing.Color.DarkOrange);
#endif

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

			if (ConfigManager.UI.RemoveReportButton)
			{
				var crap1 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/ReportWorldButton");
				if (crap1 != null)
				{
					crap1.DestroyMeLocal();
				}
			}

			if (ConfigManager.UI.RemoveUserIconButton)
			{
				var crap2 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconButton");
				if (crap2 != null)
				{
					crap2.DestroyMeLocal();
				}
			}

			if (ConfigManager.UI.RemoveVRCPlusMiniBanner)
			{
				var crap3 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner");
				if (crap3 != null)
				{
					crap3.DestroyMeLocal();
				}
			}

			if (ConfigManager.UI.RemoveVRCPlusBanner)
			{
				var crap4 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner");
				if (crap4 != null)
				{
					crap4.DestroyMeLocal();
				}
			}

			if (ConfigManager.UI.RemoveUserIconCameraButton)
			{
				var crap5 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconCameraButton");
				if (crap5 != null)
				{
					crap5.DestroyMeLocal();
				}
			}

			if (ConfigManager.UI.RemoveVRCPlusThankYou)
			{
				var crap6 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou");
				if (crap6 != null)
				{
					crap6.DestroyMeLocal();
				}
			}
		}

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
#if CHEETOS
			var uiManager = VRCUiManager.prop_VRCUiManager_0;
			PopupManager.QueHudMessage(uiManager, "Cheetos Mode!");
#endif
		}
	}
}