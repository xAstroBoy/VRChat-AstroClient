namespace AstroServer.DiscordBot.Attributes
{
	using AstroServer.DiscordBot.Extensions;
	using Discord.Commands;
	using Discord.WebSocket;
	using System;
	using System.Threading.Tasks;

	/// <summary>
	/// Requires the user to be part of the official team for the bot.
	/// </summary>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class RequireTeamAttribute : PreconditionAttribute
	{
		public override async Task<PreconditionResult> CheckPermissionsAsync(ICommandContext _context, CommandInfo _command, IServiceProvider _services)
		{
			SocketUser user = _context.User as SocketUser;

			return !await user.IsBotDeveloperAsync()
				? PreconditionResult.FromError("This command can only be ran by a developer.")
				: PreconditionResult.FromSuccess();
		}
	}
}