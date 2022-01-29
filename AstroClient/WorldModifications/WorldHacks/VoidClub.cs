namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class VoidClub : AstroEvents
    {
        internal static QMNestedGridMenu VoidClubMenu;

        internal static void InitButtons(QMGridTab main)
        {
            VoidClubMenu = new QMNestedGridMenu(main, "VoidClubMenu Exploits", "VoidClubMenu Exploits");

            _ = new QMSingleButton(VoidClubMenu, 1, 0, "Unlock\nHotel\n1", () => { UnlockHotel(); }, "Unlock Hotel 1");
            _ = new QMSingleButton(VoidClubMenu, 1, 1, "Unlock\nJapanese\n2", () => { UnlockJapanese(); }, "Unlock Japanese 2");
            _ = new QMSingleButton(VoidClubMenu, 1, 2, "Unlock\nForest\n3", () => { UnlockForest(); }, "Unlock Forest 3");
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.VoidClub))
            {
                if (VoidClubMenu != null)
                {
                    VoidClubMenu.SetInteractable(true);
                    VoidClubMenu.SetTextColor(Color.green);
                }
            }
            else
            {
                if (VoidClubMenu != null)
                {
                    VoidClubMenu.SetInteractable(false);
                    VoidClubMenu.SetTextColor(Color.red);
                }
            }
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