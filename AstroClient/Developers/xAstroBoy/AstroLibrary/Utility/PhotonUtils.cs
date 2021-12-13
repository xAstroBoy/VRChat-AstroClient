// Credit to Dayoftheplay for this.

namespace AstroClient.xAstroBoy.Utility
{
    using System.Collections.Generic;
    using Blaze;

    public static class PhotonUtils
    {
        public static string GetUserID(this Photon.Realtime.Player player)
        {
            if (player != null)
            {
                if (player.GetRawHashtable() != null)
                {
                    if (player.GetRawHashtable().ContainsKey("user"))
                    {
                        if (player.GetHashtable()["user"] != null)
                        {
                            if (player.GetHashtable()["user"] is Dictionary<string, object> dict)
                            {
                                return  (string)dict["id"];
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static string GetDisplayName(this Photon.Realtime.Player player)
        {
            if (player != null && player.GetRawHashtable() != null && player.GetRawHashtable().ContainsKey("user") && player.GetHashtable()["user"] != null)
            {
                if (player.GetHashtable()["user"] is Dictionary<string, object> dict)
                {
                    return (string)dict["displayName"];

                }
            }
            if (player != null)
            {
                return $"Photon ID : {player.GetPhotonID()}";
            }
            return "Unknown Player";
        }

        public static int GetPhotonID(this Photon.Realtime.Player player) => player.field_Private_Int32_0;

        public static VRC.Player GetPhotonPlayer(this Photon.Realtime.Player player) => player.field_Public_Player_0;

        public static System.Collections.Hashtable GetHashtable(this Photon.Realtime.Player player) => SerializationUtils.FromIL2CPPToManaged<System.Collections.Hashtable>(player.GetRawHashtable());

        public static Il2CppSystem.Collections.Hashtable GetRawHashtable(this Photon.Realtime.Player player) => player.prop_Hashtable_0;

        public static List<Photon.Realtime.Player> GetAllPhotonPlayers(this Photon.Realtime.LoadBalancingClient Instance)
        {
            List<Photon.Realtime.Player> result = new List<Photon.Realtime.Player>();
            if (WorldUtils.IsInWorld)
            {
                foreach (var x in Instance.prop_Room_0.prop_Dictionary_2_Int32_Player_0)
                {
                    if (x != null)
                    {
                        result.Add(x.Value);
                    }
                }
            }
            return result;
        }

        public static Photon.Realtime.Player GetPhotonPlayer(this Photon.Realtime.LoadBalancingClient Instance, int photonID)
        {
            List<Photon.Realtime.Player> list = Instance.GetAllPhotonPlayers();
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Photon.Realtime.Player player = list[i];
                    if (player != null)
                    {
                        if (player.GetPhotonID() == photonID)
                        {
                            return player;
                        }
                    }
                }
            }

            return null;
        }

        public static Photon.Realtime.Player GetPhotonPlayer(this Photon.Realtime.LoadBalancingClient Instance, string userID)
        {
            List<Photon.Realtime.Player> list = Instance.GetAllPhotonPlayers();
            for (int i = 0; i < list.Count; i++)
            {
                Photon.Realtime.Player player = list[i];
                if (player != null)
                {
                    if (player.GetUserID() == userID)
                    {
                        return player;
                    }
                }
            }

            return null;
        }
    }
}
