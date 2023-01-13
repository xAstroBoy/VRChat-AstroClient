
#region Usings

using System;
using AstroClient;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Utility;
using Mono.Posix;
using UdonSharp;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;
#endregion Usings
namespace ReimajoBoothAssets
{
    /// <summary>
    /// Script can be as many times in the world as you want. 
    /// This bed/chair can also be easily toggled (collider or chair itself) with my Button & Slider asset.
    /// 
    /// You should NOT have "Transfer Ownership on Collision" enabled for this script.
    /// </summary>
    internal class ChairController : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        internal ChairController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

       
        internal VRC_AstroStation Station { get; set; }
        /// <summary>
        /// Activate only if the station should NOT control when the attached collider is active
        /// </summary>
        internal bool _disableColliderControl  { get; set; } = false;
        /// <summary>
        /// If enabled, pressing ESC or the menu button in VR will kick the player out of the station
        /// and leaving the station by pressing WASD is disabled instead.
        /// </summary>
        internal bool _enableStationMenuButtonExit  { get; set; } = false;

        /// <summary>
        /// The station transform
        /// </summary>
        internal Transform _stationSeat  { get; set; }
        /// <summary>
        /// An empty transform to mark the surface to sit on (up/green vector) and the front edge position of the seat (forward/blue axis).
        /// Must have the same parent as the ChairController.
        /// </summary>
        internal Transform _seatSurfaceUpAndFrontEdgeForward  { get; set; }
        /// <summary>
        /// An empty transform to mark the chair back surface to lean the back against (forward/blue axis).
        /// Must have the same parent as the ChairController.
        /// </summary>
        internal Transform _seatBackEndSurfaceForward  { get; set; }
        /// <summary>
        /// Collider of the bed/chair to walk on it, can be empty
        /// </summary>
        internal Collider _furnitureCollider  { get; set; }

