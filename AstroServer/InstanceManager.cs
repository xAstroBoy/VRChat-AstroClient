using System;
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
            var clients = Server.Clients.Where((c => c.InstanceID.Equals(client.InstanceID)));

            if (clients.Any())
            {
                foreach (Client other in Server.Clients.Where(c => c.InstanceID.Equals(client.InstanceID)))
                {
                    if (other.IsDeveloper)
                    {
                        //client.Send($"debug:{other.UserID}");
                        client.Send($"add-tag:{other.UserID},AstroClient Developer");
                    }
                    Console.WriteLine($"IM,PI: {other.UserID}, {other.InstanceID}");
                }
            }
        }
    }
}