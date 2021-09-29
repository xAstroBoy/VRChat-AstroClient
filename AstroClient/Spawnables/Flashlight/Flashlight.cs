using AstroLibrary.Extensions;
using AstroLibrary.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace AstroClient
{
    internal class Astro_Flashlight : GameEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            DestroyAllFlashLights();
        }

        internal static  void DestroyAllFlashLights()
        {
            flashlights.DestroyAndClearList();
        }

        internal static  void SpawnFlashlight()
        {
            GameObject FlashLight_Body = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            FlashLight_Body.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            FlashLight_Body.name = "Flashlight (AstroClient)";
            FlashLight_Body.GetComponent<Renderer>().material.color = Color.blue;
            FlashLight_Body.GetComponent<Collider>().DestroyMeLocal();

            FlashLight_Body.AddComponent<BoxCollider>().isTrigger = true;

            FlashLight_Body.transform.localScale = new Vector3(0.05f, 0.125f, 0.05f);
            FlashLight_Body.transform.position = Utils.CurrentUser.transform.position + new Vector3(0f, 1f, 0f);

            var body = FlashLight_Body.AddComponent<Rigidbody>();
            if (body != null)
            {
                body.useGravity = false;
                body.isKinematic = true;
            }
            var pickup = FlashLight_Body.AddComponent<VRCSDK2.VRC_Pickup>();
            if (pickup != null)
            {
                pickup.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                pickup.pickupable = true;
            }

            GameObject FlashLight_Base = new GameObject("Base");
            if (FlashLight_Base != null)
            {
                FlashLight_Base.transform.SetParent(FlashLight_Body.transform);
                FlashLight_Base.transform.localPosition = Vector3.zero;
                FlashLight_Base.transform.Rotate(90f, 0f, 0f);
                FlashLight_Base.GetComponent<Collider>().DestroyMeLocal();
            }

            var FlashLight_Light = FlashLight_Base.AddComponent<Light>();
            if (FlashLight_Light != null)
            {
                FlashLight_Light.color = Color.white;
                FlashLight_Light.type = LightType.Spot;
                FlashLight_Light.range = 1000f;
            }

            GameObject FlashLight_Head = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            FlashLight_Head.name = "Head";
            FlashLight_Head.GetComponent<Renderer>().material.color = Color.blue;
            FlashLight_Head.transform.SetParent(FlashLight_Body.transform);
            FlashLight_Head.transform.localPosition = new Vector3(0f, -0.75f, 0f);
            FlashLight_Head.transform.localScale = new Vector3(1.5f, 0.25f, 1.5f);
            FlashLight_Head.GetComponent<Collider>().DestroyMeLocal();
            FlashLight_Body.transform.Rotate(90f, 0f, 0f);

            var behaviour = FlashLight_Body.AddComponent<FlashlightBehaviour>();
            if (behaviour != null)
            {
                behaviour.FlashLight_Base = FlashLight_Base;
                behaviour.FlashLight_Head = FlashLight_Head;
                behaviour.FlashLight_Body = FlashLight_Body;
                behaviour.FlashLight_Light = FlashLight_Light;
                behaviour.InitiateLight();
            }

            flashlights.AddGameObject(FlashLight_Body);
        }

        private static List<GameObject> flashlights = new List<GameObject>();
    }
}