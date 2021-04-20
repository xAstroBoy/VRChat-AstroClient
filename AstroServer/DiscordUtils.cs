using AstroServer.DiscordBot;

namespace AstroServer
{
    public static class DiscordUtils
    {
        public static string GetDiscordName(ulong id)
        {
            return $"{AstroBot.Client.GetUser(id).Username}#{AstroBot.Client.GetUser(id).Discriminator}";
        }
    }
}
