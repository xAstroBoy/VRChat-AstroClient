﻿namespace AstroServer
{
	using AstroNetworkingLibrary;
	using AstroServer.Serializable;

	public class Client : HandleClient
	{
		public string Name = string.Empty;

		public string Key = string.Empty;

		public string UserID = string.Empty;

		public string InstanceID = string.Empty;

		public ulong DiscordID;

		public bool IsAuthed;

		public bool IsReady;

		public AccountData Data;

		internal Client()
		{
			Name = "N/A";
			Key = "N/A";
			UserID = "N/A";
			InstanceID = "N/A";
			DiscordID = 0;
			IsAuthed = false;
			IsReady = false;
		}
	}
}