using AstroClient.ConsoleUtils;
using MelonLoader;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient
{
    public class OnlineEditor
    {
        public static void TakeObjectOwnership(GameObject obj)
        {
            Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, obj);
        }

        public static void RemoveOwnerShip(GameObject obj)
        {
            Networking.SetOwner(null, obj);
        }

        public static bool IsLocalPlayerOwner(GameObject obj)
        {
            return Networking.IsOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, obj);
        }

        public static void ReturnObjectOwner(GameObject obj)
        {
            ModConsole.Warning("Current Owner : " + Networking.GetOwner(obj).displayName);
        }
    }
}