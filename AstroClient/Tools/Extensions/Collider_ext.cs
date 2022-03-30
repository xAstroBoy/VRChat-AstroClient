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

        internal static void RemoveColliders(this GameObject obj, bool Silent = false)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponents<Collider>();
                if (!Silent)
                {
                    ModConsole.DebugLog($"Destroyed {colliders.Count} Colliders in {obj.name}");
                }

                foreach (var c in colliders)
                {
                    Object.DestroyImmediate(c);
                }
            }
        }

        internal static void RemoveAllColliders(this GameObject obj, bool Silent = true)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponentsInChildren<Collider>(true);
                if (!Silent)
                {
                    ModConsole.DebugLog($"Destroyed {colliders.Count} Colliders in {obj.name}");
                }

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

        internal static void Set_Colliders_isTrigger(this GameObject obj, bool isTrigger, bool Quiet = true)
        {
            if (obj != null)
            {
                var colliders = obj.GetComponents<Collider>();
                if (!Quiet)
                {
                    ModConsole.DebugLog($"set IsTrigger {isTrigger} to {colliders.Count} Colliders in {obj.name}");

                }
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
        internal static void IgnoreLocalPlayerCollision(this Transform obj, bool ignore = true)
        {
            var localcollider = GameInstances.LocalPlayer.gameObject.GetComponent<Collider>();
            if (localcollider != null)
            {

                var colliders = obj.GetComponents<Collider>();
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
        internal static void IgnoreObjectCollision(this GameObject obj, Transform item, bool ignore = true)
        {
            var colliders = obj.GetComponents<Collider>();
            var colliders2 = item.GetComponents<Collider>();
            foreach (var c in colliders)
            {
                foreach (var c2 in colliders2)
                {
                    Physics.IgnoreCollision(c, c2, ignore);
                }
            }

        }

        internal static void IgnoreLocalPlayerCollision(this GameObject obj, bool ignore = true, bool IncludeTriggers = true, bool Quiet = true)
        {
            var localcollider = GameInstances.LocalPlayer.gameObject.GetComponent<Collider>();
            if (localcollider != null)
            {

                var colliders = obj.GetComponents<Collider>();
                if (!Quiet)
                {
                    if (ignore)
                    {

                        ModConsole.DebugLog($"Fixing {colliders.Count} Colliders {obj.name} To ignore Current Player Collisions");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Fixing {colliders.Count} Colliders {obj.name} To Interact Current Player Collisions");

                    }
                }

                foreach (var c in colliders)
                {
                    if (c.isTrigger)
                    {
                        if (IncludeTriggers)
                        {
                            Physics.IgnoreCollision(c, localcollider, ignore);
                        }
                    }
                    else
                    {
                        Physics.IgnoreCollision(c, localcollider, ignore);
                    }
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