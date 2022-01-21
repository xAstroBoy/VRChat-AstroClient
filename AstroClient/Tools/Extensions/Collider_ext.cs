namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using ObjectEditor.Editor.Colliders;
    using UnityEngine;
    using xAstroBoy.Utility;

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
        internal static void IgnoreLocalPlayerCollision(this Collider obj, bool ignore = true)
        {
            var localcollider = GameInstances.LocalPlayer.gameObject.GetComponent<Collider>();
            if (localcollider != null)
            {

                if (ignore)
                {
                    ModConsole.DebugLog($"Fixing Collider {obj.name} To ignore Current Player Collisions");
                }
                else
                {
                    ModConsole.DebugLog($"Fixing Collider {obj.name} To Interact Current Player Collisions");

                }

                Physics.IgnoreCollision(obj, localcollider, ignore);
            }
            else
            {
                ModConsole.DebugLog("Unable to Fix Player collision as Local Collider is null!");
            }

        }

        internal static void IgnoreLocalPlayerCollision(this GameObject obj, bool ignore = true)
        {
            var localcollider = GameInstances.LocalPlayer.gameObject.GetComponent<Collider>();
            if (localcollider != null)
            {

                var colliders = obj.GetComponentsInChildren<Collider>(true);
                if (ignore)
                {
                    ModConsole.DebugLog($"Fixing {colliders.Count} Colliders {obj.name} To ignore Current Player Collisions");
                }
                else
                {
                    ModConsole.DebugLog($"Fixing {colliders.Count} Colliders {obj.name} To Interact Current Player Collisions");

                }

                foreach (var c in colliders)
                {
                    Physics.IgnoreCollision(c, localcollider, ignore);
                }
            }
            else
            {
                ModConsole.DebugLog("Unable to Fix Player collision as Local Collider is null!");
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