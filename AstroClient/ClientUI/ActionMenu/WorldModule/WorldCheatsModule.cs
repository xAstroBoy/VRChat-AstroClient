namespace AstroClient.ClientUI.ActionMenu.WorldModule
{
    using Gompoc.ActionMenuAPI.Api;
    using Tools.Extensions;
    using UnityEngine;
    using WorldModifications.WorldHacks;
    using WorldModifications.WorldHacks.Jar.AmongUS;
    using WorldModifications.WorldHacks.Jar.KitchenCooks;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using Color = System.Drawing.Color;

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
                        }, null, false, null);

                        CustomSubMenu.AddSubMenu("Protections", () =>
                        {
                            CustomSubMenu.AddToggle("Block hammer Return Button", SuperTowerDefense.BlockHammerReturnButton, ToggleValue => { SuperTowerDefense.BlockHammerReturnButton = ToggleValue; });
                            CustomSubMenu.AddToggle("Block Wrenchs Return Buttons", SuperTowerDefense.BlockWrenchReturnButton, ToggleValue => { SuperTowerDefense.BlockWrenchReturnButton = ToggleValue; });
                            CustomSubMenu.AddToggle("Freeze hammer", SuperTowerDefense.FreezeHammer, ToggleValue => { SuperTowerDefense.FreezeHammer = ToggleValue; });
                            CustomSubMenu.AddToggle("Crazy hammer", SuperTowerDefense.CrazyHammer, ToggleValue => { SuperTowerDefense.CrazyHammer = ToggleValue; });
                            CustomSubMenu.AddToggle("AntiTheft hammer", SuperTowerDefense.Hammer_AntiTheft, ToggleValue => { SuperTowerDefense.Hammer_AntiTheft = ToggleValue; });

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
                            CustomSubMenu.AddToggle("Freeze Money Balance", SuperTowerDefense.FreezeMoney.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.FreezeMoney = ToggleValue; });
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
                            CustomSubMenu.AddToggle("Freeze Money Balance", SuperTowerDefense.FreezeMoney.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.FreezeMoney = ToggleValue; });
                            CustomSubMenu.AddToggle("Anti-negative Balance", SuperTowerDefense.FixBalanceNegative.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.FixBalanceNegative = ToggleValue; });

                            CustomSubMenu.AddButton("Set 0 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) { SuperTowerDefense.BankEditor.Money = 0; } });
                            CustomSubMenu.AddButton("Add 10000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) { SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 10000; } });
                            CustomSubMenu.AddButton("Add 100000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) { SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 100000; } });
                            CustomSubMenu.AddButton("Add 1000000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) { SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 1000000; } });
                            CustomSubMenu.AddButton("Add 10000000 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) { SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 10000000; } });
                            CustomSubMenu.AddButton("Set 999999999 Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) { SuperTowerDefense.BankEditor.Money = 999999999; } });
                            CustomSubMenu.AddButton($"Set {int.MaxValue} Money", () => { if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) { SuperTowerDefense.BankEditor.Money = int.MaxValue; } });

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

                        CustomSubMenu.AddSubMenu("Game Events", () =>
                        {
                            CustomSubMenu.AddButton("Emergency Meeting", () =>
                            {
                                AmongUSCheats.EmergencyMeetingEvent?.InvokeBehaviour();

                            });
                        });

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
                                CustomSubMenu.AddButton("Cafeteria", () => { AmongUSCheats.EmptyGarbage_Cafeteria_B?.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Oxygen", () => { AmongUSCheats.EmptyGarbage_Oxygen_A?.InvokeBehaviour(); });
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
                #region  Kitchen Cooks

                if (WorldUtils.WorldID == WorldIds.KitchenCooks)
                {
                    CustomSubMenu.AddSubMenu("Kitchen Cooks", () =>
                    {

                        CustomSubMenu.AddToggle("Private Golden Knifes", KitchenCooksCheats.OnlySelfHasPatreonPerk, ToggleValue =>
                        {
                            KitchenCooksCheats.OnlySelfHasPatreonPerk = ToggleValue;
                            KitchenCooksCheats.EveryoneHasPatreonPerk = false;
                        });
                        CustomSubMenu.AddToggle("Public Golden Knifes", KitchenCooksCheats.EveryoneHasPatreonPerk, ToggleValue =>
                        {
                            KitchenCooksCheats.OnlySelfHasPatreonPerk = false;
                            KitchenCooksCheats.EveryoneHasPatreonPerk = ToggleValue;
                            ;
                        });

                    });
                }

                #endregion
                #region  PuttPuttPond

                if (WorldUtils.WorldID == WorldIds.PuttPuttPond)
                {
                    CustomSubMenu.AddSubMenu("Putt Putt Pond", () =>
                    {
                        CustomSubMenu.AddToggle("Patron Mode", PuttPuttPond.isPatron.GetValueOrDefault(false), ToggleValue => { PuttPuttPond.isPatron = ToggleValue; });
                        CustomSubMenu.AddToggle("Rainbow Golf ball", PuttPuttPond.RainbowBall, ToggleValue => { PuttPuttPond.RainbowBall = ToggleValue; });

                    });
                }

                #endregion
                #region  Ghost Game

                if (WorldUtils.WorldID == WorldIds.GhostGame)
                {
                    CustomSubMenu.AddSubMenu("Ghost Game", () =>
                    {
                        CustomSubMenu.AddSubMenu("Mirror Control", () =>
                        {
                            CustomSubMenu.AddButton("Toggle Lobby Mirrors (Fuck the Mirror zombies !)", () => { GhostGame.ToggleMirrors_1.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Toggle Mailbox Mirrors (Fuck the Mirror zombies !)", () => { GhostGame.ToggleMirrors_2.InvokeBehaviour(); });
                            CustomSubMenu.AddToggle("Turn Off Mirrors Troll (Spams Mirror Off event to piss Mirror zombies!)", GhostGame.FuckOffMirrorZombies, value => { GhostGame.FuckOffMirrorZombies = value; });
                        });

                        CustomSubMenu.AddSubMenu("Cheats", () =>
                        {
                            CustomSubMenu.AddButton("Teleport To Armory Zone", () => { GameInstances.LocalPlayer.gameObject.transform.position = new Vector3(40.171f, 5.7125f, 544.726f); });
                            CustomSubMenu.AddButton("Armory Disable Lock & Craft Everything", () =>
                            {
                                GhostGame.Armory_CraftGun.InvokeBehaviour();
                                GhostGame.Armory_CraftSniper.InvokeBehaviour();
                                GhostGame.ArmoryDoor_AddKeyOnDoor.RepeatInvokeBehaviour(5);
                            });

                            CustomSubMenu.AddButton("Click Money Reward 40 times", () =>
                            {
                                GhostGame.Armory_GetMoneyReward.RepeatInvokeBehaviour(40);
                            });

                            CustomSubMenu.AddSubMenu("Armory Manual Control", () =>
                            {

                                CustomSubMenu.AddButton("Disable Lock (Clicks it 5 times!)", () => { GhostGame.ArmoryDoor_AddKeyOnDoor.RepeatInvokeBehaviour(5); });
                                CustomSubMenu.AddButton("Start Armory Weapons crafting.", () =>
                                {
                                    GhostGame.Armory_CraftGun.InvokeBehaviour();
                                    GhostGame.Armory_CraftSniper.InvokeBehaviour();
                                });
                                CustomSubMenu.AddButton("Relock Armory Door", () => { GhostGame.ArmoryDoor_LockDoor.InvokeBehaviour(); });

                                CustomSubMenu.AddButton("Open Armory Door Clockwise", () => { GhostGame.ArmoryDoor_OpenDoor_Clockwise.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Open Armory Door CounterClockWise", () => { GhostGame.ArmoryDoor_OpenDoor_CounterClockwise.InvokeBehaviour(); });

                                CustomSubMenu.AddButton("Close Armory Door Clockwise", () => { GhostGame.ArmoryDoor_CloseDoor_Clockwise.InvokeBehaviour(); });
                                CustomSubMenu.AddButton("Close Armory Door CounterClockWise", () => { GhostGame.ArmoryDoor_CloseDoor_CounterClockwise.InvokeBehaviour(); });
                            });
                        });
                    });
                }

                #endregion

            }, ClientResources.Loaders.Icons.thief);

            ModConsole.Log("World Module is ready!", Color.Green);
        }
    }
}