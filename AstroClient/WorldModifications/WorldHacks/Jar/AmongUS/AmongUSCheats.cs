using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds.Roles;
    using AstroMonos.Components.ESP.VRCInteractable;
    using AstroMonos.Components.Spoofer;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.Player.Movement.Exploit;
    using Tools.UdonSearcher;
    using UdonCheats;
    using UnityEngine;
    using VRC;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class AmongUSCheats : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }


        internal static bool _RoleSwapper_GetImpostorRole;

        private static Vector3 SerializerPos;
        private static Quaternion SerializerRot;

        private static bool _BodyESps;

        internal static QMSingleButton GameStartbtn;
        internal static QMSingleButton GameAbortbtn;
        internal static QMSingleButton GameVictoryCrewmateBtn;
        internal static QMSingleButton GameVictoryImpostorBtn;
        internal static QMToggleButton GameBodyESPBtn;

        internal static QMToggleButton GetImpostorRoleBtn;
        internal static QMToggleButton ToggleSerializerShortcut;

        internal static QMNestedGridMenu AmongUsCheatsPage;

        internal static bool HasAmongUsWorldLoaded;

        internal static UdonBehaviour_Cached StartGameEvent;
        internal static UdonBehaviour_Cached AbortGameEvent;
        internal static UdonBehaviour_Cached EmergencyMeetingEvent;

        internal static UdonBehaviour_Cached VictoryCrewmateEvent;
        internal static UdonBehaviour_Cached VictoryImpostorEvent;

        internal static UdonBehaviour_Cached EmptyGarbage_Storage_A;
        internal static UdonBehaviour_Cached EmptyGarbage_Storage_B;

        internal static UdonBehaviour_Cached EmptyGarbage_Oxygen_A;

        internal static UdonBehaviour_Cached EmptyGarbage_Cafeteria_B;

        internal static UdonBehaviour_Cached CancelAllSabotages;
        internal static UdonBehaviour_Cached SabotageLights;

        internal static UdonBehaviour_Cached SubmitScanTask;

        internal static List<UdonBehaviour_Cached> SabotageAllDoors = new();
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

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnUdonSyncRPC += OnUdonSyncRPCEvent;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnUdonSyncRPC -= OnUdonSyncRPCEvent;

                    }
                }
                _HasSubscribed = value;
            }
        }

        internal static bool RoleSwapper_GetImpostorRole
        {
            get => _RoleSwapper_GetImpostorRole;
            set
            {
                if (value == _RoleSwapper_GetImpostorRole) return;
                _RoleSwapper_GetImpostorRole = value;
                if (GetImpostorRoleBtn != null) GetImpostorRoleBtn.SetToggleState(value);
            }
        }

        internal static bool AmongUsSerializer
        {
            get
            {
                return MovementSerializer.SerializerActivated;
            }
            set
            {
                if (MovementSerializer.SerializerActivated != value)
                {
                    if (value)
                    {
                        SerializerPos = GameInstances.CurrentUser.transform.position;
                        SerializerRot = GameInstances.CurrentUser.transform.rotation;
                    }
                    else
                    {
                        GameInstances.CurrentUser.transform.position = SerializerPos;
                        GameInstances.CurrentUser.transform.rotation = SerializerRot;

                        SerializerRot = new Quaternion(0, 0, 0, 0);
                        SerializerPos = Vector3.zero;
                    }
                    MovementSerializer.SerializerActivated = value;
                }
            }
        }

        private static bool BodyESPs
        {
            get => _BodyESps;
            set
            {
                if (value)
                    for (int i = 0; i < BodyOutlines.Count; i++)
                    {
                        var ESP = BodyOutlines[i].gameObject.GetOrAddComponent<ESP_VRCInteractable>();
                        if (ESP != null) MiscUtils.DelayFunction(0.4f, () => { ESP.ChangeColor(System.Drawing.Color.Orange.ToUnityEngineColor()); });
                    }
                else
                    for (int i = 0; i < BodyOutlines.Count; i++)
                    {
                        var ESP = BodyOutlines[i].gameObject.GetComponent<ESP_VRCInteractable>();
                        if (ESP != null) ESP.DestroyMeLocal();
                    }

                _BodyESps = value;
                if (GameBodyESPBtn != null) GameBodyESPBtn.SetToggleState(value);
            }
        }

        private static List<Transform> BodyOutlines
        {
            get
            {
                var result = new List<Transform>();
                if (JarRoleController.JarRoleLinks.Count() != 0)
                    for (int i = 0; i < JarRoleController.JarRoleLinks.Count; i++)
                    {
                        var corpse = JarRoleController.JarRoleLinks[i].Node.FindObject("Corpse");
                        if (corpse != null)
                            result.Add(corpse);
                    }

                return result;
            }
        }

        private void OnRoomLeft()
        {
            StartGameEvent = null;
            AbortGameEvent = null;
            VictoryCrewmateEvent = null;
            VictoryImpostorEvent = null;
            CancellationToken = null;
            RoleSwapper_GetImpostorRole = false;
            SerializerRot = new Quaternion(0, 0, 0, 0);
            SerializerPos = Vector3.zero;
            if (ToggleSerializerShortcut != null) ToggleSerializerShortcut.SetToggleState(false);
            EmptyGarbage_Storage_A = null;
            EmptyGarbage_Storage_B = null;

            EmptyGarbage_Oxygen_A = null;
            EmptyGarbage_Cafeteria_B = null;
            CancelAllSabotages = null;
            EmergencyMeetingEvent = null;
            BodyESPs = false;
            SabotageLights = null;
            SabotageAllDoors.Clear();
            SubmitScanTask = null;
            HasSubscribed = false;
        }

        internal static void FindAmongUsObjects()
        {
            Log.Write("Removing Anti-Peek Protection...");
            var occlusion = GameObjectFinder.Find("Environment/skeld occ");
            if (occlusion != null) occlusion.DestroyMeLocal();
            Log.Write("Removing Invisible Walls");
            var invisiblewall = GameObjectFinder.Find("Environment/Invisible wall");
            var invisiblewall_1 = GameObjectFinder.Find("Environment/Invisible wall (1)");
            if (invisiblewall != null) invisiblewall.DestroyMeLocal();
            if (invisiblewall_1 != null) invisiblewall_1.DestroyMeLocal();

            StartGameEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncStart");
            AbortGameEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncAbort");
            VictoryCrewmateEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncVictoryC");
            VictoryImpostorEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncVictoryI");
            EmergencyMeetingEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncEmergencyMeeting");
            CancelAllSabotages = UdonSearch.FindUdonEvent("Game Logic", "CancelAllSabotage");
            SabotageLights = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageLights");

            EmptyGarbage_Storage_A = UdonSearch.FindUdonEvent("Task Empty Garbage A (Storage)", "SyncConfirmAnimation");
            EmptyGarbage_Storage_B = UdonSearch.FindUdonEvent("Task Empty Garbage B (Storage)", "SyncConfirmAnimation");

            EmptyGarbage_Oxygen_A = UdonSearch.FindUdonEvent("Task Empty Garbage A (Oxygen)", "SyncConfirmAnimation");
            EmptyGarbage_Cafeteria_B = UdonSearch.FindUdonEvent("Task Empty Garbage B (Cafeteria)", "SyncConfirmAnimation");
            SubmitScanTask = UdonSearch.FindUdonEvent("Task Submit Scan", "SyncStartScan");

            var VictoryCrewMateKeys = VictoryCrewmateEvent.UdonBehaviour.Get_EventKeys();
            for (int i = 0; i < VictoryCrewMateKeys.Length; i++)
            {
                var subaction = VictoryCrewMateKeys[i];
                if (subaction.StartsWith("SyncDoSabotage"))
                {
                    if (subaction.Contains("Doors"))
                    {
                        var tmp = new UdonBehaviour_Cached(VictoryCrewmateEvent.UdonBehaviour, subaction);
                        if (!SabotageAllDoors.Contains(tmp))
                        {
                            SabotageAllDoors.Add(tmp);
                        }
                    }
                }
            }

            if (GameStartbtn != null)
            {
                GameStartbtn.SetActive(StartGameEvent.IsNotNull());
                GameStartbtn.SetInteractable(StartGameEvent.IsNotNull());
            }

            if (GameAbortbtn != null)
            {
                GameAbortbtn.SetActive(AbortGameEvent.IsNotNull());
                GameAbortbtn.SetInteractable(AbortGameEvent.IsNotNull());
            }

            if (GameVictoryCrewmateBtn != null)
            {
                GameVictoryCrewmateBtn.SetActive(VictoryCrewmateEvent.IsNotNull());
                GameVictoryCrewmateBtn.SetInteractable(VictoryCrewmateEvent.IsNotNull());
            }

            if (GameVictoryImpostorBtn != null)
            {
                GameVictoryImpostorBtn.SetActive(VictoryImpostorEvent.IsNotNull());
                GameVictoryImpostorBtn.SetInteractable(VictoryImpostorEvent.IsNotNull());
            }

        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.AmongUS)
            {
                HasAmongUsWorldLoaded = true;

                //var patronCheckFool = UdonSearch.FindUdonEvent("Patreon Data", "_start");
                //if (patronCheckFool != null)
                //{
                //    Log.Write("Unlocking Patron Perks.");
                //    if (!PlayerSpooferUtils.SpoofAsWorldAuthor)
                //    {
                //        PlayerSpooferUtils.SpoofAsWorldAuthor = true;
                //        patronCheckFool.InvokeBehaviour();
                //        PlayerSpooferUtils.SpoofAsWorldAuthor = false;
                //    }
                //    else
                //    {
                //        patronCheckFool.InvokeBehaviour();
                //    }
                //}

                if (AmongUsCheatsPage != null)
                {
                    Log.Write($"Recognized {Name} World, Unlocking Among US cheats menu!", System.Drawing.Color.Green);
                    AmongUsCheatsPage.GetMainButton().SetInteractable(true);
                    AmongUsCheatsPage.GetMainButton().SetTextColor(Color.green);
                }

                FindAmongUsObjects();
                HasSubscribed = true;
            }
            else
            {
                HasAmongUsWorldLoaded = false;
                if (AmongUsCheatsPage != null)
                {
                    AmongUsCheatsPage.GetMainButton().SetInteractable(false);
                    AmongUsCheatsPage.GetMainButton().SetTextColor(Color.red);
                }
                HasSubscribed = false;
            }
        }

        internal static void AmongUSCheatsButtons(QMGridTab submenu)
        {
            AmongUsCheatsPage = new QMNestedGridMenu(submenu, "Among US Cheats", "Manage Among US Cheats");
            JarRoleController.AmongUSRolesRevealerToggle = new QMToggleButton(AmongUsCheatsPage, "Reveal Roles On", () => { JarRoleController.ViewRoles = true; }, "Reveals Roles Off", () => { JarRoleController.ViewRoles = false; }, "Reveals Current Players Roles In nameplates.");

            AmongUS_GameLogic.InitButtons(AmongUsCheatsPage);

            AmongUS_FilteredNodes.InitButtons(AmongUsCheatsPage);
            AmongUS_UnfilteredNodes.InitButtons(AmongUsCheatsPage);

            AmongUS_SabotageAndRepair.InitButtons(AmongUsCheatsPage);
            AmongUS_KillPlayers.InitButtons(AmongUsCheatsPage);

            AmongUS_ForceVotePlayer.InitButtons(AmongUsCheatsPage);
            AmongUS_ForceEjectPlayer.InitButtons(AmongUsCheatsPage);

            AmongUS_RoleSwapper.InitButtons(AmongUsCheatsPage);

            GetImpostorRoleBtn = new QMToggleButton(AmongUsCheatsPage, "Get Impostor Role", () => { RoleSwapper_GetImpostorRole = true; }, "Get Impostor Role", () => { RoleSwapper_GetImpostorRole = false; }, "Assign Yourself Impostor Role on Next Round!");
            ToggleSerializerShortcut = new QMToggleButton(AmongUsCheatsPage, "Toggle Serializer", () => { AmongUsSerializer = true; }, "Toggle Serializer", () => { AmongUsSerializer = false; }, "Serialize For Stealth or to frame someone else!");
            GameBodyESPBtn = new QMToggleButton(AmongUsCheatsPage, "Body ESP", () => { BodyESPs = true; }, "Body ESP", () => { BodyESPs = false; }, "Makes Impostor Kills Visible (Yellow)!");

            GameStartbtn = new QMSingleButton(AmongUsCheatsPage, "Start Game", () => { StartGameEvent.InvokeBehaviour(); }, "Force Start Game Event", Color.green);
            GameAbortbtn = new QMSingleButton(AmongUsCheatsPage, "Abort Game", () => { AbortGameEvent.InvokeBehaviour(); }, "Force Abort Game Event", Color.green);

            GameVictoryCrewmateBtn = new QMSingleButton(AmongUsCheatsPage, "Victory Crewmate", () => { VictoryCrewmateEvent.InvokeBehaviour(); }, "Force Victory Crewmate Event", Color.green);
            GameVictoryImpostorBtn = new QMSingleButton(AmongUsCheatsPage, "Victory Impostor", () => { VictoryImpostorEvent.InvokeBehaviour(); }, "Force Victory Impostor Event", Color.red);
        }

        internal static AmongUS_ESP FindNodeWithRole(AmongUs_Roles role)
        {
            for (var index = 0; index < JarRoleController.AmongUS_ESPs.Count; index++)
            {
                var item = JarRoleController.AmongUS_ESPs[index];
                if (item != null)
                    if (item.CurrentRole == role)
                        return item;
            }

            return null;
        }

        private void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (HasAmongUsWorldLoaded)
                {
                    if (!RoleSwapper_GetImpostorRole) return;
                    if (action.StartsWith("SyncAssign"))
                    {
                        if (RoleSwapper_GetImpostorRole)
                        {
                            RoleSwapper_GetImpostorRole = false;
                            if (CancellationToken == null)
                            {
                                MelonCoroutines.Start(SwapRole(AmongUs_Roles.Impostor));
                            }
                        }
                    }

                    if (action.isMatch("SyncBodyFound") || action.isMatch("SyncEmergencyMeeting"))
                    {
                        AmongUsSerializer = false;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
        }
        private static object CancellationToken;
        private static IEnumerator SwapRole(AmongUs_Roles Selectedrole)
        {
            while (JarRoleController.CurrentPlayer_AmongUS_ESP.CurrentRole == AmongUs_Roles.None)
                yield return new WaitForEndOfFrame();
            while (FindNodeWithRole(Selectedrole) == null)
                yield return new WaitForEndOfFrame();
            Log.Debug("Initiating Swap!");
            var TargetNode = FindNodeWithRole(Selectedrole);
            if (TargetNode != null)
            {
                SwapRoles(TargetNode);
            }

            CancellationToken = null;
        }

        internal static void SwapRoles(AmongUS_ESP TargetESP)
        {
            var AssignedSelfRole = JarRoleController.CurrentPlayer_AmongUS_ESP.CurrentRole;
            var AssignedTargetRole = TargetESP.CurrentRole;
            if (JarRoleController.CurrentPlayer_AmongUS_ESP == TargetESP)
            {
                Log.Debug("Target Node and SelfNode are the same!");
                return;
            }

            if (AssignedTargetRole == AssignedSelfRole)
            {
                Log.Debug("Target Role  and Self Role  are the same!");
                return;
            }

            //MiscUtils.DelayFunction(0.1f, new Action(() =>
            //{
            //}));

            if (TargetESP != null) TargetESP.SetRole(AssignedSelfRole);
            if (JarRoleController.CurrentPlayer_AmongUS_ESP != null) JarRoleController.CurrentPlayer_AmongUS_ESP.SetRole(AssignedTargetRole);
            Log.Debug($"Executed Role Swapping!, {TargetESP.Player.DisplayName()} Has Role : {AssignedSelfRole}, You have {AssignedTargetRole}.");
        }

    }
}