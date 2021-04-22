using System.Linq;

namespace AstroServer
{
    public static class InstanceManager
    {
        /// <summary>
        /// Checks who's in the same instance and sends information etc..
        /// </summary>
        /// <param name="client"></param>
        public static void ClientJoinedInstance(Client client)
        {
            foreach (Client other in Server.Clients.Where(c => c.InstanceID == client.InstanceID))
            {
                if (client.IsDeveloper)
                {
                    other.Send($"notify-dev:AstroClient Developer {client.Name} Joined!");
                }
            }
        }
    }
}
