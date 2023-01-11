using System;
using System.Collections.Generic;
using AstroClient;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using Harmony;
using UdonSharp;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
namespace ReimajoBoothAssets
{

    // TODO: Finish and adjust to make it work without udon.
    /// <summary>
    /// This script needs to be added in "SpaceShuttle/ShipController"
    /// </summary>
    [RegisterComponent]
    public class SpaceShuttleController : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public SpaceShuttleController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }




        /// <summary>
        /// Reference to the player currently inside the station, will be set from the Chair Controller
        /// </summary>
        internal VRCPlayerApi _stationEventPlayer { get; set; }
        /// <summary>
        /// This slider value ranging from 0 to 1 determines the flight stick sensitivity
        /// </summary>
        public float _sliderValue { get; set; } = 0.3f;
        /// <summary>
        /// The constant forward force that is applied to the constant force component on the ship
        /// </summary>
        private float _constantRelativeForwardForce { get; set; } = 600000;
        /// <summary>
        /// The constant backward force that is applied to the constant force component on the ship
        /// </summary>
        private float _constantRelativeBackwardForce { get; set; } = 100000;
        /// <summary>
        /// The horizontal thruster force that is applied to the constant force component on the ship
        /// when steering with the thumbstick
        /// </summary>
        private float _constantRelativeHorizontalForce { get; set; } = 100000;
        /// <summary>
        /// The vertical thruster force that is applied to the constant force component on the ship
        /// when steering with the thumbstick
        /// </summary>
        private float _constantRelativeVerticalForce { get; set; } = 100000;
        /// <summary>
        /// How fast the roll will accelerate in deskop mode, multiplier of delta time
        /// </summary>
        private float _desktopRollSpeedLerp { get; set; } = 2f;
        /// <summary>
        /// Maximum roll speed, in degrees. Should stay under 180.
        /// </summary>
        private float _maxRollSpeedDegrees { get; set; } = 90f; //was 100
        /// <summary>
        /// Minimum value when <see cref="_sliderValue"/> is 0
        /// </summary>
        private float _controlSensitivityMin { get; set; }  = 1.0f;
        /// <summary>
        /// Maximum value when <see cref="_sliderValue"/> is 1
        /// </summary>
        private float _controlSensitivityMax { get; set; } = 3.0f;
        /// <summary>
        /// Controller rotation offset for desktop players, so that they can look forward while flying instead of looking down
        /// </summary>
        private float _controllerXOffsetDesktopUser { get; set; } = 45f;
        /// <summary>
        /// Controller rotation offset for VR players, so that they can look forward while flying instead of looking down
        /// </summary>
        private float _controllerXOffsetVRUser { get; set; } = 0f;
        /// <summary>
        /// All desktop buttons which will be disabled unless the player is in the spaceship.
        /// </summary>
        
        private List<GameObject> _desktopButtons { get; set; }
        /// <summary>
        /// Gear down button highlight (shown when the gears are down & the player is in the spaceship)
        /// </summary>
        
        private GameObject _buttonHighlightGearDown { get; set; }
        /// <summary>
        /// Flight assist button highlight (shown when the flight assist is on & the player is in the spaceship)
        /// </summary>
        
        private GameObject _buttonHighlightFlightAssist { get; set; }
        /// <summary>
        /// Custom center of gravity of the ship
        /// </summary>
        private Transform _customCenterOfGravity { get; set; }
        /// <summary>
        /// Animator of the space shuttle
        /// </summary>
        private Animator _animator { get; set; }
        /// <summary>
        /// AudioSource to play the gear deploy sound
        /// </summary>
        private AudioSource _gearDeployAudioSource { get; set; }
        /// <summary>
        /// AudioClip for the gear deploy (gear in) sound
        /// </summary>
        private AudioClip _gearInSound { get; set; }
        /// <summary>
        /// AudioClip for the gear deploy (gear out) sound
        /// </summary>
        private AudioClip _gearOutSound { get; set; }
        /// <summary>
        /// Root of the Flight Stick (local pickup object), will be re-set to the local position at start when it's released
        /// </summary>
        private Transform _flightStickRoot { get; set; }
        /// <summary>
        /// Nav ball bone (Instrumentation)
        /// </summary>
        private Transform _navBall { get; set; }
        /// <summary>
        /// Speed indicator bone (Instrumentation)
        /// </summary>
        private Transform _speedIndicatorBone { get; set; }
        /// <summary>
        /// Altitude indicator bone (Instrumentation)
        /// </summary>
        private Transform _altitudeIndicatorBone { get; set; }
        /// <summary>
        /// Rigidbody of the ship, will be toggled between kinematic / non-kinematic
        /// </summary>
        private Rigidbody Ship { get; set; }
        /// <summary>
        /// The pilot's chair of the ship (VRCStation)
        /// </summary>
        private ChairController _pilotChairStation { get; set; }
        /// <summary> Backwards pointing main truster number 1/3 </summary>
        private Transform _backwardMTRs1 { get; set; }
        /// <summary> Backwards pointing main truster number 2/3 </summary>
        private Transform _backwardMTRs2 { get; set; }
        /// <summary> Backwards pointing main truster number 3/3 </summary>
        private Transform _backwardMTRs3 { get; set; }
        /// <summary> Backwards pointing cold gas truster number 1/2 </summary>
        private Transform _backwardCTRs1 { get; set; }
        /// <summary> Backwards pointing cold gas truster number 2/2 </summary>
        private Transform _backwardCTRs2 { get; set; }
        /// <summary> Forward pointing cold gas truster number 1/2 </summary>
        private Transform _frontForwardCTR1 { get; set; }
        /// <summary> Forward pointing cold gas truster number 2/2 </summary>
        private Transform _frontForwardCTR2{ get; set; }
        /// <summary> Forward pointing cold gas truster on the front left </summary>
        private Transform _frontLeftCTR { get; set; }
        /// <summary> Forward pointing cold gas truster on the front right </summary>
        private Transform _frontRightCTR { get; set; }
        /// <summary> Upward pointing cold gas truster on the front left </summary>
        private Transform _upFrontLeftCTR { get; set; }
        /// <summary> Upward pointing cold gas truster on the front right </summary>
        private Transform _upFrontRightCTR { get; set; }
        /// <summary> Upward pointing cold gas truster on the far left / middle (wing) </summary>
        private Transform _upLeftCTR { get; set; }
        /// <summary> Upward pointing cold gas truster on the far right / middle (wing) </summary>
        private Transform _upRightCTR{ get; set; }
        /// <summary> Downward pointing cold gas truster on the far left / middle (wing) </summary>
        private Transform _downLeftCTR { get; set; }
        /// <summary> Downward pointing cold gas truster on the far right / middle (wing) </summary>
        private Transform _downRightCTR { get; set; }
        /// <summary> Downward pointing cold gas truster on the front left </summary>
        private Transform _downFrontLeftCTR { get; set; }
        /// <summary> Downward pointing cold gas truster on the front right </summary>
        private Transform _downFrontRightCTR { get; set; }
        /// <summary> Backward pointing cold gas truster on the back left </summary>
        private Transform _backLeftCTR { get; set; }
        /// <summary> Backward pointing cold gas truster on the back right </summary>
        private Transform _backRightCTR { get; set; }
        /// <summary> Bone of the space ship armature that moves the joystick visually </summary>
        private Transform _joystickBone { get; set; }

        private float _oldForwardThrustTriggerInput{ get; set; }
        //particle systems fetched from the transform objects
        private ParticleSystem _backwardMainPS1{ get; set; }
        private ParticleSystem _backwardMainPS2{ get; set; }
        private ParticleSystem _backwardMainPS3{ get; set; }
        private ParticleSystem _backwardSlowPS1{ get; set; }
        private ParticleSystem _backwardSlowPS2{ get; set; }
        private ParticleSystem _frontForwardPS1{ get; set; }
        private ParticleSystem _frontForwardPS2{ get; set; }
        private ParticleSystem _frontLeftPS{ get; set; }
        private ParticleSystem _frontRightPS{ get; set; }
        private ParticleSystem _upFrontLeftPS{ get; set; }
        private ParticleSystem _upFrontRightPS{ get; set; }
        private ParticleSystem _upLeftPS{ get; set; }
        private ParticleSystem _upRightPS{ get; set; }
        private ParticleSystem _downLeftPS{ get; set; }
        private ParticleSystem _downRightPS{ get; set; }
        private ParticleSystem _downFrontLeftPS{ get; set; }
        private ParticleSystem _downFrontRightPS{ get; set; }
        private ParticleSystem _backLeftPS{ get; set; }
        private ParticleSystem _backRightPS{ get; set; }
        //audio sources
        private AudioSource _backwardMainASs{ get; set; }
        private AudioSource _backwardSlowAS1{ get; set; }
        private AudioSource _backwardSlowAS2{ get; set; }
        private AudioSource _frontForwardAS1{ get; set; }
        private AudioSource _frontForwardAS2{ get; set; }
        private AudioSource _frontLeftAS{ get; set; }
        private AudioSource _frontRightAS{ get; set; }
        private AudioSource _upFrontLeftAS{ get; set; }
        private AudioSource _upFrontRightAS{ get; set; }
        private AudioSource _upLeftAS{ get; set; }
        private AudioSource _upRightAS{ get; set; }
        private AudioSource _downLeftAS{ get; set; }
        private AudioSource _downRightAS{ get; set; }
        private AudioSource _downFrontLeftAS{ get; set; }
        private AudioSource _downFrontRightAS{ get; set; }
        private AudioSource _backLeftAS{ get; set; }
        private AudioSource _backRightAS{ get; set; }
        //new state for the particle system (true if active)
        private bool _backwardMain{ get; set; }
        private bool _backwardSlow{ get; set; }
        private bool _frontForward{ get; set; }
        private bool _frontLeft{ get; set; }
        private bool _frontRight{ get; set; }
        private bool _upFrontLeft{ get; set; }
        private bool _upFrontRight{ get; set; }
        private bool _upLeft{ get; set; }
        private bool _upRight{ get; set; }
        private bool _downLeft{ get; set; }
        private bool _downRight{ get; set; }
        private bool _downFrontLeft{ get; set; }
        private bool _downFrontRight{ get; set; }
        private bool _backLeft{ get; set; }
        private bool _backRight{ get; set; }

        private bool _gearDown { get; set; }

        //current state of the particle system (true if active)
        private bool _backwardMain_PS_ON{ get; set; }
        private bool _backwardSlow_PS_ON{ get; set; }
        private bool _frontForward_PS_ON{ get; set; }
        private bool _frontLeft_PS_ON{ get; set; }
        private bool _frontRight_PS_ON{ get; set; }
        private bool _upFrontLeft_PS_ON{ get; set; }
        private bool _upFrontRight_PS_ON{ get; set; }
        private bool _upLeft_PS_ON{ get; set; }
        private bool _upRight_PS_ON{ get; set; }
        private bool _downLeft_PS_ON{ get; set; }
        private bool _downRight_PS_ON{ get; set; }
        private bool _downFrontLeft_PS_ON{ get; set; }
        private bool _downFrontRight_PS_ON{ get; set; }
        private bool _backLeft_PS_ON{ get; set; }
        private bool _backRight_PS_ON{ get; set; }
        //is true when any of the particle systems should change their state
        private ConstantForce _constantForceShipComponent{ get; set; }
        private VRC_AstroPickup _flightStickPickup{ get; set; }
        private float _forwardSpeed{ get; set; }
        private float _controlSensitivitySpan{ get; set; }
        private float _currentControlSensitivity{ get; set; }
        private bool _localPlayerIsInStationSeat{ get; set; }
        private float _rollAngleInput{ get; set; }
        private bool _addControllerOffset{ get; set; }
        private bool _stickIsHeld { get; set; }
        private float _fadeOutTime{ get; set; }
        private Vector3 _localFlightStickLocalResetPosition{ get; set; }
        private Quaternion _localFlightStickLocalResetRotation{ get; set; }
        private Quaternion _steeringOffset{ get; set; }
        private Quaternion _currentFlightStickRotation{ get; set; }
        private GameObject ShipGameObject{ get; set; }
        private Rigidbody ShipRigidbody{ get; set; }
        private float _forwardBackwardThrust{ get; set; }
        private float _upDownThrustInput{ get; set; }
        private float _leftRightThrustInput{ get; set; }
        private float _controllerXOffset{ get; set; }
        private bool _isVR{ get; set; }
        private string INDEX_TRIGGER_PICKUP_HAND_NAME { get; set; }  //is set at runtime
        private string INDEX_TRIGGER_OTHER_HAND_NAME{ get; set; }  //is set at runtime
        private const string INDEX_TRIGGER_RIGHT = "Oculus_CrossPlatform_SecondaryIndexTrigger";
        private const string INDEX_TRIGGER_LEFT = "Oculus_CrossPlatform_PrimaryIndexTrigger";
