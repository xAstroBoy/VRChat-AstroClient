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
            //foreach (Client other in Server.Clients.Where(c => c.InstanceID == client.InstanceID))
            //{
            //    if (client.IsDeveloper)
            //    {
            //        client.Send($"add-tag:{other.UserID},AstroClient");
            //        other.Send($"add-tag:{client.UserID},AstroClient Developer");
            //    }
            //    if (other.IsDeveloper)
            //    {
            //        client.Send($"add-tag:{other.UserID},AstroClient Developer");
            //        other.Send($"add-tag:{client.UserID},AstroClient");
            //    }
            //}
        }
    }
}
