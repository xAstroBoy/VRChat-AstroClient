﻿namespace AstroLibrary.Extensions
{
    using AstroClient.Components;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using UnityEngine;

    public static class RigidBodyControllerExtensions
    {
        public static void RigidBody_RestoreOriginalBody(this RigidBodyController control)
        {
            if (control != null)
            {
                control.RestoreOriginalBody();
            }
        }

        public static void RigidBody_Set_Gravity(this RigidBodyController control, bool useGravity)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.useGravity = useGravity;
            }
        }

        public static void RigidBody_Set_DetectCollisions(this RigidBodyController control, bool DetectCollisions)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.detectCollisions = DetectCollisions;
            }
        }

        public static void RigidBody_Set_isKinematic(this RigidBodyController control, bool isKinematic)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.isKinematic = isKinematic;
            }
        }

        public static void RigidBody_Remove_Constraint(this RigidBodyController control, RigidbodyConstraints constraint)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                if (control.constraints.HasFlag(constraint))
                {
                    control.constraints &= ~constraint;
                }
            }
        }

        public static void RigidBody_Remove_All_Constraints(this RigidBodyController control)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.constraints = RigidbodyConstraints.None;
            }
        }

        public static void RigidBody_Add_Constraint(this RigidBodyController control, RigidbodyConstraints constraint)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.constraints |= constraint;
            }
        }

        public static void RigidBody_PreventOthersFromGrabbing(this RigidBodyController control, bool PreventOthersFromGrabbing)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.PreventOthersFromGrabbing = PreventOthersFromGrabbing;
            }
        }

        public static bool RigidBody_Will_It_fall_throught(this RigidBodyController control)
        {
            if (control != null)
            {
                var meshcolliders = control.gameObject.GetComponentsInChildren<MeshCollider>(true);
                if (meshcolliders.Count != 0)
                {
                    foreach (var c in meshcolliders)
                    {
                        if (c.enabled && c.convex)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    var Colliders = control.gameObject.GetComponentsInChildren<Collider>(true);
                    if (Colliders.Count != 0)
                    {
                        foreach (var collider in Colliders)
                        {
                            if (collider != null)
                            {
                                if (!collider.isTrigger && collider.enabled)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static void RigidBody_RestoreOriginalBody(this GameObject obj)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_RestoreOriginalBody();
        }

        public static void RigidBody_Set_Gravity(this GameObject obj, bool useGravity)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_Set_Gravity(useGravity);
        }

        public static void RigidBody_Set_DetectCollisions(this GameObject obj, bool DetectCollisions)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_Set_DetectCollisions(DetectCollisions);
        }

        public static void RigidBody_Set_isKinematic(this GameObject obj, bool isKinematic)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_Set_isKinematic(isKinematic);
        }

        public static void RigidBody_Remove_Constraint(this GameObject obj, RigidbodyConstraints constraint)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_Remove_Constraint(constraint);
        }

        public static void RigidBody_Remove_All_Constraints(this GameObject obj)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_Remove_All_Constraints();
        }

        public static void RigidBody_Add_Constraint(this GameObject obj, RigidbodyConstraints constraint)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_Add_Constraint(constraint);
        }

        public static void RigidBody_PreventOthersFromGrabbing(this GameObject obj, bool PreventOthersFromGrabbing)
        {
            obj.GetOrAddComponent<RigidBodyController>().RigidBody_PreventOthersFromGrabbing(PreventOthersFromGrabbing);
        }

        public static bool RigidBody_Will_It_fall_throught(this GameObject obj)
        {
            return obj.GetOrAddComponent<RigidBodyController>().RigidBody_Will_It_fall_throught();
        }

        public static void RigidBody_RestoreOriginalBody(this List<GameObject> items)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.RigidBody_RestoreOriginalBody();
                }
            }
        }

        public static void RigidBody_Set_Gravity(this List<GameObject> items, bool useGravity)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.RigidBody_Set_Gravity(useGravity);
                }
            }
        }

        public static void RigidBody_Set_DetectCollisions(this List<GameObject> items, bool DetectCollisions)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.RigidBody_Set_DetectCollisions(DetectCollisions);
                }
            }
        }

        public static void RigidBody_Set_isKinematic(this List<GameObject> items, bool isKinematic)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.RigidBody_Set_isKinematic(isKinematic);
                }
            }
        }

        public static void RigidBody_Remove_Constraint(this List<GameObject> items, RigidbodyConstraints constraint)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.RigidBody_Remove_Constraint(constraint);
                }
            }
        }

        public static void RigidBody_Remove_All_Constraints(this List<GameObject> items)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.RigidBody_Remove_All_Constraints();
                }
            }
        }

        public static void RigidBody_Add_Constraint(this List<GameObject> items, RigidbodyConstraints constraint)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.RigidBody_Add_Constraint(constraint);
                }
            }
        }

        public static void RigidBody_PreventOthersFromGrabbing(this List<GameObject> items, bool PreventOthersFromGrabbing)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<RigidBodyController>().RigidBody_PreventOthersFromGrabbing(PreventOthersFromGrabbing);
                }
            }

        }

        public static void RigidBody_Set_Drag(this RigidBodyController control, float Drag)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.drag = Drag;
            }
        }

        public static void RigidBody_Set_AngularDrag(this RigidBodyController control, float AngularDrag)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.angularDrag = AngularDrag;
            }
        }


        public static void RigidBody_Forced(this RigidBodyController control, bool Forced_RigidBody)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.Forced_Rigidbody = Forced_RigidBody;
            }
        }



    }
}