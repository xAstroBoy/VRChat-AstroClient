namespace AstroClient
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using System.Collections.Generic;
    using static AstroClient.Cheetos.AvatarSearch;

    #endregion Imports

    public class NetworkingManager : GameEvents
    {
        /// <summary>
        /// Gets whether the NetworkingManager has initialized and contains the player's information.
        /// </summary>
        public static bool Initialized { get; private set; }

        /// <summary>
        /// Returns true when everything is received from the server, IE (auth, account, exploit) data.
        /// </summary>
        public static bool IsReady
        {
            get
            {
                if (!initialized)
                {
                    initialized = true;
                    AstroNetworkClient.Initialize();
                }

                return isReady;
            }
            set => isReady = value;
        }

        private static bool isReady;
        private static bool initialized;

        public static string Name = string.Empty;

        public static string UserID = string.Empty;

        public static bool HasUdon;

        public static void AvatarSearch(SearchTypes searchType, string query)
        {
            if (Initialized)
            {
                if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
                {
                    ModConsole.Log($"Sending Avatar Search: {(int)searchType}, {query}");
                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_SEARCH_TYPE, ((int)searchType).ToString()));
                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_SEARCH, query));
                }
                else
                {
                    ModConsole.Error("Could not send Search Request.");
                }
            }
        }

        public static void SendClientInfo()
        {
            if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
            {
                Name = PlayerUtils.DisplayName();
                UserID = PlayerUtils.UserID();
                ModConsole.Log($"Sending Client Information: {UserID}, {Name}");
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_USERID, UserID));
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_NAME, Name));
            }
            else
            {
                ModConsole.Error("Could not send Client Information.");
            }
        }

        public static void SendInstanceInfo()
        {
            if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
            {
                var instanceID = WorldUtils.GetFullID();
                ModConsole.Log($"Sending Instance Information: {instanceID}");
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.WORLD_JOIN, instanceID));
            }
            else
            {
                ModConsole.Error("Could not send Instance Information.");
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            var self = PlayerUtils.GetVRCPlayer();
            Name = self.GetDisplayName();
            UserID = self.GetUserID();

            MiscUtils.DelayFunction(2f, () =>
            {
                Initialized = true;
                SendClientInfo();
                SendInstanceInfo();
            });
        }
    }
}