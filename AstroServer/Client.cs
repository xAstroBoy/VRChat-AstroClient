namespace AstroServer
{
    using AstroNetworkingLibrary;
    using AstroServer.Serializable;

    public class Client : HandleClient
    {
        public string Name = string.Empty;

        public byte ClientType;

        public string Key = string.Empty;

        public string UserID = string.Empty;

        public string InstanceID = string.Empty;

        public ulong DiscordID;

        public bool IsAuthed;

        public bool IsReady;

        public AstroData Data;

        public TempData Temp;

        public Client()
        {
            Name = "N/A";
            ClientType = 0;
            Key = "N/A";
            UserID = "N/A";
            InstanceID = "N/A";
            DiscordID = 0;
            IsAuthed = false;
            IsReady = false;
            Temp = new TempData();
        }
    }
}