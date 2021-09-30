namespace AstroLibrary.Extensions
{
    using UnityEngine;
    using static AstroClient.Forces;

    internal static class Forces_ext
    {
        internal static void KillForces(this GameObject obj, bool TakeOwnership = true)
        {
            RemoveForces(obj, TakeOwnership);
        }

        internal static void Left(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyLeftForce(obj, TakeOwnership);
        }

        internal static void Right(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyRightForce(obj, TakeOwnership);
        }

        internal static void Foward(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyFowardForce(obj, TakeOwnership);
        }

        internal static void Backward(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyBackwardsForce(obj, TakeOwnership);
        }

        internal static void Push(this GameObject obj, bool TakeOwnership = true)
        {
            PushObject(obj, TakeOwnership);
        }

        internal static void Pull(this GameObject obj, bool TakeOwnership = true)
        {
            PullObject(obj, TakeOwnership);
        }

        internal static void SpinX(this GameObject obj, bool TakeOwnership = true)
        {
            SpinObjectX(obj, TakeOwnership);
        }

        internal static void SpinY(this GameObject obj, bool TakeOwnership = true)
        {
            SpinObjectY(obj, TakeOwnership);
        }

        internal static void SpinZ(this GameObject obj, bool TakeOwnership = true)
        {
            SpinObjectZ(obj, TakeOwnership);
        }
    }
}