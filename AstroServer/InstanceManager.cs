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
						client.Send(new PacketData(PacketServerType.NOTIFY, $"[<color=yellow>AstroClient Developer</color>] <color=cyan>{other.Name}</color>: is here!"));
					}
					else if (other.Data.IsBeta)
					{
						TagData tagData = new TagData() { UserID = other.UserID, Text = "AstroClient Beta Tester" };
						var json = JsonConvert.SerializeObject(tagData);
						client.Send(new PacketData(PacketServerType.ADD_TAG, json));
						client.Send(new PacketData(PacketServerType.NOTIFY, $"[<color=blue>AstroClient Beta Tester</color>] <color=cyan>{other.Name}</color>: is here!"));
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
							other.Send(new PacketData(PacketServerType.NOTIFY, $"[<color=cyan>AstroClient Developer</color>] <color=cyan>{client.Name}</color>: is here!"));
						}
						else if (client.Data.IsBeta)
						{
							TagData tagData = new TagData() { UserID = client.UserID, Text = "AstroClient Beta Tester" };
							var json = JsonConvert.SerializeObject(tagData);
							other.Send(new PacketData(PacketServerType.ADD_TAG, json));
							other.Send(new PacketData(PacketServerType.NOTIFY, $"[<color=blue>AstroClient Beta Tester</color>] <color=cyan>{client.Name}</color>: is here!"));
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