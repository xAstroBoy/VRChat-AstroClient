namespace AstroClient.WorldModifications.Modifications
{
    using AstroMonos.AstroUdons;
    using AstroMonos.Components.Cheats.Worlds.SuperTowerDefense;
    using AstroMonos.Components.Tools;
    using AstroMonos.Components.Tools.FreezeLocation;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;

    internal class SuperTowerDefense : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Tower_defense)
            {
                if (SuperTowerDefensecheatPage != null)
                {
                    SuperTowerDefensecheatPage.SetInteractable(true);
                    SuperTowerDefensecheatPage.SetTextColor(Color.green);
                }

                ModConsole.Log($"Recognized {Name}, Cheats available.");
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

                var RedWrench = GameObjectFinder.Find("UpgradeTool0");
                var BlueWrench = GameObjectFinder.Find("UpgradeTool1");
                var Hammer = GameObjectFinder.Find("SellTool");
                if (RedWrench != null)
                {
                    RedWrenchPickup = RedWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (RedWrenchPickup != null)
                    {
                        RedWrenchPickup.OnPickupUseUp = null;
                        RedWrenchPickup.OnPickupUseUp += new System.Action(() => { ResetHealth.InvokeBehaviour(); });
                        RedWrenchPickup.enabled = false;
                    }
                }
                if (BlueWrench != null)
                {
                    BlueWrenchPickup = BlueWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (BlueWrenchPickup != null)
                    {
                        BlueWrenchPickup.OnPickupUseUp = null;
                        BlueWrenchPickup.OnPickupUseUp += new System.Action(() => { ResetHealth.InvokeBehaviour(); });
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
                var CanvasesObj = GameObjectFinder.Find("WaveInteractables/SM_Bld_Portable_Office_01 (1)/WavePaper");
                if (CanvasesObj != null)
                {
                    foreach (var text in CanvasesObj.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                    {
                        if (text != null)
                        {
                            if (!text.text.ToLower().Equals("wave"))
                            {
                                text.resizeTextForBestFit = true;
                                ModConsole.DebugLog($"Fixed Canvas : {text.gameObject.name}");
                            }
                        }
                    }
                }

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

                //foreach (var item in GameObjectFinder.RootSceneObjects_WithoutAvatars)
                //{
                //    if (item != null)
                //    {
                //        if (item.name.isMatch("NearbyCollider"))
                //        {
                //            var colliderman = item.GetOrAddComponent<SuperTowerDefense_NearbyCollider>();
                //            if (colliderman != null)
                //            {
                //                NearbyCollidersManager.Add(colliderman);
                //            }
                //        }
                //    }
                //}

                FixTheTowers(false);
                foreach (var apple in WorldApples)
                {
                    if (Apple_1 == null)
                    {
                        Apple_1 = apple;
                        continue;
                    }
                    if (Apple_2 == null)
                    {
                        Apple_2 = apple;
                        continue;
                    }
                    if (Apple_3 == null)
                    {
                        Apple_3 = apple;
                        continue;
                    }
                    if (Apple_4 == null)
                    {
                        Apple_4 = apple;
                        continue;
                    }
                }
            }
            else
            {
                if (SuperTowerDefensecheatPage != null)
                {
                    SuperTowerDefensecheatPage.SetInteractable(false);
                    SuperTowerDefensecheatPage.SetTextColor(Color.red);
                }
            }
        }

        internal override void OnRoomLeft()
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

            Apple_1 = null;
            Apple_2 = null;

            Apple_3 = null;
            Apple_4 = null;

            ReturnBlueWrenchButton = null;
            ReturnRedWrenchButton = null;

            Tower_RocketLauncher = null;
            Tower_Slower = null;
            Tower_Cannon = null;
            Tower_Radar = null;
            Tower_Minigun = null;
            Tower_Lance = null;
            BlockWrenchReturnButton = false;
            FreezeTowers = false;
            IgnoreTowersCollidersPlacement = false;
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
        }

        private static void FixTower(GameObject tower, bool RespawnTowers)
        {
            if (tower != null)
            {
                tower.Pickup_Set_Pickupable(true); // Override and fix potential Tower Bugs.
                if (RespawnTowers)
                {
                    tower.TakeOwnership();
                    tower.GetComponentInChildren<SyncPhysics>(true)?.RespawnItem();
                }
            }
        }

        internal static void InitButtons(QMGridTab main)
        {
            SuperTowerDefensecheatPage = new QMNestedGridMenu(main, "Super Tower Defense", "Super Tower Defense Cheats");

            var bankmods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Bank Mods", "Modify Current Bank Balance");
            _ = new QMSingleButton(bankmods, "Set 0 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = 0; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 10000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 10000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 100000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 100000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 1000000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 1000000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 10000000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 10000000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Set 999999999 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = 999999999; } }, "Edit Current Balance!");

            var WaveMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Wave Mods", "Modify Current Rounds");

            _ = new QMSingleButton(WaveMods, "Wave +1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 1; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave +10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 10; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave +100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 100; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave -1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 1; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave -10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 10; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods, "Wave -100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 100; } }, "Edit Current Round!");

            var LifeMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Health Mods", "Modify Current Healths");

            _ = new QMSingleButton(LifeMods, "Life +1", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 1; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life +10", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 10; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life +100", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value + 100; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life -1", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value - 1; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life -10", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value - 10; } }, "Edit Current Health!");
            _ = new QMSingleButton(LifeMods, "Life -100", () => { if (HealthEditor != null && HealthEditor.CurrentHealth.HasValue) { HealthEditor.CurrentHealth = HealthEditor.CurrentHealth.Value - 100; } }, "Edit Current Health!");


            var TowerMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Towers Mods", "Make Towers SuperPowerful");

            _ = new QMSingleButton(TowerMods, "Super Tower Range", () => { SetTowersRange(9999f); }, "Edit Towers Range to maximum!");
            _ = new QMSingleButton(TowerMods, "Super Tower Speed", () => { SetTowerSpeed(9999f); }, "Edit Towers Speed to maximum!");

            var ToolMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Tool Mods", "Enable Extra Tools");
            RepairLifeWrenchToolsButton = new QMToggleButton(ToolMods, "Toggle Repair life Wrenches", () => { RepairLifeWrenches = true; }, () => { RepairLifeWrenches = false; }, "Wrenches = Reset Health, Hammer = Lose health (useful to troll)!");
            LoseLifeHammerToolBtn = new QMToggleButton(ToolMods, "Toggle Lose Life Hammer", () => { LoseLifeHammer = true; }, () => { LoseLifeHammer = false; }, "Hammer = Lose health (useful to troll)!");

            AutomaticWaveBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = true; }, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = false; }, "Turn the Red Wrench able to reset health on interact!");
            AutomaticGodModebnt = new QMToggleButton(SuperTowerDefensecheatPage, "Toggle Automatic \n GodMode", () => { GodMode = true; }, "Toggle Automatic \n GodMode", () => { GodMode = false; }, "Turn the Red Wrench able to reset health on interact!");

            new QMSingleButton(SuperTowerDefensecheatPage, "Fix towers", () => { FixTheTowers(true); }, "Fix Towers Being unpickable bug ", Color.green);
            FreezeHammerToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Freeze Hammer", () => { FreezeHammer = true; }, () => { FreezeHammer = false; }, "Add a Protection Shield to the hammer!");
            FreezeTowersToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Freeze Towers", () => { FreezeTowers = true; }, () => { FreezeTowers = false; }, "Freeze Towers In place (Fight against trolls!)");
            IgnoreTowersCollidersPlacementToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Bypass Tower Collider", () => { IgnoreTowersCollidersPlacement = true; }, () => { IgnoreTowersCollidersPlacement = false; }, "Allow Overlapping Towers!");

            BlockHammerReturnToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Block Hammer Return", () => { BlockHammerReturnButton = true; }, () => { BlockHammerReturnButton = false; }, "Add a Protection Shield to the hammer Return Button using Two Apples!");
            BlockHammerReturnToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Block Wrenchs Returns", () => { BlockWrenchReturnButton = true; }, () => { BlockWrenchReturnButton = false; }, "Add a Protection Shield to the hammer Return Button using Two Apples!");
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

        private static List<GameObject> WorldApples
        {
            get
            {
                List<GameObject> result = new List<GameObject>();
                foreach (var item in WorldUtils.Pickups)
                {
                    if (item.name.StartsWith("Apple"))
                    {
                        result.Add(item.gameObject);
                    }
                }

                return result;
            }
        }

        private static void SetTowersRange(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    tower.Range = value;
                }
            }
        }

        private static void SetTowerSpeed(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    if (tower.name.Contains("RocketLauncher")) continue; // Ignore due to Lag reasons.

                    tower.SpeedMultiplier = value;
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
                    ModConsole.DebugLog($"Locked {item.name} to pos ${item.FreezePos.ToString()} and Rotation {item.FreezeRot.ToString()}");
                }
            }
        }

        private static bool _FreezeTowers;

        internal static bool FreezeTowers
        {
            get
            {
                return _FreezeTowers;
            }
            set
            {
                if (FreezeTowersToolBtn != null)
                {
                    FreezeTowersToolBtn.SetToggleState(value);
                }
                _FreezeTowers = value;

                if (value)
                {
                    LockTowerInPlace(Tower_RocketLauncher);
                    LockTowerInPlace(Tower_Slower);
                    LockTowerInPlace(Tower_Cannon);
                    LockTowerInPlace(Tower_Radar);
                    LockTowerInPlace(Tower_Minigun);
                    LockTowerInPlace(Tower_Lance);
                }
                else
                {
                    RemoveLockOnItem(Tower_RocketLauncher);
                    RemoveLockOnItem(Tower_Slower);
                    RemoveLockOnItem(Tower_Cannon);
                    RemoveLockOnItem(Tower_Radar);
                    RemoveLockOnItem(Tower_Minigun);
                    RemoveLockOnItem(Tower_Lance);
                }
            }
        }

        private static bool _IgnoreTowersCollidersPlacement;

        internal static bool IgnoreTowersCollidersPlacement
        {
            get
            {
                return _IgnoreTowersCollidersPlacement;
            }
            set
            {
                if (IgnoreTowersCollidersPlacementToolBtn != null)
                {
                    IgnoreTowersCollidersPlacementToolBtn.SetToggleState(value);
                }
                _IgnoreTowersCollidersPlacement = value;

                if (value)
                {
                    Tower_RocketLauncher.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Slower.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Cannon.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Radar.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Minigun.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Lance.GetOrAddComponent<SuperTowerDefense_TowerSkipCollider>();
                }
                else
                {
                    Tower_RocketLauncher.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Slower.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Cannon.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Radar.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Minigun.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
                    Tower_Lance.RemoveComponent<SuperTowerDefense_TowerSkipCollider>();
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
                            ModConsole.DebugLog($"Locked {item.name} to pos ${item.FreezePos.ToString()} and Rotation {item.FreezeRot.ToString()}");
                        }
                    }
                    else
                    {
                        HammerPickup.gameObject.Remove_ObjectFreezer();
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
                item.Remove_ObjectFreezer();
                item.GetComponentInChildren<SyncPhysics>(true).RespawnItem(true);
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
                            ModConsole.DebugLog($"Locked {Freezer.gameObject.name} to pos ${Freezer.FreezePos.ToString()} and Rotation {Freezer.FreezeRot.ToString()}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
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
                    if (AutomaticGodModebnt != null)
                    {
                        AutomaticGodModebnt.SetToggleState(value.Value);
                    }

                    if (HealthEditor != null)
                    {
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

        internal static GameObject Apple_1 { get; set; }
        internal static GameObject Apple_2 { get; set; }

        internal static GameObject Apple_3 { get; set; }
        internal static GameObject Apple_4 { get; set; }

        //internal static List<SuperTowerDefense_NearbyCollider> NearbyCollidersManager = new();
        private static GameObject ReturnHammerButtonTool { get; set; }

        private static GameObject ReturnBlueWrenchButton { get; set; }
        private static GameObject ReturnRedWrenchButton { get; set; }

        internal static QMNestedGridMenu SuperTowerDefensecheatPage { get; set; }

        internal static SuperTowerDefense_WaveEditor WaveEditor { get; set; }
        internal static SuperTowerDefense_HealthEditor HealthEditor { get; set; }
        internal static SuperTowerDefense_BankEditor BankEditor { get; set; }

        private static QMToggleButton RepairLifeWrenchToolsButton { get; set; }
        private static QMToggleButton LoseLifeHammerToolBtn { get; set; }
        private static QMToggleButton FreezeHammerToolBtn { get; set; }
        private static QMToggleButton BlockHammerReturnToolBtn { get; set; }

        private static QMToggleButton BlockWrenchReturnToolBtn { get; set; }
        private static QMToggleButton FreezeTowersToolBtn { get; set; }
        private static QMToggleButton IgnoreTowersCollidersPlacementToolBtn { get; set; }

        private static QMToggleButton AutomaticWaveBtn { get; set; }

        private static QMToggleButton AutomaticGodModebnt { get; set; }

        private static object cancellationwavetoken { get; set; }

        private static VRC_AstroPickup RedWrenchPickup { get; set; }
        private static VRC_AstroPickup BlueWrenchPickup { get; set; }
        private static VRC_AstroPickup HammerPickup { get; set; }

        internal static UdonBehaviour_Cached ResetHealth { get; private set; }

        internal static UdonBehaviour_Cached LoseHealth { get; private set; }

        internal static UdonBehaviour_Cached WaveEvent { get; private set; }

        internal static UdonBehaviour_Cached ResetBalance { get; private set; }

        internal static UdonBehaviour_Cached SpawnAutoStart { get; private set; }

    }
}