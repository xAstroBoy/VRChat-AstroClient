namespace AstroNetworkingLibrary
{
	public static class PacketClientType
	{
		public const ulong AUTH = 1;
		public const ulong CONNECTED = 1;
		public const ulong DISCONNECT = 2;
		public const ulong SEND_PLAYER_USERID = 11;
		public const ulong SEND_PLAYER_NAME = 12;
		public const ulong WORLD_JOIN = 20;
		public const ulong AVATAR_DATA = 21;
		public const ulong KEEP_ALIVE = 100;

		public static ulong GET_RESOURCES = 200;
	}

	public static class PacketServerType
	{
		public const ulong EXIT = 0;
		public const ulong CONNECTED = 1;
		public const ulong DISCONNECT = 2;
		public const ulong AUTH_SUCCESS = 3;
		public const ulong AUTH_FAIlED = 4;
		public const ulong ENABLE_DEVELOPER = 10;
		public const ulong ADD_TAG = 30;
		public const ulong KEEP_ALIVE = 100;

		// Loader Stuff
		public const ulong LOADER_DONE = 200;
		public const ulong LOADER_LIBRARY = 201;
		public const ulong LOADER_MELON = 202;
		public const ulong LOADER_MODULE = 203;

		// Other Stuff
		public const ulong LOG = 300;
		public const ulong DEBUG = 301;
		public const ulong NOTIFY = 302;
	}
}
