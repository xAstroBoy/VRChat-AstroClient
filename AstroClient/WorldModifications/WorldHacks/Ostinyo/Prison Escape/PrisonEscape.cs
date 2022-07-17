using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Cheats.PatronCrackers;
using AstroClient.AstroMonos.Components.Cheats.PatronUnlocker;
using AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents;
using AstroClient.AstroMonos.Components.ESP;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.Tools.Holders;
using AstroClient.Tools.ObjectEditor;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.SDKBase;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape
{
    internal class PrisonEscape : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }


        internal static Action<bool> OnShowRolesPropertyChanged { get; set; }
        internal static Action OnForceWantedEnabled { get; set; }

        private static bool _ShowRoles = false;
        internal static bool ShowRoles
        {
            get => _ShowRoles;
            set
            {
                _ShowRoles = value;
                OnShowRolesPropertyChanged.SafetyRaiseWithParams(value);
            }
            
        }

        private static bool _DoorsStayOpen = false;
        internal static bool DoorsStayOpen
        {
            get => _DoorsStayOpen;
            set
            {
                _DoorsStayOpen = value;
            }

        }

        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnPlayerJoin += OnPlayerJoined;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerJoin -= OnPlayerJoined;

                    }
                }
                _HasSubscribed = value;
            }
        }

        internal static QMNestedGridMenu CurrentMenu;
        private static bool _IsCurrentWorld = false;
        internal static bool isCurrentWorld
        {
            get => _IsCurrentWorld;
            set
            {
                _IsCurrentWorld = value;
                if (!value)
                {
                    DoorsStayOpen = false;
                    OnShowRolesPropertyChanged = null;
                    ShowRoles = false;
                    MoneyInteraction = null;
                    GetRedCard = null;
                    RedCardBehaviour = null;
                    GateInteraction = null;
                    _GuardsAreAllowedToUseVents = false;
                    _DropKnifeAfterKill = true;
                    _FreeCratesItems = false;
                    PatronController = null;
                    ToggleDoublePoints = null;
                    TogglePatronGuns = null;
                    foreach (var crate in Large_Crates)
                    {
                        var renderer = crate.GetGetInChildrens<Renderer>(true);
                        if (renderer != null)
                        {
                            renderer.transform.RemoveComponent<ESP_HighlightItem>();
                        }
                    }
                    foreach (var crate in Small_Crates)
                    {
                        var renderer = crate.GetGetInChildrens<Renderer>(true);
                        if (renderer != null)
                        {
                            renderer.transform.RemoveComponent<ESP_HighlightItem>();
                        }
                    }

                    LargeCrateESP = false;
                    SmallCrateESP = false;
                    Large_Crates.Clear();
                    Small_Crates.Clear();
                    Large_Crates_udon.Clear();
                    Small_Crates_udon.Clear();
                    Knifes.Clear();
                    VentsMeshes.Clear();
                    CurrentReaders.Clear();
                    LocalReader = null;
                    SpawnPoints_Prisoners.Clear();
                    SpawnPoints_Guards.Clear();
                    _EveryoneHasGoldenGunCamos = false;
                    SpawnPoints_Spawn.Clear();
                    EnableGoldenCamos.Clear();
                    TakeKeyCardOnSuspicious = false;
                    TakeKeyCardOnWanted = false;
                    PrisonDoors_Open.Clear();
                    PrisonDoors_Close.Clear();
                    WorldSettings_DoublePoints_Toggle = null;
                    WorldSettings_GoldenGuns_Toggle = null;
                    WorldSettings_Subtitles_Toggle = null;
                    Gun_Blue_Color_Button = null;
                    Gun_Green_Color_Button = null;
                    Gun_Purple_Color_Button = null;
                    Gun_Gold_Color_Button = null;
                    Gun_Red_Color_Button = null;


                }
            }
        }

        internal static void InitButtons(QMGridTab main)
        {
            CurrentMenu = new QMNestedGridMenu(main, "Prison Escape Cheats", "Prison Escape Cheats");
        }

        internal static void FindEverything()
        {

            //var AprilFoolsPatcher = GameObjectFinder.FindRootSceneObject("April Fools");
            //if (AprilFoolsPatcher != null)
            //{
            //    var colliders = AprilFoolsPatcher.FindObject("Meeting Signs");
            //    if (colliders != null)
            //    {
            //        var sign = colliders.FindObject("Meeting Sign");
            //        if (sign != null)
            //        {
            //            sign.IgnoreLocalPlayerCollision(true, true, false);
            //        }

            //        var sign1 = colliders.FindObject("Meeting Sign (1)");
            //        if (sign1 != null)
            //        {
            //            sign1.IgnoreLocalPlayerCollision(true, true, false);
            //        }
            //        var sign2 = colliders.FindObject("Meeting Sign (2)");
            //        if (sign2 != null)
            //        {
            //            sign2.IgnoreLocalPlayerCollision(true, true, false);
            //        }
            //        var sign3 = colliders.FindObject("Meeting Sign (3)");
            //        if (sign3 != null)
            //        {
            //            sign3.IgnoreLocalPlayerCollision(true, true, false);
            //        }
            //        var sign4 = colliders.FindObject("Meeting Sign (4)");
            //        if (sign4 != null)
            //        {
            //            sign4.IgnoreLocalPlayerCollision(true, true, false);
            //        }

            //    }
            //}

            var heightlimiter = Finder.Find("Scripts/Avatar Height Checker");
            if(heightlimiter != null)
            {
                heightlimiter.DestroyMeLocal(true);
            }
                
            var occluder = Finder.FindRootSceneObject("Occlusion");

            if (occluder != null)
            {
                occluder.DestroyMeLocal(true);
            }
            if (Yard != null)
            {
                Yard.FindObject("Colliders/Collider").DestroyMeLocal(true); 
                Yard.FindObject("Colliders/Collider (1)").DestroyMeLocal(true);
                Yard.FindObject("Colliders/Collider (2)").DestroyMeLocal(true); 
                Yard.FindObject("Colliders/Collider (3)").DestroyMeLocal(true); 
                FixOutsideFence(Yard.FindObject("Colliders/Collider (4)"));
                FixOutsideFence(Yard.FindObject("Colliders/Collider (5)"));

            }

            var guardtower = Yard.FindObject("GuardTower/Colliders");
            if (guardtower != null)
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
                if (fence != null)
                {
                    FixbaseballFence(fence);
                }
                // Fix Fence Collider height 
                var fence1 = Prison.FindObject("Building/Basketball Court/Colliders/Collider (1)");
                if (fence1 != null)
                {
                    FixbaseballFence(fence1);
                }
                Prison.FindObject("Guard Objects/Guard Blocker").IgnoreLocalPlayerCollision(true, true, false);
                Prison.FindObject("Guard Objects/Guard Blocker (1)").IgnoreLocalPlayerCollision(true, true, false);
                Prison.FindObject("Guard Objects/Guard Blocker (2)").IgnoreLocalPlayerCollision(true, true, false);
                Prison.FindObject("Guard Objects/Guard Blocker (3)").IgnoreLocalPlayerCollision(true, true, false);
                Prison.FindObject("Guard Objects/Guard Blocker (4)").IgnoreLocalPlayerCollision(true, true, false);
                Prison.FindObject("Guard Objects/Guard Blocker (5)").IgnoreLocalPlayerCollision(true, true, false);
                Prison.FindObject("Guard Objects/Guard Blocker (6)").IgnoreLocalPlayerCollision(true, true, false);


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
                Patch__MaxPickupDist(MoneyPile);
            }

            if (Keycard != null)
            {
                Patch__MaxPickupDist(Keycard);

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
                        Remove_maxUseDist(interactevent);
                    }
                }
            }
            if (Floor_Vents != null)
            {
                foreach (var triggervent in Floor_Vents.Get_UdonBehaviours())
                {
                    var interactevent = triggervent.FindUdonEvent("_interact");
                    if (interactevent != null)
                    {
                        Remove_maxUseDist(interactevent);
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
                            // Log.Debug($"Found Behaviour with name {obj.gameObject.name}, having Event _SetWantedSynced");
                            CurrentReaders.Add(reader);
                        }
                    }
                }
            }

            foreach (var item in WorldUtils.Pickups)
            {

                Patch__MaxPickupDist(item.gameObject);

                var beh = item.gameObject.FindUdonEvent("EnablePatronEffects");
                if (beh != null)
                {

                    var unlocker = item.GetOrAddComponent<PatronUnlocker>();
                    MiscUtils.DelayFunction(5f, () =>
                    {
                        if (unlocker != null)
                        {
                            if (!EnableGoldenCamos.Contains(unlocker))
                            {
                                EnableGoldenCamos.Add(unlocker);
                            }
                        }

                    });
                }
            }

            int WantedTriggersRegistered = 0;

            foreach (var item in WorldUtils.UdonScripts)
            {


                if (item.name.Contains("Crate"))
                {
                    if (item.name.Contains("Crate Large"))
                    {
                        Large_Crates.AddGameObject(item.gameObject);
                        var crateevent = item.FindUdonEvent("_interact");
                        if (crateevent != null)
                        {
                            if (!Large_Crates_udon.Contains(crateevent))
                            {
                                Large_Crates_udon.Add(crateevent);
                            }
                        }

                        //CreateSpawnItemButton(item, false);
                    }

                    if (item.name.Contains("Crate Small"))
                    {
                        Small_Crates.AddGameObject(item.gameObject);
                        var crateevent = item.FindUdonEvent("_interact");
                        if (crateevent != null)
                        {
                            if (!Small_Crates_udon.Contains(crateevent))
                            {
                                Small_Crates_udon.Add(crateevent);
                            }
                        }
                        //CreateSpawnItemButton(item, true);
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

                if (item.name.ToLower().Contains("door"))
                {
                    // Check if The door first contains the same System
                    var unlock = item.FindUdonEvent("_UnlockDoorSynced");
                    if (unlock != null)
                    {
                        // If the unlock is present, add this to bypass the keypad interaction .
                        unlock.gameObject.GetOrAddComponent<PrisonEscape_DoorAssister>();
                    }

                }
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

                if(item.name.Equals("Cell Door"))
                {
                    item.GetOrAddComponent<PrisonEscape_CellDoorToggler>();
                }
                if (item.name.Contains("Game Manager"))
                {
                    var startgame = item.FindUdonEvent("StartGameCountdown");
                    if(startgame != null)
                    {
                        var btn = new WorldButton(new Vector3(-4.4181f, 1.4965f, 14.7982f), new Vector3(0, 270, 0), "<color=red>Start Game</color> \n <color=orange>Bypass Master Lock!</color> ", () =>
                        {
                            startgame.InvokeBehaviour();
                        });
                        btn.SetScale(new Vector3(0.15f, 0.24f, 0.3f));
                    }
                    startgame.gameObject.AddToWorldUtilsMenu();
                    var keycardtake = startgame.UdonBehaviour.FindUdonEvent("_TakeKeycard");
                    if(keycardtake != null)
                    {
                        TakeKeycard = keycardtake;
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

            if (SceneUtils.Spawns != null)
            {
                foreach (var spawn in SceneUtils.Spawns)
                {
                    if (!SpawnPoints_Spawn.Contains(spawn.position))
                    {
                        SpawnPoints_Spawn.Add(spawn.position);
                    }
                }
            }
            AddSpawnPointDetector(SceneUtils.SpawnPosition, PrimitiveType.Sphere, 50f, PrisonEscape_Roles.Dead);


            if (SceneUtils.SpawnLocation != null)
            {
                if (!SpawnPoints_Spawn.Contains(SceneUtils.SpawnLocation.position))
                {
                    SpawnPoints_Spawn.Add(SceneUtils.SpawnLocation.position);
                }
            }


            foreach (var item in WorldUtils.Pickups)
            {
                Patch_canDualWield(item.gameObject);
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
                    item.AddComponent<PrisonEscape_AimAssister>();
                }
                // Worldbuttons for Snipers 
                if (item.name.Equals("Sniper"))
                {
                    #region  Turret 1 Sniper
                    // Turret Respawn Sniper

                    #region  Turret Area
                    var TurretTop = new WorldButton(new Vector3(60.879f, 11.45f, 282.65f), new Vector3(0, 270, 0), "<color=orange>Respawn Sniper</color>", () =>
                    {
                        item.gameObject.RespawnPickup(false);
                    });
                    TurretTop.SetScale(new Vector3(0.15f, 0.2f, 0.3f));

                    #endregion


                    #region  Guard Spawn
                    var GuardArea = new WorldButton(new Vector3(22.9135f, 4.9f, 293.36f), new Vector3(0, 94, 0), "<color=orange>Teleport Sniper</color>", () =>
                    {
                        item.gameObject.SetPosition(new Vector3(22.0804f, 4.925f, 293.2137f), true);
                        item.gameObject.SetRotation(new Vector3(0f, 90f, 0f), true);

                    });
                    GuardArea.SetScale(new Vector3(0.15f, 0.2f, 0.3f));



                    #endregion
                    var Control = item.GetOrAddComponent<PickupController>();
                    if (Control != null)
                    {
                        Control.OnPickupHeld += () =>
                        {
                            var RespawnSniper = $"<color=red>Respawn Sniper</color>{Environment.NewLine}<color=red>Currently Held by {Control.CurrentHolderDisplayName}</color>";
                            var TeleportSniper = $"<color=red>Teleport Sniper</color>{Environment.NewLine}<color=red>Currently Held by {Control.CurrentHolderDisplayName}</color>";

                            if (TurretTop != null)
                            {
                                TurretTop.SetText(RespawnSniper);
                            }
                            if (GuardArea != null)
                            {
                                GuardArea.SetText(TeleportSniper);
                            }

                        };
                        Control.GetOrAddComponent<PickupController>().OnPickupDrop += () =>
                        {
                            var RespawnSniper = "<color=orange>Respawn Sniper</color>";
                            var TeleportSniper = "<color=orange>Teleport Sniper</color>";

                            if (TurretTop != null)
                            {
                                TurretTop.SetText(RespawnSniper);
                            }
                            if (GuardArea != null)
                            {
                                GuardArea.SetText(TeleportSniper);
                            }
                        };
                    }
                    #endregion

                }

                if (item.name.Equals("Sniper (1)"))
                {
                    #region  Turret 2 Sniper
                    // Turret Respawn Sniper

                    #region  Turret Area
                    var TurretTop = new WorldButton(new Vector3(60.879f, 11.45f, 317.3293f), new Vector3(0, 90, 0), "<color=orange>Respawn Sniper</color>", () =>
                    {
                        item.gameObject.RespawnPickup(false);
                    });
                    TurretTop.SetScale(new Vector3(0.15f, 0.2f, 0.3f));

                    #endregion


                    #region  Guard Spawn
                    var GuardArea = new WorldButton(new Vector3(20.6418f, 4.91f, 306.7371f), new Vector3(0, 185, 0), "<color=orange>Teleport Sniper</color>", () =>
                    {
                        item.gameObject.SetPosition(new Vector3(22.08039f, 4.925f, 306.7233f), true);
                        item.gameObject.SetRotation(new Vector3(0f, 90f, 0f), true);

                    });
                    GuardArea.SetScale(new Vector3(0.15f, 0.2f, 0.3f));



                    #endregion
                    var Control = item.GetOrAddComponent<PickupController>();
                    if (Control != null)
                    {
                        Control.OnPickupHeld += () =>
                        {
                            var RespawnSniper = $"<color=red>Respawn Sniper</color>{Environment.NewLine}<color=red>Currently Held by {Control.CurrentHolderDisplayName}</color>";
                            var TeleportSniper = $"<color=red>Teleport Sniper</color>{Environment.NewLine}<color=red>Currently Held by {Control.CurrentHolderDisplayName}</color>";

                            if (TurretTop != null)
                            {
                                TurretTop.SetText(RespawnSniper);
                            }
                            if (GuardArea != null)
                            {
                                GuardArea.SetText(TeleportSniper);
                            }

                        };
                        Control.GetOrAddComponent<PickupController>().OnPickupDrop += () =>
                        {
                            var RespawnSniper = "<color=orange>Respawn Sniper</color>";
                            var TeleportSniper = "<color=orange>Teleport Sniper</color>";

                            if (TurretTop != null)
                            {
                                TurretTop.SetText(RespawnSniper);
                            }
                            if (GuardArea != null)
                            {
                                GuardArea.SetText(TeleportSniper);
                            }
                        };
                    }
                    #endregion

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
            
            foreach (var item in Finder.GetRootGameObjectsComponents<Toggle>(true))
            {
                if(item.name.Equals("Toggle Patron Guns"))
                {
                    WorldSettings_GoldenGuns_Toggle = item;
                }
                if(item.name.Equals("Toggle Double Points"))
                {
                    WorldSettings_DoublePoints_Toggle = item;
                }
                if (item.name.Equals("Toggle Visual Hitboxes"))
                {
                    WorldSettings_VisualHitBoxes_Toggle = item;
                }
                if (item.name.Equals("Toggle Subtitles"))
                {
                    WorldSettings_Subtitles_Toggle = item;
                }
                if (item.name.Equals("Toggle Music"))
                {
                    WorldSettings_Music_Toggle = item;
                }

                if (WorldSettings_DoublePoints_Toggle != null && WorldSettings_GoldenGuns_Toggle != null && WorldSettings_VisualHitBoxes_Toggle != null && WorldSettings_Subtitles_Toggle != null && WorldSettings_Music_Toggle != null)
                {
                    break;
                }
            }

            if (Spawn_Area != null)
            {
                if (Game_Join_Blocker != null)
                {
                    Game_Join_Blocker.RemoveAllColliders(); // Fuck off annoying shit
                }
                if(Gun_Color_Panel != null)
                {
                    var enabler = Gun_Color_Panel.GetOrAddComponent<Enabler>();
                    if(enabler != null)
                    {
                        enabler.ForceStart();
                    }
                    var GoldButton = Gun_Color_Panel.transform.FindObject("Button Mat0");
                    if (GoldButton != null)
                    {
                        Gun_Gold_Color_Button = GoldButton.GetComponent<Button>();
                    }
                    var GreenButton = Gun_Color_Panel.transform.FindObject("Button Mat1");
                    if (GreenButton != null)
                    {
                        Gun_Green_Color_Button = GreenButton.GetComponent<Button>();
                    }
                    var BlueButton = Gun_Color_Panel.transform.FindObject("Button Mat2");
                    if (BlueButton != null)
                    {
                        Gun_Blue_Color_Button = BlueButton.GetComponent<Button>();
                    }
                    var PurpleButton = Gun_Color_Panel.transform.FindObject("Button Mat3");
                    if (PurpleButton != null)
                    {
                        Gun_Purple_Color_Button = PurpleButton.GetComponent<Button>();
                    }
                    var RedButton = Gun_Color_Panel.transform.FindObject("Button Mat4");
                    if (RedButton != null)
                    {
                        Gun_Red_Color_Button = RedButton.GetComponent<Button>();
                    }

                }
                var blocks = Spawn_Area.FindObject("Building/Colliders");
                if(blocks != null)
                {
                    blocks.DestroyMeLocal();
                }
            }


            Log.Debug($"Registered {CurrentReaders.Count} Player Data Readers!", System.Drawing.Color.Chartreuse);

            Log.Debug($"Registered {SpawnPoints_Spawn.Count} Spawn Area Positions!", System.Drawing.Color.Chartreuse);
            Log.Debug($"Registered {SpawnPoints_Guards.Count} Guard Spawn Positions!", System.Drawing.Color.Chartreuse);
            Log.Debug($"Registered {SpawnPoints_Prisoners.Count} Prisoner Spawn Positions!", System.Drawing.Color.Chartreuse);
            //Log.Debug($"Registered {WantedTriggersRegistered} Wanted Triggers Detectors!", System.Drawing.Color.Chartreuse);


            AddSpawnDetector(SpawnPoints_Guards, PrimitiveType.Sphere, 3, PrisonEscape_Roles.Guard);
            AddSpawnDetector(SpawnPoints_Prisoners, PrimitiveType.Sphere, 3, PrisonEscape_Roles.Prisoner);
            //AddSpawnDetector(SpawnPoints_Spawn, PrimitiveType.Cube, 10f, PrisonEscape_Roles.Dead);
            //if (Game_Join_Trigger != null)
            //{
            //    BindRoleToCollider(Game_Join_Trigger, PrisonEscape_Roles.Dead); 
            //}

            CreateEscapeButton(new Vector3(7.9167f, 1.2052f, 293.6856f), 0, "ESCAPE 1", () => { InteractWithVent("Openable Vent"); });
            CreateEscapeButton(new Vector3(4.0886f, 1.3629f, 294.0434f), 180, "ESCAPE 2", () => { InteractWithVent("Openable Vent (1)"); });

            CreateEscapeButton(new Vector3(-0.0995f, 1.3373f, 293.8687f), 0, "ESCAPE 3", () => { InteractWithVent("Openable Vent (1)"); });
            CreateEscapeButton(new Vector3(-3.9086f, 1.3534f, 294.1103f), 180, "ESCAPE 4", () => { InteractWithFloorVent("Floor Vent"); });

            CreateEscapeButton(new Vector3(-4.0806f, 1.1905f, 306.1707f), 0, "ESCAPE 5", () => { InteractWithVent("Openable Vent (2)"); });

            CreateEscapeButton(new Vector3(4.8376f, 1.1809f, 306.921f), 270, "ESCAPE 6", () => { InteractWithVent("Openable Vent (5)"); });

        }

        private static void InteractWithVent(string VentName)
        {
            if (Vents != null)
            {
                var trigger = Vents.FindObject($"{VentName}/Teleport Trigger/Trigger");
                if (trigger != null)
                {
                    var interact = trigger.FindUdonEvent("_interact");
                    if (interact != null)
                    {
                        interact.InvokeBehaviour();
                    }
                }
            }
        }

        internal static void MarkPrisonersAsWanted()
        {
            OnForceWantedEnabled.SafetyRaise();

        }

        private static void InteractWithFloorVent(string VentName)
        {
            if (Vents != null)
            {
                var trigger = Floor_Vents.FindObject($"{VentName}/Vent Enter/VentMesh");
                if (trigger != null)
                {
                    var interact = trigger.FindUdonEvent("_interact");
                    if (interact != null)
                    {
                        interact.InvokeBehaviour();
                    }
                }
            }
        }


        private static void CreateEscapeButton(Vector3 Position, float rotation, string label, System.Action action)
        {
            // label parameter is only for debug reasons.

            string defaultlabel = "<color=red>ESCAPE!</color>";
            var btn = new WorldButton(Position, new Vector3(0, rotation, 0), defaultlabel, action);

            MiscUtils.DelayFunction(2f, () =>
             {
                //btn.MakePickupable();
                btn.ButtonBody.name = label;
                 if (btn != null)
                 {
                     btn.ButtonBody.transform.eulerAngles = new Vector3(0, rotation, 0);
                 }
             });
        }


        private static void CreateSpawnItemButton(UdonBehaviour item, bool flip)
        {
            var udonevent = item.FindUdonEvent("_SpawnItem");
            if (udonevent != null)
            {
                var rend = udonevent.gameObject.GetGetInChildrens<Renderer>(true); ;
                if (rend != null)
                {
                    var btn = new WorldButton(item.transform.position + new Vector3(-0.5f, 1f, 0), Vector3.zero, rend.transform, "Spawn Weapon", () => { udonevent.InvokeBehaviour(); });

                    //btn.ButtonBody.transform.parent = rend.transform;
                    //// Flip Button On the other side.
                    if (!flip)
                    {
                        btn.RotateButton(90f);
                    }
                    else
                    {
                        btn.RotateButton(180f);
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

        private static void FixOutsideFence(GameObject fence)
        {
            if (fence != null)
            {
                var box = fence.GetComponent<BoxCollider>();
                if (box != null)
                {
                    box.extents = new Vector3(box.extents.x, 0.29f, box.extents.z);
                    box.transform.localPosition = new Vector3(box.transform.localPosition.x, 1.9f, box.transform.localPosition.z);
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


        private void OnPlayerJoined(Player player)
        {
            if (isCurrentWorld)
            {
                ComponentUtils.GetOrAddComponent<PrisonEscape_ESP>(player.gameObject);

            }
        }



        internal static List<Vector3> SpawnPoints_Guards = new List<Vector3>();
        internal static List<Vector3> SpawnPoints_Prisoners = new List<Vector3>();
        internal static List<Vector3> SpawnPoints_Spawn = new List<Vector3>();

        internal static List<PatronUnlocker> EnableGoldenCamos = new List<PatronUnlocker>();

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
        //                //Log.Debug($"Calculated Distance is {dist}");
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
        //               // Log.Debug($"Calculated Distance is {dist}");
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
                                        Log.Debug($"Found {player.GetDisplayName()} player Data Reader : {actualreader.gameObject.name}!", System.Drawing.Color.GreenYellow);
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
                                        Log.Debug($"Found {player.GetDisplayName()} player Data Reader : {actualreader.gameObject.name}!", System.Drawing.Color.GreenYellow);
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
                                            Log.Debug($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
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
                                        Log.Debug($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
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
                                            Log.Debug($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
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
                                            Log.Debug($"Found {player.GetDisplayName()} player Data Reader : {item.gameObject.name}!", System.Drawing.Color.GreenYellow);
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
                    Log.Debug($"Local Reader Changed, Resetting!");
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
                            Log.Debug($"Found Local player Data Reader : {actualreader.gameObject.name} !", System.Drawing.Color.GreenYellow);
                            return LocalReader = actualreader;
                        }
                        else if (item.isLocal)
                        {
                            Log.Debug($"Found Local player Data Reader : {item.gameObject.name} !", System.Drawing.Color.GreenYellow);
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

        #region  Getter/setters From WorldSettings Menu
        internal static bool? WorldSettings_Subtitles
        {
            get
            {
                if (WorldSettings_Subtitles_Toggle != null)
                {
                    return WorldSettings_Subtitles_Toggle.isOn;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (WorldSettings_Subtitles_Toggle != null)
                    {
                        WorldSettings_Subtitles_Toggle.isOn = value.Value;
                    }
                }
            }
        }

        internal static bool? WorldSettings_Music
        {
            get
            {
                if (WorldSettings_Music_Toggle != null)
                {
                    return WorldSettings_Music_Toggle.isOn;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (WorldSettings_Music_Toggle != null)
                    {
                        WorldSettings_Music_Toggle.isOn = value.Value;
                    }
                }
            }
        }



        internal static bool? WorldSettings_VisualHitBoxes
        {
            get
            {
                if (WorldSettings_VisualHitBoxes_Toggle != null)
                {
                    return WorldSettings_VisualHitBoxes_Toggle.isOn;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (WorldSettings_VisualHitBoxes_Toggle != null)
                    {
                        WorldSettings_VisualHitBoxes_Toggle.isOn = value.Value;
                    }
                }
            }
        }



        internal static bool? WorldSettings_GoldenGuns
        {
            get
            {
                if (WorldSettings_GoldenGuns_Toggle != null)
                {
                    return WorldSettings_GoldenGuns_Toggle.isOn;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    // before setting this , let's force patron mode to be on
                    if (!isPatron.GetValueOrDefault(false))
                    {
                        isPatron = true;
                    }
                    if (WorldSettings_GoldenGuns_Toggle != null)
                    {
                        WorldSettings_GoldenGuns_Toggle.isOn = value.Value;
                    }
                }
            }
        }

        internal static bool? WorldSettings_DoublePoints
        {
            get
            {
                if (WorldSettings_DoublePoints_Toggle != null)
                {
                    return WorldSettings_DoublePoints_Toggle.isOn;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    // before setting this , let's force patron mode to be on
                    if (!isPatron.GetValueOrDefault(false))
                    {
                        isPatron = true;
                    }
                    if (WorldSettings_DoublePoints_Toggle != null)
                    {
                        WorldSettings_DoublePoints_Toggle.isOn = value.Value;
                    }
                }
            }
        }


        #endregion


        internal static bool TakeKeyCardOnWanted { get; set; }
        internal static bool TakeKeyCardOnSuspicious { get; set; }
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

        private static bool _FreeCratesItems = false;

        internal static bool FreeCratesItems
        {
            get
            {
                return _FreeCratesItems;
            }
            set
            {
                _FreeCratesItems = value;
                if (Small_Crates_udon != null)
                {
                    if (Small_Crates_udon.Count != 0)
                    {
                        foreach (var crate in Small_Crates_udon)
                        {
                            if (crate != null)
                            {
                                if (value)
                                {
                                    SetunlockPoints(crate, 0);
                                }
                                else
                                {
                                    SetunlockPoints(crate, 200);
                                }
                            }
                        }
                    }
                }
                if (Large_Crates_udon != null)
                {
                    if (Large_Crates_udon.Count != 0)
                    {
                        foreach (var crate in Large_Crates_udon)
                        {
                            if (crate != null)
                            {
                                if (value)
                                {
                                    SetunlockPoints(crate, 0);
                                }
                                else
                                {
                                    SetunlockPoints(crate, 500);
                                }
                            }
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
                ResyncPatronSettings();
            }
        }


        private static void ResyncPatronSettings()
        {
            var reader = GetLocalReader();
            if (reader != null)
            {
                if (WorldSettings_DoublePoints_Toggle != null)
                {
                    WorldSettings_DoublePoints_Toggle.SetIsOnWithoutNotify(reader.doublePoints.GetValueOrDefault(false));
                }
                if (WorldSettings_GoldenGuns_Toggle != null)
                {
                    WorldSettings_GoldenGuns_Toggle.SetIsOnWithoutNotify(reader.goldGuns.GetValueOrDefault(false));
                }

            }
        }


        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
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
                HasSubscribed = true;
            }
            else
            {
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(false);
                    CurrentMenu.SetTextColor(Color.red);
                }

                if (isCurrentWorld)
                {
                    isCurrentWorld = false;
                }
                HasSubscribed = false;
            }
        }

        private void OnRoomLeft()
        {
            if (isCurrentWorld)
            {
                isCurrentWorld = false;
            }
            HasSubscribed = false;
        }
        private static void SetGuardsCanUse(UdonBehaviour_Cached item, bool guardsCanUse)
        {
            if (item != null)
            {
                try
                {

                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "guardsCanUse", guardsCanUse, () =>
                        {
                            Log.Debug($"Setting {item.name} guardsCanUse to {guardsCanUse}");
                        });
                    }
                }
                catch
                {
                }
            }
        }

        private static bool _EveryoneHasGoldenGunCamos { get; set; }
        internal static bool EveryoneHasGoldenGunCamos
        {
            get
            {
                return _EveryoneHasGoldenGunCamos;
            }
            set
            {
                _EveryoneHasGoldenGunCamos = value;
                Set_GoldenGunsUnlocker(value);

            }
        }



        private static void Set_GoldenGunsUnlocker(bool EveryoneHasPatreonPerk)
        {
            foreach (var item in EnableGoldenCamos)
            {

                if (item != null)
                {
                    item.EveryoneHasPatreonPerk = EveryoneHasPatreonPerk;
                }

            }
        }


        private static void SetDropOnUse(UdonBehaviour_Cached item, bool dropOnUse)
        {
            if (item != null)
            {
                try
                {
                    if (item.RawItem != null)
                    {
                       UdonHeapEditor.PatchHeap(item.RawItem, "dropOnUse", dropOnUse, () =>
                       {
                           Log.Debug($"Setting {item.name} dropOnUse to {dropOnUse}");
                       });
                    }
                }
                
                catch
                {
                }
            }
        }
        private static void SetunlockPoints(UdonBehaviour_Cached item, int UnlockPoints)
        {
            if (item != null)
            {
                try
                {
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "unlockPoints", UnlockPoints, () =>
                        {
                            Log.Debug($"Setting {item.name} Price to {UnlockPoints}");
                        });
                    }
                }

                catch
                {
                }
            }
        }

        private static void Patch_canDualWield(GameObject item)
        {

            foreach (var udon in item.GetComponentsInChildren<UdonBehaviour>(true))
            {
                if (udon != null)
                {
                    try
                    {
                        var rawitem = udon.ToRawUdonBehaviour();
                        if (rawitem != null)
                        {

                            UdonHeapEditor.PatchHeap(rawitem, "canDualWield", true, () =>
                            {
                                Log.Debug($"Setting {item.name} canDualWield to true");
                            });
                        }
                    }
                    catch { }
                }
            }
        }
        private static void Patch__MaxPickupDist(GameObject item)
        {

            foreach (var udon in item.GetComponentsInChildren<UdonBehaviour>(true))
            {
                if (udon != null)
                {
                    try
                    {
                        var rawitem = udon.ToRawUdonBehaviour();
                        if (rawitem != null)
                        {

                            UdonHeapEditor.PatchHeap(rawitem, "maxPickupDist", 999999999f, () =>
                            {
                                Log.Debug($"Setting {item.gameObject.name} maxPickupDist to 999999999");
                            });
                        }
                    }
                    catch { }
                }
            }
        }

        private static void Remove_maxUseDist(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                try
                {
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "maxUseDist", 999999999f, () =>
                        {
                            Log.Debug($"Setting {item.name} maxUseDist to 999999999f");
                        });
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

        private static bool _SmallCrateESP = false;

        internal static bool SmallCrateESP
        {
            get
            {
                return _SmallCrateESP;
            }
            set
            {
                _SmallCrateESP = value;
                ToggleSmallCrateESP(value);
            }
        }
        internal static void OpenAllLargeCrates()
        {
            if (!FreeCratesItems)
            {
                FreeCratesItems = true;
            }
            foreach (var CrateBehaviour in Large_Crates_udon)
            {
                if (CrateBehaviour != null)
                {
                    var body = CrateBehaviour.transform.FindObject("Crate");
                    if (body != null)
                    {
                        if (body.gameObject.active)
                        {
                            CrateBehaviour.InvokeBehaviour();
                        }
                    }
                }
            }
        }

        internal static void OpenAllSmallCrates()
        {
            if (!FreeCratesItems)
            {
                FreeCratesItems = true;
            }
            foreach (var CrateBehaviour in Small_Crates_udon)
            {
                if (CrateBehaviour != null)
                { 
                    var body = CrateBehaviour.transform.FindObject("Crate");
                    if (body != null)
                    {
                        if (body.gameObject.active)
                        {
                            CrateBehaviour.InvokeBehaviour();
                        }
                    }
                }
            }
        }



    private static void ToggleLargeCrateESP(bool isOn)
        {
            foreach (var crate in Large_Crates)
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

        private static void ToggleSmallCrateESP(bool isOn)
        {
            foreach (var crate in Small_Crates)
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
            if (TakeKeycard != null)
            {
                TakeKeycard.InvokeBehaviour();
            }
            else
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
        }


        internal static Ostinyo_World_PatronCracker PatronController { get; set; }




        private static GameObject _Spawn_Area;

        internal static GameObject Spawn_Area
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Spawn_Area == null)
                    {
                        return _Spawn_Area = Finder.FindRootSceneObject("Spawn Area");
                    }
                    return _Spawn_Area;
                }

                return null;
            }
        }
        private static GameObject _Gun_Color_Panel;

        internal static GameObject Gun_Color_Panel
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Spawn_Area == null) return null;
                    if (_Gun_Color_Panel == null)
                    {
                        return _Gun_Color_Panel = Spawn_Area.FindObject("Signs/Settings Sign/Panel/Gun Color Panel");
                    }
                    return _Gun_Color_Panel;
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
        private static GameObject _Game_Join_Blocker;
        internal static GameObject Game_Join_Blocker
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Game_Join_Blocker == null)
                    {
                        return _Game_Join_Blocker = Spawn_Area.FindObject("Game Join Blocker");
                    }
                    return _Game_Join_Blocker;
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
                        return _Scripts = Finder.FindRootSceneObject("Scripts");
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
                        return _Openables = Finder.FindRootSceneObject("Openables");
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


        private static GameObject _Floor_Vents;
        internal static GameObject Floor_Vents
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Floor_Vents == null)
                    {
                        return _Floor_Vents = Openables.FindObject("Floor Vent");
                    }
                    return _Floor_Vents;
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
                        return _Prison = Finder.FindRootSceneObject("Prison");
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
                        return _ITEMS = Finder.FindRootSceneObject("Items");
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

        private static RawUdonBehaviour RedCardBehaviour { get; set; } = null;
        internal static UdonBehaviour_Cached MoneyInteraction { get; set; } = null;
        internal static UdonBehaviour_Cached GateInteraction { get; set; } = null;
        internal static UdonBehaviour_Cached TogglePatronGuns { get; set; } = null;
        internal static UdonBehaviour_Cached ToggleDoublePoints { get; set; } = null;
        internal static UdonBehaviour_Cached TakeKeycard { get; set; } = null;

        private static UdonBehaviour_Cached GetRedCard { get; set; } = null;
        private static List<GameObject> Large_Crates { get; set; } = new List<GameObject>();
        private static List<GameObject> Small_Crates { get; set; } = new List<GameObject>();


        private static List<UdonBehaviour_Cached> Large_Crates_udon { get; set; } = new List<UdonBehaviour_Cached>();
        private static List<UdonBehaviour_Cached> Small_Crates_udon { get; set; } = new List<UdonBehaviour_Cached>();

        private static List<UdonBehaviour_Cached> Knifes { get; set; } = new List<UdonBehaviour_Cached>();
        private static List<UdonBehaviour_Cached> VentsMeshes { get; set; } = new List<UdonBehaviour_Cached>();
        private static List<UdonBehaviour_Cached> PrisonDoors_Open { get; set; } = new List<UdonBehaviour_Cached>();
        private static List<UdonBehaviour_Cached> PrisonDoors_Close { get; set; } = new List<UdonBehaviour_Cached>();
        internal static Toggle WorldSettings_GoldenGuns_Toggle { get; set; } = null;
        internal static Toggle WorldSettings_DoublePoints_Toggle { get; set; } = null;
        internal static Toggle WorldSettings_VisualHitBoxes_Toggle { get; set; } = null;
        internal static Toggle WorldSettings_Music_Toggle { get; set; } = null;
        internal static Toggle WorldSettings_Subtitles_Toggle { get; set; } = null;

        internal static Button Gun_Gold_Color_Button { get; set; } = null;
        internal static Button Gun_Green_Color_Button { get; set; } = null;
        internal static Button Gun_Blue_Color_Button { get; set; } = null;
        internal static Button Gun_Purple_Color_Button { get; set; } = null;
        internal static Button Gun_Red_Color_Button { get; set; } = null;

    }
}