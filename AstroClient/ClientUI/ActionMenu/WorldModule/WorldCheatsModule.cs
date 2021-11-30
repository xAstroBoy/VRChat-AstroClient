namespace AstroClient.ClientUI.ActionMenu
{
    using System.Collections.Generic;
    using System.Drawing;
    using Gompoc.ActionMenuAPI.Api;
    using Spawnables.Enderpearl;
    using Tools.Extensions;
    using Tools.Player.Movement.Exploit;
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
                        CustomSubMenu.AddButton("Fix Towers", () => { SuperTowerDefense.FixTheTowers(true);});
                        CustomSubMenu.AddSubMenu("Protections", () =>
                        {
                            CustomSubMenu.AddToggle("Block hammer Return Button", SuperTowerDefense.BlockHammerReturnButton, ToggleValue => { SuperTowerDefense.BlockHammerReturnButton = ToggleValue; });
                            CustomSubMenu.AddToggle("Block Wrenchs Return Buttons", SuperTowerDefense.BlockWrenchReturnButton, ToggleValue => { SuperTowerDefense.BlockWrenchReturnButton = ToggleValue; });
                           
                            CustomSubMenu.AddToggle("Freeze hammer", SuperTowerDefense.FreezeHammer, ToggleValue => { SuperTowerDefense.FreezeHammer = ToggleValue; });
                            CustomSubMenu.AddToggle("Freeze Towers", SuperTowerDefense.FreezeTowers, ToggleValue => { SuperTowerDefense.FreezeTowers = ToggleValue; });

                        });
                        CustomSubMenu.AddSubMenu("Tool Mods", () =>
                        {
                            CustomSubMenu.AddToggle("Repair Life Wrenches", SuperTowerDefense.RepairLifeWrenches, ToggleValue => { SuperTowerDefense.RepairLifeWrenches = ToggleValue; });
                            CustomSubMenu.AddToggle("Lose Life Hammer", SuperTowerDefense.LoseLifeHammer, ToggleValue => { SuperTowerDefense.LoseLifeHammer = ToggleValue; });

                        }, null, false, null);
                        CustomSubMenu.AddSubMenu("Cheats", () =>
                        {
                            CustomSubMenu.AddButton("Reset Life", () => { SuperTowerDefense.ResetHealth?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Remove a Life", () => { SuperTowerDefense.LoseHealth?.InvokeBehaviour(); });
                            CustomSubMenu.AddButton("Reset Bank Amount", () => { SuperTowerDefense.ResetBalance?.InvokeBehaviour(); });
                            CustomSubMenu.AddToggle("Automatic Wave", SuperTowerDefense.AutomaticWaveStart, ToggleValue => { SuperTowerDefense.AutomaticWaveStart = ToggleValue; });
                        }, null, false, null);

                    }, null, false, null);
                }
            #endregion

            #region AmongUS

            if (WorldUtils.WorldID == WorldIds.AmongUS)
            {
                CustomSubMenu.AddSubMenu("Among US", () =>
                {
                    CustomSubMenu.AddToggle("AmongUS Serializer", AmongUSCheats.AmongUsSerializer, ToggleValue => { AmongUSCheats.AmongUsSerializer = ToggleValue; });

                    CustomSubMenu.AddSubMenu("Game Events", () =>
                    {
                        CustomSubMenu.AddButton("Emergency Meeting", () => { AmongUSCheats.EmergencyMeetingEvent?.InvokeBehaviour(); });
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

            #endregion
            }, ClientResources.Loaders.Icons.thief);

            ModConsole.Log("World Module is ready!", Color.Green);
        }

    }
}