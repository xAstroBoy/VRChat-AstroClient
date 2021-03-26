using UnityEngine;

namespace AstroClient.extensions
{
    public static class OnlineExtensions
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