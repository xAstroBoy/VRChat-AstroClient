namespace AstroClient.WorldAddons
{
    using AstroLibrary.Finder;
    using RubyButtonAPI;
    using System.Collections.Generic;
    using UnityEngine.UI;

    internal class VoidClub : GameEvents
    {
        public static QMNestedButton VoidClubMenu;

        public static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            VoidClubMenu = new QMNestedButton(main, x, y, "VoidClubMenu Exploits", "VoidClubMenu Exploits", null, null, null, null, btnHalf);

            _ = new QMSingleButton(VoidClubMenu, 1, 0, "Unlock\nHotel\n1", () => { UnlockHotel(); }, "Unlock Hotel 1");
            _ = new QMSingleButton(VoidClubMenu, 1, 1, "Unlock\nJapanese\n2", () => { UnlockJapanese(); }, "Unlock Japanese 2");
            _ = new QMSingleButton(VoidClubMenu, 1, 2, "Unlock\nForest\n3", () => { UnlockForest(); }, "Unlock Forest 3");
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
        }

        private static void UnlockHotel()
        {
            GameObjectFinder.Find("Room_Hotel/Door_system Hotel/Canvas (2)/Button (1)")?.GetComponent<Button>().Press();
        }

        private static void UnlockJapanese()
        {
            GameObjectFinder.Find("Japanese_rroom/Door_system Japanese/Canvas (2)/Button (1)")?.GetComponent<Button>().Press();
        }

        private static void UnlockForest()
        {
            GameObjectFinder.Find("Room_forest/Door_system Forest/Canvas (2)/Button (1)")?.GetComponent<Button>().Press();
        }
    }
}