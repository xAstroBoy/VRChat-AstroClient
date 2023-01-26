using AstroClient.xAstroBoy.Utility;
using VRC.SDKBase;

namespace AstroClient.Constants
{
    using Config;

    internal class UserIdentifiers
    {

        private static string xAstroBoyID { get;  } = "usr_9370dc54-1fdd-435e-90f4-8e9666593f9a";
        private static bool DoOnce_xAstroBoyCheck { get; set; } = false;
        private static bool _is_xAstroBoy { get; set; } = false;

        internal static bool is_xAstroBoy
        {
            get
            {
                if(!DoOnce_xAstroBoyCheck)
                {
                    _is_xAstroBoy = true;
                    DoOnce_xAstroBoyCheck = true;
                }
                return _is_xAstroBoy;
            }

        }

        
    }
}