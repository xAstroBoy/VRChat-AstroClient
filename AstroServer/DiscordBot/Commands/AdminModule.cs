namespace AstroServer.DiscordBot.Commands
{
	using AstroNetworkingLibrary;
	using AstroServer.DiscordBot.Attributes;
	using AstroServer.Serializable;
	using Discord.Commands;
	using MongoDB.Entities;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	[Discord.Commands.Name("Admin")]
	[RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
	[RequireTeam]
	public class AdminModule : ModuleBase<SocketCommandContext>
	{
		[Command("GenKey")]
		[Summary("GenKey command")]
		public async Task GenKey([Required] ulong discordID)
		{
			string key = RandomOrg.GetRandomKey();

			if (key != string.Empty)
			{
				if (!KeyManager.IsKeyValid(key))
				{
					_ = await ReplyAsync(null, false, CustomEmbed.GetNewKeyEmbed(key, discordID, true));
					KeyManager.AddKey(key, discordID);
				}
				else
				{
					_ = await ReplyAsync(null, false, CustomEmbed.GetNewKeyEmbed(key, discordID, false));
				}
			}
			else
			{
				_ = await ReplyAsync("Failed to generate key, string.Empty was returned.");
			}
		}

		[Command("KeyCount")]
		[Summary("KeyCount command")]
		public async Task KeyCount()
		{
			_ = await ReplyAsync(null, false, CustomEmbed.GetKeyCountEmbed());
		}

		[Command("Accounts")]
		[Summary("Accounts command")]
		public async Task Accounts()
		{
			var accounts = DB.Queryable<AccountData>();
			foreach (var account in accounts)
			{
				_ = await base.ReplyAsync(null, false, CustomEmbed.GetAccountEmbed(account));
			}
		}

		[Command("Notify")]
		[Summary("Notify command")]
		public async Task Notify([Required] string name, [Required] string msg)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Client client in ClientServer.Clients.Where(c => c.Name.Contains(name)))
			{
				client.Send(new AstroNetworkingLibrary.Serializable.PacketData(PacketServerType.NOTIFY, msg));
				stringBuilder.Append($"Notified: {client.Name}, {client.UserID} \r\n");
			}

			_ = await ReplyAsync(stringBuilder.ToString());
		}

		[Command("SendAll")]
		[Summary("SendAll command")]
		public async Task SendAll([Required] string cmd)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Client client in ClientServer.Clients)
			{
				//client.Send(cmd);
				stringBuilder.Append($"Command ran on: {client.Name}, {client.UserID} \r\n");
			}

			_ = await ReplyAsync(stringBuilder.ToString());
		}

		[Command("Send")]
		[Summary("Send command")]
		public async Task Send([Required] string name, [Required] string cmd)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Client client in ClientServer.Clients.Where(c => c.Name.Contains(name)))
			{
				//client.Send(cmd);
				stringBuilder.Append($"Command ran on: {client.Name}, {client.UserID} \r\n");
			}
			_ = await ReplyAsync(stringBuilder.ToString());
		}

		[Command("Kick")]
		[Summary("Kick command")]
		public async Task Kick([Required] string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Client client in ClientServer.Clients.Where(c => c.Name.Contains(name)))
			{
				client.Send(new AstroNetworkingLibrary.Serializable.PacketData(PacketServerType.EXIT, "You have been kicked"));
				stringBuilder.Append($"Kicked: {client.Name}, {client.UserID} \r\n");
			}

			_ = await ReplyAsync(stringBuilder.ToString());
		}

		[Command("List")]
		[Summary("List command")]
		public async Task List()
		{
			if (ClientServer.Clients.Count > 0)
			{
				//stringBuilder.Append($"Client Count: {Server.Clients.Count} \r\n");

				foreach (Client client in ClientServer.Clients)
				{
					_ = await ReplyAsync(null, false, CustomEmbed.GetClientEmbed(client));
				}
			}
			else
			{
				_ = await ReplyAsync("There are no clients currently connected");
			}
		}
	}
}