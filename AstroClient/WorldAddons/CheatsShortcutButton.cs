namespace AstroClient.ButtonShortcut
{
    using AstroClient.Variables;
    using AstroClient.World.Hub;
    using AstroClient.WorldAddons;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    internal class CheatsShortcutButton : GameEvents
    {
        private static QMSingleButton WorldCheatsShortcut;

        internal static  void Init_Cheats_ShortcutBtn(float x, float y, bool btnHalf)
        {
            WorldCheatsShortcut = new QMSingleButton("ShortcutMenu", x, y, "Cheats Shortcut", null, "Cheats Shortcut", null, null, btnHalf);
            ToggleButtonVisibilityAndInteractivity(false);
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.VRChatDefaultHub)
            {
                SetButtonText("Hub Mods", "Control HUB World.");
                SetButtonShortcut(VRChatHub.VRChat_Hub_Addons);
                SetButtonColor(Color.green);
                ToggleButtonVisibilityAndInteractivity(true);
            }
            else if (id == WorldIds.AmongUS)
            {
                if (AmongUSCheats.AmongUsCheatsPage != null)
                {
                    SetButtonText("Among US Cheats", "Manage Among Us Cheats");
                    SetButtonShortcut(AmongUSCheats.AmongUsCheatsPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.Murder2)
            {
                if (Murder2Cheats.Murder2CheatPage != null)
                {
                    SetButtonText("Murder 2 Cheats", "Manage Murder 2 Cheats");
                    SetButtonShortcut(Murder2Cheats.Murder2CheatPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.Murder4)
            {
                if (Murder4Cheats.Murder4CheatPage != null)
                {
                    SetButtonText("Murder 4 Cheats", "Manage Murder 4 Cheats");
                    SetButtonShortcut(Murder4Cheats.Murder4CheatPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            //else if (id == WorldIds.FreezeTag)
            //{
            //    if (FreezeTag.FreezeTagCheatsPage != null)
            //    {
            //        SetButtonText("Freeze Tag Cheats", "Manage Freeze Tag Cheats");
            //        SetButtonShortcut(FreezeTag.FreezeTagCheatsPage);
            //        SetButtonColor(Color.green);
            //        ToggleButtonVisibilityAndInteractivity(true);
            //    }
            //}
            else if (id == WorldIds.BClub)
            {
                if (BClubWorld.BClubExploitsPage != null)
                {
                    SetButtonText("BClub Exploits", "Manage BClub Exploits");
                    SetButtonShortcut(BClubWorld.BClubExploitsPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.FBTHeaven)
            {
                if (FBTHeaven.FBTExploitsPage != null)
                {
                    SetButtonText("FBTHeaven Exploits", "Manage FBTHeaven Exploits");
                    SetButtonShortcut(FBTHeaven.FBTExploitsPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.JustHParty)
            {
                if (JustHParty.JustHPartyMenu != null)
                {
                    SetButtonText("JustHParty Exploits", "Manage JustHParty Exploits");
                    SetButtonShortcut(JustHParty.JustHPartyMenu);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.VoidClub)
            {
                if (VoidClub.VoidClubMenu != null)
                {
                    SetButtonText("VoidClub Exploits", "Manage VoidClub Exploits");
                    SetButtonShortcut(VoidClub.VoidClubMenu);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.AimFactory)
            {
                if (AimFactory.AimFactoryCheatPage != null)
                {
                    SetButtonText("Aim Factory Cheats", "Manage Aim Factory Cheats");
                    SetButtonShortcut(AimFactory.AimFactoryCheatPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.BOMBERio)
            {
                if (BOMBERio.BOMBERioCheatsPage != null)
                {
                    SetButtonText("BOMBERio Cheats", "Manage BOMBERio Cheats");
                    SetButtonShortcut(BOMBERio.BOMBERioCheatsPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (id == WorldIds.Super_Tower_defense)
            {
                if (SuperTowerDefense.SuperTowerDefensecheatPage != null)
                {
                    SetButtonText("Super Tower Defense Cheats", "Manage Super Tower Defense Cheats");
                    SetButtonShortcut(SuperTowerDefense.SuperTowerDefensecheatPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }

            else if (id == WorldIds.PoolParlor)
            {
                if (PoolParlor.PoolParlorCheats != null)
                {
                    SetButtonText("Pool Parlor Skins", "Manage Pool Parlor Customizations.");
                    SetButtonShortcut(PoolParlor.PoolParlorCheats);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }

            else
            {
                SetButtonColor(Color.red);
                ClearButtonAction();
                SetButtonText("This Button Should be hidden...");
                ToggleButtonVisibilityAndInteractivity(false);
            }
        }

        internal static  void SetButtonText(string ButtonText)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetButtonText(ButtonText + " Shortcut.");
                WorldCheatsShortcut.SetToolTip(ButtonText + " Shortcut.");
            }
        }

        internal static  void SetButtonText(string ButtonText, string ButtonToolTip)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetButtonText(ButtonText + " Shortcut.");
                WorldCheatsShortcut.SetToolTip(ButtonToolTip + " Shortcut.");
            }
        }

        internal static  void SetButtonColor(Color color)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetTextColor(color);
            }
        }

        internal static  void SetButtonShortcut(QMNestedButton btn)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetAction(new Action(() => { btn.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }

        internal static  void SetButtonShortcut(QMSingleButton btn)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetAction(new Action(() => { btn.GetGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }

        internal static  void ClearButtonAction()
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetAction(null);
            }
        }

        internal static  void ToggleButtonVisibilityAndInteractivity(bool isActive)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetActive(isActive);
                WorldCheatsShortcut.SetIntractable(isActive);
            }
        }
    }
}