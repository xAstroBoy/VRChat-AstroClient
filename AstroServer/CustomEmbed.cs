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

			embedBuilder.AddField("Developers", KeyManager.GetDevKeyCount());
			embedBuilder.AddField("Clients", KeyManager.GetDevKeyCount());
			return embedBuilder.Build();
		}

		public static Embed GetNewKeyEmbed(string authkey, ulong discordID, bool successful)
		{
			if (successful)
			{
				EmbedBuilder embedBuilder = new EmbedBuilder()
				{
					Title = "New Key Generated",
					Color = Color.Green,
				};

				embedBuilder.AddField("Discord", DiscordUtils.GetDiscordName(discordID));
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

		public static Embed GetAccountEmbed(AccountData account)
		{
			var color = Color.Blue;

			if (account.IsDeveloper)
			{
				color = Color.Red;
			}

			var discordId = KeyManager.GetKeysDiscordOwner(account.Key);
			var discordUser = AstroBot.Client.GetUser(discordId);

			EmbedBuilder embedBuilder = new EmbedBuilder()
			{
				Title = DiscordUtils.GetDiscordName(discordId),
				Color = color,
				ThumbnailUrl = discordUser.GetAvatarUrl()
			};

			EmbedFooterBuilder embedFooterBuilder = new EmbedFooterBuilder();

			if (KeyManager.IsDevKey(account.Key))
			{
				embedFooterBuilder.Text = "Developer";
			}
			else
			{
				embedFooterBuilder.Text = "Client";
			}

			embedBuilder.AddField("Name", account.Name);
			embedBuilder.AddField("Discord", account.DiscordID);

			StringBuilder sb = new StringBuilder();

			if (account.HasExploits)
			{
				sb.Append("HasExploits ");
			}

			if (account.HasUdon)
			{
				sb.Append("HasUdon ");
			}

			if (account.HasAmongUs)
			{
				sb.Append("HasAmongUs ");
			}

			if (account.HasFreezeTag)
			{
				sb.Append("HasFreezeTag ");
			}

			if (account.HasMurder4)
			{
				sb.Append("HasMurder4 ");
			}

			var perms = sb.ToString();

			if (perms != null && perms != string.Empty)
			{
				embedBuilder.AddField("Permissions", sb.ToString());
			}
			embedBuilder.AddField("Key", account.Key);

			embedBuilder.Footer = embedFooterBuilder;

			return embedBuilder.Build();
		}

		public static Embed GetClientEmbed(Client client)
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