using AstroClient.Components;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using DayClientML2.Utility.Extensions;
using System;
using System.Linq;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using static AstroClient.JarRoleController;
using Object = UnityEngine.Object;

namespace AstroClient.components
{
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
            try
            {
                var p = this.GetComponent<Player>();
                if (p != null)
                {
                    Internal_player = p;
                }
                else
                {
                    UnityEngine.Object.Destroy(this);
                }

                if (Internal_player != null)
                {
                    if (Internal_player.prop_APIUser_0 != null)
                    {
                        Internal_user = Internal_player.prop_APIUser_0;
                    }
                }
                GameRoleTag = SingleTagsUtils.AddSingleTag(Internal_player);
                if (isAmongUsWorld)
                {
                AmongUSVoteRevealTag = SingleTagsUtils.AddSingleTag(Internal_player);
                }
                if (JarRoleController.ViewRoles)
                {
                    SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                    GameRoleTag.ShowTag = false;
                }
                else
                {
                    SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                    GameRoleTag.ShowTag = false;
                }
                if (JarRoleController.IsMurder4World)
                {
                    Murder4CurrentRole = Murder4Roles.Unassigned;
                    ModConsole.DebugLog("Registered " + Internal_user.displayName + " On Murder 4 Role ESP.");
                }
                if (JarRoleController.isAmongUsWorld)
                {
                    AmongUsCurrentRole = AmongUsRoles.Unassigned;
                    ModConsole.DebugLog("Registered " + Internal_user.displayName + " On Among US Role ESP.");
                }
            }
            catch (Exception e)
            {
                ModConsole.Error("[Murder4RoleRevealer] :  Error Registering Player " + this.GetComponent<Player>().prop_APIUser_0.displayName + " : " + e);
            }
        }

        private bool JarRoleEspDebug = false;

        [HideFromIl2Cpp]
        private static JarRoleESP TranslateSyncVotedFor(int value)
        {
            return RoleEspComponents.Where(x => x.LinkedEntry.nodevalue == value).First();
        }
        [HideFromIl2Cpp]

        private static int RemoveSyncVotedForText(string key)
        {
            var removedtext = key.ToLower().Replace("syncvotedfor", string.Empty).Replace(" ", string.Empty);
            int.TryParse(removedtext, out var value);
            return value;
        }
        [HideFromIl2Cpp]

        private static JarRoleESP GetEventNode(GameObject node)
        {
            return RoleEspComponents.Where(x => x.Node == node).First();
        }


        [HideFromIl2Cpp]

        public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            if (isAmongUsWorld)
            {
                if (Internal_AssignedPlayerNode != null)
                {
                    if (obj != null && obj == Internal_AssignedPlayerNode)
                    {

                        if (action.StartsWith("SyncVotedFor"))
                        {
                            var actionexecuted = GetEventNode(obj);
                            if (actionexecuted != null)
                            {
                                actionexecuted.AmongUSHasVoted = true;
                                var against = TranslateSyncVotedFor(RemoveSyncVotedForText(action));
                                if (against != null)
                                {
                                    actionexecuted.AmongUSVoteRevealTag.ShowTag = true;
                                    if(against != JarRoleController.GetLocalPlayerNode())
                                    {
                                        SetTag(actionexecuted.AmongUSVoteRevealTag, $"Voted: {against.apiuser.displayName}", Color.white, ColorConverter.HexToColor("#44DBAC"));
                                    }
                                    else
                                    {
                                        SetTag(actionexecuted.AmongUSVoteRevealTag, $"Voted: {against.apiuser.displayName}", Color.white, ColorConverter.HexToColor("#C22B26"));

                                    }
                                }
                                
                            }

                        }
                        else if (action.ToLower() == "syncabstainedvoting")
                        {
                            AmongUSHasVoted = true;
                            if (!AmongUSVoteRevealTag.ShowTag)
                            {
                                AmongUSVoteRevealTag.ShowTag = true;
                            }
                            SetTag(AmongUSVoteRevealTag, $"Skipped Vote", Color.white, ColorConverter.HexToColor("#1BA039"));

                        }
                    }


                    if (action == "SyncEndVotingPhase" || action == "SyncAbort" || action == "SyncVictoryB" || action == "SyncVictoryM" || action == "SyncStart")
                    {
                        if (AmongUSHasVoted)
                        {
                            AmongUSHasVoted = false;
                        }
                        if (AmongUSVoteRevealTag != null)
                        {
                            SetTag(AmongUSVoteRevealTag, $"No Votes", Color.white, ColorConverter.HexToColor("#034989"));
                            if (AmongUSVoteRevealTag.ShowTag)
                            {
                                AmongUSVoteRevealTag.ShowTag = false;
                            }
                        }

                    }
                }
            }
        }


        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (JarRoleEspDebug)
            {
                ModConsole.DebugLog($"[Jar Role ESP Debug] : {msg}");
            }
        }

        [HideFromIl2Cpp]
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
                        ModConsole.Warning(Internal_user.displayName + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
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

        [HideFromIl2Cpp]
        private AmongUsRoles GetPlayerRoleAmongUS()
        {
            if (Internal_AssignedPlayerEntry != null)
            {
                if (VerifyEntry(Internal_AssignedPlayerEntry))
                {
                    return CheckEntryAmongUS(Internal_AssignedPlayerEntry);
                }
                else
                {
                    FindEntryWithUser();
                    return CheckEntryAmongUS(Internal_AssignedPlayerEntry);
                }
            }
            else
            {
                FindEntryWithUser();
                return CheckEntryAmongUS(Internal_AssignedPlayerEntry);
            }
        }

        [HideFromIl2Cpp]
        private Murder4Roles GetPlayerRoleMurder4()
        {
            if (Internal_AssignedPlayerEntry != null)
            {
                if (VerifyEntry(Internal_AssignedPlayerEntry))
                {
                    return CheckEntryMurder4(Internal_AssignedPlayerEntry);
                }
                else
                {
                    FindEntryWithUser();
                    return CheckEntryMurder4(Internal_AssignedPlayerEntry);
                }
            }
            else
            {
                FindEntryWithUser();
                return CheckEntryMurder4(Internal_AssignedPlayerEntry);
            }
        }

        [HideFromIl2Cpp]
        private bool VerifyEntry(GameObject Entry)
        {
            if (Entry != null)
            {
                var EntryText = Entry.GetComponentInChildren<Text>();
                if (EntryText != null)
                {
                    if (!string.IsNullOrEmpty(EntryText.text) && !string.IsNullOrWhiteSpace(EntryText.text))
                    {
                        if (EntryText.text == Internal_user.displayName)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        [HideFromIl2Cpp]
        private void FindEntryWithUser()
        {
            foreach (var item in JarRoleController.JarRoleLinks)
            {
                if (item != null)
                {
                    if (item.Entry != null)
                    {
                        var EntryText = item.Entry.GetComponentInChildren<Text>();
                        if (EntryText != null)
                        {
                            if (!string.IsNullOrEmpty(EntryText.text) && !string.IsNullOrWhiteSpace(EntryText.text))
                            {
                                if (EntryText.text == Internal_user.displayName)
                                {
                                    Internal_SavedEntry = item;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        [HideFromIl2Cpp]
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

        [HideFromIl2Cpp]
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

        [HideFromIl2Cpp]
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
                        ModConsole.Warning(Internal_user.displayName + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
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

        [HideFromIl2Cpp]
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

        [HideFromIl2Cpp]
        private void SetTag(SingleTag tag, string text, Color TextColor, Color TagColor)
        {
            if (Internal_player != null)
            {
                if (tag != null)
                {
                    if (tag.Label_Text != text)
                    {
                        tag.Label_Text = text;
                        Debug($"Updating SingleTag Label_Text for {Internal_player.DisplayName()}, with text : {text} ");
                    }
                    if (tag.Label_TextColor != TextColor)
                    {
                        tag.Label_TextColor = TextColor;
                        Debug($"Updating SingleTag Label_TextColor for {Internal_player.DisplayName()}, with TextColor : {TextColor.ToString()}");
                    }
                    if (tag.Tag_Color != TagColor)
                    {
                        tag.Tag_Color = TagColor;
                        Debug($"Updating SingleTag Tag_Color for {Internal_player.DisplayName()}, with TagColor : {TagColor.ToString()}");
                    }
                }
            }
        }

        private void OnDestroy()
        {
            if (GameRoleTag != null)
            {
                Object.Destroy(GameRoleTag);
            }
            if (AmongUSVoteRevealTag != null)
            {
                Object.Destroy(AmongUSVoteRevealTag);
            }
            //if (_AssignedPlayerEntry != null)
            //{
            //    _AssignedPlayerEntry.RenameObject("Unassigned Entry");
            //}
            if (_AssignedPlayerNode != null)
            {
                _AssignedPlayerNode.RenameObject("Unassigned Node");
            }

            JarRoleController.RoleEspComponents.Remove(this);
        }

        [HideFromIl2Cpp]
        private string GetCurrentSingleTagText()
        {
            return GameRoleTag.Label_Text;
        }

        private void Update()
        {
            try
            {
                if (Internal_SavedEntry == null)
                {
                    FindEntryWithUser();
                }

                if (GameRoleTag != null)
                {
                    if (GameRoleTag.ShowTag != JarRoleController.ViewRoles)
                    {
                        GameRoleTag.ShowTag = JarRoleController.ViewRoles;
                    }
                }


                if (JarRoleController.IsMurder4World)
                {
                    var ReturnedRole = GetPlayerRoleMurder4();
                    if (ReturnedRole != Murder4CurrentRole)
                    {
                        Murder4CurrentRole = ReturnedRole;
                    }
                    if (JarRoleController.ViewRoles)
                    {
                        var color = Murder4GetNamePlateColor();
                        if (color != null)
                        {
                            if (GetCurrentSingleTagText() != ReturnedRole.ToString())
                            {
                                SetTag(GameRoleTag, ReturnedRole.ToString(), DefaultTextColor, color.Value);
                            }
                        }
                        else
                        {
                            if (GetCurrentSingleTagText() != NoRoles)
                            {
                                SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                            }
                        }
                    }
                    else
                    {
                        if (GetCurrentSingleTagText() != HiddenRole)
                        {
                            SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                        }
                    }
                }
                else if (JarRoleController.isAmongUsWorld)
                {


                    var ReturnedRole = GetPlayerRoleAmongUS();
                    if (ReturnedRole != AmongUsCurrentRole)
                    {
                        AmongUsCurrentRole = ReturnedRole;
                    }
                    if (JarRoleController.ViewRoles)
                    {

                        if (AmongUSVoteRevealTag != null)
                        {
                            if (JarRoleController.ViewRoles)
                            {
                                if (AmongUsCurrentRole == AmongUsRoles.Crewmate || AmongUsCurrentRole == AmongUsRoles.Impostor)
                                {

                                    if (!AmongUSHasVoted)
                                    {
                                        if (AmongUSVoteRevealTag.ShowTag)
                                        {
                                            AmongUSVoteRevealTag.ShowTag = false;
                                        }
                                    }
                                    else
                                    {
                                        if (!AmongUSVoteRevealTag.ShowTag)
                                        {
                                            AmongUSVoteRevealTag.ShowTag = true;
                                        }
                                    }

                                }
                                else
                                {
                                    if (AmongUSVoteRevealTag.ShowTag)
                                    {
                                        AmongUSVoteRevealTag.ShowTag = false;
                                    }
                                }
                            }
                            else
                            {
                                if (AmongUSVoteRevealTag.ShowTag)
                                {
                                    AmongUSVoteRevealTag.ShowTag = false;
                                }
                            }
                        }

                        var color = AmongUsGetNamePlateColor();
                        if (color != null)
                        {
                            if (GetCurrentSingleTagText() != ReturnedRole.ToString())
                            {
                                SetTag(GameRoleTag, ReturnedRole.ToString(), DefaultTextColor, color.Value);
                            }
                        }
                        else
                        {
                            if (GetCurrentSingleTagText() != NoRoles)
                            {
                                SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                                AmongUSHasVoted = false;
                            }
                        }
                    }
                    else
                    {
                        if (GetCurrentSingleTagText() != HiddenRole)
                        {
                            SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                        }
                    }
                    return;
                }
            }
            catch (Exception e) { ModConsole.DebugError("JarRoleRevealer OnUpdate Exception : " + e); }
        }

        private readonly string HiddenRole = "Role Hidden";
        private readonly string NoRoles = "No Role";

        private readonly Color NoRolesColor = Color.yellow;
        private readonly Color HiddenRolesColor = Color.green;

        private readonly Color DefaultTextColor = Color.white;

        internal Murder4Roles AssignedMurder4Role
        {
            [HideFromIl2Cpp]
            get
            {
                return Murder4CurrentRole;
            }
        }

        internal AmongUsRoles AssignedAmongUS4Role
        {
            [HideFromIl2Cpp]
            get
            {
                return AmongUsCurrentRole;
            }
        }

        internal enum Murder4Roles
        {
            None = 0,
            Detective = 1,
            Murderer = 2,
            Bystander = 3,
            Unassigned = 4,
        }

        internal enum AmongUsRoles
        {
            None = 0,
            Crewmate = 1,
            Impostor = 2,
            Unassigned = 3,
        }

        private LinkedNodes Internal_SavedEntry
        {
            [HideFromIl2Cpp]
            get
            {
                return _SavedEntry;
            }
            [HideFromIl2Cpp]
            set
            {
                _SavedEntry = value;
                Internal_AssignedPlayerEntry = value.Entry.gameObject;
                Internal_AssignedPlayerNode = value.Node.gameObject;
            }
        }

        internal LinkedNodes LinkedEntry
        {
            [HideFromIl2Cpp]
            get
            {
                return Internal_SavedEntry;
            }
        }

        private GameObject Internal_AssignedPlayerEntry
        {
            [HideFromIl2Cpp]
            get
            {
                return _AssignedPlayerEntry;
            }
            [HideFromIl2Cpp]
            set
            {
                _AssignedPlayerEntry = value;
            }
        }

        internal GameObject Entry
        {
            [HideFromIl2Cpp]
            get
            {
                return Internal_AssignedPlayerEntry;
            }
        }

        internal APIUser apiuser
        {
            [HideFromIl2Cpp]
            get
            {
                return Internal_user;
            }
        }

        private GameObject _AssignedPlayerNode;

        private GameObject Internal_AssignedPlayerNode
        {
            [HideFromIl2Cpp]
            get
            {
                return _AssignedPlayerNode;
            }
            [HideFromIl2Cpp]
            set
            {
                if (_AssignedPlayerNode != null)
                {
                    if (value != _AssignedPlayerNode)
                    {
                        _AssignedPlayerNode.RenameObject("Unassigned Node");
                    }
                }
                value.RenameObject(Internal_user.displayName);
                _AssignedPlayerNode = value;
            }
        }

        internal GameObject Node
        {
            [HideFromIl2Cpp]
            get
            {
                return Internal_AssignedPlayerNode;
            }
        }


        internal bool AmongUSHasVoted;

        internal bool AmongUSCanVote
        {
            get
            {

                if (AmongUsCurrentRole == AmongUsRoles.Crewmate)
                {
                    if (!AmongUSHasVoted)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (AmongUsCurrentRole == AmongUsRoles.Impostor)
                {
                    if (!AmongUSHasVoted)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        private Murder4Roles Murder4CurrentRole;
        private AmongUsRoles AmongUsCurrentRole;
        private Player Internal_player;
        private APIUser Internal_user;
        private GameObject _AssignedPlayerEntry;
        private SingleTag GameRoleTag;
        
        internal SingleTag AmongUSVoteRevealTag;



        private LinkedNodes _SavedEntry;

        // MURDER 4 MAP
        private readonly Color MurderColor = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);

        private readonly Color BystanderColor = new Color(0.3428266f, 0.5883213f, 0.6792453f, 1f);
        private readonly Color DetectiveColor = new Color(0.2976544f, 0.251424f, 0.4716981f, 1f);

        // AMONG US MAP
        private readonly Color ImpostorColor = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);

        private readonly Color CrewmateColor = new Color(0f, 0.3228593f, 0.8396226f, 1f);

        // GENERAL
        private readonly Color Unassigned = new Color(0.5f, 0.5f, 0.5f, 1f);

        private readonly Color NoRolesAssigned = new Color(0f, 0f, 0f, 0f);
    }
}