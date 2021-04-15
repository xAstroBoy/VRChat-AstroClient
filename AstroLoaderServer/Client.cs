using AstroLibrary.Networking;

namespace AstroLoaderServer
{
    internal class Client : HandleClient
    {
        internal string Name = string.Empty;

        internal string Key = string.Empty;

        internal bool IsAuthed;

        internal bool IsReady;

        internal Client()
        {
        }
    }
}