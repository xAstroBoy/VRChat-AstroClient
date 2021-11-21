namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using AstroClient.Tools.Colors;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using MelonLoader;
    using Roles;
    using System;
    using System.Collections;
    using System.Linq;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.Player;
    using AstroClient.Tools.UdonSearcher;
    using Constants;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static JarRoleController;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class AmongUS_ESP : AstroMonoBehaviour
    {
        private AmongUs_Roles _CurrentRole = AmongUs_Roles.Unassigned;

        private PlayerESP _ESP;
        private LinkedNodes _LinkedNode;
        private bool _ViewRoles;

        private List<Object> AntiGarbageCollection = new();

        public AmongUS_ESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal bool _AmongUSHasVoted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal bool HasVoted
        {
            [HideFromIl2Cpp]
            get => _AmongUSHasVoted;

            [HideFromIl2Cpp]
            set
            {
                if (AmongUSVoteRevealTag != null)
                {
                    if (ViewRoles)
                    {
                        if (CurrentRole == AmongUs_Roles.Crewmate || CurrentRole == AmongUs_Roles.Impostor) AmongUSVoteRevealTag.ShowTag = value;
                    }
                    else
                    {
                        AmongUSVoteRevealTag.ShowTag = false;
                    }
                }

                _AmongUSHasVoted = value;
            }
        }

        internal bool AmongUSCanVote
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentRole == AmongUs_Roles.Crewmate || CurrentRole == AmongUs_Roles.Impostor) return !HasVoted;
                return false;
            }
        }

        internal AmongUs_Roles CurrentRole
        {
            [HideFromIl2Cpp]
            get => _CurrentRole;
            [HideFromIl2Cpp]
            private set
            {
                _CurrentRole = value;
                UpdateAmongUSRole(value);
            }
        }

        internal Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }


        private APIUser _APIUser;
        internal APIUser APIUser
        {
            [HideFromIl2Cpp]
            get
            {
                if (_APIUser == null)
                {
                    return _APIUser = Player.GetAPIUser();
                }

                return _APIUser;
            }
        }
        internal bool IsSelf
        {
            [HideFromIl2Cpp]
            get
            { 
                return APIUser.IsSelf;
            }
        }

        private SingleTag _GameRoleTag;
        internal SingleTag GameRoleTag
        {
            [HideFromIl2Cpp]
            get
            {
                if (_GameRoleTag == null)
                {
                    return _GameRoleTag = Player.gameObject.AddComponent<SingleTag>();
                }

                return _GameRoleTag;
            }
        }
        private SingleTag _AmongUSVoteRevealTag;
        internal SingleTag AmongUSVoteRevealTag
        {
            [HideFromIl2Cpp]
            get
            {
                if (_AmongUSVoteRevealTag == null)
                {
                    return _AmongUSVoteRevealTag = Player.gameObject.AddComponent<SingleTag>();
                }

                return _AmongUSVoteRevealTag;
            }
        }

        internal string HiddenRole { [HideFromIl2Cpp] get; } = "Role Hidden";
        internal string NoRoles { [HideFromIl2Cpp] get; } = "No Role";
        internal string NotVotedYet { [HideFromIl2Cpp] get; } = "Has not voted Yet";
        internal string VotedAgainst { [HideFromIl2Cpp] get; } = "Voted: ";
        internal string SkippedVote { [HideFromIl2Cpp] get; } = "Skipped Vote";

        internal Color NotVotedYetColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.DarkGreen.ToUnityEngineColor();
        internal Color VotedAgainstCurrentPlayer { [HideFromIl2Cpp] get; } = System.Drawing.Color.Red.ToUnityEngineColor();
        internal Color VotedAgainstAnotherPlayer { [HideFromIl2Cpp] get; } = System.Drawing.Color.SeaGreen.ToUnityEngineColor();
        internal Color SkippedVoteColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.ForestGreen.ToUnityEngineColor();
        internal Color UnknownRole { [HideFromIl2Cpp] get; } = System.Drawing.Color.DeepSkyBlue.ToUnityEngineColor();
        internal Color ImpostorColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.Red.ToUnityEngineColor();
        internal Color CrewmateColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.DodgerBlue.ToUnityEngineColor();

        internal bool ViewRoles
        {
            [HideFromIl2Cpp]
            get => _ViewRoles;
            [HideFromIl2Cpp]
            private set
            {
                _ViewRoles = value;
                if (value)
                {
                    UpdateAmongUSRole(CurrentRole);
                }
            }
        }

        internal LinkedNodes LinkedNode
        {
            [HideFromIl2Cpp]
            get
            {
                if (_LinkedNode == null)
                {
                    var Internal_User_VRCPlayerAPI = Player.GetVRCPlayerApi();
                    foreach (var item in JarRoleLinks.Where(x => x.NodeReader.VRCPlayerAPI != null))
                        if (item != null)
                        {
                            var InternalNodeAssignedPlayer = item.NodeReader.VRCPlayerAPI;
                            if (Internal_User_VRCPlayerAPI != null && InternalNodeAssignedPlayer != null && Internal_User_VRCPlayerAPI.Equals(InternalNodeAssignedPlayer)) return _LinkedNode = item;
                        }
                }

                return _LinkedNode;
            }
        }

        private PlayerESP ESP
        {
            [HideFromIl2Cpp]
            get
            {
                if (IsSelf) return null;
                if (_ESP == null) return _ESP = Player.GetComponent<PlayerESP>();

                return _ESP;
            }
        }

        [HideFromIl2Cpp]
        internal Color? RoleToColor
        {
            [HideFromIl2Cpp]
            get
            {
                switch (CurrentRole)
                {
                    case AmongUs_Roles.Crewmate:
                        return CrewmateColor;

                    case AmongUs_Roles.Impostor:
                        return ImpostorColor;

                    case AmongUs_Roles.Unassigned:
                        return null;

                    case AmongUs_Roles.None:
                        return null;

                    default:
                        return null;
                }
            }
        }

        // Use this for initialization
        internal void Start()
        {
            var p = GetComponent<Player>();
            if (p != null)
                Player = p;
            else
                Destroy(this);

            if (GameRoleTag != null)
            {
                GameRoleTag.ShowTag = false;
            }
            if (AmongUSVoteRevealTag != null)
            {
                AmongUSVoteRevealTag.ShowTag = false;
            }


            HasVoted = false;
            if (ViewRoles)
            {
                if (GameRoleTag != null)
                {
                    GameRoleTag.Text = NoRoles;
                    GameRoleTag.BackGroundColor = UnknownRole;
                    GameRoleTag.ShowTag = false;
                }
            }
            else
            {
                if (GameRoleTag != null)
                {
                    GameRoleTag.Text = HiddenRole;
                    GameRoleTag.BackGroundColor = UnknownRole;
                    GameRoleTag.ShowTag = false;
                }
            }

            CurrentRole = AmongUs_Roles.Unassigned;
            ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Among US Role ESP.");
            MelonCoroutines.Start(FindEverything());
        }

        internal void OnDestroy()
        {
            if (GameRoleTag != null) Destroy(GameRoleTag);
            if (AmongUSVoteRevealTag != null) Destroy(AmongUSVoteRevealTag);
            AmongUS_ESPs.Remove(this);
        }

        [HideFromIl2Cpp]
        internal void SetRole(AmongUs_Roles NewRole)
        {
            if (LinkedNode.NodeReader.Node == null) return; // Discard and dont Execute anything if Node is null!
            switch (NewRole)
            {
                case AmongUs_Roles.Crewmate:
                    {
                        GetCrewmateEvent?.ExecuteUdonEvent();
                        break;
                    }
                case AmongUs_Roles.Impostor:
                    {
                        GetImpostorEvent?.ExecuteUdonEvent();
                        break;
                    }
                case AmongUs_Roles.None:
                    if (CurrentRole == AmongUs_Roles.Impostor || CurrentRole == AmongUs_Roles.Crewmate)
                    {
                        GetKillEvent?.ExecuteUdonEvent();
                    }

                    break;

                case AmongUs_Roles.Null:
                case AmongUs_Roles.Unassigned:
                    return;
                    break;
            }
        }

        private CustomLists.UdonBehaviour_Cached _GetCrewmateEvent;
        private CustomLists.UdonBehaviour_Cached GetCrewmateEvent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_GetCrewmateEvent == null)
                {
                    _GetCrewmateEvent = UdonSearch.FindUdonEvent(LinkedNode.Node.gameObject, "SyncAssignB");
                }

                return _GetCrewmateEvent;
            }
        }
        private CustomLists.UdonBehaviour_Cached _GetImpostorEvent;
        private CustomLists.UdonBehaviour_Cached GetImpostorEvent
        {
            [HideFromIl2Cpp]

            get
            {
                if (_GetImpostorEvent == null)
                {
                    _GetImpostorEvent = UdonSearch.FindUdonEvent(LinkedNode.Node.gameObject, "SyncAssignM");
                }

                return _GetImpostorEvent;
            }
        }

        private CustomLists.UdonBehaviour_Cached _GetKillEvent;
        private CustomLists.UdonBehaviour_Cached GetKillEvent
        {
            [HideFromIl2Cpp]

            get
            {
                if (_GetKillEvent == null)
                {
                    _GetKillEvent = UdonSearch.FindUdonEvent(LinkedNode.Node.gameObject, "SyncKill");
                }

                return _GetKillEvent;
            }
        }

        private IEnumerator FindEverything()
        {
            while (LinkedNode == null)
                yield return null;
            while (GetKillEvent == null)
                yield return null;
            while (GetCrewmateEvent == null)
                yield return null;
            while (GetImpostorEvent  == null)
                yield return null;

            ModConsole.DebugLog($"Found all the required Events and Node!");
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private static AmongUS_ESP TranslateSyncVotedFor(int value)
        {
            return AmongUS_ESPs.First(x => x.LinkedNode.Nodevalue == value);
        }

        private static int RemoveSyncVotedForText(string key)
        {
            var removedtext = key.ToLower().Replace("syncvotedfor", string.Empty).Replace(" ", string.Empty);
            _ = int.TryParse(removedtext, out var value);
            return value;
        }
        internal override void OnPlayerLeft(Player player)
        {
            if (player.Equals(this.Player))
            {
                Destroy(this);
            }
        }


        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (LinkedNode.Node == null) return;
                if (LinkedNode.Node.gameObject == null) return;
                if (sender == null) return;
                if (!action.IsNotNullOrEmptyOrWhiteSpace()) return;
                if (obj != null) // Node events (only on Assigned node)!
                    if (obj.Equals(LinkedNode.Node.gameObject))
                        switch (action)
                        {
                            case "SyncAssignB":
                                {
                                    CurrentRole = AmongUs_Roles.Crewmate;

                                    break;
                                }
                            case "SyncAssignM":
                                {
                                    CurrentRole = AmongUs_Roles.Impostor;

                                    break;
                                }
                            case "SyncKill":
                            case "SyncVotedOut":
                                {
                                    CurrentRole = AmongUs_Roles.None;
                                    HasVoted = false;
                                    break;
                                }
                            case "SyncAbstainedVoting":
                                {
                                    if (AmongUSVoteRevealTag != null)
                                    {
                                        AmongUSVoteRevealTag.Text = SkippedVote;
                                        AmongUSVoteRevealTag.BackGroundColor = SkippedVoteColor;
                                        AmongUSVoteRevealTag.ShowTag = true;
                                    }
                                    HasVoted = true;
                                    break;
                                }
                            case string a when a.Contains("SyncVotedFor"):
                                {
                                    var against = TranslateSyncVotedFor(RemoveSyncVotedForText(action));
                                    if (against != null)
                                    {
                                        if (AmongUSVoteRevealTag != null)
                                        {
                                            AmongUSVoteRevealTag.Text = VotedAgainst + against.Player.DisplayName();
                                            if (against.IsSelf)
                                            {
                                                AmongUSVoteRevealTag.BackGroundColor = VotedAgainstCurrentPlayer;
                                            }
                                            else
                                            {
                                                AmongUSVoteRevealTag.BackGroundColor = VotedAgainstAnotherPlayer;
                                            }

                                            AmongUSVoteRevealTag.ShowTag = true;
                                        }
                                        HasVoted = true;
                                    }

                                    HasVoted = true;
                                    break;
                                }
                        }

                switch (action)
                {
                    case "SyncEndVotingPhase":
                        {
                            if (AmongUSVoteRevealTag != null)
                            {
                                AmongUSVoteRevealTag.Text = NotVotedYet;
                                AmongUSVoteRevealTag.BackGroundColor = NotVotedYetColor;
                                AmongUSVoteRevealTag.ShowTag = false;
                            }
                            HasVoted = false;
                            break;
                        }
                    case "SyncAbort":
                    case "SyncVictoryB":
                    case "SyncVictoryM":
                    case "SyncStart":
                        {
                            if (GameRoleTag != null)
                            {
                                GameRoleTag.Text = NoRoles;
                                GameRoleTag.BackGroundColor = UnknownRole;
                                GameRoleTag.ShowTag = false;
                            }
                            if (AmongUSVoteRevealTag != null)
                            {
                                AmongUSVoteRevealTag.Text = NotVotedYet;
                                AmongUSVoteRevealTag.BackGroundColor = NotVotedYetColor;
                                AmongUSVoteRevealTag.ShowTag = false;
                            }
                            HasVoted = false;
                            CurrentRole = AmongUs_Roles.None;
                            break;
                        }
                }
            }
            catch 
            {
            }
        }

        private string GetCurrentSingleTagText()
        {
            return GameRoleTag.Text;
        }


        internal override void OnViewRolesPropertyChanged(bool value)
        {
            ViewRoles = value;
        }


        private void ResetESPColor()
        {
            if (ESP != null)
            {
                ESP.ResetColor();
            }
        }


        private void UpdateESP()
        {
            if (ESP != null)
            {
                ESP.UseCustomColor = ViewRoles;
                if (ESP.UseCustomColor)
                {
                    ESP.ChangeColor(RoleToColor.GetValueOrDefault(Player.FriendStateToColor()));
                }
            }
        }

 
        private void UpdateAmongUSRole(AmongUs_Roles role)
        {
            if (LinkedNode != null)
            {
                if (ESP != null) ESP.UseCustomColor = ViewRoles;
                if (ViewRoles)
                {
                    if (HasVoted && !AmongUSVoteRevealTag.ShowTag) AmongUSVoteRevealTag.ShowTag = true;

                    if (role != AmongUs_Roles.None && role != AmongUs_Roles.Unassigned)
                    {
                        if (GetCurrentSingleTagText() != role.ToString())

                            if (RoleToColor != null && RoleToColor.HasValue)
                            {
                                if (GameRoleTag != null)
                                {
                                    GameRoleTag.Text = role.ToString();
                                    GameRoleTag.BackGroundColor = RoleToColor.GetValueOrDefault();
                                    GameRoleTag.ShowTag = true;
                                }
                            }
                        UpdateESP();

                    }
                    else
                    {
                        if (GameRoleTag != null)
                        {
                            if (GameRoleTag.Text != NoRoles)
                            {
                                GameRoleTag.Text = NoRoles;
                                GameRoleTag.BackGroundColor = UnknownRole;
                                GameRoleTag.ShowTag = false;
                            }
                            ResetESPColor();
                        }

                        HasVoted = false;
                    }
                }
                else
                {
                        AmongUSVoteRevealTag.ShowTag = false;
                    if (GetCurrentSingleTagText() != HiddenRole)
                    {
                        if (GameRoleTag != null)
                        {
                            GameRoleTag.Text = HiddenRole;
                            GameRoleTag.BackGroundColor = UnknownRole;
                            GameRoleTag.ShowTag = false;
                        }
                        ResetESPColor();
                    }
                }
            }
        }
    }
}