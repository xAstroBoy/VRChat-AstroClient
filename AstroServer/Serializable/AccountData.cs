namespace AstroServer.Serializable
{
	using MongoDB.Entities;
	using System;

	[Serializable]
	public class AccountData : Entity
	{
		public string Key = string.Empty;

		public string Name = string.Empty;

		public ulong DiscordID;

		public bool IsDeveloper;

		public bool IsBeta;

		public bool HasUdon;

		public bool HasExploits;

		public bool HasMurder4;

		public bool HasAmongUs;

		public bool HasFreezeTag;
	}
}