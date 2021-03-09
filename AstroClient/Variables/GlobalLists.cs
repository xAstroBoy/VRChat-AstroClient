using System.Collections.Generic;
using UnityEngine;

namespace AstroClient.variables
{
    public class GlobalLists
    {
        public static List<GameObject> ClonedObjects = new List<GameObject>();
        public static List<Renderer> RenderObjects = new List<Renderer>();

        public static void OnLevelLoad()
        {
            ClonedObjects.Clear();
            RenderObjects.Clear();
        }
    }
}