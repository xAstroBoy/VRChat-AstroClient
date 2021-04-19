﻿using AstroClient.ConsoleUtils;
using AstroClient.variables;
using AstroLibrary.Serializable;
using DayClientML2.Utility.Extensions;
using Newtonsoft.Json;

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

        public static void SendAvatarLog(AvatarData data)
        {
            string json = JsonConvert.SerializeObject(data);
            AstroNetworkClient.Client.Send($"avatar-log:{json}");
            ModConsole.DebugLog(json);
        }

        public static void SendClientInfo()
        {
            if (Initialized)
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.DebugLog($"Sending Client Information: {Name}, {UserID}");
                }
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
