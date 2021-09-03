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

    public class CheatsShortcutButton : GameEvents
    {
        private static QMSingleButton WorldCheatsShortcut;

        public static void Init_Cheats_ShortcutBtn(float x, float y, bool btnHalf)
        {
            WorldCheatsShortcut = new QMSingleButton("ShortcutMenu", x, y, "Cheats Shortcut", null, "Cheats Shortcut", null, null, btnHalf);
            ToggleButtonVisibilityAndInteractivity(false);
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
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
            else
            {
                SetButtonColor(Color.red);
                ClearButtonAction();
                SetButtonText("This Button Should be hidden...");
                ToggleButtonVisibilityAndInteractivity(false);
            }
        }

        public static void SetButtonText(string ButtonText)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetButtonText(ButtonText + " Shortcut.");
                WorldCheatsShortcut.SetToolTip(ButtonText + " Shortcut.");
            }
        }

        public static void SetButtonText(string ButtonText, string ButtonToolTip)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetButtonText(ButtonText + " Shortcut.");
                WorldCheatsShortcut.SetToolTip(ButtonToolTip + " Shortcut.");
            }
        }

        public static void SetButtonColor(Color color)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetTextColor(color);
            }
        }

        public static void SetButtonShortcut(QMNestedButton btn)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetAction(new Action(() => { btn.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }

        public static void SetButtonShortcut(QMSingleButton btn)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetAction(new Action(() => { btn.GetGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }

        public static void ClearButtonAction()
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetAction(null);
            }
        }

        public static void ToggleButtonVisibilityAndInteractivity(bool isActive)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.SetActive(isActive);
                WorldCheatsShortcut.SetIntractable(isActive);
            }
        }
    }
}