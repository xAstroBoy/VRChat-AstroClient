using Il2CppSystem;

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
                instance.Method_Public_Void_0();
            }
        }


        internal static Nullable<Vector3> GetDefaultPosition(this SyncPhysics instance)
        {
            return instance.field_Private_Nullable_1_Vector3_0;
        }
        internal static Nullable<Quaternion> GetDefaultRotation(this SyncPhysics instance)
        {
            return instance.field_Private_Nullable_1_Quaternion_0;
        }

        internal static void SetKinematic(this SyncPhysics instance, bool isKinematic)
        {
            if (instance != null)
            {
                instance.SetKinematicFor(GameInstances.CurrentPlayer, isKinematic);
            }
        }
        internal static void SetGravity(this SyncPhysics instance, bool useGravity)
        {
            if (instance != null)
            {
                instance.SetGravityFor(GameInstances.CurrentPlayer, useGravity);
            }
        }

        internal static void SetKinematicFor(this SyncPhysics instance, VRC.Player player, bool isKinematic, bool TakeOwnership = false)
        {
            if (instance != null && player != null)
            {
                instance.gameObject.TakeOwnership();
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
                var players = WorldUtils.Players;
                for (int i = 0; i < players.Count; i++)
                {
                    try
                    {
                        SetGravityFor(instance, players[i], useGravity);
                    }
                    catch { }
                }
            }
        }

        internal static void SetKinematicForEveryone(this SyncPhysics instance, bool isKinematic)
        {
            if (instance != null)
            {
                var players = WorldUtils.Players;
                for (int i = 0; i < players.Count; i++)
                {
                    try
                    {
                        SetKinematicFor(instance, players[i], isKinematic);
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