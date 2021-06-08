namespace AstroClient
{
	#region Imports

	using AstroClient.variables;
	using AstroLibrary.Console;
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using AstroLibrary.Utility;
	using AstroLibrary.Extensions;
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
        public static bool IsReady;

        public static string Name = string.Empty;

        public static string UserID = string.Empty;

        public static bool HasUdon;

        public static void AvatarSearch(SearchTypes searchType, string query)
        {
            if (Initialized)
            {
                if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.Log($"Sending Avatar Search: {(int)searchType}, {query}");
                    }
                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_SEARCH_TYPE, ((int)searchType).ToString()));
                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_SEARCH, query));
                }
            }
        }

        public static void SendClientInfo()
        {
            if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.DebugLog($"Sending Client Information: {Name}, {UserID}");
                }
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_USERID, LocalPlayerUtils.GetSelfPlayer().UserID()));
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_NAME, LocalPlayerUtils.GetSelfPlayer().DisplayName()));
            }
        }

        public static void SendInstanceInfo()
        {
            if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
            {
                var instanceID = RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.idWithTags;
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.WORLD_JOIN, instanceID));
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            var self = LocalPlayerUtils.GetSelfPlayer();
            Name = self.DisplayName();
            UserID = self.UserID();

            MiscUtility.DelayFunction(2f, () =>
            {
                Initialized = true;
                SendClientInfo();
                SendInstanceInfo();
            });
        }
    }
}