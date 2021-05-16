namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using AstroClient.variables;
	using UnityEngine;

	internal class CheetosTestStuff : GameEvents
	{
		public override void VRChat_OnUiManagerInit()
		{
			string VRChatVersion = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_1;
			string VRChatBuild = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_0;

			var userInterface = GameObjectFinder.Find("UserInterface");
			userInterface.AddComponent<CheetoMenu>();

			var infoBar = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar");
			var infobartext = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/EarlyAccessText").GetComponent<UnityEngine.UI.Text>();
			infobartext.color = new Color(1, 0, 1, 1);

			infoBar.transform.localPosition -= new Vector3(0, 110, 0);
			infobartext.GetComponent<UnityEngine.UI.Text>().text = "AstroClient";

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