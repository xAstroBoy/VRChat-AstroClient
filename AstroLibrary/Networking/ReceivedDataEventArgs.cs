using System;

namespace AstroLibrary.Networking
{
    public class ReceivedDataEventArgs
    {
        public byte[] Data { get; private set; }

        public int ClientID { get; private set; }

        public ReceivedDataEventArgs(int clientID, byte[] data)
        {
            Data = data;
            Console.WriteLine($"ReceivedDataEventArgs: data.Length = {data.Length}");
            ClientID = clientID;
        }
    }
}