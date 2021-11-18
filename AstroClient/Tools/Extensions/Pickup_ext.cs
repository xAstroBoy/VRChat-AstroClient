﻿namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools;
    using Components_exts;
    using UnityEngine;
    using xAstroBoy.Utility;

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