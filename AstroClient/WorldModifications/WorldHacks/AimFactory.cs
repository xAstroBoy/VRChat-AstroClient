using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Tools.Extensions;
    using Tools.UdonSearcher;
    using UnityEngine;
    using VRC;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;
    using Random = System.Random;

    internal class AimFactory : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnWorldReveal += OnWorldReveal;
        }



        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
                        ClientEventActions.Event_OnUdonSyncRPC += OnUdonSyncRPCEvent;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.Event_OnUdonSyncRPC -= OnUdonSyncRPCEvent;

                    }
                }
                _HasSubscribed = value;
            }
        }

        internal static void InitButtons(QMGridTab main)
        {
            AimFactoryCheatPage = new QMNestedGridMenu(main, "Aim Factory", "Aim Factory Cheats");
            AlwaysPerfectHitToggle = new QMToggleButton(AimFactoryCheatPage, 1, 0, "Always Hit ON", new Action(() => { IsAlwaysPerfectHit = true; }), "Always Hit OFF", new Action(() => { IsAlwaysPerfectHit = false; }), "Unfreezes you automatically", null, null, null);
        }

        private void OnRoomLeft()
        {
            IsAlwaysPerfectHit = false;
            MapTargets.Clear();
            isCurrentWorld = false;
            IsPoppingTarget = false;
            prevtarget = null;
        }


        

        internal static QMNestedGridMenu AimFactoryCheatPage;
        private static QMToggleButton AlwaysPerfectHitToggle;

        private static List<GameObject> MapTargets = new List<GameObject>();

        private static GameObject prevtarget = null;

        private static bool _IsAlwaysPerfectHit = false;

        private static Random r = new Random();

        private static bool _ActivateEvents = false;
        private static bool ActivateEvents
        {
            get => _ActivateEvents;
            set
            {
                if (_ActivateEvents == value) return;
                if(value)
                {

                }
                else
                {
                    
                }
            }
            
        }

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
            Log.Debug($"Filtered {MapTargets.Count()} Objects, only {FilteredLists.Count()} are Active.");
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

        private static bool isCurrentWorld = false;
        private static bool IsPoppingTarget = false;

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.AimFactory)
            {
                isCurrentWorld = true;
                if (AimFactoryCheatPage != null)
                {
                    AimFactoryCheatPage.GetMainButton().SetInteractable(true);
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
                            Log.Debug($"Registered Obj {target.name} in target list.");
                            MapTargets.Add(target.gameObject);
                        }
                    }
                }
                HasSubscribed = true;
            }
            else
            {
                isCurrentWorld = false;
                HasSubscribed = false;
                if (AimFactoryCheatPage != null)
                {
                    AimFactoryCheatPage.GetMainButton().SetInteractable(false);
                    AimFactoryCheatPage.GetMainButton().SetTextColor(Color.red);
                }
            }
        }

        // WORKS but the map doesn't count the objects, there must be something that triggers the point count!
        internal static IEnumerator PopTarget()
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
                            Log.Debug($"Sent Hit Event on {RandomTarget.name}");
                            udonevent1.InvokeBehaviour();
                        }
                        var udonevent = UdonSearch.FindUdonEvent(RandomTarget, "AllwaysHit");
                        if (udonevent != null)
                        {
                            Log.Debug($"Sent AllwaysHit Event on {RandomTarget.name}");
                            udonevent.InvokeBehaviour();
                        }
                    }
                }
            }
            IsPoppingTarget = false;
            yield return null;
        }

        private void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            if (isCurrentWorld && obj != null && IsAlwaysPerfectHit && sender != null && sender == GameInstances.LocalPlayer.GetPlayer() && obj.name.Equals("Handgun_M1911A (Model)") && action == "AllwaysTrigger" && !IsPoppingTarget)
            {
                IsPoppingTarget = true;
                _ = MelonLoader.MelonCoroutines.Start(PopTarget());
            }
        }
    }
}