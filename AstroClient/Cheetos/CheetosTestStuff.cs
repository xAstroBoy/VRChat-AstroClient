namespace AstroClient.Cheetos
{
	using AstroClient.ConsoleUtils;
	using AstroClient.Finder;
	using AstroClient.variables;

	class CheetosTestStuff : GameEvents
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
