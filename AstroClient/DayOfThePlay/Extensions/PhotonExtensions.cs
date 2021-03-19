using System.Collections.Generic;

namespace DayClientML2.Utility.Extensions
{
    public static class PhotonExtensions
    {
        public static string GetUsername(this Photon.Realtime.Player player)
        {
            if (player.prop_Hashtable_0.ContainsKey("user"))
                if (MiscUtility.Serialization.FromIL2CPPToManaged<object>(player.prop_Hashtable_0["user"]) is Dictionary<string, object> dict)
                    return (string)dict["username"];
            return "No DisplayName";
        }

        public static string GetDisplayName(this Photon.Realtime.Player player)
        {
            if (player.prop_Hashtable_0.ContainsKey("user"))
                if (MiscUtility.Serialization.FromIL2CPPToManaged<object>(player.prop_Hashtable_0["user"]) is Dictionary<string, object> dict)
                    return (string)dict["displayName"];
            return "No DisplayName";
        }
    }
}