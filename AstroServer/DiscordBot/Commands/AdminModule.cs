namespace AstroServer.DiscordBot.Commands
{
    using Discord.Commands;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Name("Admin")]
    [RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
    [RequireTeam]
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        [Command("GenKey")]
        [Summary("GenKey command")]
        public async Task GenKey([Required] ulong discordID)
        {
            var key = RandomOrg.GetRandomKey();

            if (key!=string.Empty)
            {
                if (!KeyManager.IsValidKey(key))
                {
                    await ReplyAsync(null, false, CustomEmbed.GetNewKeyEmbed(key, discordID, true));
                    KeyManager.AddKey(key, discordID);
                }
                else
                {
                    await ReplyAsync(null, false, CustomEmbed.GetNewKeyEmbed(key, discordID, false));
                }
            }
            else
            {
                await ReplyAsync("Failed to generate key, string.Empty was returned.");
            }
        }

        [Command("KeyCount")]
        [Summary("KeyCount command")]
        public async Task KeyCount()
        {
            await ReplyAsync(null, false, CustomEmbed.GetKeyCountEmbed());
        }

        [Command("ListKeys")]
        [Summary("ListKeys command")]
        public async Task ListKeys()
        {
            await ReplyAsync(null, false, CustomEmbed.GetKeyCountEmbed());

            foreach (var kvp in KeyManager.GetAllDevKeyInfo())
            {
                await base.ReplyAsync(null, false, CustomEmbed.GetKeyEmbed(kvp.Key));
            }

            foreach (var kvp in KeyManager.GetAllKeyInfo())
            {

                await base.ReplyAsync(null, false, CustomEmbed.GetKeyEmbed(kvp.Key));
            }
        }

        [Command("Notify")]
        [Summary("Notify command")]
        public async Task Notify([Required] string name, [Required] string msg)
        {
            var found = Server.Clients.Where(c => c.Name.Contains(name));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var client in found)
            {
                client.Send($"notify-dev:{msg}");
                stringBuilder.Append($"Notified: {client.Name}, {client.UserID} \r\n");
            }

            await ReplyAsync(stringBuilder.ToString());
        }

        [Command("SendAll")]
        [Summary("SendAll command")]
        public async Task SendAll([Required] string cmd)
        {
            var found = Server.Clients;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var client in found)
            {
                client.Send(cmd);
                stringBuilder.Append($"Command ran on: {client.Name}, {client.UserID} \r\n");
            }

            await ReplyAsync(stringBuilder.ToString());
        }

        [Command("Send")]
        [Summary("Send command")]
        public async Task Send([Required] string name, [Required] string cmd)
        {
            var found = Server.Clients.Where(c => c.Name.Contains(name));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var client in found)
            {
                client.Send(cmd);
                stringBuilder.Append($"Command ran on: {client.Name}, {client.UserID} \r\n");
            }
            await ReplyAsync(stringBuilder.ToString());
        }

        [Command("Kick")]
        [Summary("Kick command")]
        public async Task Kick([Required] string name)
        {
            var found = Server.Clients.Where(c => c.Name.Contains(name));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var client in found)
            {
                client.Send("exit:you have been kicked");
                stringBuilder.Append($"Kicked: {client.Name}, {client.UserID} \r\n");
            }

            await ReplyAsync(stringBuilder.ToString());
        }

        [Command("List")]
        [Summary("List command")]
        public async Task List()
        {
            if (Server.Clients.Count > 0)
            {
                //stringBuilder.Append($"Client Count: {Server.Clients.Count} \r\n");

                foreach (var client in Server.Clients)
                {
                    await ReplyAsync(null, false, CustomEmbed.GetClientEmbed(client));
                }
            } else
            {
                await ReplyAsync("There are no clients currently connected");
            }
        }
    }
}
