using AstroClient.ClientActions;

namespace AstroClient.Spawnables.Flashlight
{
    using System;
    using System.Collections.Generic;
    using AstroMonos.Components.Custom.Items;
    using ClientResources.Loaders;
    using Tools.Extensions;
    using Tools.Holders;
    using Tools.Player;
    using UnityEngine;
    using VRC.SDK.Internal.Tutorial;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using Object = UnityEngine.Object;

    internal class Astro_Flashlight : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnRoomLeft()
        {
            DestroyAllFlashLights();
            CurrentLightTemplate = null;
        }

        internal static void DestroyAllFlashLights()
        {
            flashlights.DestroyAndClearList();
        }
        internal static Light CurrentLightTemplate { get; set; }

        internal static bool isGoldenFlashlight { get; set; } = false;
        internal static bool UseExistingLightAsTemplate { get; set; } = false;
        internal static void SpawnFlashlight()
        {
            GameObject flashlight = null;
            Transform LightChild = null;
            if (isGoldenFlashlight)
            {
                flashlight = Object.Instantiate(Prefabs.Flashlight_gold);
                flashlight.name = "Gold Flashlight (AstroClient)";
                LightChild = flashlight.transform.FindObject("YellowLight");
            }
            else
            {
                flashlight = Object.Instantiate(Prefabs.Flashlight_normal);
                flashlight.name = "Black Flashlight (AstroClient)";
                LightChild = flashlight.transform.FindObject("WhiteLight");
            }

            if (flashlight != null)
            {
                flashlight.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
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
                flashlight.IgnoreLocalPlayerCollision();
                flashlight.transform.position = GameInstances.CurrentUser.transform.position + new Vector3(0f, 1f, 0f);
                flashlights.AddGameObject(flashlight);

                var pickup = flashlight.AddComponent<VRCSDK2.VRC_Pickup>();
                if (pickup != null)
                {
                    pickup.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                    pickup.pickupable = true;
                }

                var behaviour = flashlight.AddComponent<FlashlightBehaviour>();
                if (behaviour != null)
                {
                    behaviour.FlashLight_Base = flashlight;
                    behaviour.FlashLight_Light = CreateAndSetLight(LightChild); ;
                    behaviour.InitiateLight();
                }

            }

        }
        private static Light CreateAndSetLight(Transform LightObject)
        {
            Log.Debug($"Current Light Holder is : {LightObject.name}");
            if (LightObject == null) return null;
            Light Result = LightObject.GetComponent<Light>();
            if (Result != null)
            {
                Log.Debug("Setting Flashlight Light Settings ");

                if (CurrentLightTemplate != null)
                {

                    // before copying let's backup the prefab Properties!
                    Log.Debug("Backupping SpotAngle.");
                    var spotAngle = Result.spotAngle;
                    Log.Debug("Backupping innerSpotAngle.");
                    var innerSpotAngle = Result.innerSpotAngle;

                    Result.CopyFromLight(CurrentLightTemplate);

                    Log.Debug("Restoring Prefab Spot Angle Settings.");
                    Result.innerSpotAngle = innerSpotAngle;
                    Log.Debug($"Restoring innerSpotAngle: {Result.spotAngle}.");
                    Result.spotAngle = spotAngle;
                    Log.Debug($"Restoring spotAngle : {Result.spotAngle}.");

                }

                if (CurrentLightTemplate == null)
                {
                    Result.intensity = 1;
                }

                Result.useColorTemperature = false;
                Result.shadows = LightShadows.None;
                Result.color = Color.white;
                Result.type = LightType.Spot;
                Result.range = 1000f;
                //Result.attenuate = false;
                if (Result.cookie != null)
                {
                    Result.cookie.DestroyMeLocal();
                    Result.cookie = null;
                    Result.cookieSize = 0;
                }
            }
            else
            {
                Log.Debug("Result is empty!");
            }
            return Result;
        }

        internal static void GetLightTemplate()
        {
            Log.Debug("Finding Pickup...");
            var pickup = PlayerHands.GetHeldPickup();
            if (pickup != null)
            {
                Log.Debug($"Found Held Pickup : {pickup.name}, Getting Light template...");

                var light = pickup.GetComponentInChildren<Light>(); // Get the active Light.
                if (light != null)
                {
                    Log.Debug("Found a template light!");
                    PopupUtils.QueHudMessage($"<color=#FFA500>Using Light from {pickup.name} as template!</color>");
                    CurrentLightTemplate = light;
                }

            }
        }
        internal static void ClearTemplate()
        {
            CurrentLightTemplate = null;
            PopupUtils.QueHudMessage($"<color=#FFA500>Cleared Light Template!</color>");
        }

        private static List<GameObject> flashlights = new List<GameObject>();
    }
}