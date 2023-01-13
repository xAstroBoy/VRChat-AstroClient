using AstroClient;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientAttributes;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using System.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;
using VRCStation = VRC.SDKBase.VRCStation;

namespace ReimajoBoothAssets
{
    // TODO: Finish and adjust to make it work without udon.
    /// <summary>
    /// This script needs to be added in "SpaceShuttle/ShipController"
    /// </summary>
    [RegisterComponent]
    public class SpaceShuttleController : MonoBehaviour
    {
        private bool _gearDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        internal bool gearDown
        {
            [HideFromIl2Cpp]
            get
            {
                return _gearDown;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _gearDown)
                {
                    _gearDeployAudioSource.Stop();
                    if (value)
                    {
                        _gearDeployAudioSource.clip = _gearOutSound;
                        _gearDeployAudioSource.Play();
                    }
                    else
                    {
                        _gearDeployAudioSource.clip = _gearInSound;
                        _gearDeployAudioSource.Play();
                    }
                    _buttonHighlightGearDown.SetActive(value);
                    _animator.SetBool("LandingGearDeployed", value);
                    _gearDown = value;
                }
            }
        }

        private bool _directionUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionUp
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionUp;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionUp)
                {
                    if (value)
                    {
                        SetDirectionUp();
                    }
                    else
                    {
                        if (directionDown)
                        {
                            SetDirectionDown();
                        }
                        else
                        {
                            SetDirectionUpDownNeutral();
                        }
                    }
                    _directionUp = value;
                }
            }
        }

        private bool _directionDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionDown
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionDown;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionDown)
                {
                    if (value)
                    {
                        SetDirectionDown();
                    }
                    else
                    {
                        if (directionUp)
                        {
                            SetDirectionUp();
                        }
                        else
                        {
                            SetDirectionUpDownNeutral();
                        }
                    }
                    _directionDown = value;
                }
            }
        }

        private bool _directionLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionLeft
        {
            [HideFromIl2Cpp]
            get => _directionLeft;
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionLeft)
                {
                    if (value)
                    {
                        SetDirectionLeft();
                    }
                    else
                    {
                        if (directionRight)
                        {
                            SetDirectionRight();
                        }
                        else
                        {
                            SetDirectionLeftRightNeutral();
                        }
                    }

                    _directionLeft = value;
                }
            }
        }

        private bool _directionRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionRight)
                {
                    if (value)
                    {
                        SetDirectionRight();
                    }
                    else
                    {
                        if (directionLeft)
                        {
                            SetDirectionLeft();
                        }
                        else
                        {
                            SetDirectionLeftRightNeutral();
                        }
                    }

                    _directionRight = value;
                }
            }
        }

        private bool _directionForwardFast { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionForwardFast
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionForwardFast;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionForwardFast)
                {
                    if (value)
                    {
                        SetDirectionForwardFast();
                    }
                    else
                    {
                        if (directionForwardSlow)
                        {
                            SetDirectionForwardSlow();
                        }
                        else if (directionBackward)
                        {
                            SetDirectionBackward();
                        }
                        else
                        {
                            SetDirectionForwardBackwardNeutral();
                        }
                    }

                    _directionForwardFast = value;
                }
            }
        }

        private bool _directionForwardSlow { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionForwardSlow
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionForwardSlow;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionForwardSlow)
                {
                    if (value)
                    {
                        SetDirectionForwardSlow();
                    }
                    else
                    {
                        if (directionForwardFast)
                        {
                            SetDirectionForwardFast();
                        }
                        else if (directionBackward)
                        {
                            SetDirectionBackward();
                        }
                        else
                        {
                            SetDirectionForwardBackwardNeutral();
                        }
                    }

                    _directionForwardSlow = value;
                }
            }
        }

        private bool _directionBackward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionBackward
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionBackward;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionBackward)
                {
                    if (value)
                    {
                        SetDirectionBackward();
                    }
                    else
                    {
                        if (directionForwardFast)
                        {
                            SetDirectionForwardFast();
                        }
                        else
                        {
                            SetDirectionForwardBackwardNeutral();
                        }
                    }

                    _directionBackward = value;
                }
            }
        }

        private bool _directionRollLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionRollLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionRollLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionRollLeft)
                {
                    if (value)
                    {
                        SetDirectionRollLeft();
                        if (!_localPlayerIsInStationSeat)
                        {
                            _animator.SetFloat("R", value: NEGATIVE_REMOTE_STEERING);
                        }
                    }
                    else
                    {
                        if (directionRollRight)
                        {
                            SetDirectionRollRight();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("R", value: POSITIVE_REMOTE_STEERING);
                            }
                        }
                        else
                        {
                            SetDirectionRollLeftRollRightNeutral();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("R", value: NEUTRAL_REMOTE_STEERING);
                            }
                        }
                    }

                    _directionRollLeft = value;
                }
            }
        }

        private bool _directionRollRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionRollRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionRollRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionRollRight)
                {
                    if (value)
                    {
                        SetDirectionRollRight();
                        if (!_localPlayerIsInStationSeat)
                        {
                            _animator.SetFloat("R", value: POSITIVE_REMOTE_STEERING);
                        }
                    }
                    else
                    {
                        if (directionRollLeft)
                        {
                            SetDirectionRollLeft();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("R", value: NEGATIVE_REMOTE_STEERING);
                            }
                        }
                        else
                        {
                            SetDirectionRollLeftRollRightNeutral();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("R", value: NEUTRAL_REMOTE_STEERING);
                            }
                        }
                    }

                    _directionRollRight = value;
                }
            }
        }

        private bool _directionPitchUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionPitchUp
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionPitchUp;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionPitchUp)
                {
                    if (value)
                    {
                        SetDirectionPitchUp();
                        if (!_localPlayerIsInStationSeat)
                        {
                            _animator.SetFloat("V", value: POSITIVE_REMOTE_STEERING);
                        }
                    }
                    else
                    {
                        if (directionPitchDown)
                        {
                            SetDirectionPitchDown();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("V", value: NEGATIVE_REMOTE_STEERING);
                            }
                        }
                        else
                        {
                            SetDirectionPitchUpPitchDownNeutral();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("V", value: NEUTRAL_REMOTE_STEERING);
                            }
                        }
                    }

                    _directionPitchUp = value;
                }
            }
        }

        private bool _directionPitchDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionPitchDown
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionPitchDown;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionPitchDown)
                {
                    if (value)
                    {
                        SetDirectionPitchDown();
                        if (!_localPlayerIsInStationSeat)
                        {
                            _animator.SetFloat("V", value: NEGATIVE_REMOTE_STEERING);
                        }
                    }
                    else
                    {
                        if (directionPitchUp)
                        {
                            SetDirectionPitchUp();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("V", value: POSITIVE_REMOTE_STEERING);
                            }
                        }
                        else
                        {
                            SetDirectionPitchUpPitchDownNeutral();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("V", value: NEUTRAL_REMOTE_STEERING);
                            }
                        }
                    }

                    _directionPitchDown = value;
                }
            }
        }

        private bool _directionYawLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionYawLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionYawLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionYawLeft)
                {
                    if (value)
                    {
                        SetDirectionYawLeft();
                        if (!_localPlayerIsInStationSeat)
                        {
                            _animator.SetFloat("H", value: NEGATIVE_REMOTE_STEERING);
                        }
                    }
                    else
                    {
                        if (directionYawRight)
                        {
                            SetDirectionYawRight();
                            if (_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("H", value: POSITIVE_REMOTE_STEERING);
                            }
                        }
                        else
                        {
                            SetDirectionYawLeftYawRightNeutral();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("H", value: NEUTRAL_REMOTE_STEERING);
                            }
                        }
                    }

                    _directionYawLeft = value;
                }
            }
        }

        private bool _directionYawRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool directionYawRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _directionYawRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _directionYawRight)
                {
                    if (value)
                    {
                        SetDirectionYawRight();
                        if (!_localPlayerIsInStationSeat)
                        {
                            _animator.SetFloat("H", value: POSITIVE_REMOTE_STEERING);
                        }
                    }
                    else
                    {
                        if (directionYawLeft)
                        {
                            SetDirectionYawLeft();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("H", value: NEGATIVE_REMOTE_STEERING);
                            }
                        }
                        else
                        {
                            SetDirectionYawLeftYawRightNeutral();
                            if (!_localPlayerIsInStationSeat)
                            {
                                _animator.SetFloat("H", value: NEUTRAL_REMOTE_STEERING);
                            }
                        }
                    }

                    _directionYawRight = value;
                }
            }
        }

        /// <summary>
        /// This slider value ranging from 0 to 1 determines the flight stick sensitivity
        /// </summary>
        internal float _sliderValue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.3f;

        /// <summary>
        /// The constant forward force that is applied to the constant force component on the ship
        /// </summary>
        internal float _constantRelativeForwardForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 600000;

        /// <summary>
        /// The constant backward force that is applied to the constant force component on the ship
        /// </summary>
        internal float _constantRelativeBackwardForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 100000;

        /// <summary>
        /// The horizontal thruster force that is applied to the constant force component on the ship
        /// when steering with the thumbstick
        /// </summary>
        internal float _constantRelativeHorizontalForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 100000;

        /// <summary>
        /// The vertical thruster force that is applied to the constant force component on the ship
        /// when steering with the thumbstick
        /// </summary>
        internal float _constantRelativeVerticalForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 100000;

        /// <summary>
        /// How fast the roll will accelerate in deskop mode, multiplier of delta time
        /// </summary>
        internal float _desktopRollSpeedLerp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 2f;

        /// <summary>
        /// Maximum roll speed, in degrees. Should stay under 180.
        /// </summary>
        internal float _maxRollSpeedDegrees { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 90f; //was 100

        /// <summary>
        /// Minimum value when <see cref="_sliderValue"/> is 0
        /// </summary>
        internal float _controlSensitivityMin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 1.0f;

        /// <summary>
        /// Maximum value when <see cref="_sliderValue"/> is 1
        /// </summary>
        internal float _controlSensitivityMax { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 3.0f;

        /// <summary>
        /// Controller rotation offset for desktop players, so that they can look forward while flying instead of looking down
        /// </summary>
        internal float _controllerXOffsetDesktopUser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 45f;

        /// <summary>
        /// Controller rotation offset for VR players, so that they can look forward while flying instead of looking down
        /// </summary>
        internal float _controllerXOffsetVRUser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0f;

        /// <summary>
        /// All desktop buttons which will be disabled unless the player is in the spaceship.
        /// </summary>
        private List<GameObject> _desktopButtons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new List<GameObject>();

        /// <summary>
        /// Gear down button highlight (shown when the gears are down & the player is in the spaceship)
        /// </summary>
        private GameObject _buttonHighlightGearDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Flight assist button highlight (shown when the flight assist is on & the player is in the spaceship)
        /// </summary>
        private GameObject _buttonHighlightFlightAssist { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Custom center of gravity of the ship
        /// </summary>
        private Transform _customCenterOfGravity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Animator of the space shuttle
        /// </summary>
        private Animator _animator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// AudioSource to play the gear deploy sound
        /// </summary>
        private AudioSource _gearDeployAudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// AudioClip for the gear deploy (gear in) sound
        /// </summary>
        private AudioClip _gearInSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// AudioClip for the gear deploy (gear out) sound
        /// </summary>
        private AudioClip _gearOutSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Root of the Flight Stick (local pickup object), will be re-[HideFromIl2Cpp] set to the local position at start when it's released
        /// </summary>
        private Transform _flightStickRoot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Nav ball bone (Instrumentation)
        /// </summary>
        private Transform _navBall { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Speed indicator bone (Instrumentation)
        /// </summary>
        private Transform _speedIndicatorBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Altitude indicator bone (Instrumentation)
        /// </summary>
        private Transform _altitudeIndicatorBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Rigidbody of the ship, will be toggled between kinematic / non-kinematic
        /// </summary>
        private Rigidbody Ship { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// The pilot's chair of the ship (VRCStation)
        /// </summary>
        private ChairController _pilotChairStation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing main truster number 1/3 </summary>
        private Transform _backwardMTRs1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing main truster number 2/3 </summary>
        private Transform _backwardMTRs2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing main truster number 3/3 </summary>
        private Transform _backwardMTRs3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing cold gas truster number 1/2 </summary>
        private Transform _backwardCTRs1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing cold gas truster number 2/2 </summary>
        private Transform _backwardCTRs2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster number 1/2 </summary>
        private Transform _frontForwardCTR1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster number 2/2 </summary>
        private Transform _frontForwardCTR2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster on the front left </summary>
        private Transform _frontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster on the front right </summary>
        private Transform _frontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the front left </summary>
        private Transform _upFrontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the front right </summary>
        private Transform _upFrontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the far left / middle (wing) </summary>
        private Transform _upLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the far right / middle (wing) </summary>
        private Transform _upRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the far left / middle (wing) </summary>
        private Transform _downLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the far right / middle (wing) </summary>
        private Transform _downRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the front left </summary>
        private Transform _downFrontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the front right </summary>
        private Transform _downFrontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backward pointing cold gas truster on the back left </summary>
        private Transform _backLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backward pointing cold gas truster on the back right </summary>
        private Transform _backRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Bone of the space ship armature that moves the joystick visually </summary>
        private Transform _joystickBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float _oldForwardThrustTriggerInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        //particle systems fetched from the transform objects
        private ParticleSystem _backwardMainPS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private ParticleSystem _backwardMainPS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _backwardMainPS3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _backwardSlowPS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _backwardSlowPS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _frontForwardPS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _frontForwardPS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _frontLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _frontRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _upFrontLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _upFrontRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _upLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _upRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _downLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _downRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _downFrontLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _downFrontRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _backLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem _backRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        //audio sources
        private AudioSource _backwardMainASs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private AudioSource _backwardSlowAS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _backwardSlowAS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _frontForwardAS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _frontForwardAS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _frontLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _frontRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _upFrontLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _upFrontRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _upLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _upRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _downLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _downRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _downFrontLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _downFrontRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _backLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource _backRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool _backwardMain { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backwardMain
        {
            [HideFromIl2Cpp]
            get
            {
                return _backwardMain;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backwardMain)
                {
                    _backwardMain = value;

                    //forward main boosters
                    if (value)
                    {
                        _backwardMainPS1.Play();
                        _backwardMainPS2.Play();
                        _backwardMainPS3.Play();
                        _backwardMainASs.Play();
                    }
                    else
                    {
                        _backwardMainPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _backwardMainPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _backwardMainPS3.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _backwardMainASs.Stop();
                    }
                }
            }
        }

        private bool _upFrontLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upFrontLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _upFrontLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upFrontLeft)
                {
                    _upFrontLeft = value;
                    if (value)
                    {
                        _upFrontLeftPS.Play();
                    }
                    else
                    {
                        _upFrontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
            }
        }

        private bool _backwardSlow { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backwardSlow
        {
            [HideFromIl2Cpp]
            get
            {
                return _backwardSlow;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backwardSlow)
                {
                    _backwardSlow = value;
                    if (value)
                    {
                        _backwardSlowPS1.Play();
                        _backwardSlowPS2.Play();
                        _backwardSlowAS1.Play();
                        _backwardSlowAS2.Play();
                    }
                    else
                    {
                        _backwardSlowPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _backwardSlowPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _backwardSlowAS1.Stop();
                        _backwardSlowAS2.Stop();
                    }
                }
            }
        }

        private bool _frontForward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool frontForward
        {
            [HideFromIl2Cpp]
            get
            {
                return _frontForward;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _frontForward)
                {
                    _frontForward = value;
                    if (value)
                    {
                        _frontForwardPS1.Play();
                        _frontForwardAS1.Play();
                        _frontForwardPS2.Play();
                        _frontForwardAS2.Play();
                    }
                    else
                    {
                        _frontForwardPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _frontForwardAS1.Stop();
                        _frontForwardPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _frontForwardAS2.Stop();
                    }
                }
            }
        }

        private bool _frontLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool frontLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _frontLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _frontLeft)
                {
                    _frontLeft = value;
                    if (value)
                    {
                        _frontLeftPS.Play();
                        _frontLeftAS.Play();
                    }
                    else
                    {
                        _frontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _frontLeftAS.Stop();
                    }
                }
            }
        }

        private bool _frontRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool frontRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _frontRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _frontRight)
                {
                    _frontRight = value;
                    if (value)
                    {
                        _frontRightPS.Play();
                        _frontRightAS.Play();
                    }
                    else
                    {
                        _frontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _frontRightAS.Stop();
                    }
                }
            }
        }

        private bool _upFrontRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upFrontRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _upFrontRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upFrontRight)
                {
                    _upFrontRight = value;
                    if (value)
                    {
                        _upFrontRightPS.Play();
                    }
                    else
                    {
                        _upFrontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
            }
        }

        private bool _upLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _upLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upLeft)
                {
                    _upLeft = value;
                    if (value)
                    {
                        _upLeftPS.Play();
                    }
                    else
                    {
                        _upLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
            }
        }

        private bool _upRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _upRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upRight)
                {
                    _upRight = value;
                    if (value)
                    {
                        _upRightPS.Play();
                        _upRightAS.Play();
                    }
                    else
                    {
                        _upRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _upRightAS.Stop();
                    }
                }
            }
        }

        private bool _downLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _downLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downLeft)
                {
                    _downLeft = value;
                    if (value)
                    {
                        _downLeftPS.Play();
                        _downLeftAS.Play();
                    }
                    else
                    {
                        _downLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _downLeftAS.Stop();
                    }
                }
            }
        }

        private bool _downRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _downRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downRight)
                {
                    _downRight = value;
                    if (value)
                    {
                        _downRightPS.Play();
                        _downRightAS.Play();
                    }
                    else
                    {
                        _downRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _downRightAS.Stop();
                    }
                }
            }
        }

        private bool _downFrontLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downFrontLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _downFrontLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downFrontLeft)
                {
                    _downFrontLeft = value;
                    if (value)
                    {
                        _downFrontLeftPS.Play();
                        _downFrontLeftAS.Play();
                    }
                    else
                    {
                        _downFrontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _downFrontLeftAS.Stop();
                    }
                }
            }
        }

        private bool _downFrontRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downFrontRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _downFrontRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downFrontRight)
                {
                    _downFrontRight = value;
                    if (value)
                    {
                        _downFrontRightPS.Play();
                        _downFrontRightAS.Play();
                    }
                    else
                    {
                        _downFrontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _downFrontRightAS.Stop();
                    }
                }
            }
        }

        private bool _backLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _backLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backLeft)
                {
                    _backLeft = value;
                    if (value)
                    {
                        _backLeftPS.Play();
                        _backLeftAS.Play();
                    }
                    else
                    {
                        _backLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _backLeftAS.Stop();
                    }
                }
            }
        }

        private bool _backRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _backRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backRight)
                {
                    _backRight = value;
                    if (value)
                    {
                        _backRightPS.Play();
                        _backRightAS.Play();
                    }
                    else
                    {
                        _backRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        _backRightAS.Stop();
                    }
                }
            }
        }

        private ConstantForce _constantForceShipComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup _flightStickPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _forwardSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _controlSensitivitySpan { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _currentControlSensitivity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _localPlayerIsInStationSeat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _rollAngleInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _addControllerOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _stickIsHeld { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _fadeOutTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 _localFlightStickLocalResetPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion _localFlightStickLocalResetRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion _steeringOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion _currentFlightStickRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private GameObject _syncedShipGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _forwardBackwardThrust { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _upDownThrustInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _leftRightThrustInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float _controllerXOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _isVR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private string INDEX_TRIGGER_PICKUP_HAND_NAME { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } //is [HideFromIl2Cpp] set at runtime
        private string INDEX_TRIGGER_OTHER_HAND_NAME { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } //is [HideFromIl2Cpp] set at runtime
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
        /// The input that is [HideFromIl2Cpp] set locally if the remote user steers in the negative direction. Must be between -1 and 0.
        /// </summary>
        private const float NEGATIVE_REMOTE_STEERING = -0.5f;

        /// <summary>
        /// The input that is [HideFromIl2Cpp] set locally if the remote user doesn't steer in any direction. Must be between -1 and 1.
        /// This should be 0 unless your animator is weird.
        /// </summary>
        private const float NEUTRAL_REMOTE_STEERING = 0;

        /// <summary>
        /// The input that is [HideFromIl2Cpp] set locally if the remote user steers in the positive direction. Must be between 1 and 0.
        /// </summary>
        private const float POSITIVE_REMOTE_STEERING = 0.5f;

        private static void SetVRCSpatialAudioSource(GameObject audio, float gain, float far)
        {
            var audiosource = audio.GetComponentInChildren<AudioSource>();
            if (audiosource == null) return;
            var SpatialSource = audiosource.GetOrAddComponent<VRC_SpatialAudioSource>();
            if (SpatialSource != null)
            {
                SpatialSource.Gain = gain;
                SpatialSource.Far = far;
                SpatialSource.EnableSpatialization = true;
            }
        }

        /// <summary>
        /// Disables all thrusters. This is only called from the object owner.
        /// </summary>
        internal void DisableAllThrusters()
        {
            backwardMain = false;
            backwardSlow = false;
            frontForward = false;
            frontLeft = false;
            frontRight = false;
            upFrontLeft = false;
            upFrontRight = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
            downFrontLeft = false;
            downFrontRight = false;
            backLeft = false;
            backRight = false;
        }

        /// <summary>
        /// Takes in the current pitch/yaw/roll input and syncs it to remote users.
        /// </summary>
        /// <param name="pitchRotation">Pilot input for the joystick pitch angle, in degrees</param>
        /// <param name="yawRotation">Pilot input for the joystick yaw angle, in degrees</param>
        /// <param name="rollRotation">Pilot input for the joystick roll angle, in degrees</param>
        internal void SyncControlInput(float pitchRotation, float yawRotation, float rollRotation)
        {
            //check up-down stick axis
            if (Mathf.Abs(_upDownThrustInput) > MIN_STICK_INPUT)
            {
                //relevant input for up/down
                if (_upDownThrustInput < 0)
                {
                    SetDirectionUp();
                }
                else
                {
                    SetDirectionDown();
                }
            }
            else
            {
                SetDirectionUpDownNeutral();
            }

            //check left-right stick axis
            if (Mathf.Abs(_leftRightThrustInput) > MIN_STICK_INPUT)
            {
                //relevant input for up/down
                if (_leftRightThrustInput > 0)
                {
                    SetDirectionRight();
                }
                else
                {
                    SetDirectionLeft();
                }
            }
            else
            {
                SetDirectionLeftRightNeutral();
            }

            //check forward-backward input _forwardBackwardThrust
            if (Mathf.Abs(_forwardBackwardThrust) > MIN_STICK_INPUT)
            {
                //relevant input for forward/backward
                if (_forwardBackwardThrust > 0)
                {
                    if (_forwardBackwardThrust < SLOW_TRIGGER_INPUT)
                    {
                        SetDirectionForwardSlow();
                    }
                    else
                    {
                        SetDirectionForwardFast();
                    }
                }
                else
                {
                    SetDirectionBackward();
                }
            }
            else
            {
                SetDirectionForwardBackwardNeutral();
            }

            //Left/right roll axis
            rollRotation = rollRotation > 180 ? rollRotation - 360 : rollRotation;
            if (Mathf.Abs(rollRotation) > MIN_AXIS_INPUT)
            {
                //relevant input for left/right
                if (rollRotation < 0)
                {
                    SetDirectionRollLeft();
                }
                else
                {
                    SetDirectionRollRight();
                }
            }
            else
            {
                SetDirectionRollLeftRollRightNeutral();
            }

            //Up/Down pitch axis
            pitchRotation = pitchRotation > 180 ? pitchRotation - 360 : pitchRotation;
            if (Mathf.Abs(pitchRotation) > MIN_AXIS_INPUT)
            {
                //relevant input for up/down
                if (pitchRotation > 0)
                {
                    SetDirectionPitchDown();
                }
                else
                {
                    SetDirectionPitchUp();
                }
            }
            else
            {
                SetDirectionPitchUpPitchDownNeutral();
            }

            //Left/Right yaw axis
            yawRotation = yawRotation > 180 ? yawRotation - 360 : yawRotation;
            if (Mathf.Abs(yawRotation) > MIN_AXIS_INPUT)
            {
                //relevant input for left/right
                if (yawRotation > 0)
                {
                    SetDirectionYawRight();
                }
                else
                {
                    SetDirectionYawLeft();
                }
            }
            else
            {
                SetDirectionYawLeftYawRightNeutral();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft upwards
        /// </summary>
        internal void SetDirectionUp()
        {
            //player wants to fly upwards, so activate down-booster
            if (directionUp)
            {
                //we're already flying upwards, so nothing changed
            }
            else
            {
                directionUp = true;

                //we now fly upwards for the first time, so activate down booster
                downFrontLeft = true;
                downFrontRight = true;
                downLeft = true;
                downRight = true;
                //we're no longer flying downwards
                if (directionDown)
                {
                    directionDown = false;
                    SetDisabled_upFrontLeft();
                    SetDisabled_upFrontRight();
                    SetDisabled_upLeft();
                    SetDisabled_upRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither up nor downwards
        /// </summary>
        internal void SetDirectionUpDownNeutral()
        {
            //we are flying neither up nor down, so cancel directions if they are active
            if (directionUp)
            {
                directionUp = false;

                SetDisabled_downLeft();
                SetDisabled_downRight();
                SetDisabled_downFrontLeft();
                SetDisabled_downFrontRight();
            }
            if (directionDown)
            {
                directionDown = false;

                SetDisabled_upLeft();
                SetDisabled_upRight();
                SetDisabled_upFrontLeft();
                SetDisabled_upFrontRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft downwards
        /// </summary>
        internal void SetDirectionDown()
        {
            //player wants to fly downwards, so activate up-booster
            if (directionDown)
            {
                //we're already flying downwards, so nothing changed
            }
            else
            {
                directionDown = true;

                //we now fly upwards for the first time, so activate up booster
                upFrontRight = true;
                upFrontLeft = true;
                upLeft = true;
                upRight = true;
                //check if we flew upwards before
                if (directionUp)
                {
                    directionUp = false;

                    //we are no longer flying upwards
                    SetDisabled_downLeft();
                    SetDisabled_downRight();
                    SetDisabled_downFrontLeft();
                    SetDisabled_downFrontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft leftwards
        /// </summary>
        internal void SetDirectionLeft()
        {
            //player wants to fly leftwards, so activate right-booster
            if (directionLeft)
            {
                //we're already flying leftwards, so nothing changed
            }
            else
            {
                directionLeft = true;

                //we now fly leftwards for the first time, so activate right booster
                frontRight = true;
                backRight = true;
                //we're no longer flying rightwards
                if (directionRight)
                {
                    directionRight = false;

                    //we are no longer flying rightwards
                    SetDisabled_frontLeft();
                    SetDisabled_backLeft();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither left nor rightwards
        /// </summary>
        internal void SetDirectionLeftRightNeutral()
        {
            //we are flying neither left nor right, so cancel directions if they are active
            if (directionLeft)
            {
                directionLeft = false;

                SetDisabled_frontRight();
                SetDisabled_backRight();
            }
            if (directionRight)
            {
                directionRight = false;

                SetDisabled_frontLeft();
                SetDisabled_backLeft();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft rightwards
        /// </summary>
        internal void SetDirectionRight()
        {
            //player wants to fly rightwards, so activate left-booster
            if (directionRight)
            {
                //we're already flying rightwards, so nothing changed
            }
            else
            {
                directionRight = true;

                //we now fly leftwards for the first time, so activate right booster
                frontLeft = true;
                backLeft = true;
                //check if we flew leftwards before
                if (directionLeft)
                {
                    directionLeft = false;

                    SetDisabled_frontRight();
                    SetDisabled_backRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft forwardwards fast
        /// </summary>
        internal void SetDirectionForwardFast()
        {
            //player wants to fly forwardwards, so activate backward-booster
            if (directionForwardFast)
            {
                //we're already flying forwardwards, so nothing changed
            }
            else
            {
                directionForwardFast = true;

                //we now fly forward for the first time, so activate main backward booster
                backwardMain = true;
                //we're no longer flying backward
                if (directionBackward)
                {
                    directionBackward = false;

                    //we are no longer flying backward
                    SetDisabled_frontForward();
                }
                if (directionForwardSlow)
                {
                    directionForwardSlow = false;

                    //we are no longer flying forward
                    SetDisabled_backwardSlow();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft forwardwards slow
        /// </summary>
        internal void SetDirectionForwardSlow()
        {
            //player wants to fly forwardwards, so activate backward-booster
            if (directionForwardSlow)
            {
                //we're already flying forwardwards, so nothing changed
            }
            else
            {
                directionForwardSlow = true;

                //we now fly forward for the first time, so activate slow backward booster
                backwardSlow = true;
                //we're no longer flying backward
                if (directionBackward)
                {
                    directionBackward = false;

                    //we are no longer flying backward
                    SetDisabled_frontForward();
                }
                if (directionForwardFast)
                {
                    directionForwardFast = false;

                    //we are no longer flying forward
                    SetDisabled_backwardMain();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither forward nor backwardwards
        /// </summary>
        internal void SetDirectionForwardBackwardNeutral()
        {
            //we are flying neither forward nor backward, so cancel directions if they are active
            if (directionBackward)
            {
                directionBackward = false;

                SetDisabled_frontForward();
            }
            if (directionForwardFast)
            {
                directionForwardFast = false;

                //we are no longer flying forward
                SetDisabled_backwardMain();
            }
            if (directionForwardSlow)
            {
                directionForwardSlow = false;

                //we are no longer flying forward
                SetDisabled_backwardSlow();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft backwardwards
        /// </summary>
        internal void SetDirectionBackward()
        {
            //player wants to fly backward, so activate forward-booster
            if (directionBackward)
            {
                //we're already flying backward, so nothing changed
            }
            else
            {
                directionBackward = true;

                //we now fly backward for the first time, so activate forward pointing booster
                frontForward = true;
                //check if we flew forward before
                if (directionForwardFast)
                {
                    directionForwardFast = false;

                    //we are no longer flying forward
                    SetDisabled_backwardMain();
                }
                if (directionForwardSlow)
                {
                    directionForwardSlow = false;

                    //we are no longer flying forward
                    SetDisabled_backwardSlow();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft leftYawwards
        /// </summary>
        internal void SetDirectionYawLeft()
        {
            //player wants to fly leftYaw
            if (directionYawLeft)
            {
                //we're already flying leftYawwards, so nothing changed
            }
            else
            {
                directionYawLeft = true;

                //we now fly leftYawwards for the first time, so activate rightYaw booster
                backLeft = true;
                frontRight = true;
                //we're no longer flying rightYawwards
                if (directionYawRight)
                {
                    directionYawRight = false;

                    SetDisabled_frontLeft();
                    SetDisabled_backRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither leftYaw nor rightYawwards
        /// </summary>
        internal void SetDirectionYawLeftYawRightNeutral()
        {
            //we are flying neither leftYaw nor rightYaw, so cancel directions if they are active
            if (directionYawLeft)
            {
                directionYawLeft = false;

                SetDisabled_backLeft();
                SetDisabled_frontRight();
            }
            if (directionYawRight)
            {
                directionYawRight = false;

                SetDisabled_frontLeft();
                SetDisabled_backRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft rightYawwards
        /// </summary>
        internal void SetDirectionYawRight()
        {
            //player wants to fly rightYawwards, so activate leftYaw-booster
            if (directionYawRight)
            {
                //we're already flying rightYawwards, so nothing changed
            }
            else
            {
                directionYawRight = true;

                //we now fly leftYawwards for the first time, so activate rightYaw booster
                backRight = true;
                frontLeft = true;
                //check if we flew leftYawwards before
                if (directionYawLeft)
                {
                    directionYawLeft = false;

                    SetDisabled_backLeft();
                    SetDisabled_frontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft leftRollwards
        /// </summary>
        internal void SetDirectionRollLeft()
        {
            //player wants to fly leftRoll
            if (directionRollLeft)
            {
                //we're already flying leftRollwards, so nothing changed
            }
            else
            {
                directionRollLeft = true;

                //we now fly leftRollwards for the first time, so activate rightRoll booster
                downLeft = true;
                downFrontLeft = true;
                upRight = true;
                upFrontRight = true;
                //we're no longer flying rightRollwards
                if (directionRollRight)
                {
                    directionRollRight = false;

                    SetDisabled_upLeft();
                    SetDisabled_upFrontLeft();
                    SetDisabled_downRight();
                    SetDisabled_downFrontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither leftRoll nor rightRollwards
        /// </summary>
        internal void SetDirectionRollLeftRollRightNeutral()
        {
            //we are flying neither leftRoll nor rightRoll, so cancel directions if they are active
            if (directionRollLeft)
            {
                directionRollLeft = false;

                SetDisabled_downLeft();
                SetDisabled_downFrontLeft();
                SetDisabled_upRight();
                SetDisabled_upFrontRight();
            }
            if (directionRollRight)
            {
                directionRollRight = false;

                SetDisabled_upLeft();
                SetDisabled_upFrontLeft();
                SetDisabled_downRight();
                SetDisabled_downFrontRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft rightRollwards
        /// </summary>
        internal void SetDirectionRollRight()
        {
            //player wants to fly rightRollwards, so activate leftRoll-booster
            if (directionRollRight)
            {
                //we're already flying rightRollwards, so nothing changed
            }
            else
            {
                directionRollRight = true;

                //we now fly leftRollwards for the first time, so activate rightRoll booster
                downRight = true;
                downFrontRight = true;
                upLeft = true;
                upFrontLeft = true;
                //check if we flew leftRollwards before
                if (directionRollLeft)
                {
                    directionRollLeft = false;

                    SetDisabled_downLeft();
                    SetDisabled_downFrontLeft();
                    SetDisabled_upRight();
                    SetDisabled_upFrontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft pitchUpwards
        /// </summary>
        internal void SetDirectionPitchUp()
        {
            //player wants to fly pitchUp
            if (directionPitchUp)
            {
                //we're already flying pitchUpwards, so nothing changed
            }
            else
            {
                directionPitchUp = true;

                //we now fly pitchUpwards for the first time, so activate pitchDown booster
                downFrontLeft = true;
                downFrontRight = true;
                upLeft = true;
                upRight = true;
                //we're no longer flying pitchDownwards
                if (directionPitchDown)
                {
                    directionPitchDown = false;
                    SetDisabled_upFrontLeft();
                    SetDisabled_upFrontRight();
                    SetDisabled_downLeft();
                    SetDisabled_downRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither pitchUp nor pitchDownwards
        /// </summary>
        internal void SetDirectionPitchUpPitchDownNeutral()
        {
            //we are flying neither pitchUp nor pitchDown, so cancel directions if they are active
            if (directionPitchUp)
            {
                directionPitchUp = false;

                SetDisabled_downFrontLeft();
                SetDisabled_downFrontRight();
                SetDisabled_upLeft();
                SetDisabled_upRight();
            }
            if (directionPitchDown)
            {
                directionPitchDown = false;

                SetDisabled_upFrontLeft();
                SetDisabled_upFrontRight();
                SetDisabled_downLeft();
                SetDisabled_downRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft pitchDownwards
        /// </summary>
        internal void SetDirectionPitchDown()
        {
            //player wants to fly pitchDownwards, so activate pitchUp-booster
            if (directionPitchDown)
            {
                //we're already flying pitchDownwards, so nothing changed
            }
            else
            {
                directionPitchDown = true;

                //we now fly pitchUpwards for the first time, so activate pitchDown booster
                upFrontLeft = true;
                upFrontRight = true;
                downLeft = true;
                downRight = true;
                //check if we flew pitchUpwards before
                if (directionPitchUp)
                {
                    directionPitchUp = false;

                    SetDisabled_downFrontLeft();
                    SetDisabled_downFrontRight();
                    SetDisabled_upLeft();
                    SetDisabled_upRight();
                }
            }
        }

        /// <summary>
        /// Main thruster that is pointing backwards
        /// </summary>
        internal void SetDisabled_backwardMain()
        {
            backwardMain = false;
        }

        /// <summary>
        /// Slow thruster that is pointing backwards
        /// </summary>
        internal void SetDisabled_backwardSlow()
        {
            backwardSlow = false;
        }

        /// <summary>
        /// Thruster that is pointing forward in the front
        /// </summary>
        internal void SetDisabled_frontForward()
        {
            frontForward = false;
        }

        /// <summary>
        /// Thruster on the front that is pointing to the left
        /// Used for going right and turning on Y-axis
        /// </summary>
        internal void SetDisabled_frontLeft()
        {
            if (directionRight)
                return;
            if (directionYawRight)
                return;
            frontLeft = false;
        }

        internal void SetDisabled_frontRight()
        {
            if (directionLeft)
                return;
            if (directionYawLeft)
                return;
            frontRight = false;
        }

        internal void SetDisabled_upFrontLeft()
        {
            if (directionRollRight)
                return;
            if (directionPitchDown)
                return;
            if (directionDown)
                return;
            upFrontLeft = false;
        }

        internal void SetDisabled_upFrontRight()
        {
            if (directionRollLeft)
                return;
            if (directionPitchDown)
                return;
            if (directionDown)
                return;
            upFrontRight = false;
        }

        internal void SetDisabled_upLeft()
        {
            if (directionDown)
                return;
            if (directionRollLeft)
                return;
            if (directionPitchUp)
                return;
            upLeft = false;
        }

        internal void SetDisabled_upRight()
        {
            if (directionDown)
                return;
            if (directionRollRight)
                return;
            if (directionPitchUp)
                return;
            upRight = false;
        }

        internal void SetDisabled_downLeft()
        {
            if (directionUp)
                return;
            if (directionRollRight)
                return;
            if (directionPitchDown)
                return;
            downLeft = false;
        }

        internal void SetDisabled_downRight()
        {
            if (directionUp)
                return;
            if (directionRollLeft)
                return;
            if (directionPitchDown)
                return;
            downRight = false;
        }

        internal void SetDisabled_downFrontLeft()
        {
            if (directionUp)
                return;
            if (directionRollRight)
                return;
            if (directionPitchUp)
                return;
            downFrontLeft = false;
        }

        internal void SetDisabled_downFrontRight()
        {
            if (directionUp)
                return;
            if (directionRollLeft)
                return;
            if (directionPitchUp)
                return;
            downFrontRight = false;
        }

        internal void SetDisabled_backLeft()
        {
            if (directionRight)
                return;
            if (directionYawLeft)
                return;
            backLeft = false;
        }

        internal void SetDisabled_backRight()
        {
            if (directionLeft)
                return;
            if (directionYawRight)
                return;
            backRight = false;
        }

        /// <summary>
        /// Is called from an external slider when <see cref="_sliderValue"/> changed
        /// </summary>
        internal void SliderValueChanged()
        {
            _currentControlSensitivity = _controlSensitivityMin + (_sliderValue * _controlSensitivitySpan);
        }

        /// <summary>
        /// Is called when a button in the cockpit is pressed.
        /// </summary>
        internal void OnButtonDown(int id)
        {
            switch (id)
            {
                case 0:
                    _ToggleFlightAssist();
                    break;

                case 1:
                    ToggleGearDown();
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
        internal void ToggleGearDown()
        {
            gearDown = !gearDown;
        }

        private bool _flightAssistOn = true;

        /// <summary>
        /// Toggles the flight assist on/off, default is on.
        /// </summary>
        internal void _ToggleFlightAssist()
        {
            _flightAssistOn = !_flightAssistOn;
            _buttonHighlightFlightAssist.SetActive(_flightAssistOn);
            ApplyFlightAssistSetting();
        }

        internal void ApplyFlightAssistSetting()
        {
            if (_flightAssistOn)
            {
                Ship.drag = 1;
                Ship.angularDrag = 1;
            }
            else
            {
                Ship.drag = 0.01f;
                Ship.angularDrag = 1f;
            }
        }

        /// <summary>
        /// Is called once at the start of the world to setup the script
        /// </summary>
        internal void Start()
        {
            #region Setup Variables

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
            var Desktop2 = root.FindObject($"Space Shuttle Model/Armature/Root/EjectButton/_desktopButton2").gameObject;
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
            Ship = root.GetComponent<Rigidbody>();
            _syncedShipGameObject = root.gameObject;
            _buttonHighlightGearDown = root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.L/ButtonHighlightGearDown").gameObject;
            _buttonHighlightFlightAssist = root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.R/ButtonHighlightFlightAssist").gameObject;
            _customCenterOfGravity = root.FindObject("CustomCG");
            _animator = root.FindObject("Space Shuttle Model").GetComponent<Animator>();
            _gearDeployAudioSource = root.FindObject("_audioSourceGearDeploySound").GetComponent<AudioSource>();
            _flightStickRoot = this.transform;
            _navBall = root.FindObject("Space Shuttle Model/Armature/Root/NavBallParent/NavballRotateHere");
            _speedIndicatorBone = root.FindObject("Space Shuttle Model/Armature/Root/Speedometer");
            _altitudeIndicatorBone = root.FindObject("Space Shuttle Model/Armature/Root/Altimeter");
            _backwardMTRs1 = root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.L/_backwardMTRs1");
            _backwardMTRs2 = root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.R/_backwardMTRs2");
            _backwardMTRs3 = root.FindObject("Space Shuttle Model/Armature/Root/MainEngineTop/_backwardMTRs3");

            _backwardCTRs1 = root.FindObject("ParticlesRoot/_backwardCTR1");
            _backwardCTRs2 = root.FindObject("ParticlesRoot/_backwardCTR2");

            _frontForwardCTR1 = root.FindObject("ParticlesRoot/_frontForwardCTR1");
            _frontForwardCTR2 = root.FindObject("ParticlesRoot/_frontForwardCTR2");

            _upRightCTR = root.FindObject("ParticlesRoot/_upRightCTR");

            _upFrontRightCTR = root.FindObject("ParticlesRoot/_upFrontRightCTR");
            _downFrontRightCTR = root.FindObject("ParticlesRoot/_downFrontRightCTR");
            _downFrontLeftCTR = root.FindObject("ParticlesRoot/_downFrontLeftCTR");
            _backLeftCTR = root.FindObject("ParticlesRoot/_backLeftCTR");
            _downRightCTR = root.FindObject("ParticlesRoot/_downRightCTR");
            _downLeftCTR = root.FindObject("ParticlesRoot/_downLeftCTR");
            _frontRightCTR = root.FindObject("ParticlesRoot/_frontRightCTR");
            _frontLeftCTR = root.FindObject("ParticlesRoot/_frontLeftCTR");
            _backRightCTR = root.FindObject("ParticlesRoot/_backRightCTR");
            _upFrontLeftCTR = root.FindObject("ParticlesRoot/_upFrontLeftCTR");
            _upLeftCTR = root.FindObject("ParticlesRoot/_upLeftCTR");
            _joystickBone = root.FindObject("Space Shuttle Model/Armature/Root/Joystick");

            _flightStickPickup = _flightStickRoot.GetOrAddComponent<VRC_AstroPickup>();
            _flightStickPickup.ForcePickupComponent = true;
            _flightStickPickup.PickupController.orientation = VRC_Pickup.PickupOrientation.Any;
            _flightStickPickup.PickupController.AutoHold = VRC_Pickup.AutoHoldMode.Yes;
            _flightStickPickup.PickupController.UseText = "Grab";
            _flightStickPickup.PickupController.ThrowVelocityBoostMinSpeed = 1;
            _flightStickPickup.PickupController.ThrowVelocityBoostScale = 1;
            _flightStickPickup.pickupable = true;
            _flightStickPickup.PickupController.proximity = 2;
            _flightStickPickup.OnPickup += OnPickup;
            _flightStickPickup.OnDrop += OnDrop;

            var ChairController = root.FindObject("SelfAdjustingChair_Pilot/ChairController");
            var station = ChairController.GetOrAddComponent<VRC_AstroStation>();
            if (station != null)
            {
                station.OnStationEnterEvent += OnStationEnter;
                station.OnStationExitEvent += OnStationExit;
                station.Station.disableStationExit = true;
                station.Station.seated = true;
                station.Station.PlayerMobility = VRCStation.Mobility.ImmobilizeForVehicle;
                station.Station.canUseStationFromStation = false;
                station.Station.stationEnterPlayerLocation = root.FindObject("SelfAdjustingChair_Pilot/_stationSeat");
                station.Station.stationExitPlayerLocation = root.FindObject("SelfAdjustingChair_Pilot/Exit");
                station.StationTrigger.InteractionText = "Drive Shuttle";
                station.StationTrigger.proximity = 2;
            }

            _pilotChairStation = ChairController.GetOrAddComponent<ChairController>();
            if (_pilotChairStation != null)
            {
                _pilotChairStation._disableColliderControl = false;
                _pilotChairStation._enableStationMenuButtonExit = false;
                _pilotChairStation._stationSeat = root.FindObject("SelfAdjustingChair_Pilot/_stationSeat");
                _pilotChairStation._seatSurfaceUpAndFrontEdgeForward = root.FindObject("SelfAdjustingChair_Pilot/_seatSurfaceUpAndFrontEdgeForward");
                _pilotChairStation._seatBackEndSurfaceForward = root.FindObject("SelfAdjustingChair_Pilot/_seatBackEndSurfaceForward");
            }
            // add missing audio components.
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_upRightCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_frontForwardCTR2/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_downFrontLeftCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_downRightCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_frontLeftCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_backwardCTR1/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_upLeftCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_frontForwardCTR1/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_backLeftCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_frontRightCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_upFrontRightCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_upFrontLeftCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_backwardCTR2/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_backRightCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_downLeftCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("ParticlesRoot/_downFrontRightCTR/ColdGasThrusters/AudioSource").gameObject, 10, 100);
            SetVRCSpatialAudioSource(root.FindObject("_audioSourceGearDeploySound").gameObject, 10, 40);
            SetVRCSpatialAudioSource(root.FindObject("SpaceShuttle/Space Shuttle Model/Armature/Root/MainEngine.L/_backwardMTRs1/AudioSource").gameObject, 60, 40);
            SetVRCSpatialAudioSource(root.FindObject("SpaceShuttle/Space Shuttle Model/Armature/Root/MainEngine.R/_backwardMTRs2/AudioSource").gameObject, 60, 40);
            SetVRCSpatialAudioSource(root.FindObject("SpaceShuttle/Space Shuttle Model/Armature/Root/MainEngine.R/_backwardMTRs2/AudioSource").gameObject, 60, 40);
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

            #endregion Setup Variables

            foreach (var button in _desktopButtons)
            {
                button.SetActive(false);
            }
            DisableButtonHighlights();
            //fetch particle systems
            _controlSensitivitySpan = _controlSensitivityMax - _controlSensitivityMin;
            SliderValueChanged(); //apply the calculated _controlSensitivitySpan
            _constantForceShipComponent = Ship.GetComponent<ConstantForce>();
            ApplyFlightAssistSetting();
            DisableAllThrusters();
            if (_customCenterOfGravity)
            {
                Ship.centerOfMass = _customCenterOfGravity.localPosition;
            }
            if (_constantForceShipComponent != null)
            {
                _constantForceShipComponent.relativeForce = new Vector3(0, 0, 0);
            }
            else
            {
                Log.Error("[ShipController] There is no constant force component attached to the ship's rigidbody.");
            }
            Ship.isKinematic = true;
            _flightStickPickup.pickupable = false;
            _isVR = Networking.LocalPlayer.IsUserInVR();
            _controllerXOffset = _isVR ? _controllerXOffsetVRUser : _controllerXOffsetDesktopUser;
            if (_controllerXOffset != 0)
            {
                _addControllerOffset = true;
                Log.Debug($"[ShipController] Adding controller X-Offset with {_controllerXOffset} degrees.");
                _steeringOffset = Quaternion.Euler(_controllerXOffset, 0, 0);
            }
            StoreLocalStickPositionOffset();
            if (_constantRelativeVerticalForce > 0)
                _constantRelativeVerticalForce = -_constantRelativeVerticalForce;
            if (_constantRelativeBackwardForce < 0)
                _constantRelativeBackwardForce = -_constantRelativeBackwardForce;
            _animator.SetBool("LandingGearDeployed", gearDown);
            ResetAnimator();
        }

        internal void Update()
        {
            if (_isVR)
            {
                //allows advanced VR input via thumbstick
                UpdateSteeringVR();
            }
            else
            {
                UpdateSteeringDesktop();
            }
            UpdateWhileInStation();
            UpdateFadeOut();
        }

        /// <summary>
        /// Resets the space shuttle animator to be in the neutral steering position
        /// </summary>
        internal void ResetAnimator()
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
        internal void UpdateFadeOut()
        {
            if (_stickIsHeld)
                return;
            _fadeOutTime += Time.deltaTime;
            if (_fadeOutTime < FADE_OUT_TIME)
            {
                Ship.MoveRotation(Quaternion.Slerp(Ship.rotation, _currentFlightStickRotation, _currentControlSensitivity * Time.deltaTime));
            }
            else
            {
                Log.Debug("[ShipController] Stopped fade-out update.");
            }
        }

        /// <summary>
        /// Is called every frame while the player is in the station to
        /// update the instruments and run the buttons
        /// </summary>
        internal void UpdateWhileInStation()
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
        internal void UpdateInstruments()
        {
#pragma warning disable IDE0018 // Inline variable declaration is not possible in Udon right now
            Vector3 axisVector;
            float axisRotation;
#pragma warning restore IDE0018

            _syncedShipGameObject.transform.rotation.ToAngleAxis(out axisRotation, out axisVector);

            //Mirror pitch
            axisVector.y *= -1;
            _navBall.localRotation = Quaternion.AngleAxis(axisRotation, axisVector);

            //moves from 90 (zero) to -90 (max)
            _altitudeIndicatorBone.localEulerAngles = new Vector3(-74.413f, 180, 83.6f - (173.6f * Mathf.Clamp01(_syncedShipGameObject.transform.position.y / 400)));
            //moves from 90 (zero) to -90 (max)
            _speedIndicatorBone.localEulerAngles = new Vector3(-74.413f, 180, 83.6f - (173.6f * Mathf.Clamp01(Ship.velocity.magnitude / 60)));
        }

        /// <summary>
        /// Is called in every frame while the controller is held in hand for VR users
        /// </summary>
        internal void UpdateSteeringVR()
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
                Ship.MoveRotation(Quaternion.Slerp(Ship.rotation, _currentFlightStickRotation, _currentControlSensitivity * Time.deltaTime));
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
                SyncControlInput(stickRotation.x % 360, stickRotation.y % 360, stickRotation.z % 360);
            }
            else
            {
                _constantForceShipComponent.relativeForce = Vector3.zero;
#if DEBUG_TEST
                Log.Debug("[ShipController] Stopping steering update loop");
#endif
            }
        }

        /// <summary>
        /// Is called in every frame while the controller is held in hand for desktop users
        /// </summary>
        internal void UpdateSteeringDesktop()
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
                Ship.MoveRotation(Quaternion.Slerp(Ship.rotation, _currentFlightStickRotation, _currentControlSensitivity * Time.deltaTime));
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
                SyncControlInput(stickRotation.x % 360, stickRotation.y % 360, rollAngleInput);
                //we call UpdateSteering each frame while the controller is held, to avoid having update loops for empty stations
            }
#if DEBUG_TEST
            else
            {
                Log.Debug("[ShipController] Stopping steering update loop");
            }
#endif
        }

        /// <summary>
        /// Saves the current local stick position offset from the ship, is called at Start()
        /// </summary>
        internal void StoreLocalStickPositionOffset()
        {
            _localFlightStickLocalResetPosition = _flightStickRoot.localPosition;
            _localFlightStickLocalResetRotation = _flightStickRoot.localRotation;
        }

        /// <summary>
        /// Resets the local stick root position offset from the ship, which was stored at Start()
        /// </summary>
        internal void ResetLocalStickPositionOffset()
        {
#if DEBUG_TEST
            Log.Debug("[ShipController] Restored stick position offset");
#endif
            _flightStickRoot.localPosition = _localFlightStickLocalResetPosition;
            _flightStickRoot.localRotation = _localFlightStickLocalResetRotation;
        }

        /// <summary>
        /// Must be called from the station seat when a player entered the pilot chair
        /// </summary>
        internal void OnStationEnter()
        {
#if DEBUG_TEST
            Log.Debug("[ShipController] Player entered this station, called OnStationEnter() locally");
#endif
            foreach (GameObject button in _desktopButtons)
            {
                button.SetActive(true);
            }
            SetButtonHighlightsToCurrentState();
#if DEBUG_TEST
                Log.Debug("[ShipController] LocalPlayer entered the station.");
#endif
            _localPlayerIsInStationSeat = true;
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
        internal void SetButtonHighlightsToCurrentState()
        {
            _buttonHighlightGearDown.SetActive(gearDown);
            _buttonHighlightFlightAssist.SetActive(_flightAssistOn);
        }

        /// <summary>
        /// Disables the current "highlight on" objects on all buttons, regardless of their state
        /// </summary>
        internal void DisableButtonHighlights()
        {
            _buttonHighlightGearDown.SetActive(false);
            _buttonHighlightFlightAssist.SetActive(false);
        }

        /// <summary>
        /// Must be called from the station seat when a player exited the pilot chair
        /// </summary>
        internal void OnStationExit()
        {
#if DEBUG_TEST
                Log.Debug("[ShipController] Player exited this station, called _OnRelayedAllStationExit() locally");
#endif
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
#if DEBUG_TEST
                Log.Debug("[ShipController] LocalPlayer exited the station.");
#endif
            _localPlayerIsInStationSeat = false;
            Ship.isKinematic = true;
            _flightStickPickup.pickupable = false;
            ResetLocalStickPositionOffset();
            _flightStickPickup.Drop();
        }

        /// <summary>
        /// Is called when the flight stick (local pickup) is being picked up.
        /// </summary>
        internal void OnPickup()
        {
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
#if DEBUG_TEST
                    Log.Debug("[ShipController] Starting steering update loop");
#endif
                _stickIsHeld = true;
                if (_addControllerOffset)
                {
                    _controllerXOffset = _isVR ? _controllerXOffsetVRUser : _controllerXOffsetDesktopUser;
                }
            }
        }

        /// <summary>
        /// Is called when the flight stick (local pickup) is being dropped.
        /// </summary>
        internal void OnDrop()
        {
#if DEBUG_TEST
            Log.Debug("[ShipController] Flight stick was dropped, called OnDrop() locally.");
#endif
            Log.Debug("[ShipController] Flight stick was dropped, now fading out steering.");
#if ADMIN_STOP && UDON_TYCOON
            if (_isStoppedByAdmin)
            {
                _stickIsHeld = false;
                return;
            }
#endif
            _stickIsHeld = false;
            if (_addControllerOffset)
            {
                _controllerXOffset = 0;
            }
            DisableAllThrusters();
            //smoothly fade out rotation steering
            _fadeOutTime = 0;
            ResetLocalStickPositionOffset();
        }
    }
}