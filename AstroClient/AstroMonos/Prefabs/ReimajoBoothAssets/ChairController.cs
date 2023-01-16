
using AstroClient;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientAttributes;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using IntPtr = System.IntPtr;
using Object = Il2CppSystem.Object;

namespace ReimajoBoothAssets
{
    /// <summary>
    /// Script can be as many times in the world as you want.
    /// You should NOT have "Transfer Ownership on Collision" enabled for this script.
    /// </summary>
    [RegisterComponent]
    internal class ChairController : MonoBehaviour
    {
        internal  List<Object> AntiGarbageCollection = new();

        public ChairController(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal Action OnStationEnter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnStationExit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroStation Station { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal void Start()
        {
            Station = this.GetOrAddComponent<VRC_AstroStation>();
            Station.Start(); // Forces start priority.
            isVR = GameInstances.LocalPlayer.IsUserInVR();
            localPositionAtStart = Station.gameObject.transform.localPosition;
            Station.StationTrigger.OnInteract += Interact;
            Station.OnStationEnterEvent += OnStationEntered;
            Station.OnStationExitEvent += OnStationExited;
        }

        internal void Update()
        {
            if (enableStationMenuButtonExit)
            {
                CheckStationExitButton();
            }
        }
        /// <summary>
        /// If the station is currently occupied by localPlayer
        /// </summary>
        internal bool isLocalPlayerInStation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// If the station is currently occupied by any player, including localPlayer
        /// </summary>
        internal bool isOccupied  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// Is called when LocalPlayer clicks on a station collider
        /// </summary>
        internal void Interact()
        {
            Log.Debug($"[RMStationController] LocalPlayer called Interact() on the station.");
            localChairRotation = stationSeat.localRotation;
            //stationSeat.rotation = Quaternion.identity;
            colliderIsOn = furnitureCollider.enabled;
            furnitureCollider.enabled = false;
            Station.EnterStation();
        }

        /// <summary>
        /// Can be called by an external script.
        /// Activates the interactable collider locally to allow the local player to enter that station.
        /// Remote players are unaffected by this. If this is called while the station is occupied, the
        /// interactable collider will only activate when the player leaves the station.
        /// </summary>
        internal void SetStationEnabledLocally()
        {
            if (isStationDisabledByApi)
            {
                isStationDisabledByApi = false;
                if (!disableColliderControl)
                {
                    Collider collider = this.GetComponent<Collider>();
                    if (collider != null)
                    {
                        //only activate the collider if station is empty
                        if (GameInstances.LocalPlayer == null)
                            collider.enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Can be called by an external script.
        /// Deactivates the interactable collider locally to disallow the local player to enter that station.
        /// Remote players are unaffected by this. If this is called, a remote player leaves the station
        /// won't activate the interactable collider locally.
        /// </summary>
        internal void SetStationDisabledLocally()
        {
            if (!isStationDisabledByApi)
            {
                isStationDisabledByApi = true;
                if (!disableColliderControl)
                {
                    Collider collider = this.GetComponent<Collider>();
                    //only deactivate the collider if station is empty
                    if (collider != null)
                    {
                        if (GameInstances.LocalPlayer == null)
                            collider.enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Can be called by an external script.
        /// Activates the furniture collider locally to allow the local player to walk through the station collider.
        /// Remote players are unaffected by this. If this is called while the station is occupied by the local player, the
        /// furniture collider will only activate when the local player leaves the station.
        /// </summary>
        internal void SetFurnitureColliderEnabledLocally()
        {
            if (isFurnitureColliderDisabledByApi)
            {
                isFurnitureColliderDisabledByApi = false;
                //only activate the collider if the station is not occupied by local player
                if (!isLocalPlayerInStation)
                {
                    furnitureCollider.enabled = true;
                }
                else
                {
                    //remember to activate the collider once the player leaves the station
                    colliderIsOn = true;
                }
            }
        }

        /// <summary>
        /// Can be called by an external script.
        /// Deactivates the furniture collider locally to allow the local player to walk through the station collider.
        /// Remote players are unaffected by this. If this is called while the station is occupied by the local player, the
        /// furniture collider will stay deactivated when the local player leaves the station.
        /// </summary>
        internal void SetFurnitureColliderDisabledLocally()
        {
            if (!isFurnitureColliderDisabledByApi)
            {
                isFurnitureColliderDisabledByApi = true;
                if (!isLocalPlayerInStation)
                {
                    furnitureCollider.enabled = false;
                }
            }
        }

        /// <summary>
        /// Activate only if the station should NOT control when the attached collider is active
        /// </summary>
        internal bool disableColliderControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// If enabled, pressing ESC or the menu button in VR will kick the player out of the station
        /// and leaving the station by pressing WASD is disabled instead.
        /// </summary>
        internal  bool enableStationMenuButtonExit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// The station transform
        /// </summary>
        internal  Transform stationSeat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// An empty transform to mark the surface to sit on (up/green vector) and the front edge position of the seat (forward/blue axis).
        /// Must have the same parent as the ChairController.
        /// </summary>
        internal  Transform seatSurfaceUpAndFrontEdgeForward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// An empty transform to mark the chair back surface to lean the back against (forward/blue axis).
        /// Must have the same parent as the ChairController.
        /// </summary>
        internal  Transform seatBackEndSurfaceForward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Collider of the bed/chair to walk on it, can be empty
        /// </summary>
        internal  Collider furnitureCollider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// How often <see cref="_AdjustPosition"/> should get called after seating or changing avatar.
        /// While a single call would be enough, it's recommended to call this at least twice to provide a fast adjustement
        /// directly after seating, but then a more accurate re-adjustement later, since VRChat is still in the seating animation
        /// transition while seating, so a later adjustement is more accurate then the first initial one.
        /// </summary>
        internal  int ADJUSTMENT_COUNTS { get; set; } = 3;

        /// <summary>
        /// How much time should be between 2 calls of <see cref="_AdjustPosition"/>,
        /// a value that is too small might lead to issues since bone positions are not very accurate
        /// and might be too old, so the adjusting can "overshoot" and spiral out of control in VRChat.
        /// It is recommended that ADJUSTMENT_START_DELAY + (ADJUSTMENT_DELAY * ADJUSTMENT_COUNTS) are
        ///  at least a second in total to eliminate inaccuracy caused by the seating animation itself.
        /// </summary>
        internal  const float ADJUSTMENT_DELAY = 1f;

        /// <summary>
        /// How long to wait (after entering the station) until adjusting the player position.
        /// An earlier adjustement is less accurate, but eliminates a sudden jump which would be
        /// very noticeable if the first adjustement happens too late.
        /// </summary>
        internal  const float ADJUSTMENT_START_DELAY = 0.5f;

        /// <summary>
        /// How long we should re-adjust avatars in stations after entering a new world, assuming we first need to load their avatars
        /// </summary>
        internal  const float AVATAR_LOAD_TIME = 8f;

        /// <summary>
        /// We assume linear scale, e.g. 0.0895f for an upperLeg with 0.2824 of joint distance, so we multiply by 0.3169f
        ///
        ///  KnownThiccness   NewThiccness
        ///  -------------- = ----------------    =====>   NewThiccness = NewKnownDistance * KnownThiccness / KnownDistance
        ///  KnownDistance    NewKnownDistance
        ///
        /// And this is why school math is usefull in life :)
        /// </summary>
        internal  const float LEG_DISTANCE_TO_UPPER_LEG_THICCNESS = 0.3169f * 0.95f; //allow sinking into the chair by 5%

        /// <summary>
        /// Lower leg to upper leg ration can be ignored here. No need to allow sinking.
        /// </summary>
        internal  const float LEG_DISTANCE_TO_LOWER_LEG_THICCNESS = 0.2869f;

        /// <summary>
        /// We assume linear scale, e.g. 0.0967 for an upperLeg with 0.2824 of joint distance, so we multiply by 0.3424f
        /// </summary>
        internal  const float LEG_DISTANCE_TO_HIP_THICCNESS = 0.3424f * 0.95f; //allow sinking into the chair by 5%

        /// <summary>
        /// If set to true, the interactable collider is disabled and will stay disabled when a player leaves the station
        /// </summary>
        internal  bool isStationDisabledByApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// If set to true, the furniture collider is disabled and will stay disabled when a player leaves the station
        /// </summary>
        internal  bool isFurnitureColliderDisabledByApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal  Quaternion localChairRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal  Vector3 localPositionAtStart { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal  bool colliderIsOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal  int adjustCounter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal  bool isVR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Is called each frame when the localPlayer sits in the station when this station doesn't allow a regular station exit over WASD,
        /// to allow a station exit when the ESC key is pressed.
        /// </summary>
        internal void CheckStationExitButton()
        {
            if (isLocalPlayerInStation)
            {
                if (isVR)
                {
                    if (Input.GetButtonDown("Oculus_CrossPlatform_Button4")) //left menu button
                        Station.ExitStation();

                    if (Input.GetButtonDown("Oculus_CrossPlatform_Button2")) //right menu button
                        Station.ExitStation();

                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Escape)) //ESC button
                        Station.ExitStation();

                }
            }
        }

        public void OnStationEntered()
        {
            //stationSeat.localRotation = localChairRotation;
            if (!disableColliderControl)
            {
                Collider collider = this.GetComponent<Collider>();
                collider.enabled = false;
            }
            Log.Debug($"[RMStationController] LocalPlayer entered station, adjusting position in {ADJUSTMENT_START_DELAY} seconds.");
            isLocalPlayerInStation = true;
            isOccupied = true;
            StartAdjusting();
            OnStationEnter.SafetyRaise();
        }


        /// <summary>
        /// This is called for everyone on the network when a player exited the station.
        /// It is possible that multiple player are in a station at once due to race conditions, so this
        /// event doesn't mean that the station is empty now.
        /// </summary>
        internal void OnStationExited()
        {
            if (isLocalPlayerInStation)
            {
                Log.Debug($"[RMStationController] LocalPlayer exited the chair.");
                isLocalPlayerInStation = false;
                //turn the collider back on if it was on before and is not set to be disabled by an external API call
                if (!isFurnitureColliderDisabledByApi)
                {
                    furnitureCollider.enabled = colliderIsOn;
                }
                OnStationExit.SafetyRaise();
            }
            LastPlayerLeftStation();
        }

        /// <summary>
        /// Must be called when the last player left this station
        /// </summary>
        internal  void LastPlayerLeftStation()
        {
            Log.Debug($"[RMStationController] Last player exited the chair, resetting it's position.");
            isOccupied = false;
            if (!disableColliderControl)
            {
                //make sure an external API call didn't disable the collider
                if (!isStationDisabledByApi)
                {
                    Collider collider = this.GetComponent<Collider>();
                    collider.enabled = true;
                }
            }
            Station.transform.localPosition = localPositionAtStart;
        }

        /// <summary>
        /// Starts adjusting the avatar height after the <see cref="ADJUSTMENT_START_DELAY"/>
        /// </summary>
        internal void StartAdjusting()
        {
            adjustCounter = ADJUSTMENT_COUNTS;
            MiscUtils.DelayFunction(ADJUSTMENT_START_DELAY, () =>
            {
                AdjustPosition();
            });
        }

        /// <summary>
        /// Adjusting the station height to fit the player on the chair surface.
        /// </summary>
        internal void AdjustPosition()
        {
            Vector3 rightUpperLegJoint = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.RightUpperLeg);
            Vector3 rightLowerLegJoint = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.RightLowerLeg);
            if (rightUpperLegJoint == Vector3.zero || rightLowerLegJoint == Vector3.zero)
            {
                Log.Debug($"[RMStationController] Player doesn't have RightUpperLeg/RightLowerLeg, so we can't adjust the chair for them.");
                return;
            }
            Vector3 scale = stationSeat.lossyScale;
            Vector3 refPointLocalPosition = seatSurfaceUpAndFrontEdgeForward.localPosition;
            float refBoneDistance = Vector3.Distance(rightUpperLegJoint, rightLowerLegJoint);
            float currentYDiff = seatSurfaceUpAndFrontEdgeForward.InverseTransformPoint(rightUpperLegJoint).y - ((refBoneDistance * LEG_DISTANCE_TO_UPPER_LEG_THICCNESS) / scale.y);
            float currentZDiff = seatSurfaceUpAndFrontEdgeForward.InverseTransformPoint(rightLowerLegJoint).z - ((refBoneDistance * LEG_DISTANCE_TO_LOWER_LEG_THICCNESS) / scale.z);
            Vector3 hipJoint = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.Hips);
            if (hipJoint != Vector3.zero)
            {
                float currentHipDiff = seatBackEndSurfaceForward.InverseTransformPoint(hipJoint).z - ((refBoneDistance * LEG_DISTANCE_TO_HIP_THICCNESS) / scale.z);
                //we might end up inside the back of the chair, so we can only move the chair backwards by the currentHipDiff and not further
                if (currentHipDiff < currentZDiff)
                {
                    Log.Debug($"[RMStationController] Assuming hip thiccness of {(refBoneDistance * LEG_DISTANCE_TO_HIP_THICCNESS):F4}, correcting offset of Z:{currentHipDiff:F4}");
                    currentZDiff = currentHipDiff;
                }
                else
                {
                    Log.Debug($"[RMStationController] Hip distance doesn't matter.");
                }
            }
            else
            {
                Log.Debug($"[RMStationController] Avatar has no hip bone, skipping hip check.");
            }
            Log.Debug($"[RMStationController] Assuming upper leg thiccness of {(refBoneDistance * LEG_DISTANCE_TO_UPPER_LEG_THICCNESS):F4}, correcting offset of Y:{currentYDiff:F4} and Z:{currentZDiff:F4}");
            //since the character was offset by the current local position, we need to keep this one and add only the diff
            Vector3 currentLocalPosition = stationSeat.localPosition;
            //the ChairController is already alligned to x at start to make this work
            stationSeat.localPosition = new Vector3(currentLocalPosition.x, currentLocalPosition.y - currentYDiff, currentLocalPosition.z - currentZDiff);
            adjustCounter--;
            if (adjustCounter > 0 || (Time.timeSinceLevelLoad < AVATAR_LOAD_TIME && !isLocalPlayerInStation))
            {
                Log.Debug($"[RMStationController] Adjusting again in {ADJUSTMENT_DELAY} seconds.");
                MiscUtils.DelayFunction(ADJUSTMENT_DELAY, () =>
                {
                    AdjustPosition();
                });
            }
        }

        /// <summary>
        /// Is called from my player calibration script (https://reimajo.booth.pm/items/2753511) when the avatar changed
        /// This is externally called after setting _avatarHeight (happening after localPlayer changed their avatar)
        /// </summary>
        internal void OnAvatarChanged()
        {
            if (isLocalPlayerInStation)
            {
                Log.Debug($"[RMStationController] LocalPlayer is in station and changed avatar, informing all players about this change.");
                OnAvatarInStationChanged();
            }
        }

        /// <summary>
        /// Is called on the network for everyone when the player in the station changed their avatar
        /// </summary>
        public void OnAvatarInStationChanged()
        {
            if (adjustCounter > 0)
            {
                Log.Debug($"[RMStationController] (Remote) player in station changed avatar but we are already adjusting, skipping event.");
                return;
            }
            Log.Debug($"[RMStationController] (Remote) player in station changed avatar, adjusting position in {ADJUSTMENT_START_DELAY} seconds.");
            StartAdjusting();
        }
    }
}