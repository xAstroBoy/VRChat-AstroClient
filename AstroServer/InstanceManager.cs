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
						other.Send(new AstroNetworkingLibrary.Serializable.PacketData(PacketServerType.ADD_TAG, "", null, tagData1));
					}

					TagData tagData2 = new TagData() { UserID = client.UserID, Text = "AstroClient" };
					other.Send(new AstroNetworkingLibrary.Serializable.PacketData(PacketServerType.ADD_TAG, "", null, tagData2));
				}
			}
		}
	}
}