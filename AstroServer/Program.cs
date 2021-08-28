namespace AstroServer
{
    using AstroServer.DiscordBot;
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal class Program
    {
        public static ServiceProvider Services { get; private set; }

        internal static ClientServer CServer;

        internal static LoaderServer LServer;

        internal static bool Running;

        public static async Task Main()
        {
            Console.WriteLine("Welcome to AstroServer!");
            await Database.Initialize();
            //AvatarChecker.Initialize();
            Console.WriteLine("Starting Discord bot..");
            Services = new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<DiscordSocketConfig>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .BuildServiceProvider();
            DiscordSocketClient client = Services.GetRequiredService<DiscordSocketClient>();
            DiscordSocketConfig config = Services.GetRequiredService<DiscordSocketConfig>();

            config.GatewayIntents = ~GatewayIntents.None; // All intents
            config.AlwaysDownloadUsers = true;
            config.DefaultRetryMode = ~RetryMode.AlwaysFail; // Always retry

            await new AstroBot(client).Start();

            // Here we initialize the logic required to register our commands.
            await Services.GetRequiredService<CommandHandlingService>().InitializeAsync();

            // Key count
            Console.WriteLine($"There are {KeyManager.GetDevKeyCount()} dev keys stored.");
            Console.WriteLine($"There are {KeyManager.GetKeyCount()} valid keys stored.");

            Console.WriteLine("Starting Server..");
            LServer = new LoaderServer();
            CServer = new ClientServer();

            Running = true;
            while (Running)
            {
                Console.ReadLine();
            }
        }
    }
}