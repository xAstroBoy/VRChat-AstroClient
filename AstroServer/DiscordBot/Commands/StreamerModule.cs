namespace AstroServer.DiscordBot.Commands
{
    using Discord.Commands;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [Name("Streamer")]
    [RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
    [RequireTeam]
    public class StreamerModule : ModuleBase<SocketCommandContext>
    {
        [Command("StreamerName")]
        [Summary("StreamerName command")]
        public async Task StreamerName([Required] string name)
        {
            string streamerID = StreamerManager.GetStreamerID(name);
            if (streamerID != string.Empty)
            {
                await ReplyAsync($"Streamer {name} Found: {streamerID}");
            }
            else
            {
                await ReplyAsync($"No streamer found by that name.");
            }
        }
    }
}
