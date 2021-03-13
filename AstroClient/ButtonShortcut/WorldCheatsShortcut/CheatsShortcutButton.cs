using AstroClient.World.Hub;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using AstroClient.Worlds;

namespace AstroClient.ButtonShortcut
{
    public static class CheatsShortcutButton
    {

        private static QMSingleButton WorldCheatsShortcut;


        public static void Init_Cheats_ShortcutBtn(float x, float y, bool btnHalf)
        {
           WorldCheatsShortcut = new QMSingleButton("ShortcutMenu", x, y, "Cheats Shortcut", null, "Cheats Shortcut", null, null, btnHalf);
            
        }



        public static void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == "wrld_ba913a96-fac4-4048-a062-9aa5db092812")
            {
                SetButtonText("Hub Mods", "Control HUB World.");
                SetButtonShortcut(HubButtonsControl.VRChat_Hub_Addons);
                SetButtonColor(Color.green);
                ToggleButtonVisibilityAndInteractivity(true);
            }
            else if (WorldUtils.GetWorldID() == "wrld_dd036610-a246-4f52-bf01-9d7cea3405d7")
            {
                if (AmongUSCheats.AmongUsCheatsPage != null)
                {
                    SetButtonText("Among US Cheats", "Manage Among Us Cheats");
                    SetButtonShortcut(AmongUSCheats.AmongUsCheatsPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (WorldUtils.GetWorldID() == "wrld_858dfdfc-1b28-2e1e-8a23-f0edc611e5fe")
            {
                if (Murder2Cheats.Murder2CheatPage != null)
                {
                    SetButtonText("Murder 2 Cheats", "Manage Murder 2 Cheats");
                    SetButtonShortcut(Murder2Cheats.Murder2CheatPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (WorldUtils.GetWorldID() == "wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe")
            {
                if (Murder4Cheats.Murder4CheatPage != null)
                {
                    SetButtonText("Murder 4 Cheats", "Manage Murder 4 Cheats");
                    SetButtonShortcut(Murder4Cheats.Murder4CheatPage);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (WorldUtils.GetWorldID() == "wrld_c87d9e7a-d46a-4ca4-9077-a6322ac0f7e7")
            {
                if (WorldAddons.SandBagCheat != null)
                {
                    SetButtonText("Select Sandbag", "Select SandBag in Item Tweaker");
                    SetButtonShortcut(WorldAddons.SandBagCheat);
                    SetButtonColor(Color.green);
                    ToggleButtonVisibilityAndInteractivity(true);
                }
            }
            else if (WorldUtils.GetWorldID() == "wrld_4f826865-8501-4de2-b83a-f7eeb86b26a1")
            {
                if (WorldAddons.MovieRoomPatreonRoomUnlock != null)
                {
                    SetButtonText("Unlock Patreon Room", "Enables Patreon Room Door Without the password in the Room.");
                    SetButtonShortcut(WorldAddons.MovieRoomPatreonRoomUnlock);
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
            if(WorldCheatsShortcut != null)
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
