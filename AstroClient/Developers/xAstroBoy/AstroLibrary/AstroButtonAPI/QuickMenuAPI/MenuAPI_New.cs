namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient;

    internal static class MenuAPI_New
    {

        //internal static QmQuickActions QA_MainMenu { get; private set; } = new QmQuickActions(0, "MainMenu", BuildInfo.Name, "#FF69B4");

        internal static QmQuickActions QA_SelectedUser_Remote { get; private set; } = new QmQuickActions(1, "Menu_SelectedUser_Remote", BuildInfo.Name, "#FF69B4");

        internal static QmQuickActions QA_SelectedUser_Local { get; private set; } = new QmQuickActions(1, "Menu_SelectedUser_Local", BuildInfo.Name, "#FF69B4");

    }
}