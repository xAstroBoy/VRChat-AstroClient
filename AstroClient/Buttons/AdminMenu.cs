namespace AstroClient.Startup.Buttons
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Enums;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using DayClientML2.Utility;
    using AstroButtonAPI;
    using System.Reflection;
    using CheetoLibrary;

    #endregion Imports

    internal class AdminMenu : GameEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(float pos)
        {
            if (!Bools.IsDeveloper) { return; }
            SubMenu = new QMTabMenu(pos, "Admin Menu", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.badge.png"));

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