using AstroLibrary.Networking;

namespace AstroServer
{
    public class Client : HandleClient
    {
        public string Name = string.Empty;

        public string Key = string.Empty;

        public string UserID = string.Empty;

        public string WorldID = string.Empty;

        public ulong DiscordID = 0;

        public bool IsAuthed;

        public bool IsDeveloper;

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