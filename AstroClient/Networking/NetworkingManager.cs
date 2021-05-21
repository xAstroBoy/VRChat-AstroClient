namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroClient.variables;
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using UnityEngine;
	using VRC.SDKBase;

	public class NetworkingManager : GameEvents
	{
		/// <summary>
		/// Gets whether the NetworkingManager has initialized and contains the player's information.
		/// </summary>
		public static bool Initialized { get; private set; }

		public static string Name = string.Empty;

		public static string UserID = string.Empty;

		public override void OnAvatarSpawn(GameObject avatar, VRC_AvatarDescriptor DescriptorObj, bool state)
		{
			if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
			{
				//string bson = BSonWriter.ToBson(data);
				//AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_DATA, "", bson.ConvertToBytes()));
			}
		}

		public static void SendClientInfo()
		{
			if (Initialized)
			{
				if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
				{
					if (Bools.IsDeveloper)
					{
						ModConsole.DebugLog($"Sending Client Information: {Name}, {UserID}");
					}
					AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_USERID, LocalPlayerUtils.GetSelfPlayer().UserID()));
					AstroNetworkClient.Client.Send(new PacketData(PacketClientType.SEND_PLAYER_NAME, LocalPlayerUtils.GetSelfPlayer().DisplayName()));
				}
			}
		}

		public static void SendInstanceInfo()
		{
			if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
			{
				var instanceID = RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.idWithTags;
				AstroNetworkClient.Client.Send(new PacketData(PacketClientType.WORLD_JOIN, instanceID));
			}
		}

		public override void OnWorldReveal(string id, string Name, string tags, string AssetURL)
		{
			var self = LocalPlayerUtils.GetSelfPlayer();
			Name = self.DisplayName();
			UserID = self.UserID();

			MiscUtility.DelayFunction(2f, () =>
			{
				Initialized = true;
				SendClientInfo();
				SendInstanceInfo();
			});
		}
	}
}