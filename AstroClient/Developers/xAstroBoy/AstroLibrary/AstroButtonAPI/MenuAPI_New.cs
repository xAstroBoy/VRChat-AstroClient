namespace AstroButtonAPI
{
    using AstroClient;
    using AstroClient.xAstroBoy.AstroButtonAPI;

    internal static class MenuAPI_New
    {

        //internal static QmQuickActions QA_MainMenu { get; private set; } = new QmQuickActions(0, "MainMenu", BuildInfo.Name, "#FF69B4");

        internal static QmQuickActions QA_SelectedUser { get; private set; } = new QmQuickActions(1, "SelectedUser", BuildInfo.Name, "#FF69B4");
    }
}