namespace AstroClient
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Submenus;
    using AstroLibrary.Extensions;
    using UnityEngine;

    public class Forces
    {
        // TODO: Get rid of these two , lazy rn.
        public static float Force
        {
            get
            {
                return ForcesSubmenu.Force;
            }
        }

        public static float SpinForce
        {
            get
            {
                return ForcesSubmenu.SpinForce;
            }
        }

        public static void ApplyBackwardsForce(GameObject obj, bool TakeOwnership = true)
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

        public static void ApplyForce(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
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

        public static void ApplyFowardForce(GameObject obj, bool TakeOwnership = true)
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

        public static void ApplyLeftForce(GameObject obj, bool TakeOwnership = true)
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

        public static void ApplyRelativeForce(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
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

        public static void ApplyRightForce(GameObject obj, bool TakeOwnership = true)
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

        public static void PullObject(GameObject obj, bool TakeOwnership = true)
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

        public static void PushObject(GameObject obj, bool TakeOwnership = true)
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

        public static void RemoveAllObjConstraints(GameObject obj)
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

        public static void RemoveConstraint(GameObject obj, RigidbodyConstraints constraint)
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

        public static void RemoveForces(GameObject obj, bool TakeOwnership = true)
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

        public static void SpinObject(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
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

        public static void SpinObjectX(GameObject obj, bool TakeOwnership = true)
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

        public static void SpinObjectY(GameObject obj, bool TakeOwnership = true)
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

        public static void SpinObjectZ(GameObject obj, bool TakeOwnership = true)
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