namespace AstroLibrary.Extensions
{
    using System.Collections.Generic;
    using AstroClient.AstroMonos.Components.Custom.Random;
    using UnityEngine;
    using Utility;

    internal static class BouncerExtensions
    {
        internal static void Set_Bouncer(this Bouncer instance, bool BounceTowardPlayer = false)
        {
            if (instance != null)
            {
                instance.BounceTowardPlayer = BounceTowardPlayer;
            }
        }

        internal static void Remove_Bouncer(this Bouncer instance)
        {
            if (instance != null)
            {
                instance.DestroyMeLocal();
            }
        }

        internal static void Add_Bouncer(this GameObject obj, bool BounceTowardPlayer = false)
        {
            if (obj != null)
            {
                obj.GetOrAddComponent<Bouncer>().Set_Bouncer(BounceTowardPlayer);
            }
        }

        internal static void Remove_Bouncer(this GameObject obj)
        {
            if (obj != null)
            {
                var bouncer = obj.GetComponent<Bouncer>();
                if (bouncer != null)
                {
                    bouncer.Remove_Bouncer();
                }
            }
        }

        internal static void Add_Bouncer(this List<GameObject> items, bool BounceTowardPlayer = false)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.Add_Bouncer(BounceTowardPlayer);
                }
            }
        }

        internal static void Remove_Bouncer(this List<GameObject> items)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.Remove_Bouncer();
                }
            }
        }
    }
}