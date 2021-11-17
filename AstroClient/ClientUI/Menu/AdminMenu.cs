namespace AstroClient.ClientUI.QuickMenuButtons
{
    #region Imports

    using System.Reflection;
    using AstroButtonAPI;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using CheetoLibrary;
    using Variables;

    #endregion Imports

    internal class AdminMenu : GameEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(int index)
        {
            if (!Bools.IsDeveloper) { return; }
            SubMenu = new QMTabMenu(index, "Admin Menu", null, null, null, ClientResources.badge_sprite);

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