namespace AstroClient.xAstroBoy.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Utility;
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
            Player[] array = Instance.AllPlayers().ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Player player = array[i];
                if (player.GetVRCPlayerApi().playerId == playerID)
                    return player;
            }

            return null;
        }

        public static Player GetPlayer(this PlayerManager Instance, string UserID)
        {
            var Players = Instance.AllPlayers();
            foreach (var player in from player in Players
                                   where player.GetAPIUser().GetUserID() == UserID
                                   select player)
            {
                return player;
            }

            return null;
        }

        public static Player GetPlayerByRayCast(this RaycastHit RayCast)
        {
            return GetPlayer(GameInstances.PlayerManager, VRCPlayerApi.GetPlayerByGameObject(RayCast.transform.gameObject).playerId);
        }
    }
}