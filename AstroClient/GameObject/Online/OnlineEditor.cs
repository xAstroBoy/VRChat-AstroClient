namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System.Linq;
    using UnityEngine;
    using VRC.SDKBase;

    internal class OnlineEditor
    {
        internal static  void TakeObjectOwnership(GameObject obj)
        {
            Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, obj);
        }

        internal static  void RemoveOwnerShip(GameObject obj)
        {
            Networking.SetOwner(GetInstanceMaster(), obj);
        }

        internal static  bool IsLocalPlayerOwner(GameObject obj)
        {
            return Networking.IsOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, obj);
        }

        internal static  void ReturnObjectOwner(GameObject obj)
        {
            ModConsole.Warning($"Current Owner : {Networking.GetOwner(obj).displayName}");
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