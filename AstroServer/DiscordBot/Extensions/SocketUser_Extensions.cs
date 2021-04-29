namespace AstroServer.DiscordBot.Extensions
	{
	using Discord.WebSocket;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public static class SocketUser_Extensions
		{
		public static async Task<bool> IsBotDeveloperAsync(this SocketUser _user)
			{
			return AstroBot.DeveloperIDs.Contains(_user.Id);
			}
		}
	}