using System.Collections.Generic;
using UnityEngine;

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

        public static void AddTriggerCollider(this GameObject obj)
        {
            if (obj != null)
            {
                ColliderEditors.AddTriggerCollider(obj);
            }
        }

        public static void removeColliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponents<Collider>())
                {
                    UnityEngine.Object.DestroyImmediate(c);
                }
            }
        }

        public static void removeAllCollider(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    UnityEngine.Object.DestroyImmediate(c);
                }
            }
        }

        public static void disablecollider(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponents<Collider>())
                {
                    c.enabled = false;
                }
            }
        }

        public static void DisableAllColliders(this GameObject obj)
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