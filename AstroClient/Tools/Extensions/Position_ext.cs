using VRC.SDKBase;

namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using ObjectEditor.Editor.Position;
    using Target;
    using UnityEngine;

    internal static class Position_ext
    {
        internal static void TeleportTo(this VRCPlayerApi obj, Vector3 position, Quaternion rotation)
        {
            if (obj != null)
            {
                obj.gameObject.transform.position = position;
                obj.gameObject.transform.rotation = rotation;
            }
        }
        internal static void TeleportTo(this VRCPlayerApi obj, Vector3 position, Vector3 rotation)
        {
            if (obj != null)
            {
                obj.gameObject.transform.position = position;
                obj.gameObject.transform.rotation = Quaternion.Euler(rotation);
            }
        }

        internal static void TeleportTo(this VRCPlayerApi obj, GameObject target, bool useRotation = true)
        {
            if (obj != null)
            {
                obj.TeleportTo(target, useRotation);
            }
        }

        internal static void TeleportTo(this VRCPlayerApi obj, Transform target, bool useRotation = true)
        {
            if (obj != null)
            {
                obj.gameObject.transform.position = target.position;
                if (useRotation)
                {
                    obj.gameObject.transform.rotation = target.rotation;
                }
            }
        }

        internal static void TeleportToTarget(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj, TargetSelector.CurrentTarget, HumanBodyBones.Chest, true);
                }
            }
        }

        internal static void TeleportToMe(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj);
                }
            }
        }

        internal static void TeleportToTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, TargetSelector.CurrentTarget, HumanBodyBones.Chest, true);
            }
        }

        internal static void TeleportToMe(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj);
            }
        }
        internal static void SetPosition(this GameObject obj, Vector3 position, bool TakeOwnership = false)
        {
            if (obj != null)
            {
                ItemPosition.SetPosition(obj, position, TakeOwnership);
            }
        }
        internal static void SetRotation(this GameObject obj, Quaternion rotation, bool TakeOwnership = false)
        {
            if (obj != null)
            {
                ItemPosition.SetRotation(obj, rotation, TakeOwnership);
            }
        }
        internal static void SetRotation(this GameObject obj, Vector3 rotation, bool TakeOwnership = false)
        {
            if (obj != null)
            {
                ItemPosition.SetRotation(obj, rotation, TakeOwnership);
            }
        }


        internal static void TeleportToMe(this GameObject obj, bool ResetRigidBody = false, bool ResetPickupProperties = false)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, ResetRigidBody, ResetPickupProperties);
            }
        }


        internal static void TeleportToMeWithRot(this GameObject obj, HumanBodyBones bone, bool KillcustomScripts = true, bool KillForces = true)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObjectWithRot(obj, bone, KillcustomScripts, KillForces);
            }
        }

        internal static void TeleportToMe(this GameObject obj, HumanBodyBones bone, bool KillcustomScripts = true, bool KillForces = true)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, bone, KillcustomScripts, KillForces);
            }
        }
    }
}