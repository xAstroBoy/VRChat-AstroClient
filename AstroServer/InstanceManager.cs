namespace AstroServer
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using Newtonsoft.Json;

	public static class InstanceManager
	{
		internal static void InstanceJoined(Client client)
		{
			foreach (var other in ClientServer.Clients)
			{
				if (other.InstanceID.Equals(client.InstanceID))
				{
					if (other.IsDeveloper)
					{
						TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient Developer" };
						var json = JsonConvert.SerializeObject(tagData);
						other.Send(new PacketData(PacketServerType.ADD_TAG, json));
						client.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
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