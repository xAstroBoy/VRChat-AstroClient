using RubyButtonAPI;
using UnityEngine;

#region AstroClient Imports

using AstroClient.components;
using AstroClient.AstroUtils.ItemTweaker;

#endregion AstroClient Imports

namespace AstroClient
{
    public class Forces
    {
        public static QMToggleButton Constraint_Rot_X_Toggle;
        public static QMToggleButton Constraint_Rot_Y_Toggle;
        public static QMToggleButton Constraint_Rot_Z_Toggle;

        public static QMToggleButton Constraint_X_Toggle;
        public static QMToggleButton Constraint_Y_Toggle;
        public static QMToggleButton Constraint_Z_Toggle;

        public static readonly float DefaultForce = 1f;
        public static readonly float DefaultSpinForce = 100f;
        private static bool _TakeOwnership;

        public static bool TakeOwnership
        {
            get
            {
                return _TakeOwnership;
            }
            set
            {
                _TakeOwnership = value;
                if (Forces.TakeOwnerShipToggle != null)
                {
                    TakeOwnerShipToggle.setToggleState(value);
                }
            }
        }

        public static QMSingleButton ForceAmnt1;

        public static QMSingleButton ForceAmnt2;
        public static QMSingleButton SpinForceAmnt1;
        public static QMSingleButton SpinForceAmnt2;

        public static QMSingleToggleButton TakeOwnerShipToggle;

        public static void AddConstraint(GameObject obj, RigidbodyConstraints constraint)
        {

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

        public static void OnLevelLoad()
        {
            Update_Constraint_X_Toggle(false);
            Update_Constraint_Y_Toggle(false);
            Update_Constraint_Z_Toggle(false);
            Update_Constraint_Rot_X_Toggle(false);
            Update_Constraint_Rot_Y_Toggle(false);
            Update_Constraint_Rot_Z_Toggle(false);
            TakeOwnership = false;
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

        public static void ResetForcesVar()
        {
            Force = DefaultForce;
            UpdateForceAmountBtns();
        }

        public static void ResetSpinForcesVar()
        {
            SpinForce = DefaultSpinForce;
            UpdateForceAmountBtns();
        }

        public static void SetForceAmount(int val)
        {
            Force = val;
            UpdateForceAmountBtns();
        }

        public static void SetSpinForceAmount(int val)
        {
            SpinForce = val;
            UpdateForceAmountBtns();
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

        public static void Update_Constraint_Rot_X_Toggle(bool status)
        {
            if (Constraint_Rot_X_Toggle != null) { Constraint_Rot_X_Toggle.setToggleState(status); }
        }

        public static void Update_Constraint_Rot_Y_Toggle(bool status)
        {
            if (Constraint_Rot_Y_Toggle != null) { Constraint_Rot_Y_Toggle.setToggleState(status); }
        }

        public static void Update_Constraint_Rot_Z_Toggle(bool status)
        {
            if (Constraint_Rot_Z_Toggle != null) { Constraint_Rot_Z_Toggle.setToggleState(status); }
        }

        public static void Update_Constraint_X_Toggle(bool status)
        {
            if (Constraint_X_Toggle != null) { Constraint_X_Toggle.setToggleState(status); }
        }

        public static void Update_Constraint_Y_Toggle(bool status)
        {
            if (Constraint_Y_Toggle != null) { Constraint_Y_Toggle.setToggleState(status); }
        }

        public static void Update_Constraint_Z_Toggle(bool status)
        {
            if (Constraint_Z_Toggle != null) { Constraint_Z_Toggle.setToggleState(status); }
        }

        public static void UpdateForceAmountBtns()
        {
            if (ForceAmnt1 != null)
            {
                ForceAmnt1.setButtonText("Force : " + Force.ToString());
            }
            if (ForceAmnt2 != null)
            {
                ForceAmnt2.setButtonText("Force : " + Force.ToString());
            }
            if (SpinForceAmnt1 != null)
            {
                SpinForceAmnt1.setButtonText("Spin Force : " + SpinForce.ToString());
            }
            if (SpinForceAmnt2 != null)
            {
                SpinForceAmnt2.setButtonText("Spin Force : " + SpinForce.ToString());
            }

            if (ItemTweakerMain.SpinForceSlider != null)
            {
                ItemTweakerMain.SpinForceSlider.SetValue(SpinForce);
            }

            if (ItemTweakerMain.ForceSlider != null)
            {
                ItemTweakerMain.ForceSlider.SetValue(Force);
            }
        }

        public static bool UpdateFreezeAllConstraints(RigidbodyConstraints constraints)
        {
            if (constraints.HasFlag(RigidbodyConstraints.FreezeAll))
            {
                Update_Constraint_X_Toggle(true);
                Update_Constraint_Y_Toggle(true);
                Update_Constraint_Z_Toggle(true);
                Update_Constraint_Rot_X_Toggle(true);
                Update_Constraint_Rot_Y_Toggle(true);
                Update_Constraint_Rot_Z_Toggle(true);
                return true;
            }
            return false;
        }

        public static void UpdatePositionConstraints(RigidbodyConstraints constraints)
        {
            if (constraints.HasFlag(RigidbodyConstraints.FreezeAll))
            {
                return;
            }

            if (constraints.HasFlag(RigidbodyConstraints.FreezePosition))
            {
                Update_Constraint_X_Toggle(true);
                Update_Constraint_Y_Toggle(true);
                Update_Constraint_Z_Toggle(true);
            }
            else
            {
                Update_Constraint_X_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezePositionX));
                Update_Constraint_Y_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezePositionY));
                Update_Constraint_Z_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezePositionZ));
            }
        }

        public static void UpdateRotationSection(RigidbodyConstraints constraints)
        {
            if (constraints.HasFlag(RigidbodyConstraints.FreezeAll))
            {
                return;
            }
            if (constraints.HasFlag(RigidbodyConstraints.FreezeRotation))
            {
                Update_Constraint_Rot_X_Toggle(true);
                Update_Constraint_Rot_Y_Toggle(true);
                Update_Constraint_Rot_Z_Toggle(true);
            }
            else
            {
                Update_Constraint_Rot_X_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezeRotationX));
                Update_Constraint_Rot_Y_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezeRotationY));
                Update_Constraint_Rot_Z_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezeRotationZ));
            }
        }

        public static float Force = DefaultForce;
        public static float SpinForce = DefaultSpinForce;
    }
}