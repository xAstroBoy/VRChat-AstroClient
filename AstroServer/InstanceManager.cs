namespace AstroServer
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using Newtonsoft.Json;

	public static class InstanceManager
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
		internal static void InstanceJoined(Client client)
		{
			foreach (Client other in ClientServer.Clients)
			{
				//if (other.InstanceID.Equals(client.InstanceID))
				//{
				//	if (other.IsDeveloper)
				//	{
				//		TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient Developer" };
				//		var json = JsonConvert.SerializeObject(tagData);
				//		client.Send(new PacketData(PacketServerType.ADD_TAG, json));
				//		client.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
				//	}
				//	else
				//	{
				//		TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient" };
				//		var json = JsonConvert.SerializeObject(tagData);
				//		client.Send(new PacketData(PacketServerType.ADD_TAG, json));
				//	}

				//	if (client.IsDeveloper)
				//	{
				//		TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient Developer" };
				//		var json = JsonConvert.SerializeObject(tagData);
				//		other.Send(new PacketData(PacketServerType.ADD_TAG, json));
				//		other.Send(new PacketData(PacketServerType.NOTIFY, $"<color=cyan>AstroClient Developer</color> {client.Name} Is Here!"));
				//	}
				//	else
				//	{
				//		TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient" };
				//		var json = JsonConvert.SerializeObject(tagData);
				//		other.Send(new PacketData(PacketServerType.ADD_TAG, json));
				//	}
				//}
			}
		}
	}
}