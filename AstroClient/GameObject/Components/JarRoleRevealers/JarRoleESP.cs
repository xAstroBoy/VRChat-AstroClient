using AstroClient.ConsoleUtils;
using AstroClient.variables;
using MelonLoader;
using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using UnhollowerBaseLib.Attributes;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using AstroClient.extensions;
using Object = UnityEngine.Object;
using DayClientML2.Utility.Extensions;
using AstroClient.Components;
using static AstroClient.JarRoleController;

namespace AstroClient.components
{
    public class JarRoleESP : MonoBehaviour
    {

        public JarRoleESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();


        // Use this for initialization
        public void Start()
        {
            try
            {
                var p = this.GetComponent<Player>();
                if (p != null)
                {
                    player = p;
                }
                else
                {
                    UnityEngine.Object.Destroy(this);
                }

                if (player != null)
                {

                    if (player.prop_APIUser_0 != null)
                    {
                        user = player.prop_APIUser_0;
                    }
                }
                GameRoleTag = SingleTagsUtils.AddSingleTag(player);
                if (JarRoleController.ViewRoles)
                {
                    SetTag(NoRoles, DefaultTextColor, NoRolesColor);

                }
                else
                {
                    SetTag(HiddenRole, DefaultTextColor, HiddenRolesColor);
                    if (JarRoleController.IsMurder4World)
                    {
                        Murder4CurrentRole = Murder4Roles.Unassigned;

                    }
                    if (JarRoleController.isAmongUsWorld)
                    {
                        AmongUsCurrentRole = AmongUsRoles.Unassigned;
                    }
                }

                if (JarRoleController.IsMurder4World)
                {
                    Murder4CurrentRole = Murder4Roles.Unassigned;
                    ModConsole.Log("Registered " + user.displayName + " On Murder 4 Role ESP.");

                }
                if (JarRoleController.isAmongUsWorld)
                {
                    AmongUsCurrentRole = AmongUsRoles.Unassigned;
                    ModConsole.Log("Registered " + user.displayName + " On Among US Role ESP.");

                }
                

            }
            catch (Exception e)
            {
                ModConsole.Error("[Murder4RoleRevealer] :  Error Registering Player " + this.GetComponent<Player>().prop_APIUser_0.displayName + " : " + e);
            }
        }

        public bool JarRoleEspDebug = false;

        [HideFromIl2Cpp]
        public void Debug(string msg)
        {
            if (JarRoleEspDebug)
            {
                ModConsole.DebugLog($"[Jar Role ESP Debug] : {msg}");
            }
        }

