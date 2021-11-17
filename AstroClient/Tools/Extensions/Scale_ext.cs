namespace AstroClient.Tools.Extensions
{
    using ClientUI.Menu.ItemTweakerV2.Submenus.Scale;
    using UnityEngine;

    internal static class Scale_ext
    {
        internal static void IncreaseHoldItemScale(this GameObject obj)
        {
            if (obj != null)
            {
                ScaleSubmenu.IncreaseHoldItemScale(obj);
            }
        }

        internal static void RestoreOriginalScaleItem(this GameObject obj)
        {
            if (obj != null)
            {
                ScaleSubmenu.RestoreOriginalScaleItem(obj);
            }
        }

        internal static void DecreaseHoldItemScale(this GameObject obj)
        {
            if (obj != null)
            {
                ScaleSubmenu.DecreaseHoldItemScale(obj);
            }
        }
    }
}