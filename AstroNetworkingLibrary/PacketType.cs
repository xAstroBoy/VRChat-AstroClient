namespace AstroNetworkingLibrary
{
	public static class PacketClientType
	{
		public const ulong AUTH = 1;
		public const ulong KEEP_ALIVE = 100;
	}

	public static class PacketServerType
	{
		public const ulong EXIT = 0;
		public const ulong CONNECTED = 1;
		public const ulong DISCONNECT = 2;
		public const ulong AUTH_SUCCESS = 3;
		public const ulong AUTH_FAIlED = 4;
		public const ulong ENABLE_DEVELOPER = 10;
		public const ulong KEEP_ALIVE = 100;
	}
}
