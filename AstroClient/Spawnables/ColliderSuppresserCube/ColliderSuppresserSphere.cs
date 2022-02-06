namespace AstroClient.Spawnables.Enderpearl
{
    using AstroMonos.Components.Custom.Items;
    using System.Collections.Generic;
    using Tools.Extensions;
    using Tools.Holders;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal class ColliderSuppresserSphere : AstroEvents
    {
        private static GameObject CubeColliderDisabler;

        internal override void OnRoomLeft()
        {
            DisabledCollisions.Clear();
        }

        internal static void SpawnSphere()
        {
            if (CubeColliderDisabler != null)
            {
                UnityEngine.Object.Destroy(CubeColliderDisabler);
                CubeColliderDisabler = null;
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
            Cube.GetOrAddComponent<ColliderSuppresserBehaviour>();
            CubeColliderDisabler = Cube;
        }

        internal static List<Transform> DisabledCollisions = new List<Transform>();

        internal static void FixAndRevertColliderEdits()
        {
            if (DisabledCollisions.Count != 0)
            {
                foreach (var item in DisabledCollisions)
                {
                    item.gameObject.IgnoreLocalPlayerCollision(false);
                }
                DisabledCollisions.Clear();
            }
        }
    }
}