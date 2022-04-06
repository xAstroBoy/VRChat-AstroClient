namespace AstroClient.Tools.Extensions
{
    using UnityEngine;

    internal static class Rigidbody_ext
    {
        internal static void PrintAllRigidBodySettings(this GameObject obj)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    Log.Write(obj.name + " Rigidbody Details");
                    Log.Write("{");
                    Log.Write("velocity " + body.velocity.ToString() + ",");
                    Log.Write("angularVelocity " + body.angularVelocity.ToString() + ",");
                    Log.Write("drag " + body.drag.ToString() + ",");
                    Log.Write("angularDrag " + body.angularDrag.ToString() + ",");
                    Log.Write("mass " + body.mass.ToString() + ",");
                    Log.Write("useGravity " + body.useGravity.ToString() + ",");
                    Log.Write("maxDepenetrationVelocity " + body.maxDepenetrationVelocity.ToString() + ",");
                    Log.Write("isKinematic " + body.isKinematic.ToString() + ",");
                    Log.Write("freezeRotation " + body.freezeRotation.ToString() + ",");
                    Log.Write("constraints " + body.constraints.ToString() + ",");
                    Log.Write("collisionDetectionMode " + body.collisionDetectionMode.ToString() + ",");
                    Log.Write("centerOfMass " + body.centerOfMass.ToString() + ",");
                    Log.Write("inertiaTensor " + body.inertiaTensor.ToString() + ",");
                    Log.Write("detectCollisions " + body.detectCollisions.ToString() + ",");
                    Log.Write("position " + body.position.ToString() + ",");
                    Log.Write("rotation " + body.rotation.ToString() + ",");
                    Log.Write("interpolation " + body.interpolation.ToString() + ",");
                    Log.Write("solverIterations " + body.solverIterations.ToString() + ",");
                    Log.Write("sleepThreshold " + body.sleepThreshold.ToString() + ",");
                    Log.Write("maxAngularVelocity " + body.maxAngularVelocity.ToString() + ",");
                    Log.Write("solverVelocityIterations " + body.solverVelocityIterations.ToString() + ",");
                    Log.Write("sleepVelocity " + body.sleepVelocity.ToString() + ",");
                    Log.Write("sleepAngularVelocity " + body.sleepAngularVelocity.ToString() + ",");
                    Log.Write("useConeFriction " + body.useConeFriction.ToString() + ",");
                    Log.Write("inertiaTensorRotation " + body.inertiaTensorRotation.ToString() + ",");
                    Log.Write("solverIterationCount " + body.solverIterationCount.ToString() + ",");
                    Log.Write("solverVelocityIterationCount " + body.solverVelocityIterationCount.ToString() + ",");
                    Log.Write("}");
                }
                else
                {
                    Log.Write("Does " + obj.name + "have a rigidbody?");
                }
            }
        }
    }
}