using AstroClient.xAstroBoy.Utility;

namespace AstroClient.Constants
{
    using ClientUI.Menu;
    using ClientUI.Menu.Wings;
    using Config;

    internal class UserIdentifiers
    {
        
        internal static bool is_xAstroBoy
        {
            get => GameInstances.CurrentUser.GetAPIUser().id == "usr_a2fb27e8-921e-42f5-aa22-545c816b376e";
        }

        
    }
}