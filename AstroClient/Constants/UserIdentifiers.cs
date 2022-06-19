using AstroClient.xAstroBoy.Utility;
using VRC.SDKBase;

namespace AstroClient.Constants
{
    using Config;

    internal class UserIdentifiers
    {
        
        internal static bool is_xAstroBoy
        {
            get => Networking.LocalPlayer.GetPlayer().GetAPIUser().id == "usr_a2fb27e8-921e-42f5-aa22-545c816b376e";
        }

        
    }
}