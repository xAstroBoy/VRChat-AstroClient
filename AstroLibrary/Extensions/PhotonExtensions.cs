namespace AstroLibrary.Extensions
{
    using AstroLibrary.Utility;
    using System.Collections.Generic;

    public static class PhotonExtensions
    {
        public static string GetUsername(this Photon.Realtime.Player player)
        {
            if (player.GetRawHashtable().ContainsKey("user"))
                if (player.GetHashtable()["user"] is Dictionary<string, object> dict)
                    return (string)dict["username"];
            return string.Empty;
        }

        public static string GetUserID(this Photon.Realtime.Player player)
        {
            if (player.GetRawHashtable().ContainsKey("user"))
                if (player.GetHashtable()["user"] is Dictionary<string, object> dict)
                    return (string)dict["id"];
            return string.Empty;
        }

        public static string GetDisplayName(this Photon.Realtime.Player player)
        {
            if (player.GetRawHashtable().ContainsKey("user"))
                if (player.GetHashtable()["user"] is Dictionary<string, object> dict)
                    return (string)dict["displayName"];
            return string.Empty;
        }

        public static int GetPhotonID(this Photon.Realtime.Player player)
            => player.field_Private_Int32_0;

        public static VRC.Player GetPlayer(this Photon.Realtime.Player player)
            => player.field_Public_Player_0;

        public static System.Collections.Hashtable GetHashtable(this Photon.Realtime.Player player)
            => MiscUtils_Old.Serialization.FromIL2CPPToManaged<System.Collections.Hashtable>(player.GetRawHashtable());

        public static Il2CppSystem.Collections.Hashtable GetRawHashtable(this Photon.Realtime.Player player)
            => player.prop_Hashtable_0;

        public static List<Photon.Realtime.Player> GetAllPhotonPlayers(this Photon.Realtime.LoadBalancingClient Instance)
        {
            List<Photon.Realtime.Player> result = new List<Photon.Realtime.Player>();
            foreach (var x in Instance.prop_Player_0.prop_Room_0.field_Private_Dictionary_2_Int32_Player_0)
                result.Add(x.Value);
            return result;
        }

        public static Photon.Realtime.Player GetPhotonPlayer(this Photon.Realtime.LoadBalancingClient Instance, int photonID)
        {
            foreach (var x in Instance.GetAllPhotonPlayers())
                if (x.GetPhotonID() == photonID)
                    return x;
            return null;
        }
    }
}