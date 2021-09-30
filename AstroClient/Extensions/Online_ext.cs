namespace AstroLibrary.Extensions
{
    using AstroClient;
    using UnityEngine;

    internal static class Online_ext
    {
        internal static void TakeOwnership(this GameObject obj)
        {
            OnlineEditor.TakeObjectOwnership(obj);
        }

        internal static void DropOwnership(this GameObject obj)
        {
            OnlineEditor.RemoveOwnerShip(obj);
        }

        internal static bool IsOwner(this GameObject obj)
        {
            return OnlineEditor.IsLocalPlayerOwner(obj);
        }
    }
}