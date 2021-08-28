namespace AstroServer.DiscordBot
{
    #region Imports

    using AstroServer.Serializable;
    using Discord;
    using Discord.WebSocket;
    using MongoDB.Entities;
    using System;
    using System.Threading.Tasks;
    using System.Timers;

    #endregion

    public class AstroBot
    {
        #region ChannelIDs

        internal const ulong AvatarCountChannelID = 849865669393776660;

        internal const ulong LoginChannelID = 832405505774190682;

        internal const ulong LogChannelID = 834125750365192210;

        internal const ulong AvatarLogChannelID = 849867882711875584;

        internal const ulong LoginFailedChannelID = 848304027677753344;

        internal const ulong KeyshareChannelID = 834125559578624050;

        internal const ulong CommandChannelID = 832405559378051112;

        #endregion

        public static DiscordSocketClient Client { get; set; }

        internal static ulong[] DeveloperIDs = new ulong[] { 717788323262890045, 257862389687386113, 587423650718679068 };

        private static Timer statusTimer;

        public AstroBot(DiscordSocketClient client)
        {
            Client = client;

            Client.Connected += OnConntected;
            Client.Ready += OnReady;
        }

        private void OnStatusTimer(object sender, ElapsedEventArgs e)
        {
            SetStatus();
        }

        private void SetStatus()
        {
            var count = DB.Find<AvatarDataEntity>().ManyAsync(_ => true).GetAwaiter().GetResult().Count;
            (Client.GetChannel(AvatarCountChannelID) as IVoiceChannel).ModifyAsync(channel => channel.Name = $"Avatars: {count}").GetAwaiter().GetResult();
            Console.WriteLine($"Updated AvatarCountChannel to {count}");
        }

        public async Task Start()
        {
            await Client.LoginAsync(TokenType.Bot, KeyManager.GetBotToken());
            await Client.StartAsync();
        }

        private Task OnReady()
        {
            statusTimer = new Timer(600000);
            statusTimer.Elapsed += OnStatusTimer;
            statusTimer.AutoReset = true;
            statusTimer.Enabled = true;
            statusTimer.Start();

            Console.WriteLine("DiscordBot is ready.");
            SetStatus();
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

        #region LogSenders

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
        public static async Task SendLoggedInFailedLog(Client client, string reason)
        {
            var channel = Client.GetChannel(LoginFailedChannelID) as ISocketMessageChannel;
            await channel.SendMessageAsync(null, false, CustomEmbed.GetLoggedInFailedEmbed(client, reason));
        }

        public static async Task SendLogMessageAsync(string msg)
        {
            var channel = Client.GetChannel(LogChannelID) as ISocketMessageChannel;
            await channel.SendMessageAsync(msg);
        }

        public static async Task SendNewAvatarLogAsync(AvatarDataEntity ade)
        {
            //var channel = Client.GetChannel(AvatarLogChannelID) as ISocketMessageChannel;
            //await channel.SendMessageAsync(null, false, CustomEmbed.GetAvatarEmbed(ade));
        }

        #endregion
    }
}