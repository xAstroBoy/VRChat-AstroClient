using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Cheats.PatronCrackers;
using AstroClient.AstroMonos.Components.Cheats.PatronUnlocker;
using AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents;
using AstroClient.AstroMonos.Components.ESP;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.CheetosUI;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Holders;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape
{
    internal class PrisonEscape : AstroEvents
    {
        internal static QMNestedGridMenu CurrentMenu;
        internal static bool isCurrentWorld = false;

        internal static void InitButtons(QMGridTab main)
        {
            CurrentMenu = new QMNestedGridMenu(main, "Prison Escape Cheats", "Prison Escape Cheats");
        }

        internal static void FindEverything()
        {
            var occluder = GameObjectFinder.FindRootSceneObject("Occlusion");
            
            if(occluder != null)
            {
                occluder.DestroyMeLocal(true);
            }
            if (Yard != null)
            {
                Yard.FindObject("Colliders/Collider").DestroyMeLocal(true); // Remove roof collider only
                Yard.FindObject("Colliders/Collider (1)").DestroyMeLocal(true); // Remove roof collider only

            }

            var guardtower = Yard.FindObject("GuardTower/Colliders");
            if(guardtower != null)
            {
                AdjustGuardTowerBorders(guardtower);
            }
            var guardtower_1 = Yard.FindObject("GuardTower (1)/Colliders");
            if (guardtower_1 != null)
            {
                AdjustGuardTowerBorders(guardtower_1);
            }


            if (Prison != null)
            {
                // Fix Fence Collider height 
                var fence = Prison.FindObject("Building/Basketball Court/Colliders/Collider");
                if(fence != null)
                {
                    FixbaseballFence(fence);
                }
                // Fix Fence Collider height 
                var fence1 = Prison.FindObject("Building/Basketball Court/Colliders/Collider (1)");
                if (fence1 != null)
                {
                    FixbaseballFence(fence1);
                }

                // Remove roof & other useless colliders
                Prison.FindObject("Building/Basketball Court/Colliders/Collider (2)").DestroyMeLocal(true);
                Prison.FindObject("Building/Basketball Court/Colliders/Collider (3)").DestroyMeLocal(true);
                Prison.FindObject("Building/Basketball Court/Colliders/Collider (4)").DestroyMeLocal(true);
                Prison.FindObject("Building/Basketball Court/Colliders/Collider (5)").DestroyMeLocal(true);
                Prison.FindObject("Building/Basketball Court/Colliders/Collider (6)").DestroyMeLocal(true);
                Prison.FindObject("Building/Basketball Court/Colliders/Collider (7)").DestroyMeLocal(true);
                Prison.FindObject("Building/Basketball Court/Colliders/Collider (8)").DestroyMeLocal(true);


                var fence3 = Prison.FindObject("Building/Back Area/Colliders/Collider");
                if (fence3 != null)
                {
                    FixBackAreaFence(fence1);
                }
                var fence4 = Prison.FindObject("Building/Back Area/Colliders/Collider (1)");
                if (fence4 != null)
                {
                    FixBackAreaFence(fence1);
                }

                // Kitchen Roof
                Prison.FindObject("Building/Back Area/Colliders/Collider (2)").DestroyMeLocal(true);

                
            }


            if (MoneyPile != null)
            {
                MoneyInteraction = MoneyPile.FindUdonEvent("_interact");
                if (MoneyInteraction != null)
                {
                    Remove_MaxPickupDist(MoneyInteraction); // Get Rid of the anti-cheat!
                }
            }

            if (Keycard != null)
            {
                GetRedCard = Keycard.FindUdonEvent("_interact");
                if (GetRedCard != null)
                {
                    Remove_MaxPickupDist(GetRedCard); // Get Rid of the anti-cheat!
                }

            }

            if (Gate_Button != null)
            {
                GateInteraction = Gate_Button.FindUdonEvent("_interact");
            }

            if (Vents != null)
            {
                foreach (var triggervent in Vents.Get_UdonBehaviours())
                {
                    var interactevent = triggervent.FindUdonEvent("_interact");
                    if (interactevent != null)
                    {
                        if (interactevent.name.Equals("Trigger"))
                        {
                            Remove_maxUseDist(interactevent);
                        }
                    }
                }
            }

            foreach (var item in Player_Object_Pool.transform.Get_UdonBehaviours())
            {

                var obj = item.FindUdonEvent("_SetWantedSynced");
                if (obj != null)
                {
                    var reader = obj.transform.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                    if (reader != null)
                    {
                        if (!CurrentReaders.Contains(reader))
                        {
                           // ModConsole.DebugLog($"Found Behaviour with name {obj.gameObject.name}, having Event _SetWantedSynced");
                            CurrentReaders.Add(reader);
                        }
                    }
                }
            }

            foreach (var item in WorldUtils.Pickups)
            {
                var beh = item.gameObject.FindUdonEvent("EnablePatronEffects");
                if(beh != null)
                {
                    EnableGoldenCamos.Add(beh);
                }
            }

            int WantedTriggersRegistered = 0;

            foreach (var item in WorldUtils.UdonScripts)
            {

                if (item.name.Contains("Crate"))
                {
                    if (item.name.Contains("Crate Large"))
                    {
                        Crates.AddGameObject(item.gameObject);
                        CreateSpawnItemButton(item);
                    }

                    if(item.name.Contains("Crate Small"))
                    {
                        CreateSpawnItemButton(item);
                    }
                }
                // Not Reliable.
                //if(item.name.StartsWith("Wanted Trigger"))
                //{
                //    var WantedDetector = item.GetOrAddComponent<PrisonEscape_WantedDetector>();
                //    if(WantedDetector != null)
                //    {
                //        WantedTriggersRegistered++;
                //    }
                //}

                if (item.name.Contains("Knife"))
                {
                    var knife = item.FindUdonEvent("PlayMeleeEffects");
                    if (knife != null)
                    {
                        if (!Knifes.Contains(knife))
                        {
                            Knifes.Add(knife);
                        }
                    }
                }

                if (item.name.Contains("VentMesh"))
                {
                    var ventmesh = item.FindUdonEvent("_interact");
                    if (ventmesh != null)
                    {
                        if (!VentsMeshes.Contains(ventmesh))
                        {
                            VentsMeshes.Add(ventmesh);
                        }
                    }
                }

                if (item.name.Equals("Patron Control"))
                {
                    PatronController = item.GetOrAddComponent<Ostinyo_World_PatronCracker>(); // Fuck u Ostinyo 
                    TogglePatronGuns = item.FindUdonEvent("_TogglePatronGuns");
                    ToggleDoublePoints = item.FindUdonEvent("_ToggleDoublePoints");

                }
            }

            foreach (var item in Prisoner_Spawns.Get_Childs())
            {
                if (!SpawnPoints_Prisoners.Contains(item.position))
                {
                    SpawnPoints_Prisoners.Add(item.position);
                }
            }

            foreach (var item in Guard_Spawns.Get_Childs())
            {
                if (!SpawnPoints_Guards.Contains(item.position))
                {
                    SpawnPoints_Guards.Add(item.position);
                }
            }
            foreach (var item in Respawn_Points.Get_Childs())
            {
                if (!SpawnPoints_Spawn.Contains(item.position))
                {
                    SpawnPoints_Spawn.Add(item.position);
                }
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<VRC_SceneDescriptor>())
            {
                if (item != null)
                {
                    foreach (var spawn in item.spawns)
                    {
                        if (!SpawnPoints_Spawn.Contains(spawn.position))
                        {
                            SpawnPoints_Spawn.Add(spawn.position);
                        }
                    }
                    if (!SpawnPoints_Spawn.Contains(item.SpawnPosition))
                    {
                        SpawnPoints_Spawn.Add(item.SpawnPosition);
                    }
                    AddSpawnPointDetector(item.SpawnPosition, PrimitiveType.Sphere, 50f, PrisonEscape_Roles.Dead);


                    if (item.SpawnLocation != null)
                    {
                        if (!SpawnPoints_Spawn.Contains(item.SpawnLocation.position))
                        {
                            SpawnPoints_Spawn.Add(item.SpawnLocation.position);
                        }
                    }
                }
            }
            foreach (var item in WorldUtils.Pickups)
            {
                if (item.name.Contains("Sniper"))
                {
                    var MuzzlePos = item.transform.FindObject("Mesh/Muzzle Loc");
                    if (MuzzlePos != null)
                    {
                        var laser = MuzzlePos.AddComponent<LaserPointer>();
                        if (laser != null)
                        {
                            laser.ChangeOnPlayerHit = true;
                            laser.ShowEndPointSphere = true;
                        }
                    }
                    // item.AddComponent<PrisonEscape_AimAssister>();
                }

                if (item.name.Contains("RPG"))
                {
                    var MuzzlePos = item.transform.FindObject("Rocket");
                    if (MuzzlePos != null)
                    {
                        var laser = MuzzlePos.AddComponent<LaserPointer>();
                        if (laser != null)
                        {
                            laser.ChangeOnPlayerHit = true;
                            laser.ShowEndPointSphere = true;
                            laser.SphereSize = 5f;
                        }
                    }
                }
            }



            ModConsole.DebugLog($"Registered {CurrentReaders.Count} Player Data Readers!", System.Drawing.Color.Chartreuse);

            ModConsole.DebugLog($"Registered {SpawnPoints_Spawn.Count} Spawn Area Positions!", System.Drawing.Color.Chartreuse);
            ModConsole.DebugLog($"Registered {SpawnPoints_Guards.Count} Guard Spawn Positions!", System.Drawing.Color.Chartreuse);
            ModConsole.DebugLog($"Registered {SpawnPoints_Prisoners.Count} Prisoner Spawn Positions!", System.Drawing.Color.Chartreuse);
            ModConsole.DebugLog($"Registered {WantedTriggersRegistered} Wanted Triggers Detectors!", System.Drawing.Color.Chartreuse);


            AddSpawnDetector(SpawnPoints_Guards, PrimitiveType.Sphere, 3, PrisonEscape_Roles.Guard);
            AddSpawnDetector(SpawnPoints_Prisoners, PrimitiveType.Sphere, 3, PrisonEscape_Roles.Prisoner);
            //AddSpawnDetector(SpawnPoints_Spawn, PrimitiveType.Cube, 10f, PrisonEscape_Roles.Dead);
            //if (Game_Join_Trigger != null)
            //{
            //    BindRoleToCollider(Game_Join_Trigger, PrisonEscape_Roles.Dead); 
            //}
        }

        private static void CreateSpawnItemButton(UdonBehaviour item)
        {
            var udonevent = item.FindUdonEvent("_SpawnItem");
            if (udonevent != null)
            {
                var btn = new WorldButton(item.transform.position + new Vector3(-1, 1f, 0), item.transform.rotation, "Spawn Weapon", () => { udonevent.InvokeBehaviour(); });
                if (btn != null)
                {
                    btn.FixPlayercollisions();
                    var rend = udonevent.gameObject.GetGetInChildrens<Renderer>(true);;
                    if (rend != null)
                    {
                        btn.ButtonObject.transform.parent = rend.transform;
                        // Flip Button On the other side.

                        Vector3 rot = btn.ButtonObject.transform.rotation.eulerAngles;
                        rot = new Vector3(rot.x, rot.y + 180, rot.z);
                        btn.ButtonObject.transform.rotation = Quaternion.Euler(rot);

                    }
                }
            }

        }

        /// <summary>
        ///  This will shrink the border colliders on The guard tower and Adjust their position to allow the player to jump out of the tower!

        /// </summary>
        /// <param name="tower"></param>
        private static void AdjustGuardTowerBorders(GameObject tower)
        {
            foreach(var item in tower.GetComponentsInChildren<BoxCollider>())
            {
                if (item != null)
                {
                    if (item != null)
                    {
                        item.extents = new Vector3(item.extents.x, 0.2f, item.extents.z);
                        item.transform.localPosition = new Vector3(item.transform.localPosition.x, 10.9f, item.transform.localPosition.z);
                    }
                }

            }
        }


        /// <summary>
        ///  This will shrink the border colliders on The guard tower and Adjust their position to allow the player to jump out of the Fence!
        /// </summary>
        /// <param name="fence"></param>
        
        private static void FixbaseballFence(GameObject fence)
        {
            if (fence != null)
            {
                var box = fence.GetComponent<BoxCollider>();
                if (box != null)
                {
                    box.extents = new Vector3(box.extents.x, 0.3f, box.extents.z);
                    box.transform.localPosition = new Vector3(box.transform.localPosition.x, 2f, box.transform.localPosition.z);
                }
            }

        }
        /// <summary>
        ///  This will shrink the border colliders on The guard tower and Adjust their position to allow the player to jump out of the Fence!
        /// </summary>
        /// <param name="fence"></param>

        private static void FixBackAreaFence(GameObject fence)
        {
            if (fence != null)
            {
                var box = fence.GetComponent<BoxCollider>();
                if (box != null)
                {
                    box.extents = new Vector3(box.extents.x, 0.4f, box.extents.z);
                    box.transform.localPosition = new Vector3(box.transform.localPosition.x, 2f, box.transform.localPosition.z);
                }
            }

        }        
        /// <summary>
        ///  This will add a Trigger collider to assign a role once a player hits it!
        /// </summary>

        private static void AddSpawnDetector(List<Vector3> positions, PrimitiveType detectorshape, float scale,  PrisonEscape_Roles AssignedRole)
        {
            foreach (var pos in positions)
            {
                AddSpawnPointDetector(pos, detectorshape, scale, AssignedRole);
            }
        }

        private static void BindRoleToCollider(GameObject obj, PrisonEscape_Roles AssignedRole)
        {
            var setup = ComponentUtils.GetOrAddComponent<PrisonEscape_CollisionDetector>(obj);
            if (setup != null)
            {
                setup.AssignedRole = AssignedRole;
            }
        }

        private static void AddSpawnPointDetector(Vector3 position, PrimitiveType detectorshape, float scale , PrisonEscape_Roles AssignedRole)
        {
            GameObject sphere = GameObject.CreatePrimitive(detectorshape);
            sphere.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            sphere.name = AssignedRole.ToString() + " SpawnPoint Detector";
            sphere.transform.position = position;
            sphere.transform.localScale = new Vector3(scale, scale, scale);
            foreach (var col in sphere.GetComponents<Collider>())
            {
                col.isTrigger = true;
            }
            foreach (var ren in sphere.GetComponents<Renderer>())
            {
                ren.DestroyMeLocal(true);
            }
            BindRoleToCollider(sphere, AssignedRole);

        }


        internal override void OnPlayerJoined(Player player)
        {
            if (isCurrentWorld)
            {
                ComponentUtils.GetOrAddComponent<PrisonEscape_ESP>(player.gameObject);

            }
        }



        internal static List<Vector3> SpawnPoints_Guards = new List<Vector3>();
        internal static List<Vector3> SpawnPoints_Prisoners = new List<Vector3>();
        internal static List<Vector3> SpawnPoints_Spawn = new List<Vector3>();

        internal static List<UdonBehaviour_Cached> EnableGoldenCamos = new List<UdonBehaviour_Cached>();

        //internal static PrisonEscape_Roles GetRoleFromPos(Vector3 pos)
        //{
        //    if (IsPrisoner(pos))
        //    {
        //        return PrisonEscape_Roles.Prisoner;
        //    }

        //    if (isGuard(pos))
        //    {
        //        return PrisonEscape_Roles.Guard;
        //    }
        //    return PrisonEscape_Roles.None;
        //}


        //internal static bool IsPrisoner(Vector3 position)
        //{
        //    if (SpawnPoints_Prisoners != null)
        //    {
        //        if (SpawnPoints_Prisoners.Count != 0)
        //        {
        //            foreach (var pos in SpawnPoints_Prisoners)
        //            {
        //                var dist = Vector3.Distance(pos, position);
        //                //ModConsole.DebugLog($"Calculated Distance is {dist}");
        //                if (dist.CheckRange(1, 30f))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }

        //    return false;
        //}

        //internal static bool isGuard(Vector3 position)
        //{
        //    if (SpawnPoints_Guards != null)
        //    {
        //        if (SpawnPoints_Guards.Count != 0)
        //        {
        //            foreach (var pos in SpawnPoints_Guards)
        //            {
        //                var dist = Vector3.Distance(pos, position);
        //               // ModConsole.DebugLog($"Calculated Distance is {dist}");
        //                if (dist.CheckRange(1, 30f))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }

        //    return false;

        //    return false;
        //}

        private static List<PrisonEscape_PoolDataReader> CurrentReaders { get; set; } = new();


        internal static PrisonEscape_PoolDataReader FindAssignedUser(Player player, bool SuppressLogs = false, PrisonEscape_Roles TargetRole = PrisonEscape_Roles.Dead)
        {

            foreach (var item in CurrentReaders)
            {
                var actualreader = GetCorrectReader(item);
                if (actualreader != null)
                {

                    //if (!actualreader.isPlaying.GetValueOrDefault(false)) continue;
                    if (actualreader.playerName == player.GetAPIUser().displayName)
                    {

                        switch (TargetRole)
                        {
                            case PrisonEscape_Roles.Prisoner:
                            {
                                if (!actualreader.isGuard.GetValueOrDefault(false))
                                {
                                    if (!SuppressLogs)
                                    {
                                        ModConsole.DebugLog($"Found {player.GetDisplayName()} player Data Reader : {actualreader.gameObject.name}!", System.Drawing.Color.GreenYellow);
                                    }

                                    return actualreader;
                                }

                                break;
                            }

                            case PrisonEscape_Roles.Guard:
                            {
                                if (actualreader.isGuard.GetValueOrDefault(false))
                                {
                                    if (!SuppressLogs)
                                    {
                                        ModConsole.DebugLog($"Found {player.GetDisplayName()} player Data Reader : {actualreader.gameObject.name}!", System.Drawing.Color.GreenYellow);
                                    }

                                    return actualreader;
                                }

                                break;
                            }
                            case PrisonEscape_Roles.Dead:
                                {
                                    if (item.isDead.GetValueOrDefault(false))
                                    {
                                        if (!SuppressLogs)
                                        {
                                            ModConsole.DebugLog($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
                                        }

                                        return item;
                                    }
                                    break;
                                }
                        }

                    }
                    else if (item.playerName == player.GetAPIUser().displayName)
                    {

                        switch (TargetRole)
                        {
                            case PrisonEscape_Roles.Prisoner:
                            {
                                if (!item.isGuard.GetValueOrDefault(false))
                                {
                                    if (!SuppressLogs)
                                    {
                                        ModConsole.DebugLog($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
                                    }

                                    return item;
                                }

                                break;
                            }

                            case PrisonEscape_Roles.Guard:
                            {
                                if (item.isGuard.GetValueOrDefault(false))
                                {
                                    if (!SuppressLogs)
                                    {
                                            ModConsole.DebugLog($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
                                    }

                                    return item;
                                }

                                break;
                            }
                            case PrisonEscape_Roles.Dead:
                                {
                                    if (item.isDead.GetValueOrDefault(false))
                                    {
                                        if (!SuppressLogs)
                                        {
                                            ModConsole.DebugLog($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
                                        }

                                        return item;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }

            return null;
        }

        private static PrisonEscape_PoolDataReader LocalReader { get; set; }
        internal static PrisonEscape_PoolDataReader GetLocalReader()
        {
            if (LocalReader != null)
            {
                if (!LocalReader.isLocal)
                {
                    ModConsole.DebugLog($"Local Reader Changed, Resetting!");
                    LocalReader = null;
                }
            }

            if (LocalReader == null)
            {
                foreach (var item in CurrentReaders)
                {
                    var actualreader = GetCorrectReader(item);
                    if (actualreader != null)
                    {

                        if (actualreader.isLocal)
                        {
                            ModConsole.DebugLog($"Found Local player Data Reader : {actualreader.gameObject.name} !", System.Drawing.Color.GreenYellow);
                            return LocalReader = actualreader;
                        }
                        else if (item.isLocal)
                        {
                            ModConsole.DebugLog($"Found Local player Data Reader : {item.gameObject.name} !", System.Drawing.Color.GreenYellow);
                            return LocalReader = actualreader;
                        }

                    }
                }
            }
            return LocalReader;
        }


        internal static PrisonEscape_PoolDataReader GetCorrectReader(PrisonEscape_PoolDataReader reader)
        {
            if (reader != null)
            {
                if (reader.GetActualDataReader != null)
                {
                    if (reader != reader.GetActualDataReader)
                    {
                        return GetCorrectReader(reader.GetActualDataReader);
                    }
                    else
                    {
                        return reader;
                    }
                }
            }
            return null;
        }


        private static List<UdonBehaviour_Cached> Knifes = new List<UdonBehaviour_Cached>();
        private static List<UdonBehaviour_Cached> VentsMeshes = new List<UdonBehaviour_Cached>();


        private static PrisonEscape_PoolDataReader _LocalPlayerData;
        
        private static bool _DropKnifeAfterKill = true;

        internal static bool DropKnifeAfterKill
        {
            get
            {
                return _DropKnifeAfterKill;
            }
            set
            {
                if (Knifes == null || Knifes.Count == 0)
                {
                    value = false;
                }
                _DropKnifeAfterKill = value;
                if (Knifes != null)
                {
                    if (Knifes.Count != 0)
                    {
                        foreach (var knife in Knifes)
                        {
                            SetDropOnUse(knife, value);
                        }
                    }
                }

            }
        }


        private static bool _GuardsAreAllowedToUseVents = false;

        internal static bool GuardsAreAllowedToUseVents
        {
            get
            {
                return _GuardsAreAllowedToUseVents;
            }
            set
            {
                if (VentsMeshes == null || VentsMeshes.Count == 0)
                {
                    value = false;
                }
                _GuardsAreAllowedToUseVents = value;
                if (VentsMeshes != null)
                {
                    if (VentsMeshes.Count != 0)
                    {
                        foreach (var ventmesh in VentsMeshes)
                        {
                            SetGuardsCanUse(ventmesh, value);
                        }
                    }
                }

            }
        }

        internal static bool? isPatron
        {
            get
            {
                if (PatronController != null) return PatronController.isPatron;
                return null;
            }
            set
            {
                var newvalue = value.GetValueOrDefault(false);
                if (PatronController != null)
                {
                    PatronController.SetAsPatron(newvalue);
                }

            }
        }



        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.PrisonEscape))
            {
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(true);
                    CurrentMenu.SetTextColor(Color.green);
                }

                isCurrentWorld = true;
                FindEverything();
            }
            else
            {
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(false);
                    CurrentMenu.SetTextColor(Color.red);
                }

                isCurrentWorld = false;
            }
        }

        internal override void OnRoomLeft()
        {
            isCurrentWorld = false;
            MoneyInteraction = null;
            GetRedCard = null;
            RedCardBehaviour = null;
            GateInteraction = null;
            _GuardsAreAllowedToUseVents = false;
            _DropKnifeAfterKill = true;
            PatronController = null;            
            ToggleDoublePoints = null;
            TogglePatronGuns = null;
            foreach (var crate in Crates)
            {
                var renderer = crate.GetGetInChildrens<Renderer>(true);
                if (renderer != null)
                {
                    renderer.transform.RemoveComponent<ESP_HighlightItem>();
                }
            }
            LargeCrateESP = false;
            Crates.Clear();
            Knifes.Clear();
            VentsMeshes.Clear();
            _LocalPlayerData = null;
            CurrentReaders.Clear();
            LocalReader = null;
            SpawnPoints_Prisoners.Clear();
            SpawnPoints_Guards.Clear();
            _EveryoneHasdoublePoints = false;
            SpawnPoints_Spawn.Clear();
            EnableGoldenCamos.Clear();
        }
        private static void SetGuardsCanUse(UdonBehaviour_Cached item, bool CanUse)
        {
            if (item != null)
            {
                try
                {

                    ModConsole.DebugLog($"Setting {item.name} guardsCanUse to {CanUse}");
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "guardsCanUse", CanUse);
                    }
                }
                catch
                {
                }
            }
        }

        private static bool _EveryoneHasdoublePoints { get; set; }
        internal static bool EveryoneHasdoublePoints
        {
            get
            {
                return _EveryoneHasdoublePoints;
            }
            set
            {
                _EveryoneHasdoublePoints = value;
                Set_doublePoints(value);

            }
        }



        private static void Set_doublePoints(bool doublePoints)
        {
            try
            {
                foreach (var item in CurrentReaders)
                {
                    if (item != null)
                    {
                        if (item.isLocal) continue;
                        item.doublePoints = doublePoints;
                    }
                }

            }
            catch
            {
            }
        }


        private static void SetDropOnUse(UdonBehaviour_Cached item, bool dropOnUse)
        {
            if (item != null)
            {
                try
                {

                    ModConsole.DebugLog($"Setting {item.name} dropOnUse to {dropOnUse}");
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "guardsCanUse", dropOnUse);
                    }
                }
                catch
                {
                }
            }
        }

        private static void Remove_MaxPickupDist(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                try
                {

                    ModConsole.DebugLog($"Setting {item.name} maxPickupDist to 999999999");
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "maxPickupDist", 999999999f);
                    }
                }
                catch
                {
                }
            }
        }

        private static void Remove_maxUseDist(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                try
                {
                    ModConsole.DebugLog($"Setting {item.name} maxUseDist to 999999999");
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "maxUseDist", 999999999f);
                    }
                }
                catch{}
            }
        }

        private static bool _LargeCrateESP = false;

        internal static bool LargeCrateESP
        {
            get
            {
                return _LargeCrateESP;
            }
            set
            {
                _LargeCrateESP = value;
                ToggleLargeCrateESP(value);
            }
        }

        private static void ToggleLargeCrateESP(bool isOn)
        {
            foreach (var crate in Crates)
            {
                var renderer = crate.GetGetInChildrens<Renderer>(true);
                if (renderer != null)
                {
                    if (isOn)
                    {
                        renderer.transform.GetOrAddComponent<ESP_HighlightItem>();
                    }
                    else
                    {
                        renderer.transform.RemoveComponent<ESP_HighlightItem>();
                    }
                }
            }
        }


        internal static void TakeKeyCard()
        {
            if (GetRedCard != null)
            {
                if (RedCardBehaviour == null)
                {
                    // Check if Taken, if so set the heap value back to false.
                    RedCardBehaviour = GetRedCard.UdonBehaviour.ToRawUdonBehaviour();
                }

                if (RedCardBehaviour != null)
                {
                    var isTaken = UdonHeapParser.Udon_Parse<bool>(RedCardBehaviour, "taken");
                    if (isTaken)
                    {
                        UdonHeapEditor.PatchHeap(RedCardBehaviour, "taken", false);
                    }
                }

                GetRedCard.InvokeBehaviour();

            }
        }


        internal static Ostinyo_World_PatronCracker PatronController { get; set; }

        private static RawUdonBehaviour RedCardBehaviour = null;
        internal static UdonBehaviour_Cached MoneyInteraction = null;
        internal static UdonBehaviour_Cached GateInteraction = null;

        internal static UdonBehaviour_Cached TogglePatronGuns = null;
        internal static UdonBehaviour_Cached ToggleDoublePoints = null;

        private static UdonBehaviour_Cached GetRedCard = null;
        private static List<GameObject> Crates { get; set; } = new List<GameObject>();


        private static GameObject _Spawn_Area;

        internal static GameObject Spawn_Area
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Spawn_Area == null)
                    {
                        return _Spawn_Area = GameObjectFinder.FindRootSceneObject("Spawn Area");
                    }
                    return _Spawn_Area;
                }

                return null;
            }
        }


        private static GameObject _Respawn_Points;
        internal static GameObject Respawn_Points
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Respawn_Points == null)
                    {
                        return _Respawn_Points = Spawn_Area.FindObject("Respawn Points");
                    }
                    return _Respawn_Points;
                }

                return null;
            }
        }


        private static GameObject _Game_Join_Trigger;
        internal static GameObject Game_Join_Trigger
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Game_Join_Trigger == null)
                    {
                        return _Game_Join_Trigger = Spawn_Area.FindObject("Game Join Trigger");
                    }
                    return _Game_Join_Trigger;
                }

                return null;
            }
        }

        private static GameObject _Scripts;

        internal static GameObject Scripts
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Scripts == null)
                    {
                        return _Scripts = GameObjectFinder.FindRootSceneObject("Scripts");
                    }
                    return _Scripts;
                }

                return null;
            }
        }

        private static GameObject _Player_Object_Pool;
        internal static GameObject Player_Object_Pool
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Player_Object_Pool == null)
                    {
                        return _Player_Object_Pool = Scripts.FindObject("Player Object Pool");
                    }
                    return _Player_Object_Pool;
                }

                return null;
            }
        }



        private static GameObject _Openables;

        internal static GameObject Openables
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Openables == null)
                    {
                        return _Openables = GameObjectFinder.FindRootSceneObject("Openables");
                    }
                    return _Openables;
                }

                return null;
            }
        }


        private static GameObject _Vents;
        internal static GameObject Vents
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Vents == null)
                    {
                        return _Vents = Openables.FindObject("Vents");
                    }
                    return _Vents;
                }

                return null;
            }
        }

        private static GameObject _Prison;

        internal static GameObject Prison
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Prison == null)
                    {
                        return _Prison = GameObjectFinder.FindRootSceneObject("Prison");
                    }
                    return _Prison;
                }

                return null;
            }
        }


        private static GameObject _Gate_Button;
        internal static GameObject Gate_Button
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Gate_Button == null)
                    {
                        return _Gate_Button = Guard_Booth.FindObject("Gate Button");
                    }
                    return _Gate_Button;
                }

                return null;
            }
        }

        private static GameObject _Guard_Booth;
        internal static GameObject Guard_Booth
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Guard_Booth == null)
                    {
                        return _Guard_Booth = Yard.FindObject("Guard Booth");
                    }
                    return _Guard_Booth;
                }

                return null;
            }
        }


        private static GameObject _Yard;
        internal static GameObject Yard
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Prison == null) return null;
                    if (_Yard == null)
                    {
                        return _Yard = Prison.FindObject("Yard");
                    }
                    return _Yard;
                }

                return null;
            }
        }


        private static GameObject _Spawn_Points;
        internal static GameObject Spawn_Points
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Prison == null) return null;
                    if (_Spawn_Points == null)
                    {
                        return _Spawn_Points = Prison.FindObject("Spawn Points");
                    }
                    return _Spawn_Points;
                }

                return null;
            }
        }

        private static GameObject _Cells_Closed_Objects;
        internal static GameObject Cells_Closed_Objects
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Prison == null) return null;
                    if (_Cells_Closed_Objects == null)
                    {
                        return _Cells_Closed_Objects = Prison.FindObject("Cells Closed Objects");
                    }
                    return _Cells_Closed_Objects;
                }

                return null;
            }
        }



        private static GameObject _Prisoner_Spawns;
        internal static GameObject Prisoner_Spawns
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Prison == null) return null;
                    if (_Prisoner_Spawns == null)
                    {
                        return _Prisoner_Spawns = Spawn_Points.FindObject("Prisoner Spawns");
                    }
                    return _Prisoner_Spawns;
                }

                return null;
            }
        }


        private static GameObject _Guard_Spawns;
        internal static GameObject Guard_Spawns
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Prison == null) return null;
                    if (_Guard_Spawns == null)
                    {
                        return _Guard_Spawns = Spawn_Points.FindObject("Guard Spawns");
                    }
                    return _Guard_Spawns;
                }

                return null;
            }
        }




        private static GameObject _ITEMS;

        internal static GameObject ITEMS
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_ITEMS == null)
                    {
                        return _ITEMS = GameObjectFinder.FindRootSceneObject("Items");
                    }
                    return _ITEMS;
                }

                return null;
            }
        }

        private static GameObject _Money;
        internal static GameObject Money
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (ITEMS == null) return null;
                    if (_Money == null)
                    {
                        return _Money = ITEMS.FindObject("Money");
                    }
                    return _Money;
                }

                return null;
            }
        }


        private static GameObject _MoneyPile;
        internal static GameObject MoneyPile
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Money == null) return null;
                    if (_MoneyPile == null)
                    {
                        return _MoneyPile = Money.FindObject("Money Pile");
                    }
                    return _MoneyPile;
                }

                return null;
            }
        }



        private static GameObject _Keycards;
        internal static GameObject Keycards
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (ITEMS == null) return null;
                    if (_Keycards == null)
                    {
                        return _Keycards = ITEMS.FindObject("Keycards");
                    }
                    return _Keycards;
                }

                return null;
            }
        }


        private static GameObject _Keycard;
        internal static GameObject Keycard
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Keycards == null) return null;
                    if (_Keycard == null)
                    {
                        return _Keycard = Keycards.FindObject("Keycard");
                    }
                    return _Keycard;
                }

                return null;
            }
        }


    }
}