using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace AstroServer.DiscordBot
{   
    public class AstroBot
    {
        public static DiscordSocketClient Client { get; set; }

        internal static string AuthToken = "ODMyNDAzODMxNjY0ODAzODcw.YHjSeg.32LVhPPwLw-AbJBkB_K9LG_NmHs";

        internal static ulong LogChannelID = 832405505774190682;

        internal static ulong CommandChannelID = 832405559378051112;

        internal static ulong[] DeveloperIDs = new ulong[] { 717788323262890045, 257862389687386113 };

        public AstroBot(DiscordSocketClient client)
        {
            Client = client;

            Client.Connected += OnConntected;
            Client.Ready += OnReady;
            //Client.MessageReceived += OnMessage;
        }

        public async Task Start()
        {
            await Client.LoginAsync(TokenType.Bot, AuthToken);
            await Client.StartAsync();
        }

        private Task OnReady()
        {
            Console.WriteLine("DiscordBot is ready.");
            return Task.CompletedTask;
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
