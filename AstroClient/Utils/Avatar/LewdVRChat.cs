using MelonLoader;
using RubyButtonAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using Color = UnityEngine.Color;

#region AstroClient Imports

using static AstroClient.ObjectMiscOptions;
using AstroClient.ConsoleUtils;
using AstroClient.variables;
using AstroClient.extensions;
using static AstroClient.ConsoleUtils.ModConsole;
using VRC.SDKBase;
using AstroClient.components;
using DayClientML2.Utility.Extensions;
#endregion AstroClient Imports

namespace AstroClient
{
    public class LewdVRChat
    {
        public static void AvatarLoaded(Transform avatar, Player player)
        {
            if (Bools.DisableNSFWMenu)
            {
                return;
            }
            if (avatar != null && player != null && player.field_Private_APIUser_0 != null)
            {


                try
                {
                    var OldEntry = _AnalyzedPlayers.Where(x => x.player.field_Private_APIUser_0.id == player.field_Private_APIUser_0.id).DefaultIfEmpty(null).First();
                    if (OldEntry != null)
                    {
                        if (_AnalyzedPlayers.Contains(OldEntry))
                        {
                            ModConsole.DebugLog($"Deregistered User {OldEntry.player.DisplayName()} in LewdVRChat ");
                            _AnalyzedPlayers.Remove(OldEntry);
                        }
                    }
                }
                catch (Exception e)
                {
                    ModConsole.DebugError("Error in LewdVRChat Deregistering Avatar " + e);
                }



                try
                {
                    var tmp = new AnalyzedAvatar(player, avatar);
                    if (tmp != null)
                    {
                        if (!_AnalyzedPlayers.Contains(tmp))
                        {
                            ModConsole.DebugLog($"Registered User {tmp.player.DisplayName()} in LewdVRChat ");
                            _AnalyzedPlayers.Add(tmp);
                        }
                    }
                }
                catch (Exception e)
                {
                    ModConsole.DebugError("Error in LewdVRChat Registering Avatar " + e);
                }

            }
        }

        public static void OnPlayerJoined(Player player)
        {
            if (Bools.DisableNSFWMenu)
            {
                return;
            }
        }

        public static void OnPlayerLeft(Player player)
        {
            if (Bools.DisableNSFWMenu)
            {
                return;
            }
            if (player != null)
            {
                var user = _AnalyzedPlayers.Where(x => x.player.GetAPIUser().id == player.GetAPIUser().id).DefaultIfEmpty(null).First();
                if (_AnalyzedPlayers.Contains(user))
                {
                    _AnalyzedPlayers.Remove(user);
                }
            }
        }


        public static void OnWorldReveal()
        {
            if (Bools.DisableNSFWMenu)
            {
                return;
            }
        }

        public static void OnLevelLoad()
        {
            if (Bools.DisableNSFWMenu)
            {
                return;
            }
            _AnalyzedPlayers.Clear();

        }


        public static IEnumerator AvatarDumper(Transform obj, Player player)
        {
            if (obj == null && player == null)
            {
                ModConsole.DebugWarning("AvatarDumper Failed To Start!");
                if(obj != null)
                {
                    ModConsole.DebugWarning("AvatarDumper Obj is not null!");
                }
                else
                {
                    ModConsole.DebugWarning("AvatarDumper Obj is null!");
                }

                if (player != null)
                {
                    ModConsole.DebugWarning("AvatarDumper player is not null!");
                }
                else
                {
                    ModConsole.DebugWarning("AvatarDumper player is null!");
                }

                yield return null;
            }
            Avatar_Object_Dumper(obj, player);
            yield return null;
        }

        public static IEnumerator AvatarPickup(Transform obj, Player player)
        {
            if (obj == null && player == null)
            {
                ModConsole.DebugWarning("AvatarPickup Failed To Start!");

                if (obj != null)
                {
                    ModConsole.DebugWarning("AvatarPickup Obj is not null!");
                }
                else
                {
                    ModConsole.DebugWarning("AvatarPickup Obj is null!");
                }

                if (player != null)
                {
                    ModConsole.DebugWarning("AvatarPickup player is not null!");
                }
                else
                {
                    ModConsole.DebugWarning("AvatarPickup player is null!");
                }
                yield return null;
            }
            AvatarPickupEditor(obj, player);
            yield return null;
        }


