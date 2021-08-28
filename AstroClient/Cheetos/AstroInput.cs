namespace AstroClient
{
    #region Imports

    using AstroClient.Cheetos;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using UnityEngine;

    #endregion Imports

    public class AstroInput : GameEvents
    {
        public static string Oculus_PrimaryIndexTrigger { get; private set; } = "Oculus_CrossPlatform_PrimaryIndexTrigger";

        public static string Oculus_SecondaryIndexTrigger { get; private set; } = "Oculus_CrossPlatform_SecondaryIndexTrigger";

        public static string Oculus_PrimaryHandTrigger { get; private set; } = "Oculus_CrossPlatform_PrimaryHandTrigger";

        public static string Oculus_SecondaryHandTrigger { get; private set; } = "Oculus_CrossPlatform_SecondaryHandTrigger";

        public static string Oculus_Button_1 { get; private set; } = "Oculus_CrossPlatform_Button_1";

        public static string Oculus_Button_2 { get; private set; } = "Oculus_CrossPlatform_Button_2";

        public static string Oculus_Button_3 { get; private set; } = "Oculus_CrossPlatform_Button_3";

        public static string Oculus_Button_4 { get; private set; } = "Oculus_CrossPlatform_Button_4";

        public static string Oculus_Button_PrimaryThumbstick { get; private set; } = "Oculus_CrossPlatform_Button_PrimaryThumbstick";

        public static string Oculus_Button_SecondaryThumbstick { get; private set; } = "Oculus_CrossPlatform_Button_SecondaryThumbstick";

        public static string Oculus_PrimaryThumbstickHorizontal { get; private set; } = "Oculus_CrossPlatform_PrimaryThumbstickHorizontal";

        public static string Oculus_PrimaryThumbstickVertical { get; private set; } = "Oculus_CrossPlatform_PrimaryThumbstickVertical";

        public static string Oculus_SecondaryThumbstickHorizontal { get; private set; } = "Oculus_CrossPlatform_SecondaryThumbstickHorizontal";

        public static string Oculus_SecondaryThumbstickVertical { get; private set; } = "Oculus_CrossPlatform_SecondaryThumbstickVertical";

        public GameObject LeftHandPointer { get; private set; }

        public GameObject RightHandPointer { get; private set; }

        public bool CanClick { get; private set; }

        public override void OnLateUpdate()
        {
            var localPlayer = Utils.LocalPlayer.GetPlayer();
            if (WorldUtils.GetWorldID() == null || localPlayer == null || !localPlayer.isActiveAndEnabled || QuickMenuUtils_Old.IsQuickMenuOpen)
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

                    AvatarSearch.OnSelect();
                    AvatarFavorites.OnSelect();
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

                    AvatarSearch.OnSelect();
                    AvatarFavorites.OnSelect();
                }
            }
        }

        public void CheckHitObject(GameObject gameObject)
        {
            //var interactable = gameObject.GetComponent<Astro_Interactable>();
            //if (interactable != null)
            //{
            //    interactable.Action.Invoke();
            //}
        }
    }
}