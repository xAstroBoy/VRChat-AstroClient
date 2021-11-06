using UnhollowerBaseLib.Attributes;

namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Linq;
    using UnityEngine;
    using VRC;
    using static AstroClient.JarRoleController;

    [RegisterComponent]
    public class JarRoleESP : JarControllerEvents
    {
        //-----------------------------------------------------------
        //Could separate the murder 4 and among us role esps into 2 seperate classes
        //-----------------------------------------------------------








        public JarRoleESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            var p = GetComponent<Player>();
            if (p != null)
            {
                Player = p;
            }
            else
            {
                Destroy(this);
            }
            IsRPCActive = false;
            if (ESP == null && !IsSelf)
            {
                ESP = Player.gameObject.GetComponent<PlayerESP>();
            }
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
            if (IsMurder4World)
            {
                Murder4CurrentRole = Murder4Roles.Unassigned;
                ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Murder 4 Role ESP.");
            }
            if (IsAmongUsWorld)
            {
                AmongUsCurrentRole = AmongUsRoles.Unassigned;
                ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Among US Role ESP.");
            }
        }

        private static JarRoleESP TranslateSyncVotedFor(int value)
        {
            return RoleEspComponents.Where(x => x.LinkedNode.Nodevalue == value).First();
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
                if (obj != null)
                {
                    if (IsAmongUsWorld)
                    {
                        if (LinkedNode != null && LinkedNode.Node != null && obj.Equals(LinkedNode.Node.gameObject))
                        {
                            if (action == "SyncAssignB")
                            {
                                AmongUsCurrentRole = AmongUsRoles.Crewmate;
                                if (!IsRPCActive) IsRPCActive = true;
                            }
                            else if (action == "SyncAssignM")
                            {
                                AmongUsCurrentRole = AmongUsRoles.Impostor;
                                if (!IsRPCActive) IsRPCActive = true;
                            }
                            else if (action == "SyncKill")
                            {
                                AmongUsCurrentRole = AmongUsRoles.None;
                                AmongUSHasVoted = false;
                                if (!IsRPCActive) IsRPCActive = true;
                            }
                            else if (action == "SyncVotedOut")
                            {
                                AmongUsCurrentRole = AmongUsRoles.None;
                                AmongUSHasVoted = false;
                                if (!IsRPCActive) IsRPCActive = true;
                            }
                            else if (action.Contains("SyncVotedFor"))
                            {
                                var against = TranslateSyncVotedFor(RemoveSyncVotedForText(action));
                                if (against != null)
                                {
                                    if (against != CurrentPlayerRoleESP)
                                    {
                                        SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#44DBAC"));
                                    }
                                    else
                                    {
                                        SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#C22B26"));
                                    }
                                }
                                AmongUSHasVoted = true;
                                if (!IsRPCActive) IsRPCActive = true;
                            }
                            else if (action.Equals("SyncAbstainedVoting"))
                            {
                                _ = SetTag(AmongUSVoteRevealTag, $"Skipped Vote", Color.white, ColorUtils.HexToColor("#1BA039"));
                                AmongUSHasVoted = true;
                                if (!IsRPCActive) IsRPCActive = true;
                            }
                        }

                        if (action.Equals("SyncEndVotingPhase") || action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
                        {
                            AmongUSHasVoted = false;
                            if (AmongUSVoteRevealTag != null)
                            {
                                _ = SetTag(AmongUSVoteRevealTag, $"Has not voted Yet", Color.white, ColorUtils.HexToColor("#034989"));
                            }
                            if (action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
                            {
                                AmongUsCurrentRole = AmongUsRoles.None;
                                AmongUSHasVoted = false;
                            }
                            if (!IsRPCActive) IsRPCActive = true;
                        }
                    }
                    else if (IsMurder4World)
                    {
                        if (LinkedNode != null && LinkedNode.Node != null)
                        {
                            if (obj.Equals(LinkedNode.Node.gameObject))
                            {
                                if (action == "SyncAssignB")
                                {
                                    Murder4CurrentRole = Murder4Roles.Bystander;
                                    if (!IsRPCActive) IsRPCActive = true;
                                }
                                else if (action == "SyncAssignD")
                                {
                                    Murder4CurrentRole = Murder4Roles.Detective;
                                    if (!IsRPCActive) IsRPCActive = true;
                                }
                                else if (action == "SyncAssignM")
                                {
                                    Murder4CurrentRole = Murder4Roles.Murderer;
                                    if (!IsRPCActive) IsRPCActive = true;
                                }
                                else if (action == "SyncKill")
                                {
                                    Murder4CurrentRole = Murder4Roles.None;
                                    if (!IsRPCActive) IsRPCActive = true;
                                }
                            }

                            if (action == "SyncVictoryB" || action == "SyncVictoryM" || action == "SyncAbort" || action.Equals("SyncStart"))
                            {
                                Murder4CurrentRole = Murder4Roles.None;
                                if (!IsRPCActive) IsRPCActive = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private LinkedNodes GetEntryWithUser()
        {
            foreach (var item in JarRoleController.JarRoleLinks.Where(x => x.NodeReader.VRCPlayerAPI != null))
            {
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
            }
            return null;
        }
        [HideFromIl2Cpp]
        internal Color? Murder4GetNamePlateColor()
        {
            switch (Murder4CurrentRole)
            {
                case Murder4Roles.Detective:
                    return DetectiveColor;

                case Murder4Roles.Murderer:
                    return MurderColor;

                case Murder4Roles.Bystander:
                    return BystanderColor;

                case Murder4Roles.Unassigned:
                    return null;

                case Murder4Roles.None:
                    return null;

                default:
                    return null;
            }
        }
        [HideFromIl2Cpp]

        internal Color? AmongUsGetNamePlateColor()
        {
            switch (AmongUsCurrentRole)
            {
                case AmongUsRoles.Crewmate:
                    return CrewmateColor;

                case AmongUsRoles.Impostor:
                    return ImpostorColor;

                case AmongUsRoles.Unassigned:
                    return null;

                case AmongUsRoles.None:
                    return null;

                default:
                    return null;
            }
        }

        private SingleTag SetTag(SingleTag tag, string text, Color TextColor, Color TagColor)
        {
            if (tag != null)
            {
                if (tag.Label_Text != text)
                {
                    tag.Label_Text = text;
                }
                if (tag.Label_TextColor != TextColor)
                {
                    tag.Label_TextColor = TextColor;
                }
                if (tag.Tag_Color != TagColor)
                {
                    tag.Tag_Color = TagColor;
                }
                return tag;
            }
            else
            {
                tag = SingleTagsUtils.AddSingleTag(Player);
                return SetTag(tag, text, TextColor, TagColor);
            }
        }

        internal void OnDestroy()
        {
            if (GameRoleTag != null)
            {
                Destroy(GameRoleTag);
            }
            if (AmongUSVoteRevealTag != null)
            {
                Destroy(AmongUSVoteRevealTag);
            }
            RoleEspComponents.Remove(this);
        }

        private string GetCurrentSingleTagText()
        {
            return GameRoleTag.Label_Text;
        }

        private void SetEspColorIfExists(Color color)
        {
            if (Player != null && ESP != null && ESP.UseCustomColor)
            {
                ESP.ChangeColor(color);
            }
        }

        private void ResetESPColor()
        {
            if (Player != null && ESP != null) ESP.ResetColor();
        }

        private void Update()
        {
            try
            {
                if (LinkedNode == null) LinkedNode = GetEntryWithUser();
            }
            catch (Exception e) { ModConsole.DebugError("JarRoleRevealer OnUpdate Exception : " + e); }
        }

        internal override void OnViewRolesPropertyChanged(bool value)
        {
            ViewRoles = value;
            if (LinkedNode != null)
            {
                if (GameRoleTag != null)
                {
                    GameRoleTag.ShowTag = value;
                    if (value)
                    {
                        if (ESP != null)
                        {
                            if (IsAmongUsWorld) UpdateAmongUSRole(AmongUsCurrentRole);
                            else if (IsMurder4World) UpdateMurder4Role(Murder4CurrentRole);
                        }
                    }
                }
            }
        }

        internal override void OnPlayerESPPropertyChanged(bool value)
        {
            if (value)
            {
                if (!IsSelf)
                {
                    ESP ??= Player.gameObject.GetComponent<PlayerESP>();
                }
            }
        }

        private void UpdateMurder4Role(Murder4Roles role)
        {
            if (LinkedNode != null)
            {
                if (ESP != null)
                {
                    if (ESP.UseCustomColor != ViewRoles) ESP.UseCustomColor = ViewRoles;
                }
                if (ViewRoles)
                {
                    if (role != Murder4Roles.None && role != Murder4Roles.Unassigned)
                    {
                        if (GetCurrentSingleTagText() != role.ToString())
                        {
                            var color = Murder4GetNamePlateColor();
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
                        }
                    }
                }
                else
                {
                    if (GetCurrentSingleTagText() != HiddenRole)
                    {
                        SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                        ResetESPColor();
                    }
                }
            }
        }

        private void UpdateAmongUSRole(AmongUsRoles role)
        {
            if (LinkedNode != null)
            {
                AmongUSVoteRevealTag ??= SingleTagsUtils.AddSingleTag(Player);
                if (ESP != null && ESP.UseCustomColor != ViewRoles) ESP.UseCustomColor = ViewRoles;
                if (ViewRoles)
                {
                    if (AmongUSHasVoted && !AmongUSVoteRevealTag.ShowTag) AmongUSVoteRevealTag.ShowTag = true;

                    if (role != AmongUsRoles.None && role != AmongUsRoles.Unassigned)
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

        internal enum Murder4Roles
        {
            None = 0,
            Detective = 1,
            Murderer = 2,
            Bystander = 3,
            Unassigned = 4,
            Null = 5,
        }

        internal enum AmongUsRoles
        {
            None = 0,
            Crewmate = 1,
            Impostor = 2,
            Unassigned = 3,
            Null = 4,
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
                        if (AmongUsCurrentRole == AmongUsRoles.Crewmate || AmongUsCurrentRole == AmongUsRoles.Impostor)
                        {
                            AmongUSVoteRevealTag.ShowTag = value;
                        }
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
                if (AmongUsCurrentRole == AmongUsRoles.Crewmate || AmongUsCurrentRole == AmongUsRoles.Impostor) return !AmongUSHasVoted;
                return false;
            }
        }

        internal bool IsRPCActive { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private AmongUsRoles _AmongUsCurrentRole = AmongUsRoles.Unassigned;
        internal AmongUsRoles AmongUsCurrentRole
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

        private Murder4Roles _Murder4CurrentRole = Murder4Roles.Unassigned;
        internal Murder4Roles Murder4CurrentRole
        {
            [HideFromIl2Cpp]
            get => _Murder4CurrentRole;
            [HideFromIl2Cpp]
            private set
            {
                _Murder4CurrentRole = value;
                UpdateMurder4Role(value);
            }
        }

        internal Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private PlayerESP _ESP;
        internal PlayerESP ESP
        {
            [HideFromIl2Cpp]
            get => _ESP;
            [HideFromIl2Cpp]
            private set => _ESP = value;
        }

        internal bool IsSelf
        {
            [HideFromIl2Cpp]
            get => Player.GetAPIUser().IsSelf;
        }

        internal bool ViewRoles { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal SingleTag GameRoleTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal SingleTag AmongUSVoteRevealTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal LinkedNodes LinkedNode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal string HiddenRole { [HideFromIl2Cpp] get; } = "Role Hidden";
        internal string NoRoles { [HideFromIl2Cpp] get; } = "No Role";
        internal Color NoRolesColor { [HideFromIl2Cpp] get; } = Color.yellow;
        internal Color HiddenRolesColor { [HideFromIl2Cpp] get; } = Color.green;
        internal Color DefaultTextColor { [HideFromIl2Cpp] get; } = Color.white;

        // MURDER 4 MAP
        internal Color MurderColor { [HideFromIl2Cpp] get; } = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);
        internal Color BystanderColor { [HideFromIl2Cpp] get; } = new Color(0.3428266f, 0.5883213f, 0.6792453f, 1f);
        internal Color DetectiveColor { [HideFromIl2Cpp] get; } = new Color(0.2976544f, 0.251424f, 0.4716981f, 1f);

        // AMONG US MAP
        internal Color ImpostorColor { [HideFromIl2Cpp] get; } = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);
        internal Color CrewmateColor { [HideFromIl2Cpp] get; } = new Color(0f, 0.3228593f, 0.8396226f, 1f);

        // GENERAL
        internal Color Unassigned { [HideFromIl2Cpp] get; } = new Color(0.5f, 0.5f, 0.5f, 1f);
        internal Color NoRolesAssigned { [HideFromIl2Cpp] get; } = new Color(0f, 0f, 0f, 0f);
    }
}