﻿namespace AstroClient
{
    public class ReceivedTextEventArgs
    {
        public string Message { get; private set; }

        public int ClientID { get; private set; }

        public ReceivedTextEventArgs(int clientID, string message)
        {
            Message = message;
            ClientID = clientID;
        }
    }
}
