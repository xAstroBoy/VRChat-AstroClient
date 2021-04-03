namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using AstroClient.variables;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CheetosConsole;
    using AstroClient.Finder;
    using AstroClient.Variables;
    using UnityEngine;
    using DayClientML2.Utility.Extensions;
    using VRC;
    using AstroClient.extensions;

    public class CheetosPrivateStuff : Overridables
    {
        public override void VRChat_OnUiManagerInit()
        {
#if CHEETOS
            CheetosConsole.Console.WriteFigletWithGradient(FigletFont.LoadFromAssembly("Larry3D.flf"), "Cheetos Mode", System.Drawing.Color.LightYellow, System.Drawing.Color.DarkOrange);

            string VRChatVersion = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_1;
            string VRChatBuild = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_0;
            ModConsole.CheetoLog($"VRChat Version: {VRChatVersion}, {VRChatBuild}");

            // Find and remove shitty UI shit
            var crap1 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/ReportWorldButton");
            var crap2 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconButton");
            var crap3 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner");
            var crap4 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner");
            var crap5 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconCameraButton");
            var crap6 = GameObjectFinder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou");

            if (crap1 != null)
            {
                crap1.DestroyMeLocal();
            }

            if (crap2 != null)
            {
                crap2.DestroyMeLocal();
            }

            if (crap3 != null)
            {
                crap3.DestroyMeLocal();
            }

            if (crap4 != null)
            {
                crap4.DestroyMeLocal();
            }

            if (crap5 != null)
            {
                crap5.DestroyMeLocal();
            }

            if (crap6 != null)
            {
                crap6.DestroyMeLocal();
            }
#endif
        }

        public override void OnWorldReveal()
        {
#if CHEETOS
            var uiManager = VRCUiManager.prop_VRCUiManager_0;
            PopupManager.QueHudMessage(uiManager, "Cheetos Mode!");
#endif
        }
    }

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    public class CheetosUI : Overridables
    {
        public QMNestedButton MainButton { get; private set; }

        public QMNestedButton SettingsButton { get; private set; }

        public QMScrollMenu MainScroller { get; private set; }

        public QMSingleButton RestartButton { get; private set; }

        public QMToggleButton PlayerListToggle { get; private set; }

        public override void VRChat_OnUiManagerInit()
        {
            MainButton = new QMNestedButton("ShortcutMenu", 5, 3, "Cheeto's Menu", "Cheeto's secret WIP features", null, null, null, null, true);
            MainScroller = new QMScrollMenu(MainButton);
            RestartButton = new QMSingleButton(MainButton, 0, 0, "Close Game", () => { Environment.Exit(0); }, "Close the game");

            if (!Bools.isCheetosMode)
            {
                MainButton.getMainButton().setActive(false);
            } else
            {
                QMTabMenu cheetosTab = new QMTabMenu(0, "Cheeto's Menu", null, null, null, @"https://craig.se/AstroClient/tab_button.png");
            }
        }

        public override void OnWorldReveal()
        {

            string userid = LocalPlayerUtils.GetSelfPlayer().UserID();
            ModConsole.DebugLog($"UserID: {userid}");
            try
            {
                PlayerMenuUI.playerButtons.TryGetValue(userid, out QMSingleButton button);

                if (button != null)
                {
                    ModConsole.DebugLog($"My spoofed name is: {button.getButtonText()}");
                    ModConsole.DebugLog($"My spoofed name is: {button.getButtonText()}");
                    ModConsole.DebugLog($"My spoofed name is: {button.getButtonText()}");
                    ModConsole.DebugLog($"My spoofed name is: {button.getButtonText()}");
                    ModConsole.DebugLog($"My spoofed name is: {button.getButtonText()}");
                    ModConsole.DebugLog($"My spoofed name is: {button.getButtonText()}");
                } else
                {
                    ModConsole.DebugError($"BUTTON WAS NULL");
                }
            } catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
        }
    }
}
