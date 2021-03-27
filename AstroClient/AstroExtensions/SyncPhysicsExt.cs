using AstroClient.ConsoleUtils;
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
            if (instance != null)
            {
                if (instance.field_Private_Rigidbody_0 == null)
                {
                    var body = instance.gameObject.GetComponent<Rigidbody>();
                    if (body != null)
                    {
                        ModConsole.DebugLog("SyncPhysic Instance returned null, Linking Current object Rigidbody...!");
                        instance.field_Private_Rigidbody_0 = body;
                    }
                }
                return instance.field_Private_Rigidbody_0;
            }
            return null;
        }

    }
}