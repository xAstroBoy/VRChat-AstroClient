namespace AstroServer.DiscordBot
{
    using Discord;
    using Discord.WebSocket;
    using System;
    using System.Threading.Tasks;

    public class AstroBot
    {
        public static DiscordSocketClient Client { get; set; }

        internal static ulong LogChannelID = 834125750365192210;

        internal static ulong LoginChannelID = 832405505774190682;

        internal static ulong KeyshareChannelID = 834125559578624050;

        internal static ulong CommandChannelID = 832405559378051112;

        internal static ulong[] DeveloperIDs = new ulong[] { 717788323262890045, 257862389687386113, 587423650718679068 };

        public AstroBot(DiscordSocketClient client)
        {
            Client = client;

            Client.Connected += OnConntected;
            Client.Ready += OnReady;
            //Client.MessageReceived += OnMessage;
        }

        public async Task Start()
        {
            await Client.LoginAsync(TokenType.Bot, KeyManager.GetBotToken());
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

        public static async Task SendKeyshareLog(Client origin, Client other)
        {
            var channel = Client.GetChannel(KeyshareChannelID) as ISocketMessageChannel;
            await channel.SendMessageAsync(null, false, CustomEmbed.GetKeyshareEmbed(origin, other));
        }

        public static async Task SendLoggedInLog(Client client)
        {
            var channel = Client.GetChannel(LoginChannelID) as ISocketMessageChannel;
            await channel.SendMessageAsync(null, false, CustomEmbed.GetLoggedInEmbed(client));
        }

        public static async Task SendLogMessageAsync(string msg)
        {
            var channel = Client.GetChannel(LogChannelID) as ISocketMessageChannel;
            await channel.SendMessageAsync(msg);
        }
    }
}