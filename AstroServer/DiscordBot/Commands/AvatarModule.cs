namespace AstroServer.DiscordBot.Commands
{
	using AstroServer.DiscordBot.Attributes;
	using AstroServer.Serializable;
	using Discord.Commands;
	using MongoDB.Entities;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Threading.Tasks;

	[Group("Admin")]
	[RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
	[RequireTeam]
	public class AvatarModule : ModuleBase<SocketCommandContext>
	{
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