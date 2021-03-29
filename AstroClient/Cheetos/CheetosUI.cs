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

    public class CheetosPrivateStuff : Overridables
    {
        public override void VRChat_OnUiManagerInit()
        {
#if CHEETOS
            CheetosConsole.Console.WriteFigletWithGradient(FigletFont.LoadFromAssembly("Larry3D.flf"), "Cheetos Mode", System.Drawing.Color.LightYellow, System.Drawing.Color.DarkOrange);
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

        public override void VRChat_OnUiManagerInit()
        {
            MainButton = new QMNestedButton("ShortcutMenu", 6, 0, "Cheeto's Menu", "Cheeto's secret WIP features", null, null, null, null, true);
            MainScroller = new QMScrollMenu(MainButton);

            if (!Bools.isCheetosMode)
            {
                MainButton.getMainButton().setActive(false);
            }
        }

        // /Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview
        // /Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking
        // /Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock
        // /Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito
        // /Bedrooms/Bedroom 6/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND

        //nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance 6

        public override void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == WorldIds.BClub)
            {
                var testObject = GameObjectFinder.InactiveFind("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");

                if (testObject != null)
                {
                    ModConsole.DebugLog("Bedroom Preview Found");
                } else
                {
                    ModConsole.DebugLog("Bedroom Preview NOT Found");
                }
            }
        }
    }
}
