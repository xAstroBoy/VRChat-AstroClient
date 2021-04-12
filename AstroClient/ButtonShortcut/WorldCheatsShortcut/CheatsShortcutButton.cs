using AstroClient.Variables;
using AstroClient.World.Hub;
using RubyButtonAPI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AstroClient.ButtonShortcut
{
    public class CheatsShortcutButton : GameEvents
    {
        private static QMSingleButton WorldCheatsShortcut;

        public static void Init_Cheats_ShortcutBtn(float x, float y, bool btnHalf)
        {
            WorldCheatsShortcut = new QMSingleButton("ShortcutMenu", x, y, "Cheats Shortcut", null, "Cheats Shortcut", null, null, btnHalf);
        }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.VRChatDefaultHub)
            {
                SetButtonText("Hub Mods", "Control HUB World.");
                SetButtonShortcut(HubButtonsControl.VRChat_Hub_Addons);
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
            else if (id == WorldIds.FreezeTag)
            {
                if (FreezeTag.FreezeTagCheatsPage != null)
                {
                    SetButtonText("Freeze Tag Cheats", "Manage Freeze Tag Cheats");
                    SetButtonShortcut(FreezeTag.FreezeTagCheatsPage);
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
                WorldCheatsShortcut.setButtonText(ButtonText + " Shortcut.");
                WorldCheatsShortcut.setToolTip(ButtonText + " Shortcut.");
            }
        }

        public static void SetButtonText(string ButtonText, string ButtonToolTip)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setButtonText(ButtonText + " Shortcut.");
                WorldCheatsShortcut.setToolTip(ButtonToolTip + " Shortcut.");
            }
        }

        public static void SetButtonColor(Color color)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setTextColor(color);
            }
        }

        public static void SetButtonShortcut(QMNestedButton btn)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setAction(new Action(() => { btn.getMainButton().getGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }

        public static void SetButtonShortcut(QMSingleButton btn)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setAction(new Action(() => { btn.getGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }

        public static void ClearButtonAction()
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setAction(null);
            }
        }

        public static void ToggleButtonVisibilityAndInteractivity(bool isActive)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setActive(isActive);
                WorldCheatsShortcut.setIntractable(isActive);
            }
        }
    }
}