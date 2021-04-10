namespace AstroServer
{
    using System;

    internal class Client : HandleClient
    {
        public EventHandler<EventArgs> LoggedIn;

        internal string Name { get; private set; }

        internal bool IsLoggedIn { get; private set; }

        internal Client()
        {
            Name = "Temp"; // We'll get this later from the client after authentication is implemented
        }
    }
}