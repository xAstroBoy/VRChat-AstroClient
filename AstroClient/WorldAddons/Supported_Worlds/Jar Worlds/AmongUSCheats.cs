namespace AstroClient
{
	using AstroClient.AstroUtils.PlayerMovement;
	using AstroClient.components;
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroClient.Finder;
	using AstroClient.UdonExploits;
	using AstroClient.Variables;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using VRC.Udon;
	using static AstroClient.variables.CustomLists;
	using System.Collections.Generic;

	public class AmongUSCheats : GameEvents
	{
		public override void OnLevelLoaded()
		{
			StartGameEvent = null;
			AbortGameEvent = null;
			VictoryCrewmateEvent = null;
			VictoryImpostorEvent = null;

			AssignedSelfRole = null;
			AssignedTargetRole = null;
			TargetNode = null;
			SafetySwap = false;

			RoleSwapper_GetImpostorRole = false;
			SerializerRot = new Quaternion(0,0,0,0);
			SerializerPos = Vector3.zero;
			if(ToggleSerializerShortcut != null)
			{
				ToggleSerializerShortcut.setToggleState(false);
			}
			BodyOutlines.Clear();
			BodyESPs = false;
		}

		public static void FindAmongUsObjects()
		{
			ModConsole.Log("Removing Anti-Peek Protection...");
			var occlusion = GameObjectFinder.Find("Environment/skeld occ");
			if (occlusion != null)
			{
				occlusion.DestroyMeLocal();
			}
			ModConsole.Log("Removing Invisible Walls");
			var invisiblewall = GameObjectFinder.Find("Environment/Invisible wall");
			var invisiblewall_1 = GameObjectFinder.Find("Environment/Invisible wall (1)");
			if (invisiblewall != null)
			{
				invisiblewall.DestroyMeLocal();
			}
			if (invisiblewall_1 != null)
			{
				invisiblewall_1.DestroyMeLocal();
			}

			foreach (var action in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
			{
				if (action.gameObject.name == "Game Logic")
				{
					foreach (var subaction in action._eventTable)
					{
						if (subaction.key == "SyncStart")
						{
							StartGameEvent = new CachedUdonEvent(action, subaction.key);
							ModConsole.Log("Found Start Game Event.");
						}
						if (subaction.key == "SyncAbort")
						{
							AbortGameEvent = new CachedUdonEvent(action, subaction.key);
							ModConsole.Log("Found Abort Game Event.");
						}
						if (subaction.key == "SyncVictoryB")
						{
							VictoryCrewmateEvent = new CachedUdonEvent(action, subaction.key);
							ModConsole.Log("Found Victory Crewmate Event.");
						}
						if (subaction.key == "SyncVictoryM")
						{
							VictoryImpostorEvent = new CachedUdonEvent(action, subaction.key);
							ModConsole.Log("Found Victory Impostor Event.");
						}
						if (StartGameEvent != null && AbortGameEvent != null && VictoryCrewmateEvent != null && VictoryImpostorEvent != null)
						{
							ModConsole.DebugLog("Finished Finding all Udon Events!");
							break;
						}
					}
				}
			}
			if (GameStartbtn != null)
			{
				GameStartbtn.setActive(StartGameEvent.isNotNull());
				GameStartbtn.setIntractable(StartGameEvent.isNotNull());
			}
			if (GameAbortbtn != null)
			{
				GameAbortbtn.setActive(AbortGameEvent.isNotNull());
				GameAbortbtn.setIntractable(AbortGameEvent.isNotNull());
			}
			if (GameVictoryCrewmateBtn != null)
			{
				GameVictoryCrewmateBtn.setActive(VictoryCrewmateEvent.isNotNull());
				GameVictoryCrewmateBtn.setIntractable(VictoryCrewmateEvent.isNotNull());
			}
			if (GameVictoryImpostorBtn != null)
			{
				GameVictoryImpostorBtn.setActive(VictoryImpostorEvent.isNotNull());
				GameVictoryImpostorBtn.setIntractable(VictoryImpostorEvent.isNotNull());
			}
			if (JarRoleController.JarRoleLinks.Count() != 0)
			{
				foreach (var item in JarRoleController.JarRoleLinks)
				{
					var corpse = item.Node.FindObject("Corpse");
					if(corpse != null)
					{
						if(!BodyOutlines.Contains(corpse))
						{
							BodyOutlines.Add(corpse);
						}
					}
				}
			}
		}

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (id == WorldIds.AmongUS)
			{
				HasAmongUsWorldLoaded = true;
				if (AmongUsCheatsPage != null)
				{
					ModConsole.Log($"Recognized {name} World, Unlocking Among US cheats menu!", System.Drawing.Color.Green);
					AmongUsCheatsPage.getMainButton().setIntractable(true);
					AmongUsCheatsPage.getMainButton().setTextColor(Color.green);
				}
				FindAmongUsObjects();
			}
			else
			{
				HasAmongUsWorldLoaded = false;
				if (AmongUsCheatsPage != null)
				{
					AmongUsCheatsPage.getMainButton().setIntractable(false);
					AmongUsCheatsPage.getMainButton().setTextColor(Color.red);
				}
			}
		}

		public static void AmongUSCheatsButtons(QMTabMenu submenu, float BtnXLocation, float BtnYLocation, bool btnHalf)
		{
			AmongUsCheatsPage = new QMNestedButton(submenu, BtnXLocation, BtnYLocation, "Among US Cheats", "Manage Among US Cheats", null, null, null, null, btnHalf);
			JarRoleController.AmongUSRolesRevealerToggle = new QMSingleToggleButton(AmongUsCheatsPage, 1, 0, "Reveal Roles On", new Action(() => { JarRoleController.ViewRoles = true; }), "Reveals Roles Off", new Action(() => { JarRoleController.ViewRoles = false; }), "Reveals Current Players Roles In nameplates.", Color.green, Color.red, null, false, true);

			
			AmongUSUdonExploits.Init_GameController_Menu(AmongUsCheatsPage, 2, 0, true);

			AmongUSUdonExploits.Init_FilteredNodes_Menu(AmongUsCheatsPage, 2f, 0.5f, true);
			AmongUSUdonExploits.InitUnfilteredNodesMenu(AmongUsCheatsPage, 2f, 1f, true);

			AmongUSUdonExploits.Init_SabotageAndRepair_Menu(AmongUsCheatsPage, 3f, 0f, true);
			AmongUSUdonExploits.Init_KillPlayers_Menu(AmongUsCheatsPage, 3f, 0.5f, true);

			AmongUSUdonExploits.Init_ForceVotePlayer_menu(AmongUsCheatsPage, 4f, 0f, true);
			AmongUSUdonExploits.Init_ForcePlayerEject_Menu(AmongUsCheatsPage, 4f, 0.5f, true);

			AmongUSUdonExploits.Init_RoleSwap_Menu(AmongUsCheatsPage, 4f, 1f, true);
			GetImpostorRoleBtn = new QMSingleToggleButton(AmongUsCheatsPage, 4, 1.5f, "Get Impostor Role", new Action(() => { RoleSwapper_GetImpostorRole = true; }), "Get Impostor Role", new Action(() => { RoleSwapper_GetImpostorRole = false; }), "Assign Yourself Impostor Role on Next Round!", Color.green, Color.red, null, false, true);
			ToggleSerializerShortcut = new QMSingleToggleButton(AmongUsCheatsPage, 4, 2f, "Toggle Serializer", new Action(() => { AmongUsSerializer = true; }), "Toggle Serializer", new Action(() => { AmongUsSerializer = false;  }), "Serialize For Stealth or to frame someone else!", Color.green, Color.red, null, false, true);
			GameBodyESPBtn = new QMSingleToggleButton(AmongUsCheatsPage, 4, 2.5f, "Body ESP", new Action(() => { BodyESPs = true; }), "Body ESP", new Action(() => { BodyESPs = false; }), "Makes Impostor Kills Visible (Yellow)!", Color.green, Color.red, null, false, true);

			GameStartbtn = new QMSingleButton(AmongUsCheatsPage, 1, 1, "Start Game", new Action(() => { StartGameEvent.ExecuteUdonEvent(); }), "Force Start Game Event", null, Color.green, true);
			GameAbortbtn = new QMSingleButton(AmongUsCheatsPage, 1, 1.5f, "Abort Game", new Action(() => { AbortGameEvent.ExecuteUdonEvent(); }), "Force Abort Game Event", null, Color.green, true);

			GameVictoryCrewmateBtn = new QMSingleButton(AmongUsCheatsPage, 1, 2, "Victory Crewmate", new Action(() => { VictoryCrewmateEvent.ExecuteUdonEvent(); }), "Force Victory Crewmate Event", null, Color.green, true);
			GameVictoryImpostorBtn = new QMSingleButton(AmongUsCheatsPage, 1, 2.5f, "Victory Impostor", new Action(() => { VictoryImpostorEvent.ExecuteUdonEvent(); }), "Force Victory Impostor Event", null, Color.red, true);
		}


		public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
		{
			try
			{
				if (HasAmongUsWorldLoaded)
				{
					if (obj != null)
					{
						if (action.StartsWith("SyncAssign") && JarRoleController.GetLocalPlayerNode().Node != null)
						{
							if (RoleSwapper_GetImpostorRole)
							{
								if (!SafetySwap) // In case it grabs and update the current ones already!
								{
									if (obj == JarRoleController.GetLocalPlayerNode().Node)
									{
										AssignedSelfRole = action;
									}

									if (action == "SyncAssignM")
									{
										TargetNode = obj;
										AssignedTargetRole = action;
									}

									RoleSwapper_GetImpostorRole = SwapRoles(JarRoleController.GetLocalPlayerNode().Node, TargetNode, AssignedSelfRole, AssignedTargetRole);
								}
							}
						}
					}
				}
			}
			catch { }
		}

		public static bool SwapRoles(GameObject SelfNode, GameObject TargetNode, string AssignedSelfRole, string AssignedTargetRole)
		{
			if (SelfNode == null && TargetNode == null && AssignedSelfRole == null && AssignedTargetRole == null)
			{
				SafetySwap = false;
				return true; // Keep it active.
			}
			if (string.IsNullOrEmpty(AssignedSelfRole) && string.IsNullOrWhiteSpace(AssignedSelfRole))
			{
				SafetySwap = false;
				return true;
			}
			if (string.IsNullOrEmpty(AssignedTargetRole) && string.IsNullOrWhiteSpace(AssignedTargetRole))
			{
				SafetySwap = false;
				return true;
			}
			if (SelfNode == TargetNode)
			{
				ModConsole.DebugLog("Target Node and SelfNode are the same!");
				SafetySwap = false;
				return false; // Deactivate..
			}
			if (AssignedTargetRole == AssignedSelfRole)
			{
				ModConsole.DebugLog("Target Role String and Self Role String are the same!");
				SafetySwap = false;
				return false;
			}

			MiscUtility.DelayFunction(0.01f, new Action(() =>
			{
				ModConsole.DebugLog($"Executing Role Swapping!, Target Has Role : {AssignedTargetRole}, You have {AssignedSelfRole}.");
				var TargetEvent = UdonSearch.FindUdonEvent(TargetNode, AssignedSelfRole);
				if (TargetEvent != null)
				{
					TargetEvent.ExecuteUdonEvent();
				}

				var selfevent = UdonSearch.FindUdonEvent(SelfNode, AssignedTargetRole);
				if (selfevent != null)
				{
					selfevent.ExecuteUdonEvent();
				}
			}));

			SafetySwap = true;

			SafetySwap = false;
			return false; // Deactivate.
		}

		private static GameObject TargetNode;
		private static string AssignedTargetRole;
		private static string AssignedSelfRole;

		private static bool SafetySwap;

		public static bool _RoleSwapper_GetImpostorRole;

		public static bool RoleSwapper_GetImpostorRole
		{
			get
			{
				return _RoleSwapper_GetImpostorRole;
			}
			set
			{
				if (value == _RoleSwapper_GetImpostorRole)
				{
					return;
				}
				_RoleSwapper_GetImpostorRole = value;
				if (GetImpostorRoleBtn != null)
				{
					GetImpostorRoleBtn.setToggleState(value);
				}
				if (value)
				{
					AssignedSelfRole = null;
					AssignedTargetRole = null;
					TargetNode = null;
					SafetySwap = false;
				}
				if (!value)
				{
					SafetySwap = false;
				}
			}
		}
		

		private static bool AmongUsSerializer
		{
			set
			{
				
				if(value)
				{
					SerializerPos = Utils.CurrentUser.transform.position;
					SerializerRot = Utils.CurrentUser.transform.rotation;
				}
				else
				{
					Utils.CurrentUser.transform.position = SerializerPos;
					Utils.CurrentUser.transform.rotation = SerializerRot;

					SerializerRot = new Quaternion(0, 0, 0, 0);
					SerializerPos = Vector3.zero;
				}
                Movement.SerializerEnabled = value;
			}
		}

		private static List<Transform> BodyOutlines = new List<Transform>();
		private static Vector3 SerializerPos;
		private static Quaternion SerializerRot;

		private static bool _BodyESps;
		private static bool BodyESPs
		{
			get
			{
				return _BodyESps;
			}
			set
			{
				if(value)
				{
					foreach (var item in BodyOutlines)
					{
						ESP_VRCInteractable ESP = item.gameObject.GetComponent<ESP_VRCInteractable>();
						if (ESP == null)
						{
							ESP = item.gameObject.AddComponent<ESP_VRCInteractable>();
						}
						if (ESP != null)
						{
							MiscUtility.DelayFunction(0.4f, new Action(() => { ESP.ChangeColor(Color.yellow); }));
						}
					}
				}
				else
				{
					foreach (var item in BodyOutlines)
					{
						ESP_VRCInteractable ESP = item.gameObject.GetComponent<ESP_VRCInteractable>();
						if (ESP != null)
						{
							ESP.DestroyMeLocal();
						}
					}
				}
				_BodyESps = value;
				if(GameBodyESPBtn != null)
				{
					GameBodyESPBtn.setToggleState(value);
				}
			}
		}

		public static QMSingleButton GameStartbtn;
		public static QMSingleButton GameAbortbtn;
		public static QMSingleButton GameVictoryCrewmateBtn;
		public static QMSingleButton GameVictoryImpostorBtn;
		public static QMSingleToggleButton GameBodyESPBtn;

		public static QMSingleToggleButton GetImpostorRoleBtn;
		public static QMSingleToggleButton ToggleSerializerShortcut;

		public static QMNestedButton AmongUsCheatsPage;

		public static bool HasAmongUsWorldLoaded = false;

		public static CachedUdonEvent StartGameEvent;
		public static CachedUdonEvent AbortGameEvent;

		public static CachedUdonEvent VictoryCrewmateEvent;
		public static CachedUdonEvent VictoryImpostorEvent;
	}
}