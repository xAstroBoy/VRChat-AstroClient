namespace AstroClient
{
	using AstroLibrary.Console;
	using DayClientML2.Utility.Extensions;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	public class OnlineEditor
    {
        public static void TakeObjectOwnership(GameObject obj)
        {
            try
            {
                if (LocalPlayerAPI != null)
                {
                    if (!IsLocalPlayerOwner(obj))
                    {
                        Networking.SetOwner(LocalPlayerAPI, obj);
                    }
                }
            }
            catch { }
        }

        public static void RemoveOwnerShip(GameObject obj)
        {
            Networking.SetOwner(Get_instance_master(), obj);
        }

        private static VRCPlayerApi Get_instance_master()
        {
            return WorldUtils.Get_Players()
                .ToArray()
                .ToList()
                .Where(x => x.GetIsMaster())
                .Select(x2 => x2.GetVRCPlayerApi())
                .FirstOrDefault(null);
        }

        public static bool IsLocalPlayerOwner(GameObject obj)
        {
            if (LocalPlayerAPI != null)
            {
                return LocalPlayerAPI.IsOwner(obj);
            }
            return false;
        }

        public static void ReturnObjectOwner(GameObject obj)
        {
            ModConsole.Warning("Current Owner : " + Networking.GetOwner(obj).displayName);
        }

        private static VRCPlayerApi _LocalPlayerAPI;

        public static VRCPlayerApi LocalPlayerAPI
        {
            get
            {
                if (_LocalPlayerAPI == null)
                {
                    var api = Player.prop_Player_0.field_Private_VRCPlayerApi_0;
                    if (api != null)
                    {
                        return _LocalPlayerAPI = api;
                    }
                }
                else
                {
                    return _LocalPlayerAPI;
                }
                return null;
            }
        }
    }
}