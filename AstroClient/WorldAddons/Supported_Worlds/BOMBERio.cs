﻿namespace AstroClient
{
	using AstroClient.Components;
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using RubyButtonAPI;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using static AstroClient.Variables.CustomLists;

	public class BOMBERio : GameEvents
	{
		public static void InitButtons(QMTabMenu main, float x, float y)
		{
			BOMBERioCheatsPage = new QMNestedButton(main, x, y, "BOMBERio", "BOMBERio Cheats", null, null, null, null, true);
			Always_ShootBomb_0_Toggle = new QMSingleToggleButton(BOMBERioCheatsPage, 1, 0, "Shoot Bomb 0", () => { Override_ShootBomb_0_Toggle = true; }, "Shoot Bomb 0", () => { Override_ShootBomb_0_Toggle = false; }, "Always Shoot A Specified Projectile", Color.green, Color.red, null, false, true);
			Always_ShootBomb_1_Toggle = new QMSingleToggleButton(BOMBERioCheatsPage, 1, 0.5f, "Shoot Bomb 1", () => { Override_ShootBomb_1_Toggle = true; }, "Shoot Bomb 1", () => { Override_ShootBomb_1_Toggle = false; }, "Always Shoot A Specified Projectile", Color.green, Color.red, null, false, true);
			Always_ShootBomb_2_Toggle = new QMSingleToggleButton(BOMBERioCheatsPage, 1, 1, "Shoot Bomb 2", () => { Override_ShootBomb_2_Toggle = true; }, "Shoot Bomb 2", () => { Override_ShootBomb_2_Toggle = false; }, "Always Shoot A Specified Projectile", Color.green, Color.red, null, false, true);
			Always_ShootBomb_3_Toggle = new QMSingleToggleButton(BOMBERioCheatsPage, 1, 1.5f, "Shoot Bomb 3", () => { Override_ShootBomb_3_Toggle = true; }, "Shoot Bomb 3", () => { Override_ShootBomb_3_Toggle = false; }, "Always Shoot A Specified Projectile", Color.green, Color.red, null, false, true);
			Always_ShootBomb_4_Toggle = new QMSingleToggleButton(BOMBERioCheatsPage, 1, 2, "Shoot First Player Bomb", () => { Override_ShootBomb_4_Toggle = true; }, "Shoot First Player Bomb", () => { Override_ShootBomb_4_Toggle = false; }, "Always Shoot A Specified Projectile", Color.green, Color.red, null, false, true);
			Always_ShootBomb_5_Toggle = new QMSingleToggleButton(BOMBERioCheatsPage, 1, 2.5f, "Shoot Rocket", () => { Override_ShootBomb_5_Toggle = true; }, "Shoot Rocket", () => { Override_ShootBomb_5_Toggle = false; }, "Always Shoot A Specified Projectile", Color.green, Color.red, null, false, true);

			new QMSingleButton(BOMBERioCheatsPage, 2, 0f, "Harvest 10 Crystals", () => { HarvestQuads(10); }, "Harvest some Quads!", null, null, true);
			new QMSingleButton(BOMBERioCheatsPage, 2, 0.5f, "Harvest 20 Crystals", () => { HarvestQuads(20); }, "Harvest some Quads!", null, null, true);
			new QMSingleButton(BOMBERioCheatsPage, 2, 1, "Harvest 50 Crystals", () => { HarvestQuads(50); }, "Harvest some Quads!", null, null, true);
			new QMSingleButton(BOMBERioCheatsPage, 2, 1.5f, "Harvest 100 Crystals", () => { HarvestQuads(100); }, "Harvest some Quads!", null, null, true);
			new QMSingleButton(BOMBERioCheatsPage, 2, 2f, "Harvest 500 Crystals", () => { HarvestQuads(500); }, "Harvest some Quads!", null, null, true);
			new QMSingleButton(BOMBERioCheatsPage, 2, 2.5f, "Harvest 1000 Crystals", () => { HarvestQuads(1000); }, "Harvest some Quads!", null, null, true);

		}

		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			if (id == WorldIds.BOMBERio)
			{
				ModConsole.Log($"Recognized {Name} World, Enabling Gun Projectile Hijacker..");
				isBomberIO = true;

			}
			else
			{
				isBomberIO = false;
			}
		}

		private bool isBomberIO = false;



		public static GameObject GetRandomQuad()
		{
			foreach(var item in GameObjectFinder.FindRootSceneObject("ItemManager").transform.Get_Childs())
			{
				ModConsole.DebugLog($"Grabbed Quad : {item.name}");
				return item.gameObject;
			}
			return null;
		}
		private static GameObject _Quad;
		private static GameObject Quad
		{
			get
			{
				if(_Quad == null)
				{
					return 	_Quad = GetRandomQuad();
				}
				return _Quad;
			}
		}

		private static bool isHarvesting = false;
		private static bool isInGame = false;
		public static void HarvestQuads(int amount)
		{
			if (!isHarvesting)
			{
				MelonLoader.MelonCoroutines.Start(HarvestQuadsRoutine(amount));
				isHarvesting = true;
			}
		}

		public static IEnumerator HarvestQuadsRoutine(int amount)
		{
			while (Quad == null) yield return null;
			int i = 0;
			while (i <= amount && isInGame)
			{
				Quad?.SetActive(true);
				Quad?.TeleportToMe(HumanBodyBones.RightFoot);
				i++;
				yield return null;
			}
			isHarvesting = false;
			yield return null;
		}





		private static void OnGameJoinEvent()
		{
			isInGame = true;
		}

		private static void OnGameExitStageEvent()
		{
			isInGame = false;

		}



		public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
		{
			if (isBomberIO)
			{
				
				if (sender.DisplayName() == Utils.LocalPlayer.GetPlayer().DisplayName())
				{
					if (obj.name.ToLower().StartsWith("followobj"))
					{
						
						if (AssignedNode == null)
						{
							if (action.ToLower().Contains("join"))
							{
								FindEverything(obj);
								OnGameJoinEvent();
							}
							else if (action.ToLower().Contains("ExitStage"))
							{
								FindEverything(obj);
								OnGameExitStageEvent();
							}
						}
						else
						{
							if (obj == AssignedNode)
							{
								if (action.ToLower().Contains("join"))
								{
									OnGameJoinEvent();
								}
								else if (action.ToLower().Contains("ExitStage"))
								{
									OnGameExitStageEvent();
								}
							}
						}
					}
				}
			}
		}

		public override void OnUpdate()
		{
			if (isBomberIO && isInGame)
			{
				if (control != null)
				{
					if (control.IsHeld)
					{
						if (control.CurrentHand == VRC.SDKBase.VRC_Pickup.PickupHand.Left)
						{
							if (InputUtils.IsImputUseLeftCalled() || InputUtils.IsInputUseLeftPressed())
							{
								if (!HasShot)
								{
									ModConsole.DebugLog("Detected Use Left, executing...");
									ShootModifiedBullet();
									HasShot = true;
								}
							}
							else
							{
								HasShot = false;
							}
						}
						else if(control.CurrentHand == VRC.SDKBase.VRC_Pickup.PickupHand.Right)
						{
							if (InputUtils.IsImputUseRightCalled() || InputUtils.IsInputUseRightPressed())
							{
								if (!HasShot)
								{
									ModConsole.DebugLog("Detected Use Right, executing...");
									ShootModifiedBullet();
									HasShot = true;
								}
							}
							else
							{
								HasShot = false;
							}

						}
					}
				}

			}
		}


		private static bool HasShot = false;
		private void ShootModifiedBullet()
		{
			if (AssignedNode != null)
			{

				if (Override_ShootBomb_0_Toggle)
				{
					if (ShootBomb0 != null)
					{
						ShootBomb0.ExecuteUdonEvent();
					}
				}
				else if (Override_ShootBomb_1_Toggle)
				{
					if (ShootBomb1 != null)
					{
						ShootBomb1.ExecuteUdonEvent();
					}
				}
				else if (Override_ShootBomb_2_Toggle)
				{
					if (ShootBomb2 != null)
					{
						ShootBomb2.ExecuteUdonEvent();
					}
				}
				else if (Override_ShootBomb_3_Toggle)
				{
					if (ShootBomb3 != null)
					{
						ShootBomb3.ExecuteUdonEvent();
					}
				}
				else if (Override_ShootBomb_4_Toggle)
				{
					if (ShootBomb4 != null)
					{
						ShootBomb4.ExecuteUdonEvent();
					}
				}
				else if (Override_ShootBomb_5_Toggle)
				{
					if (ShootBombEx != null)
					{
						ShootBombEx.ExecuteUdonEvent();
					}
				}
			}
		}
		public static void FindEverything(GameObject obj)
		{
			if (obj != null)
			{
				AssignedNode = obj;
				if (AssignedNode != null)
				{
					var Item = AssignedNode.transform.FindObject("Shooter");
					if(Item != null)
					{
						control = Item.GetOrAddComponent<PickupController>();
					}
					var shooterbody = AssignedNode.transform.FindObject("Shooter/ShooterBody");
					if (shooterbody != null)
					{
						ShootBomb0 = shooterbody.gameObject.FindUdonEvent("ShootBomb0");
						ShootBomb1 = shooterbody.gameObject.FindUdonEvent("ShootBomb1");
						ShootBomb2 = shooterbody.gameObject.FindUdonEvent("ShootBomb2");
						ShootBomb3 = shooterbody.gameObject.FindUdonEvent("ShootBomb3");
						ShootBomb4 = shooterbody.gameObject.FindUdonEvent("ShootBomb4");
						ShootBombEx = shooterbody.gameObject.FindUdonEvent("ShootBombEx");
					}
				}
			}
		}

		public override void OnSceneLoaded(int buildIndex, string sceneName)
		{
			AssignedNode = null;
			ShootBomb0 = null;
			ShootBomb1 = null;
			ShootBomb2 = null;
			ShootBomb3 = null;
			ShootBomb4 = null;
			ShootBombEx = null;
			Override_ShootBomb_0_Toggle = false;
			Override_ShootBomb_1_Toggle = false;
			Override_ShootBomb_2_Toggle = false;
			Override_ShootBomb_3_Toggle = false;
			Override_ShootBomb_4_Toggle = false;
			Override_ShootBomb_5_Toggle = false;
			control = null;
			HasShot = false;
			_Quad = null;
			isInGame = false;
			isHarvesting = false;
		}

		public static PickupController control;

		public static CachedUdonEvent ShootBomb0;
		public static CachedUdonEvent ShootBomb1;
		public static CachedUdonEvent ShootBomb2;
		public static CachedUdonEvent ShootBomb3;
		public static CachedUdonEvent ShootBomb4;
		public static CachedUdonEvent ShootBombEx;

		public static GameObject AssignedNode;
		public static QMNestedButton BOMBERioCheatsPage;

		public static QMSingleToggleButton Always_ShootBomb_0_Toggle;
		public static QMSingleToggleButton Always_ShootBomb_1_Toggle;
		public static QMSingleToggleButton Always_ShootBomb_2_Toggle;
		public static QMSingleToggleButton Always_ShootBomb_3_Toggle;
		public static QMSingleToggleButton Always_ShootBomb_4_Toggle;
		public static QMSingleToggleButton Always_ShootBomb_5_Toggle;

		private static bool _Override_ShootBomb_0_Toggle;

		private static bool Override_ShootBomb_0_Toggle
		{
			get
			{
				return _Override_ShootBomb_0_Toggle;
			}
			set
			{
				if (value == _Override_ShootBomb_0_Toggle)
				{
					return; // Discard.
				}

				if (value)
				{
					// Disable the rest
					Override_ShootBomb_1_Toggle = false;
					Override_ShootBomb_2_Toggle = false;
					Override_ShootBomb_3_Toggle = false;
					Override_ShootBomb_4_Toggle = false;
					Override_ShootBomb_5_Toggle = false;
				}

				_Override_ShootBomb_0_Toggle = value;
				if (Always_ShootBomb_0_Toggle != null)
				{
					Always_ShootBomb_0_Toggle.SetToggleState(value);
				}
			}
		}

		private static bool _Override_ShootBomb_1_Toggle;

		private static bool Override_ShootBomb_1_Toggle
		{
			get
			{
				return _Override_ShootBomb_1_Toggle;
			}
			set
			{
				if (value == _Override_ShootBomb_1_Toggle)
				{
					return; // Discard.
				}

				if (value)
				{
					// Disable the rest
					Override_ShootBomb_0_Toggle = false;
					Override_ShootBomb_2_Toggle = false;
					Override_ShootBomb_3_Toggle = false;
					Override_ShootBomb_4_Toggle = false;
					Override_ShootBomb_5_Toggle = false;
				}

				_Override_ShootBomb_1_Toggle = value;
				if (Always_ShootBomb_1_Toggle != null)
				{
					Always_ShootBomb_1_Toggle.SetToggleState(value);
				}
			}
		}

		private static bool _Override_ShootBomb_2_Toggle;

		private static bool Override_ShootBomb_2_Toggle
		{
			get
			{
				return _Override_ShootBomb_2_Toggle;
			}
			set
			{
				if (value == _Override_ShootBomb_2_Toggle)
				{
					return; // Discard.
				}

				if (value)
				{
					// Disable the rest
					Override_ShootBomb_0_Toggle = false;
					Override_ShootBomb_2_Toggle = false;
					Override_ShootBomb_3_Toggle = false;
					Override_ShootBomb_4_Toggle = false;
					Override_ShootBomb_5_Toggle = false;
				}

				_Override_ShootBomb_2_Toggle = value;
				if (Always_ShootBomb_2_Toggle != null)
				{
					Always_ShootBomb_2_Toggle.SetToggleState(value);
				}
			}
		}

		private static bool _Override_ShootBomb_3_Toggle;

		private static bool Override_ShootBomb_3_Toggle
		{
			get
			{
				return _Override_ShootBomb_3_Toggle;
			}
			set
			{
				if (value == _Override_ShootBomb_3_Toggle)
				{
					return; // Discard.
				}

				if (value)
				{
					// Disable the rest
					Override_ShootBomb_0_Toggle = false;
					Override_ShootBomb_1_Toggle = false;
					Override_ShootBomb_2_Toggle = false;
					Override_ShootBomb_4_Toggle = false;
					Override_ShootBomb_5_Toggle = false;
				}

				_Override_ShootBomb_3_Toggle = value;
				if (Always_ShootBomb_3_Toggle != null)
				{
					Always_ShootBomb_3_Toggle.SetToggleState(value);
				}
			}
		}

		private static bool _Override_ShootBomb_4_Toggle;

		private static bool Override_ShootBomb_4_Toggle
		{
			get
			{
				return _Override_ShootBomb_4_Toggle;
			}
			set
			{
				if (value == _Override_ShootBomb_4_Toggle)
				{
					return; // Discard.
				}

				if (value)
				{
					// Disable the rest
					Override_ShootBomb_0_Toggle = false;
					Override_ShootBomb_1_Toggle = false;
					Override_ShootBomb_2_Toggle = false;
					Override_ShootBomb_3_Toggle = false;
					Override_ShootBomb_5_Toggle = false;
				}

				_Override_ShootBomb_4_Toggle = value;
				if (Always_ShootBomb_4_Toggle != null)
				{
					Always_ShootBomb_4_Toggle.SetToggleState(value);
				}
			}
		}

		private static bool _Override_ShootBomb_5_Toggle;

		private static bool Override_ShootBomb_5_Toggle
		{
			get
			{
				return _Override_ShootBomb_5_Toggle;
			}
			set
			{
				if (value == _Override_ShootBomb_5_Toggle)
				{
					return; // Discard.
				}

				if (value)
				{
					// Disable the rest
					Override_ShootBomb_0_Toggle = false;
					Override_ShootBomb_1_Toggle = false;
					Override_ShootBomb_2_Toggle = false;
					Override_ShootBomb_3_Toggle = false;
					Override_ShootBomb_4_Toggle = false;
				}

				_Override_ShootBomb_5_Toggle = value;
				if (Always_ShootBomb_5_Toggle != null)
				{
					Always_ShootBomb_5_Toggle.SetToggleState(value);
				}
			}
		}





	}
}