namespace AstroServer.DiscordBot.Commands
{
    using Discord;
    using Discord.Commands;
    using System.Linq;
    using System.Threading.Tasks;

    [Name("Admin")]
    [RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
    [RequireUserPermission(GuildPermission.Administrator, ErrorMessage = "Command can only be ran by server admins.")]
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        [Command("Test")]
        [Summary("Test command")]
        public async Task Test()
        {
            var id = Context.Message.Author.Id;

            if (AstroBot.DeveloperIDs.Contains(id))
            {
                await ReplyAsync($"I can respond to you!");
            }
        }
    }
}
