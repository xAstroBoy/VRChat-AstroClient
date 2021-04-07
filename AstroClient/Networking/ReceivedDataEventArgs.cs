namespace AstroClient
{
    public class ReceivedDataEventArgs
    {
        public string Message { get; private set; }

        public int ClientID { get; private set; }

        public ReceivedDataEventArgs(int clientID, string message)
        {
            Message = message;
            ClientID = clientID;
        }
    }
}
