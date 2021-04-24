using AstroClient.Finder;
using DayClientML2.Utility.Extensions;
using System;
using UnityEngine;

namespace AstroClient
{
    public static class Astro_Interactable_Extensions
    {
        public static void AddAstroInteractable(this GameObject gameObject, Action action)
        {
            gameObject.AddComponent<Astro_Interactable>();
            gameObject.GetComponent<Astro_Interactable>().Action = action;
        }
    }

    public class Astro_Interactable : GameEventsBehaviour
    {
        public Astro_Interactable(IntPtr ptr) : base(ptr)
        {
        }

        public Action Action;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }

    public class AstroInput : GameEvents
    {
        public GameObject LeftHandPointer { get; private set; }
        public GameObject RightHandPointer { get; private set; }

        public bool CanClick { get; private set; }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
#if CHEETOS
            //var testButton = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //testButton.transform.position = LocalPlayerUtils.GetSelfPlayer().transform.position;
            //testButton.AddComponent<Astro_Interactable>();
            //testButton.GetComponent<Astro_Interactable>().Action = () => { ModConsole.DebugLog("Astro_Interactable: I was invoked.."); };
#endif
        }

        public override void OnLateUpdate()
        {
            var localPlayer = LocalPlayerUtils.GetSelfPlayer();
            if (WorldUtils.GetWorldID() == null || localPlayer == null || !localPlayer.isActiveAndEnabled || LocalPlayerUtils.IsQuickMenuOpen)
            {
                return;
            }

            if (localPlayer.GetIsInVR())
            {
                if (LeftHandPointer == null)
                {
                    LeftHandPointer = GameObjectFinder.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (left)/PointerOrigin");
                }

                if (RightHandPointer == null)
                {
                    RightHandPointer = GameObjectFinder.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (right)/PointerOrigin");
                }

                var inputManager = GameObjectFinder.Find("_Application/InputManager");

                var daydreamComp = inputManager.GetComponent<VRCInputProcessorDaydream>();

                var leftTrigger = daydreamComp.field_Private_VRCInput_12;
                var rightTrigger = daydreamComp.field_Private_VRCInput_10;

                Transform currentTriggerPointer = null;

                if (leftTrigger.prop_Boolean_2 && CanClick)
                {
                    currentTriggerPointer = LeftHandPointer.transform;
                    CanClick = false;
                }
                else if (rightTrigger.prop_Boolean_2 && CanClick)
                {
                    currentTriggerPointer = RightHandPointer.transform;
                    CanClick = false;
                }

                if (!leftTrigger.prop_Boolean_2 && !rightTrigger.prop_Boolean_2)
                {
                    CanClick = true;
                }

                if (currentTriggerPointer != null)
                {
                    if (Physics.Raycast(currentTriggerPointer.position, currentTriggerPointer.transform.forward, out RaycastHit hit, float.MaxValue))
                    {
                        var gameObject = hit.collider.transform.gameObject;
                        CheckHitObject(gameObject);
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
                    {
                        var gameObject = hit.collider.transform.gameObject;
                        CheckHitObject(gameObject);
                    }
                }
            }
        }

        public void CheckHitObject(GameObject gameObject)
        {
            var interactable = gameObject.GetComponent<Astro_Interactable>();
            if (interactable != null)
            {
                interactable.Action.Invoke();
            }
        }
    }
}