using System;
using System.Collections;
using System.Linq;
using AstroClient.Components;
using AstroLibrary.Extensions;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC.SDKBase;
using VRCSDK2;

namespace AstroClient
{
    public class AstroEnderPearl
    {

        private static GameObject ENDER;

        public static void SpawnEnderPearl()
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
            UnityEngine.Object.Destroy(pearl.GetComponent<Collider>());
            pearl.RigidBody_Set_Gravity(false);
            pearl.AddComponent<EnderPearlBehaviour>();
            ENDER = pearl;
        }

    }
}
