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
						TagData tagData1 = new TagData() { UserID = client.UserID, Text = "AstroClient Developer" };
						other.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData1));
					}

					if (other.IsDeveloper)
					{
						TagData tagData1 = new TagData() { UserID = other.UserID, Text = "AstroClient Developer" };
						client.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData1));
					}

					TagData tagData2 = new TagData() { UserID = client.UserID, Text = "AstroClient" };
					TagData tagData3 = new TagData() { UserID = other.UserID, Text = "AstroClient" };
					other.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData2));
					client.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData3));
				}
			}
		}
	}
}