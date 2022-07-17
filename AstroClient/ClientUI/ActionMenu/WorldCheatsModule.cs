using AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents;
using AstroClient.ClientActions;
using AstroClient.ClientResources.Loaders;
using AstroClient.ClientUI.QuickMenuGUI.ESP;
using AstroClient.Constants;
using AstroClient.Gompoc.ActionMenuAPI.Api;
using AstroClient.Tools.Bruteforcer;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Player.Movement.Exploit;
using AstroClient.WorldModifications.WorldHacks;
using AstroClient.WorldModifications.WorldHacks.BlueKun;
using AstroClient.WorldModifications.WorldHacks.Jar.AmongUS;
using AstroClient.WorldModifications.WorldHacks.Jar.KitchenCooks;
using AstroClient.WorldModifications.WorldHacks.Kmarts;
using AstroClient.WorldModifications.WorldHacks.NoLife1942;
using AstroClient.WorldModifications.WorldHacks.Ostinyo;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.ClientUI.ActionMenu;

using Color = System.Drawing.Color;

internal class WorldCheatsModule : AstroEvents
{
    internal override void RegisterToEvents()
    {
        ClientEventActions.OnApplicationStart += OnApplicationStart;
    }

    private void OnApplicationStart()
    {
        AMUtils.AddToModsFolder("World Modules", () =>
        {
            #region Super Tower Defense

            if (WorldUtils.WorldID == WorldIds.Super_Tower_defense)
            {
                CustomSubMenu.AddSubMenu("Fixes", () =>
                    {
                        CustomSubMenu.AddButton("Fix Towers And Respawn", () => { SuperTowerDefense.FixTheTowers(true); });
                        CustomSubMenu.AddButton("Fix Towers No Respawn", () => { SuperTowerDefense.FixTheTowers(false); });
                    });

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
                    });
                });
                CustomSubMenu.AddSubMenu("Tool Mods", () =>
                {
                    CustomSubMenu.AddToggle("Repair Life Wrenches", SuperTowerDefense.RepairLifeWrenches, ToggleValue => { SuperTowerDefense.RepairLifeWrenches = ToggleValue; });
                    CustomSubMenu.AddToggle("Lose Life Hammer", SuperTowerDefense.LoseLifeHammer, ToggleValue => { SuperTowerDefense.LoseLifeHammer = ToggleValue; });
                });
                CustomSubMenu.AddSubMenu("Cheats", () =>
                {
                    CustomSubMenu.AddButton("Reset Heart", () => { SuperTowerDefense.ResetHealth?.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Remove a Heart", () => { SuperTowerDefense.LoseHealth?.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Reset Bank Amount", () => { SuperTowerDefense.ResetBalance?.InvokeBehaviour(); });
                    CustomSubMenu.AddToggle("Automatic Wave", SuperTowerDefense.AutomaticWaveStart, ToggleValue => { SuperTowerDefense.AutomaticWaveStart = ToggleValue; });
                    CustomSubMenu.AddToggle("Automatic God Mode", SuperTowerDefense.GodMode.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.GodMode = ToggleValue; });
                    CustomSubMenu.AddToggle("Freeze Money Balance", SuperTowerDefense.FreezeMoney.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.FreezeMoney = ToggleValue; });
                    CustomSubMenu.AddToggle("Free Towers Upgrade", SuperTowerDefense.MakeUpgradesFree, ToggleValue => { SuperTowerDefense.ActivateFreeUpgrades(ToggleValue); });

                    //CustomSubMenu.AddToggle("Bypass Tower Collider", SuperTowerDefense.IgnoreTowersCollidersPlacement, ToggleValue => { SuperTowerDefense.IgnoreTowersCollidersPlacement = ToggleValue; });
                });
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
                    });

                    CustomSubMenu.AddSubMenu("Tower Speed", () =>
                    {
                        CustomSubMenu.AddButton("+0.5f Speed", () => { SuperTowerDefense.AddTowerSpeed(0.5f); });
                        CustomSubMenu.AddButton("+1f Speed", () => { SuperTowerDefense.AddTowerSpeed(1f); });
                        CustomSubMenu.AddButton("-0.5f Speed", () => { SuperTowerDefense.RemoveTowerSpeed(0.5f); });
                        CustomSubMenu.AddButton("-1f Speed", () => { SuperTowerDefense.RemoveTowerSpeed(1f); });
                        CustomSubMenu.AddButton("9999 Speed", () => { SuperTowerDefense.SetTowerSpeed(9999f); });
                        CustomSubMenu.AddButton("Reset Speed", () => { SuperTowerDefense.RestoreTowerSpeed(); });
                    });
                });
                CustomSubMenu.AddSubMenu("Auto Starter Control", () =>
                {
                    CustomSubMenu.AddButton("Place AutoStarter", () => { SuperTowerDefense.AutoStarter_Place?.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Activate AutoStarter", () => { SuperTowerDefense.AutoStarter_SetActive?.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Deactivate AutoStarter", () => { SuperTowerDefense.AutoStarter_SetInactive?.InvokeBehaviour(); });
                    CustomSubMenu.AddToggle("Keep AutoStart ON", SuperTowerDefense.KeepAutoStarterActive.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.KeepAutoStarterActive = ToggleValue; });
                    CustomSubMenu.AddToggle("Keep AutoStart OFF", SuperTowerDefense.KeepAutoStarterInactive.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.KeepAutoStarterInactive = ToggleValue; });
                });
                CustomSubMenu.AddSubMenu("Bank Mods", () =>
                {
                    CustomSubMenu.AddButton("Reset Bank Amount", () => { SuperTowerDefense.ResetBalance?.InvokeBehaviour(); });
                    CustomSubMenu.AddToggle("Freeze Money Balance", SuperTowerDefense.FreezeMoney.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.FreezeMoney = ToggleValue; });
                    CustomSubMenu.AddToggle("Anti-negative Balance", SuperTowerDefense.FixBalanceNegative.GetValueOrDefault(false), ToggleValue => { SuperTowerDefense.FixBalanceNegative = ToggleValue; });

                    CustomSubMenu.AddButton("Set 0 Money", () =>
                    {
                        if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) SuperTowerDefense.BankEditor.Money = 0;
                    });
                    CustomSubMenu.AddButton("Add 10000 Money", () =>
                    {
                        if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 10000;
                    });
                    CustomSubMenu.AddButton("Add 100000 Money", () =>
                    {
                        if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 100000;
                    });
                    CustomSubMenu.AddButton("Add 1000000 Money", () =>
                    {
                        if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 1000000;
                    });
                    CustomSubMenu.AddButton("Add 10000000 Money", () =>
                    {
                        if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) SuperTowerDefense.BankEditor.Money = SuperTowerDefense.BankEditor.Money.Value + 10000000;
                    });
                    CustomSubMenu.AddButton("Set 999999999 Money", () =>
                    {
                        if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) SuperTowerDefense.BankEditor.Money = 999999999;
                    });
                    CustomSubMenu.AddButton($"Set {int.MaxValue} Money", () =>
                    {
                        if (SuperTowerDefense.BankEditor != null && SuperTowerDefense.BankEditor.Money.HasValue) SuperTowerDefense.BankEditor.Money = int.MaxValue;
                    });
                });
                CustomSubMenu.AddSubMenu("Health Mods", () =>
                {
                    CustomSubMenu.AddButton("Reset Heart", () => { SuperTowerDefense.ResetHealth?.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Heart +1", () =>
                    {
                        if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue)
                        {
                            SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value + 1;
                            SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value + 1;
                        }
                    });
                    CustomSubMenu.AddButton("Heart +10", () =>
                    {
                        if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue)
                        {
                            SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value + 10;
                            SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value + 10;
                        }
                    });
                    CustomSubMenu.AddButton("Heart +100", () =>
                    {
                        if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue)
                        {
                            SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value + 100;
                            SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value + 100;
                        }
                    });
                    CustomSubMenu.AddButton("Heart -1", () =>
                    {
                        if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue)
                        {
                            SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value - 1;
                            SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value - 1;
                        }
                    });
                    CustomSubMenu.AddButton("Heart -10", () =>
                    {
                        if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue)
                        {
                            SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value - 10;
                            SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value - 10;
                        }
                    });
                    CustomSubMenu.AddButton("Heart -100", () =>
                    {
                        if (SuperTowerDefense.HealthEditor != null && SuperTowerDefense.HealthEditor.CurrentHealth.HasValue)
                        {
                            SuperTowerDefense.HealthEditor.CurrentHealth = SuperTowerDefense.HealthEditor.CurrentHealth.Value - 100;
                            SuperTowerDefense.HealthEditor.TimesBoughtLives = SuperTowerDefense.HealthEditor.TimesBoughtLives.Value - 100;
                        }
                    });
                });
            }

            #endregion Super Tower Defense

            #region AmongUS

            if (WorldUtils.WorldID == WorldIds.AmongUS)
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
                        CustomSubMenu.AddButton("Cafeteria", () => { AmongUSCheats.EmptyGarbage_Cafeteria_B?.InvokeBehaviour(); });
                        CustomSubMenu.AddButton("Oxygen", () => { AmongUSCheats.EmptyGarbage_Oxygen_A?.InvokeBehaviour(); });
                        CustomSubMenu.AddButton("Storage A", () => { AmongUSCheats.EmptyGarbage_Storage_A?.InvokeBehaviour(); });
                        CustomSubMenu.AddButton("Storage B", () => { AmongUSCheats.EmptyGarbage_Storage_B?.InvokeBehaviour(); });
                    });
                });
            }

            #endregion AmongUS

            #region ClickerGame

            if (WorldUtils.WorldID == WorldIds.Clicker_Game)
            {
                CustomSubMenu.AddToggle("AutoClicker", ClickerGame.CubeAutoClicker,
                    ToggleValue => { ClickerGame.CubeAutoClicker = ToggleValue; });
            }

            #endregion ClickerGame
            
            #region Pool Parlor

            if (WorldUtils.WorldID == WorldIds.PoolParlor)
            {
                CustomSubMenu.AddSubMenu("Pool Table Settings", () =>
                {
                    CustomSubMenu.AddToggle("Longer Guideline", PoolParlor.LongerGuideline, ToggleValue => { PoolParlor.LongerGuideline = ToggleValue; });
                    CustomSubMenu.AddToggle("Force Guideline", PoolParlor.BilliardsModule.ForceGuidelineOn, ToggleValue => { PoolParlor.BilliardsModule.ForceGuidelineOn = ToggleValue; });
                    CustomSubMenu.AddToggle("Force Locking Cue", PoolParlor.BilliardsModule.ForceLockingOn, ToggleValue => { PoolParlor.BilliardsModule.ForceLockingOn = ToggleValue; });
                    CustomSubMenu.AddToggle("Can Hit Cue Ball", PoolParlor.BilliardsModule.canHitCueBall.GetValueOrDefault(false), ToggleValue => { PoolParlor.BilliardsModule.canHitCueBall = ToggleValue; });
                    CustomSubMenu.AddToggle("Practice mode", PoolParlor.BilliardsModule.isPracticeMode.GetValueOrDefault(false), ToggleValue => { PoolParlor.BilliardsModule.isPracticeMode = ToggleValue; });
                    if (UserIdentifiers.is_xAstroBoy)
                    {
                        CustomSubMenu.AddButton("Set Holystar Camo", () => { PoolParlor.CurrentTableSkin = PoolParlor.TableSkins.Holystar;});
                    }

                });

                CustomSubMenu.AddSubMenu("Match Settings", () =>
                {
                    CustomSubMenu.AddButton("Create Match", () => { PoolParlor.StartNewMatchCreation.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Abort Match Creation", () => { PoolParlor.CloseNewMatchCreation.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Start Match", () => { PoolParlor.StartMatch.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Reset Match", () => { PoolParlor.ResetMatch.InvokeBehaviour(); });


                });
                CustomSubMenu.AddSubMenu("Popcat Bruteforcer", () =>
                {
                    CustomSubMenu.AddToggle("Bruteforce Popcat", TextBruteforcer.StartBruteforcer, ToggleValue => { TextBruteforcer.StartBruteforcer = ToggleValue; });

                });

            }

            #endregion Pool Parlor

            #region BOMBERio

            if (WorldUtils.WorldID == WorldIds.BOMBERio)
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
            }

            #endregion BOMBERio

            #region Kitchen Cooks

            if (WorldUtils.WorldID == WorldIds.KitchenCooks)
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
                });
            }

            #endregion Kitchen Cooks

            #region PuttPuttPond

            if (WorldUtils.WorldID == WorldIds.PuttPuttPond)
            {
                CustomSubMenu.AddToggle("Patron Mode", PuttPuttPond.isPatron.GetValueOrDefault(false),
                    ToggleValue => { PuttPuttPond.isPatron = ToggleValue; });
                CustomSubMenu.AddToggle("Rainbow Golf ball", PuttPuttPond.RainbowBall,
                    ToggleValue => { PuttPuttPond.RainbowBall = ToggleValue; });
            }

            #endregion PuttPuttPond

            #region Ghost Game

            if (WorldUtils.WorldID == WorldIds.GhostGame)
            {
                CustomSubMenu.AddSubMenu("Mirror Control", () =>
                {
                    CustomSubMenu.AddButton("Toggle Lobby Mirrors (Fuck the Mirror zombies !)",
                        () => { GhostGame.ToggleMirrors_1.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Toggle Mailbox Mirrors (Fuck the Mirror zombies !)",
                        () => { GhostGame.ToggleMirrors_2.InvokeBehaviour(); });
                    CustomSubMenu.AddToggle("Turn Off Mirrors Troll (Spams Mirror Off event to piss Mirror zombies!)",
                        GhostGame.FuckOffMirrorZombies, value => { GhostGame.FuckOffMirrorZombies = value; });
                });

                CustomSubMenu.AddSubMenu("Cheats", () =>
                {
                    CustomSubMenu.AddButton("Teleport To Armory Zone",
                        () =>
                        {
                            GameInstances.LocalPlayer.gameObject.transform.position =
                                new Vector3(40.171f, 5.7125f, 544.726f);
                        });
                    CustomSubMenu.AddButton("Armory Disable Lock & Unlock Everything", () =>
                    {
                        GhostGame.Armory_CraftGun.InvokeBehaviour();
                        GhostGame.Armory_CraftSniper.InvokeBehaviour();
                        GhostGame.Armory_CraftClue.InvokeBehaviour();
                        GhostGame.Armory_OpenCabinet_1.InvokeBehaviour();
                        GhostGame.Armory_OpenCabinet_2.InvokeBehaviour();
                        GhostGame.ArmoryDoor_AddKeyOnDoor.RepeatInvokeBehaviour(5);
                        GhostGame.Armory_GetMoneyReward.RepeatInvokeBehaviour(15);
                    });

                    CustomSubMenu.AddButton("Click Money Reward 40 times",
                        () => { GhostGame.Armory_GetMoneyReward.RepeatInvokeBehaviour(40); });

                    CustomSubMenu.AddSubMenu("Armory Manual Control", () =>
                    {
                        CustomSubMenu.AddButton("Disable Lock (Clicks it 5 times!)",
                            () => { GhostGame.ArmoryDoor_AddKeyOnDoor.RepeatInvokeBehaviour(5); });
                        CustomSubMenu.AddButton("Start Armory Weapons crafting.", () =>
                        {
                            GhostGame.Armory_CraftGun.InvokeBehaviour();
                            GhostGame.Armory_CraftSniper.InvokeBehaviour();
                        });
                        CustomSubMenu.AddButton("Relock Armory Door",
                            () => { GhostGame.ArmoryDoor_LockDoor.InvokeBehaviour(); });

                        CustomSubMenu.AddButton("Open Armory Door Clockwise",
                            () => { GhostGame.ArmoryDoor_OpenDoor_Clockwise.InvokeBehaviour(); });
                        CustomSubMenu.AddButton("Open Armory Door CounterClockWise",
                            () => { GhostGame.ArmoryDoor_OpenDoor_CounterClockwise.InvokeBehaviour(); });

                        CustomSubMenu.AddButton("Close Armory Door Clockwise",
                            () => { GhostGame.ArmoryDoor_CloseDoor_Clockwise.InvokeBehaviour(); });
                        CustomSubMenu.AddButton("Close Armory Door CounterClockWise",
                            () => { GhostGame.ArmoryDoor_CloseDoor_CounterClockwise.InvokeBehaviour(); });
                    });
                });
            }

            #endregion Ghost Game

            #region Infested

            if (WorldUtils.WorldID == WorldIds.Infested)
            {
                CustomSubMenu.AddToggle("Unlimited Ammo",
                    Infested.UnlimitedAmmo, value => { Infested.UnlimitedAmmo = value; });
                CustomSubMenu.AddToggle("Unlimited Money",
                    Infested.UnlimitedMoney, value => { Infested.UnlimitedMoney = value; });
            }


            #endregion
            #region BeyondDarkness

            if (WorldUtils.WorldID == WorldIds.BeyondDarkness)
            {
                CustomSubMenu.AddToggle("Skip Bedroom Puzzle", BeyondDarkness.SkipBedroomPuzzle, ToggleValue => { BeyondDarkness.SkipBedroomPuzzle = ToggleValue; });
            }

            #endregion BeyondDarkness

            #region Prison Escape

            if (WorldUtils.WorldID == WorldIds.PrisonEscape)
            {
                CustomSubMenu.AddSubMenu("Money Hacks", () =>
                {
                    CustomSubMenu.AddButton("Get Money", () => { PrisonEscape.MoneyInteraction.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Get Money x10", () => { PrisonEscape.MoneyInteraction.RepeatInvokeBehaviour(10); });
                    CustomSubMenu.AddButton("Get Money x20", () => { PrisonEscape.MoneyInteraction.RepeatInvokeBehaviour(20); });
                    CustomSubMenu.AddButton("Get Money x30", () => { PrisonEscape.MoneyInteraction.RepeatInvokeBehaviour(30); });
                    CustomSubMenu.AddButton("Get Money x40", () => { PrisonEscape.MoneyInteraction.RepeatInvokeBehaviour(40); });
                    CustomSubMenu.AddButton("Get Money x50", () => { PrisonEscape.MoneyInteraction.RepeatInvokeBehaviour(50); });
                    CustomSubMenu.AddButton("Get Money x100", () => { PrisonEscape.MoneyInteraction.RepeatInvokeBehaviour(100); });
                });
                CustomSubMenu.AddSubMenu("World Settings", () =>
                {
                    if (PrisonEscape.WorldSettings_Subtitles_Toggle != null)
                    {
                        CustomSubMenu.AddToggle("Toggle Subtitles", PrisonEscape.WorldSettings_Subtitles.GetValueOrDefault(false), ToggleValue => { PrisonEscape.WorldSettings_Subtitles = ToggleValue; });
                    }
                    if (PrisonEscape.WorldSettings_Music_Toggle != null)
                    {
                        CustomSubMenu.AddToggle("Toggle Music", PrisonEscape.WorldSettings_Music.GetValueOrDefault(false), ToggleValue => { PrisonEscape.WorldSettings_Music = ToggleValue; });
                    }
                    if (PrisonEscape.WorldSettings_VisualHitBoxes_Toggle != null)
                    {
                        CustomSubMenu.AddToggle("Toggle Visual Hitbox", PrisonEscape.WorldSettings_VisualHitBoxes.GetValueOrDefault(false), ToggleValue => { PrisonEscape.WorldSettings_VisualHitBoxes = ToggleValue; });
                    }
                    if (PrisonEscape.WorldSettings_GoldenGuns_Toggle != null)
                    {
                        CustomSubMenu.AddToggle("Toggle Golden Guns", PrisonEscape.WorldSettings_GoldenGuns.GetValueOrDefault(false), ToggleValue => { PrisonEscape.WorldSettings_GoldenGuns = ToggleValue; });
                    }
                    if (PrisonEscape.WorldSettings_DoublePoints_Toggle != null)
                    {
                        CustomSubMenu.AddToggle("Toggle Double Points", PrisonEscape.WorldSettings_DoublePoints.GetValueOrDefault(false), ToggleValue => { PrisonEscape.WorldSettings_DoublePoints = ToggleValue; });
                    }
                });
                CustomSubMenu.AddSubMenu("Gun Colors", () =>
                {
                    if (PrisonEscape.Gun_Gold_Color_Button != null)
                    {
                        CustomSubMenu.AddButton("Set Gold Color", () => { PrisonEscape.Gun_Gold_Color_Button.onClick.Invoke(); });
                    }
                    if (PrisonEscape.Gun_Green_Color_Button != null)
                    {
                        CustomSubMenu.AddButton("Set Green Color", () => { PrisonEscape.Gun_Green_Color_Button.onClick.Invoke(); });
                    }
                    if (PrisonEscape.Gun_Blue_Color_Button != null)
                    {
                        CustomSubMenu.AddButton("Set Blue Color", () => { PrisonEscape.Gun_Blue_Color_Button.onClick.Invoke(); });
                    }
                    if (PrisonEscape.Gun_Purple_Color_Button != null)
                    {
                        CustomSubMenu.AddButton("Set Purple Color", () => { PrisonEscape.Gun_Purple_Color_Button.onClick.Invoke(); });
                    }
                    if (PrisonEscape.Gun_Red_Color_Button != null)
                    {
                        CustomSubMenu.AddButton("Set Red Color", () => { PrisonEscape.Gun_Red_Color_Button.onClick.Invoke(); });
                    }
                });

                CustomSubMenu.AddSubMenu("Patreon System Control", () =>
                {
                    CustomSubMenu.AddToggle("Patron Mode", PrisonEscape.isPatron.GetValueOrDefault(false), ToggleValue => { PrisonEscape.isPatron = ToggleValue; });
                    CustomSubMenu.AddButton("Toggle Patron Guns", () => { PrisonEscape.TogglePatronGuns.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Toggle Double Points", () => { PrisonEscape.ToggleDoublePoints.InvokeBehaviour(); });
                });
                CustomSubMenu.AddSubMenu("Game Settings", () =>
                {
                    CustomSubMenu.AddToggle("Drop Knifes after kill", PrisonEscape.DropKnifeAfterKill, ToggleValue => { PrisonEscape.DropKnifeAfterKill = ToggleValue; });
                    CustomSubMenu.AddToggle("Allow guard Role to use vents", PrisonEscape.GuardsAreAllowedToUseVents, ToggleValue => { PrisonEscape.GuardsAreAllowedToUseVents = ToggleValue; });
                    CustomSubMenu.AddToggle("Free Crates Items", PrisonEscape.FreeCratesItems, ToggleValue => { PrisonEscape.FreeCratesItems = ToggleValue; });
                });
                CustomSubMenu.AddSubMenu("Game Cheats", () =>
                {
                    CustomSubMenu.AddToggle("Show Role, Health & Wanted ", PrisonEscape.ShowRoles, ToggleValue => { PrisonEscape.ShowRoles = ToggleValue; });

                    CustomSubMenu.AddToggle("Everyone Has Gold Guns", PrisonEscape.EveryoneHasGoldenGunCamos, ToggleValue => { PrisonEscape.EveryoneHasGoldenGunCamos = ToggleValue; });

                    var ESP = GameInstances.LocalPlayer.gameObject.GetOrAddComponent<PrisonEscape_ESP>();
                    if (ESP != null)
                    {
                        CustomSubMenu.AddToggle("GodMode", ESP.GodMode, ToggleValue => { ESP.GodMode = ToggleValue; });
                    }

                    CustomSubMenu.AddToggle("Take Keycard On Suspicious", PrisonEscape.TakeKeyCardOnSuspicious, ToggleValue => { PrisonEscape.TakeKeyCardOnSuspicious = ToggleValue; });
                    CustomSubMenu.AddToggle("Take Keycard On Wanted", PrisonEscape.TakeKeyCardOnWanted, ToggleValue => { PrisonEscape.TakeKeyCardOnWanted = ToggleValue; });

                    CustomSubMenu.AddToggle("Large Crate ESP", PrisonEscape.LargeCrateESP, ToggleValue => { PrisonEscape.LargeCrateESP = ToggleValue; });
                    CustomSubMenu.AddToggle("Small Crate ESP", PrisonEscape.SmallCrateESP, ToggleValue => { PrisonEscape.SmallCrateESP = ToggleValue; });

                    CustomSubMenu.AddToggle("Toggle Pickup ESP", VRChat_Map_ESP_Menu.Toggle_Pickup_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_Pickup_ESP = ToggleValue; });
                    CustomSubMenu.AddToggle("Toggle Ghost", MovementSerializer.SerializerActivated, ToggleValue => { MovementSerializer.SerializerActivated = ToggleValue; },  null);
                    CustomSubMenu.AddToggle("Doors Stay open", PrisonEscape.DoorsStayOpen, ToggleValue => { PrisonEscape.DoorsStayOpen = ToggleValue; });

                });
                CustomSubMenu.AddSubMenu("Game Events", () =>
                {
                    var reader = PrisonEscape.GetLocalReader();
                    if(reader != null)
                    {
                        CustomSubMenu.AddToggle("Is Guard", reader.isGuard.GetValueOrDefault(false), ToggleValue =>
                        {
                            reader.isGuard = ToggleValue;
                        },  null);
                        CustomSubMenu.AddToggle("Is Dead", reader.isDead.GetValueOrDefault(false), ToggleValue =>
                        {
                            reader.isDead = ToggleValue;

                        },  null);

                    }
                    CustomSubMenu.AddButton("Click Gate Button as Prisoner", () =>
                    {
                        if (reader != null)
                        {
                            if (reader.isGuard.GetValueOrDefault(false))
                            {
                                reader.isGuard = false;
                                if(!reader.hasKeycard.GetValueOrDefault(false))
                                {
                                    reader.hasKeycard = true;
                                }
                                PrisonEscape.GateInteraction.InvokeBehaviour();
                                reader.isGuard = true;
                            }
                            else
                            {
                                if (!reader.hasKeycard.GetValueOrDefault(false))
                                {
                                    reader.hasKeycard = true;
                                }
                                PrisonEscape.GateInteraction.InvokeBehaviour();
                            }
                        }
                        else
                        {
                            PrisonEscape.GateInteraction.InvokeBehaviour();
                        }
                    });
                    CustomSubMenu.AddButton("Click Gate Button as Guard", () =>
                    {

                        if (reader != null)
                        {
                            if (!reader.isGuard.GetValueOrDefault(false))
                            {
                                reader.isGuard = true;
                                PrisonEscape.GateInteraction.InvokeBehaviour();
                                reader.isGuard = false;
                            }
                            else
                            {
                                PrisonEscape.GateInteraction.InvokeBehaviour();
                            }

                        }
                        else
                        {
                            PrisonEscape.GateInteraction.InvokeBehaviour();
                        }
                    });
                    CustomSubMenu.AddButton("Make Prisoners Wanted", () => { PrisonEscape.MarkPrisonersAsWanted(); });
                    CustomSubMenu.AddButton("Get KeyCard", () => { PrisonEscape.TakeKeyCard(); });
                    CustomSubMenu.AddButton("Open All Small Crates", () => { PrisonEscape.OpenAllSmallCrates(); });
                    CustomSubMenu.AddButton("Open All Large Crates", () => { PrisonEscape.OpenAllLargeCrates(); });

                });

                if (UserIdentifiers.is_xAstroBoy)
                {
                    CustomSubMenu.AddButton("xAstroBoy Preset", () =>
                    {
                        var ESP = GameInstances.LocalPlayer.gameObject.GetOrAddComponent<PrisonEscape_ESP>();
                        if (ESP != null)
                        {
                            ESP.GodMode = true;
                        }
                        PrisonEscape.TakeKeyCardOnSuspicious = true;
                        PrisonEscape.TakeKeyCardOnWanted = true;
                        VRChat_Map_ESP_Menu.Toggle_Pickup_ESP = true;
                        PrisonEscape.ShowRoles = true;
                        PrisonEscape.LargeCrateESP = true;
                        PrisonEscape.SmallCrateESP = true;
                        PrisonEscape.FreeCratesItems = true;
                        PrisonEscape.DropKnifeAfterKill = false;
                        PrisonEscape.GuardsAreAllowedToUseVents = true;
                        PrisonEscape.WorldSettings_VisualHitBoxes = true;
                        PrisonEscape.WorldSettings_GoldenGuns = false;
                        PrisonEscape.WorldSettings_DoublePoints = true;
                        PrisonEscape.WorldSettings_Music = false;
                        PrisonEscape.WorldSettings_Subtitles = true;
                    });
                }
            }

            #endregion Prison Escape

            #region PuttPuttQuest & PuttPuttQuest Night

            if (WorldUtils.WorldID == WorldIds.PuttPuttQuest || WorldUtils.WorldID == WorldIds.PuttPuttQuest_Night)
            {
                CustomSubMenu.AddToggle("Patron Mode", PuttPuttQuest.isPatron.GetValueOrDefault(false), ToggleValue => { PuttPuttQuest.isPatron = ToggleValue; });
                CustomSubMenu.AddToggle("Rainbow Golf ball", PuttPuttQuest.RainbowBall, ToggleValue => { PuttPuttQuest.RainbowBall = ToggleValue; });
            }

            #endregion PuttPuttQuest & PuttPuttQuest Night

            #region FBT Heaven

            if (WorldUtils.WorldID == WorldIds.FBTHeaven)
            {
                CustomSubMenu.AddButton("Toggle Room 1", () => { FBTHeaven.ToggleDoor(1); });
                CustomSubMenu.AddButton("Toggle Room 2", () => { FBTHeaven.ToggleDoor(2); });
                CustomSubMenu.AddButton("Toggle Room 3", () => { FBTHeaven.ToggleDoor(3); });
                CustomSubMenu.AddButton("Toggle Room 4", () => { FBTHeaven.ToggleDoor(4); });
            }

            #endregion FBT Heaven

            #region Just B Club

            if (WorldUtils.WorldID == WorldIds.JustBClub)
            {
                CustomSubMenu.AddToggle("Rainbow Lights", JustBClub1.IsRainbowEnabled, ToggleValue => { JustBClub1.IsRainbowEnabled = ToggleValue; });
                CustomSubMenu.AddToggle("Doorbell Spam", JustBClub1.IsDoorbellSpamEnabled, ToggleValue => { JustBClub1.IsDoorbellSpamEnabled = ToggleValue; });
                if (Bools.IsDeveloper)
                {
                    CustomSubMenu.AddToggle("BlueChair Everyone", JustBClub1.IsBlueChairEnabled, ToggleValue => { JustBClub1.IsBlueChairEnabled = ToggleValue; });
                }
                CustomSubMenu.AddToggle("NPC Moan Spam", JustBClub1.IsMoanSpamEnabled, ToggleValue => { JustBClub1.IsMoanSpamEnabled = ToggleValue; });
                CustomSubMenu.AddToggle("NPC Fall Spam", JustBClub1.IsFallSpamEnabled, ToggleValue => { JustBClub1.IsFallSpamEnabled = ToggleValue; });

                CustomSubMenu.AddToggle("Freeze Locked Door", JustBClub1.IsFreezeLockEnabed, ToggleValue => { JustBClub1.IsFreezeLockEnabed = ToggleValue; });
                CustomSubMenu.AddToggle("Freeze Unlocked Door", JustBClub1.IsFreezeUnlockEnabed, ToggleValue => { JustBClub1.IsFreezeUnlockEnabed = ToggleValue; });

                if (JustBClub1.EjectNonVips != null)
                {
                    CustomSubMenu.AddButton("Eject Non VIPs (VIP Room)", () => { JustBClub1.EjectNonVips.InvokeBehaviour(); });
                }
            }

            #endregion Just B Club

            #region Kmart Express

            if (WorldUtils.WorldID == WorldIds.KMartExpress_1)
            {
                CustomSubMenu.AddButton("Bypass Kmart Lock for Everyone", () => { KmartExpress_1.BypassKmartRestrictions(); });
                CustomSubMenu.AddButton("Restore Kmart Lock for Everyone", () => { KmartExpress_1.RestoreKmartRestrictions(); });

                CustomSubMenu.AddToggle("Remove Lock for Every new player join", KmartExpress_1.EmployeeModeForJoinedPlayers, ToggleValue =>
                {
                    if (ToggleValue)
                    {
                        KmartExpress_1.BypassKmartRestrictions();
                    }
                    KmartExpress_1.EmployeeModeForJoinedPlayers = ToggleValue;
                });
            }

            #endregion Kmart Express
            
            #region VRChat Kmart

            if (WorldUtils.WorldID == WorldIds.VRCHAT_Kmart)
            {
                CustomSubMenu.AddButton("Bypass Kmart Lock for Everyone", () => { VRChat_Kmart.BypassKmartRestrictions(); });
                CustomSubMenu.AddButton("Restore Kmart Lock for Everyone", () => { VRChat_Kmart.RestoreKmartRestrictions(); });

                CustomSubMenu.AddToggle("Remove Lock for Every new player join", VRChat_Kmart.RemoveBlocksForJoinedPlayers, ToggleValue =>
                {
                    if (ToggleValue)
                    {
                        KmartExpress_1.BypassKmartRestrictions();
                    }
                    KmartExpress_1.EmployeeModeForJoinedPlayers = ToggleValue;
                });
            }

            #endregion Kmart Express

            #region VRWare

            if (WorldUtils.WorldID == WorldIds.VRWare || WorldUtils.WorldID == WorldIds.VRWare_Test_CrossPlatform)
            {
                CustomSubMenu.AddButton("Toggle Console", () => { VRWare.ToggleConsole.InvokeBehaviour(); });
                CustomSubMenu.AddButton("Toggle Music", () => { VRWare.ToggleMusic.InvokeBehaviour(); });

                CustomSubMenu.AddButton("Force Devouring Minigame", () => { VRWare.Trigger_Devouring_Level?.InvokeBehaviour(); });
                CustomSubMenu.AddButton("Force Break The Target Minigame", () => { VRWare.Trigger_BreakTheTargets_Level?.InvokeBehaviour(); });
                CustomSubMenu.AddButton("Force Japan World Minigame", () => { VRWare.Trigger_JapanWorld_Level?.InvokeBehaviour(); });
                CustomSubMenu.AddButton("Force Race Minigame", () => { VRWare.Trigger_Race_Level?.InvokeBehaviour(); });
                CustomSubMenu.AddButton("Force Exit VRChat Minigame", () => { VRWare.Trigger_ExitVRChat_Level?.InvokeBehaviour(); });


            }

            #endregion VRWare
        }, Icons.thief);

        Log.Write("World Module is ready!", Color.Green);
    }
}