using AstroClient.ClientActions;

namespace AstroClient.WorldModifications
{
    using System;
    using System.Collections.Generic;
    using ClientResources;
    using ClientResources.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldHacks;
    using WorldHacks.Jar.AmongUS;
    using WorldHacks.Jar.Murder2;
    using WorldHacks.Jar.Murder4;
    using WorldsIds;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class CheatsShortcutButton : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private static QMWings WorldCheatsShortcut;

        internal static void Init_Cheats_ShortcutBtn()
        {
            WorldCheatsShortcut = new QMWings(1020, true, "World Cheats", "This Opens Compatible World cheats", Icons.thief_sprite);
            ToggleButtonVisibilityAndInteractivity(false);
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.AmongUS)
            {
                if (AmongUSCheats.AmongUsCheatsPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(AmongUSCheats.AmongUsCheatsPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.Murder2)
            {
                if (Murder2Cheats.Murder2CheatPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(Murder2Cheats.Murder2CheatPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.Murder4)
            {
                if (Murder4Cheats.Murder4CheatPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(Murder4Cheats.Murder4CheatPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.JustBClub)
            {
                if (JustBClub1.BClubExploitsPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(JustBClub1.BClubExploitsPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.FBTHeaven)
            {
                if (FBTHeaven.FBTExploitsPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(FBTHeaven.FBTExploitsPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.JustHParty)
            {
                if (JustHParty.JustHPartyMenu != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(JustHParty.JustHPartyMenu);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.VoidClub)
            {
                if (VoidClub.VoidClubMenu != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(VoidClub.VoidClubMenu);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.AimFactory)
            {
                if (AimFactory.AimFactoryCheatPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(AimFactory.AimFactoryCheatPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.BOMBERio)
            {
                if (BOMBERio.BOMBERioCheatsPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(BOMBERio.BOMBERioCheatsPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.Super_Tower_defense)
            {
                if (SuperTowerDefense.SuperTowerDefensecheatPage != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(SuperTowerDefense.SuperTowerDefensecheatPage);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.Clicker_Game)
            {
                if (ClickerGame.ClickerGameCheats != null)
                {
                    WorldCheatsShortcut.SetButtonShortcut(ClickerGame.ClickerGameCheats);
                    WorldCheatsShortcut.SetTextColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }

            else
            {
                WorldCheatsShortcut.SetTextColor(Color.red);
                ClearButtonAction();
                ToggleButtonVisibilityAndInteractivity(false);
            }
        }




        internal static void ClearButtonAction()
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetAction(null);
            }
        }

        internal static void ToggleButtonVisibilityAndInteractivity(bool isActive)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetActive(isActive);
                WorldCheatsShortcut.SetInteractable(isActive);
            }
        }
    }
}