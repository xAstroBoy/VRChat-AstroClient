namespace AstroClient.Startup.Buttons
{
	using AstroClient.components;
	using AstroClient.extensions;
	using RubyButtonAPI;
	using System;
	using UnityEngine;
	using VRC;

	internal class ESPMenu : GameEvents
	{
		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "ESP Menu", "ESP Options", null, null, null, null, btnHalf);

			PlayerESPToggleBtn = new QMSingleToggleButton(main, 1, 0f, "Player ESP ON", new Action(() => { Toggle_Player_ESP = true; }), "Player ESP OFF", new Action(() => { Toggle_Player_ESP = false; }), "Toggles Player ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
			PlayerESPToggleBtn.setToggleState(ConfigManager.ESP.PlayerESP);

			PickupESPToggleBtn = new QMSingleToggleButton(main, 2, 0f, "Pickup ESP ON", new Action(() => { Toggle_Pickup_ESP = true; }), "Pickup ESP OFF", new Action(() => { Toggle_Pickup_ESP = false; }), "Toggle Pickup ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
			PickupESPToggleBtn.setToggleState(ConfigManager.ESP.PickupESP);
			
			VRCInteractableESPToggleBtn = new QMSingleToggleButton(main, 2, 0.5f, "VRC Interactable ESP ON", new Action(() => { Toggle_VRCInteractable_ESP = true; }), "VRC Interactable ESP OFF", new Action(() => { Toggle_VRCInteractable_ESP = false; }), "Toggle VRC Interactable ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
			VRCInteractableESPToggleBtn.setToggleState(ConfigManager.ESP.VRCInteractableESP);

			TriggerESPToggleBtn = new QMSingleToggleButton(main, 2, 1f, "Trigger ESP ON", new Action(() => { Toggle_Trigger_ESP = true; }), "Trigger ESP OFF", new Action(() => { Toggle_Trigger_ESP = false; }), "Toggle Trigger ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
			TriggerESPToggleBtn.setToggleState(ConfigManager.ESP.TriggerESP);

			UdonBehaviourESPToggleBtn = new QMSingleToggleButton(main, 2, 1.5f, "Udon Behaviour ESP ON", new Action(() => { Toggle_UdonBehaviour_ESP = true; }), "Udon Behaviour ESP OFF", new Action(() => { Toggle_UdonBehaviour_ESP = false; }), "Toggle Udon Behaviour ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
			UdonBehaviourESPToggleBtn.setToggleState(ConfigManager.ESP.UdonESP);

			new QMSingleButton(main, 4, 0, "Blue", () => { ChangeColor(Color.blue); }, null, null, null, false);
			new QMSingleButton(main, 4, 1, "Red", () => { ChangeColor(Color.red); }, null, null, null, false);
			new QMSingleButton(main, 4, 2, "Green", () => { ChangeColor(Color.green); }, null, null, null, false);
			new QMSingleButton(main, 3, 0, "Yellow", () => { ChangeColor(Color.yellow); }, null, null, null, false);
			new QMSingleButton(main, 3, 1, "Cyan", () => { ChangeColor(Color.cyan); }, null, null, null, false);
			new QMSingleButton(main, 3, 2, "White", () => { ChangeColor(Color.white); }, null, null, null, false);
		}

		private static QMSingleToggleButton PlayerESPToggleBtn;
		private static QMSingleToggleButton VRCInteractableESPToggleBtn;
		private static QMSingleToggleButton PickupESPToggleBtn;
		private static QMSingleToggleButton TriggerESPToggleBtn;
		private static QMSingleToggleButton UdonBehaviourESPToggleBtn;


		public static void ChangeColor(UnityEngine.Color color)
		{
			ConfigManager.ESP.ESPColor = color;
			foreach (var player in WorldUtils.GetAllPlayers0())
			{
				player.GetComponent<PlayerESP>().ChangeColor(ConfigManager.ESP.ESPColor);
			}
		}

		public override void OnLevelLoaded()
		{
			Toggle_VRCInteractable_ESP = false;
			Toggle_Trigger_ESP = false;
			Toggle_UdonBehaviour_ESP = false;
			Toggle_Pickup_ESP = false;
		}
		#region VRCInteractableESP

		public static bool Toggle_VRCInteractable_ESP
		{
			get
			{
				return ConfigManager.ESP.UdonESP;
			}
			set
			{
				if (value)
				{
					AddESPToVRCInteractables();
				}
				else
				{
					RemoveESPToVRCInteractables();
				}

				ConfigManager.ESP.UdonESP = value;
				if (VRCInteractableESPToggleBtn != null)
				{
					VRCInteractableESPToggleBtn.setToggleState(value);
				}
			}
		}

		public static void AddESPToVRCInteractables()
		{
			var items = WorldUtils.GetAllVRCInteractables();
			foreach (var item in items)
			{
				if (item != null)
				{
					
					var ESP = item.GetComponent<ESP_VRCInteractable>();
					if(ESP == null)
					{
						item.AddComponent<ESP_VRCInteractable>();
					}
				}
			}
		}

		public static void RemoveESPToVRCInteractables()
		{
			var items = WorldUtils.GetAllVRCInteractables();
			foreach (var item in items)
			{
				var ESP = item.GetComponent<ESP_VRCInteractable>();
				if (ESP != null)
				{
					ESP.DestroyMeLocal();
				}
			}
		}

		#endregion VRCInteractableESP

		#region PickupESP

		public static bool Toggle_Pickup_ESP
		{
			get
			{
				return ConfigManager.ESP.PickupESP;
			}
			set
			{
				if (value)
				{
					AddESPToPickups();
				}
				else
				{
					RemoveESPToPickups();
				}

				ConfigManager.ESP.PickupESP = value;
				if (PickupESPToggleBtn != null)
				{
					PickupESPToggleBtn.setToggleState(value);
				}
			}
		}

		private static void AddESPToPickups()
		{
			var items = WorldUtils.GetPickups();
			foreach (var item in items)
			{
				if (item != null)
				{
					var ESP = item.GetComponent<ESP_Pickup>();
					if (ESP == null)
					{
						item.AddComponent<ESP_Pickup>();
					}
				}
			}
		}

		private static void RemoveESPToPickups()
		{
			var items = WorldUtils.GetPickups();
			foreach (var item in items)
			{
				var ESP = item.GetComponent<ESP_Pickup>();
				if (ESP != null)
				{
					ESP.DestroyMeLocal();
				}
			}
		}

		#endregion PickupESP

		#region TriggerESP

		public static bool Toggle_Trigger_ESP
		{
			get
			{
				return ConfigManager.ESP.TriggerESP;
			}
			set
			{
				if (value)
				{
					AddESPToTriggers();
				}
				else
				{
					RemoveESPToTriggers();
				}

				ConfigManager.ESP.TriggerESP = value;
				if (TriggerESPToggleBtn != null)
				{
					TriggerESPToggleBtn.setToggleState(value);
				}
			}
		}

		private static void AddESPToTriggers()
		{
			var items = WorldUtils.GetTriggers();
			foreach (var item in items)
			{
				if (item != null)
				{
					var ESP = item.GetComponent<ESP_Trigger>();
					if (ESP == null)
					{
						item.AddComponent<ESP_Trigger>();
					}
					//if (WorldUtils.GetWorldID() == WorldIds.SnoozeScaryMaze5)
					//{
					//    if (item.name == "The Doctor Watcher Activate")
					//    {
					//        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
					//        continue;
					//    }
					//    if (item.name == "Teddy Watcher Activate")
					//    {
					//        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
					//        continue;
					//    }
					//    if (item.name == "Kill Trigger For Maze Part 2")
					//    {
					//        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
					//        continue;
					//    }
					//    if (item.name == "Kill Trigger For Maze")
					//    {
					//        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
					//        continue;
					//    }
					//    if (item.transform.parent != null && item.transform.parent.gameObject != null)
					//    {
					//        if (item.transform.parent.gameObject.name == "Do Something Easter Egg")
					//        {
					//            if (item.name == "Area Trigger")
					//            {
					//                ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name + " With parent : " + item.transform.parent.gameObject.name);
					//                continue;
					//            }
					//        }
					//    }

					//    item.AddComponent<ObjectESP>();
					//}
					//else
					//{
					//    item.AddComponent<ObjectESP>();
					//}
				}
			}
		}

		private static void RemoveESPToTriggers()
		{
			var items = WorldUtils.GetTriggers();
			foreach (var item in items)
			{
				var ESP = item.GetComponent<ESP_Trigger>();
				if (ESP != null)
				{
					ESP.DestroyMeLocal();
				}
			}
		}

		#endregion TriggerESP

		#region playerESP

		public static bool Toggle_Player_ESP
		{
			get
			{
				return ConfigManager.ESP.PlayerESP;
			}
			set
			{
				if (value)
				{
					AddESPToAllPlayers();
				}
				else
				{
					RemoveAllActivePlayerESPs();
				}

				ConfigManager.ESP.PlayerESP = value;
				if (PlayerESPToggleBtn != null)
				{
					PlayerESPToggleBtn.setToggleState(value);
				}
			}
		}

		public override void OnPlayerJoined(Player player)
		{
			if (Toggle_Player_ESP)
			{
				if (player != null && player != LocalPlayerUtils.GetSelfPlayer())
				{
					player.gameObject.AddComponent<PlayerESP>();
				}
			}
		}

		private static void AddESPToAllPlayers()
		{
			foreach (var item in WorldUtils.GetAllPlayers0())
			{
				if (item != LocalPlayerUtils.GetSelfPlayer())
				{
					if (item.gameObject.GetComponent<PlayerESP>() == null)
					{
						item.gameObject.AddComponent<PlayerESP>();
						item.gameObject.GetComponent<PlayerESP>().ChangeColor(ConfigManager.ESP.ESPColor);
					}
				}
			}
		}

		private static void RemoveAllActivePlayerESPs()
		{
			foreach (var player in WorldUtils.GetAllPlayers0())
			{
				var esp = player.gameObject.GetComponent<PlayerESP>();
				if (esp != null)
				{
					UnityEngine.Object.Destroy(esp);
				}
			}
		}

		#endregion playerESP

		#region UdonBehaviourESP

		private static bool Toggle_UdonBehaviour_ESP
		{
			get
			{
				return ConfigManager.ESP.UdonESP;
			}
			set
			{
				if (value)
				{
					AddESPToUdonBehaviours();
				}
				else
				{
					RemoveESPToUdonBehaviours();
				}

				ConfigManager.ESP.UdonESP = value;
				if (UdonBehaviourESPToggleBtn != null)
				{
					UdonBehaviourESPToggleBtn.setToggleState(value);
				}
			}
		}

		private static void AddESPToUdonBehaviours()
		{
			var items = WorldUtils.GetUdonBehaviours();
			foreach (var item in items)
			{
				if (item != null)
				{
					var ESP = item.GetComponent<ESP_UdonBehaviour>();
					if (ESP == null)
					{
						item.AddComponent<ESP_UdonBehaviour>();
					}
				}
			}
		}

		private static void RemoveESPToUdonBehaviours()
		{
			var items = WorldUtils.GetUdonBehaviours();
			foreach (var item in items)
			{
				var ESP = item.GetComponent<ESP_UdonBehaviour>();
				if (ESP != null)
				{
					ESP.DestroyMeLocal();
				}
			}
		}

		#endregion UdonBehaviourESP
	}
}