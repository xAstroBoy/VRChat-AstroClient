namespace AstroServer.DiscordBot.Commands
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using AstroServer.DiscordBot.Attributes;
	using AstroServer.Serializable;
	using Discord.Commands;
	using MongoDB.Entities;
	using System;
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
		public async Task Notify([Required] ulong discordID, [Required] string msg)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Client client in ClientServer.Clients.Where(c => c.DiscordID == discordID))
			{
				client.Send(new AstroNetworkingLibrary.Serializable.PacketData(PacketServerType.NOTIFY, msg));
				stringBuilder.Append($"Notified: {client.Name}, {client.UserID} \r\n");
			}

			var repy = stringBuilder.ToString();

			if (repy != null && repy != string.Empty)
			{
				_ = await ReplyAsync(repy);
			}
			else
			{
				_ = await ReplyAsync($"Nobody found with the discord ID '{discordID}'");
			}
		}

		[Command("Kick")]
		[Summary("Kick command")]
		public async Task Kick([Required] string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Client client in ClientServer.Clients.Where(c => c.Name.Contains(name)))
			{
				client.Send(new PacketData(PacketServerType.EXIT, "You have been kicked"));
				stringBuilder.Append($"Kicked: {client.Name}, {client.UserID} \r\n");
			}

			_ = await ReplyAsync(stringBuilder.ToString());
		}

		[Command("List")]
		[Summary("List command")]
		public async Task List()
		{
			var clients = ClientServer.Clients.Where(c => c.IsConnected);
			if (clients.Any())
			{
				foreach (Client client in clients)
				{
					_ = await ReplyAsync(null, false, CustomEmbed.GetClientEmbed(client));
				}
			}
			else
			{
				_ = await ReplyAsync("There are no clients currently connected");
			}
		}

		[Command("Avatar")]
		[Summary("Avatar command")]
		public async Task Avatar([Required] string query, int count = 1)
		{
			if (count > 10)
			{
				count = 10;
			}
			if (count < 1)
			{
				count = 1;
			}

			var avatars = await DB.Find<AvatarDataEntity>().ManyAsync(a => a.Name.ToLower().Contains(query.ToLower()));

			if (avatars.Any())
			{
				foreach (var avatar in avatars.Take(count))
				{
					await ReplyAsync(null, false, CustomEmbed.GetAvatarEmbed(avatar));
				}
			}
			else
			{
				await ReplyAsync("No avatars found!");
			}
		}

		[Command("Info")]
		[Summary("Info command")]
		public async Task Info(int code = 0)
		{
			switch (code)
			{
				case 0:
					{
						var avatarCount = await DB.CountAsync<AvatarDataEntity>();
						await ReplyAsync($"There are {avatarCount} avatars in the database.");
						break;
					}

				default:
					await ReplyAsync("Invalid code");
					break;
			}
		}
	}
}