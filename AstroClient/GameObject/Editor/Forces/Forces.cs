namespace AstroClient
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Submenus;
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
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddForce(0, -Force, 0, ForceMode.Impulse);
                }
            }
        }

        public static void ApplyForce(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddForce(x, y, z, ForceMode.Impulse);
                }
            }
        }

        public static void ApplyFowardForce(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddForce(0, Force, 0, ForceMode.Impulse);
                }
            }
        }

        public static void ApplyLeftForce(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddForce(-Force, 0, 0, ForceMode.Impulse);
                }
            }
        }

        public static void ApplyRelativeForce(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddRelativeForce(x, y, z, ForceMode.Impulse);
                }
            }
        }

        public static void ApplyRightForce(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddForce(Force, 0, 0, ForceMode.Impulse);
                }
            }
        }

        public static void PullObject(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddForce(0, 0, -Force, ForceMode.Impulse);
                }
            }
        }

        public static void PushObject(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddForce(0, 0, Force, ForceMode.Impulse);
                }
            }
        }

        public static void RemoveAllObjConstraints(GameObject obj)
        {
            var itemedit = obj.GetComponent<RigidBodyController>();
            if (itemedit == null)
            {
                itemedit = obj.AddComponent<RigidBodyController>();
            }
            if (itemedit != null)
            {
                if (!itemedit.EditMode)
                {
                    itemedit.EditMode = true;
                }
                itemedit.Constraints = RigidbodyConstraints.None;
            }
        }

        public static void RemoveConstraint(GameObject obj, RigidbodyConstraints constraint)
        {
            var itemedit = obj.GetComponent<RigidBodyController>();
            if (itemedit == null)
            {
                itemedit = obj.AddComponent<RigidBodyController>();
            }
            if (itemedit != null)
            {
                if (itemedit.Constraints.HasFlag(constraint))
                {
                    itemedit.Constraints &= ~constraint;
                }
            }
        }

        public static void RemoveForces(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.velocity = Vector3.zero;
                    body.angularVelocity = Vector3.zero;
                }
            }
        }

        public static void SpinObject(GameObject obj, float x, float y, float z, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddRelativeTorque(x, y, z, ForceMode.Force);
                }
            }
        }

        public static void SpinObjectX(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    body.AddRelativeTorque(SpinForce, 0, 0, ForceMode.Force);
                }
            }
        }

        public static void SpinObjectY(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddRelativeTorque(0, SpinForce, 0, ForceMode.Force);
                }
            }
        }

        public static void SpinObjectZ(GameObject obj, bool TakeOwnership = true)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    if (TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    body.AddRelativeTorque(0, 0, SpinForce, ForceMode.Force);
                }
            }
        }
    }
}