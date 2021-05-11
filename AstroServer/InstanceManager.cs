namespace AstroServer
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;

	public static class InstanceManager
	{
		internal static void InstanceJoined(Client client)
		{
			foreach (var other in ClientServer.Clients)
			{
				if (other.InstanceID.Equals(client.InstanceID))
				{
					if (client.IsDeveloper)
					{
						TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient Developer" };
						other.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData));
						if (!other.ClientID.Equals(client.ClientID))
						{
							other.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
						}
					}
					else
					{
						TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient" };
						other.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData));
					}

					if (other.IsDeveloper)
					{
						TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient Developer" };
						client.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData));
						if (!client.ClientID.Equals(other.ClientID))
						{
							client.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
						}
					}
					else
					{
						TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient" };
						client.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData));
					}
				}
			}
		}
	}
}