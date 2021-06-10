namespace AstroLibrary.Extensions
{
	using AstroLibrary.Console;
	using UnityEngine;

	public static class Rigidbody_ext
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
    }
}