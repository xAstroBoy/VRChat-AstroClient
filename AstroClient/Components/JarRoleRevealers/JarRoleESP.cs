namespace AstroClient.Components
{
    using AstroClient.Startup.Buttons;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC;
    using static AstroClient.JarRoleController;

    public class JarRoleESP : GameEventsBehaviour
    {
        public JarRoleESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        public void Start()
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
            if (ESP == null)
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
                SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                ResetESPColor();
                GameRoleTag.ShowTag = false;
            }
            else
            {
                SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
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
            int.TryParse(removedtext, out var value);
            return value;
        }

        public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (obj != null)
                {
                    if (IsAmongUsWorld)
                    {
                        if (LinkedNode != null && LinkedNode.Node != null)
                        {
                            if (obj.Equals(LinkedNode.Node))
                            {
                                if (action == "SyncAssignB")
                                {
                                    AmongUsCurrentRole = AmongUsRoles.Crewmate;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action == "SyncAssignM")
                                {
                                    AmongUsCurrentRole = AmongUsRoles.Impostor;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action == "SyncKill")
                                {
                                    AmongUsCurrentRole = AmongUsRoles.None;
                                    AmongUSHasVoted = false;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action == "SyncVotedOut")
                                {
                                    AmongUsCurrentRole = AmongUsRoles.None;
                                    AmongUSHasVoted = false;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action.Contains("SyncVotedFor"))
                                {
                                    var against = TranslateSyncVotedFor(RemoveSyncVotedForText(action));
                                    if (against != null)
                                    {
                                        if (against != GetLocalPlayerNode())
                                        {
                                            SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#44DBAC"));
                                        }
                                        else
                                        {
                                            SetTag(AmongUSVoteRevealTag, $"Voted: {against.Player.DisplayName()}", Color.white, ColorUtils.HexToColor("#C22B26"));
                                        }
                                    }
                                    AmongUSHasVoted = true;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action.Equals("SyncAbstainedVoting"))
                                {
                                    AmongUSHasVoted = true;
                                    SetTag(AmongUSVoteRevealTag, $"Skipped Vote", Color.white, ColorUtils.HexToColor("#1BA039"));
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                            }
                        }

                        if (action.Equals("SyncEndVotingPhase") || action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
                        {
                            AmongUSHasVoted = false;
                            if (AmongUSVoteRevealTag != null)
                            {
                                SetTag(AmongUSVoteRevealTag, $"Has not voted Yet", Color.white, ColorUtils.HexToColor("#034989"));
                            }
                            if (action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
                            {
                                AmongUsCurrentRole = AmongUsRoles.None;
                                AmongUSHasVoted = false;
                            }
                            if (!IsRPCActive)
                            {
                                IsRPCActive = true;
                            }
                        }
                    }
                    else if (IsMurder4World)
                    {
                        if (LinkedNode != null && LinkedNode.Node != null)
                        {
                            if (obj.Equals(LinkedNode.Node))
                            {
                                if (action == "SyncAssignB")
                                {
                                    Murder4CurrentRole = Murder4Roles.Bystander;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action == "SyncAssignD")
                                {
                                    Murder4CurrentRole = Murder4Roles.Detective;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action == "SyncAssignM")
                                {
                                    Murder4CurrentRole = Murder4Roles.Murderer;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                                else if (action == "SyncKill")
                                {
                                    Murder4CurrentRole = Murder4Roles.None;
                                    if (!IsRPCActive)
                                    {
                                        IsRPCActive = true;
                                    }
                                }
                            }

                            if (action == "SyncVictoryB" || action == "SyncVictoryM" || action == "SyncAbort" || action.Equals("SyncStart"))
                            {
                                Murder4CurrentRole = Murder4Roles.None;
                                if (!IsRPCActive)
                                {
                                    IsRPCActive = true;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private AmongUsRoles CheckEntryAmongUS(GameObject Entry)
        {
            if (Entry != null)
            {
                var Color = GetPlayerEntryColor(Entry);
                if (Entry.active)
                {
                    if (Color == NoRolesAssigned)
                    {
                        return AmongUsRoles.None;
                    }
                    else if (Color == CrewmateColor)
                    {
                        return AmongUsRoles.Crewmate;
                    }
                    else if (Color == ImpostorColor)
                    {
                        return AmongUsRoles.Impostor;
                    }
                    else if (Color == Unassigned)
                    {
                        return AmongUsRoles.Unassigned;
                    }
                    else
                    {
                        ModConsole.Warning("Unknown Color Detected!");
                        ModConsole.Warning(Player.DisplayName() + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
                        return AmongUsRoles.None;
                    }
                }
                else
                {
                    return AmongUsRoles.Unassigned;
                }
            }
            return AmongUsRoles.Unassigned;
        }

        private AmongUsRoles GetPlayerRoleAmongUS()
        {
            if (IsRPCActive)
            {
                return AmongUsCurrentRole;
            }
            if (LinkedNode.NodeReader != null)
            {
                return CheckEntryAmongUS(LinkedNode.Entry.gameObject);
            }
            return AmongUsRoles.Null;
        }

        private Murder4Roles GetPlayerRoleMurder4()
        {
            if (IsRPCActive)
            {
                return Murder4CurrentRole;
            }
            if (LinkedNode.NodeReader != null)
            {
                return CheckEntryMurder4(LinkedNode.Entry.gameObject);
            }
            return Murder4Roles.Null;
        }

        private LinkedNodes GetEntryWithUser()
        {
            foreach (var item in JarRoleController.JarRoleLinks.Where(x => x.NodeReader.VRCPlayeAPI != null))
            {
                if (item != null)
                {
                    var Internal_User_VRCPlayerAPI = Player.GetVRCPlayerApi();
                    var InternalNodeAssignedPlayer = item.NodeReader.VRCPlayeAPI;
                    if (Internal_User_VRCPlayerAPI != null && InternalNodeAssignedPlayer != null)
                    {
                        if (Internal_User_VRCPlayerAPI.Equals(InternalNodeAssignedPlayer))
                        {
                            ModConsole.DebugLog($"Found Assigned Linked Node in Player {InternalNodeAssignedPlayer.displayName}");
                            return item;
                        }
                    }
                }
            }
            return null;
        }

        public Color? Murder4GetNamePlateColor()
        {
            if (Murder4CurrentRole == Murder4Roles.Detective)
            {
                return DetectiveColor;
            }
            if (Murder4CurrentRole == Murder4Roles.Murderer)
            {
                return MurderColor;
            }
            if (Murder4CurrentRole == Murder4Roles.Bystander)
            {
                return BystanderColor;
            }
            if (Murder4CurrentRole == Murder4Roles.Unassigned)
            {
                return null;
            }
            if (Murder4CurrentRole == Murder4Roles.None)
            {
                return null;
            }
            return null;
        }

        public Color? AmongUsGetNamePlateColor()
        {
            if (AmongUsCurrentRole == AmongUsRoles.Crewmate)
            {
                return CrewmateColor;
            }
            if (AmongUsCurrentRole == AmongUsRoles.Impostor)
            {
                return ImpostorColor;
            }
            if (AmongUsCurrentRole == AmongUsRoles.Unassigned)
            {
                return null;
            }
            if (AmongUsCurrentRole == AmongUsRoles.None)
            {
                return null;
            }
            return null;
        }

        private Murder4Roles CheckEntryMurder4(GameObject Entry)
        {
            if (Entry != null)
            {
                var Color = GetPlayerEntryColor(Entry);
                if (Entry.active)
                {
                    if (Color == NoRolesAssigned)
                    {
                        return Murder4Roles.None;
                    }
                    else if (Color == BystanderColor)
                    {
                        return Murder4Roles.Bystander;
                    }
                    else if (Color == DetectiveColor)
                    {
                        return Murder4Roles.Detective;
                    }
                    else if (Color == MurderColor)
                    {
                        return Murder4Roles.Murderer;
                    }
                    else if (Color == Unassigned)
                    {
                        return Murder4Roles.Unassigned;
                    }
                    else
                    {
                        ModConsole.Warning("Unknown Color Detected!");
                        ModConsole.Warning(Player.DisplayName() + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
                        return Murder4Roles.None;
                    }
                }
                else
                {
                    return Murder4Roles.Unassigned;
                }
            }
            return Murder4Roles.Unassigned;
        }

        private Color GetPlayerEntryColor(GameObject Entry)
        {
            if (Entry != null)
            {
                var Image = Entry.GetComponentInChildren<Image>();
                if (Image != null)
                {
                    return Image.color;
                }
            }
            return Color.white;
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

        public void OnDestroy()
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
            if (Player != null)
            {
                if (PlayerESPMenu.Toggle_Player_ESP)
                {
                    if (ESP != null)
                    {
                        if (ESP.UseCustomColor)
                        {
                            ESP.ChangeColor(color);
                        }
                    }
                }
            }
        }

        private void ResetESPColor()
        {
            if (Player != null)
            {
                if (PlayerESPMenu.Toggle_Player_ESP)
                {
                    var esp = Player.gameObject.GetComponent<PlayerESP>();
                    if (esp != null)
                    {
                        esp.ResetColor();
                    }
                }
            }
        }

        private void Update()
        {
            try
            {
                if (LinkedNode == null)
                {
                    LinkedNode = GetEntryWithUser();
                }

                if (LinkedNode != null)
                {
                    if (GameRoleTag != null)
                    {
                        if (GameRoleTag.ShowTag != ViewRoles)
                        {
                            GameRoleTag.ShowTag = ViewRoles;
                        }
                    }
                    if (PlayerESPMenu.Toggle_Player_ESP)
                    {
                        if (ESP == null)
                        {
                            ESP = Player.gameObject.GetComponent<PlayerESP>();
                        }
                    }
                    if (IsMurder4World)
                    {
                        UpdateMurder4ESPMechanism();
                    }
                    else if (IsAmongUsWorld)
                    {
                        UpdateAmongUSESpMechanism();
                    }
                }
            }
            catch (Exception e) { ModConsole.DebugError("JarRoleRevealer OnUpdate Exception : " + e); }
        }

        private void UpdateMurder4ESPMechanism()
        {
            var ReturnedRole = GetPlayerRoleMurder4();
            if (ReturnedRole == Murder4Roles.Null)
            {
                return;
            }
            if (ReturnedRole != Murder4CurrentRole)
            {
                Murder4CurrentRole = ReturnedRole;
            }
            if (ESP != null)
            {
                if (ESP.UseCustomColor != ViewRoles)
                {
                    ESP.UseCustomColor = ViewRoles;
                }
            }
            if (ViewRoles)
            {
                if (ReturnedRole != Murder4Roles.None && ReturnedRole != Murder4Roles.Unassigned)
                {
                    if (GetCurrentSingleTagText() != ReturnedRole.ToString())
                    {
                        var color = Murder4GetNamePlateColor();
                        if (color != null)
                        {
                            SetTag(GameRoleTag, ReturnedRole.ToString(), DefaultTextColor, color.Value);
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

        private void UpdateAmongUSESpMechanism()
        {
            var ReturnedRole = GetPlayerRoleAmongUS();
            if (ReturnedRole == AmongUsRoles.Null)
            {
                return;
            }
            if (ReturnedRole != AmongUsCurrentRole)
            {
                AmongUsCurrentRole = ReturnedRole;
            }

            if (AmongUSVoteRevealTag == null)
            {
                AmongUSVoteRevealTag = SingleTagsUtils.AddSingleTag(Player);
            }
            if (ESP != null)
            {
                if (ESP.UseCustomColor != ViewRoles)
                {
                    ESP.UseCustomColor = ViewRoles;
                }
            }
            if (ViewRoles)
            {
                if (AmongUSHasVoted)
                {
                    if (!AmongUSVoteRevealTag.ShowTag)
                    {
                        AmongUSVoteRevealTag.ShowTag = true;
                    }
                }

                if (ReturnedRole != AmongUsRoles.None && ReturnedRole != AmongUsRoles.Unassigned)
                {
                    if (GetCurrentSingleTagText() != ReturnedRole.ToString())
                    {
                        var color = AmongUsGetNamePlateColor();
                        if (color != null)
                        {
                            SetTag(GameRoleTag, ReturnedRole.ToString(), DefaultTextColor, color.Value);
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
                if (AmongUSVoteRevealTag != null)
                {
                    if (AmongUSVoteRevealTag.ShowTag)
                    {
                        AmongUSVoteRevealTag.ShowTag = false;
                    }
                }

                if (GetCurrentSingleTagText() != HiddenRole)
                {
                    SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                    ResetESPColor();
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

        internal bool _AmongUSHasVoted { get; private set; }

        internal bool AmongUSHasVoted
        {
            get
            {
                return _AmongUSHasVoted;
            }

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
            get
            {
                if (AmongUsCurrentRole == AmongUsRoles.Crewmate)
                {
                    return !AmongUSHasVoted;
                }
                else if (AmongUsCurrentRole == AmongUsRoles.Impostor)
                {
                    return !AmongUSHasVoted;
                }
                else if (AmongUsCurrentRole == AmongUsRoles.Unassigned)
                {
                    return false;
                }
                else if (AmongUsCurrentRole == AmongUsRoles.None)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        internal bool IsRPCActive { get; private set; }
        internal Murder4Roles Murder4CurrentRole { get; private set; } = Murder4Roles.Unassigned;
        internal AmongUsRoles AmongUsCurrentRole { get; private set; } = AmongUsRoles.Unassigned;
        internal Player Player { get; private set; }

        internal PlayerESP ESP { get; private set; }
        internal SingleTag GameRoleTag { get; private set; }

        internal SingleTag AmongUSVoteRevealTag { get; private set; }

        internal LinkedNodes LinkedNode { get; private set; }

        internal string HiddenRole { get; } = "Role Hidden";
        internal string NoRoles { get; } = "No Role";

        internal Color NoRolesColor { get; } = Color.yellow;
        internal Color HiddenRolesColor { get; } = Color.green;
        internal Color DefaultTextColor { get; } = Color.white;

        // MURDER 4 MAP
        internal Color MurderColor { get; } = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);

        internal Color BystanderColor { get; } = new Color(0.3428266f, 0.5883213f, 0.6792453f, 1f);
        internal Color DetectiveColor { get; } = new Color(0.2976544f, 0.251424f, 0.4716981f, 1f);

        // AMONG US MAP
        internal Color ImpostorColor { get; } = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);

        internal Color CrewmateColor { get; } = new Color(0f, 0.3228593f, 0.8396226f, 1f);

        // GENERAL
        internal Color Unassigned { get; } = new Color(0.5f, 0.5f, 0.5f, 1f);

        internal Color NoRolesAssigned { get; } = new Color(0f, 0f, 0f, 0f);
    }
}