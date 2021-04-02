namespace AstroClient.Cheetos
{
    using AstroClient.ConsoleUtils;
    using AstroClient.variables;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using CheetosConsole;
    using AstroClient.Finder;
    using AstroClient.Variables;
    using UnityEngine;
    using DayClientML2.Utility.Extensions;
    using VRC;

    public class CheetosPrivateStuff : Overridables
    {
        public override void VRChat_OnUiManagerInit()
        {
#if CHEETOS
            CheetosConsole.Console.WriteFigletWithGradient(FigletFont.LoadFromAssembly("Larry3D.flf"), "Cheetos Mode", System.Drawing.Color.LightYellow, System.Drawing.Color.DarkOrange);

            string VRChatVersion = VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.prop_String_2;
            ModConsole.DebugLog($"VRChat Version: {VRChatVersion}");
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

        public QMScrollMenu MainScroller { get; private set; }

        public QMSingleButton RestartButton { get; private set; }

        public override void VRChat_OnUiManagerInit()
        {
            MainButton = new QMNestedButton("ShortcutMenu", 6, 0, "Cheeto's Menu", "Cheeto's secret WIP features", null, null, null, null, true);
            MainScroller = new QMScrollMenu(MainButton);
            RestartButton = new QMSingleButton(MainButton, 0, 0, "Close Game", () => { Environment.Exit(0); }, "Close the game");

            if (!Bools.isCheetosMode)
            {
                MainButton.getMainButton().setActive(false);
            }
        }

        public override void OnWorldReveal()
        {
        }
    }
}
