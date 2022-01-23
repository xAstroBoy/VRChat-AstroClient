namespace AstroClient.Spawnables.Flashlight
{
    using System.Collections.Generic;
    using AstroMonos.Components.Custom.Items;
    using ClientResources.Loaders;
    using Tools.Extensions;
    using Tools.Holders;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class Astro_Flashlight : AstroEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            DestroyAllFlashLights();
        }

        internal static void DestroyAllFlashLights()
        {
            flashlights.DestroyAndClearList();
        }

        internal static bool isGoldenFlashlight { get; set; } = false;

        internal static void SpawnFlashlight()
        {
            GameObject flashlight = null;
            if (isGoldenFlashlight)
            {
                flashlight = Object.Instantiate(Prefabs.Flashlight_gold);
            }
            else
            {
                flashlight = Object.Instantiate(Prefabs.Flashlight_normal);
            }

            if (flashlight != null)
            {
                flashlight.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
                flashlight.name = "Flashlight (AstroClient)";
                var collider = flashlight.AddComponent<MeshCollider>();
                if (collider != null)
                {
                    collider.convex = true;
                    collider.IgnoreLocalPlayerCollision(true);
                }
                var rigidbody = flashlight.GetOrAddComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.useGravity = false;
                    rigidbody.isKinematic = true;

                }

                var pickup = flashlight.AddComponent<VRCSDK2.VRC_Pickup>();
                if (pickup != null)
                {
                    pickup.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                    pickup.pickupable = true;
                }

                var FlashLight_Light = flashlight.GetGetInChildrens_OrAddComponent<Light>();
                if (FlashLight_Light != null)
                {
                    FlashLight_Light.color = Color.white;
                    FlashLight_Light.type = LightType.Spot;
                    FlashLight_Light.range = 1000f;
                    if (FlashLight_Light.cookie != null)
                    {
                        FlashLight_Light.cookie.DestroyMeLocal();
                        FlashLight_Light.cookie = null;
                        FlashLight_Light.cookieSize = 0;
                    }
                    //FlashLight_Light.attenuate = false;
                }
                var behaviour = flashlight.AddComponent<FlashlightBehaviour>();
                if (behaviour != null)
                {
                    behaviour.FlashLight_Base = flashlight;
                    behaviour.FlashLight_Light = FlashLight_Light;
                    behaviour.InitiateLight();

                }

                flashlight.IgnoreLocalPlayerCollision();
                flashlight.transform.position = GameInstances.CurrentUser.transform.position + new Vector3(0f, 1f, 0f);
                flashlights.AddGameObject(flashlight);

            }
            //GameObject FlashLight_Body = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            //FlashLight_Body.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            //FlashLight_Body.name = "Flashlight (AstroClient)";
            //FlashLight_Body.GetComponent<Renderer>().material = Materials.metal_gold_001;
            //FlashLight_Body.GetComponent<Collider>().DestroyMeLocal();

            //FlashLight_Body.AddComponent<BoxCollider>().isTrigger = true;

            //FlashLight_Body.transform.localScale = new Vector3(0.05f, 0.125f, 0.05f);
            //FlashLight_Body.transform.position = GameInstances.CurrentUser.transform.position + new Vector3(0f, 1f, 0f);

            //var body = FlashLight_Body.AddComponent<Rigidbody>();
            //if (body != null)
            //{
            //    body.useGravity = false;
            //    body.isKinematic = true;
            //}
            //var pickup = FlashLight_Body.AddComponent<VRCSDK2.VRC_Pickup>();
            //if (pickup != null)
            //{
            //    pickup.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
            //    pickup.pickupable = true;
            //}

            //GameObject FlashLight_Base = new GameObject("Base");
            //if (FlashLight_Base != null)
            //{
            //    FlashLight_Base.transform.SetParent(FlashLight_Body.transform);
            //    FlashLight_Base.transform.localPosition = Vector3.zero;
            //    FlashLight_Base.transform.Rotate(90f, 0f, 0f);
            //    FlashLight_Base.GetComponent<Collider>().DestroyMeLocal();
            //}

            //GameObject FlashLight_Head = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //FlashLight_Head.name = "Head";
            //FlashLight_Head.GetComponent<Renderer>().material = Materials.metal_gold_001;
            //FlashLight_Head.transform.SetParent(FlashLight_Body.transform);
            //FlashLight_Head.transform.localPosition = new Vector3(0f, -0.75f, 0f);
            //FlashLight_Head.transform.localScale = new Vector3(1.5f, 0.25f, 1.5f);
            //FlashLight_Head.GetComponent<Collider>().DestroyMeLocal();
            //FlashLight_Body.transform.Rotate(90f, 0f, 0f);

            //var FlashLight_Light = FlashLight_Head.AddComponent<Light>();
            //if (FlashLight_Light != null)
            //{
            //    FlashLight_Light.color = Color.white;
            //    FlashLight_Light.type = LightType.Spot;
            //    FlashLight_Light.range = 1000f;
            //    FlashLight_Light.attenuate = false;
            //    FlashLight_Light.shadows = LightShadows.None;
            //}

            //var behaviour = FlashLight_Body.AddComponent<FlashlightBehaviour>();
            //if (behaviour != null)
            //{
            //    behaviour.FlashLight_Base = FlashLight_Base;
            //    behaviour.FlashLight_Head = FlashLight_Head;
            //    behaviour.FlashLight_Body = FlashLight_Body;
            //    behaviour.FlashLight_Light = FlashLight_Light;
            //    behaviour.InitiateLight();
            //}

            //FlashLight_Body.IgnoreLocalPlayerCollision();
        }

        private static List<GameObject> flashlights = new List<GameObject>();
    }
}