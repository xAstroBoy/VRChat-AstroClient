namespace AstroLibrary.Extensions
{
    using UnityEngine;
    using static AstroClient.Forces;

    public static class Forces_ext
    {
        public static void KillForces(this GameObject obj, bool TakeOwnership = true)
        {
            RemoveForces(obj, TakeOwnership);
        }

        public static void Left(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyLeftForce(obj, TakeOwnership);
        }

        public static void Right(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyRightForce(obj, TakeOwnership);
        }

        public static void Foward(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyFowardForce(obj, TakeOwnership);
        }

        public static void Backward(this GameObject obj, bool TakeOwnership = true)
        {
            ApplyBackwardsForce(obj, TakeOwnership);
        }

        public static void Push(this GameObject obj, bool TakeOwnership = true)
        {
            PushObject(obj, TakeOwnership);
        }

        public static void Pull(this GameObject obj, bool TakeOwnership = true)
        {
            PullObject(obj, TakeOwnership);
        }

        public static void SpinX(this GameObject obj, bool TakeOwnership = true)
        {
            SpinObjectX(obj, TakeOwnership);
        }

        public static void SpinY(this GameObject obj, bool TakeOwnership = true)
        {
            SpinObjectY(obj, TakeOwnership);
        }

        public static void SpinZ(this GameObject obj, bool TakeOwnership = true)
        {
            SpinObjectZ(obj, TakeOwnership);
        }
    }
}