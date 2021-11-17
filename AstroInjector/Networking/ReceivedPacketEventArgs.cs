namespace AstroNetworkingLibrary
{
    using Serializable;

    internal class ReceivedPacketEventArgs
    {
        internal PacketData Data { get; private set; }

        internal int ClientID { get; private set; }

        internal ReceivedPacketEventArgs(int clientID, PacketData data)
        {
            Data = data;
            ClientID = clientID;
        }
    }
}