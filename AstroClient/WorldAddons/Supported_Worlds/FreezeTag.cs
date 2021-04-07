using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using DayClientML2.Utility;
using DayClientML2.Utility.Extensions;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using static AstroClient.variables.CustomLists;

namespace AstroClient
{
    public class FreezeTag : Overridables
    {

        private static bool IsFreezeTag;

        private static bool _AutomaticallyUnfreeze;

        public static bool AutomaticallyUnfreeze
        {
            get
            {
                return _AutomaticallyUnfreeze;
            }
            set
            {

                _AutomaticallyUnfreeze = value;
                if(UnfreezeAutoMode != null)
                {
                    UnfreezeAutoMode.setToggleState(value);
                }

            }
        }

        private static GameObject SelfNode;

        private static bool HasFoundAssignedNode;

        public static QMNestedButton FreezeTagCheatsPage;

        public static QMToggleButton UnfreezeAutoMode;


        public static void InitButtons(QMNestedButton main, float x, float y, bool btnhalf)
        {
            FreezeTagCheatsPage = new QMNestedButton(main, x, y, "Freeze Tag", "Freeze Tag Cheats", null, null, null, null, true);
            UnfreezeAutoMode = new QMToggleButton(FreezeTagCheatsPage, 1, 0, "Auto Unfreeze ON", new Action(() => { AutomaticallyUnfreeze = true; }), "Auto Unfreeze OFF", new Action(() => { AutomaticallyUnfreeze = false; }), "Unfreezes you automatically", null, null, null);
            NodeControlSubmenu(FreezeTagCheatsPage, 2, 0, false);
        }



        public override void OnLevelLoaded()
        {
            IsFreezeTag = false;
            SelfNode = null;
            AutomaticallyUnfreeze = false; // Hoping it works lol
            HasFoundAssignedNode = false;
            UnfreezeMeUdonEvent = null;

        }


        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.FreezeTag)
            {
                IsFreezeTag = true;
                if (FreezeTagCheatsPage != null)
                {
                    FreezeTagCheatsPage.getMainButton().setIntractable(true);
                    FreezeTagCheatsPage.getMainButton().setTextColor(Color.green);
                }
                ModConsole.Log($"Recognized {name} World, removing anti-cheat mechanism!");
                var SpawnRoof = GameObjectFinder.Find("spawn/mainroom 2/ceiling");
                var Barriers = GameObjectFinder.Find("packmanmap/barriors");
                var OutsideMazePlane = GameObjectFinder.Find("packmanmap/Plane (4)");
                var InternalMazePlane = GameObjectFinder.Find("packmanmap/Plane (3)");
                var possiblenaticheatplane = GameObjectFinder.Find("packmanmap/Plane (2)");
                SpawnRoof.DestroyMeLocal();
                Barriers.DestroyMeLocal();
                OutsideMazePlane.DestroyMeLocal();
                InternalMazePlane.DestroyMeLocal();
                possiblenaticheatplane.DestroyMeLocal();

            }
            else
            {
                IsFreezeTag = false;
                if (FreezeTagCheatsPage != null)
                {
                    FreezeTagCheatsPage.getMainButton().setIntractable(false);
                    FreezeTagCheatsPage.getMainButton().setTextColor(Color.red);
                }
            }
        }

        private static CachedUdonEvent UnfreezeMeUdonEvent;
        private static CachedUdonEvent RefreezeMeUdonEvent;






        public static void NodeControlSubmenu(QMNestedButton main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Interact Node", "Interact with Node  Events", null, null, null, null, btnHalf);
            var scroll = new QMHalfScroll(menu);
            new QMSingleButton(menu, 0, -1, "Refresh", delegate
            {
                scroll.Refresh();
            }, "", null, null, true);
            scroll.SetAction(delegate
            {
                var udoneventholder = SelfNode.GetComponentInChildren<UdonBehaviour>(true);
                foreach (var subaction in udoneventholder._eventTable)
                {
                    scroll.Add(
                    new QMSingleButton(scroll.BaseMenu, 0, 0, $"{subaction.Key.ToString()}", delegate
                    {
                        udoneventholder.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                    }, $"Execute {subaction.Key}", null, null, true));
                }
            });
        }


        public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            if(IsFreezeTag)
            {
                if(action == "netping")
                {
                    return; // WTF THE SPAM WITH THIS SHIT ACTION WOT
                }
                try
                {
                    if (SelfNode == null)
                    {
                        if (sender.DisplayName() == LocalPlayerUtils.GetSelfPlayer().DisplayName())
                        {

                            if (obj.name.ToLower().Contains("tagplayerctrl") && action.ToLower().Contains("seestuck")) 
                            {
                                SelfNode = obj;
                                ModConsole.Log($"Found Self Assigned Node! {SelfNode.name}");
                                UnfreezeMeUdonEvent = UdonSearch.FindUdonEvent(SelfNode.name, "unfreezeme");
                                if (UnfreezeMeUdonEvent != null)
                                {
                                    ModConsole.Log("Found Self Unfreeze Event!");
                                }
                            }

                        }
                    }
                    if (AutomaticallyUnfreeze)
                    {
                        if (SelfNode != null)
                        {
                            if (obj.name.ToLower() == SelfNode.name.ToLower() && action.ToLower() == "freezeme")
                            {
                                MiscUtility.DelayFunction(0.01f, new Action(() =>
                                {



                                    if (UnfreezeMeUdonEvent != null)
                                    {
                                        UnfreezeMeUdonEvent.ExecuteUdonEvent();
                                        ModConsole.Log("Detected Freeze!, Unfreezing!", System.Drawing.Color.LawnGreen);
                                    }
                                    else
                                    {
                                        UnfreezeMeUdonEvent = UdonSearch.FindUdonEvent(SelfNode.name, "unfreezeme");
                                        UnfreezeMeUdonEvent.ExecuteUdonEvent();
                                        ModConsole.Log("Detected Freeze!, Unfreezing!", System.Drawing.Color.LawnGreen);

                                    }


                                }));



                            }
                        }

                    }
                }
                catch(Exception e)
                {
                    ModConsole.DebugErrorExc(e);
                }
            }
        }
    }
}
