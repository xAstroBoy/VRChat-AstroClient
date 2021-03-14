using AstroClient.components;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnityEngine;
using VRC;

namespace AstroClient
{
    public static class JarRoleController
    {
        
        private static bool _IsMurder4World;
        private static bool _isAmongUsWorld;
        private static bool _ViewRoles;
        private static bool _ShowHiddenNodes;

        public static bool IsMurder4World
        {
            get
            {
                return _IsMurder4World;
            }
            set
            {
                if (value)
                {
                    _isAmongUsWorld = false;
                }
                _IsMurder4World = value;
            }
        }
        public static bool isAmongUsWorld
        {
            get
            {
                return _isAmongUsWorld;
            }
            set
            {
                if (value)
                {
                    _IsMurder4World = false;
                }
                _isAmongUsWorld = value;
            }
        }
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
                        Murder4RolesRevealerToggle.setToggleState(value);
                    }
                }
                if (AmongUSRolesRevealerToggle != null)
                {
                    if (isAmongUsWorld)
                    {
                        AmongUSRolesRevealerToggle.setToggleState(value);
                    }
                }

            }
        }


        public static QMToggleButton Murder4RolesRevealerToggle;
        public static QMToggleButton AmongUSRolesRevealerToggle;

        public static List<LinkedNodes> JarRoleLinks = new List<LinkedNodes>();

        public static List<JarRoleESP> RoleEspComponents = new List<JarRoleESP>();


        public static LinkedNodes GetLinkedNode(int value)
        {
            return JarRoleLinks.Where(x => x.nodevalue == value).DefaultIfEmpty(null).First();
        }


        public static JarRoleESP GetLinkedComponent(int value)
        {
            return RoleEspComponents.Where(x => x.LinkedEntry.nodevalue == value).DefaultIfEmpty(null).First();
        }

        public static void OnLevelLoad()
        {
            JarRoleLinks.Clear();
            RoleEspComponents.Clear();
            isAmongUsWorld = false;
            IsMurder4World = false;
            Murder4RolesRevealerToggle.setToggleState(false);
            AmongUSRolesRevealerToggle.setToggleState(false);
            ViewRoles = false;
        }


        public static void OnPlayerJoined(Player player)
        {
            if (JarRoleLinks.Count() != 0)
            {
                if (IsMurder4World || isAmongUsWorld)
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
        }



        public class LinkedNodes
        {
            public Transform Entry{ get; set; }
            public Transform Node { get; set; }
            public int nodevalue { get; set; }
            public LinkedNodes(Transform EntryObj, Transform Nodeobj, int linknumber)
            {
                Entry = EntryObj;
                Node = Nodeobj;
                nodevalue = linknumber;
            }
        }
    



    public static string DescPart
        {
            get
            {
                if(isAmongUsWorld)
                {
                    return "ability To see who is the impostor";
                }
                if(IsMurder4World)
                {
                    return "ability to see who is the murderer";
                }

                return "WORLD NOT RECOGNIZED!";
            }
        }


        public static bool DebugMsg = false;
        public static void Debug(string msg)
        {
            if(DebugMsg)
            {
                ModConsole.DebugLog($"[Jar Role Linker Debug] : {msg}");
            }
        }


        public static int? RemoveNodeText(Transform node)
        {
            var replacedstring = node.name.Replace("Player Node ", String.Empty).Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty);
            if (!String.IsNullOrEmpty(replacedstring) && !String.IsNullOrWhiteSpace(replacedstring)) 
            {
                int.TryParse(replacedstring, out int value);
                return value;
            }
            return null;
        }

        public static int? RemoveEntryText(Transform Entry)
        {
            var replacedstring = Entry.name.Replace("Player Entry ", String.Empty).Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty); ;
            if (!String.IsNullOrEmpty(replacedstring) && !String.IsNullOrWhiteSpace(replacedstring))
            {
                int.TryParse(replacedstring, out int value);
                return value;
            }
            return null;
        }


        public static void OnWorldReveal()
        {
            isAmongUsWorld = (WorldUtils.GetWorldID() == WorldIds.AmongUS);
            IsMurder4World = (WorldUtils.GetWorldID() == WorldIds.Murder4);

            if (isAmongUsWorld || IsMurder4World)
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
                            if (Entry.name.StartsWith("Player Entry"))
                            {
                                Debug($"Found Entry : {Entry.name}, Finding Link in Nodes...");
                                int? EntryNumber = RemoveEntryText(Entry);
                                if (EntryNumber != null)
                                {
                                    foreach (var node in NodeChilds)
                                    {
                                        if (node != null)
                                        {
                                            int? NodeNumber = RemoveNodeText(node);
                                            if(NodeNumber != null)
                                            {

                                                Debug($"Comparing Entry Nr. {EntryNumber} Having Name {Entry.name} with Node nr {NodeNumber} having Name {node.name}");
                                                if(NodeNumber == EntryNumber)
                                                {
                                                    Debug($"Linked Player Entry : {Entry.name}, With node : {node.name}, with link : {NodeNumber}");
                                                    var addme = new LinkedNodes(Entry, node, NodeNumber.Value);
                                                    if (GetLinkedNode(addme.nodevalue) != null)
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        if (!JarRoleLinks.Contains(addme))
                                                        {
                                                            JarRoleLinks.Add(addme);
                                                            Debug($"Registered Player Entry : {addme.Entry.name}, With node : {addme.Node.name} with Link nr. {addme.nodevalue}");
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
                    ModConsole.Log($"[Jar Role Revealer] Registered {JarRoleLinks.Count()} Linked Nodes and Player Entries. ({DescPart})");
                }
                else
                {

                    if(IsMurder4World)
                    {
                        ModConsole.Error("Player List Group Path in Murder 4 Changed! Unable to Reveal Roles!");
                    }
                    if(isAmongUsWorld)
                    {
                        ModConsole.Error("Player List Group Path in Among us Changed! Unable to Reveal Roles!");
                    }
                }
            }
        }
    }
}
