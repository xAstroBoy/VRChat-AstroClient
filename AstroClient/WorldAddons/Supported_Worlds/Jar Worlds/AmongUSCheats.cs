namespace AstroClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.ESP.VRCInteractable;
    using AstroMonos.Components.Spoofer;
    using Features.Player.Movement.Exploit;
    using Udon.UdonEditor;
    using UdonExploits;
    using UnityEngine;
    using Variables;
    using VRC;
    using static Variables.CustomLists;

    internal class AmongUSCheats : GameEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
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
            SerializerRot = new Quaternion(0, 0, 0, 0);
            SerializerPos = Vector3.zero;
            if (ToggleSerializerShortcut != null)
            {
                ToggleSerializerShortcut.SetToggleState(false);
            }
            BodyOutlines.Clear();
            BodyESPs = false;
        }

        internal static void FindAmongUsObjects()
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

            foreach (var action in UdonParser.CleanedWorldBehaviours)
            {
                if (action.gameObject.name == "Game Logic")
                {
                    foreach (var subaction in action._eventTable)
                    {
                        if (subaction.key == "SyncStart")
                        {
                            StartGameEvent = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Start Game Event.");
                        }
                        if (subaction.key == "SyncAbort")
                        {
                            AbortGameEvent = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Abort Game Event.");
                        }
                        if (subaction.key == "SyncVictoryB")
                        {
                            VictoryCrewmateEvent = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Victory Crewmate Event.");
                        }
                        if (subaction.key == "SyncVictoryM")
                        {
                            VictoryImpostorEvent = new UdonBehaviour_Cached(action, subaction.key);
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
                GameStartbtn.SetActive(StartGameEvent.IsNotNull());
                GameStartbtn.SetIntractable(StartGameEvent.IsNotNull());
            }
            if (GameAbortbtn != null)
            {
                GameAbortbtn.SetActive(AbortGameEvent.IsNotNull());
                GameAbortbtn.SetIntractable(AbortGameEvent.IsNotNull());
            }
            if (GameVictoryCrewmateBtn != null)
            {
                GameVictoryCrewmateBtn.SetActive(VictoryCrewmateEvent.IsNotNull());
                GameVictoryCrewmateBtn.SetIntractable(VictoryCrewmateEvent.IsNotNull());
            }
            if (GameVictoryImpostorBtn != null)
            {
                GameVictoryImpostorBtn.SetActive(VictoryImpostorEvent.IsNotNull());
                GameVictoryImpostorBtn.SetIntractable(VictoryImpostorEvent.IsNotNull());
            }
            if (JarRoleController.JarRoleLinks.Count() != 0)
            {
                foreach (var item in JarRoleController.JarRoleLinks)
                {
                    var corpse = item.Node.FindObject("Corpse");
                    if (corpse != null)
                    {
                        if (!BodyOutlines.Contains(corpse))
                        {
                            BodyOutlines.Add(corpse);
                        }
                    }
                }
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.AmongUS)
            {
                HasAmongUsWorldLoaded = true;

                var patronCheckFool = UdonSearch.FindUdonEvent("Patreon Data", "_start");
                if(patronCheckFool != null)
                {
                    ModConsole.Log("Unlocking Patron Perks.");
                    if(!PlayerSpooferUtils.SpoofAsWorldAuthor)
                    {
                        PlayerSpooferUtils.SpoofAsWorldAuthor = true;
                        patronCheckFool.ExecuteUdonEvent();
                        PlayerSpooferUtils.SpoofAsWorldAuthor = false;
                    }
                    else
                    {
                        patronCheckFool.ExecuteUdonEvent();
                        
                    }
                }
                if (AmongUsCheatsPage != null)
                {
                    ModConsole.Log($"Recognized {Name} World, Unlocking Among US cheats menu!", System.Drawing.Color.Green);
                    AmongUsCheatsPage.GetMainButton().SetIntractable(true);
                    AmongUsCheatsPage.GetMainButton().SetTextColor(Color.green);
                }
                FindAmongUsObjects();
            }
            else
            {
                HasAmongUsWorldLoaded = false;
                if (AmongUsCheatsPage != null)
                {
                    AmongUsCheatsPage.GetMainButton().SetIntractable(false);
                    AmongUsCheatsPage.GetMainButton().SetTextColor(Color.red);
                }
            }
        }

        internal static void AmongUSCheatsButtons(QMTabMenu submenu, float BtnXLocation, float BtnYLocation, bool btnHalf)
        {
            AmongUsCheatsPage = new QMNestedButton(submenu, BtnXLocation, BtnYLocation, "Among US Cheats", "Manage Among US Cheats", null, null, null, null, btnHalf);
            JarRoleController.AmongUSRolesRevealerToggle = new QMSingleToggleButton(AmongUsCheatsPage, 1, 0, "Reveal Roles On", new Action(() => { JarRoleController.ViewRoles = true; }), "Reveals Roles Off", new Action(() => { JarRoleController.ViewRoles = false; }), "Reveals Current Players Roles In nameplates.", Color.green, Color.red, null, false, true);

            AmongUSUdonExploits.Init_GameController_Menu(AmongUsCheatsPage, 2, 0, true);

            AmongUSUdonExploits.Init_FilteredNodes_Menu(AmongUsCheatsPage, 2f, 0.5f, true);
            AmongUSUdonExploits.Init_Unfiltered_Nodes_Menu(AmongUsCheatsPage, 2f, 1f, true);

            AmongUSUdonExploits.Init_SabotageAndRepair_Menu(AmongUsCheatsPage, 3f, 0f, true);
            AmongUSUdonExploits.Init_KillPlayers_Menu(AmongUsCheatsPage, 3f, 0.5f, true);

            AmongUSUdonExploits.Init_ForceVotePlayer_menu(AmongUsCheatsPage, 4f, 0f, true);
            AmongUSUdonExploits.Init_ForcePlayerEject_Menu(AmongUsCheatsPage, 4f, 0.5f, true);

            AmongUSUdonExploits.Init_RoleSwap_Menu(AmongUsCheatsPage, 4f, 1f, true);
            GetImpostorRoleBtn = new QMSingleToggleButton(AmongUsCheatsPage, 4, 1.5f, "Get Impostor Role", new Action(() => { RoleSwapper_GetImpostorRole = true; }), "Get Impostor Role", new Action(() => { RoleSwapper_GetImpostorRole = false; }), "Assign Yourself Impostor Role on Next Round!", Color.green, Color.red, null, false, true);
            ToggleSerializerShortcut = new QMSingleToggleButton(AmongUsCheatsPage, 4, 2f, "Toggle Serializer", new Action(() => { AmongUsSerializer = true; }), "Toggle Serializer", new Action(() => { AmongUsSerializer = false; }), "Serialize For Stealth or to frame someone else!", Color.green, Color.red, null, false, true);
            GameBodyESPBtn = new QMSingleToggleButton(AmongUsCheatsPage, 4, 2.5f, "Body ESP", new Action(() => { BodyESPs = true; }), "Body ESP", new Action(() => { BodyESPs = false; }), "Makes Impostor Kills Visible (Yellow)!", Color.green, Color.red, null, false, true);

            GameStartbtn = new QMSingleButton(AmongUsCheatsPage, 1, 1, "Start Game", new Action(() => { StartGameEvent.ExecuteUdonEvent(); }), "Force Start Game Event", null, Color.green, true);
            GameAbortbtn = new QMSingleButton(AmongUsCheatsPage, 1, 1.5f, "Abort Game", new Action(() => { AbortGameEvent.ExecuteUdonEvent(); }), "Force Abort Game Event", null, Color.green, true);

            GameVictoryCrewmateBtn = new QMSingleButton(AmongUsCheatsPage, 1, 2, "Victory Crewmate", new Action(() => { VictoryCrewmateEvent.ExecuteUdonEvent(); }), "Force Victory Crewmate Event", null, Color.green, true);
            GameVictoryImpostorBtn = new QMSingleButton(AmongUsCheatsPage, 1, 2.5f, "Victory Impostor", new Action(() => { VictoryImpostorEvent.ExecuteUdonEvent(); }), "Force Victory Impostor Event", null, Color.red, true);
        }

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (HasAmongUsWorldLoaded)
                {
                    if (obj != null)
                    {
                        if (action.StartsWith("SyncAssign") && JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject != null)
                        {
                            if (RoleSwapper_GetImpostorRole)
                            {
                                if (!SafetySwap) // In case it grabs and update the current ones already!
                                {
                                    if (obj == JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject)
                                    {
                                        AssignedSelfRole = action;
                                    }

                                    if (action == "SyncAssignM")
                                    {
                                        TargetNode = obj;
                                        AssignedTargetRole = action;
                                    }

                                    RoleSwapper_GetImpostorRole = SwapRoles(JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject, TargetNode, AssignedSelfRole, AssignedTargetRole);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        internal static bool SwapRoles(GameObject SelfNode, GameObject TargetNode, string AssignedSelfRole, string AssignedTargetRole)
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

            MiscUtils.DelayFunction(0.01f, new Action(() =>
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

        internal static bool _RoleSwapper_GetImpostorRole;

        internal static bool RoleSwapper_GetImpostorRole
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
                    GetImpostorRoleBtn.SetToggleState(value);
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
                if (value)
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
                MovementSerializer.SerializerActivated = value;
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
                if (value)
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
                            MiscUtils.DelayFunction(0.4f, new Action(() => { ESP.ChangeColor(Color.yellow); }));
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
                if (GameBodyESPBtn != null)
                {
                    GameBodyESPBtn.SetToggleState(value);
                }
            }
        }

        internal static QMSingleButton GameStartbtn;
        internal static QMSingleButton GameAbortbtn;
        internal static QMSingleButton GameVictoryCrewmateBtn;
        internal static QMSingleButton GameVictoryImpostorBtn;
        internal static QMSingleToggleButton GameBodyESPBtn;

        internal static QMSingleToggleButton GetImpostorRoleBtn;
        internal static QMSingleToggleButton ToggleSerializerShortcut;

        internal static QMNestedButton AmongUsCheatsPage;

        internal static bool HasAmongUsWorldLoaded = false;

        internal static UdonBehaviour_Cached StartGameEvent;
        internal static UdonBehaviour_Cached AbortGameEvent;

        internal static UdonBehaviour_Cached VictoryCrewmateEvent;
        internal static UdonBehaviour_Cached VictoryImpostorEvent;
    }
}