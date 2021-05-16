namespace AstroServer.Serializable
{
	using MongoDB.Entities;
	using System;

	[Serializable]
	public class AccountData : Entity
	{
		public string Name = string.Empty;

		public ulong DiscordID = 0;

		public string Key = string.Empty;

		public bool IsDeveloper = false;

		public bool HasUdon = false;

		public bool HasExploits = false;

		public bool HasMurder4 = false;

		public bool HasAmongUs = false;

		public bool HasFreezeTag = false;
	}
}