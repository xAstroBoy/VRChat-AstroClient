namespace AstroClient.ClientUI.ActionMenu.WorldModule
{
    using Gompoc.ActionMenuAPI.Api;
    using System.Drawing;
    using Tools.Extensions;
    using WorldModifications.Modifications;
    using WorldModifications.Modifications.Jar.AmongUS;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;

    internal class WorldCheatsModule : AstroEvents
    {
        internal override void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("World Modules", () =>
            {
                #region Super Tower Defense

                if (WorldUtils.WorldID == WorldIds.Super_Tower_defense)
                {
                    CustomSubMenu.AddSubMenu("Super Tower Defense", () =>
                    {
                        CustomSubMenu.AddSubMenu("Fixes", () =>
                        {
                            CustomSubMenu.AddButton("Fix Towers And Respawn", () => { SuperTowerDefense.FixTheTowers(true); });
                            CustomSubMenu.AddButton("Fix Towers No Respawn", () => { SuperTowerDefense.FixTheTowers(false); });
                            CustomSubMenu.AddButton("Fix Towers Colliders", () => { SuperTowerDefense.FixTowerColliders(); });
                        }, null, false, null);

                        CustomSubMenu.AddSubMenu("Protections", () =>
                        {
                            CustomSubMenu.AddToggle("Block hammer Return Button", SuperTowerDefense.BlockHammerReturnButton, ToggleValue => { SuperTowerDefense.BlockHammerReturnButton = ToggleValue; });
                            CustomSubMenu.AddToggle("Block Wrenchs Return Buttons", SuperTowerDefense.BlockWrenchReturnButton, ToggleValue => { SuperTowerDefense.BlockWrenchReturnButton = ToggleValue; });
                            CustomSubMenu.AddToggle("Freeze hammer", SuperTowerDefense.FreezeHammer, ToggleValue => { SuperTowerDefense.FreezeHammer = ToggleValue; });
                            CustomSubMenu.AddToggle("Freeze Red Wrench", SuperTowerDefense.FreezeRedWrench, ToggleValue => { SuperTowerDefense.FreezeRedWrench = ToggleValue; });
                            CustomSubMenu.AddToggle("Freeze Blue Wrench", SuperTowerDefense.FreezeBlueWrench, ToggleValue => { SuperTowerDefense.FreezeBlueWrench = ToggleValue; });
                            CustomSubMenu.AddToggle("Freeze All Towers", SuperTowerDefense.FreezeAllTowers, ToggleValue => { SuperTowerDefense.FreezeAllTowers = ToggleValue; });
                            CustomSubMenu.AddSubMenu("Towers Freeze Panel", () =>
                            {
                                CustomSubMenu.AddToggle("Freeze Cannon Tower", SuperTowerDefense.FreezeCannonTower, ToggleValue => { SuperTowerDefense.FreezeCannonTower = ToggleValue; });
                                CustomSubMenu.AddToggle("Freeze Radar Tower", SuperTowerDefense.FreezeRadarTower, ToggleValue => { SuperTowerDefense.FreezeRadarTower = ToggleValue; });
                                CustomSubMenu.AddToggle("Freeze Lance Tower", SuperTowerDefense.FreezeLanceTower, ToggleValue => { SuperTowerDefense.FreezeLanceTower = ToggleValue; });
                                CustomSubMenu.AddToggle("Freeze Slower Tower", SuperTowerDefense.FreezeSlowerTower, ToggleValue => { SuperTowerDefense.FreezeSlowerTower = ToggleValue; });
                                CustomSubMenu.AddToggle("Freeze Rocket Launcher Tower", SuperTowerDefense.FreezeRocketLauncherTower, ToggleValue => { SuperTowerDefense.FreezeRocketLauncherTower = ToggleValue; });
                                CustomSubMenu.AddToggle("Freeze MiniGun Tower", SuperTowerDefense.FreezeMinigunTower, ToggleValue => { SuperTowerDefense.FreezeMinigunTower = ToggleValue; });
                            }, null, false, null);

                        });
                        CustomSubMenu.AddSubMenu("Tool Mods", () =>
                        {
                            CustomSubMenu.AddToggle("Repair Life Wrenches", SuperTowerDefense.RepairLifeWrenches, ToggleValue => { SuperTowerDefense.RepairLifeWrenches = ToggleValue; });
                            CustomSubMenu.AddToggle("Lose Life Hammer", SuperTowerDefense.LoseLifeHammer, ToggleValue => { SuperTowerDefense.LoseLifeHammer = ToggleValue; });
                        }, null, false, null);
                        CustomSubMenu.AddSubMenu("Cheats", () =>
                        {
                            CustomSubMenu.AddButton("Reset Heart", () => { SuperTowerDefense.ResetHealth?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Remove a Heart", () => { SuperTowerDefense.LoseHealth?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Reset Bank Amount", () => { SuperTowerDefense.ResetBalance?.InvokeBehaviour(); });
                            CustomSubMenu.AddToggle("Automatic Wave", SuperTowerDefense.AutomaticWaveStart, ToggleValue => { SuperTowerDefense.AutomaticWaveStart = ToggleValue; });
                            CustomSubMenu.AddToggle("Automatic God Mode", SuperTowerDefense.GodMode.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.GodMode = ToggleValue; });
                            //CustomSubMenu.AddToggle("Bypass Tower Collider", SuperTowerDefense.IgnoreTowersCollidersPlacement, ToggleValue => { SuperTowerDefense.IgnoreTowersCollidersPlacement = ToggleValue; });

                        }, null, false, null);
                        CustomSubMenu.AddSubMenu("Towers Editor", () =>
                        {

                            CustomSubMenu.AddSubMenu("Tower Range", () =>
                            {
                                CustomSubMenu.AddButton("+0.5f Range", () => { SuperTowerDefense.AddTowerRange(0.5f); });
                                CustomSubMenu.AddButton("+1f Range", () => { SuperTowerDefense.AddTowerRange(1f); });
                                CustomSubMenu.AddButton("-0.5f Range", () => { SuperTowerDefense.RemoveTowerRange(0.5f); });
                                CustomSubMenu.AddButton("-1f Range", () => { SuperTowerDefense.RemoveTowerRange(1f); });
                                CustomSubMenu.AddButton("9999 Range", () => { SuperTowerDefense.SetTowersRange(9999f); });
                                CustomSubMenu.AddButton("Reset Range", () => { SuperTowerDefense.RestoreTowerRange(); });
                            }, null, false, null);

                            CustomSubMenu.AddSubMenu("Tower Speed", () =>
                            {
                                CustomSubMenu.AddButton("+0.5f Speed", () => { SuperTowerDefense.AddTowerSpeed(0.5f); });
                                CustomSubMenu.AddButton("+1f Speed", () => { SuperTowerDefense.AddTowerSpeed(1f); });
                                CustomSubMenu.AddButton("-0.5f Speed", () => { SuperTowerDefense.RemoveTowerSpeed(0.5f); });
                                CustomSubMenu.AddButton("-1f Speed", () => { SuperTowerDefense.RemoveTowerSpeed(1f); });
                                CustomSubMenu.AddButton("9999 Speed", () => { SuperTowerDefense.SetTowerSpeed(9999f); });
                                CustomSubMenu.AddButton("Reset Speed", () => { SuperTowerDefense.RestoreTowerSpeed(); });
                            }, null, false, null);



                        }, null, false, null);
                        CustomSubMenu.AddSubMenu("Auto Starter Control", () =>
                        {
                            CustomSubMenu.AddButton("Place AutoStarter", () => { SuperTowerDefense.AutoStarter_Place?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Activate AutoStarter", () => { SuperTowerDefense.AutoStarter_SetActive?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Deactivate AutoStarter", () => { SuperTowerDefense.AutoStarter_SetInactive?.InvokeBehaviour(); });
                            CustomSubMenu.AddToggle("Keep AutoStart ON", SuperTowerDefense.KeepAutoStarterActive.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.KeepAutoStarterActive = ToggleValue; });
                            CustomSubMenu.AddToggle("Keep AutoStart OFF", SuperTowerDefense.KeepAutoStarterInactive.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.KeepAutoStarterInactive = ToggleValue; });
                        }, null, false, null);
                        CustomSubMenu.AddSubMenu("Bank Mods", () =>
                        {
                            CustomSubMenu.AddButton("Reset Bank Amount", () => { SuperTowerDefense.ResetBalance?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Set 0 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.CurrentBankBalance.HasValue) { SuperTowerDefense.BankEditor.CurrentBankBalance = 0; } });
                            CustomSubMenu.AddButton("Add 10000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.CurrentBankBalance.HasValue) { SuperTowerDefense.BankEditor.CurrentBankBalance = SuperTowerDefense.BankEditor.CurrentBankBalance.Value + 10000; } });
                            CustomSubMenu.AddButton("Add 100000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.CurrentBankBalance.HasValue) { SuperTowerDefense.BankEditor.CurrentBankBalance = SuperTowerDefense.BankEditor.CurrentBankBalance.Value + 100000; } });
                            CustomSubMenu.AddButton("Add 1000000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.CurrentBankBalance.HasValue) { SuperTowerDefense.BankEditor.CurrentBankBalance = SuperTowerDefense.BankEditor.CurrentBankBalance.Value + 1000000; } });
                            CustomSubMenu.AddButton("Add 10000000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.CurrentBankBalance.HasValue) { SuperTowerDefense.BankEditor.CurrentBankBalance = SuperTowerDefense.BankEditor.CurrentBankBalance.Value + 10000000; } });
                            CustomSubMenu.AddButton("Set 999999999 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.CurrentBankBalance.HasValue) { SuperTowerDefense.BankEditor.CurrentBankBalance = 999999999; } });
                        });
                        CustomSubMenu.AddSubMenu("Health Mods", () =>
                        {
                            CustomSubMenu.AddButton("Reset Heart", () => { SuperTowerDefense.ResetHealth?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Heart +1", () => { if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue) { SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value + 1; SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value + 1; } });
                            CustomSubMenu.AddButton("Heart +10", () => { if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue) { SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value + 10; SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value + 10; } });
                            CustomSubMenu.AddButton("Heart +100", () => { if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue) { SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value + 100; SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value + 100; } });
                            CustomSubMenu.AddButton("Heart -1", () => { if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue) { SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value - 1; SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value - 1; } });
                            CustomSubMenu.AddButton("Heart -10", () => { if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue) { SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value - 10; SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value - 10; } });
                            CustomSubMenu.AddButton("Heart -100", () => { if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue) { SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value - 100; SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value - 100; } });

                        });

                    }, null, false, null);
                }

                #endregion Super Tower Defense

                #region AmongUS

                if (WorldUtils.WorldID == WorldIds.AmongUS)
                {
                    CustomSubMenu.AddSubMenu("Among US", () =>
                    {
                        CustomSubMenu.AddToggle("AmongUS Serializer", AmongUSCheats.AmongUsSerializer, ToggleValue => { AmongUSCheats.AmongUsSerializer = ToggleValue; });

                        CustomSubMenu.AddSubMenu("Game Events", () => { CustomSubMenu.AddButton("Emergency Meeting", () => { AmongUSCheats.EmergencyMeetingEvent?.InvokeBehaviour(); }); });

                        CustomSubMenu.AddSubMenu("Sabotage & Repair", () =>
                        {
                            CustomSubMenu.AddButton("Cancel Sabotages", () => { AmongUSCheats.CancelAllSabotages?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Sabotage Lights", () => { AmongUSCheats.SabotageLights?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Sabotage Doors", () => { AmongUSCheats.SabotageAllDoors.InvokeBehaviour(); });
                        });

                        CustomSubMenu.AddSubMenu("Task Faker", () =>
                        {
                            CustomSubMenu.AddButton("Submit Scan", () => { AmongUSCheats.SubmitScanTask?.InvokeBehaviour(); });
                            CustomSubMenu.AddSubMenu("Garbage", () =>
                            {
                                CustomSubMenu.AddButton("Cafeteria A", () => { AmongUSCheats.EmptyGarbage_Cafeteria_A?.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Cafeteria B", () => { AmongUSCheats.EmptyGarbage_Cafeteria_B?.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Oxygen A", () => { AmongUSCheats.EmptyGarbage_Oxygen_A?.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Oxygen B", () => { AmongUSCheats.EmptyGarbage_Oxygen_A?.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Storage A", () => { AmongUSCheats.EmptyGarbage_Storage_A?.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Storage B", () => { AmongUSCheats.EmptyGarbage_Storage_B?.InvokeBehaviour(); });
                            }, null, false, null);
                        }, null, false, null);
                    });
                }

                #endregion AmongUS

                #region  ClickerGame

                if (WorldUtils.WorldID == WorldIds.Clicker_Game)
                {
                    CustomSubMenu.AddSubMenu("Clicker Game", () =>
                    {

                        CustomSubMenu.AddToggle("AutoClicker", ClickerGame.CubeAutoClicker, ToggleValue => { ClickerGame.CubeAutoClicker = ToggleValue; });

                    });
                }


                #endregion

                #region  BOMBERio

                if (WorldUtils.WorldID == WorldIds.BOMBERio)
                {
                    CustomSubMenu.AddSubMenu("BOMBERio", () =>
                    {
                        CustomSubMenu.AddSubMenu("Gun Modifier", () =>
                        {
                            CustomSubMenu.AddToggle("Shoot Bomb 0", BOMBERio.Override_ShootBomb_0_Toggle, ToggleValue => { BOMBERio.Override_ShootBomb_0_Toggle = ToggleValue; });
                            CustomSubMenu.AddToggle("Shoot Bomb 1", BOMBERio.Override_ShootBomb_1_Toggle, ToggleValue => { BOMBERio.Override_ShootBomb_1_Toggle = ToggleValue; });
                            CustomSubMenu.AddToggle("Shoot Bomb 2", BOMBERio.Override_ShootBomb_2_Toggle, ToggleValue => { BOMBERio.Override_ShootBomb_2_Toggle = ToggleValue; });
                            CustomSubMenu.AddToggle("Shoot Bomb 3", BOMBERio.Override_ShootBomb_3_Toggle, ToggleValue => { BOMBERio.Override_ShootBomb_3_Toggle = ToggleValue; });
                            CustomSubMenu.AddToggle("Shoot First Player Bomb", BOMBERio.Override_ShootBomb_4_Toggle, ToggleValue => { BOMBERio.Override_ShootBomb_4_Toggle = ToggleValue; });
                            CustomSubMenu.AddToggle("Shoot Rocket", BOMBERio.Override_ShootBomb_5_Toggle, ToggleValue => { BOMBERio.Override_ShootBomb_5_Toggle = ToggleValue; });
                        });

                        CustomSubMenu.AddSubMenu("Crystal Harvester", () =>
                        {
                            CustomSubMenu.AddButton("Harvest 10 Crystals", () => { BOMBERio.HarvestQuads(10); });
                            CustomSubMenu.AddButton("Harvest 20 Crystals", () => { BOMBERio.HarvestQuads(20); });
                            CustomSubMenu.AddButton("Harvest 50 Crystals", () => { BOMBERio.HarvestQuads(50); });
                            CustomSubMenu.AddButton("Harvest 100 Crystals", () => { BOMBERio.HarvestQuads(100); });
                            CustomSubMenu.AddButton("Harvest 500 Crystals", () => { BOMBERio.HarvestQuads(500); });
                            CustomSubMenu.AddButton("Harvest 1000 Crystals", () => { BOMBERio.HarvestQuads(1000); });
                        });

                        CustomSubMenu.AddToggle("Bypass Outside Circle Speed", BOMBERio.BypassOutsideCircleSpeed, ToggleValue => { BOMBERio.BypassOutsideCircleSpeed = ToggleValue; });

                    });
                }


                #endregion


            }, ClientResources.Loaders.Icons.thief);

            ModConsole.Log("World Module is ready!", Color.Green);
        }
    }
}