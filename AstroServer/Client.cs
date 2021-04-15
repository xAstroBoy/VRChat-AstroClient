using AstroLibrary.Networking;

namespace AstroServer
{
    internal class Client : HandleClient
    {
        internal string Name = string.Empty;

        internal string Key = string.Empty;

        internal bool IsAuthed = false;

        internal Client()
        {
            Name = "Temp"; // We'll get this later from the client after authentication is implemented
            Key = "";
            IsAuthed = false;
        }
    }
}