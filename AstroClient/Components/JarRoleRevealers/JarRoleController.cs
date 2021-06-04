namespace AstroClient
{
	using AstroClient.Components;
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnhollowerBaseLib;
	using UnityEngine;
	using VRC;

	public class JarRoleController : GameEvents
    {
        private static bool _ViewRoles;

        public static bool IsMurder4World { get; private set; }

        public static bool IsAmongUsWorld { get; private set; }

        public static bool ViewRoles
        {
            get
            {
                return _ViewRoles;
            }
            set
            {
                _ViewRoles = value;
                if (Murder4RolesRevealerToggle != null)
                {
                    if (IsMurder4World)
                    {
                        Murder4RolesRevealerToggle.SetToggleState(value);
                    }
                }
                if (AmongUSRolesRevealerToggle != null)
                {
                    if (IsAmongUsWorld)
                    {
                        AmongUSRolesRevealerToggle.SetToggleState(value);
                    }
                }
            }
        }

        public static QMSingleToggleButton Murder4RolesRevealerToggle;
        public static QMSingleToggleButton AmongUSRolesRevealerToggle;

        public static List<LinkedNodes> JarRoleLinks = new List<LinkedNodes>();

        public static List<JarRoleESP> RoleEspComponents = new List<JarRoleESP>();

        public static LinkedNodes GetLinkedNode(int value)
        {
            return JarRoleLinks.Where(x => x.Nodevalue == value).DefaultIfEmpty(null).First();
        }

        public static JarRoleESP GetLinkedComponent(int value)
        {
            return RoleEspComponents.Where(x => x.LinkedEntry.Nodevalue == value).DefaultIfEmpty(null).First();
        }

        public override void OnLevelLoaded()
        {
            JarRoleLinks.Clear();
            RoleEspComponents.Clear();
            Murder4RolesRevealerToggle.SetToggleState(false);
            AmongUSRolesRevealerToggle.SetToggleState(false);
            ViewRoles = false;
            IsAmongUsWorld = false;
            IsMurder4World = false;
        }

        public override void OnPlayerJoined(Player player)
        {
            MiscUtility.DelayFunction(0.5f, new Action(() =>
            {
                if (JarRoleLinks.Count() != 0)
                {
                    if (IsMurder4World || IsAmongUsWorld)
                    {
                        if (player != null)
                        {
                            if (player.gameObject.GetComponent<JarRoleESP>() == null)
                            {
                                var RoleRevealer = player.gameObject.AddComponent<JarRoleESP>();
                                if (RoleRevealer != null)
                                {
                                    if (!RoleEspComponents.Contains(RoleRevealer))
                                    {
                                        RoleEspComponents.Add(RoleRevealer);
                                    }
                                }
                            }
                        }
                    }
                }
            }));
        }

        public class LinkedNodes
        {
            public Transform Entry { get; set; }
            public Transform Node { get; set; }
            public int Nodevalue { get; set; }

            public LinkedNodes(Transform EntryObj, Transform Nodeobj, int linknumber)
            {
                Entry = EntryObj;
                Node = Nodeobj;
                Nodevalue = linknumber;
            }
        }

        public static string DescPart
        {
            get
            {
                if (IsAmongUsWorld)
                {
                    return "ability To see who is the impostor";
                }
                if (IsMurder4World)
                {
                    return "ability to see who is the murderer";
                }

                return "WORLD NOT RECOGNIZED!";
            }
        }

        public static bool DebugMsg = true;

        public static void Debug(string msg)
        {
            if (DebugMsg)
            {
                ModConsole.DebugLog($"[Jar Role Linker Debug] : {msg}");
            }
        }

        public static int? RemoveNodeText(Transform node)
        {
            var replacedstring = node.name.Replace("Player Node ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(replacedstring) && !string.IsNullOrWhiteSpace(replacedstring))
            {
                int.TryParse(replacedstring, out int value);
                return value;
            }
            return null;
        }

        public static int? RemoveEntryText(Transform Entry)
        {
            var replacedstring = Entry.name.Replace("Player Entry ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty); ;
            if (!string.IsNullOrEmpty(replacedstring) && !string.IsNullOrWhiteSpace(replacedstring))
            {
                int.TryParse(replacedstring, out int value);
                return value;
            }
            return null;
        }

        public static JarRoleESP GetLocalPlayerNode()
        {
            return RoleEspComponents.Count() != 0 && RoleEspComponents != null
                ? RoleEspComponents.Where(x => x.Apiuser.displayName == LocalPlayerUtils.GetSelfPlayer().DisplayName()).First()
                : null;
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            IsAmongUsWorld = id.Equals(WorldIds.AmongUS);
            IsMurder4World = id.Equals(WorldIds.Murder4);

            if (IsAmongUsWorld || IsMurder4World)
            {
                var PlayerEntries = GameObjectFinder.Find("Game Logic/Game Canvas/Game In Progress/Player List/Player List Group"); // SHOULD WORK IN MURDER 4 AND AMONG US.
                var GameNodes = GameObjectFinder.Find("Game Logic/Player Nodes"); // SHOULD WORK IN MURDER 4 AND AMONG US.
                Il2CppArrayBase<Transform> EntryChilds;
                Il2CppArrayBase<Transform> NodeChilds;

                if (PlayerEntries != null)
                {
                    EntryChilds = PlayerEntries.GetComponentsInChildren<Transform>(true);
                }
                else
                {
                    ModConsole.Error("PlayerEntries Returned Null, Ignored Finding Nodes & Entries");
                    return;
                }
                if (GameNodes != null)
                {
                    NodeChilds = GameNodes.GetComponentsInChildren<Transform>(true);
                }
                else
                {
                    ModConsole.Error("GameNodes Returned Null, Ignored Finding Nodes & Entries");
                    return;
                }

                if (PlayerEntries != null)
                {
                    foreach (var Entry in EntryChilds)
                    {
                        if (Entry != null)
                        {
                            if (Entry.gameObject == PlayerEntries) // CRITICAL AS THE GETCOMPONENTSINCHILDREN INCLUDE THE PARENT APPARENTLY AS WELL
                            {
                                continue;
                            }
                            if (Entry.name.StartsWith("Player Entry"))
                            {
                                //Debug($"Found Entry : {Entry.name}, Finding Link in Nodes...");
                                int? EntryNumber = RemoveEntryText(Entry);
                                if (EntryNumber != null)
                                {
                                    foreach (var node in NodeChilds)
                                    {
                                        if (node != null)
                                        {
                                            //if(node.name.Equals("Player Nodes"))
                                            //{
                                            //	continue;
                                            //}
                                            if (node.gameObject == GameNodes) // CRITICAL AS THE GETCOMPONENTSINCHILDREN INCLUDE THE PARENT APPARENTLY AS WELL
                                            {
                                                continue;
                                            }
                                            int? NodeNumber = RemoveNodeText(node);
                                            if (NodeNumber != null)
                                            {
                                                //Debug($"Comparing Entry Nr. {EntryNumber} Having Name {Entry.name} with Node nr {NodeNumber} having Name {node.name}");
                                                if (NodeNumber == EntryNumber)
                                                {
                                                    //Debug($"Linked Player Entry : {Entry.name}, With node : {node.name}, with link : {NodeNumber}");
                                                    var addme = new LinkedNodes(Entry, node, NodeNumber.Value);
                                                    if (GetLinkedNode(addme.Nodevalue) != null)
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        if (!JarRoleLinks.Contains(addme))
                                                        {
                                                            JarRoleLinks.Add(addme);
                                                            //Debug($"Registered Player Entry : {addme.Entry.name}, With node : {addme.Node.name} with Link nr. {addme.nodevalue}");
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ModConsole.DebugLog($"[Jar Role Revealer] Registered {JarRoleLinks.Count()} Linked Nodes and Player Entries. ({DescPart})");
                }
                else
                {
                    if (IsMurder4World)
                    {
                        ModConsole.Error("Player List Group Path in Murder 4 Changed! Unable to Reveal Roles!");
                    }
                    if (IsAmongUsWorld)
                    {
                        ModConsole.Error("Player List Group Path in Among us Changed! Unable to Reveal Roles!");
                    }
                }
            }
        }
    }
}