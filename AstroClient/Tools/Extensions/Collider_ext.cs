namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using ObjectEditor.Editor.Colliders;
    using UnityEngine;

    internal static class Collider_ext
    {
        internal static void AddCollider(this GameObject obj)
        {
            if (obj != null)
            {
                ColliderEditors.AddCollider(obj);
            }
        }

        internal static void AddTriggerCollider(this GameObject obj)
        {
            if (obj != null)
            {
                ColliderEditors.AddTriggerCollider(obj);
            }
        }

        internal static void RemoveColliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponents<Collider>())
                {
                    Object.DestroyImmediate(c);
                }
            }
        }

        internal static void RemoveAllColliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    Object.DestroyImmediate(c);
                }
            }
        }

        internal static void Disablecollider(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponents<Collider>())
                {
                    c.enabled = false;
                }
            }
        }

        internal static void Set_Colliders_isTrigger(this GameObject obj, bool isTrigger)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponents<Collider>())
                {
                    c.isTrigger = isTrigger;
                }
            }
        }


        internal static void DisableAllColliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    c.enabled = false;
                }
            }
        }

        internal static void EnableColliders(this GameObject obj)
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

        internal static void RegisterCustomCollider(this GameObject obj, bool HasColliderAdded)
        {
            if (obj != null)
            {
                ColliderEditors.CustomColliderHasBeenAdded(obj, HasColliderAdded);
            }
        }

        internal static void AddBoxCollider(this List<GameObject> list, Vector3 size)
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