namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using AstroClient.Tools.Colors;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using System;
    using System.Linq;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static JarRoleController;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class AmongUS_ESP : AstroMonoBehaviour
    {
        private AmongUs_Roles _AmongUsCurrentRole = AmongUs_Roles.Unassigned;

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

        internal bool AmongUSHasVoted
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
                        if (AmongUsCurrentRole == AmongUs_Roles.Crewmate || AmongUsCurrentRole == AmongUs_Roles.Impostor) AmongUSVoteRevealTag.ShowTag = value;
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
                if (AmongUsCurrentRole == AmongUs_Roles.Crewmate || AmongUsCurrentRole == AmongUs_Roles.Impostor) return !AmongUSHasVoted;
                return false;
            }
        }

        internal AmongUs_Roles AmongUsCurrentRole
        {
            [HideFromIl2Cpp]
            get => _AmongUsCurrentRole;
            [HideFromIl2Cpp]
            private set
            {
                _AmongUsCurrentRole = value;
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
                        if (value)
                            if (ESP != null)
                                UpdateAmongUSRole(AmongUsCurrentRole);
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
                            if (Internal_User_VRCPlayerAPI != null && InternalNodeAssignedPlayer != null && Internal_User_VRCPlayerAPI.Equals(InternalNodeAssignedPlayer))
                            {
                                ModConsole.DebugLog($"Found Assigned Linked Node in Player {InternalNodeAssignedPlayer.displayName}");
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

        // Use this for initialization
        internal void Start()
        {
            var p = GetComponent<Player>();
            if (p != null)
                Player = p;
            else
                Destroy(this);
            GameRoleTag = SingleTagsUtils.AddSingleTag(Player);
            if (IsAmongUsWorld)
            {
                AmongUSVoteRevealTag = SingleTagsUtils.AddSingleTag(Player);
                AmongUSVoteRevealTag.ShowTag = false;
                AmongUSHasVoted = false;
            }

            if (ViewRoles)
            {
                _ = SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                ResetESPColor();
                GameRoleTag.ShowTag = false;
            }
            else
            {
                _ = SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                ResetESPColor();
                GameRoleTag.ShowTag = false;
            }

            {
                AmongUsCurrentRole = AmongUs_Roles.Unassigned;
                ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Among US Role ESP.");
            }
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
            return AmongUS_ESPs.Where(x => x.LinkedNode.Nodevalue == value).First();
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
                if (LinkedNode == null) return;
                if (LinkedNode.Entry == null) return;
                if (LinkedNode.Node == null) return;
                if (LinkedNode.Node.gameObject == null) return;
                if (sender == null) return;
                if (obj != null)
                {
                    if (LinkedNode != null && LinkedNode.Node != null && obj.Equals(LinkedNode.Node.gameObject))
                    {
                        if (action == "SyncAssignB")
                        {
                            AmongUsCurrentRole = AmongUs_Roles.Crewmate;
                        }
                        else if (action == "SyncAssignM")
                        {
                            AmongUsCurrentRole = AmongUs_Roles.Impostor;
                        }
                        else if (action == "SyncKill")
                        {
                            AmongUsCurrentRole = AmongUs_Roles.None;
                            AmongUSHasVoted = false;
                        }
                        else if (action == "SyncVotedOut")
                        {
                            AmongUsCurrentRole = AmongUs_Roles.None;
                            AmongUSHasVoted = false;
                        }
                        else if (action.Contains("SyncVotedFor"))
                        {
                            var against = TranslateSyncVotedFor(RemoveSyncVotedForText(action));
                            if (against != null)
                            {
                                if (against != CurrentPlayer_Murder4ESP)
                                    SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#44DBAC"));
                                else
                                    SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#C22B26"));
                            }

                            AmongUSHasVoted = true;
                        }
                        else if (action.Equals("SyncAbstainedVoting"))
                        {
                            _ = SetTag(AmongUSVoteRevealTag, "Skipped Vote", Color.white, ColorUtils.HexToColor("#1BA039"));
                            AmongUSHasVoted = true;
                        }
                    }

                    if (action.Equals("SyncEndVotingPhase") || action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
                    {
                        AmongUSHasVoted = false;
                        if (AmongUSVoteRevealTag != null) _ = SetTag(AmongUSVoteRevealTag, "Has not voted Yet", Color.white, ColorUtils.HexToColor("#034989"));
                        if (action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
                        {
                            AmongUsCurrentRole = AmongUs_Roles.None;
                            AmongUSHasVoted = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private LinkedNodes GetEntryWithUser()
        {
            foreach (var item in JarRoleLinks.Where(x => x.NodeReader.VRCPlayerAPI != null))
                if (item != null)
                {
                    var Internal_User_VRCPlayerAPI = Player.GetVRCPlayerApi();
                    var InternalNodeAssignedPlayer = item.NodeReader.VRCPlayerAPI;
                    if (Internal_User_VRCPlayerAPI != null && InternalNodeAssignedPlayer != null && Internal_User_VRCPlayerAPI.Equals(InternalNodeAssignedPlayer))
                    {
                        ModConsole.DebugLog($"Found Assigned Linked Node in Player {InternalNodeAssignedPlayer.displayName}");
                        return item;
                    }
                }

            return null;
        }

        [HideFromIl2Cpp]
        internal Color? AmongUsGetNamePlateColor()
        {
            switch (AmongUsCurrentRole)
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

        private void ResetESPColor()
        {
            if (Player != null && ESP != null) ESP.ResetColor();
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
                            UpdateAmongUSRole(AmongUsCurrentRole);
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
                    if (AmongUSHasVoted && !AmongUSVoteRevealTag.ShowTag) AmongUSVoteRevealTag.ShowTag = true;

                    if (role != AmongUs_Roles.None && role != AmongUs_Roles.Unassigned)
                    {
                        if (GetCurrentSingleTagText() != role.ToString())
                        {
                            var color = AmongUsGetNamePlateColor();
                            if (color != null)
                            {
                                SetTag(GameRoleTag, role.ToString(), DefaultTextColor, color.Value);
                                SetEspColorIfExists(color.Value);
                            }
                        }
                    }
                    else
                    {
                        if (GetCurrentSingleTagText() != NoRoles)
                        {
                            SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                            ResetESPColor();
                            AmongUSHasVoted = false;
                        }
                    }
                }
                else
                {
                    if (AmongUSVoteRevealTag != null && AmongUSVoteRevealTag.ShowTag) AmongUSVoteRevealTag.ShowTag = false;

                    if (GetCurrentSingleTagText() != HiddenRole)
                    {
                        SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                        ResetESPColor();
                    }
                }
            }
        }

    }
}