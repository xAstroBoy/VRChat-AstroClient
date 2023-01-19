using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds.AmongUS;
using AstroClient.AstroMonos.Components.ESP;
using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS
{
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds.Roles;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Tools.Extensions;
    using Tools.Player.Movement.Exploit;
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
            // ClientEventActions.OnEnterWorld += EnterWorld;
        }

        //private void EnterWorld(ApiWorld world, ApiWorldInstance instance)
        //{
        //    if (world == null) return;
        //    if (world.id.Equals(WorldIds.AmongUS))
        //    {
        //        EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("BoundsContainsPoint");
        //        EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("Check");
        //        UnityDestroyBlock.MonitorDestroyingEvent = true;
        //        UnityDestroyBlock.ReportEvent = true;
        //    }
        //    else
        //    {
        //        UnityDestroyBlock.MonitorDestroyingEvent = false;
        //        UnityDestroyBlock.ReportEvent = false;
        //    }
        //}

        internal static bool _RoleSwapper_GetImpostorRole { get; set; }

        private static Vector3 SerializerPos { get; set; }
        private static Quaternion SerializerRot { get; set; }

        private static bool _BodyESps { get; set; }

        internal static QMSingleButton GameStartbtn { get; set; }
        internal static QMSingleButton GameAbortbtn { get; set; }
        internal static QMSingleButton GameVictoryCrewmateBtn { get; set; }
        internal static QMSingleButton GameVictoryImpostorBtn { get; set; }
        internal static QMToggleButton GameBodyESPBtn { get; set; }

        internal static QMToggleButton GetImpostorRoleBtn { get; set; }
        internal static QMToggleButton ToggleSerializerShortcut { get; set; }

        internal static QMNestedGridMenu AmongUsCheatsPage { get; set; }

        internal static bool HasAmongUsWorldLoaded { get; set; }

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
                        MovementSerializer.SerializerActivated = true;
                    }
                    else
                    {
                        GameInstances.CurrentUser.transform.position = SerializerPos;
                        GameInstances.CurrentUser.transform.rotation = SerializerRot;
                        SerializerRot = new Quaternion(0, 0, 0, 0);
                        SerializerPos = Vector3.zero;
                        MiscUtils.DelayFunction(0.5f, () =>
                        {
                            MovementSerializer.SerializerActivated = false;
                        });
                    }
                }
            }
        }

        internal static bool BodyESPs
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
            CancellationToken = null;
            RoleSwapper_GetImpostorRole = false;
            SerializerRot = new Quaternion(0, 0, 0, 0);
            SerializerPos = Vector3.zero;
            if (ToggleSerializerShortcut != null) ToggleSerializerShortcut.SetToggleState(false);

            BodyESPs = false;
            AmongUsUdonEvents.Cleanup();
            AmongUsWorldBtns.Cleanup();
            HasSubscribed = false;
        }

        internal static void FindAmongUsObjects()
        {
            var forcepatron = Finder.Find("Game Logic/Patreon Credits/");
            if (forcepatron != null)
            {
                forcepatron.GetOrAddComponent<AmongUS_PatronCreditsReader>();
            }
            Log.Write("Removing Anti-Peek Protection...");
            var occlusion = Finder.Find("Environment/skeld occ");
            if (occlusion != null) occlusion.DestroyMeLocal();
            Log.Write("Removing Invisible Walls");
            var invisiblewall = Finder.Find("Environment/Invisible wall");
            var invisiblewall_1 = Finder.Find("Environment/Invisible wall (1)");
            if (invisiblewall != null) invisiblewall.DestroyMeLocal();
            if (invisiblewall_1 != null) invisiblewall_1.DestroyMeLocal();
            AmongUsUdonEvents.SearchEvents();
            if (GameStartbtn != null)
            {
                var isValid = AmongUsUdonEvents.StartGameEvent.IsNotNull();
                GameStartbtn.SetActive(isValid);
                GameStartbtn.SetInteractable(isValid);
            }

            if (GameAbortbtn != null)
            {
                var isValid = AmongUsUdonEvents.AbortGameEvent.IsNotNull();
                GameAbortbtn.SetActive(isValid);
                GameAbortbtn.SetInteractable(isValid);
            }

            if (GameVictoryCrewmateBtn != null)
            {
                var isValid = AmongUsUdonEvents.VictoryCrewmateEvent.IsNotNull();
                GameVictoryCrewmateBtn.SetActive(isValid);
                GameVictoryCrewmateBtn.SetInteractable(isValid);
            }

            if (GameVictoryImpostorBtn != null)
            {
                var isValid = AmongUsUdonEvents.VictoryCrewmateEvent.IsNotNull();
                GameVictoryImpostorBtn.SetActive(isValid);
                GameVictoryImpostorBtn.SetInteractable(isValid);
            }
            AmongUsWorldBtns.SetupWorldButtons();
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

            GameStartbtn = new QMSingleButton(AmongUsCheatsPage, "Start Game", () => { AmongUsUdonEvents.StartGameEvent.InvokeBehaviour(); }, "Force Start Game Event", Color.green);
            GameAbortbtn = new QMSingleButton(AmongUsCheatsPage, "Abort Game", () => { AmongUsUdonEvents.AbortGameEvent.InvokeBehaviour(); }, "Force Abort Game Event", Color.green);

            GameVictoryCrewmateBtn = new QMSingleButton(AmongUsCheatsPage, "Victory Crewmate", () => { AmongUsUdonEvents.VictoryCrewmateEvent.InvokeBehaviour(); }, "Force Victory Crewmate Event", Color.green);
            GameVictoryImpostorBtn = new QMSingleButton(AmongUsCheatsPage, "Victory Impostor", () => { AmongUsUdonEvents.VictoryImpostorEvent.InvokeBehaviour(); }, "Force Victory Impostor Event", Color.red);
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