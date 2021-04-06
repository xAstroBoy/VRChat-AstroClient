using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using DayClientML2.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using static AstroClient.variables.CustomLists;

namespace AstroClient
{
    public class FreezeTag : Overridables
    {

        private static bool IsFreezeTag;

        private static bool AutomaticallyUnfreeze; // Hoping it works lol

        private static GameObject SelfNode;

        private static bool HasFoundAssignedNode;


        public override void OnLevelLoaded()
        {
            IsFreezeTag = false;
            SelfNode = null;
            AutomaticallyUnfreeze = true; // Hoping it works lol
            HasFoundAssignedNode = false;
            UnfreezeMeUdonEvent = null;

        }


        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.FreezeTag)
            {
                IsFreezeTag = true;

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
        }

        private static CachedUdonEvent UnfreezeMeUdonEvent;

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
                    ModConsole.Log($"Sender : {sender.DisplayName()}, obj {obj.name} , Action : {action} ");
                    if (SelfNode == null)
                    {
                        if (sender.DisplayName() == LocalPlayerUtils.GetSelfPlayer().DisplayName())
                        {

                            if (obj.name.ToLower().Contains("tagplayerctrl") && action.ToLower().Contains("seestuck")) ;
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
