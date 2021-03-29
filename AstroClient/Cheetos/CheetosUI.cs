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

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    public class CheetosUI : Overridables
    {

        public QMNestedButton MainButton { get; private set; }

        public QMScrollMenu MainScroller { get; private set; }

        public override void VRChat_OnUiManagerInit()
        {
            MainButton = new QMNestedButton("ShortcutMenu", 5, 4, "Cheeto's Menu", "Cheeto's WIP features", null, null, null, null, true);
            MainScroller = new QMScrollMenu(MainButton);

            if (!Bools.isCheetosMode)
            {
                MainButton.getMainButton().setActive(false);
            }
        }

        private void OnButtonClicked()
        {
            ModConsole.DebugLog("Button Clicked");
        }
    }
}
