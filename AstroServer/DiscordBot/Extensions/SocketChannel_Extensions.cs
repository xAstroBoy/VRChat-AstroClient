namespace AstroServer.DiscordBot
{
    using Discord.WebSocket;
    using System.Linq;

    public static class SocketChannel_Extensions
    {
        public static SocketGuild GetGuild(this ISocketMessageChannel _channel)
        {
            return AstroBot.Client.Guilds.Where(guild => guild.Channels.Any(channel1 => channel1.Id == _channel.Id)).FirstOrDefault();
        }
    }
}