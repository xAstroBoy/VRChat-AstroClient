namespace AstroNetworkingLibrary
{
    using System.Text.RegularExpressions;

    public class ReceivedTextEventArgs
    {
        public string Message { get; private set; }

        public int ClientID { get; private set; }

        public ReceivedTextEventArgs(int clientID, string message)
        {
            string text1 = message;
            Message = Regex.Replace(text1, @"[^a-zA-Z0-9{}@#$%&*+\-_(),+':;?.,!\[\]\s\\/]+$", string.Empty).Trim();
            ClientID = clientID;
        }
    }
}