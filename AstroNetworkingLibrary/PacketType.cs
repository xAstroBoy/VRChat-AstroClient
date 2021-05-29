namespace AstroNetworkingLibrary
{
	public static class PacketClientType
	{
		public const byte AUTH = 1;
		public const byte CONNECTED = 1;
		public const byte DISCONNECT = 2;
		public const byte SEND_PLAYER_USERID = 11;
		public const byte SEND_PLAYER_NAME = 12;
		public const byte WORLD_JOIN = 20;
		public const byte AVATAR_DATA = 21;
		public const byte KEEP_ALIVE = 100;
		public const byte GET_RESOURCES = 200;
		public const byte AVATAR_SEARCH = 225;
	}

	public static class PacketServerType
	{
		public const byte EXIT = 0;
		public const byte CONNECTED = 1;
		public const byte DISCONNECT = 2;
		public const byte AUTH_SUCCESS = 3;
		public const byte AUTH_FAIlED = 4;
		public const byte ENABLE_DEVELOPER = 10;
		public const byte EXPLOIT_DATA = 11;
		public const byte ADD_TAG = 30;
		public const byte KEEP_ALIVE = 100;

		// Loader Stuff
		public const byte LOADER_DONE = 200;
		public const byte LOADER_LIBRARY = 201;
		public const byte LOADER_MELON = 202;
		public const byte LOADER_MODULE = 203;

		// Other Stuff
		public const byte LOG = 220;
		public const byte DEBUG = 221;
		public const byte NOTIFY = 223;

		// Avatar Stuff
		public const byte AVATAR_RESULT = 230;
		public const byte AVATAR_RESULT_DONE = 231;
	}
}
