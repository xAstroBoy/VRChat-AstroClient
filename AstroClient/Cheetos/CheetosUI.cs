using AstroClient.variables;
using RubyButtonAPI;
using System;

namespace AstroClient
{

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    public class CheetosUI : GameEvents
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

            if (!Bools.IsCheetosMode)
            {
                MainButton.getMainButton().setActive(false);
            } else
            {
                //QMTabMenu cheetosTab = new QMTabMenu(0, "Cheeto's Menu", null, null, null, null);
            }
        }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
        }
    }
}
