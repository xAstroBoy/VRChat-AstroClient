namespace AstroClient.Tools.Extensions.Components_exts
{
    using System.Collections.Generic;
    using AstroMonos.Components.Custom.Random;
    using AstroMonos.Components.Tools.FreezeLocation;
    using UnityEngine;
    using xAstroBoy.Utility;

    internal static class ObjectFreezerExtensions
    {

        internal static void Remove_ObjectFreezer(this ObjectFreezer instance)
        {
            if (instance != null)
            {
                instance.DestroyMeLocal();
            }
        }

        internal static ObjectFreezer Add_ObjectFreezer(this GameObject obj)
        {
            if (obj != null)
            {
               return obj.GetOrAddComponent<ObjectFreezer>();
            }

            return null;
        }

        internal static void Remove_ObjectFreezer(this GameObject obj)
        {
            if (obj != null)
            {
                var Freeze = obj.GetComponent<ObjectFreezer>();
                if (Freeze != null)
                {
                    Freeze.Remove_ObjectFreezer();
                }
            }
        }

        internal static void Add_ObjectFreezer(this List<GameObject> items)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.Add_ObjectFreezer();
                }
            }
        }

        internal static void Remove_ObjectFreezer(this List<GameObject> items)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.Remove_ObjectFreezer();
                }
            }
        }
    }
}