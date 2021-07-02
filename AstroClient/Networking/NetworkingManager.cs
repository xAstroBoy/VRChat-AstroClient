﻿namespace AstroClient
{
	#region Imports

	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
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
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_USERID, Utils.LocalPlayer.GetPlayer().UserID()));
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_NAME, Utils.LocalPlayer.GetPlayer().DisplayName()));
            }
        }

        public static void SendInstanceInfo()
        {
            if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
            {
                var instanceID = Blaze.Utils.WorldUtils.GetFullID();
                AstroNetworkClient.Client.Send(new PacketData(PacketClientType.WORLD_JOIN, instanceID));
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            var self = Utils.LocalPlayer.GetPlayer();
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