﻿namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroClient.Tools.Extensions;
    using AstroEventArgs;
    using UnhollowerBaseLib;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using WorldModifications.WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class JarRoleController : AstroEvents
    {
        private static bool _ViewRoles;

        internal static EventHandler<BoolEventsArgs> Event_OnViewRolesPropertyChanged;

        internal static JarRoleESP _CurrentPlayerRoleESP;

        internal static bool IsMurder4World { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal static bool IsAmongUsWorld { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // TODO: Make A Action event to bind on JarRoleESP Component.

        internal static bool ViewRoles
        {
            [HideFromIl2Cpp] get => _ViewRoles;
            [HideFromIl2Cpp]
            set
            {
                _ViewRoles = value;
                if (Murder4RolesRevealerToggle != null && IsMurder4World)
                {
                    Murder4RolesRevealerToggle.SetToggleState(value);
                    Event_OnViewRolesPropertyChanged.SafetyRaise(new BoolEventsArgs(value));
                }

                if (AmongUSRolesRevealerToggle != null && IsAmongUsWorld)
                {
                    AmongUSRolesRevealerToggle.SetToggleState(value);
                    Event_OnViewRolesPropertyChanged.SafetyRaise(new BoolEventsArgs(value));
                }
            }
        }

        internal static JarRoleESP CurrentPlayerRoleESP
        {
            [HideFromIl2Cpp]
            get
            {
                //this just looks weird
                switch (_CurrentPlayerRoleESP)
                {
                    case null:
                        return _CurrentPlayerRoleESP = GameInstances.LocalPlayer.GetPlayer().gameObject.GetComponent<JarRoleESP>();

                    default:
                        return _CurrentPlayerRoleESP;
                }
            }
        }

        internal static QMToggleButton Murder4RolesRevealerToggle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal static QMToggleButton AmongUSRolesRevealerToggle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal static List<LinkedNodes> JarRoleLinks { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } = new();

        internal static List<JarRoleESP> RoleEspComponents { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } = new();

        internal static string DescPart
        {
            [HideFromIl2Cpp]
            get
            {
                if (IsAmongUsWorld) return "ability To see who is the impostor";
                if (IsMurder4World) return "ability to see who is the murderer";
                return "WORLD NOT RECOGNIZED!";
            }
        }

        internal static LinkedNodes GetLinkedNode(int value)
        {
            return JarRoleLinks.Where(x => x.Nodevalue == value).DefaultIfEmpty(null).First();
        }

        internal static JarRoleESP GetLinkedComponent(int value)
        {
            return RoleEspComponents.Where(x => x.LinkedNode.Nodevalue == value).DefaultIfEmpty(null).First();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            JarRoleLinks.Clear();
            RoleEspComponents.Clear();
            //Murder4RolesRevealerToggle.SetToggleState(false);
            //AmongUSRolesRevealerToggle.SetToggleState(false);
            _CurrentPlayerRoleESP = null;
            ViewRoles = false;
            IsAmongUsWorld = false;
            IsMurder4World = false;
        }

        internal override void OnPlayerJoined(Player player)
        {
            if (IsAmongUsWorld || IsMurder4World)
                if (JarRoleLinks.Count() != 0 && player != null)
                {
                    var RoleRevealer = player.gameObject.AddComponent<JarRoleESP>();
                    if (RoleRevealer != null && !RoleEspComponents.Contains(RoleRevealer)) RoleEspComponents.Add(RoleRevealer);
                }
        }

        internal static int? RemoveNodeText(Transform node)
        {
            var replacedstring = node.name.Replace("Player Node ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(replacedstring) && !string.IsNullOrWhiteSpace(replacedstring))
            {
                _ = int.TryParse(replacedstring, out var value);
                return value;
            }

            return null;
        }

        internal static int? RemoveEntryText(Transform Entry)
        {
            var replacedstring = Entry.name.Replace("Player Entry ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty);
            ;
            if (!string.IsNullOrEmpty(replacedstring) && !string.IsNullOrWhiteSpace(replacedstring))
            {
                _ = int.TryParse(replacedstring, out var value);
                return value;
            }

            return null;
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
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
                    for (var i1 = 0; i1 < EntryChilds.Count; i1++)
                    {
                        var Entry = EntryChilds[i1];
                        if (Entry != null)
                        {
                            // CRITICAL AS THE GETCOMPONENTSINCHILDREN INCLUDE THE PARENT APPARENTLY AS WELL
                            if (Entry.gameObject == PlayerEntries) continue;
                            if (Entry.name.StartsWith("Player Entry"))
                            {
                                //Debug($"Found Entry : {Entry.name}, Finding Link in Nodes...");
                                var EntryNumber = RemoveEntryText(Entry);
                                if (EntryNumber != null)
                                    for (var i = 0; i < NodeChilds.Count; i++)
                                    {
                                        var node = NodeChilds[i];
                                        if (node != null)
                                        {
                                            //if(node.name.Equals("Player Nodes"))
                                            //{
                                            //	continue;
                                            //}
                                            // CRITICAL AS THE GETCOMPONENTSINCHILDREN INCLUDE THE PARENT APPARENTLY AS WELL
                                            if (node.gameObject == GameNodes) continue;
                                            var NodeNumber = RemoveNodeText(node);
                                            if (NodeNumber != null)
                                                //Debug($"Comparing Entry Nr. {EntryNumber} Having Name {Entry.name} with Node nr {NodeNumber} having Name {node.name}");
                                                if (NodeNumber == EntryNumber)
                                                    //Debug($"Linked Player Entry : {Entry.name}, With node : {node.name}, with link : {NodeNumber}");
                                                    if (node != null)
                                                    {
                                                        var NodeReader = node.gameObject.AddComponent<JarNodeReader>();
                                                        if (NodeReader != null)
                                                        {
                                                            var addme = new LinkedNodes(Entry, node, NodeReader, NodeNumber.Value);

                                                            if (GetLinkedNode(addme.Nodevalue) != null) continue;

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

                    ModConsole.DebugLog($"[Jar Role Revealer] Registered {JarRoleLinks.Count()} Linked Nodes and Player Entries. ({DescPart})");
                }
                else
                {
                    if (IsMurder4World) ModConsole.Error("Player List Group Path in Murder 4 Changed! Unable to Reveal Roles!");
                    if (IsAmongUsWorld) ModConsole.Error("Player List Group Path in Among us Changed! Unable to Reveal Roles!");
                }
            }
        }

        internal class LinkedNodes
        {
            internal LinkedNodes(Transform EntryObj, Transform Nodeobj, JarNodeReader JarNodeReader, int linknumber)
            {
                Entry = EntryObj;
                Node = Nodeobj;
                NodeReader = JarNodeReader;
                Nodevalue = linknumber;
            }

            internal Transform Entry { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
            internal Transform Node { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
            internal JarNodeReader NodeReader { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
            internal int Nodevalue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        }
    }
}