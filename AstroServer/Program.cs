using AstroServer.DiscordBot;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AstroServer
{
    class Program
    {
        public static ServiceProvider Services { get; private set; }

        internal static Server Server1;

        public static async Task Main()
        {
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

            await new AstroBot(client).Start();

            // Here we initialize the logic required to register our commands.
            await Services.GetRequiredService<CommandHandlingService>().InitializeAsync();

            Console.WriteLine("Starting Client Server..");
            Server1 = new Server();
        }
    }
}
