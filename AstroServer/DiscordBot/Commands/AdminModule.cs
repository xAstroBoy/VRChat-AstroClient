namespace AstroServer.DiscordBot.Commands
{
    using Discord.Commands;
    using System.Linq;
    using System.Threading.Tasks;

    [Name("Admin")]
    [RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
    [RequireTeam]
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
