namespace AstroClient.Tools.Extensions
{
    using UnityEngine;
    using xAstroBoy.Utility;

    internal static class SyncPhysics_ext
    {
        internal static void RefreshProperties(this SyncPhysics instance, bool TakeOwnership = false)
        {
            if (instance != null)
            {
                if (TakeOwnership)
                {
                    instance.gameObject.TakeOwnership();
                }
                instance.Method_Public_Void_PDM_2();
            }
        }

        internal static void RespawnItem(this SyncPhysics instance, bool TakeOwnership = false)
        {
            if (instance != null)
            {
                if (TakeOwnership)
                {
                    instance.gameObject.TakeOwnership();
                }
                instance.Method_Public_Void_PDM_0();
            }
        }
        internal static void SetKinematic(this SyncPhysics instance, bool isKinematic, bool TakeOwnership = false)
        {
            if (instance != null)
            {
                if (TakeOwnership)
                {
                    instance.gameObject.TakeOwnership();
                }

                if (isKinematic)
                {
                    instance.EnableKinematic(GameInstances.CurrentPlayer);
                }
                else
                {
                    instance.DisableKinematic(GameInstances.CurrentPlayer);
                }
            }
        }
        internal static void SetGravity(this SyncPhysics instance, bool useGravity, bool TakeOwnership = false)
        {
            if (instance != null)
            {
                if (TakeOwnership)
                {
                    instance.gameObject.TakeOwnership();
                }

                if (useGravity)
                {
                    instance.EnableGravity(GameInstances.CurrentPlayer);
                }
                else
                {
                    instance.DisableGravity(GameInstances.CurrentPlayer);
                }
            }
        }

        internal static Rigidbody GetRigidBody(this SyncPhysics instance)
        {
            return instance?.field_Private_Rigidbody_0;
        }
    }
}