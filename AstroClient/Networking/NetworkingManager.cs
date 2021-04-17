using AstroClient.ConsoleUtils;
using DayClientML2.Utility.Extensions;

namespace AstroClient
{
    public class NetworkingManager : GameEvents
    {
        /// <summary>
        /// Gets whether the NetworkingManager has initialized and contains the player's information.
        /// </summary>
        public static bool Initialized { get; private set; }

        public static string Name = string.Empty;

        public static string UserID = string.Empty;

        public static void SendClientInfo()
        {
            if (Initialized)
            {
                ModConsole.DebugLog("Sending Client Information");
                AstroNetworkClient.Client.Send($"name:{Name}");
                AstroNetworkClient.Client.Send($"userid:{UserID}");
            }
        }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            var self = LocalPlayerUtils.GetSelfPlayer();
            Name = self.DisplayName();
            UserID = self.UserID();
            Initialized = true;
            SendClientInfo();
        }
    }
}