        #region Settings
        /// <summary>
        /// How often <see cref="AdjustPosition"/> should get called after seating or changing avatar.
        /// While a single call would be enough, it's recommended to call this at least twice to provide a fast adjustement
        /// directly after seating, but then a more accurate re-adjustement later, since VRChat is still in the seating animation
        /// transition while seating, so a later adjustement is more accurate then the first initial one.
        /// </summary>
        internal const int ADJUSTMENT_COUNTS = 4;
        /// <summary>
        /// How much time should be between 2 calls of <see cref="AdjustPosition"/>,
        /// a value that is too small might lead to issues since bone positions are not very accurate
        /// and might be too old, so the adjusting can "overshoot" and spiral out of control in VRChat.
        /// It is recommended that ADJUSTMENT_START_DELAY + (ADJUSTMENT_DELAY * ADJUSTMENT_COUNTS) are
        ///  at least a second in total to eliminate inaccuracy caused by the seating animation itself.
        /// </summary>
        internal const float ADJUSTMENT_DELAY = 0.9f;
        /// <summary>
        /// How long to wait (after entering the station) until adjusting the player position.
        /// An earlier adjustement is less accurate, but eliminates a sudden jump which would be
        /// very noticeable if the first adjustement happens too late.
        /// </summary>
#if !DEBUG_ADJUST
        internal const float ADJUSTMENT_START_DELAY = 0.4f;
#else
        internal const float ADJUSTMENT_START_DELAY = 2f;
#endif
        /// <summary>
        /// How long we should re-adjust avatars in stations after entering a new world, assuming we first need to load their avatars
        /// </summary>
        internal const float AVATAR_LOAD_TIME = 8f;
        /// <summary>
        /// We assume linear scale, e.g. 0.0895f for an upperLeg with 0.2824 of joint distance, so we multiply by 0.3169f
        /// 
        ///  KnownThiccness   NewThiccness
        ///  -------------- = ----------------    =====>   NewThiccness = NewKnownDistance * KnownThiccness / KnownDistance
        ///  KnownDistance    NewKnownDistance
        ///  
        /// And this is why school math is usefull in life :)
        /// </summary>
        internal const float LEG_DISTANCE_TO_UPPER_LEG_THICCNESS = 0.3169f * 0.95f; //allow sinking into the chair by 5%
        /// <summary>
        /// Lower leg to upper leg ration can be ignored here. No need to allow sinking.
        /// </summary>
        internal const float LEG_DISTANCE_TO_LOWER_LEG_THICCNESS = 0.2869f;
        /// <summary>
        /// We assume linear scale, e.g. 0.0967 for an upperLeg with 0.2824 of joint distance, so we multiply by 0.3424f
        /// </summary>
        internal const float LEG_DISTANCE_TO_HIP_THICCNESS = 0.3424f * 0.95f; //allow sinking into the chair by 5%
        #endregion Settings
        #region PrivateFields
        /// <summary>
        /// If set to true, the interactable collider is disabled and will stay disabled when a player leaves the station
        /// </summary>
        internal bool _isStationDisabledByApi  { get; set; }= false;
        /// <summary>
        /// If set to true, the furniture collider is disabled and will stay disabled when a player leaves the station
        /// </summary>
        internal bool _isFurnitureColliderDisabledByApi  { get; set; } = false;
        internal Quaternion _localChairRotation { get; set; } 
#if !EXPOSE_FIELDS
        internal bool isLocalPlayerInStation { get; set; } 
#endif
#if RESET_POSITION
        internal Vector3 _localPositionAtStart;
#endif
        internal bool _colliderIsOn { get; set; } 
        internal int _adjustCounter { get; set; } 
        internal bool _isVR { get; set; } 
        #endregion PrivateFields
        #region StartSetup
        private void Start()
        {
            Station = this.GetOrAddComponent<VRC_AstroStation>();
            Station.StationTrigger.OnInteract += Interact;
            Station.OnStationEnterEvent += OnStationEntered;
            Station.OnStationExitEvent += OnStationExited;
            if (_enableStationMenuButtonExit)
            {
                _isVR = Networking.LocalPlayer.IsUserInVR();
                Station.disableStationExit = true;
            }
        }
        #endregion StartSetup
        #region StationExit
        /// <summary>
        /// Is called each frame when the localPlayer sits in the station when this station doesn't allow a regular station exit over WASD,
        /// to allow a station exit when the ESC key is pressed.
        /// </summary>
        internal void CheckStationExitButton()
        {
            if (isLocalPlayerInStation)
            {
                if (_isVR)
                {
#if LEFT_MENU_BUTTON_EXIT
                    if (Input.GetButtonDown("Oculus_CrossPlatform_Button4")) //left menu button
                        LocalPlayerExitStation();
#endif
#if RIGHT_MENU_BUTTON_EXIT
                    if (Input.GetButtonDown("Oculus_CrossPlatform_Button2")) //right menu button
                        LocalPlayerExitStation();
#endif
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Escape)) //ESC button
                        LocalPlayerExitStation();
                }
            }
        }
        #endregion StationExit
        #region AdjustPosition
        /// <summary>
        /// Starts adjusting the avatar height after the <see cref="ADJUSTMENT_START_DELAY"/>
        /// </summary>
        internal void StartAdjusting()
        {
            _adjustCounter = ADJUSTMENT_COUNTS;
            MiscUtils.DelayFunction(ADJUSTMENT_START_DELAY, () =>
            {
                AdjustPosition();
            } );
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
            Vector3 scale = _stationSeat.lossyScale;
            Vector3 refPointLocalPosition = _seatSurfaceUpAndFrontEdgeForward.localPosition;
            float refBoneDistance = Vector3.Distance(rightUpperLegJoint, rightLowerLegJoint);
            float currentYDiff = _seatSurfaceUpAndFrontEdgeForward.InverseTransformPoint(rightUpperLegJoint).y - ((refBoneDistance * LEG_DISTANCE_TO_UPPER_LEG_THICCNESS) / scale.y);
            float currentZDiff = _seatSurfaceUpAndFrontEdgeForward.InverseTransformPoint(rightLowerLegJoint).z - ((refBoneDistance * LEG_DISTANCE_TO_LOWER_LEG_THICCNESS) / scale.z);
            Vector3 hipJoint = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.Hips);
            if (hipJoint != Vector3.zero)
            {
                float currentHipDiff = _seatBackEndSurfaceForward.InverseTransformPoint(hipJoint).z - ((refBoneDistance * LEG_DISTANCE_TO_HIP_THICCNESS) / scale.z);
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
            Vector3 currentLocalPosition = _stationSeat.localPosition;
            //the ChairController is already alligned to x at start to make this work
            _stationSeat.localPosition = new Vector3(currentLocalPosition.x, currentLocalPosition.y - currentYDiff, currentLocalPosition.z - currentZDiff);
            _adjustCounter--;
            if (_adjustCounter > 0 || (Time.timeSinceLevelLoad < AVATAR_LOAD_TIME && !isLocalPlayerInStation))
            {
                Log.Debug($"[RMStationController] Adjusting again in {ADJUSTMENT_DELAY} seconds.");
                MiscUtils.DelayFunction(ADJUSTMENT_DELAY, () =>
                {
                    AdjustPosition();
                });
            }
        }
        #endregion AdjustPosition
        #region Calibration
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
        internal void OnAvatarInStationChanged()
        {
            if (_adjustCounter > 0)
            {
                Log.Debug($"[RMStationController] (Remote) player in station changed avatar but we are already adjusting, skipping event.");
                return;
            }
            Log.Debug($"[RMStationController] (Remote) player in station changed avatar, adjusting position in {ADJUSTMENT_START_DELAY} seconds.");
            StartAdjusting();
        }
        #endregion Calibration
        #region VRChatEvents
        /// <summary>
        /// Is called when LocalPlayer clicks on a station collider
        /// </summary>
        internal void Interact()
        {
            Log.Debug($"[RMStationController] LocalPlayer called Interact() on the station.");
            _localChairRotation = _stationSeat.localRotation;
            _stationSeat.rotation = Quaternion.identity;
            if (Utilities.IsValid(_furnitureCollider))
            {
                _colliderIsOn = _furnitureCollider.enabled;
                _furnitureCollider.enabled = false;
            }
            LocalPlayerEnterStation();
        }
        /// <summary>
        /// This is called for everyone on the network when a player entered the station. 
        /// It is possible that multiple player enter a station at once due to race conditions.
        /// </summary>
        /// <param name="playerWhoEntered">The player that entered the station</param>
        internal void OnStationEntered()
        {
            _stationSeat.localRotation = _localChairRotation;
            if (!_disableColliderControl)
            {
                Collider collider = this.GetComponent<Collider>();
                collider.enabled = false;
            }
            Log.Debug($"[RMStationController] LocalPlayer entered station, adjusting position in {ADJUSTMENT_START_DELAY} seconds.");
            isLocalPlayerInStation = true;
            if (_enableStationMenuButtonExit)
                CheckStationExitButton();
            //saving the last player who entered the station
            StartAdjusting();
        }
        /// <summary>
        /// Exits localPlayer from the station
        /// </summary>
        internal void LocalPlayerExitStation()
        {
            Station.ExitStation();
        }
        /// <summary>
        /// Enter the station as LocalPlayer
        /// </summary>
        internal void LocalPlayerEnterStation()
        {
            Station.EnterStation();
        }
        /// <summary>
        /// This is called for everyone on the network when a player exited the station. 
        /// It is possible that multiple player are in a station at once due to race conditions, so this
        /// event doesn't mean that the station is empty now.
        /// </summary>
        /// <param name="playerWhoExited">The player that exited the station</param>
        internal void OnStationExited()
        {
            if (isLocalPlayerInStation)
            {
                Log.Debug($"[RMStationController] LocalPlayer exited the chair.");
                isLocalPlayerInStation = false;
                //turn the collider back on if it was on before and is not set to be disabled by an external API call
                if (!_isFurnitureColliderDisabledByApi)
                    _furnitureCollider.enabled = _colliderIsOn;
            }
            //check if the last player who entered has now left the station
            LastPlayerLeftStation();

        }
        /// <summary>
        /// Must be called when the last player left this station
        /// </summary>
        internal void LastPlayerLeftStation()
        {
            Log.Debug($"[RMStationController] Last player exited the chair, resetting it's position.");
            if (!_disableColliderControl)
            {
                //make sure an external API call didn't disable the collider
                if (!_isStationDisabledByApi)
                {
                    Collider collider = this.GetComponent<Collider>();
                    collider.enabled = true;
                }
            }
        }
        #endregion VRChatEvents
    }
}
