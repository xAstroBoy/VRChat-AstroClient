namespace AstroLibrary.Extensions
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	public static class PlayerManagerExtension
	{
		public static List<Player> AllPlayers(this PlayerManager Instance)
		{
			return Instance.field_Private_List_1_Player_0.ToArray().ToList();
		}

		public static List<int> AllPlayersIDs(this PlayerManager Instance)
		{
			return (from p in Instance.AllPlayers()
					select p.GetVRCPlayerApi().playerId).ToList();
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
			foreach (var player in from player in Players
								   where player.GetAPIUser().UserID() == UserID
								   select player)
			{
				return player;
			}

			return null;
		}

		public static Player GetPlayerByRayCast(this RaycastHit RayCast)
		{
			return GetPlayer(Utils.PlayerManager, VRCPlayerApi.GetPlayerByGameObject(RayCast.transform.gameObject).playerId);
		}
	}
}