namespace AstroClient
{
    #region Imports

    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using Cheetos;
    using Exploits;
    using UnityEngine;

    #endregion Imports

    internal class AstroInput : GameEvents
    {
        internal static string Oculus_PrimaryIndexTrigger { get; } = "Oculus_CrossPlatform_PrimaryIndexTrigger";

        internal static string Oculus_SecondaryIndexTrigger { get; } = "Oculus_CrossPlatform_SecondaryIndexTrigger";

        internal static string Oculus_PrimaryHandTrigger { get; } = "Oculus_CrossPlatform_PrimaryHandTrigger";

        internal static string Oculus_SecondaryHandTrigger { get; } = "Oculus_CrossPlatform_SecondaryHandTrigger";

        internal static string Oculus_Button_1 { get; } = "Oculus_CrossPlatform_Button_1";

        internal static string Oculus_Button_2 { get; } = "Oculus_CrossPlatform_Button_2";

        internal static string Oculus_Button_3 { get; } = "Oculus_CrossPlatform_Button_3";

        internal static string Oculus_Button_4 { get; } = "Oculus_CrossPlatform_Button_4";

        internal static string Oculus_Button_PrimaryThumbstick { get; } = "Oculus_CrossPlatform_Button_PrimaryThumbstick";

        internal static string Oculus_Button_SecondaryThumbstick { get; } = "Oculus_CrossPlatform_Button_SecondaryThumbstick";

        internal static string Oculus_PrimaryThumbstickHorizontal { get; } = "Oculus_CrossPlatform_PrimaryThumbstickHorizontal";

        internal static string Oculus_PrimaryThumbstickVertical { get; } = "Oculus_CrossPlatform_PrimaryThumbstickVertical";

        internal static string Oculus_SecondaryThumbstickHorizontal { get; } = "Oculus_CrossPlatform_SecondaryThumbstickHorizontal";

        internal static string Oculus_SecondaryThumbstickVertical { get; } = "Oculus_CrossPlatform_SecondaryThumbstickVertical";

        internal GameObject LeftHandPointer { get; private set; }

        internal GameObject RightHandPointer { get; private set; }

        internal bool CanClick { get; private set; }

        internal override void OnLateUpdate()
        {
            if (!WorldUtils.IsInWorld) return;
            try
            {
                var localPlayer = PlayerUtils.GetPlayer();
                if (!localPlayer.isActiveAndEnabled || QuickMenuUtils_Old.IsQuickMenuOpen) return;

                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Z))
                {
                    ExploitUtils.DisableAllExploits();
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
            catch
            {
            }
        }

        internal void CheckHitObject(GameObject gameObject)
        {
            //var interactable = gameObject.GetComponent<Astro_Interactable>();
            //if (interactable != null)
            //{
            //    interactable.Action.Invoke();
            //}
        }
    }
}