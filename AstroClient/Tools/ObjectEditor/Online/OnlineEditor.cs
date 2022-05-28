namespace AstroClient.Tools.ObjectEditor.Online
{
    using System.Linq;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class OnlineEditor
    {
        internal static void TakeObjectOwnership(GameObject obj)
        {
            Networking.SetOwner(GameInstances.LocalPlayer, obj);
        }

        internal static void RemoveOwnerShip(GameObject obj)
        {
            Networking.SetOwner(GetInstanceMaster(), obj);
        }

        internal static bool IsLocalPlayerOwner(GameObject obj)
        {
            return Networking.IsOwner(GameInstances.LocalPlayer, obj);
        }
        internal static bool isOwner(VRC.Player player, GameObject obj)
        {
            return GetOwner(obj).Equals(player.GetVRCPlayerApi());
        }

        internal static VRCPlayerApi GetOwner(GameObject obj)
        {
            return Networking.GetOwner(obj);
        }
        internal static void ReturnObjectOwner(GameObject obj)
        {
            Log.Warn($"Current Owner : {Networking.GetOwner(obj).displayName}");
        }

        private static VRCPlayerApi GetInstanceMaster()
        {
            return WorldUtils.Players
                .Where(x => x.GetIsMaster())
                .Select(x2 => x2.GetVRCPlayerApi())
                .First();
        }
    }
}