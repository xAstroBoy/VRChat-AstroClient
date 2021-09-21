namespace AstroLibrary.Extensions
{
    using AstroLibrary.Utility;
    using System.Collections.Generic;

    public static class PhotonExtensions
    {
        public static string GetUsername(this Photon.Realtime.Player player)
        {
            return (player.GetRawHashtable().ContainsKey("user") && player.GetHashtable()["user"] is Dictionary<string, object> dict) ? (string)dict["username"] : string.Empty;
        }

        public static string GetUserID(this Photon.Realtime.Player player)
        {
            return (player.GetRawHashtable().ContainsKey("user") && player.GetHashtable()["user"] is Dictionary<string, object> dict) ? (string)dict["id"] : string.Empty;
        }

        public static int GetPhotonID(this Photon.Realtime.Player player) => player.field_Private_Int32_0;

        public static VRC.Player GetPlayer(this Photon.Realtime.Player player) => player.field_Public_Player_0;

        public static System.Collections.Hashtable GetHashtable(this Photon.Realtime.Player player) => MiscUtils_Old.Serialization.FromIL2CPPToManaged<System.Collections.Hashtable>(player.GetRawHashtable());

        public static Il2CppSystem.Collections.Hashtable GetRawHashtable(this Photon.Realtime.Player player) => player.prop_Hashtable_0;
    }
}