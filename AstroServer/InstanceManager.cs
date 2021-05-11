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
					}
					else
					{
						TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient" };
						other.Send(new PacketData(PacketServerType.ADD_TAG, "", null, tagData));
					}
				}
			}
		}
	}
}