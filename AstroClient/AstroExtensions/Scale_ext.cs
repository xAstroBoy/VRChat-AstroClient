namespace AstroClient.Extensions
{
	using AstroClient.ItemTweakerV2.Submenus;
	using UnityEngine;

	public static class Scale_ext
    {
        public static void IncreaseHoldItemScale(this GameObject obj)
        {
            if (obj != null)
            {
                ScaleSubmenu.IncreaseHoldItemScale(obj);
            }
        }

        public static void RestoreOriginalScaleItem(this GameObject obj)
        {
            if (obj != null)
            {
                ScaleSubmenu.RestoreOriginalScaleItem(obj);
            }
        }

        public static void DecreaseHoldItemScale(this GameObject obj)
        {
            if (obj != null)
            {
                ScaleSubmenu.DecreaseHoldItemScale(obj);
            }
        }
    }
}