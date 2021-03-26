using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using AstroClient.components;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using System.Reflection;
using RubyButtonAPI;
using UnityEngine.UI;
using DayClientML2.Utility.Extensions;
using AstroClient.AstroUtils.ItemTweaker;
using static AstroClient.Forces;
using VRC.SDK3.Components;
using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports


namespace AstroClient.extensions
{
    public static class ColliderExtensions
    {
        public static void AddCollider(this GameObject obj)
        {
            if (obj != null)
            {
                ColliderEditors.AddCollider(obj);
            }
        }


        public static void removeCollider(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    UnityEngine.Object.DestroyImmediate(c);
                }
            }
        }

        public static void disablecolliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    c.enabled = false;
                }
            }
        }

        public static void enablecolliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    c.enabled = true;
                }
                foreach (var c in obj.GetComponentsInChildren<MeshCollider>(true))
                {
                    c.enabled = true;
                    c.convex = true;
                }
            }
        }


        public static void RegisterCustomCollider(this GameObject obj, bool HasColliderAdded)
        {
            if (obj != null)
            {
                ColliderEditors.CustomColliderHasBeenAdded(obj, HasColliderAdded);
            }
        }

        public static void AddBoxCollider(this List<GameObject> list, Vector3 size)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ColliderEditors.AddBoxCollider(obj, size);
                }
            }
        }



    }
}