#if RIGHT_HAND_THUMBSTICK
        private const string HORIZONTAL_INPUT_AXIS_NAME = "Oculus_CrossPlatform_SecondaryThumbstickHorizontal"; //right hand
        private const string VERTICAL_INPUT_AXIS_NAME = "Oculus_CrossPlatform_SecondaryThumbstickVertical"; //right hand
#else
        private const string HORIZONTAL_INPUT_AXIS_NAME = "Horizontal"; //left hand
        private const string VERTICAL_INPUT_AXIS_NAME = "Vertical"; //left hand
#endif
        /// <summary>
        /// Offset for the space ship parameter applied onto the "V" parameter (vertical movement)
        /// </summary>
        private const float V_OFFSET = 0.08f; //our space shuttle animator requires this offset
        /// <summary>
        /// Offset for the space ship parameter applied onto the "R" parameter (rotational movement)
        /// </summary>
        private const float R_OFFSET = 0.035f; //our space shuttle animator requires this offset
        /// <summary>
        /// Biggest negative joystick angle that is accepted, everything bigger is capped
        /// </summary>
        private const float MIN_JOYSTICK_TILT = -32;
        /// <summary>
        /// Biggest positive joystick angle that is accepted, everything bigger is capped
        /// </summary>
        private const float MAX_JOYSTICK_TILT = 32;
        /// <summary>
        /// How long the input "fades out" when the stick is dropped.
        /// </summary>
        private const float FADE_OUT_TIME = 2f;
        /// <summary>
        /// Minimum thumbstick input for the thruster system to be active. Anything below is considered as no input (deadzone).
        /// </summary>
        private const float MIN_STICK_INPUT = 0.05f;
        /// <summary>
        /// Trigger input threshold which is considered as moving slow (uses cold gas trusters). Anything above will fire the main trusters.
        /// </summary>
        private const float SLOW_TRIGGER_INPUT = 0.2f;
        /// <summary>
        /// Minimum joystick input in degrees for the steering system to be active. Anything below is considered as no input (deadzone).
        /// </summary>
        private const float MIN_AXIS_INPUT = 5f;
        /// <summary>
        /// The input that is set locally if the remote user steers in the negative direction. Must be between -1 and 0.
        /// </summary>
        private const float NEGATIVE_REMOTE_STEERING = -0.5f;
        /// <summary>
        /// The input that is set locally if the remote user doesn't steer in any direction. Must be between -1 and 1.
        /// This should be 0 unless your animator is weird.
        /// </summary>
        private const float NEUTRAL_REMOTE_STEERING = 0;
        /// <summary>
        /// The input that is set locally if the remote user steers in the positive direction. Must be between 1 and 0.
        /// </summary>
        private const float POSITIVE_REMOTE_STEERING = 0.5f;

        /// <summary>
        /// This code to setup the cold gas thrusters is auto-generated with my publicly 
        /// available tool https://github.com/Reimajo/HorribleUdonNetworkingCodeGenerator
        /// Template:
        /// #1#PS = #1#CTR.GetComponentInChildren<ParticleSystem>();
        /// Array 1: _frontLeft,_frontRight,_frontMiddle,_upBack,_upFront,_upLeft,_upRight,_downLeft,_downRight,_downBack,_downFront,_backLeft,_backRight
        /// </summary>
        ///
        
        private void SetupColdGasThrusters()
        {
            //fetch particle systems
            _backwardMainPS1 = _backwardMTRs1.GetComponentInChildren<ParticleSystem>();
            _backwardMainPS2 = _backwardMTRs2.GetComponentInChildren<ParticleSystem>();
            _backwardMainPS3 = _backwardMTRs3.GetComponentInChildren<ParticleSystem>();
            _backwardSlowPS1 = _backwardCTRs1.GetComponentInChildren<ParticleSystem>();
            _backwardSlowPS2 = _backwardCTRs2.GetComponentInChildren<ParticleSystem>();
            _frontForwardPS1 = _frontForwardCTR1.GetComponentInChildren<ParticleSystem>();
            _frontForwardPS2 = _frontForwardCTR2.GetComponentInChildren<ParticleSystem>();
            _frontLeftPS = _frontLeftCTR.GetComponentInChildren<ParticleSystem>();
            _frontRightPS = _frontRightCTR.GetComponentInChildren<ParticleSystem>();
            _upFrontLeftPS = _upFrontLeftCTR.GetComponentInChildren<ParticleSystem>();
            _upFrontRightPS = _upFrontRightCTR.GetComponentInChildren<ParticleSystem>();
            _upLeftPS = _upLeftCTR.GetComponentInChildren<ParticleSystem>();
            _upRightPS = _upRightCTR.GetComponentInChildren<ParticleSystem>();
            _downLeftPS = _downLeftCTR.GetComponentInChildren<ParticleSystem>();
            _downRightPS = _downRightCTR.GetComponentInChildren<ParticleSystem>();
            _downFrontLeftPS = _downFrontLeftCTR.GetComponentInChildren<ParticleSystem>();
            _downFrontRightPS = _downFrontRightCTR.GetComponentInChildren<ParticleSystem>();
            _backLeftPS = _backLeftCTR.GetComponentInChildren<ParticleSystem>();
            _backRightPS = _backRightCTR.GetComponentInChildren<ParticleSystem>();
            //fetch audio sources
            _backwardMainASs = _backwardMainPS1.GetComponentInChildren<AudioSource>();
            _backwardSlowAS1 = _backwardSlowPS1.GetComponentInChildren<AudioSource>();
            _backwardSlowAS2 = _backwardSlowPS2.GetComponentInChildren<AudioSource>();
            _frontForwardAS1 = _frontForwardCTR1.GetComponentInChildren<AudioSource>();
            _frontForwardAS2 = _frontForwardCTR2.GetComponentInChildren<AudioSource>();
            _frontLeftAS = _frontLeftCTR.GetComponentInChildren<AudioSource>();
            _frontRightAS = _frontRightCTR.GetComponentInChildren<AudioSource>();
            _upFrontLeftAS = _upFrontLeftCTR.GetComponentInChildren<AudioSource>();
            _upFrontRightAS = _upFrontRightCTR.GetComponentInChildren<AudioSource>();
            _upLeftAS = _upLeftCTR.GetComponentInChildren<AudioSource>();
            _upRightAS = _upRightCTR.GetComponentInChildren<AudioSource>();
            _downLeftAS = _downLeftCTR.GetComponentInChildren<AudioSource>();
            _downRightAS = _downRightCTR.GetComponentInChildren<AudioSource>();
            _downFrontLeftAS = _downFrontLeftCTR.GetComponentInChildren<AudioSource>();
            _downFrontRightAS = _downFrontRightCTR.GetComponentInChildren<AudioSource>();
            _backLeftAS = _backLeftCTR.GetComponentInChildren<AudioSource>();
            _backRightAS = _backRightCTR.GetComponentInChildren<AudioSource>();
        }
        /// <summary>
        /// Disables all thrusters. This is only called from the object owner.
        /// </summary>
        private void DisableAllThrusters()
        {
            _backwardMain = false;
            _backwardSlow = false;
            _frontForward = false;
            _frontLeft = false;
            _frontRight = false;
            _upFrontLeft = false;
            _upFrontRight = false;
            _upLeft = false;
            _upRight = false;
            _downLeft = false;
            _downRight = false;
            _downFrontLeft = false;
            _downFrontRight = false;
            _backLeft = false;
            _backRight = false;
            UpdateColdGasBoosters();
        }

        /// <summary>
        /// Bool checks (without negation) don't cause expensive extern instructions in the Udon VM!
        /// It's free real estate.
        /// </summary>
        private void UpdateColdGasBoosters()
        {
            // update all upwards pointing particle systems if needed
            if (_upFrontLeft)
            {
                if (_upFrontLeft_PS_ON) { }
                else
                {
                    _upFrontLeft_PS_ON = true;
                    _upFrontLeftPS.Play();
                }
            }
            else
            {
                if (_upFrontLeft_PS_ON)
                {
                    _upFrontLeft_PS_ON = false;
                    _upFrontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                }
            }

            if (_upFrontRight)
            {
                if (_upFrontRight_PS_ON) { }
                else
                {
                    _upFrontRight_PS_ON = true;
                    _upFrontRightPS.Play();
                }
            }
            else
            {
                if (_upFrontRight_PS_ON)
                {
                    _upFrontRight_PS_ON = false;
                    _upFrontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                }
            }

            if (_upLeft)
            {
                if (_upLeft_PS_ON) { }
                else
                {
                    _upLeft_PS_ON = true;
                    _upLeftPS.Play();
                }
            }
            else
            {
                if (_upLeft_PS_ON)
                {
                    _upLeft_PS_ON = false;
                    _upLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                }
            }

            if (_upRight)
            {
                if (_upRight_PS_ON) { }
                else
                {
                    _upRight_PS_ON = true;
                    _upRightPS.Play();
                    _upRightAS.Play();
                }
            }
            else
            {
                if (_upRight_PS_ON)
                {
                    _upRight_PS_ON = false;
                    _upRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _upRightAS.Stop();
                }
            }

            // update all downwards pointing particle systems if needed
            if (_downFrontLeft)
            {
                if (_downFrontLeft_PS_ON) { }
                else
                {
                    _downFrontLeft_PS_ON = true;
                    _downFrontLeftPS.Play();
                    _downFrontLeftAS.Play();
                }
            }
            else
            {
                if (_downFrontLeft_PS_ON)
                {
                    _downFrontLeft_PS_ON = false;
                    _downFrontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _downFrontLeftAS.Stop();
                }
            }

            if (_downFrontRight)
            {
                if (_downFrontRight_PS_ON) { }
                else
                {
                    _downFrontRight_PS_ON = true;
                    _downFrontRightPS.Play();
                    _downFrontRightAS.Play();
                }
            }
            else
            {
                if (_downFrontRight_PS_ON)
                {
                    _downFrontRight_PS_ON = false;
                    _downFrontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _downFrontRightAS.Stop();
                }
            }

            if (_downLeft)
            {
                if (_downLeft_PS_ON) { }
                else
                {
                    _downLeft_PS_ON = true;
                    _downLeftPS.Play();
                    _downLeftAS.Play();
                }
            }
            else
            {
                if (_downLeft_PS_ON)
                {
                    _downLeft_PS_ON = false;
                    _downLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _downLeftAS.Stop();
                }
            }

            if (_downRight)
            {
                if (_downRight_PS_ON) { }
                else
                {
                    _downRight_PS_ON = true;
                    _downRightPS.Play();
                    _downRightAS.Play();
                }
            }
            else
            {
                if (_downRight_PS_ON)
                {
                    _downRight_PS_ON = false;
                    _downRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _downRightAS.Stop();
                }
            }

            //left right

            if (_frontLeft)
            {
                if (_frontLeft_PS_ON) { }
                else
                {
                    _frontLeft_PS_ON = true;
                    _frontLeftPS.Play();
                    _frontLeftAS.Play();
                }
            }
            else
            {
                if (_frontLeft_PS_ON)
                {
                    _frontLeft_PS_ON = false;
                    _frontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _frontLeftAS.Stop();
                }
            }

            if (_frontRight)
            {
                if (_frontRight_PS_ON) { }
                else
                {
                    _frontRight_PS_ON = true;
                    _frontRightPS.Play();
                    _frontRightAS.Play();
                }
            }
            else
            {
                if (_frontRight_PS_ON)
                {
                    _frontRight_PS_ON = false;
                    _frontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _frontRightAS.Stop();
                }
            }

            if (_backLeft)
            {
                if (_backLeft_PS_ON) { }
                else
                {
                    _backLeft_PS_ON = true;
                    _backLeftPS.Play();
                    _backLeftAS.Play();
                }
            }
            else
            {
                if (_backLeft_PS_ON)
                {
                    _backLeft_PS_ON = false;
                    _backLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _backLeftAS.Stop();
                }
            }

            if (_backRight)
            {
                if (_backRight_PS_ON) { }
                else
                {
                    _backRight_PS_ON = true;
                    _backRightPS.Play();
                    _backRightAS.Play();
                }
            }
            else
            {
                if (_backRight_PS_ON)
                {
                    _backRight_PS_ON = false;
                    _backRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _backRightAS.Stop();
                }
            }

            //forward main boosters
            if (_backwardMain)
            {
                if (_backwardMain_PS_ON) { }
                else
                {
                    _backwardMain_PS_ON = true;
                    _backwardMainPS1.Play();
                    _backwardMainPS2.Play();
                    _backwardMainPS3.Play();
                    _backwardMainASs.Play();
                }
            }
            else
            {
                if (_backwardMain_PS_ON)
                {
                    _backwardMain_PS_ON = false;
                    _backwardMainPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _backwardMainPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _backwardMainPS3.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _backwardMainASs.Stop();
                }
            }

            //forward Slow boosters
            if (_backwardSlow)
            {
                if (_backwardSlow_PS_ON) { }
                else
                {
                    _backwardSlow_PS_ON = true;
                    _backwardSlowPS1.Play();
                    _backwardSlowPS2.Play();
                    _backwardSlowAS1.Play();
                    _backwardSlowAS2.Play();
                }
            }
            else
            {
                if (_backwardSlow_PS_ON)
                {
                    _backwardSlow_PS_ON = false;
                    _backwardSlowPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _backwardSlowPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _backwardSlowAS1.Stop();
                    _backwardSlowAS2.Stop();
                }
            }

            //backward boosters
            if (_frontForward)
            {
                if (_frontForward_PS_ON) { }
                else
                {
                    _frontForward_PS_ON = true;
                    _frontForwardPS1.Play();
                    _frontForwardAS1.Play();
                    _frontForwardPS2.Play();
                    _frontForwardAS2.Play();
                }
            }
            else
            {
                if (_frontForward_PS_ON)
                {
                    _frontForward_PS_ON = false;
                    _frontForwardPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _frontForwardAS1.Stop();
                    _frontForwardPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    _frontForwardAS2.Stop();
                }
            }
        }

        /// <summary>
        /// Is called from an external slider when <see cref="_sliderValue"/> changed
        /// </summary>
        public void _SliderValueChanged()
        {
            _currentControlSensitivity = _controlSensitivityMin + (_sliderValue * _controlSensitivitySpan);
        }

        /// <summary>
        /// Is called when a button in the cockpit is pressed.
        /// </summary>
        public void OnButtonDown(int id)
        {
            switch (id)
            {
                case 0:
                    _ToggleFlightAssist();
                    break;
                case 1:
                    _ToggleGearDown();
                    break;
                case 2:
                    if (_localPlayerIsInStationSeat)
                    {
                        _pilotChairStation.Station.ExitStation();
                    }
                    break;
            }
        }
        /// <summary>
        /// Toggles the flight assist on/off, default is on.
        /// </summary>
        public void _ToggleGearDown()
        {
            _gearDeployAudioSource.Stop();
            _gearDown = !_gearDown;
            if (_gearDown)
            {
                _gearDeployAudioSource.clip = _gearOutSound;
                _gearDeployAudioSource.Play();
            }
            else
            {
                _gearDeployAudioSource.clip = _gearInSound;
                _gearDeployAudioSource.Play();
            }
            _buttonHighlightGearDown.SetActive(_gearDown);
            _animator.SetBool("LandingGearDeployed", _gearDown);
        }

        private bool _flightAssistOn = true;
        /// <summary>
        /// Toggles the flight assist on/off, default is on.
        /// </summary>
        public void _ToggleFlightAssist()
        {
            _flightAssistOn = !_flightAssistOn;
            _buttonHighlightFlightAssist.SetActive(_flightAssistOn);
            ApplyFlightAssistSetting();
        }
        private void ApplyFlightAssistSetting()
        {
            if (_flightAssistOn)
            {
                ShipRigidbody.drag = 1;
                ShipRigidbody.angularDrag = 1;
            }
            else
            {
                ShipRigidbody.drag = 0.01f;
                ShipRigidbody.angularDrag = 1f;
            }
        }

        /// <summary>
        /// Is called once at the start of the world to setup the script
        /// </summary>
        public void Start()
        {
            #region Setup Shuttle  Variables
            var root = this.gameObject.transform.root;
            var Desktop0 = root.FindObject($"Space Shuttle Model/Armature/Root/DashboardButton.R/_desktopButton0").gameObject;
            if (Desktop0 != null)
            {
                var interact = Desktop0.GetOrAddComponent<VRC_AstroInteract>();
                if (interact != null)
                {
                    interact.InteractionText = "Toggle Pro Mode";
                    interact.proximity = 0.05f;
                    interact.OnInteract = () =>
                    {
                        this.OnButtonDown(0);
                    };
                }
                _desktopButtons.Add(Desktop0);
            }
            var Desktop1 = root.FindObject($"Space Shuttle Model/Armature/Root/DashboardButton.L/_desktopButton1").gameObject;
            if (Desktop1 != null)
            {
                var interact = Desktop1.GetOrAddComponent<VRC_AstroInteract>();
                if (interact != null)
                {
                    interact.InteractionText = "Toggle Gear";
                    interact.proximity = 0.05f;
                    interact.OnInteract = () =>
                    {
                        this.OnButtonDown(1);
                    };
                }
                _desktopButtons.Add(Desktop1);
            }
            var Desktop2 =root.FindObject($"Space Shuttle Model/Armature/Root/EjectButton/_desktopButton2").gameObject;
            if (Desktop2 != null)
            {
                var interact = Desktop2.GetOrAddComponent<VRC_AstroInteract>();
                if (interact != null)
                {
                    interact.InteractionText = "Exit Space Ship";
                    interact.proximity = 0.05f;
                    interact.OnInteract = () =>
                    {
                        this.OnButtonDown(2);
                    };
                }
                _desktopButtons.Add(Desktop2);
            }
            _buttonHighlightGearDown = root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.L/ButtonHighlightGearDown").gameObject;
            _buttonHighlightFlightAssist = root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.R/ButtonHighlightFlightAssist").gameObject;
            _customCenterOfGravity = root.FindObject("CustomCG");
            _animator = root.FindObject("Space Shuttle Model").GetComponent<Animator>();
            _gearDeployAudioSource = root.FindObject("_audioSourceGearDeploySound").GetComponent<AudioSource>();
            _flightStickRoot = this.transform;
            _navBall = root.FindObject("Space Shuttle Model/Armature/Root/NavBallParent/NavballRotateHere");
            _speedIndicatorBone = root.FindObject("Space Shuttle Model/Armature/Root/Speedometer");
            _altitudeIndicatorBone = root.FindObject("Space Shuttle Model/Armature/Root/Altimeter");
            _pilotChairStation = root.FindObject("SelfAdjustingChair_Pilot/ChairController").GetOrAddComponent<ChairController>();

            #endregion

            foreach (var button in _desktopButtons)
            {
                button.SetActive(false);
            }
            DisableButtonHighlights();
            SetupColdGasThrusters();
            _controlSensitivitySpan = _controlSensitivityMax - _controlSensitivityMin;
            _SliderValueChanged(); //apply the calculated _controlSensitivitySpan
            _constantForceShipComponent = Ship.GetComponent<ConstantForce>();
            ShipRigidbody = Ship.GetComponent<Rigidbody>();
            ApplyFlightAssistSetting();
            if (_customCenterOfGravity)
            {
                ShipRigidbody.centerOfMass = _customCenterOfGravity.localPosition;
            }
            _flightStickPickup = _flightStickRoot.GetOrAddComponent<VRC_AstroPickup>();
            if (_constantForceShipComponent)
            {
                _constantForceShipComponent.relativeForce = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.LogError("[ShipController] There is no constant force component attached to the ship's rigidbody.");
            }
            Ship.isKinematic = true;
            _flightStickPickup.pickupable = false;
            _isVR = Networking.LocalPlayer.IsUserInVR();
            _controllerXOffset = _isVR ? _controllerXOffsetVRUser : _controllerXOffsetDesktopUser;
            if (_controllerXOffset != 0)
            {
                _addControllerOffset = true;
                Debug.Log($"[ShipController] Adding controller X-Offset with {_controllerXOffset} degrees.");
                _steeringOffset = Quaternion.Euler(_controllerXOffset, 0, 0);
            }
            StoreLocalStickPositionOffset();
            if (_constantRelativeVerticalForce > 0)
                _constantRelativeVerticalForce = -_constantRelativeVerticalForce;
            if (_constantRelativeBackwardForce < 0)
                _constantRelativeBackwardForce = -_constantRelativeBackwardForce;
            _animator.SetBool("LandingGearDeployed", _gearDown);
            ResetAnimator();
        }
        /// <summary>
        /// Resets the space shuttle animator to be in the neutral steering position
        /// </summary>
        private void ResetAnimator()
        {
            _animator.SetFloat("V", value: 0 + V_OFFSET);
            _animator.SetFloat("H", value: 0);
            _animator.SetFloat("R", value: 0.5f + R_OFFSET);
        }

        /// <summary>
        /// Is called each frame after the stick was dropped 
        /// for <see cref="FADE_OUT_TIME"/> seconds to smoothly
        /// fade out the rotational steering 
        /// </summary>
        public void _UpdateFadeOut()
        {
            while (true)
            {
                if (_stickIsHeld) return;
                if (Networking.IsOwner(ShipGameObject))
                {
                    _fadeOutTime += Time.deltaTime;
                    if (_fadeOutTime < FADE_OUT_TIME)
                    {
                        ShipRigidbody.MoveRotation(Quaternion.Slerp(ShipRigidbody.rotation, _currentFlightStickRotation, _currentControlSensitivity * Time.deltaTime));
                        continue;
                    }
                    else
                    {
                        Log.Debug("Stopped fade-out update.");
                    }
                }

                break;
            }
        }


        /// <summary>
        /// Is called every frame while the player is in the station to 
        /// update the instruments and run the buttons
        /// </summary>
        public void _UpdateWhileInStation()
        {
            if (_localPlayerIsInStationSeat)
            {
                UpdateInstruments();
                Vector3 localRotation = _flightStickRoot.localEulerAngles;
                if (_isVR)
                {
                    float inputX = (_flightStickRoot.localRotation.eulerAngles.x + _controllerXOffset) % 360;
                    if (inputX > 180) inputX -= 360;
                    float inputY = _flightStickRoot.localRotation.eulerAngles.y % 360;
                    if (inputY > 180) inputY -= 360;
                    float inputZ = _flightStickRoot.localRotation.eulerAngles.z % 360;
                    if (inputZ > 180) inputZ -= 360;
                    float inputXClamped = Mathf.Clamp(inputX, MIN_JOYSTICK_TILT, MAX_JOYSTICK_TILT);
                    float inputYClamped = Mathf.Clamp(inputY, MIN_JOYSTICK_TILT, MAX_JOYSTICK_TILT);
                    float inputZClamped = Mathf.Clamp(inputZ, MIN_JOYSTICK_TILT, MAX_JOYSTICK_TILT);
                    //joystick is already driven by animation --> _joystickBone.localEulerAngles = new Vector3(inputXClamped, 0, inputZClamped);
                    //pitch up-> joystick back -> V:1 (Pitch&Yaw layer)
                    //pitch down-> joystick front -> V:-1 (Pitch&Yaw layer)
                    _animator.SetFloat("V", value: (-inputXClamped / MAX_JOYSTICK_TILT) + V_OFFSET);
                    //turn left-> thumbstick left -> H:-1 (Pitch&Yaw layer)
                    //turn right-> thumbstick right -> H:1 (Pitch&Yaw layer)
                    _animator.SetFloat("H", value: inputYClamped / MAX_JOYSTICK_TILT);
                    //roll left-> joystick left -> R:0 (Pitch&Yaw layer)
                    //roll right-> joystick right -> R:1 (Pitch&Yaw layer)
                    _animator.SetFloat("R", value: (((inputZClamped / MAX_JOYSTICK_TILT) + 1) * 0.5f) + R_OFFSET);
                    //JTH Joystick Thumbstick horizontal
                    _animator.SetFloat("JTH", value: _leftRightThrustInput);
                    //JTV Joystick Thumbstick vertical
                    _animator.SetFloat("JTV", value: _upDownThrustInput);
                    //TTH Throttle Thumbstick horizontal
                    //TTV Throttle Thumbstick vertical
                    //Throttle 0-1
                    _animator.SetFloat("Throttle", value: (_forwardBackwardThrust > 0 ? _forwardBackwardThrust / _constantRelativeForwardForce : 0));
                    //LandingGearDeployed (bool)
                }
            }
        }
        /// <summary>
        /// Updates the nav ball, speed and height indicator.
        /// The navball part was an absolute pain and is still not perfect. 
        /// Additional thanks goes to NotFish who suffered endlessly to try to make the navball work in all angles.
        /// </summary>
        private void UpdateInstruments()
        {
#pragma warning disable IDE0018 // Inline variable declaration is not possible in Udon right now
            Vector3 axisVector;
            float axisRotation;
#pragma warning restore IDE0018

            ShipGameObject.transform.rotation.ToAngleAxis(out axisRotation, out axisVector);

            //Mirror pitch
            axisVector.y *= -1;
            _navBall.localRotation = Quaternion.AngleAxis(axisRotation, axisVector);

            //moves from 90 (zero) to -90 (max)
            _altitudeIndicatorBone.localEulerAngles = new Vector3(-74.413f, 180, 83.6f - (173.6f * Mathf.Clamp01(ShipGameObject.transform.position.y / 400)));
            //moves from 90 (zero) to -90 (max)
            _speedIndicatorBone.localEulerAngles = new Vector3(-74.413f, 180, 83.6f - (173.6f * Mathf.Clamp01(ShipRigidbody.velocity.magnitude / 60)));
        }

        /// <summary>
        /// Is called in every frame while the controller is held in hand for VR users
        /// </summary>
        public void _UpdateSteeringVR()
        {
            if (_stickIsHeld)
            {
                if (Input.GetButtonDown("Oculus_CrossPlatform_Button2")) //right menu button
                    OnButtonDown(1);
                //amplify the roll axis 3x
                float roll = _flightStickRoot.localRotation.eulerAngles.z % 360;
                roll = roll > 180 ? roll - 360 : roll;
                if (roll >= 0)
                {
                    roll = Mathf.Min(2 * roll, 120 - roll);
                }
                else
                {
                    roll = Mathf.Max(2 * roll, -120 - roll);
                }
                _currentFlightStickRotation = Quaternion.AngleAxis(roll, _flightStickRoot.forward) * _flightStickRoot.rotation;
                if (_addControllerOffset)
                {
                    _currentFlightStickRotation *= _steeringOffset;
                }
                ShipRigidbody.MoveRotation(Quaternion.Slerp(ShipRigidbody.rotation, _currentFlightStickRotation, _currentControlSensitivity * Time.deltaTime));
                //check if input thrust has changed
                float triggerInput = Input.GetAxisRaw(INDEX_TRIGGER_PICKUP_HAND_NAME) - (Input.GetAxisRaw(INDEX_TRIGGER_OTHER_HAND_NAME));
                if (triggerInput != _oldForwardThrustTriggerInput)
                {
                    if (triggerInput > 0)
                    {
                        _forwardBackwardThrust = triggerInput * _constantRelativeForwardForce;
                    }
                    else
                    {
                        _forwardBackwardThrust = triggerInput * _constantRelativeBackwardForce;
                    }
                    _oldForwardThrustTriggerInput = triggerInput;
                }
                if (_forwardBackwardThrust >= 0)
                {
                    _forwardSpeed = Mathf.Min(Mathf.Lerp(_forwardSpeed, _forwardBackwardThrust, Time.deltaTime), _forwardBackwardThrust);
                }
                else
                {
                    _forwardSpeed = Mathf.Max(Mathf.Lerp(_forwardSpeed, _forwardBackwardThrust, Time.deltaTime), _forwardBackwardThrust);
                }
                _leftRightThrustInput = Input.GetAxisRaw(HORIZONTAL_INPUT_AXIS_NAME);
                _upDownThrustInput = Input.GetAxisRaw(VERTICAL_INPUT_AXIS_NAME);
                _constantForceShipComponent.relativeForce = new Vector3(_leftRightThrustInput * _constantRelativeHorizontalForce, _upDownThrustInput * _constantRelativeVerticalForce, _forwardSpeed);
                Vector3 stickRotation = _flightStickRoot.localRotation.eulerAngles;
                //we call UpdateSteering each frame while the controller is held, to avoid having update loops for empty stations
                _UpdateSteeringVR();
            }
            else
            {
                _constantForceShipComponent.relativeForce = Vector3.zero;
                Log.Debug("Stopping steering update loop");
            }
        }

        /// <summary>
        /// Is called in every frame while the controller is held in hand for desktop users
        /// </summary>
        public void _UpdateSteeringDesktop()
        {
            if (_stickIsHeld)
            {
                float rollAngleInput = 0;
                if (Input.GetKey(KeyCode.Q))
                {
                    if (Input.GetKey(KeyCode.E)) { } //compiler optimization
                    else
                    {
                        rollAngleInput = _maxRollSpeedDegrees;
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        rollAngleInput = -_maxRollSpeedDegrees;
                    }
                }
                _rollAngleInput = Mathf.LerpAngle(_rollAngleInput, rollAngleInput, Time.deltaTime * _desktopRollSpeedLerp);
                _currentFlightStickRotation = Quaternion.AngleAxis(_rollAngleInput, _flightStickRoot.forward) * _flightStickRoot.rotation;
                if (_addControllerOffset)
                {
                    _currentFlightStickRotation *= _steeringOffset;
                }
                ShipRigidbody.MoveRotation(Quaternion.Slerp(ShipRigidbody.rotation, _currentFlightStickRotation, _currentControlSensitivity * Time.deltaTime));
                //UpDown
                if (Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        _upDownThrustInput = 0;
                    }
                    else
                    {
                        _upDownThrustInput = 1;
                    }
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    _upDownThrustInput = -1;
                }
                else
                {
                    _upDownThrustInput = 0;
                }
                //LeftRight
                if (Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKey(KeyCode.A))
                        _leftRightThrustInput = 0;
                    else
                        _leftRightThrustInput = 1;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    _leftRightThrustInput = -1;
                }
                else
                {
                    _leftRightThrustInput = 0;
                }
                //forward/backward
                if (Input.GetMouseButton(0)) //primary mouse button
                {
                    if (Input.GetKey(KeyCode.Space))
                        _forwardBackwardThrust = 0;
                    else
                        _forwardBackwardThrust = _constantRelativeForwardForce;
                }
                else if (Input.GetKey(KeyCode.Space)) //space
                {
                    _forwardBackwardThrust = -_constantRelativeForwardForce;
                }
                else
                {
                    _forwardBackwardThrust = 0;
                }
                _constantForceShipComponent.relativeForce = new Vector3(_leftRightThrustInput * _constantRelativeHorizontalForce, _upDownThrustInput * _constantRelativeVerticalForce, _forwardBackwardThrust);
                Vector3 stickRotation = _addControllerOffset ? (_flightStickRoot.localRotation * _steeringOffset).eulerAngles : _flightStickRoot.localRotation.eulerAngles;
                //we call UpdateSteering each frame while the controller is held, to avoid having update loops for empty stations
                _UpdateSteeringDesktop();
            }
            else
            {
                Log.Debug("Stopping steering update loop");
            }
        }

        /// <summary>
        /// Saves the current local stick position offset from the ship, is called at Start()
        /// </summary>
        private void StoreLocalStickPositionOffset()
        {
            _localFlightStickLocalResetPosition = _flightStickRoot.localPosition;
            _localFlightStickLocalResetRotation = _flightStickRoot.localRotation;
        }
        /// <summary>
        /// Resets the local stick root position offset from the ship, which was stored at Start()
        /// </summary>
        private void ResetLocalStickPositionOffset()
        {
            Log.Debug("Restored stick position offset");
            _flightStickRoot.localPosition = _localFlightStickLocalResetPosition;
            _flightStickRoot.localRotation = _localFlightStickLocalResetRotation;
        }

        /// <summary>
        /// Must be called from the station seat when a player entered the pilot chair
        /// </summary>
        public void _OnRelayedAllStationEnter()
        {
            Log.Debug("Player entered this station, called _OnRelayedAllStationEnter() locally");
            ShipGameObject = Ship.gameObject;
            Networking.SetOwner(Networking.LocalPlayer, ShipGameObject);
            foreach (GameObject button in _desktopButtons)
            {
                button.SetActive(true);
            }
            SetButtonHighlightsToCurrentState();
            _localPlayerIsInStationSeat = true;
            _UpdateWhileInStation();
            Ship.isKinematic = false;
            ResetLocalStickPositionOffset();
            _flightStickPickup.pickupable = true;
            //reset ship thrusters just in case
            _stickIsHeld = false;
            DisableAllThrusters();
            ResetAnimator();
        }
        /// <summary>
        /// Applies the current "highlight on/off" state to all buttons
        /// </summary>
        private void SetButtonHighlightsToCurrentState()
        {
            _buttonHighlightGearDown.SetActive(_gearDown);
            _buttonHighlightFlightAssist.SetActive(_flightAssistOn);
        }
        /// <summary>
        /// Disables the current "highlight on" objects on all buttons, regardless of their state
        /// </summary>
        private void DisableButtonHighlights()
        {
            _buttonHighlightGearDown.SetActive(false);
            _buttonHighlightFlightAssist.SetActive(false);
        }
        /// <summary>
        /// Must be called from the station seat when a player exited the pilot chair
        /// </summary>
        public void _OnRelayedAllStationExit()
        {
            Log.Debug("Player exited this station, called _OnRelayedAllStationExit() locally");
            if (_stationEventPlayer.isLocal)
            {
                foreach (GameObject button in _desktopButtons) 
                { 
                    button.SetActive(false); 
                }
                DisableButtonHighlights();
                _stickIsHeld = false;
                DisableAllThrusters();
                ResetAnimator();
                //smoothly fade out rotation steering
                _fadeOutTime = 0;
                _UpdateFadeOut();
                Log.Debug("LocalPlayer exited the station.");
                _localPlayerIsInStationSeat = false;
                Ship.isKinematic = true;
                _flightStickPickup.pickupable = false;
                ResetLocalStickPositionOffset();
                _flightStickPickup.Drop();
            }
        }

        /// <summary>
        /// Is called when the flight stick (local pickup) is being picked up.
        /// </summary>
        internal void OnPickup()
        {
            Log.Debug("Flight stick was picked up, called OnPickup() locally.");
            DisableAllThrusters();
            if (_flightStickPickup.CurrentHand == VRC_Pickup.PickupHand.Left)
            {
                INDEX_TRIGGER_PICKUP_HAND_NAME = INDEX_TRIGGER_LEFT;
                INDEX_TRIGGER_OTHER_HAND_NAME = INDEX_TRIGGER_RIGHT;
            }
            else
            {
                INDEX_TRIGGER_PICKUP_HAND_NAME = INDEX_TRIGGER_RIGHT;
                INDEX_TRIGGER_OTHER_HAND_NAME = INDEX_TRIGGER_LEFT;
            }
            if (_stickIsHeld) { } //compiler optimization
            else //avoid having two "update" loops in any case
            {
                Log.Debug("Starting steering update loop");
                _stickIsHeld = true;
                if (_addControllerOffset)
                {
                    _controllerXOffset = _isVR ? _controllerXOffsetVRUser : _controllerXOffsetDesktopUser;
                }
                if (_isVR)
                {
                    //allows advanced VR input via thumbstick
                    _UpdateSteeringVR();
                }
                else
                {
                    _UpdateSteeringDesktop();
                }
            }
        }
        /// <summary>
        /// Is called when the flight stick (local pickup) is being dropped.
        /// </summary>
        internal void OnDrop()
        {
            Log.Debug("Flight stick was dropped, now fading out steering.");
            _stickIsHeld = false;
            if (_addControllerOffset)
            {
                _controllerXOffset = 0;
            }
            DisableAllThrusters();
            //smoothly fade out rotation steering
            _fadeOutTime = 0;
            _UpdateFadeOut();
            ResetLocalStickPositionOffset();
        }

    }
}