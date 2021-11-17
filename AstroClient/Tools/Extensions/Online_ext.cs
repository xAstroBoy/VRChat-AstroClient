namespace AstroClient.Tools.Extensions
{
    using ObjectEditor.Online;
    using UnityEngine;

    internal static class Online_ext
    {
        /// <summary>
        /// Returns True if already owned otherwise tries to take ownership and returns the result of the attempt
        /// </summary>
        internal static bool TryTakeOwnership(this GameObject obj)
        {
            if (obj.IsOwner()) return true;
            OnlineEditor.TakeObjectOwnership(obj);
            return obj.IsOwner();
        }

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