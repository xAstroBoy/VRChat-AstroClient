using System.Collections.Generic;
using UnityEngine;

namespace AstroClient.extensions
{
    public static class EspExtensions
    {
        public static void RegisterMurderItemEsp(this GameObject obj)
        {
            if (obj != null)
            {
                if (obj != null)
                {
                    if (!GameObjectESP.MurderESPItems.Contains(obj))
                    {
                        GameObjectESP.MurderESPItems.Add(obj);
                    }
                }
            }
        }

        public static void RegisterMurderItemEsp(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    if (!GameObjectESP.MurderESPItems.Contains(obj))
                    {
                        GameObjectESP.MurderESPItems.Add(obj);
                    }
                }
            }
        }
    }
}