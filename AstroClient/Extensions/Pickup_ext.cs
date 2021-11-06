namespace AstroLibrary.Extensions
{
    using System.Collections.Generic;
    using AstroClient.AstroMonos.Components.Tools;
    using AstroLibrary.Utility;
    using UnityEngine;

    internal static class Pickup_ext
    {
        internal static void Pickup_AllowOnlySelfToGrab(this GameObject obj, bool AllowOnlySelfToGrab)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_AllowOnlySelfToGrab(AllowOnlySelfToGrab);
        }

        internal static void Pickup_AllowOnlySelfToGrab(this List<GameObject> items, bool AllowOnlySelfToGrab)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_AllowOnlySelfToGrab(AllowOnlySelfToGrab);
                }
            }
        }

    }
}