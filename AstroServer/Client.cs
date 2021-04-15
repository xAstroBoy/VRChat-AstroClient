using AstroLibrary.Networking;

namespace AstroServer
{
    internal class Client : HandleClient
    {
        internal string Name = string.Empty;

        internal string Key = string.Empty;

        internal string UserID = string.Empty;

        internal bool IsAuthed;

        internal bool IsDeveloper;

        internal Client()
        {
        }
    }
}