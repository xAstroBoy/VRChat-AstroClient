using System.Collections.Generic;
using UnityEngine;

#region AstroClient Imports

using AstroClient.AstroUtils.ItemTweaker;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
    public static class ItemTweakerExtensions
    {
        public static void AddToWorldUtilsMenu(this GameObject obj)
        {
            if (obj != null)
            {
                ItemTweakerMain.AddToWorldUtilsMenu(obj);
            }
        }

        public static void AddToWorldUtilsMenu(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemTweakerMain.AddToWorldUtilsMenu(obj);
                }
            }
        }
    }
}