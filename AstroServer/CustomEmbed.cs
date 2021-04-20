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

        public static Embed GetKeyshareEmbed(Client origin, Client other)
        {
            var discordId = KeyManager.GetKeysDiscordOwner(origin.Key);
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = Color.DarkPurple,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();

            if (KeyManager.IsDevKey(origin.Key))
            {
                embedFooterBuilder.Text = "Developer";
            }
            else
            {
                embedFooterBuilder.Text = "Client";
            }

            embedBuilder.AddField("Kicked Name", origin.Name);
            embedBuilder.AddField("Kicked UserID", origin.Name);

            embedBuilder.AddField("Origin IP", origin.ClientSocket.Client.RemoteEndPoint);
            embedBuilder.AddField("Other IP", other.ClientSocket.Client.RemoteEndPoint);
            embedBuilder.AddField("Time", $"{DateTime.Now.ToLongDateString()}, {DateTime.Now:HH:mm:ss tt}");
            embedBuilder.AddField("Key", origin.Key);

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }

        public static Embed GetLoggedInEmbed(Client client)
        {
            var color = Color.Blue;

            if (client.IsDeveloper)
            {
                color = Color.Red;
            }

            var discordId = KeyManager.GetKeysDiscordOwner(client.Key);
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = color,
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
            var color = Color.Blue;

            if (KeyManager.IsDevKey(authKey))
            {
                color = Color.Red;
            }

            var discordId = KeyManager.GetKeysDiscordOwner(authKey);
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = color,
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
