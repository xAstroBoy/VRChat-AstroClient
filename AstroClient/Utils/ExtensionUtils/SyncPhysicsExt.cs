using UnityEngine;

namespace AstroClient.SyncPhysicExt
{
    public static class SyncPhysicsExt
    {
        public static void RefreshProperties(this SyncPhysics instance)
        {
            if (instance != null)
            {
                instance.Method_Public_Void_PDM_1();
            }
        }

        public static void RespawnItem(this SyncPhysics instance)
        {
            if (instance != null)
            {
                instance.Method_Public_Void_PDM_0();
            }
        }

        public static Rigidbody GetRigidBody(this SyncPhysics instance)
        {
            return instance.field_Private_Rigidbody_0;
        }
    }
}