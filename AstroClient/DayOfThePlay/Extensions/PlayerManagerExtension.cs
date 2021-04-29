using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace DayClientML2.Utility.Extensions
{
	public static class PlayerManagerExtension
	{
		public static List<Player> AllPlayers(this PlayerManager Instance)
		{
			return Instance.field_Private_List_1_Player_0.ToArray().ToList();
		}

		public static List<int> AllPlayersIDs(this PlayerManager Instance)
		{
			List<int> PhotonIDs = new List<int>();
			foreach (var p in Instance.AllPlayers())
				PhotonIDs.Add(p.GetVRCPlayerApi().playerId);
			return PhotonIDs;
		}

		public static Player GetPlayer(this PlayerManager Instance, int Index)
		{
			var Players = Instance.AllPlayers();
			return Players[Index];
		}

		public static Player GetPlayerID(this PlayerManager Instance, int playerID)
		{
			var Players = Instance.AllPlayers();
			foreach (Player player in Players.ToArray())
				if (player.GetVRCPlayerApi().playerId == playerID)
					return player;
			return null;
		}

		public static Player GetPlayer(this PlayerManager Instance, string UserID)
		{
			var Players = Instance.AllPlayers();
			for (int i = 0; i < Players.Count; i++)
			{
				var player = Players[i];
				if (player.GetAPIUser().UserID() == UserID)
					return Players[i];
			}
			return null;
		}

		public static Player GetPlayerByRayCast(this RaycastHit RayCast)
		{
			var gameObject = RayCast.transform.gameObject;
			return GetPlayer(Utils.PlayerManager, VRCPlayerApi.GetPlayerByGameObject(gameObject).playerId);
		}
	}
}