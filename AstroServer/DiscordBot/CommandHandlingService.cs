namespace AstroServer.DiscordBot
{
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    public class CommandHandlingService
    {
        private readonly CommandService commands;
        private readonly DiscordSocketClient discord;
        private readonly IServiceProvider services;

        public CommandHandlingService(IServiceProvider _services)
        {
            commands = _services.GetRequiredService<CommandService>();
            discord = _services.GetRequiredService<DiscordSocketClient>();
            services = _services;

            // Hook CommandExecuted to handle post-command-execution logic.
            commands.CommandExecuted += CommandExecutedAsync;
            // Hook MessageReceived so we can process each message to see
            // if it qualifies as a command.
            discord.MessageReceived += MessageReceivedAsync;
        }

        public async Task InitializeAsync()
        {
            // Register modules that are public and inherit ModuleBase<T>.
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        public async Task MessageReceivedAsync(SocketMessage _rawMessage)
        {
            if (_rawMessage is not SocketUserMessage message) return;
            if (message.Source != MessageSource.User) return;

            SocketUser me = AstroBot.Client.CurrentUser;
            int argPos = 0;

            //if (message.HasMentionPrefix(me, ref argPos) || message.HasCharPrefix(guild.GetPrefix(), ref argPos))
            if (message.HasMentionPrefix(me, ref argPos))
            {
                SocketCommandContext context = new(discord, message);
                await commands.ExecuteAsync(context, argPos, services);
                Console.WriteLine($"Command: '{context.Message}' from '{context.User.Username}#{context.User.Discriminator}' in '{context.Guild.Name}'");
            }
        }

        public static async Task CommandExecutedAsync(Optional<CommandInfo> _command, ICommandContext _context, IResult _result)
        {
            // command is unspecified when there was a search failure (command not found); we don't care about these errors
            if (!_command.IsSpecified)
                return;

            // the command was successful, we don't care about this result, unless we want to log that a command succeeded.
            if (_result.IsSuccess)
                return;

            // the command failed, let's notify the user that something happened.
            await _context.Channel.SendMessageAsync($"{_result.ErrorReason}");
        }
    }
}
