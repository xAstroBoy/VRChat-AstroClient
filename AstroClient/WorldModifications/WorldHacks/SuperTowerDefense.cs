using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.AstroUdons;
    using AstroMonos.Components.Cheats.Worlds.SuperTowerDefense;
    using AstroMonos.Components.Custom.Random;
    using AstroMonos.Components.Tools;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class SuperTowerDefense : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnWorldReveal += OnWorldReveal;
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

                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Tower_defense)
            {
                isCurrentWorld = true;
                HasSubscribed = true;
                if (SuperTowerDefensecheatPage != null)
                {
                    SuperTowerDefensecheatPage.SetInteractable(true);
                    SuperTowerDefensecheatPage.SetTextColor(Color.green);
                }

                Log.Write($"Recognized {Name}, Cheats available.");
                ResetBalance = UdonSearch.FindUdonEvent("Bank", "Restart");
                if (ResetBalance != null)
                {
                    BankEditor = ResetBalance.UdonBehaviour.GetOrAddComponent<SuperTowerDefense_BankEditor>();
                }
                var revive = UdonSearch.FindUdonEvent("HealthController", "Revive");
                if (revive != null)
                {
                    ResetHealth = revive;
                    LoseHealth = revive.UdonBehaviour.FindUdonEvent("LoseLives");
                    HealthEditor = revive.UdonBehaviour.GetOrAddComponent<SuperTowerDefense_HealthEditor>();
                }

                var Round = UdonSearch.FindUdonEvent("NewWaveInteract", "_interact");
                if (Round != null)
                {
                    WaveEvent = Round;
                }
                var wavecontrol = UdonSearch.FindUdonEvent("WaveController", "AskForNewWave");
                if (wavecontrol != null)
                {
                    WaveEditor = wavecontrol.UdonBehaviour.gameObject.AddComponent<SuperTowerDefense_WaveEditor>();
                }

                var AutoStarter_PlaceEvent = UdonSearch.FindUdonEvent("AutoStarter", "Place");
                if (AutoStarter_PlaceEvent != null)
                {
                    AutoStarterReader = AutoStarter_PlaceEvent.UdonBehaviour.gameObject.AddComponent<SuperTowerDefense_AutoStarter>();
                    AutoStarter_Place = AutoStarter_PlaceEvent;
                }
                var AutoStarter_InactiveEvent = UdonSearch.FindUdonEvent("AutoStarter", "SetInactive");
                if (AutoStarter_InactiveEvent != null)
                {
                    AutoStarter_SetInactive = AutoStarter_InactiveEvent;
                }
                var AutoStarter_ActiveEvent = UdonSearch.FindUdonEvent("AutoStarter", "SetActive");
                if (AutoStarter_ActiveEvent != null)
                {
                    AutoStarter_SetActive = AutoStarter_ActiveEvent;
                }

                RedWrench = GameObjectFinder.Find("UpgradeTool0");
                BlueWrench = GameObjectFinder.Find("UpgradeTool1");
                Hammer = GameObjectFinder.Find("SellTool");
                if (RedWrench != null)
                {
                    RedWrenchPickup = RedWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (RedWrenchPickup != null)
                    {
                        RedWrenchPickup.OnPickupUseUp = null;
                        RedWrenchPickup.OnPickupUseUp += new System.Action(() =>
                        {
                            if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 1; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value + 1; }
                        });
                        RedWrenchPickup.enabled = false;
                    }
                }
                if (BlueWrench != null)
                {
                    BlueWrenchPickup = BlueWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (BlueWrenchPickup != null)
                    {
                        BlueWrenchPickup.OnPickupUseUp = null;
                        BlueWrenchPickup.OnPickupUseUp += new System.Action(() =>
                        {
                            if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 1; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value + 1; }
                        });
                        BlueWrenchPickup.enabled = false;
                    }
                }
                if (Hammer != null)
                {
                    HammerPickup = Hammer.GetOrAddComponent<VRC_AstroPickup>();
                    if (HammerPickup != null)
                    {
                        HammerPickup.OnPickupUseUp = null;
                        HammerPickup.OnPickupUseUp += new System.Action(() => { LoseHealth.InvokeBehaviour(); });
                        HammerPickup.enabled = false;
                    }
                }
                //var CanvasesObj = GameObjectFinder.Find("WaveInteractables/SM_Bld_Portable_Office_01 (1)/WavePaper");
                //if (CanvasesObj != null)
                //{
                //    foreach (var text in CanvasesObj.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                //    {
                //        if (text != null)
                //        {
                //            if (!text.text.ToLower().Equals("wave"))
                //            {
                //                text.resizeTextForBestFit = true;
                //                Log.Debug($"Fixed Canvas : {text.gameObject.name}");
                //            }
                //        }
                //    }
                //}

                var toolshop = GameObjectFinder.FindRootSceneObject("ToolShop");
                if (toolshop != null)
                {
                    // Button is SM_Switch_Button_Button_02
                    ReturnHammerButtonTool = toolshop.transform.FindObject("ReturnSellTool").gameObject;
                    ReturnBlueWrenchButton = toolshop.transform.FindObject("ReturnUpgradeTool1").gameObject;
                    ReturnRedWrenchButton = toolshop.transform.FindObject("ReturnUpgradeTool0").gameObject;
                }

                Tower_RocketLauncher = GameObjectFinder.Find("TowerRocketLauncher1Grabbable (0)");
                Tower_Slower = GameObjectFinder.Find("TowerSlower1Grabbable (0)");
                Tower_Cannon = GameObjectFinder.Find("TowerCannon1Grabbable (0)");
                Tower_Radar = GameObjectFinder.Find("TowerRadar1Grabbable (0)");
                Tower_Minigun = GameObjectFinder.Find("TowerMiniGun1Grabbable (0)");
                Tower_Lance = GameObjectFinder.Find("TowerLance1Grabbable (0)");

                Tower_RocketLauncher_1 = GameObjectFinder.Find("TowerRocketLauncher1Grabbable (1)");
                Tower_Slower_1 = GameObjectFinder.Find("TowerSlower1Grabbable (1)");
                Tower_Cannon_1 = GameObjectFinder.Find("TowerCannon1Grabbable (1)");
                Tower_Radar_1 = GameObjectFinder.Find("TowerRadar1Grabbable (1)");
                Tower_Minigun_1 = GameObjectFinder.Find("TowerMiniGun1Grabbable (1)");
                Tower_Lance_1 = GameObjectFinder.Find("TowerLance1Grabbable (1)");

                Tower_RocketLauncher.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Slower.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Cannon.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Radar.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Minigun.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Lance.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();

                Tower_RocketLauncher_1.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Slower_1.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Cannon_1.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Radar_1.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Minigun_1.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();
                Tower_Lance_1.GetOrAddComponent<SuperTowerDefense_TowerCollisionFixer>();

                FixTheTowers(false);
                
            }
            else
            {
                HasSubscribed = false;
                if (SuperTowerDefensecheatPage != null)
                {
                    SuperTowerDefensecheatPage.SetInteractable(false);
                    SuperTowerDefensecheatPage.SetTextColor(Color.red);
                }

                isCurrentWorld = false;
            }
        }

        private static bool isCurrentWorld = false;
        private void OnRoomLeft()
        {
            WaveEditor = null;
            HealthEditor = null;
            BankEditor = null;
            cancellationwavetoken = null;
            RedWrenchPickup = null;
            BlueWrenchPickup = null;
            HammerPickup = null;
            GodMode = false;
            ResetHealth = null;
            LoseHealth = null;
            WaveEvent = null;
            FreezeHammer = false;
            LoseLifeHammer = false;
            RepairLifeWrenches = false;
            BlockHammerReturnButton = false;
            ReturnHammerButtonTool = null;
            FixBalanceNegative = false;
            FreezeMoney = false;
            Obj_Apple_1 = null;
            Obj_Apple_2 = null;

            Obj_Apple_3 = null;
            Obj_Apple_4 = null;

            Hammer = null;
            ReturnBlueWrenchButton = null;
            ReturnRedWrenchButton = null;

            Tower_RocketLauncher = null;
            Tower_Slower = null;
            Tower_Cannon = null;
            Tower_Radar = null;
            Tower_Minigun = null;
            Tower_Lance = null;
            CrazyHammer = false;
            HammerCrazyBehaviour = null;
            Hammer_AntiTheft = false;
            Tower_RocketLauncher_1 = null;
            Tower_Slower_1 = null;
            Tower_Cannon_1 = null;
            Tower_Radar_1 = null;
            Tower_Minigun_1 = null;
            Tower_Lance_1 = null;
            BlueWrench = null;
            RedWrench = null;
            FreezeRedWrench = false;
            FreezeBlueWrench = false;
            BlockWrenchReturnButton = false;
            FreezeLanceTower = false;
            FreezeMinigunTower = false;
            FreezeRadarTower = false;
            FreezeCannonTower = false;
            FreezeSlowerTower = false;
            FreezeRocketLauncherTower = false;
            FreezeAllTowers = false;
            KeepAutoStarterActive = false;
            KeepAutoStarterInactive = false;
            AutoStarter_Place = null;
            AutoStarter_SetInactive = null;
            AutoStarter_SetActive = null;
            AutoStarterReader = null;
            isCurrentWorld = false;
            HasSubscribed = false;
            //IgnoreTowersCollidersPlacement = false;
            //NearbyCollidersManager.Clear();
        }

        internal static void FixTheTowers(bool RespawnTower)
        {
            FixTower(Tower_RocketLauncher, RespawnTower);
            FixTower(Tower_Slower, RespawnTower);
            FixTower(Tower_Cannon, RespawnTower);
            FixTower(Tower_Radar, RespawnTower);
            FixTower(Tower_Minigun, RespawnTower);
            FixTower(Tower_Lance, RespawnTower);

            FixTower(Tower_RocketLauncher_1, RespawnTower);
            FixTower(Tower_Slower_1, RespawnTower);
            FixTower(Tower_Cannon_1, RespawnTower);
            FixTower(Tower_Radar_1, RespawnTower);
            FixTower(Tower_Minigun_1, RespawnTower);
            FixTower(Tower_Lance_1, RespawnTower);

        }

        private static void FixTower(GameObject tower, bool RespawnTowers)
        {
            if (tower != null)
            {
                tower.Pickup_Set_Pickupable(true); // Override and fix potential Tower Bugs.
                if (RespawnTowers)
                {
                    tower.TakeOwnership();
                    tower.RigidBody_Set_isKinematic(true);
                    tower.GetComponentInChildren<SyncPhysics>(true)?.RespawnItem();
                    tower.KillForces();
                    tower.RigidBody_Set_isKinematic(false);
                }
            }
        }

        internal static void InitButtons(QMGridTab main)
        {
            SuperTowerDefensecheatPage = new QMNestedGridMenu(main, "Super Tower Defense", "Super Tower Defense Cheats");

            var bankmods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Bank Mods", "Modify Current Bank Balance");
            _ = new QMSingleButton(bankmods, "Set 0 Money", () => { if (BankEditor != null && BankEditor.Money.HasValue) { BankEditor.Money = 0; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 10000 Money", () => { if (BankEditor != null && BankEditor.Money.HasValue) { BankEditor.Money = BankEditor.Money.Value + 10000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 100000 Money", () => { if (BankEditor != null && BankEditor.Money.HasValue) { BankEditor.Money = BankEditor.Money.Value + 100000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 1000000 Money", () => { if (BankEditor != null && BankEditor.Money.HasValue) { BankEditor.Money = BankEditor.Money.Value + 1000000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 10000000 Money", () => { if (BankEditor != null && BankEditor.Money.HasValue) { BankEditor.Money = BankEditor.Money.Value + 10000000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Set 999999999 Money", () => { if (BankEditor != null && BankEditor.Money.HasValue) { BankEditor.Money = 999999999; } }, "Edit Current Balance!");

            var WaveMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Wave Mods", "Modify Current Rounds");

            _ = new QMSingleButton(WaveMods, "Wave +1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 1; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave +10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 10; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave +100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 100; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave -1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 1; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave -10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 10; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave -100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 100; } }, "Edit Current Round!");

            var LifeMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Health Mods", "Modify Current Healths");

            _ = new QMSingleButton(LifeMods, "Life +1", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 1; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value + 1; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life +10", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 10; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value + 10; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life +100", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 100; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value + 100; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life -1", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value - 1; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value - 1; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life -10", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value - 10; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value - 10; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life -100", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value - 100; HealthEditor.TimesBoughtLives = HealthEditor.TimesBoughtLives.Value - 100; } }, "Edit Current Health!");

            var TowerMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Towers Mods", "Make Towers SuperPowerful");
            _ = new QMSingleButton(TowerMods, "+0.5f Tower Range", () => { AddTowerRange(0.5f); }, "Add +0.5f Towers Range!");
            _ = new QMSingleButton(TowerMods, "+1f Tower Range", () => { AddTowerRange(1f); }, "Add +1f Towers Range!");
            _ = new QMSingleButton(TowerMods, "-0.5f Tower Range", () => { RemoveTowerRange(0.5f); }, "Remove 0.5f Towers Range!");
            _ = new QMSingleButton(TowerMods, "-1f Tower Range", () => { RemoveTowerRange(1f); }, "Remove 1f Towers Range!");
            _ = new QMSingleButton(TowerMods, "Restore Tower Range", () => { RestoreTowerRange(); }, "Revert Any Edits if Any to Towers Range Settings!");

            _ = new QMSingleButton(TowerMods, "+0.5f Tower Speed", () => { AddTowerSpeed(0.5f); }, "Add +0.5f Towers Speed!");
            _ = new QMSingleButton(TowerMods, "+1f Tower Speed", () => { AddTowerSpeed(1f); }, "Add +1f Towers Speed!");
            _ = new QMSingleButton(TowerMods, "-0.5f Tower Speed", () => { RemoveTowerSpeed(0.5f); }, "Remove 0.5f Towers Speed!");
            _ = new QMSingleButton(TowerMods, "-1f Tower Speed", () => { RemoveTowerSpeed(1f); }, "Remove 1f Towers Speed!");

            _ = new QMSingleButton(TowerMods, "Restore Tower Speed", () => { RestoreTowerSpeed(); }, "Revert Any Edits if Any to Towers Speed Settings!");

            _ = new QMSingleButton(TowerMods, "9999 Tower Range", () => { SetTowersRange(9999f); }, "Edit Towers Range to maximum!");
            _ = new QMSingleButton(TowerMods, "9999 Tower Speed", () => { SetTowerSpeed(9999f); }, "Edit Towers Speed to maximum!");

            var ToolMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Tool Mods", "Enable Extra Tools");
            RepairLifeWrenchToolsButton = new QMToggleButton(ToolMods, "Toggle Repair life Wrenches", () => { RepairLifeWrenches = true; }, () => { RepairLifeWrenches = false; }, "Wrenches = Reset Health, Hammer = Lose health (useful to troll)!");
            LoseLifeHammerToolBtn = new QMToggleButton(ToolMods, "Toggle Lose Life Hammer", () => { LoseLifeHammer = true; }, () => { LoseLifeHammer = false; }, "Hammer = Lose health (useful to troll)!");

            var AutoStarterManagement = new QMNestedGridMenu(SuperTowerDefensecheatPage, "AutoStarter Control", "Control Map AutoStarter");
            new QMSingleButton(AutoStarterManagement, "Place AutoStarter", () => { AutoStarter_Place?.InvokeBehaviour(); }, "Spawn AutoStarter");
            new QMSingleButton(AutoStarterManagement, "Activate AutoStarter", () => { AutoStarter_SetActive?.InvokeBehaviour(); }, "Activate AutoStarter");
            new QMSingleButton(AutoStarterManagement, "Deactivate AutoStarter", () => { AutoStarter_SetInactive?.InvokeBehaviour(); }, "Deactivate AutoStarter");
            AutoStartKeepActiveBtn = new QMToggleButton(AutoStarterManagement, "Keep AutoStart ON", () => { KeepAutoStarterActive = true; }, () => { KeepAutoStarterActive = false; }, "Locks AutoStarter on Active Status!");
            AutoStartKeepInactiveBtn = new QMToggleButton(AutoStarterManagement, "Keep AutoStart OFF", () => { KeepAutoStarterInactive = true; }, () => { KeepAutoStarterInactive = false; }, "Locks AutoStarter on Inactive Status!");

            var RandomFeatures = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Random Features", "More Random Features");
            AutomaticWaveBtn = new QMToggleButton(RandomFeatures, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = true; }, () => { AutomaticWaveStart = false; }, "Spam the event to start the round!");
            AutomaticGodModebnt = new QMToggleButton(RandomFeatures, "Toggle Automatic \n GodMode", () => { GodMode = true; }, () => { GodMode = false; }, "Enable Healths God Mode!");
            new QMSingleButton(RandomFeatures, "Fix towers", () => { FixTheTowers(true); }, "Fix Towers Being unpickable bug ", Color.green);
            FreezeMoneyBtn = new QMToggleButton(RandomFeatures, "Freeze Current Money Balance!", () => { FreezeMoney = true; }, () => { FreezeMoney = false; }, "Keep the money balance frozen!");
            FixBalanceNegativeBtn = new QMToggleButton(RandomFeatures, "No Negative Balance Money!", () => { FixBalanceNegative = true; }, () => { FixBalanceNegative = false; }, "Checks if the money goes negative, if so it resets to StartMoney Amount!");

            //IgnoreTowersCollidersPlacementToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Bypass Tower Collider", () => { IgnoreTowersCollidersPlacement = true; }, () => { IgnoreTowersCollidersPlacement = false; }, "Allow Overlapping Towers!");
            var ProtectionsMenu = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Protections", "Protections");

            FreezeHammerToolBtn = new QMToggleButton(ProtectionsMenu, "Freeze Hammer", () => { FreezeHammer = true; }, () => { FreezeHammer = false; }, "Add a Protection Shield to the hammer!");

            FreezeBlueWrenchToolBtn = new QMToggleButton(ProtectionsMenu, "Freeze Blue Wrench", () => { FreezeBlueWrench = true; }, () => { FreezeBlueWrench = false; }, "Add a Protection Shield to Blue Wrench!");
            FreezeRedWrenchToolBtn = new QMToggleButton(ProtectionsMenu, "Freeze Red Wrench", () => { FreezeRedWrench = true; }, () => { FreezeRedWrench = false; }, "Add a Protection Shield to Red Wrench!");

            BlockHammerReturnToolBtn = new QMToggleButton(ProtectionsMenu, "Block Hammer Return", () => { BlockHammerReturnButton = true; }, () => { BlockHammerReturnButton = false; }, "Add a Protection Shield to the hammer Return Button using Two Apples!");
            BlockWrenchReturnToolBtn = new QMToggleButton(ProtectionsMenu, "Block Wrenchs Returns", () => { BlockWrenchReturnButton = true; }, () => { BlockWrenchReturnButton = false; }, "Add a Protection Shield to the hammer Return Button using Two Apples!");

            var FreezeTowerMenu = new QMNestedGridMenu(ProtectionsMenu, "Towers Freeze Options", "Freeze Towers Menu");

            FreezeCannonTowerToolBtn = new QMToggleButton(FreezeTowerMenu, "Freeze Cannon Tower", () => { FreezeCannonTower = true; }, () => { FreezeCannonTower = false; }, "Add a Protection Shield to the Cannon Tower!");
            FreezeRadarTowerToolBtn = new QMToggleButton(FreezeTowerMenu, "Freeze Radar Tower", () => { FreezeRadarTower = true; }, () => { FreezeRadarTower = false; }, "Add a Protection Shield to the Radar Tower!");
            FreezeLanceTowerToolBtn = new QMToggleButton(FreezeTowerMenu, "Freeze Lance Tower", () => { FreezeLanceTower = true; }, () => { FreezeLanceTower = false; }, "Add a Protection Shield to the Lance Tower!");
            FreezeSlowerTowerToolBtn = new QMToggleButton(FreezeTowerMenu, "Freeze Slower Tower", () => { FreezeSlowerTower = true; }, () => { FreezeSlowerTower = false; }, "Add a Protection Shield to the Slower Tower!");
            FreezeRocketLauncherTowerToolBtn = new QMToggleButton(FreezeTowerMenu, "Freeze Rocket Launcher Tower", () => { FreezeRocketLauncherTower = true; }, () => { FreezeRocketLauncherTower = false; }, "Add a Protection Shield to the Rocket Launcher Tower!");
            FreezeMinigunTowerToolBtn = new QMToggleButton(FreezeTowerMenu, "Freeze Minigun Tower", () => { FreezeMinigunTower = true; }, () => { FreezeMinigunTower = false; }, "Add a Protection Shield to the Minigun Tower!");

            FreezeAllTowersToolBtn = new QMToggleButton(FreezeTowerMenu, "Freeze All Towers", () => { FreezeAllTowers = true; }, () => { FreezeAllTowers = false; }, "Add a Protection Shield to All Towers!");

        }

        // TODO: Add a reversal mechanism to check if speed or range is modified and revert it.

        // TODO : make a Hook to detect when a object is instantiated to immediately add and optimize the component as well, to avoid running this on loop.

        private static List<SuperTowerDefense_TowerEditor> GetCurrentEditors
        {
            get
            {
                List<SuperTowerDefense_TowerEditor> result = new List<SuperTowerDefense_TowerEditor>();
                foreach (var item in GameObjectFinder.RootSceneObjects_WithoutAvatars)
                {
                    if (item.name.StartsWith("TowerMiniGun") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerRocketLauncher") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerSlow") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerLance") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerRadar") && item.name.EndsWith("(Clone)") ||
                         item.name.StartsWith("TowerCannon") && item.name.EndsWith("(Clone)"))
                    {
                        var editor = item.GetOrAddComponent<SuperTowerDefense_TowerEditor>();
                        if (editor != null)
                        {
                            result.Add(editor);
                        }
                    }
                }

                return result;
            }
        }

        internal static void SetTowersRange(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    tower.BackupAndModifyRange(value);
                }
            }
        }
        internal static void AddTowerRange(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    tower.BackupAndModifyRange(tower.Range.Value + value);
                }
            }
        }
        internal static void RemoveTowerRange(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    tower.BackupAndModifyRange(tower.Range.Value - value);
                }
            }
        }
        internal static void RestoreTowerRange()
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    tower.RestoreRange();
                }
            }
        }

        internal static void SetTowerSpeed(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    if (tower.name.Contains("RocketLauncher")) continue; // Ignore due to Lag reasons.
                    tower.BackupAndModifySpeedMultiplier(value);
                }
            }
        }
        internal static void AddTowerSpeed(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    if (tower.name.Contains("RocketLauncher")) continue; // Ignore due to Lag reasons.
                    tower.BackupAndModifySpeedMultiplier(tower.SpeedMultiplier.Value + value);
                }
            }
        }
        internal static void RemoveTowerSpeed(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    if (tower.name.Contains("RocketLauncher")) continue; // Ignore due to Lag reasons.
                    tower.BackupAndModifySpeedMultiplier(tower.SpeedMultiplier.Value - value);
                }
            }
        }

        internal static void RestoreTowerSpeed()
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    if (tower.name.Contains("RocketLauncher")) continue; // Ignore due to Lag reasons.
                    tower.RestoreSpeedMultiplier();
                }
            }
        }

        private static bool _RepairLifeWrenches;

        internal static bool RepairLifeWrenches
        {
            get
            {
                return _RepairLifeWrenches;
            }
            set
            {
                if (RepairLifeWrenchToolsButton != null)
                {
                    RepairLifeWrenchToolsButton.SetToggleState(value);
                }
                _RepairLifeWrenches = value;
                if (RedWrenchPickup != null)
                {
                    RedWrenchPickup.enabled = value;
                    if (value)
                    {
                        RedWrenchPickup.UseText = "Reset Health (AstroClient)";
                    }
                    else
                    {
                        RedWrenchPickup.UseText = "Use";
                    }
                }
                if (BlueWrenchPickup != null)
                {
                    BlueWrenchPickup.enabled = value;
                    if (value)
                    {
                        BlueWrenchPickup.UseText = "Reset Health (AstroClient)";
                    }
                    else
                    {
                        BlueWrenchPickup.UseText = "Use";
                    }
                }
            }
        }

        private static bool _LoseLifeHammer;

        internal static bool LoseLifeHammer
        {
            get
            {
                return _LoseLifeHammer;
            }
            set
            {
                if (LoseLifeHammerToolBtn != null)
                {
                    LoseLifeHammerToolBtn.SetToggleState(value);
                }
                _LoseLifeHammer = value;
                if (HammerPickup != null)
                {
                    HammerPickup.enabled = value;
                    if (value)
                    {
                        HammerPickup.UseText = "Lose Health (AstroClient)";
                    }
                    else
                    {
                        HammerPickup.UseText = "Use";
                    }
                }
            }
        }

        private static void LockTowerInPlace(GameObject Tower)
        {
            if (Tower != null)
            {
                Tower.gameObject.TakeOwnership();
                Tower.GetComponentInChildren<SyncPhysics>(true).RespawnItem();
                var item = Tower.gameObject.GetOrAddComponent<ObjectFreezer>();
                if (item != null)
                {
                    item.IsEnabled = true;
                    item.Capture();
                    item.LockPosition = true;
                    Log.Debug($"Locked {item.name} to pos ${item.FreezePos.ToString()} and Rotation {item.FreezeRot.ToString()}");
                }
            }
        }
        private static bool _FreezeRocketLauncherTower;

        internal static bool FreezeRocketLauncherTower
        {
            get
            {
                return _FreezeRocketLauncherTower;
            }
            set
            {
                if (FreezeRocketLauncherTowerToolBtn != null)
                {
                    FreezeRocketLauncherTowerToolBtn.SetToggleState(value);
                }
                _FreezeRocketLauncherTower = value;

                if (value)
                {
                    LockTowerInPlace(Tower_RocketLauncher);
                    LockTowerInPlace(Tower_RocketLauncher_1);

                }
                else
                {
                    RemoveLockOnItem(Tower_RocketLauncher);
                    RemoveLockOnItem(Tower_RocketLauncher_1);

                }

                CheckForAllTowersFreezeStatus();
            }
        }
        private static bool _FreezeSlowerTower;

        internal static bool FreezeSlowerTower
        {
            get
            {
                return _FreezeSlowerTower;
            }
            set
            {
                if (FreezeSlowerTowerToolBtn != null)
                {
                    FreezeSlowerTowerToolBtn.SetToggleState(value);
                }
                _FreezeSlowerTower = value;

                if (value)
                {
                    LockTowerInPlace(Tower_Slower);
                    LockTowerInPlace(Tower_Slower_1);

                }
                else
                {
                    RemoveLockOnItem(Tower_Slower);
                    RemoveLockOnItem(Tower_Slower_1);

                }
                CheckForAllTowersFreezeStatus();
            }
        }

        private static bool _FreezeCannonTower;

        internal static bool FreezeCannonTower
        {
            get
            {
                return _FreezeCannonTower;
            }
            set
            {
                if (FreezeCannonTowerToolBtn != null)
                {
                    FreezeCannonTowerToolBtn.SetToggleState(value);
                }
                _FreezeCannonTower = value;

                if (value)
                {
                    LockTowerInPlace(Tower_Cannon);
                    LockTowerInPlace(Tower_Cannon_1);

                }
                else
                {
                    RemoveLockOnItem(Tower_Cannon);
                    RemoveLockOnItem(Tower_Cannon_1);
                }
                CheckForAllTowersFreezeStatus();
            }
        }

        private static bool _FreezeRadarTower;

        internal static bool FreezeRadarTower
        {
            get
            {
                return _FreezeRadarTower;
            }
            set
            {
                if (FreezeRadarTowerToolBtn != null)
                {
                    FreezeRadarTowerToolBtn.SetToggleState(value);
                }
                _FreezeRadarTower = value;

                if (value)
                {
                    LockTowerInPlace(Tower_Radar);
                    LockTowerInPlace(Tower_Radar_1);

                }
                else
                {
                    RemoveLockOnItem(Tower_Radar);
                    RemoveLockOnItem(Tower_Radar_1);
                }
                CheckForAllTowersFreezeStatus();
            }
        }
        private static bool _FreezeMinigunTower;

        internal static bool FreezeMinigunTower
        {
            get
            {
                return _FreezeMinigunTower;
            }
            set
            {
                if (FreezeMinigunTowerToolBtn != null)
                {
                    FreezeMinigunTowerToolBtn.SetToggleState(value);
                }
                _FreezeMinigunTower = value;

                if (value)
                {
                    LockTowerInPlace(Tower_Minigun);
                    LockTowerInPlace(Tower_Minigun_1);

                }
                else
                {
                    RemoveLockOnItem(Tower_Minigun);
                    RemoveLockOnItem(Tower_Minigun_1);
                }
                CheckForAllTowersFreezeStatus();
            }
        }

        private static bool _FreezeLanceTower;

        internal static bool FreezeLanceTower
        {
            get
            {
                return _FreezeLanceTower;
            }
            set
            {
                if (FreezeLanceTowerToolBtn != null)
                {
                    FreezeLanceTowerToolBtn.SetToggleState(value);
                }
                _FreezeLanceTower = value;

                if (value)
                {
                    LockTowerInPlace(Tower_Lance);
                    LockTowerInPlace(Tower_Lance_1);

                }
                else
                {
                    RemoveLockOnItem(Tower_Lance);
                    RemoveLockOnItem(Tower_Lance_1);
                }

                CheckForAllTowersFreezeStatus();
            }
        }
        private static bool _FreezeAllTowers;

        internal static bool FreezeAllTowers
        {
            get
            {
                return _FreezeAllTowers;
            }
            set
            {
                if (FreezeAllTowersToolBtn != null)
                {
                    FreezeAllTowersToolBtn.SetToggleState(value);
                }
                _FreezeAllTowers = value;
                FreezeLanceTower = value;
                FreezeMinigunTower = value;
                FreezeRadarTower = value;
                FreezeCannonTower = value;
                FreezeSlowerTower = value;
                FreezeRocketLauncherTower = value;
            }
        }

        private static void CheckForAllTowersFreezeStatus()
        {
            if (FreezeLanceTower && FreezeMinigunTower && FreezeRadarTower && FreezeCannonTower && FreezeSlowerTower && FreezeRocketLauncherTower)
            {
                if (FreezeAllTowersToolBtn != null)
                {
                    FreezeAllTowersToolBtn.SetToggleState(true);
                }
                _FreezeAllTowers = true;
            }
            else
            {
                if (FreezeAllTowersToolBtn != null)
                {
                    FreezeAllTowersToolBtn.SetToggleState(false);
                }
                _FreezeAllTowers = false;
            }
        }

        //private static bool _IgnoreTowersCollidersPlacement;

        //internal static bool IgnoreTowersCollidersPlacement
        //{
        //    get
        //    {
        //        return _IgnoreTowersCollidersPlacement;
        //    }
        //    set
        //    {
        //        if (IgnoreTowersCollidersPlacementToolBtn != null)
        //        {
        //            IgnoreTowersCollidersPlacementToolBtn.SetToggleState(value);
        //        }
        //        _IgnoreTowersCollidersPlacement = value;

        //        if (value)
        //        {
        //            Tower_RocketLauncher.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Slower.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Cannon.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Radar.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Minigun.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Lance.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
        //        }
        //        else
        //        {
        //            Tower_RocketLauncher.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Slower.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Cannon.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Radar.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Minigun.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
        //            Tower_Lance.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
        //        }
        //    }
        //}
        private static bool _CrazyHammer = false;
        private static CrazyBehaviour HammerCrazyBehaviour = null;
        internal static bool CrazyHammer
        {
            get
            {
                return _CrazyHammer;
            }
            set
            {
                _CrazyHammer = value;
                if (Hammer != null)
                {
                    if (value)
                    {
                        Hammer.TakeOwnership();
                        if (HammerCrazyBehaviour == null)
                        {
                            HammerCrazyBehaviour = Hammer.GetOrAddComponent<CrazyBehaviour>();
                        }
                        if (HammerCrazyBehaviour != null)
                        {
                            HammerCrazyBehaviour.IsEnabled = true;
                            HammerCrazyBehaviour.UseGravity = true;
                        }
                    }
                    else
                    {
                        HammerCrazyBehaviour.DestroyMeLocal();
                    }
                }
            }
        }

        internal static bool Hammer_AntiTheft
        {
            get
            {
                if (HammerPickup != null)
                {
                    return HammerPickup.GetOrAddComponent<PickupController>().AntiTheft;
                }
                return false;
            }
            set
            {
                var beh = HammerPickup.GetOrAddComponent<PickupController>();
                if (beh != null)
                {
                    beh.AntiTheft = value;
                }
            }
        }

        private static bool _FreezeHammer;

        internal static bool FreezeHammer
        {
            get
            {
                return _FreezeHammer;
            }
            set
            {
                if (FreezeHammerToolBtn != null)
                {
                    FreezeHammerToolBtn.SetToggleState(value);
                }
                _FreezeHammer = value;

                if (HammerPickup != null)
                {
                    if (value)
                    {
                        var item = HammerPickup.gameObject.GetOrAddComponent<ObjectFreezer>();
                        if (item != null)
                        {
                            item.IsEnabled = true;
                            Log.Debug($"Locked {item.name} to pos ${item.FreezePos.ToString()} and Rotation {item.FreezeRot.ToString()}");
                        }
                    }
                    else
                    {
                        HammerPickup.gameObject.Remove_ObjectFreezer();
                    }
                }
            }
        }

        private static bool _FreezeRedWrench;

        internal static bool FreezeRedWrench
        {
            get
            {
                return _FreezeRedWrench;
            }
            set
            {
                if (FreezeRedWrenchToolBtn != null)
                {
                    FreezeRedWrenchToolBtn.SetToggleState(value);
                }
                _FreezeRedWrench = value;

                if (RedWrenchPickup != null)
                {
                    if (value)
                    {
                        var item = RedWrenchPickup.gameObject.GetOrAddComponent<ObjectFreezer>();
                        if (item != null)
                        {
                            item.IsEnabled = true;
                            Log.Debug($"Locked {item.name} to pos ${item.FreezePos.ToString()} and Rotation {item.FreezeRot.ToString()}");
                        }
                    }
                    else
                    {
                        RedWrenchPickup.gameObject.Remove_ObjectFreezer();
                    }
                }
            }
        }

        private static bool _FreezeBlueWrench;
        internal static bool FreezeBlueWrench
        {
            get
            {
                return _FreezeBlueWrench;
            }
            set
            {
                if (FreezeBlueWrenchToolBtn != null)
                {
                    FreezeBlueWrenchToolBtn.SetToggleState(value);
                }
                _FreezeBlueWrench = value;

                if (BlueWrenchPickup != null)
                {
                    if (value)
                    {
                        var item = BlueWrenchPickup.gameObject.GetOrAddComponent<ObjectFreezer>();
                        if (item != null)
                        {
                            item.IsEnabled = true;
                            Log.Debug($"Locked {item.name} to pos ${item.FreezePos.ToString()} and Rotation {item.FreezeRot.ToString()}");
                        }
                    }
                    else
                    {
                        BlueWrenchPickup.gameObject.Remove_ObjectFreezer();
                    }
                }
            }
        }

        private static bool _BlockHammerReturn;

        internal static bool BlockHammerReturnButton
        {
            get
            {
                return _BlockHammerReturn;
            }
            set
            {
                if (BlockHammerReturnToolBtn != null)
                {
                    BlockHammerReturnToolBtn.SetToggleState(value);
                }
                _BlockHammerReturn = value;

                if (value)
                {
                    LockOnTarget(Apple_1, ReturnHammerButtonTool);
                    LockOnTarget(Apple_2, ReturnHammerButtonTool);
                    if (!BlockWrenchReturnButton)
                    {
                        LockOnTarget(Apple_3, ReturnHammerButtonTool);
                        LockOnTarget(Apple_4, ReturnHammerButtonTool);
                    }
                }
                else
                {
                    if (BlockWrenchReturnButton)
                    {
                        LockOnTarget(Apple_1, ReturnRedWrenchButton);
                        LockOnTarget(Apple_2, ReturnBlueWrenchButton);
                    }
                    else
                    {
                        RemoveLockOnItem(Apple_1);
                        RemoveLockOnItem(Apple_2);
                        if (!BlockWrenchReturnButton)
                        {
                            RemoveLockOnItem(Apple_3);
                            RemoveLockOnItem(Apple_4);
                        }
                    }
                }
            }
        }

        private static bool _BlockWrenchReturn;

        internal static bool BlockWrenchReturnButton
        {
            get
            {
                return _BlockWrenchReturn;
            }
            set
            {
                if (BlockWrenchReturnToolBtn != null)
                {
                    BlockWrenchReturnToolBtn.SetToggleState(value);
                }
                _BlockWrenchReturn = value;

                if (value)
                {
                    LockOnTarget(Apple_3, ReturnRedWrenchButton);
                    LockOnTarget(Apple_4, ReturnBlueWrenchButton);
                    if (!BlockHammerReturnButton)
                    {
                        LockOnTarget(Apple_1, ReturnRedWrenchButton);
                        LockOnTarget(Apple_2, ReturnBlueWrenchButton);
                    }
                }
                else
                {
                    if (BlockHammerReturnButton)
                    {
                        LockOnTarget(Apple_3, ReturnHammerButtonTool);
                        LockOnTarget(Apple_4, ReturnHammerButtonTool);
                    }
                    else
                    {
                        RemoveLockOnItem(Apple_3);
                        RemoveLockOnItem(Apple_4);
                        if (!BlockHammerReturnButton)
                        {
                            RemoveLockOnItem(Apple_1);
                            RemoveLockOnItem(Apple_2);
                        }
                    }
                }
            }
        }

        private static void RemoveLockOnItem(GameObject item)
        {
            if (item != null)
            {
                var Freeze = item.GetComponent<ObjectFreezer>();
                if(Freeze != null)
                {
                    Freeze.DestroyMeLocal(true);
                    var sync = item.GetComponentInChildren<SyncPhysics>(true);
                    if(sync != null)
                    {
                        sync.RespawnItem(true);
                    }

                }
            }
        }

        private static void LockOnTarget(GameObject item, GameObject target)
        {
            try
            {
                if (item != null)
                {
                    if (target != null)
                    {
                        item.TakeOwnership();
                        var body = item.GetOrAddComponent<RigidBodyController>();
                        if (body != null)
                        {
                            body.position = target.transform.position;
                            body.rotation = target.transform.rotation;
                        }
                        else
                        {
                            item.transform.position = target.transform.position;
                            item.transform.rotation = target.transform.rotation;
                        }
                        var Freezer = item.GetOrAddComponent<ObjectFreezer>();
                        if (Freezer != null)
                        {
                            Freezer.OverrideCapture(target.transform.position, target.transform.rotation);
                            Freezer.LockPosition = true; // Prevent Re-capturing To Fully freeze and protect the button !
                            Log.Debug($"Locked {Freezer.gameObject.name} to pos ${Freezer.FreezePos.ToString()} and Rotation {Freezer.FreezeRot.ToString()}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
        }

        private static bool _AutomaticWaveStart = false;

        internal static bool AutomaticWaveStart
        {
            get
            {
                return _AutomaticWaveStart;
            }
            set
            {
                if (AutomaticWaveBtn != null)
                {
                    AutomaticWaveBtn.SetToggleState(value);
                }

                if (value.Equals(_AutomaticWaveStart))
                {
                    return;
                }
                _AutomaticWaveStart = value;
                if (value)
                {
                    cancellationwavetoken = MelonCoroutines.Start(WaveStarter());
                }
                else
                {
                    if (cancellationwavetoken != null)
                    {
                        MelonCoroutines.Stop(cancellationwavetoken);
                    }
                    cancellationwavetoken = null;
                }
            }
        }

        private static IEnumerator WaveStarter()
        {
            while (AutomaticWaveStart)
            {
                yield return new WaitForSeconds(1);
                if (WaveEvent != null)
                {
                    WaveEvent.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }
        internal static bool? FreezeMoney
        {
            get
            {
                if (BankEditor != null)
                {
                    return BankEditor.FreezeMoney;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (BankEditor != null)
                    {
                        if (FreezeMoneyBtn != null)
                        {
                            FreezeMoneyBtn.SetToggleState(value.Value);
                        }
                        BankEditor.FreezeMoney = value.Value;
                    }
                }
            }
        }

        internal static bool? FixBalanceNegative
        {
            get
            {
                if (BankEditor != null)
                {
                    return BankEditor.FixBalanceNegative;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (BankEditor != null)
                    {
                        if (FixBalanceNegativeBtn != null)
                        {
                            FixBalanceNegativeBtn.SetToggleState(value.Value);
                        }
                        BankEditor.FixBalanceNegative = value.Value;
                    }
                }
            }
        }

        internal static bool? GodMode
        {
            get
            {
                if (HealthEditor != null)
                {
                    return HealthEditor.GodMode;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (HealthEditor != null)
                    {
                        if (AutomaticGodModebnt != null)
                        {
                            AutomaticGodModebnt.SetToggleState(value.Value);
                        }
                        HealthEditor.GodMode = value.Value;
                    }
                }
            }
        }

        internal static GameObject Tower_RocketLauncher { get; set; }
        internal static GameObject Tower_Slower { get; set; }
        internal static GameObject Tower_Cannon { get; set; }
        internal static GameObject Tower_Radar { get; set; }
        internal static GameObject Tower_Minigun { get; set; }
        internal static GameObject Tower_Lance { get; set; }

        internal static GameObject Tower_RocketLauncher_1 { get; set; }
        internal static GameObject Tower_Slower_1 { get; set; }
        internal static GameObject Tower_Cannon_1 { get; set; }
        internal static GameObject Tower_Radar_1 { get; set; }
        internal static GameObject Tower_Minigun_1 { get; set; }
        internal static GameObject Tower_Lance_1 { get; set; }

        private static GameObject Obj_Apple_1;
        internal static GameObject Apple_1
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Obj_Apple_1 == null)
                {
                    return Obj_Apple_1 = GameObjectFinder.Find("Apples/Apple_01");
                }

                return Obj_Apple_1;
            }
        }
        private static GameObject Obj_Apple_2;
        internal static GameObject Apple_2
        {
            get
            {
                if (!isCurrentWorld) return null;

                if (Obj_Apple_2 == null)
                {
                    return Obj_Apple_2 = GameObjectFinder.Find("Apples/Apple_01 (1)");
                }

                return Obj_Apple_2;
            }
        }

        private static GameObject Obj_Apple_3;
        internal static GameObject Apple_3
        {
            get
            {
                if (!isCurrentWorld) return null;

                if (Obj_Apple_3 == null)
                {
                    return Obj_Apple_3 = GameObjectFinder.Find("Apples/Apple_01 (2)");
                }

                return Obj_Apple_3;
            }
        }
        private static GameObject Obj_Apple_4;
        internal static GameObject Apple_4
        {
            get
            {
                if (!isCurrentWorld) return null;

                if (Obj_Apple_4 == null)
                {
                    return Obj_Apple_4 = GameObjectFinder.Find("Apples/Apple_01 (3)");
                }

                return Obj_Apple_4;
            }
        }
        internal static GameObject BlueWrench { get; set; }

        internal static GameObject Hammer { get; set; }
        internal static GameObject RedWrench { get; set; }

        //internal static List<SuperTowerDefense_NearbyCollider> NearbyCollidersManager = new();
        private static GameObject ReturnHammerButtonTool { get; set; }

        private static GameObject ReturnBlueWrenchButton { get; set; }
        private static GameObject ReturnRedWrenchButton { get; set; }

        internal static QMNestedGridMenu SuperTowerDefensecheatPage { get; set; }

        internal static SuperTowerDefense_WaveEditor WaveEditor { get; set; }
        internal static SuperTowerDefense_HealthEditor HealthEditor { get; set; }
        internal static SuperTowerDefense_BankEditor BankEditor { get; set; }

        internal static SuperTowerDefense_AutoStarter AutoStarterReader { get; set; }
        private static QMSingleButton CurrentLifes { get; set; }
        private static QMSingleButton TimesBoughtLifesAmount { get; set; }

        private static QMSingleButton CurrentWave { get; set; }

        private static QMToggleButton RepairLifeWrenchToolsButton { get; set; }
        private static QMToggleButton LoseLifeHammerToolBtn { get; set; }
        private static QMToggleButton FreezeHammerToolBtn { get; set; }
        private static QMToggleButton FreezeBlueWrenchToolBtn { get; set; }
        private static QMToggleButton FreezeRedWrenchToolBtn { get; set; }

        private static QMToggleButton BlockHammerReturnToolBtn { get; set; }

        private static QMToggleButton BlockWrenchReturnToolBtn { get; set; }
        private static QMToggleButton FreezeRocketLauncherTowerToolBtn { get; set; }
        private static QMToggleButton FreezeSlowerTowerToolBtn { get; set; }
        private static QMToggleButton FreezeCannonTowerToolBtn { get; set; }
        private static QMToggleButton FreezeRadarTowerToolBtn { get; set; }
        private static QMToggleButton FreezeMinigunTowerToolBtn { get; set; }
        private static QMToggleButton FreezeLanceTowerToolBtn { get; set; }
        private static QMToggleButton FreezeAllTowersToolBtn { get; set; }

        private static QMToggleButton AutomaticWaveBtn { get; set; }
        private static QMToggleButton AutoStartKeepActiveBtn { get; set; }
        private static QMToggleButton AutoStartKeepInactiveBtn { get; set; }

        private static QMToggleButton AutomaticGodModebnt { get; set; }
        private static QMToggleButton FreezeMoneyBtn { get; set; }
        private static QMToggleButton FixBalanceNegativeBtn { get; set; }
        private static object cancellationwavetoken { get; set; }

        private static VRC_AstroPickup RedWrenchPickup { get; set; }
        private static VRC_AstroPickup BlueWrenchPickup { get; set; }
        private static VRC_AstroPickup HammerPickup { get; set; }

        internal static UdonBehaviour_Cached ResetHealth { get; private set; }

        internal static UdonBehaviour_Cached LoseHealth { get; private set; }

        internal static UdonBehaviour_Cached WaveEvent { get; private set; }

        internal static UdonBehaviour_Cached ResetBalance { get; private set; }

        internal static UdonBehaviour_Cached AutoStarter_Place { get; private set; }
        internal static UdonBehaviour_Cached AutoStarter_SetActive { get; private set; }
        internal static UdonBehaviour_Cached AutoStarter_SetInactive { get; private set; }

        internal static bool? KeepAutoStarterActive
        {
            get
            {
                if (AutoStarterReader != null)
                {
                    return AutoStarterReader.KeepAutoStarterActive;
                }

                return null;
            }
            set
            {
                if (AutoStarterReader != null)
                {
                    AutoStarterReader.KeepAutoStarterActive = value.GetValueOrDefault(false);
                }
            }
        }

        internal static bool? KeepAutoStarterInactive
        {
            get
            {
                if (AutoStarterReader != null)
                {
                    return AutoStarterReader.KeepAutoStarterInactive;
                }

                return null;
            }
            set
            {
                if (AutoStarterReader != null)
                {
                    AutoStarterReader.KeepAutoStarterInactive = value.GetValueOrDefault(false);
                }
            }
        }

    }
}