namespace AstroClient.Tools.Extensions
{
    using UnityEngine;

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

        internal static Rigidbody GetRigidBody(this SyncPhysics instance)
        {
            return instance?.field_Private_Rigidbody_0;
        }
    }
}