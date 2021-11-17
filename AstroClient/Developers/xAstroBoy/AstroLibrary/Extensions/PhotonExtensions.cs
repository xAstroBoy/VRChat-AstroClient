namespace AstroClient.xAstroBoy.Extensions
{
    using CheetoLibrary.Misc;
    using Utility;

    public static class PhotonExtensions
    {
        public static int GetPhotonID(this Photon.Realtime.Player player) => player.field_Private_Int32_0;

        public static VRC.Player GetVRCPlayer(this Photon.Realtime.Player player) => player.field_Public_Player_0;

        public static System.Collections.Hashtable GetHashtable(this Photon.Realtime.Player player) => MiscUtils_Old.Serialization.FromIL2CPPToManaged<System.Collections.Hashtable>(player.GetRawHashtable());

        public static Il2CppSystem.Collections.Hashtable GetRawHashtable(this Photon.Realtime.Player player) => player.prop_Hashtable_0;
    }
}