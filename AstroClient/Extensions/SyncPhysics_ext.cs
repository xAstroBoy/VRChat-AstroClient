﻿namespace AstroLibrary.Extensions
{
    using UnityEngine;
    using SyncPhysics = SyncPhysics;

    internal static class SyncPhysics_ext
    {
        internal static void RefreshProperties(this SyncPhysics instance)
        {
            if (instance != null)
            {
                instance.Method_Public_Void_PDM_2();
            }
        }

        internal static void RespawnItem(this SyncPhysics instance)
        {
            if (instance != null)
            {
                instance.Method_Public_Void_PDM_1();
            }
        }

        internal static Rigidbody GetRigidBody(this SyncPhysics instance)
        {
            return instance?.field_Private_Rigidbody_0;
        }
    }
}