namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	public class OnlineEditor
    {


		public static void TakeObjectOwnership(GameObject obj)
		{
			Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, obj);
		}

		public static void RemoveOwnerShip(GameObject obj)
		{
			Networking.SetOwner(Get_instance_master(), obj);
		}

		public static bool IsLocalPlayerOwner(GameObject obj)
		{
			return Networking.IsOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, obj);
		}

		public static void ReturnObjectOwner(GameObject obj)
		{
			ModConsole.Warning("Current Owner : " + Networking.GetOwner(obj).displayName);
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
    }
}