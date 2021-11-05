using AstroLibrary.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace AstroLibrary.Extensions
{
    using AstroClient.AstroMonos.Components.Tools;

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