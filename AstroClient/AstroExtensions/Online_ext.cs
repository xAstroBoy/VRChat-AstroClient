namespace AstroClient.Extensions
{
	using UnityEngine;

	public static class Online_ext
	{
		public static void ClaimOwnership(this GameObject obj)
		{
			OnlineEditor.TakeObjectOwnership(obj);
		}

		public static void DropOwnership(this GameObject obj)
		{
			OnlineEditor.RemoveOwnerShip(obj);
		}

		public static bool TakeOwnershipIfNeccesary(this GameObject obj)
		{
			return OnlineEditor.TakeOwnershipIfNeccessary(obj);
		}
	}
}