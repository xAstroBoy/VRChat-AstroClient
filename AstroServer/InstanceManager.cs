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
				if (other.InstanceID.Equals(client.InstanceID) && !other.UserID.Equals(client.UserID))
				{
					if (client.IsDeveloper)
					{
						TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient Developer" };
						var bson = BSonWriter.ToBson(tagData);
						other.Send(new PacketData(PacketServerType.ADD_TAG, bson));
						other.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
					}
					else
					{
						TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient" };
						var bson = BSonWriter.ToBson(tagData);
						other.Send(new PacketData(PacketServerType.ADD_TAG, bson));
					}

					if (other.IsDeveloper)
					{
						TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient Developer" };
						var bson = BSonWriter.ToBson(tagData);
						client.Send(new PacketData(PacketServerType.ADD_TAG, bson));
						client.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
					}
					else
					{
						TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient" };
						var bson = BSonWriter.ToBson(tagData);
						client.Send(new PacketData(PacketServerType.ADD_TAG, bson));
					}
				}
			}
		}
	}
}