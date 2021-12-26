namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    #region Imports

    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using CheetoLibrary.Utility;
    using ClientNetworking;
    using ClientResources;
    using ClientResources.Loaders;
    using Constants;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    internal class AdminMenu : AstroEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(int index)
        {
            if (!Bools.IsDeveloper) { return; }
            SubMenu = new QMTabMenu(index, "Admin Menu", null, null, null, Icons.badge_sprite);

            _ = new QMSingleButton(SubMenu, 1, 1, "Mass\nNotify", () => {
                CheetoUtils.PopupCall("Astro Avatar Search", "Search", "Enter Avatar name. . .", false, delegate (string text)
                {
                    MassNotify(text);
                });
            }, "Mass Notify");
        }

        private static void MassNotify(string message)
        {
            AstroNetworkClient.Client.Send(new PacketData(PacketClientType.MASS_NOTIFY, message));
        }
    }
}