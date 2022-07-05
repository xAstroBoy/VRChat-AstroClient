namespace AstroClient.Spawnables.ColliderSuppresserCube
{
    using AstroMonos.Components.Custom.Items;
    using Tools.Extensions;
    using Tools.Holders;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal class TweakerSphere : AstroEvents
    {
        private static GameObject obj;

        internal static void Spawn()
        {
            if (obj != null)
            {
                UnityEngine.Object.Destroy(obj);
                obj = null;
                return;
            }
            Vector3 bonePosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightHand);
            GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Cube.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            Cube.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            Cube.transform.position = bonePosition;
            Cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Cube.name = "Tweaker Sphere Helper  (AstroClient)";
            Cube.AddToWorldUtilsMenu();
            var body = Cube.GetOrAddComponent<Rigidbody>();
            if (body != null)
            {
                body.useGravity = false;
            }
            Cube.IgnoreLocalPlayerCollision();
            Cube.GetOrAddComponent<ItemTweakerHelper>();
            obj = Cube;
        }

    }
}