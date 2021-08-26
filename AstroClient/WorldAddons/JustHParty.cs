namespace AstroClient.WorldAddons
{
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using RubyButtonAPI;
	using System.Collections.Generic;
	using System.Linq;
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

			_ = new QMSingleButton(JustHPartyMenu, 1, 2.5f, "Go To Rooms", () => { GoToRooms(); }, "Go To Rooms", null, Color.cyan, true);
		}

		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			GameObjectFinder.Find("기믹/3f delete (1)")?.gameObject.DestroyMeLocal();
		}

		private static void GoToRooms()
		{
			GameObjectFinder.Find("기믹/LOBBY/엘베/엘베 3층").GetComponents<VRC_Trigger>().ToList()[1].Interact();
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
