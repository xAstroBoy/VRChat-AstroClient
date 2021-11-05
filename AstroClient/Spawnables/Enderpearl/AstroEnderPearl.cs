using AstroLibrary.Extensions;
using AstroLibrary.Utility;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient
{
    internal class AstroEnderPearl
    {
        private static GameObject ENDER;

        internal static void SpawnEnderPearl()
        {
            if (ENDER != null)
            {
                UnityEngine.Object.Destroy(ENDER);
                ENDER = null;
                return;
            }
            Vector3 bonePosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightHand);
            GameObject pearl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pearl.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            pearl.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            pearl.transform.position = bonePosition;
            pearl.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            pearl.name = "EnderPearl (AstroClient)";
           var body =  pearl.GetOrAddComponent<Rigidbody>();
           if (body != null)
           {
               body.useGravity = false;
           }
            UnityEngine.Object.Destroy(pearl.GetComponent<Collider>());
            _ = pearl.AddComponent<EnderPearlBehaviour>();
            ENDER = pearl;
        }
    }
}