namespace AstroClient.ClientNetworking
{
    #region Imports

    using System.Collections;
    using System.Collections.Generic;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using MelonLoader;
    using xAstroBoy.Utility;
    using static Cheetos.AvatarSearch;

    #endregion Imports

    internal class NetworkingManager : AstroEvents
    {
        /// <summary>
        /// Gets whether the NetworkingManager has initialized and contains the player's information.
        /// </summary>
        internal static bool Initialized { get; private set; }

        /// <summary>
        /// Returns true when everything is received from the server, IE (auth, account, exploit) data.
        /// </summary>
        internal static bool IsReady
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

        internal static string Name = string.Empty;

        internal static string UserID = string.Empty;

        internal static bool HasUdon;

        internal static void AvatarSearch(SearchTypes searchType, string query)
        {
            if (Initialized)
            {
                if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
                {
                    ModConsole.DebugLog($"Sending Avatar Search: {(int)searchType}, {query}");
                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_SEARCH_TYPE, ((int)searchType).ToString()));
                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_SEARCH, query));
                }
                else
                {
                    ModConsole.Error("Could not send Search Request.");
                }
            }
        }

        internal static void SendClientInfo()
        {
            MelonCoroutines.Start(SendClientInfoLoop());
        }

        private static IEnumerator SendClientInfoLoop()
        {
            for (;;)
            {
                if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected && WorldUtils.IsInWorld && PlayerUtils.GetPlayer() != null)
                {
                    try
                    {
                        Name = PlayerUtils.DisplayName();
                        UserID = PlayerUtils.UserID();
                        ModConsole.DebugLog($"Sending Client Information: {UserID}, {Name}");
                        AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_USERID, UserID));
                        AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_NAME, Name));
                        yield break;
                    }
                    catch
                    {
                    }
                }

                yield return null;
            }
        }

        internal static void SendInstanceInfo()
        {
            if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
            {
                var instanceID = WorldUtils.Instance.id;
                ModConsole.DebugLog($"Sending Instance Information: {instanceID}");
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.WORLD_JOIN, instanceID));
            }
            else
            {
                ModConsole.Error("Could not send Instance Information.");
            }
        }

        internal override void OnRoomLeft()
        {
            initialized = false;
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            var self = PlayerUtils.GetVRCPlayer();
            Name = self.GetDisplayName();
            UserID = self.GetUserID();
            Initialized = true;
            SendInstanceInfo();
        }
    }
}