        [HideFromIl2Cpp]
        public AmongUsRoles CheckEntryAmongUS(GameObject Entry)
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
                        ModConsole.Log("Unknown Color Detected!");
                        ModConsole.Log(user.displayName + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
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
        public AmongUsRoles GetPlayerRoleAmongUS()
        {
            if (AssignedPlayerEntry != null)
            {
                if (VerifyEntry(AssignedPlayerEntry))
                {
                    return CheckEntryAmongUS(AssignedPlayerEntry);
                }
                else
                {
                    FindEntryWithUser();
                    return CheckEntryAmongUS(AssignedPlayerEntry);
                }
            }
            else
            {
                FindEntryWithUser();
                return CheckEntryAmongUS(AssignedPlayerEntry);
            }
        }

        [HideFromIl2Cpp]
        public Murder4Roles GetPlayerRoleMurder4()
        {
            if (AssignedPlayerEntry != null)
            {
                if (VerifyEntry(AssignedPlayerEntry))
                {
                    return CheckEntryMurder4(AssignedPlayerEntry);
                }
                else
                {
                    FindEntryWithUser();
                    return CheckEntryMurder4(AssignedPlayerEntry);
                }
            }
            else
            {
                FindEntryWithUser();
                return CheckEntryMurder4(AssignedPlayerEntry);
            }
        }

        [HideFromIl2Cpp]

        public bool VerifyEntry(GameObject Entry)
        {
            if (Entry != null)
            {
                var EntryText = Entry.GetComponentInChildren<Text>();
                if (EntryText != null)
                {
                    if (!string.IsNullOrEmpty(EntryText.text) && !string.IsNullOrWhiteSpace(EntryText.text))
                    {
                        if (EntryText.text == user.displayName)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        [HideFromIl2Cpp]
        public void FindEntryWithUser()
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
                                if (EntryText.text == user.displayName)
                                {
                                    SavedEntry = item;
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
        public Murder4Roles CheckEntryMurder4(GameObject Entry)
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
                        ModConsole.Log("Unknown Color Detected!");
                        ModConsole.Log(user.displayName + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
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
        public Color GetPlayerEntryColor(GameObject Entry)
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
        internal void SetTag(string text, Color TextColor, Color TagColor)
        {
            if (player != null)
            {
                if (GameRoleTag != null)
                {
                    if (GameRoleTag.Label_Text != text)
                    {
                        GameRoleTag.Label_Text = text;
                        Debug($"Updating SingleTag Label_Text for {player.DisplayName()}, with text : {text} ");
                    }
                    if (GameRoleTag.Label_TextColor != TextColor)
                    {
                        GameRoleTag.Label_TextColor = TextColor;
                        Debug($"Updating SingleTag Label_TextColor for {player.DisplayName()}, with TextColor : {TextColor.ToString()}");
                    }
                    if (GameRoleTag.Tag_Color != TagColor)
                    {
                        GameRoleTag.Tag_Color = TagColor;
                        Debug($"Updating SingleTag Tag_Color for {player.DisplayName()}, with TagColor : {TagColor.ToString()}");
                    }
                }
            }
        }



        public void OnDestroy()
        {
            if (GameRoleTag != null)
            {
                Object.Destroy(GameRoleTag);
            }
            //if (_AssignedPlayerEntry != null)
            //{
            //    _AssignedPlayerEntry.RenameObject("Unassigned Entry");
            //}
            if (_AssignedPlayerNode != null)
            {
                _AssignedPlayerNode.RenameObject("Unassigned Node");
            }
            
            JarRoleController.RoleRevealers.Remove(this);
        }


        [HideFromIl2Cpp]
        internal string GetCurrentSingleTagText()
        {
            return GameRoleTag.Label_Text;
        }



        public void Update()
        {
            try
            {
                if(SavedEntry == null)
                {
                    FindEntryWithUser();
                }

                if (!JarRoleController.ViewRoles)
                {
                    if (GetCurrentSingleTagText() != HiddenRole)
                    {
                        SetTag(HiddenRole, DefaultTextColor, HiddenRolesColor);
                        if (JarRoleController.IsMurder4World)
                        {
                            Murder4CurrentRole = Murder4Roles.Unassigned;
                        }
                        if (JarRoleController.isAmongUsWorld)
                        {
                            AmongUsCurrentRole = AmongUsRoles.Unassigned;
                        }
                    }
                    return;
                }
                else
                {

                    if (GameRoleTag != null)
                    {
                        if (!GameRoleTag.gameObject.active)
                        {
                            GameRoleTag.gameObject.SetActive(true); // KEEP IT ENABLED!
                        }
                    }
                    if (GetCurrentSingleTagText() == HiddenRole)
                    {
                        SetTag(NoRoles, DefaultTextColor, NoRolesColor);
                    }
                    if (JarRoleController.IsMurder4World)
                    {
                        var ReturnedRole = GetPlayerRoleMurder4();
                        if (ReturnedRole != Murder4CurrentRole)
                        {
                            Murder4CurrentRole = ReturnedRole;
                            var color = Murder4GetNamePlateColor();
                            if (color != null)
                            {
                                SetTag(ReturnedRole.ToString(), Color.white, color.Value);
                            }
                            else
                            {
                                SetTag(NoRoles, DefaultTextColor, NoRolesColor);
                            }
                        }
                    }
                    if (JarRoleController.isAmongUsWorld)
                    {
                        var ReturnedRole = GetPlayerRoleAmongUS();
                        if (ReturnedRole != AmongUsCurrentRole)
                        {
                            AmongUsCurrentRole = ReturnedRole;
                            var color = AmongUsGetNamePlateColor();
                            if (color != null)
                            {
                                SetTag(ReturnedRole.ToString(), DefaultTextColor, color.Value);
                            }
                            else
                            {
                                SetTag(NoRoles, DefaultTextColor, NoRolesColor);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { ModConsole.DebugError("JarRoleRevealer OnUpdate Exception : " + e); }
        }


        public readonly string HiddenRole = "Role Hidden";
        public readonly string NoRoles = "No Role";

        public readonly Color NoRolesColor = Color.yellow;
        public readonly Color HiddenRolesColor = Color.green;


        public readonly Color DefaultTextColor = Color.white;



        public enum Murder4Roles
        {
            None = 0,
            Detective = 1,
            Murderer = 2,
            Bystander = 3,
            Unassigned = 4,
        }

        public enum AmongUsRoles
        {
            None = 0,
            Crewmate = 1,
            Impostor = 2,
            Unassigned = 3,
        }


        private LinkedNodes _SavedEntry;
        private LinkedNodes SavedEntry
        {
            get
            {
                return _SavedEntry;
            }
            set
            {
                _SavedEntry = value;
                AssignedPlayerEntry = value.Entry.gameObject;
                AssignedPlayerNode = value.Node.gameObject;
            }
        }



        private Player player;
        private Murder4Roles Murder4CurrentRole;

        private AmongUsRoles AmongUsCurrentRole;




        private APIUser user;

        private GameObject _AssignedPlayerEntry;

        private GameObject AssignedPlayerEntry
        {
            get
            {
                return _AssignedPlayerEntry;
            }
            set
            {

                //if (_AssignedPlayerEntry != null)
                //{
                //    if (value != _AssignedPlayerEntry)
                //    {
                //        _AssignedPlayerEntry.RenameObject("Unassigned Entry");
                //    }
                //}
                //value.RenameObject(user.displayName + "\n Assigned Entry");
                _AssignedPlayerEntry = value;
                
            }
        }

        private GameObject _AssignedPlayerNode;

        private GameObject AssignedPlayerNode
        {
            get
            {
                return _AssignedPlayerNode;
            }
            set
            {

                if (_AssignedPlayerNode != null)
                {
                    if (value != _AssignedPlayerNode)
                    {
                        _AssignedPlayerNode.RenameObject("Unassigned Node");

                    }
                }
                value.RenameObject(user.displayName);
                _AssignedPlayerNode = value;
            }
        }



        private SingleTag GameRoleTag;

        // MURDER 4 MAP
        public readonly Color MurderColor = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);
        public readonly Color BystanderColor = new Color(0.3428266f, 0.5883213f, 0.6792453f, 1f);
        public readonly Color DetectiveColor = new Color(0.2976544f, 0.251424f, 0.4716981f, 1f);

        // AMONG US MAP
        public readonly Color ImpostorColor = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);
        public readonly Color CrewmateColor = new Color(0f, 0.3228593f, 0.8396226f, 1f);


        // GENERAL
        public readonly Color Unassigned = new Color(0.5f, 0.5f, 0.5f, 1f);
        public readonly Color NoRolesAssigned = new Color(0f, 0f, 0f, 0f);

    }
}