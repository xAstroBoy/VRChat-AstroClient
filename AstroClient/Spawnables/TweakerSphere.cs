using AstroClient.AstroMonos.Components.Custom.Items;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Holders;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.Spawnables
{
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
            Cube.gameObject.AddComponent<SphereCollider>().isTrigger = true;
            Cube.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            Cube.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            Cube.transform.position = bonePosition;
            Cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Cube.name = "Tweaker Sphere Helper  (AstroClient)";
            Cube.AddToWorldUtilsMenu();
            var body = ComponentUtils.GetOrAddComponent<Rigidbody>(Cube);
            if (body != null)
            {
                body.useGravity = false;
            }
            Cube.IgnoreLocalPlayerCollision();
            ComponentUtils.GetOrAddComponent<ItemTweakerHelper>(Cube);
            obj = Cube;
        }

    }
}