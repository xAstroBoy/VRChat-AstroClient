namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using AstroClient.Tools.Colors;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using Roles;
    using System;
    using System.Collections;
    using System.Linq;
    using MelonLoader;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using xAstroBoy.AstroButtonAPI;
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
        private bool _isSelf;

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

        private bool HasChecked { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool IsSelf
        {
            [HideFromIl2Cpp]
            get
            {
                if (!HasChecked)
                {
                    _isSelf = Player.GetAPIUser().IsSelf;
                    HasChecked = true;
                }

                return _isSelf;
            }
        }

        internal SingleTag GameRoleTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal SingleTag AmongUSVoteRevealTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal string HiddenRole { [HideFromIl2Cpp] get; } = "Role Hidden";
        internal string NoRoles { [HideFromIl2Cpp] get; } = "No Role";
        internal Color NoRolesColor { [HideFromIl2Cpp] get; } = Color.yellow;
        internal Color HiddenRolesColor { [HideFromIl2Cpp] get; } = Color.green;
        internal Color DefaultTextColor { [HideFromIl2Cpp] get; } = Color.white;

        // AMONG US MAP
        internal Color ImpostorColor { [HideFromIl2Cpp] get; } = new(0.5377358f, 0.1648718f, 0.1728278f, 1f);

        internal Color CrewmateColor { [HideFromIl2Cpp] get; } = new(0f, 0.3228593f, 0.8396226f, 1f);

        internal bool ViewRoles
        {
            [HideFromIl2Cpp]
            get => _ViewRoles;
            [HideFromIl2Cpp]
            private set
            {
                _ViewRoles = value;
                if (LinkedNode != null)
                    if (GameRoleTag != null)
                    {
                        GameRoleTag.ShowTag = value;
                    }
                if (value)
                    if (ESP != null)
                        UpdateAmongUSRole(CurrentRole);

            }
        }
        private IEnumerator FindLinkedNode()
        {
            while (LinkedNode == null)
                yield return null;
            ModConsole.DebugLog($"Among US ESP , Found Linked Node to {Player.GetDisplayName()}");
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
                            if (Internal_User_VRCPlayerAPI != null && InternalNodeAssignedPlayer != null && Internal_User_VRCPlayerAPI.Equals(InternalNodeAssignedPlayer))
                            {
                                return _LinkedNode = item;
                            }
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

        private void ResetESP()
        {
            if (Player != null && ESP != null) ESP.ResetColor();
        }

        // Use this for initialization
        internal void Start()
        {
            var p = GetComponent<Player>();
            if (p != null)
                Player = p;
            else
                Destroy(this);
            GameRoleTag = SingleTagsUtils.AddSingleTag(Player);
            AmongUSVoteRevealTag = SingleTagsUtils.AddSingleTag(Player);
            AmongUSVoteRevealTag.ShowTag = false;
            HasVoted = false;

            if (ViewRoles)
            {
                _ = SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                ResetESP();
                GameRoleTag.ShowTag = false;
            }
            else
            {
                _ = SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                ResetESP();
                GameRoleTag.ShowTag = false;
            }

            CurrentRole = AmongUs_Roles.Unassigned;
            ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Among US Role ESP.");
            MelonCoroutines.Start(FindLinkedNode());
        }

        internal void OnDestroy()
        {
            if (GameRoleTag != null) Destroy(GameRoleTag);
            if (AmongUSVoteRevealTag != null) Destroy(AmongUSVoteRevealTag);
            AmongUS_ESPs.Remove(this);
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

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (LinkedNode.Node == null) return;
                if (LinkedNode.Node.gameObject == null) return;
                if (sender == null) return;
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
                                    _ = SetTag(AmongUSVoteRevealTag, "Skipped Vote", Color.white, ColorUtils.HexToColor("#1BA039"));
                                    HasVoted = true;
                                    break;
                                }
                            case string a when a.Contains("SyncVotedFor"):
                                {
                                    var against = TranslateSyncVotedFor(RemoveSyncVotedForText(action));
                                    if (against != null)
                                    {
                                        if (against != CurrentPlayer_AmongUS_ESP)
                                            SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#44DBAC"));
                                        else
                                            SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#C22B26"));
                                    }

                                    HasVoted = true;
                                    break;
                                }
                        }

                switch (action)
                {
                    case "SyncEndVotingPhase":
                        {
                            if (AmongUSVoteRevealTag != null) _ = SetTag(AmongUSVoteRevealTag, "Has not voted Yet", Color.white, ColorUtils.HexToColor("#034989"));
                            HasVoted = false;
                            break;
                        }
                    case "SyncAbort":
                    case "SyncVictoryB":
                    case "SyncVictoryM":
                    case "SyncStart":
                        {
                            if (AmongUSVoteRevealTag != null) _ = SetTag(AmongUSVoteRevealTag, "Has not voted Yet", Color.white, ColorUtils.HexToColor("#034989"));
                            HasVoted = false;
                            CurrentRole = AmongUs_Roles.None;
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private SingleTag SetTag(SingleTag tag, string text, Color TextColor, Color TagColor)
        {
            if (tag != null)
            {
                if (tag.Label_Text != text) tag.Label_Text = text;
                if (tag.Label_TextColor != TextColor) tag.Label_TextColor = TextColor;
                if (tag.Tag_Color != TagColor) tag.Tag_Color = TagColor;
                return tag;
            }

            tag = SingleTagsUtils.AddSingleTag(Player);
            return SetTag(tag, text, TextColor, TagColor);
        }

        private string GetCurrentSingleTagText()
        {
            return GameRoleTag.Label_Text;
        }

        private void SetEspColorIfExists(Color color)
        {
            if (Player != null && ESP != null && ESP.UseCustomColor) ESP.ChangeColor(color);
        }

        internal override void OnViewRolesPropertyChanged(bool value)
        {
            ViewRoles = value;
            if (LinkedNode != null)
                if (GameRoleTag != null)
                {
                    GameRoleTag.ShowTag = value;
                    if (value)
                        if (ESP != null)
                            UpdateAmongUSRole(CurrentRole);
                }
        }

        private void UpdateAmongUSRole(AmongUs_Roles role)
        {
            if (LinkedNode != null)
            {
                AmongUSVoteRevealTag ??= SingleTagsUtils.AddSingleTag(Player);
                if (ESP != null) ESP.UseCustomColor = ViewRoles;
                if (ViewRoles)
                {
                    if (HasVoted && !AmongUSVoteRevealTag.ShowTag) AmongUSVoteRevealTag.ShowTag = true;

                    if (role != AmongUs_Roles.None && role != AmongUs_Roles.Unassigned)
                    {
                        if (GetCurrentSingleTagText() != role.ToString())
                            if (RoleToColor != null && RoleToColor.HasValue)
                            {
                                SetTag(GameRoleTag, role.ToString(), DefaultTextColor, RoleToColor.GetValueOrDefault());
                                SetEspColorIfExists(RoleToColor.GetValueOrDefault());
                            }
                    }
                    else
                    {
                        if (GetCurrentSingleTagText() != NoRoles)
                        {
                            SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                            ResetESP();
                            HasVoted = false;
                        }
                    }
                }
                else
                {
                    if (AmongUSVoteRevealTag != null && AmongUSVoteRevealTag.ShowTag) AmongUSVoteRevealTag.ShowTag = false;

                    if (GetCurrentSingleTagText() != HiddenRole)
                    {
                        SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                        ResetESP();
                    }
                }
            }
        }
    }
}