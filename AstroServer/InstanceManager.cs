using System.Linq;

namespace AstroServer
{
    public static class InstanceManager
    {
        /// <summary>
        /// Checks who's in the same instance and sends information etc..
        /// </summary>
        /// <param name="client"></param>
        public static void PlayerInfo(Client client)
        {
            foreach (Client other in Server.Clients.Where(c => c.InstanceID == client.InstanceID))
            {
                //client.Send($"add-tag:{client.UserID},AstroClient Developer");
                client.Send($"debug:{other.UserID}");
            }
        }
    }
}