namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroLibrary.Finder;
	using AstroClient.Variables;
	using RubyButtonAPI;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using Random = System.Random;

	public class AimFactory : GameEvents
	{
		public static void InitButtons(QMTabMenu main, float x, float y, bool btnhalf)
		{
			AimFactoryCheatPage = new QMNestedButton(main, x, y, "Aim Factory", "Aim Factory Cheats", null, null, null, null, true);
			AlwaysPerfectHitToggle = new QMToggleButton(AimFactoryCheatPage, 1, 0, "Always Hit ON", new Action(() => { IsAlwaysPerfectHit = true; }), "Always Hit OFF", new Action(() => { IsAlwaysPerfectHit = false; }), "Unfreezes you automatically", null, null, null);
		}

		public override void OnLevelLoaded()
		{
			IsAlwaysPerfectHit = false;
			MapTargets.Clear();
			IsAimFactory = false;
			IsPoppingTarget = false;
			prevtarget = null;
		}

		public static QMNestedButton AimFactoryCheatPage;
		private static QMToggleButton AlwaysPerfectHitToggle;

		private static List<GameObject> MapTargets = new List<GameObject>();

		private static GameObject prevtarget = null;

		private static bool _IsAlwaysPerfectHit = false;

		private static Random r = new Random();

		private static GameObject GetRandomtarget()
		{
			if (MapTargets.Count() == 0)
			{
				return null;
			}
			var FilteredLists = MapTargets.Where(x => x.active).ToList();
			if (FilteredLists.Count() == 0)
			{
				return null;
			}
			ModConsole.DebugLog($"Filtered {MapTargets.Count()} Objects, only {FilteredLists.Count()} are Active.");
			var obj = FilteredLists[r.Next(FilteredLists.Count())];
			if (prevtarget != null)
			{
				if (obj == prevtarget)
				{
					return GetRandomtarget();
				}
			}

			prevtarget = obj;
			return obj;
		}

		private static bool IsAlwaysPerfectHit
		{
			get
			{
				return _IsAlwaysPerfectHit;
			}
			set
			{
				_IsAlwaysPerfectHit = value;
				if (AlwaysPerfectHitToggle != null)
				{
					AlwaysPerfectHitToggle.SetToggleState(value);
				}
			}
		}

		private static bool IsAimFactory = false;
		private static bool IsPoppingTarget = false;

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (id == WorldIds.AimFactory)
			{
				IsAimFactory = true;
				if (AimFactoryCheatPage != null)
				{
					AimFactoryCheatPage.GetMainButton().SetIntractable(true);
					AimFactoryCheatPage.GetMainButton().SetTextColor(Color.green);
				}

				var Gamesound = GameObjectFinder.FindRootSceneObject("GameSound");
				if (Gamesound != null)
				{
					Gamesound.DestroyMeLocal();
				}

				var TargetsRootScene = GameObjectFinder.FindRootSceneObject("Targets");
				if (TargetsRootScene != null)
				{
					foreach (var target in TargetsRootScene.GetComponentsInChildren<Transform>(true))
					{
						if (target.name.ToLower().StartsWith("target"))
						{
							if (!MapTargets.Contains(target.gameObject))
							{
								ModConsole.DebugLog($"Registered Obj {target.name} in target list.");
								MapTargets.Add(target.gameObject);
							}
						}
					}
				}
			}
			else
			{
				IsAimFactory = false;
				if (AimFactoryCheatPage != null)
				{
					AimFactoryCheatPage.GetMainButton().SetIntractable(false);
					AimFactoryCheatPage.GetMainButton().SetTextColor(Color.red);
				}
			}
		}

		// WORKS but the map doesn't count the objects, there must be something that triggers the point count!
		public static IEnumerator PopTarget()
		{
			//float cooldown = 0.f;
			//DayClientML2.Utility.MiscUtility.DelayFunction(cooldown, new Action(() =>
			//{
			//}));
			if (IsPoppingTarget)
			{
				var RandomTarget = GetRandomtarget();
				if (RandomTarget != null)
				{
					if (RandomTarget != null)
					{
						var udonevent1 = UdonSearch.FindUdonEvent(RandomTarget, "Hit");
						if (udonevent1 != null)
						{
							ModConsole.DebugLog($"Sent Hit Event on {RandomTarget.name}");
							udonevent1.ExecuteUdonEvent();
						}
						var udonevent = UdonSearch.FindUdonEvent(RandomTarget, "AllwaysHit");
						if (udonevent != null)
						{
							ModConsole.DebugLog($"Sent AllwaysHit Event on {RandomTarget.name}");
							udonevent.ExecuteUdonEvent();
						}
					}
				}
			}
			IsPoppingTarget = false;
			yield return null;
		}

		public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
		{
			if (IsAimFactory)
			{
				if (obj != null)
				{
					if (IsAlwaysPerfectHit)
					{
						if (sender != null)
						{
							if (sender == LocalPlayerUtils.GetSelfPlayer())
							{
								if (obj.name.Equals("Handgun_M1911A (Model)"))
								{
									if (action == "AllwaysTrigger")
									{
										if (!IsPoppingTarget)
										{
											IsPoppingTarget = true;
											MelonLoader.MelonCoroutines.Start(PopTarget());
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}