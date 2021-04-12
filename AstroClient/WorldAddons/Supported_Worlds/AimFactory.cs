using AstroClient.ConsoleUtils;
using AstroClient.Variables;
using System;
using UnityEngine;
using AstroClient.extensions;
using AstroClient.Finder;
using VRC.Udon;
using System.Linq;
using VRC;
using RubyButtonAPI;
using System.Collections.Generic;

namespace AstroClient
{
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
            SelectedBeforeTarget = null;
        }


        public static QMNestedButton AimFactoryCheatPage;
        private static QMToggleButton AlwaysPerfectHitToggle;


        private static List<ShootingTarget> MapTargets = new List<ShootingTarget>();


        private static bool _IsAlwaysPerfectHit = false;
        private static ShootingTarget SelectedBeforeTarget;


        public class ShootingTarget
        {
            public GameObject TargetObj { get; set; }
            public bool HasPopped { get; set; }

            public ShootingTarget(GameObject obj, bool hasPopped)
            {
                TargetObj = obj;
                HasPopped = hasPopped;
            }
        }


        private static ShootingTarget FindTargetObject(GameObject obj)
        {
            return MapTargets.Where(x => x.TargetObj == obj).First();

        }



        private static ShootingTarget GetRandomtarget()
        {
            int val = ran.Next(MapTargets.Count);
            var target = MapTargets[val];
            if (target.HasPopped)
            {
                return GetRandomtarget();
            }
            else if (target == SelectedBeforeTarget)
            {
                return GetRandomtarget();
            }
            else
            {
                SelectedBeforeTarget = target;
                return target;
            }
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
                    AlwaysPerfectHitToggle.setToggleState(value);
                }
            }
        }


        private static bool IsAimFactory = false;

        private static System.Random ran = new System.Random();


        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.AimFactory)
            {
                IsAimFactory = true;
                if (AimFactoryCheatPage != null)
                {
                    AimFactoryCheatPage.getMainButton().setIntractable(true);
                    AimFactoryCheatPage.getMainButton().setTextColor(Color.green);
                }
            }
            else
            {
                IsAimFactory = false;
                if (AimFactoryCheatPage != null)
                {
                    AimFactoryCheatPage.getMainButton().setIntractable(false);
                    AimFactoryCheatPage.getMainButton().setTextColor(Color.red);
                }
            }
        }

        public static void PopTarget()
        {
            var target = GetRandomtarget();
            float cooldown = 0.3f;
            DayClientML2.Utility.MiscUtility.DelayFunction(cooldown, new Action(() => { if (!target.HasPopped) { UdonSearch.FindUdonEvent(target.TargetObj, "AllwaysHit").ExecuteUdonEvent(); } else { target.HasPopped = false; PopTarget(); } }));

        }

        public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (IsAimFactory)
                {
                    if (obj != null)
                    {
                        if (obj.name.ToLower().StartsWith("target"))
                        {
                            if (MapTargets.Count() != 0)
                            {
                                if (FindTargetObject(obj) == null)
                                {
                                    if (!MapTargets.Contains(new ShootingTarget(obj, false)))
                                    {
                                        MapTargets.Add(new ShootingTarget(obj, false));
                                    }
                                }
                                else
                                {
                                    MapTargets.Add(new ShootingTarget(obj, false));

                                }
                            }

                            if (IsAlwaysPerfectHit)
                            {
                                if (sender != null)
                                {
                                    if (sender == LocalPlayerUtils.GetSelfPlayer())
                                    {
                                        if (obj.name.ToLower().StartsWith("target"))
                                        {
                                            if (action.Equals("AllwaysHit"))
                                            {
                                                var foundtarget = FindTargetObject(obj);
                                                if (foundtarget != null)
                                                {
                                                    foundtarget.HasPopped = true;
                                                }
                                            }
                                        }

                                        if (obj.name.Equals("Handgun_M1911A (Model)"))
                                        {

                                            if (action == "AllwaysTrigger")
                                            {
                                                PopTarget();
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                ModConsole.Error("Error in AimFactory OnUdonSync");
                ModConsole.ErrorExc(e);
            }
        }
    }
}

