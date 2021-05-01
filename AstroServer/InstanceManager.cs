namespace AstroServer
{
	using System;
	using System.Linq;

	public static class InstanceManager
	{
		/// <summary>
		/// Checks who's in the same instance and sends information etc..
		/// </summary>
		/// <param name="client"></param>
		public static void PlayerInfo(Client client)
		{
			if (ClientServer.Clients.Where((c => c.InstanceID.Equals(client.InstanceID))).Any())
			{
				foreach (Client other in ClientServer.Clients.Where(c => c.InstanceID.Equals(client.InstanceID)))
				{
					if (other.IsDeveloper)
					{
						client.Send($"add-tag:{other.UserID},AstroClient Developer");
					}
					Console.WriteLine($"IM,PI: {other.UserID}, {other.InstanceID}");
				}
			}
		}
	}
}