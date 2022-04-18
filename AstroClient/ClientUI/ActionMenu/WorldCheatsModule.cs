using AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents;
using AstroClient.ClientResources.Loaders;
using AstroClient.ClientUI.Menu.ESP;
using AstroClient.Constants;
using AstroClient.Gompoc.ActionMenuAPI.Api;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Player.Movement.Exploit;
using AstroClient.WorldModifications.WorldHacks;
using AstroClient.WorldModifications.WorldHacks.Jar.AmongUS;
using AstroClient.WorldModifications.WorldHacks.Jar.KitchenCooks;
using AstroClient.WorldModifications.WorldHacks.Ostinyo;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Steamworks;
using UnityEngine;

namespace AstroClient.ClientUI.ActionMenu;

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

            #endregion

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

            #endregion

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

            
            #endregion

            #region PuttPuttPond

            if (WorldUtils.WorldID == WorldIds.PuttPuttPond)
            {
                CustomSubMenu.AddToggle("Patron Mode", PuttPuttPond.isPatron.GetValueOrDefault(false),
                    ToggleValue => { PuttPuttPond.isPatron = ToggleValue; });
                CustomSubMenu.AddToggle("Rainbow Golf ball", PuttPuttPond.RainbowBall,
                    ToggleValue => { PuttPuttPond.RainbowBall = ToggleValue; });
            }

            #endregion

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

            #endregion

            #region BeyondDarkness

            if (WorldUtils.WorldID == WorldIds.BeyondDarkness)
            {
                CustomSubMenu.AddToggle("Skip Bedroom Puzzle", BeyondDarkness.SkipBedroomPuzzle, ToggleValue => { BeyondDarkness.SkipBedroomPuzzle = ToggleValue; });
            }

            #endregion

            #region  Prison Escape

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
                    if (PrisonEscape.WorldSettings_Avatars_Toggle != null)
                    {
                        CustomSubMenu.AddToggle("Toggle Avatars", PrisonEscape.WorldSettings_Avatars.GetValueOrDefault(false), ToggleValue => { PrisonEscape.WorldSettings_Avatars = ToggleValue; });
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

                CustomSubMenu.AddSubMenu("Patreon System Control", () =>
                {
                    CustomSubMenu.AddToggle("Patron Mode", PrisonEscape.isPatron.GetValueOrDefault(false), ToggleValue => { PrisonEscape.isPatron = ToggleValue; });
                    CustomSubMenu.AddButton("Toggle Patron Guns", () => { PrisonEscape.TogglePatronGuns.InvokeBehaviour(); });
                    CustomSubMenu.AddButton("Toggle Double Points", () => { PrisonEscape.ToggleDoublePoints.InvokeBehaviour(); });
                    //CustomSubMenu.AddToggle("Everyone Has Gold Gun", PrisonEscape.EveryoneHasGoldenGuns, ToggleValue => { PrisonEscape.EveryoneHasGoldenGuns = ToggleValue; });
                    // CustomSubMenu.AddToggle("Everyone Has Double Points", PrisonEscape.EveryoneHasGoldenGunCamos, ToggleValue => { PrisonEscape.EveryoneHasGoldenGunCamos = ToggleValue; });

                });
                CustomSubMenu.AddSubMenu("Game Settings", () =>
                {
                
                    CustomSubMenu.AddToggle("Drop Knifes after kill", PrisonEscape.DropKnifeAfterKill, ToggleValue => { PrisonEscape.DropKnifeAfterKill = ToggleValue; });
                    CustomSubMenu.AddToggle("Allow guard Role to use vents", PrisonEscape.GuardsAreAllowedToUseVents, ToggleValue => { PrisonEscape.GuardsAreAllowedToUseVents = ToggleValue; });
                    CustomSubMenu.AddToggle("Game Start Master Lock", PrisonEscape.MasterLocked.GetValueOrDefault(false), ToggleValue => { PrisonEscape.MasterLocked = ToggleValue; });
                });

                CustomSubMenu.AddSubMenu("Game Hacks", () =>
                {
                    CustomSubMenu.AddToggle("Everyone Has Gold Guns", PrisonEscape.EveryoneHasGoldenGunCamos, ToggleValue => { PrisonEscape.EveryoneHasGoldenGunCamos = ToggleValue; });

                    CustomSubMenu.AddButton("Make Prisoners Wanted", () => { PrisonEscape.MarkPrisonersAsWanted(); });

                    var ESP = GameInstances.LocalPlayer.gameObject.GetOrAddComponent<PrisonEscape_ESP>();
                    if (ESP != null)
                    {
                        CustomSubMenu.AddToggle("GodMode", ESP.GodMode, ToggleValue => { ESP.GodMode = ToggleValue; });

                    }


                    CustomSubMenu.AddToggle("Take Keycard On Wanted", PrisonEscape.TakeKeyCardOnWanted, ToggleValue => { PrisonEscape.TakeKeyCardOnWanted = ToggleValue; });
                    CustomSubMenu.AddButton("Click Gate Button", () => { PrisonEscape.GateInteraction.InvokeBehaviour(); });
                    
                  


                    CustomSubMenu.AddToggle("Large Crate ESP", PrisonEscape.LargeCrateESP, ToggleValue => { PrisonEscape.LargeCrateESP = ToggleValue; });
                    CustomSubMenu.AddToggle("Toggle Pickup ESP", VRChat_Map_ESP_Menu.Toggle_Pickup_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_Pickup_ESP = ToggleValue; }, null, false);
                    CustomSubMenu.AddToggle("Toggle Ghost", MovementSerializer.SerializerActivated, ToggleValue => { MovementSerializer.SerializerActivated = ToggleValue; }, null, false);

                    var localreader = PrisonEscape.GetLocalReader();
                    if (localreader != null)
                    {
                        if (!localreader.hasKeycard.GetValueOrDefault(false))
                        {
                            CustomSubMenu.AddButton("Get KeyCard", () => { PrisonEscape.TakeKeyCard(); });
                        }
                    }

                });


            }
            #endregion

            #region  PuttPuttQuest & PuttPuttQuest Night

            if (WorldUtils.WorldID == WorldIds.PuttPuttQuest || WorldUtils.WorldID == WorldIds.PuttPuttQuest_Night)
            {
                CustomSubMenu.AddToggle("Patron Mode", PuttPuttQuest.isPatron.GetValueOrDefault(false), ToggleValue => { PuttPuttQuest.isPatron = ToggleValue; });
                CustomSubMenu.AddToggle("Rainbow Golf ball", PuttPuttQuest.RainbowBall, ToggleValue => { PuttPuttQuest.RainbowBall = ToggleValue; });
            }

            #endregion

            #region FBT Heaven
            if (WorldUtils.WorldID == WorldIds.FBTHeaven)
            {
                CustomSubMenu.AddButton("Lock Room 1", () => { FBTHeaven.LockDoor(1); });
                CustomSubMenu.AddButton("Unlock Room 1", () => { FBTHeaven.UnlockDoor(1); });

                CustomSubMenu.AddButton("Lock Room 2", () => { FBTHeaven.LockDoor(2); });
                CustomSubMenu.AddButton("Unlock Room 2", () => { FBTHeaven.UnlockDoor(2); });

                CustomSubMenu.AddButton("Lock Room 3", () => { FBTHeaven.LockDoor(3); });
                CustomSubMenu.AddButton("Unlock Room 3", () => { FBTHeaven.UnlockDoor(3); });

                CustomSubMenu.AddButton("Lock Room 4", () => { FBTHeaven.LockDoor(4); });
                CustomSubMenu.AddButton("Unlock Room 4", () => { FBTHeaven.UnlockDoor(4); });


            }



            #endregion

            #region Just B Club
            if (WorldUtils.WorldID == WorldIds.JustBClub)
            {
                CustomSubMenu.AddToggle("Rainbow Lights", BClubWorld.IsRainbowEnabled, ToggleValue => { BClubWorld.IsRainbowEnabled = ToggleValue; });
                CustomSubMenu.AddToggle("Doorbell Spam", BClubWorld.IsDoorbellSpamEnabled, ToggleValue => { BClubWorld.IsDoorbellSpamEnabled = ToggleValue; });
                if (Bools.IsDeveloper)
                {
                    CustomSubMenu.AddToggle("BlueChair Everyone", BClubWorld.IsBlueChairEnabled, ToggleValue => { BClubWorld.IsBlueChairEnabled = ToggleValue; });
                }
                CustomSubMenu.AddToggle("NPC Moan Spam", BClubWorld.IsMoanSpamEnabled, ToggleValue => { BClubWorld.IsMoanSpamEnabled = ToggleValue; });
                CustomSubMenu.AddToggle("NPC Fall Spam", BClubWorld.IsFallSpamEnabled, ToggleValue => { BClubWorld.IsFallSpamEnabled = ToggleValue; });

                CustomSubMenu.AddToggle("Freeze Locked Door", BClubWorld.IsFreezeLockEnabed, ToggleValue => { BClubWorld.IsFreezeLockEnabed = ToggleValue; });
                CustomSubMenu.AddToggle("Freeze Unlocked Door", BClubWorld.IsFreezeUnlockEnabed, ToggleValue => { BClubWorld.IsFreezeUnlockEnabed = ToggleValue; });

                if(BClubWorld.EjectNonVips != null)
                {
                    CustomSubMenu.AddButton("Eject Non VIPs (VIP Room)", () => { BClubWorld.EjectNonVips.InvokeBehaviour(); });

                }
            }



            #endregion

            #region  Kmart Express

            if (WorldUtils.WorldID == WorldIds.KMartExpress_1)
            {
                CustomSubMenu.AddButton("Bypass Kmart Lock for Everyone", () => { Kmart.BypassKmartRestrictions(); });
                CustomSubMenu.AddButton("Restore Kmart Lock for Everyone", () => { Kmart.RestoreKmartRestrictions(); });

                CustomSubMenu.AddToggle("Remove Lock for Every new player join", Kmart.RemoveBlocksForJoinedPlayers, ToggleValue =>
                {
                    if(ToggleValue)
                    {
                        Kmart.BypassKmartRestrictions();
                    }
                    Kmart.RemoveBlocksForJoinedPlayers = ToggleValue;
                });

            }



            #endregion
        }, Icons.thief);

        Log.Write("World Module is ready!", Color.Green);
    }
}