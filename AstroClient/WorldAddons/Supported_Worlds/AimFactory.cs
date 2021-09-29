namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC;
    using Random = System.Random;

    internal class AimFactory : GameEvents
    {
        internal static  void InitButtons(QMTabMenu main, float x, float y, bool btnhalf)
        {
            AimFactoryCheatPage = new QMNestedButton(main, x, y, "Aim Factory", "Aim Factory Cheats", null, null, null, null, true);
            AlwaysPerfectHitToggle = new QMToggleButton(AimFactoryCheatPage, 1, 0, "Always Hit ON", new Action(() => { IsAlwaysPerfectHit = true; }), "Always Hit OFF", new Action(() => { IsAlwaysPerfectHit = false; }), "Unfreezes you automatically", null, null, null);
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            IsAlwaysPerfectHit = false;
            MapTargets.Clear();
            IsAimFactory = false;
            IsPoppingTarget = false;
            prevtarget = null;
        }

        internal static  QMNestedButton AimFactoryCheatPage;
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

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
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
                    UnhollowerBaseLib.Il2CppArrayBase<Transform> list = TargetsRootScene.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < list.Count; i++)
                    {
                        Transform target = list[i];
                        if (target.name.ToLower().StartsWith("target") && !MapTargets.Contains(target.gameObject))
                        {
                            ModConsole.DebugLog($"Registered Obj {target.name} in target list.");
                            MapTargets.Add(target.gameObject);
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
        internal static  IEnumerator PopTarget()
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

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            if (IsAimFactory && obj != null && IsAlwaysPerfectHit && sender != null && sender == Utils.LocalPlayer.GetPlayer() && obj.name.Equals("Handgun_M1911A (Model)") && action == "AllwaysTrigger" && !IsPoppingTarget)
            {
                IsPoppingTarget = true;
                _ = MelonLoader.MelonCoroutines.Start(PopTarget());
            }
        }
    }
}