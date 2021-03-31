namespace AstroClient.Cheetos
{
    using AstroClient.ConsoleUtils;
    using AstroClient.Finder;
    using DayClientML2.Utility.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnhollowerBaseLib;
    using UnhollowerBaseLib.Runtime;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Experimental.UIElements;
    using VRC;

    public class Astro_Interactable : MonoBehaviour
    {
        // https://melonwiki.xyz/#/modders/melonloaderdifferences?id=custom-components-il2cpp-type-inheritance

        public Astro_Interactable(IntPtr ptr) : base(ptr) { }

        public Action Action;

        // Use this for initialization
        void Start()
        {
            ModConsole.DebugError("Astro_Interactable Created..");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class AtroInput : Overridables
    {
        public bool IsReady = false;

        public override void OnApplicationStart()
        {
            // https://github.com/knah/Il2CppAssemblyUnhollower#class-injection
            ClassInjector.RegisterTypeInIl2Cpp<Astro_Interactable>();
        }

        public override void OnWorldReveal()
        {
#if CHEETOS
            var testButton = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            testButton.transform.position = LocalPlayerUtils.GetSelfPlayer().transform.position;
            testButton.AddComponent<Astro_Interactable>();
            testButton.GetComponent<Astro_Interactable>().Action = () => { ModConsole.DebugLog("Astro_Interactable: I was invoked.."); };
#endif
        }

        public override void OnLateUpdate()
        {
            var localPlayer = LocalPlayerUtils.GetSelfPlayer();
            if (WorldUtils.GetWorldID() == null || localPlayer == null || !localPlayer.isActiveAndEnabled)
            {
                return;
            }

            if (localPlayer.GetIsInVR())
            {
#if CHEETOS
                // _Application/TrackingVolume/TrackingHandProxy(Clone)/Left/PointerOrigin
                // _Application/TrackingVolume/TrackingHandProxy(Clone)/Right/PointerOrigin

                // _Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (left)/PointerOrigin
                // _Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (right)/PointerOrigin

                //var leftHand = GameObjectFinder.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (left)/PointerOrigin");
                //var rightHand = GameObjectFinder.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (right)/PointerOrigin");

                var inputManager = GameObjectFinder.Find("_Application/InputManager");

                var daydreamComp = inputManager.GetComponent<VRCInputProcessorDaydream>();

                var rightTrigger = daydreamComp.field_Private_VRCInput_10;

                if(rightTrigger.prop_Boolean_2)
                {
                    var uiManager = VRCUiManager.prop_VRCUiManager_0;
                    PopupManager.QueHudMessage(uiManager, "VR Right Trigger");
                }
#endif
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, float.MaxValue))
                    {
                        var gameObject = hit.transform.gameObject;
                        CheckHitObject(gameObject);
                    }
                }
            }
        }

        public void CheckHitObject(GameObject gameObject)
        {
            var interactable = gameObject.GetComponent<Astro_Interactable>();
            if (interactable!=null)
            {
                interactable?.Action.Invoke();
                ModConsole.DebugLog("Astro_Interactable invoked..");
            }
        }
    }
}
