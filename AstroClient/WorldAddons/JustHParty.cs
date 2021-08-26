namespace AstroClient.WorldAddons
{
	using AstroLibrary.Finder;
	using RubyButtonAPI;
	using UnityEngine;
	using VRC.SDKBase;

	class JustHParty : GameEvents
	{
		public static QMNestedButton JustHPartyMenu;

		public static void InitButtons(QMTabMenu main, float x, float y)
		{
			JustHPartyMenu = new QMNestedButton(main, x, y, "JustHParty Exploits", "JustHParty Exploits", null, null, null, null, true);

			_ = new QMSingleButton(JustHPartyMenu, 1, 0, "Toggle\nLock\n1", () => { ToggleDoor(1); }, "Toggle Door Lock");
			_ = new QMSingleButton(JustHPartyMenu, 2, 0, "Toggle\nLock\n2", () => { ToggleDoor(2); }, "Toggle Door Lock");
			_ = new QMSingleButton(JustHPartyMenu, 3, 0, "Toggle\nLock\n3", () => { ToggleDoor(3); }, "Toggle Door Lock");
			_ = new QMSingleButton(JustHPartyMenu, 4, 0, "Toggle\nLock\n4", () => { ToggleDoor(4); }, "Toggle Door Lock");
			_ = new QMSingleButton(JustHPartyMenu, 1, 1, "Toggle\nLock\n5", () => { ToggleDoor(5); }, "Toggle Door Lock");
			_ = new QMSingleButton(JustHPartyMenu, 2, 1, "Toggle\nLock\n6", () => { ToggleDoor(6); }, "Toggle Door Lock");

			_ = new QMSingleButton(JustHPartyMenu, 1, 3, "Go\nTo\nRooms", () => { GoToRooms(); }, "Go To Rooms");
		}

		private static void GoToRooms()
		{
			GameObjectFinder.Find("기믹/LOBBY/엘베/엘베 3층").GetComponent<VRC_Trigger>().Interact();
		}

		private static void ToggleDoor(int doorID)
		{
			GameObject doorLock = null;

			if (doorID == 1)
			{
				doorLock = GameObjectFinder.Find($"기믹/lock system/sys/00{doorID}/lock");
			}
			else if (doorID >= 2)
			{
				doorLock = GameObjectFinder.Find($"기믹/lock system/sys/00{doorID}/lock ({doorID - 1})");
			}

			VRC_Trigger trigger = doorLock?.GetComponent<VRC_Trigger>();
			trigger?.Interact();
		}
	}
}
