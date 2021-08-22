namespace AstroClient
{
	#region Imports

	using AstroClient.Cheetos;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using UnityEngine;

	#endregion Imports

	public class AstroInput : GameEvents
    {
        public GameObject LeftHandPointer { get; private set; }

        public GameObject RightHandPointer { get; private set; }

        public bool CanClick { get; private set; }

        public override void OnLateUpdate()
        {
            var localPlayer = Utils.LocalPlayer.GetPlayer();
            if (WorldUtils.Get_World_ID() == null || localPlayer == null || !localPlayer.isActiveAndEnabled || QuickMenuUtils.IsQuickMenuOpen)
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