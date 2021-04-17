namespace AstroServer.DiscordBot.Commands
{
    using Discord.Commands;
    using System.Linq;
    using System.Text;
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
            await ReplyAsync($"I can respond to you!");
        }

        [Command("List")]
        [Summary("List command")]
        public async Task List()
        {
            if (Server.Clients.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append($"Client Count: {Server.Clients.Count} \r\n");
                foreach (var client in Server.Clients)
                {
                    string prefix = "Client";

                    if (client.IsDeveloper)
                    {
                        prefix = "Developer";
                    }

                    stringBuilder.Append($"{client.ClientID}: [{prefix}] {client.Name}, {client.UserID} \r\n");
                }
                await ReplyAsync(stringBuilder.ToString());
            } else
            {
                await ReplyAsync("There are no clients currently connected");
            }
        }
    }
}
