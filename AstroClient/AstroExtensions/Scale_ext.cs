﻿namespace AstroClient.Extensions
{
	using UnityEngine;

	public static class Scale_ext
	{
		public static void IncreaseHoldItemScale(this GameObject obj)
		{
			if (obj != null)
			{
				ObjectMiscOptions.IncreaseHoldItemScale(obj);
			}
		}

		public static void RestoreOriginalScaleItem(this GameObject obj)
		{
			if (obj != null)
			{
				ObjectMiscOptions.RestoreOriginalScaleItem(obj);
			}
		}

		public static void DecreaseHoldItemScale(this GameObject obj)
		{
			if (obj != null)
			{
				ObjectMiscOptions.DecreaseHoldItemScale(obj);
			}
		}
	}
}