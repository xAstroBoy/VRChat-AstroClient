using AstroServer.DiscordBot;
using Discord;
using System;

namespace AstroServer
{
    public static class CustomEmbed
    {
        public static Embed GetKeyCountEmbed()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = "Key Count",
                Color = Color.Blue,
            };

            embedBuilder.AddField("Developers", KeyManager.GetDevKeyCount());
            embedBuilder.AddField("Clients", KeyManager.GetDevKeyCount());
            return embedBuilder.Build();
        }

        public static Embed GetLoggedInEmbed(Client client)
        {
            var discordId = KeyManager.GetKeysDiscordOwner(client.Key);
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = Color.Blue,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();

            if (KeyManager.IsDevKey(client.Key))
            {
                embedFooterBuilder.Text = "Developer";
            }
            else
            {
                embedFooterBuilder.Text = "Client";
            }

            embedBuilder.AddField("IP", client.ClientSocket.Client.RemoteEndPoint);
            embedBuilder.AddField("Time", $"{DateTime.Now.ToLongDateString()}, {DateTime.Now:HH:mm:ss tt}");
            embedBuilder.AddField("Key", client.Key);

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }

        public static Embed GetKeyEmbed(string authKey)
        {
            var discordId = KeyManager.GetKeysDiscordOwner(authKey);
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = Color.Blue,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();

            if (KeyManager.IsDevKey(authKey))
            {
                embedFooterBuilder.Text = "Developer";
            }
            else
            {
                embedFooterBuilder.Text = "Client";
            }

            embedBuilder.AddField("Key", authKey);

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }
    }
}
