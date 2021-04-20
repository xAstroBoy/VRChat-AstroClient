namespace AstroServer.DiscordBot.Commands
{
    using Discord.Commands;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    [Name("Admin")]
    [RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
    [RequireTeam]
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        [Command("ListKeys")]
        [Summary("ListKeys command")]
        public async Task ListKeys()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"There are {KeyManager.GetDevKeyCount()} developer keys \r\n");
            stringBuilder.Append($"There are {KeyManager.GetKeyCount()} client keys \r\n");
            await ReplyAsync(stringBuilder.ToString());

            foreach (var kvp in KeyManager.GetAllDevKeyInfo())
            {
                StringBuilder stringBuilder1 = new StringBuilder();
                var discorduser = AstroBot.Client.GetUser(kvp.Value);
                stringBuilder1.Append($"[Developer] {discorduser.Mention} \r\n {kvp.Key} \r\n\r\n");
                await ReplyAsync(stringBuilder1.ToString());
            }

            foreach (var kvp in KeyManager.GetAllKeyInfo())
            {
                StringBuilder stringBuilder2 = new StringBuilder();
                var discorduser = AstroBot.Client.GetUser(kvp.Value);
                stringBuilder2.Append($"[Client] {discorduser.Mention} \r\n {kvp.Key} \r\n\r\n");
                await ReplyAsync(stringBuilder2.ToString());
            }
        }

        [Command("ValidateKeys")]
        [Summary("ValidateKeys command")]
        public async Task ValidateKeys([Required] string name, [Required] string msg)
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
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append($"Client Count: {Server.Clients.Count} \r\n");
                foreach (var client in Server.Clients)
                {
                    string prefix = "Client";

                    if (client.IsDeveloper)
                    {
                        prefix = "Developer";
                    }

                    stringBuilder.Append($"{client.ClientID}: [{prefix}] {client.Name}, {client.UserID}, {client.ClientSocket.Client.RemoteEndPoint} \r\n");
                }
                await ReplyAsync(stringBuilder.ToString());
            } else
            {
                await ReplyAsync("There are no clients currently connected");
            }
        }
    }
}
