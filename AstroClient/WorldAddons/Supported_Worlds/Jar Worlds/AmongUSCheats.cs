﻿using RubyButtonAPI;
using System;
using UnityEngine;

#region AstroClient Imports

using AstroClient.Finder;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.UdonExploits;
using AstroClient.Variables;
using VRC.Udon;
using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports

namespace AstroClient
{
    public class AmongUSCheats : Overridables
    {
        public override void OnLevelLoaded()
        {
            StartGameEvent = null;
            AbortGameEvent = null;
            VictoryCrewmateEvent = null;
            VictoryImpostorEvent = null;
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

        public static void AmongUSCheatsButtons(QMNestedButton submenu, float BtnXLocation, float BtnYLocation, bool btnHalf)
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

            GameStartbtn = new QMSingleButton(AmongUsCheatsPage, 1, 1, "Start Game", new Action(() => { StartGameEvent.ExecuteUdonEvent(); }), "Force Start Game Event", null, Color.green, true);
            GameAbortbtn = new QMSingleButton(AmongUsCheatsPage, 1, 1.5f, "Abort Game", new Action(() => { AbortGameEvent.ExecuteUdonEvent(); }), "Force Abort Game Event", null, Color.green, true);

            GameVictoryCrewmateBtn = new QMSingleButton(AmongUsCheatsPage, 1, 2, "Victory Crewmate", new Action(() => { VictoryCrewmateEvent.ExecuteUdonEvent(); }), "Force Victory Crewmate Event", null, Color.green, true);
            GameVictoryImpostorBtn = new QMSingleButton(AmongUsCheatsPage, 1, 2.5f, "Victory Impostor", new Action(() => { VictoryImpostorEvent.ExecuteUdonEvent(); }), "Force Victory Impostor Event", null, Color.red, true);
        }

        public static QMSingleButton GameStartbtn;
        public static QMSingleButton GameAbortbtn;
        public static QMSingleButton GameVictoryCrewmateBtn;
        public static QMSingleButton GameVictoryImpostorBtn;

        public static QMNestedButton AmongUsCheatsPage;

        public static bool HasAmongUsWorldLoaded = false;

        public static CachedUdonEvent StartGameEvent;
        public static CachedUdonEvent AbortGameEvent;

        public static CachedUdonEvent VictoryCrewmateEvent;
        public static CachedUdonEvent VictoryImpostorEvent;
    }
}