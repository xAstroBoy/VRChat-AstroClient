namespace AstroServer
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using Newtonsoft.Json;

	public static class InstanceManager
	{
		internal static void InstanceJoined(Client client)
		{
			foreach (Client other in ClientServer.Clients)
			{
				if (other.InstanceID.Equals(client.InstanceID))
				{
					if (other.Data.IsDeveloper)
					{
						TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient Developer" };
						var json = JsonConvert.SerializeObject(tagData);
						client.Send(new PacketData(PacketServerType.ADD_TAG, json));
						client.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {other.Name} Is Here!"));
					}
					else
					{
						TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient" };
						var json = JsonConvert.SerializeObject(tagData);
						client.Send(new PacketData(PacketServerType.ADD_TAG, json));
					}

					if (!other.ClientID.Equals(client.ClientID))
					{
						if (client.Data.IsDeveloper)
						{
							TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient Developer" };
							var json = JsonConvert.SerializeObject(tagData);
							other.Send(new PacketData(PacketServerType.ADD_TAG, json));
							other.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
						}
						else
						{
							TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient" };
							var json = JsonConvert.SerializeObject(tagData);
							other.Send(new PacketData(PacketServerType.ADD_TAG, json));
						}
					}
				}
			}
		}
	}
}