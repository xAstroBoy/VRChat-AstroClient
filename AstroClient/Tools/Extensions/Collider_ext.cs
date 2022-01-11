﻿namespace AstroClient.Tools.Extensions
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
                var colliders = obj.GetComponents<Collider>();
                ModConsole.DebugLog($"Destroyed {colliders.Count} Colliders in {obj.name}");

                foreach (var c in colliders)
                {
                    Object.DestroyImmediate(c);
                }
            }
        }

        internal static void RemoveAllColliders(this GameObject obj)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponentsInChildren<Collider>(true);
                ModConsole.DebugLog($"Destroyed {colliders.Count} Colliders in {obj.name}");
                foreach (var c in colliders)
                {
                    Object.DestroyImmediate(c);
                }
            }
        }

        internal static void Disablecollider(this GameObject obj)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponents<Collider>();
                ModConsole.DebugLog($"Disabled {colliders.Count} Colliders in {obj.name}");

                foreach (var c in colliders)
                {
                    c.enabled = false;
                }
            }
        }

        internal static void Set_Colliders_isTrigger(this GameObject obj, bool isTrigger)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponents<Collider>();
                ModConsole.DebugLog($"set IsTrigger {isTrigger} to {colliders.Count} Colliders in {obj.name}");

                foreach (var c in colliders)

                {
                    c.isTrigger = isTrigger;
                }
            }
        }

        internal static void DisableAllColliders(this GameObject obj)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponentsInChildren<Collider>(true);
                ModConsole.DebugLog($"Disabled {colliders.Count} Colliders in {obj.name}");

                foreach (var c in colliders)

                {
                    c.enabled = false;
                }
            }
        }

        internal static void EnableColliders(this GameObject obj)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponentsInChildren<Collider>(true);
                ModConsole.DebugLog($"Enabled {colliders.Count} Colliders in {obj.name}");

                foreach (var c in colliders)

                {
                    c.enabled = true;
                }

                var meshcolliders = obj.GetComponentsInChildren<MeshCollider>(true);
                ModConsole.DebugLog($"Enabled {colliders.Count} MeshColliders in {obj.name}");
                foreach (var c in meshcolliders)
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