using AstroClient.ClientActions;
using UnhollowerBaseLib.Attributes;

namespace AstroClient.Spawnables.ColliderSuppresserCube
{
    using System.Collections.Generic;
    using AstroMonos.Components.Custom.Items;
    using Tools.Extensions;
    using Tools.Holders;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal class ColliderSuppresserSphere : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private static GameObject SphereColliderDisabler;

        private void OnRoomLeft()
        {
            DisabledCollisions.Clear();
        }

        internal static void SpawnSphere()
        {
            if (SphereColliderDisabler != null)
            {
                UnityEngine.Object.Destroy(SphereColliderDisabler);
                SphereColliderDisabler = null;
                return;
            }
            Vector3 bonePosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightHand);
            GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Cube.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            Cube.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            Cube.transform.position = bonePosition;
            Cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Cube.name = "Collider Patcher Cube  (AstroClient)";
            Cube.AddToWorldUtilsMenu();
            var body = Cube.GetOrAddComponent<Rigidbody>();
            if (body != null)
            {
                body.useGravity = false;
            }
            Cube.IgnoreLocalPlayerCollision();
            if (DisabledCollisions.Count != 0)
            {
                foreach (var item in DisabledCollisions)
                {
                    Cube.IgnoreObjectCollision(item); // Make sure the sphere is the same as the despawned one
                }
            }
            Cube.GetOrAddComponent<ColliderSuppresserBehaviour>();
            SphereColliderDisabler = Cube;
        }

        internal static bool DeactivateCollision(Transform collider)
        {
            if (collider != null)
            {

                // Register collision.
                if (!DisabledCollisions.Contains(collider))
                {
                    DisabledCollisions.Add(collider);

                    // Process it.

                    collider.IgnoreLocalPlayerCollision();

                    // Disable Collider as well on Sphere ..
                    SphereColliderDisabler.IgnoreObjectCollision(collider);
                    return true;
                }
                return false;

            }
            return false;
        }

        private static List<Transform> DisabledCollisions { get; set; } = new();

        internal static void FixAndRevertColliderEdits()
        {
            if (DisabledCollisions.Count != 0)
            {
                foreach (var item in DisabledCollisions)
                {
                    // Process it.
                    item.IgnoreLocalPlayerCollision(false);

                    // Enable Collider as well on Sphere ..
                    SphereColliderDisabler.IgnoreObjectCollision(item, false);
                }
                DisabledCollisions.Clear();
            }
        }
    }
}