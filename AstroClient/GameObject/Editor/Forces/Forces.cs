namespace AstroClient
{
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools;
    using ItemTweakerV2.Submenus;
    using UnityEngine;

    internal class Forces
    {
        // TODO: Get rid of these two , lazy rn.
        internal static float Force => ForcesSubmenu.Force;

        internal static float SpinForce => ForcesSubmenu.SpinForce;

        internal static void ApplyBackwardsForce(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddForce(0, -Force, 0, ForceMode.Impulse);
                }
            }
        }

        internal static void ApplyForce(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddForce(x, y, z, ForceMode.Impulse);
                }
            }
        }

        internal static void ApplyFowardForce(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddForce(0, Force, 0, ForceMode.Impulse);
                }
            }
        }

        internal static void ApplyLeftForce(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddForce(-Force, 0, 0, ForceMode.Impulse);
                }
            }
        }

        internal static void ApplyRelativeForce(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddRelativeForce(x, y, z, ForceMode.Impulse);
                }
            }
        }

        internal static void ApplyRightForce(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddForce(Force, 0, 0, ForceMode.Impulse);
                }
            }
        }

        internal static void PullObject(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddForce(0, 0, -Force, ForceMode.Impulse);
                }
            }
        }

        internal static void PushObject(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddForce(0, 0, Force, ForceMode.Impulse);
                }
            }
        }

        internal static void RemoveAllObjConstraints(GameObject obj)
        {
            var itemedit = obj.GetOrAddComponent<RigidBodyController>();
            if (itemedit != null)
            {
                if (!itemedit.EditMode)
                {
                    itemedit.EditMode = true;
                }
                itemedit.constraints = RigidbodyConstraints.None;
            }
        }

        internal static void RemoveConstraint(GameObject obj, RigidbodyConstraints constraint)
        {
            var itemedit = obj.GetOrAddComponent<RigidBodyController>();

            if (itemedit != null)
            {
                if (!itemedit.EditMode)
                {
                    itemedit.EditMode = true;
                }
                if (itemedit.constraints.HasFlag(constraint))
                {
                    itemedit.constraints &= ~constraint;
                }
            }
        }

        internal static void RemoveForces(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetOrAddComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    if (!bodycontroller.EditMode)
                    {
                        bodycontroller.EditMode = true;
                    }
                    bodycontroller.Rigidbody.velocity = Vector3.zero;
                    bodycontroller.Rigidbody.angularVelocity = Vector3.zero;
                }
            }
        }

        internal static void SpinObject(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddRelativeTorque(x, y, z, ForceMode.Force);
                }
            }
        }

        internal static void SpinObjectX(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    bodycontroller.Rigidbody.AddRelativeTorque(SpinForce, 0, 0, ForceMode.Force);
                }
            }
        }

        internal static void SpinObjectY(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddRelativeTorque(0, SpinForce, 0, ForceMode.Force);
                }
            }
        }

        internal static void SpinObjectZ(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var bodycontroller = obj.GetComponent<RigidBodyController>();
                if (bodycontroller.Rigidbody != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    bodycontroller.Rigidbody.AddRelativeTorque(0, 0, SpinForce, ForceMode.Force);
                }
            }
        }
    }
}