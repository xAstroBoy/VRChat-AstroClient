namespace AstroLibrary.Extensions
{
	using AstroClient;
	using UnityEngine;

	public static class Online_ext
	{
		public static void TakeOwnership(this GameObject obj)
		{
			OnlineEditor.TakeObjectOwnership(obj);
		}

		public static void DropOwnership(this GameObject obj)
		{
			OnlineEditor.RemoveOwnerShip(obj);
		}

		public static bool isOwner(this GameObject obj)
		{
			return OnlineEditor.IsLocalPlayerOwner(obj);
		}
	}
}