﻿namespace AstroClient.Extensions
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
	}
}