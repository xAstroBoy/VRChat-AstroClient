namespace AstroNetworkingLibrary
{
    internal static class PacketClientType
    {
        internal const byte AUTH = 1;
        internal const byte CONNECTED = 1;
        internal const byte DISCONNECT = 2;
        internal const byte SEND_PLAYER_USERID = 11;
        internal const byte SEND_PLAYER_NAME = 12;
        internal const byte WORLD_JOIN = 20;
        internal const byte AVATAR_DATA = 21;
        internal const byte KEEP_ALIVE = 100;
        internal const byte GET_RESOURCES = 200;
        internal const byte GOT_RESOURCE = 201;
        internal const byte AVATAR_SEARCH_TYPE = 224;
        internal const byte AVATAR_SEARCH = 225;
        internal const byte AVATAR_REPORT = 226;
        internal const byte AVATAR_DELETE = 227;
    }

    internal static class PacketServerType
    {
        internal const byte EXIT = 0;
        internal const byte CONNECTED = 1;
        internal const byte DISCONNECT = 2;
        internal const byte AUTH_SUCCESS = 3;
        internal const byte AUTH_FAIlED = 4;
        internal const byte KEYSHARING = 5;
        internal const byte ENABLE_DEVELOPER = 10;
        internal const byte ENABLE_UDON = 11;
        internal const byte CONNECTION_FINISHED = 20;
        internal const byte ADD_TAG = 30;
        internal const byte KEEP_ALIVE = 100;

        // Loader Stuff
        internal const byte LOADER_DONE = 200;

        internal const byte LOADER_LIBRARY = 201;
        internal const byte LOADER_MELON = 202;
        internal const byte LOADER_MODULE = 203;

        // Other Stuff
        internal const byte LOG = 220;

        internal const byte DEBUG = 221;
        internal const byte NOTIFY = 223;

        // Avatar Stuff
        internal const byte AVATAR_RESULT = 230;

        internal const byte AVATAR_RESULT_DONE = 231;
    }
}