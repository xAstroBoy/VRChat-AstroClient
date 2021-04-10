namespace AstroServer
{
    public class ReceivedTextEventArgs
    {
        public string Message { get; private set; }

        public int ClientID { get; private set; }
        public ReceivedTextEventArgs(int clientID, string message, bool encrypted = false)
        {
            Message = message;
            ClientID = clientID;
        }
    }
}