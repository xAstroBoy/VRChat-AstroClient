using AstroLibrary.Networking;

namespace AstroLoaderServer
{
    internal class Client : HandleClient
    {
        internal string Name = string.Empty;

        internal string Key = string.Empty;

        internal bool IsAuthed = false;

        internal bool IsReady = false;

        internal Client()
        {
            Name = "Temp"; // We'll get this later from the client after authentication is implemented
            Key = "";
            IsAuthed = false;
        }
    }
}