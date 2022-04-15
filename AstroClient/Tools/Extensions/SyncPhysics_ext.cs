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
                instance.Method_Public_Void_1();
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
                instance.SetKinematicFor(GameInstances.CurrentPlayer, isKinematic, TakeOwnership);
            }
        }
        internal static void SetGravity(this SyncPhysics instance, bool useGravity, bool TakeOwnership = false)
        {
            if (instance != null)
            {
                instance.SetGravityFor(GameInstances.CurrentPlayer, useGravity, TakeOwnership);
            }
        }

        internal static void SetKinematicFor(this SyncPhysics instance, VRC.Player player, bool isKinematic, bool TakeOwnership = false)
        {
            if (instance != null && player != null)
            {
                if (TakeOwnership)
                {
                    instance.gameObject.TakeOwnership();
                }

                if (isKinematic)
                {
                    instance.EnableKinematic(player);
                }
                else
                {
                    instance.DisableKinematic(player);
                }
            }
        }

        internal static void SetGravityForEveryone(this SyncPhysics instance, bool useGravity)
        {
            if (instance != null)
            {
                for (int i = 0; i < WorldUtils.Players.Count; i++)
                {
                    try
                    {
                        SetGravityFor(instance, WorldUtils.Players[i], useGravity);
                    }
                    catch { }
                }
            }
        }

        internal static void SetKinematicForEveryone(this SyncPhysics instance, bool isKinematic)
        {
            if (instance != null)
            {
                for (int i = 0; i < WorldUtils.Players.Count; i++)
                {
                    try
                    {
                        SetKinematicFor(instance, WorldUtils.Players[i], isKinematic);
                    }
                    catch { }
                }
            }
        }

        internal static void SetGravityFor(this SyncPhysics instance, VRC.Player player, bool useGravity, bool TakeOwnership = false)
        {
            if (instance != null && player != null)
            {
                if (TakeOwnership)
                {
                    instance.gameObject.TakeOwnership();
                }

                if (useGravity)
                {
                    instance.EnableGravity(player);
                }
                else
                {
                    instance.DisableGravity(player);
                }
            }
        }

        internal static Rigidbody GetRigidBody(this SyncPhysics instance)
        {
            return instance?.field_Private_Rigidbody_0;
        }
    }
}