        public static void AvatarPickupEditor(Transform Body, Player player)
        {
            if (Body == null)
            {
                ModConsole.Log("Couldn't find avatar body , is the player using a invisible avatar?", ConsoleColor.Red);
                return;
            }

            ModConsole.Log("[AVATAR Pickup] : Finding All Render Components of " + player.GetAPIUser().displayName + " Avatar...", ConsoleColor.Green);
            if (player.prop_ApiAvatar_0 != null)
            {
                ModConsole.Log("[AVATAR ANALYZER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, ConsoleColor.Green);
            }
            AvatarHelper.CheckTransform(Body.transform);
            var username = GetDisplayName(player);
            //Don't Check This Player's GameObjects As None Were Found
            if (AvatarHelper._GameObjects == null)
            {
                ModConsole.Log("Failed to find Objects for User : " + username);
                return;
            }
            _DumpedNames = new List<string>();
            ModConsole.Log("Adding Pickup To Avatar Internals ...", ConsoleColor.Green);

            foreach (var obj in AvatarHelper._GameObjects)
            {
                if (obj != null)
                {
                    var item = obj.gameObject;
                    var TransformRenderer = item.GetComponentInChildren<Renderer>();
                    var GameObjectRenderer = obj.GetComponentInChildren<Renderer>();
                    if (GameObjectRenderer == null || TransformRenderer == null)
                    {
                        // IGNORE, NO RENDERER!
                        continue;
                    }

                    if (!_DumpedNames.Contains(item.name))
                    {
                        if (item.name.ToLower() == "avatar" || item.name.ToLower() == "body")
                        {
                            continue;
                        }
                        _DumpedNames.Add(item.name);
                           var control = item.GetComponentInChildren<PickupController>();
                            if(control == null)
                            {
                                control = item.AddComponent<PickupController>();
                            }
                            if(control != null)
                            {
                            control.ForceComponent = true;
                                Pickup.SetPickupable(item, true);
                                Pickup.SetDisallowTheft(item);
                            ModConsole.Log("Added Pickup in Object [ " + item.name + " ] in " + username + "'s avatar", ConsoleColor.Yellow);

                        }

                        item.AddCollider();

                    }
                }
            }
        }

        public static void Avatar_Object_Dumper(Transform Body, Player player)
        {
            if (Body == null)
            {
                ModConsole.Log("Couldn't find avatar body , is the player using a invisible avatar?", ConsoleColor.Red);
                return;
            }

            ModConsole.Log("[AVATAR ANALYZER] : Dumping All Render Components of " + player.GetAPIUser().displayName + " Avatar...", ConsoleColor.Green);
            if (player.prop_ApiAvatar_0 != null)
            {
                ModConsole.Log("[AVATAR ANALYZER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, ConsoleColor.Green);
            }
            AvatarHelper.CheckTransform(Body.transform);
            var username = GetDisplayName(player);
            //Don't Check This Player's GameObjects As None Were Found
            if (AvatarHelper._GameObjects == null)
            {
                ModConsole.Log("Failed to find Objects for User : " + username);
                return;
            }
            _DumpedNames = new List<string>();
            ModConsole.Log("Dumping Objects ...", ConsoleColor.Green);

            foreach (var obj in AvatarHelper._GameObjects)
            {
                if (obj != null)
                {
                    var item = obj.gameObject;
                    var TransformRenderer = item.GetComponentInChildren<Renderer>();
                    var GameObjectRenderer = obj.GetComponentInChildren<Renderer>();
                    if (GameObjectRenderer == null || TransformRenderer == null)
                    {
                        // IGNORE, NO RENDERER!
                        continue;
                    }

                    if (!_DumpedNames.Contains(item.name))
                    {
                        ModConsole.Log("Found Object [ " + item.name + " ] in " + username + "'s avatar", ConsoleColor.Yellow);
                        _DumpedNames.Add(item.name);
                    }
                }
            }
        }

        public static void Material_Object_Dumper(Transform Body, Player player)
        {
            AvatarHelper.CheckTransform(Body.transform);
            var username = GetDisplayName(player);
            //Don't Check This Player's GameObjects As None Were Found
            if (AvatarHelper._GameObjects == null)
            {
                ModConsole.Log("Failed to find Objects for User : " + username);
                return;
            }
            _DumpedNames = new List<string>();

            ModConsole.Log("Dumping Materials ...", ConsoleColor.Green);

            foreach (var obj in AvatarHelper._GameObjects)
            {
                if (obj != null)
                {
                    var item = obj.gameObject;
                    var TransformRenderer = item.GetComponentInChildren<Renderer>();
                    var GameObjectRenderer = obj.GetComponentInChildren<Renderer>();
                    if (GameObjectRenderer == null || TransformRenderer == null)
                    {
                        // IGNORE, NO RENDERER!
                        continue;
                    }

                    if (!_DumpedNames.Contains(TransformRenderer.material.name))
                    {
                        ModConsole.Log("Found Material [ " + TransformRenderer.material.name + " ] in " + username + "'s avatar", ConsoleColor.Yellow);
                        _DumpedNames.Add(TransformRenderer.name);
                    }
                }
            }
        }

        public static void OnLateUpdate()
        {
        }


        public static void OnUpdate()
        {
        }


        public static void MakePlayerAvatarInteractable(AnalyzedAvatar playeravi)
        {

        }

    
        public static string GetDisplayName(Player player)
        {
            return player.GetAPIUser().displayName;
        }



        public static void DumpSelectedAviComponents()
        {
            var apiuser = QuickMenuUtils.GetSelectedUser();
            if (apiuser != null)
            {
                var ScannedUser = _AnalyzedPlayers.Where(x => x.player.GetAPIUser().id == apiuser.id).DefaultIfEmpty(null).First();
                if (ScannedUser != null)
                {
                    ModConsole.Log("Dumping renderer components in player : " + ScannedUser.player.field_Private_APIUser_0.displayName);
                    MelonCoroutines.Start(AvatarDumper(ScannedUser.Avatar, ScannedUser.player));
                }
            }
        }



        public static void PickupAviObjects()
        {
            var apiuser = QuickMenuUtils.GetSelectedUser();
            if (apiuser != null)
            {
                var ScannedUser = _AnalyzedPlayers.Where(x => x.player.GetAPIUser().id == apiuser.id).DefaultIfEmpty(null).First();
                if (ScannedUser != null)
                {
                    MelonCoroutines.Start(AvatarPickup(ScannedUser.Avatar, ScannedUser.player));
                }
            }
        }


        public static void InitButtons(QMNestedButton main, float x, float y, bool btnHalf)
        {
            if (Bools.DisableNSFWMenu)
            {
                return;
            }
            var menu = new QMNestedButton(main, x, y, "Lewd NSFW Revealer", "Lewd Revealer", null, null, null, null, btnHalf);

            
        }

        public static void InitUserMenu(QMNestedButton main, float x, float y)
        {
            if (Bools.DisableNSFWMenu)
            {
                return;
            }
            var menu = new QMNestedButton(main, x, y, "Lewd NSFW Menu", "Lewd Menu", null, null, null, null, false);
                //new QMSingleButton(menu, 1, 0, "Force Lewdify", new Action(ScanPlayerforNSFW), "Scan Player For NSFW.", null, null);
                new QMSingleButton(menu, 3, 0, "Dump Avatar Renderer Components", new Action(DumpSelectedAviComponents), "Print all visible components names in console.", null, null);
                new QMSingleButton(menu, 1, 1, "Add Pickup Component to extra avatar parts (WIP).", new Action(PickupAviObjects), "Pickup Avatar Objects.", null, null);

        }




        private static void ReloadAllAvatars()
        {
            if (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null)
            {
                return;
            }
            foreach (var player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
            {
                    if (player != null && player.field_Internal_VRCPlayer_0 != null)
                    {
                        ReloadAvatar(player.field_Internal_VRCPlayer_0);
                    }
                
            }
        }

        private static void ReloadAvatar(VRCPlayer player)
        {
            if (VRCPlayer.field_Internal_Static_VRCPlayer_0 != null && player != null)
            {
                player.Method_Public_Void_Boolean_0();
            }
        }


        public static void AddPickupComponentsToAvi()
        {
            var apiuser = QuickMenuUtils.GetSelectedUser();
            if (apiuser != null)
            {
                var ScannedUser = _AnalyzedPlayers.Where(x => x.player.GetAPIUser().id == apiuser.id).DefaultIfEmpty(null).First();
                if (ScannedUser != null)
                {
                    ModConsole.Log("Dumping renderer components in player : " + ScannedUser.player.field_Private_APIUser_0.displayName);
                    MelonCoroutines.Start(AvatarDumper(ScannedUser.Avatar, ScannedUser.player));
                }
            }
        }




        public static List<string> _DumpedNames;

        private class AvatarHelper
        {
            public static List<GameObject> _GameObjects;

            //Recursive
            public static void CheckTransform(Transform transform)
            {
                _GameObjects = new List<GameObject>();

                //MelonLoader.MelonLogger.ModConsole.Log("Debug: Start CheckTransform Recursive Checker");
                if (transform == null)
                {
                    ModConsole.Log("Debug: CheckTransform transform is null");
                    return;
                }

                GetChildren(transform);
            }

            public static void GetChildren(Transform transform)
            {
                //MelonLogger.ModConsole.Log("Debug: GetChildren current transform: " + transform.gameObject.name);

                if (!_GameObjects.Contains(transform.gameObject))
                {
                    _GameObjects.Add(transform.gameObject);
                }

                if (transform.name.ToLower().Contains("armature"))
                {
                    return;
                }

                for (var i = 0; i < transform.childCount; i++)
                {
                    GetChildren(transform.GetChild(i));
                }
            }
        }



        public static List<AnalyzedAvatar> _AnalyzedPlayers = new List<AnalyzedAvatar>();
        public static List<string> _NSFWNamePlayer = new List<string>();



        public class AnalyzedAvatar
        {
            public Transform Avatar { get; set; }
            public Player player { get; set; }
            public AnalyzedAvatar(Player player, Transform Avatar)
            {
                this.Avatar = Avatar;
                this.player = player;
            }
        }


    }
}