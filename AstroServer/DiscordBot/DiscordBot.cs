using Discord.WebSocket;

namespace AstroServer
{   
    public class DiscordBot
    {
        public static DiscordSocketClient Client { get; set; }

        internal static string AuthToken = "ODMyNDAzODMxNjY0ODAzODcw.YHjSeg.32LVhPPwLw-AbJBkB_K9LG_NmHs";

        public DiscordBot(DiscordSocketClient client)
        {
            Client = client;
            //Client.MessageReceived += OnMessage;
            //Client.Connected += OnConntected;
        }
    }
}
