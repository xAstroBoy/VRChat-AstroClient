using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace AstroServer.DiscordBot
{   
    public class AstroBot
    {
        public static DiscordSocketClient Client { get; set; }

        internal static string AuthToken = "ODMyNDAzODMxNjY0ODAzODcw.YHjSeg.32LVhPPwLw-AbJBkB_K9LG_NmHs";

        public AstroBot(DiscordSocketClient client)
        {
            Client = client;

            Client.Connected += OnConntected;
            //Client.MessageReceived += OnMessage;
        }

        public async Task Start()
        {
            await Client.LoginAsync(TokenType.Bot, AuthToken);
            await Client.StartAsync();
        }

        private Task OnConntected()
        {
            Client.SetActivityAsync(new CustomActivity()
            {
                Name = "the stars",
                Type = ActivityType.Watching,
            }).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }
    }
}
