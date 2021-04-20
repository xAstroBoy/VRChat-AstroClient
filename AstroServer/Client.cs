using AstroLibrary.Networking;

namespace AstroServer
{
    internal class Client : HandleClient
    {
        internal string Name = string.Empty;

        internal string Key = string.Empty;

        internal string UserID = string.Empty;

        internal ulong DiscordID = 0;

        internal bool IsAuthed;

        internal bool IsDeveloper;

        internal Client()
        {
            Name = "";
            Key = "";
            UserID = "";
            DiscordID = 0;
            IsAuthed = false;
            IsDeveloper = false;
        }
    }
}