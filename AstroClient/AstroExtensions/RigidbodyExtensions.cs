using System.Collections.Generic;
using UnityEngine;
using AstroClient.components;

#region AstroClient Imports

using AstroClient.ConsoleUtils;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
    public static class RigidbodyExtensions
    {
        public static void PrintAllRigidBodySettings(this GameObject obj)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    ModConsole.Log(obj.name + " Rigidbody Details");
                    ModConsole.Log("{");
                    ModConsole.Log("velocity " + body.velocity.ToString() + ",");
                    ModConsole.Log("angularVelocity " + body.angularVelocity.ToString() + ",");
                    ModConsole.Log("drag " + body.drag.ToString() + ",");
                    ModConsole.Log("angularDrag " + body.angularDrag.ToString() + ",");
                    ModConsole.Log("mass " + body.mass.ToString() + ",");
                    ModConsole.Log("useGravity " + body.useGravity.ToString() + ",");
                    ModConsole.Log("maxDepenetrationVelocity " + body.maxDepenetrationVelocity.ToString() + ",");
                    ModConsole.Log("isKinematic " + body.isKinematic.ToString() + ",");
                    ModConsole.Log("freezeRotation " + body.freezeRotation.ToString() + ",");
                    ModConsole.Log("constraints " + body.constraints.ToString() + ",");
                    ModConsole.Log("collisionDetectionMode " + body.collisionDetectionMode.ToString() + ",");
                    ModConsole.Log("centerOfMass " + body.centerOfMass.ToString() + ",");
                    ModConsole.Log("inertiaTensor " + body.inertiaTensor.ToString() + ",");
                    ModConsole.Log("detectCollisions " + body.detectCollisions.ToString() + ",");
                    ModConsole.Log("position " + body.position.ToString() + ",");
                    ModConsole.Log("rotation " + body.rotation.ToString() + ",");
                    ModConsole.Log("interpolation " + body.interpolation.ToString() + ",");
                    ModConsole.Log("solverIterations " + body.solverIterations.ToString() + ",");
                    ModConsole.Log("sleepThreshold " + body.sleepThreshold.ToString() + ",");
                    ModConsole.Log("maxAngularVelocity " + body.maxAngularVelocity.ToString() + ",");
                    ModConsole.Log("solverVelocityIterations " + body.solverVelocityIterations.ToString() + ",");
                    ModConsole.Log("sleepVelocity " + body.sleepVelocity.ToString() + ",");
                    ModConsole.Log("sleepAngularVelocity " + body.sleepAngularVelocity.ToString() + ",");
                    ModConsole.Log("useConeFriction " + body.useConeFriction.ToString() + ",");
                    ModConsole.Log("inertiaTensorRotation " + body.inertiaTensorRotation.ToString() + ",");
                    ModConsole.Log("solverIterationCount " + body.solverIterationCount.ToString() + ",");
                    ModConsole.Log("solverVelocityIterationCount " + body.solverVelocityIterationCount.ToString() + ",");
                    ModConsole.Log("}");
                }
                else
                {
                    ModConsole.Log("Does " + obj.name + "have a rigidbody?");
                }
            }
        }

        public static void RestoreOriginalSettings(this GameObject obj)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control != null)
                {
                    control.RestoreOriginalBody();
                }
            }
        }

        public static void AddConstraint(this GameObject obj, RigidbodyConstraints constraint)
        {
            Forces.AddConstraint(obj, constraint);
        }

        public static void RemoveConstraint(this GameObject obj, RigidbodyConstraints constraint)
        {
            Forces.RemoveConstraint(obj, constraint);
        }

        public static void Remove_all_constraints(this GameObject obj)
        {
            Forces.RemoveAllObjConstraints(obj);
        }

        public static void SetGravity(this GameObject obj, bool useGravity)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.useGravity = useGravity;
                control.isKinematic = false;
            }
        }

        public static bool GetGravity(this GameObject obj)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }

                return control.useGravity;
            }
            return false;
        }

        public static void SetGravity(this List<GameObject> GameObjects, bool useGravity)
        {
            foreach (var obj in GameObjects)
            {
                if (obj != null)
                {
                    var control = obj.GetComponent<RigidBodyController>();
                    if (control == null)
                    {
                        control = obj.AddComponent<RigidBodyController>();
                    }
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.useGravity = useGravity;
                }
            }
        }

        public static void SetKinematic(this GameObject obj, bool isKinematic)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.isKinematic = isKinematic;
            }
        }

        public static bool GetKinematic(this GameObject obj)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }

                return control.isKinematic;
            }
            return false;
        }

        public static void SetKinematic(this List<GameObject> GameObjects, bool isKinematic)
        {
            foreach (var obj in GameObjects)
            {
                if (obj != null)
                {
                    var control = obj.GetComponent<RigidBodyController>();
                    if (control == null)
                    {
                        control = obj.AddComponent<RigidBodyController>();
                    }
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.isKinematic = isKinematic;
                }
            }
        }

        public static void SetDetectCollision(this GameObject obj, bool DetectCollisions)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.DetectCollisions = DetectCollisions;
            }
        }

        public static void SetDetectCollision(this List<GameObject> GameObjects, bool DetectCollisions)
        {
            foreach (var obj in GameObjects)
            {
                if (obj != null)
                {
                    var control = obj.GetComponent<RigidBodyController>();
                    if (control == null)
                    {
                        control = obj.AddComponent<RigidBodyController>();
                    }
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.DetectCollisions = DetectCollisions;
                }
            }
        }


    }
}