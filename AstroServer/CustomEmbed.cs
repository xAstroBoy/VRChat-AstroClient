namespace AstroServer
{
    using AstroServer.DiscordBot;
    using AstroServer.Serializable;
    using Discord;
    using System;
    using System.Text;

    public static class CustomEmbed
    {
        public static Embed GetKeyCountEmbed()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = "Key Count",
                Color = Color.Blue,
            };

            embedBuilder.AddField("Developers", AccountManager.GetDevKeyCount());
            embedBuilder.AddField("Beta Testers", AccountManager.GetBetaKeyCount());
            embedBuilder.AddField("Clients", AccountManager.GetDevKeyCount());
            return embedBuilder.Build();
        }

        public static Embed GetNewKeyEmbed(string authkey, bool successful)
        {
            if (successful)
            {
                EmbedBuilder embedBuilder = new EmbedBuilder()
                {
                    Title = "New Key Generated",
                    Color = Color.Green,
                };

                embedBuilder.AddField("Key", authkey);
                return embedBuilder.Build();
            }
            else
            {
                EmbedBuilder embedBuilder = new EmbedBuilder()
                {
                    Title = "New Key Failed",
                    Color = Color.Red,
                };

                return embedBuilder.Build();
            }
        }

        public static Embed GetAvatarEmbed(AvatarDataEntity avatarDataEntity)
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = avatarDataEntity.Name,
                Color = Color.Blue,
                ThumbnailUrl = avatarDataEntity.ThumbnailURL,
            };

            embedBuilder.AddField("ID", avatarDataEntity.AvatarID);
            embedBuilder.AddField("Author", avatarDataEntity.AuthorName);
            embedBuilder.AddField("Release", avatarDataEntity.ReleaseStatus);
            embedBuilder.AddField("Version", avatarDataEntity.Version);

            return embedBuilder.Build();
        }

        public static Embed GetKeyshareEmbed(Client origin, Client other)
        {
            var data = AccountManager.GetAccountData(origin.Key);
            var discordId = data.DiscordID;
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = Color.DarkPurple,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();
            var text = string.Empty;

            if (data.IsDeveloper)
            {
                text = "Developer";
            }
            else if (data.IsBeta)
            {
                text = "Beta";
            }
            else
            {
                text = "Client";
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

        public static Embed GetAccountEmbed(AstroData data)
        {
            var color = Color.Blue;

            if (data.IsDeveloper)
            {
                color = Color.Gold;
            }

            var discordId = data.DiscordID;
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = color,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();
            var text = string.Empty;

            if (data.IsDeveloper)
            {
                text = "Developer";
            }
            else if (data.IsBeta)
            {
                text = "Beta";
            }
            else
            {
                text = "Client";
            }

            embedBuilder.AddField("Name", data.Name);
            embedBuilder.AddField("Discord", data.DiscordID);

            StringBuilder sb = new StringBuilder();

            if (data.HasExploits)
            {
                sb.Append("HasExploits ");
            }

            if (data.HasUdon)
            {
                sb.Append("HasUdon ");
            }

            if (data.HasAmongUs)
            {
                sb.Append("HasAmongUs ");
            }

            if (data.HasFreezeTag)
            {
                sb.Append("HasFreezeTag ");
            }

            if (data.HasMurder4)
            {
                sb.Append("HasMurder4 ");
            }

            var perms = sb.ToString();

            if (perms != null && perms != string.Empty)
            {
                embedBuilder.AddField("Permissions", sb.ToString());
            }
            embedBuilder.AddField("Key", data.Key);

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }

        public static Embed GetClientEmbed(Client client)
        {
            var color = Color.Blue;

            if (client.Data.IsDeveloper)
            {
                color = Color.Red;
            }

            var data = AccountManager.GetAccountData(client.Key);
            var discordId = data.DiscordID;
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = color,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();
            var text = string.Empty;

            if (data.IsDeveloper)
            {
                text = "Developer";
            }
            else if (data.IsBeta)
            {
                text = "Beta";
            }
            else
            {
                text = "Client";
            }

            embedBuilder.AddField("IP", client.ClientSocket.Client.RemoteEndPoint);

            if (client.Name != null && client.Name != string.Empty)
            {
                embedBuilder.AddField("Name", client.Name);
            }

            if (client.UserID != null && client.UserID != string.Empty)
            {
                embedBuilder.AddField("UserID", client.UserID);
            }

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }

        public static Embed GetLoggedInEmbed(Client client)
        {
            var color = Color.Blue;

            if (client.Data.IsDeveloper)
            {
                color = Color.Gold;
            }

            var data = AccountManager.GetAccountData(client.Key);
            var discordId = data.DiscordID;
            var discordUser = AstroBot.Client.GetUser(discordId);

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = color,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();
            var text = string.Empty;

            if (data.IsDeveloper)
            {
                text = "Developer";
            }
            else if (data.IsBeta)
            {
                text = "Beta";
            }
            else
            {
                text = "Client";
            }

            embedBuilder.AddField("IP", client.ClientSocket.Client.RemoteEndPoint);
            embedBuilder.AddField("Time", $"{DateTime.Now.ToLongDateString()}, {DateTime.Now:HH:mm:ss tt}");
            embedBuilder.AddField("Key", client.Key);

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }

        internal static Embed GetLoggedInFailedEmbed(Client client, string reason)
        {
            var color = Color.Orange;

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = "Failed Login",
                Color = color,
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();

            embedBuilder.AddField("Reason", reason);
            embedBuilder.AddField("IP", client.ClientSocket.Client.RemoteEndPoint);
            embedBuilder.AddField("Time", $"{DateTime.Now.ToLongDateString()}, {DateTime.Now:HH:mm:ss tt}");
            embedBuilder.AddField("Key", client.Key);

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }

        public static Embed GetKeyEmbed(string authKey)
        {
            var data = AccountManager.GetAccountData(authKey);
            var discordId = data.DiscordID;
            var discordUser = AstroBot.Client.GetUser(discordId);

            var color = Color.Blue;

            if (data.IsDeveloper)
            {
                color = Color.Gold;
            }

            EmbedBuilder embedBuilder = new EmbedBuilder()
            {
                Title = DiscordUtils.GetDiscordName(discordId),
                Color = color,
                ThumbnailUrl = discordUser.GetAvatarUrl()
            };

            EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();
            var text = string.Empty;

            if (data.IsDeveloper)
            {
                text = "Developer";
            }
            else if (data.IsBeta)
            {
                text = "Beta";
            }
            else
            {
                text = "Client";
            }

            embedBuilder.AddField("Key", authKey);

            embedBuilder.Footer = embedFooterBuilder;

            return embedBuilder.Build();
        }
    }
}