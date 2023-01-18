using AstroClient;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientAttributes;
using AstroClient.ClientResources.Loaders;
using AstroClient.febucci;
using AstroClient.febucci.Utilities;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using System;
using TMPro;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace ReimajoBoothAssets
{
    [RegisterComponent]
    public class ButtonController : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();

        #region SquaredButtonController

        private GameObject _WorldButton_Squared__staticButtonOn__lod0RendererWhenOnFromStatic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOn__lod0RendererWhenOnFromStatic
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOn__lod0RendererWhenOnFromStatic == null)
                {
                    return _WorldButton_Squared__staticButtonOn__lod0RendererWhenOnFromStatic = this.transform.root.FindObject($"_staticButtonOn/_lod0RendererWhenOnFromStatic").gameObject;
                }

                return _WorldButton_Squared__staticButtonOn__lod0RendererWhenOnFromStatic;
            }
        }

        private GameObject _WorldButton_Squared_DynamicButton__dynamicButtonTopOff_Model { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_DynamicButton__dynamicButtonTopOff_Model
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_DynamicButton__dynamicButtonTopOff_Model == null)
                {
                    return _WorldButton_Squared_DynamicButton__dynamicButtonTopOff_Model = this.transform.root.FindObject($"DynamicButton/_dynamicButtonTopOff/Model").gameObject;
                }

                return _WorldButton_Squared_DynamicButton__dynamicButtonTopOff_Model;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOff__lod0RendererWhenOffFromStatic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOff__lod0RendererWhenOffFromStatic
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOff__lod0RendererWhenOffFromStatic == null)
                {
                    return _WorldButton_Squared__staticButtonOff__lod0RendererWhenOffFromStatic = this.transform.root.FindObject($"_staticButtonOff/_lod0RendererWhenOffFromStatic").gameObject;
                }

                return _WorldButton_Squared__staticButtonOff__lod0RendererWhenOffFromStatic;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOff_ButtonOff_LOD1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOff_ButtonOff_LOD1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOff_ButtonOff_LOD1 == null)
                {
                    return _WorldButton_Squared__staticButtonOff_ButtonOff_LOD1 = this.transform.root.FindObject($"_staticButtonOff/ButtonOff_LOD1").gameObject;
                }

                return _WorldButton_Squared__staticButtonOff_ButtonOff_LOD1;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOff_ButtonOff_LOD2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOff_ButtonOff_LOD2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOff_ButtonOff_LOD2 == null)
                {
                    return _WorldButton_Squared__staticButtonOff_ButtonOff_LOD2 = this.transform.root.FindObject($"_staticButtonOff/ButtonOff_LOD2").gameObject;
                }

                return _WorldButton_Squared__staticButtonOff_ButtonOff_LOD2;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOn
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOn == null)
                {
                    return _WorldButton_Squared__staticButtonOn = this.transform.root.FindObject($"_staticButtonOn").gameObject;
                }

                return _WorldButton_Squared__staticButtonOn;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOff_ButtonOff_LOD0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOff_ButtonOff_LOD0
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOff_ButtonOff_LOD0 == null)
                {
                    return _WorldButton_Squared__staticButtonOff_ButtonOff_LOD0 = this.transform.root.FindObject($"_staticButtonOff/ButtonOff_LOD0").gameObject;
                }

                return _WorldButton_Squared__staticButtonOff_ButtonOff_LOD0;
            }
        }

        private GameObject _WorldButton_Squared_DynamicButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_DynamicButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_DynamicButton == null)
                {
                    return _WorldButton_Squared_DynamicButton = this.transform.root.FindObject($"DynamicButton").gameObject;
                }

                return _WorldButton_Squared_DynamicButton;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOn_ButtonOn_LOD1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOn_ButtonOn_LOD1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOn_ButtonOn_LOD1 == null)
                {
                    return _WorldButton_Squared__staticButtonOn_ButtonOn_LOD1 = this.transform.root.FindObject($"_staticButtonOn/ButtonOn_LOD1").gameObject;
                }

                return _WorldButton_Squared__staticButtonOn_ButtonOn_LOD1;
            }
        }

        private GameObject _WorldButton_Squared_DynamicButton__dynamicButtonTopOn_Model { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_DynamicButton__dynamicButtonTopOn_Model
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_DynamicButton__dynamicButtonTopOn_Model == null)
                {
                    return _WorldButton_Squared_DynamicButton__dynamicButtonTopOn_Model = this.transform.root.FindObject($"DynamicButton/_dynamicButtonTopOn/Model").gameObject;
                }

                return _WorldButton_Squared_DynamicButton__dynamicButtonTopOn_Model;
            }
        }

        private GameObject _WorldButton_Squared_DynamicButton__dynamicButtonTopOff { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_DynamicButton__dynamicButtonTopOff
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_DynamicButton__dynamicButtonTopOff == null)
                {
                    return _WorldButton_Squared_DynamicButton__dynamicButtonTopOff = this.transform.root.FindObject($"DynamicButton/_dynamicButtonTopOff").gameObject;
                }

                return _WorldButton_Squared_DynamicButton__dynamicButtonTopOff;
            }
        }

        private GameObject _WorldButton_Squared_DynamicButton__dynamicButtonTopOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_DynamicButton__dynamicButtonTopOn
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_DynamicButton__dynamicButtonTopOn == null)
                {
                    return _WorldButton_Squared_DynamicButton__dynamicButtonTopOn = this.transform.root.FindObject($"DynamicButton/_dynamicButtonTopOn").gameObject;
                }

                return _WorldButton_Squared_DynamicButton__dynamicButtonTopOn;
            }
        }

        private GameObject _WorldButton_Squared__buttonPushDirection { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__buttonPushDirection
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__buttonPushDirection == null)
                {
                    return _WorldButton_Squared__buttonPushDirection = this.transform.root.FindObject($"_buttonPushDirection").gameObject;
                }

                return _WorldButton_Squared__buttonPushDirection;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOn_ButtonOn_LOD0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOn_ButtonOn_LOD0
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOn_ButtonOn_LOD0 == null)
                {
                    return _WorldButton_Squared__staticButtonOn_ButtonOn_LOD0 = this.transform.root.FindObject($"_staticButtonOn/ButtonOn_LOD0").gameObject;
                }

                return _WorldButton_Squared__staticButtonOn_ButtonOn_LOD0;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOn_ButtonOn_LOD2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOn_ButtonOn_LOD2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOn_ButtonOn_LOD2 == null)
                {
                    return _WorldButton_Squared__staticButtonOn_ButtonOn_LOD2 = this.transform.root.FindObject($"_staticButtonOn/ButtonOn_LOD2").gameObject;
                }

                return _WorldButton_Squared__staticButtonOn_ButtonOn_LOD2;
            }
        }

        private GameObject _WorldButton_Squared__staticButtonOff { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__staticButtonOff
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__staticButtonOff == null)
                {
                    return _WorldButton_Squared__staticButtonOff = this.transform.root.FindObject($"_staticButtonOff").gameObject;
                }

                return _WorldButton_Squared__staticButtonOff;
            }
        }

        private GameObject _WorldButton_Squared_DynamicButton__dynamicButtonBase { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_DynamicButton__dynamicButtonBase
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_DynamicButton__dynamicButtonBase == null)
                {
                    return _WorldButton_Squared_DynamicButton__dynamicButtonBase = this.transform.root.FindObject($"DynamicButton/_dynamicButtonBase").gameObject;
                }

                return _WorldButton_Squared_DynamicButton__dynamicButtonBase;
            }
        }

        private GameObject _WorldButton_Squared__pushArea { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared__pushArea
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared__pushArea == null)
                {
                    return _WorldButton_Squared__pushArea = this.transform.root.FindObject($"_pushArea").gameObject;
                }

                return _WorldButton_Squared__pushArea;
            }
        }

        private GameObject _WorldButton_Squared_ButtonScript { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_ButtonScript
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_ButtonScript == null)
                {
                    return _WorldButton_Squared_ButtonScript = this.transform.root.FindObject($"ButtonScript").gameObject;
                }

                return _WorldButton_Squared_ButtonScript;
            }
        }

        private GameObject _WorldButton_Squared_Canvas { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_Canvas
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_Canvas == null)
                {
                    return _WorldButton_Squared_Canvas = this.transform.root.FindObject($"Canvas").gameObject;
                }

                return _WorldButton_Squared_Canvas;
            }
        }

        private GameObject _WorldButton_Squared_Canvas_Text { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject WorldButton_Squared_Canvas_Text
        {
            [HideFromIl2Cpp]
            get
            {
                if (_WorldButton_Squared_Canvas_Text == null)
                {
                    return _WorldButton_Squared_Canvas_Text = this.transform.root.FindObject($"Canvas/Text").gameObject;
                }

                return _WorldButton_Squared_Canvas_Text;
            }
        }

        #endregion SquaredButtonController

        public ButtonController(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private string _Text = "";
        internal string Text
        {
            [HideFromIl2Cpp]
            get
            {
                return _Text;
            }
            [HideFromIl2Cpp]
            set
            {
                _Text = value;
                if (TextMesh == null)
                {
                    TextMesh = WorldButton_Squared_Canvas_Text.GetOrAddComponent<TextMeshPro>();
                }
                if (TextMeshAnimator == null)
                {
                    TextMeshAnimator = TextMesh.GetOrAddComponent<TextAnimator>();
                }
                TextMeshAnimator.Safe_SetText(value);
            }
        }

        internal Vector3 DefaultCanvasLocation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal bool isToggle { get; set; } = true;
        internal TextAnimator TextMeshAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal TextMeshPro TextMesh { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnButtonUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnButtonDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Relevant bone from the left hand (of localPlayer), can be set by an external script for better usability of the keyboard accross all players.
        /// One such script is my AvatarCalibrationScript which I sell on my booth page.
        /// </summary>
        public HumanBodyBones leftIndexBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.LeftIndexDistal;

        /// <summary>
        /// Relevant bone from the right hand (of localPlayer), can be set by an external script for better usability of the keyboard accross all players.
        /// One such script is my AvatarCalibrationScript which I sell on my booth page.
        /// </summary>
        public HumanBodyBones rightIndexBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.RightIndexDistal;

        /// <summary>
        /// Avatar height in meter (of localPlayer), can be set by an external script for better usability of the keyboard.
        /// Afterwards, OnAvatarChanged() must be called on this script.
        /// One such script that does all of that is my AvatarCalibrationScript which I sell on my booth page.
        /// </summary>
        public float avatarHeight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 1.3f;

        /// <summary>
        /// If the button is on / green at start (can be used to set the default state in editor,
        /// do not modify this at runtime, only use _ExternalButtonOn() and _ExternalButtonOff() for this)
        /// </summary>
        private bool isOnAtStart { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// Audio that plays when the button is released after being fully pressed down
        /// </summary>
        private AudioClip clickUpAudioClip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Audio that plays when the button is fully pressed down
        /// </summary>
        private AudioClip clickDownAudioClip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// LOD renderer that activates the push detection (should be LOD0) when the button is on
        /// </summary>
        private Renderer lod0RendererWhenOnFromStatic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// LOD renderer that activates the push detection (should be LOD0) when the button is off
        /// </summary>
        private Renderer lod0RendererWhenOffFromStatic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Area in which pushing the button is calculated if any bones are inside
        /// </summary>
        private BoxCollider pushArea { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Button top (the pushable part of the button) for when the button is dynamic and on
        /// </summary>
        private GameObject dynamicButtonTopOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Button top (the pushable part of the button) for when the button is dynamic and off
        /// </summary>
        private GameObject dynamicButtonTopOff { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Button base (the static part of the button) for when the button is dynamic
        /// </summary>
        private GameObject dynamicButtonBase { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Static button model for when the button is on but not being pushed
        /// </summary>
        private GameObject staticButtonOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Static button model for when the button is off but not being pushed
        /// </summary>
        private GameObject staticButtonOff { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Start position of the button when not pressed and push direction (blue axis / forward direction).
        /// This object is set to the _buttonPushDirection position at Start().
        /// </summary>
        private Transform buttonPushDirection { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Finger thickness of a standard sized avatar (1.3m), will automatically scale with avatar size
        /// </summary>
        private const float FINGER_THICKNESS_DEFAULT = 0.02f;

        /// <summary>
        /// How far the button can be pressed down from the start position at scale 1
        /// </summary>
        private const float BUTTON_PUSH_DISTANCE_DEFAULT = 0.03f;

        /// <summary>
        /// At how much of BUTTON_PUSH_DISTANCE the button will trigger,
        /// from 0 to 1, recommended is 0.9 (90%)
        /// </summary>
        private const float BUTTON_TRIGGER_PERCENTAGE = 0.9f;

        /// <summary>
        /// At how much of BUTTON_PUSH_DISTANCE the button will un-trigger to be pushable again,
        /// from 0 to 1, recommended is 0.55 (55%)
        /// </summary>
        private const float BUTTON_UNTRIGGER_PERCENTAGE = 0.55f;

        /// <summary>
        /// Speed in meters/second at which the button will move itself at scale 1
        /// </summary>
        private const float MOVING_SPEED_DEFAULT = 0.2f;

        /// <summary>
        /// Minimal time (in seconds) that must pass between two button triggers
        /// </summary>
        private const float MIN_TRIGGER_TIME_OFFSET = 0.2f;

        private bool isOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Current button top of the pushable part of the button
        /// </summary>
        private Transform currentDynamicButtonTop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool isMovingDownDesktop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private float buttonPushDistance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = BUTTON_PUSH_DISTANCE_DEFAULT;
        private float buttonMovingSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = MOVING_SPEED_DEFAULT;
        private float buttonTriggerDistance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float buttonUntriggerDistance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float fingerThickness { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float lastTriggerTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Renderer lodLevelRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool hasNotFinishedStart { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;
        private float handPushDistance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool wasTriggered { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private bool wasPushing { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private bool isPushingRightNow { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private float currentPushedDistance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool leftHandIsClosest { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private MeshCollider desktopButtonCollider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroInteract DesktopInteraction { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool isVR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool isInDesktopFallbackMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool desktopButtonForVrDisabled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        /// <summary>
        /// The (other) furthest bones from the current avatar. The first index finger can be found in the API region.
        /// </summary>
        private HumanBodyBones fingerbone2r { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.RightLittleDistal;

        private HumanBodyBones fingerbone3r { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.RightMiddleDistal;
        private HumanBodyBones fingerbone4r { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.RightRingDistal;
        private HumanBodyBones fingerbone5r { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.RightThumbDistal;
        private HumanBodyBones fingerbone2l { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.LeftLittleDistal;
        private HumanBodyBones fingerbone3l { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.LeftMiddleDistal;
        private HumanBodyBones fingerbone4l { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.LeftRingDistal;
        private HumanBodyBones fingerbone5l { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = HumanBodyBones.LeftThumbDistal;
        private bool HasInitialized { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// Checks in which direction the button is currently oriented
        /// </summary>
        internal void Start()
        {
            if (!HasInitialized)
            {
                TextMesh = WorldButton_Squared_Canvas_Text.GetOrAddComponent<TextMeshPro>();
                clickDownAudioClip = AudioClips.WorldButton_clickDownAudioClip;
                clickUpAudioClip = AudioClips.WorldButton_clickUpAudioClip;
                DefaultCanvasLocation = WorldButton_Squared_Canvas.transform.localPosition;
                lod0RendererWhenOnFromStatic = WorldButton_Squared__staticButtonOn__lod0RendererWhenOnFromStatic.GetComponent<MeshRenderer>();
                lod0RendererWhenOffFromStatic = WorldButton_Squared__staticButtonOff__lod0RendererWhenOffFromStatic.GetComponent<MeshRenderer>();
                pushArea = WorldButton_Squared__pushArea.GetComponent<BoxCollider>();
                dynamicButtonTopOn = WorldButton_Squared_DynamicButton__dynamicButtonTopOn;
                dynamicButtonTopOff = WorldButton_Squared_DynamicButton__dynamicButtonTopOff;
                dynamicButtonBase = WorldButton_Squared_DynamicButton__dynamicButtonBase;
                staticButtonOn = WorldButton_Squared__staticButtonOn;
                staticButtonOff = WorldButton_Squared__staticButtonOff;
                buttonPushDirection = WorldButton_Squared__buttonPushDirection.transform;
                desktopButtonCollider = this.GetComponent<MeshCollider>();
                DesktopInteraction = desktopButtonCollider.GetOrAddComponent<VRC_AstroInteract>();
                if (DesktopInteraction != null)
                {
                    DesktopInteraction.OnInteract += Interact;
                    DesktopInteraction.interactText = "Click";
                }
                isOn = isOnAtStart;
                isVR = GameInstances.LocalPlayer.IsUserInVR();
                if (desktopButtonCollider == null)
                {
                    Log.Error($"[ButtonController] No MeshCollider assigned to button '{this.transform.parent.name}'");
                    this.gameObject.SetActive(false);
                    return;
                }
                if (desktopButtonForVrDisabled)
                {
                    if (desktopButtonCollider != null) desktopButtonCollider.enabled = !isVR; //disable for VR user, enable for desktop user
                    if (DesktopInteraction != null) DesktopInteraction.enabled = !isVR;
                }
                else
                {
                    if (DesktopInteraction != null) desktopButtonCollider.enabled = true; //enable for all users
                    if (DesktopInteraction != null) DesktopInteraction.enabled = true;
                }
                InitializeButtonSwitch();
                MakeStatic();
                buttonPushDirection.position = isOn ? dynamicButtonTopOn.transform.position : dynamicButtonTopOff.transform.position;
                SetupButtonDistances();
                fingerThickness = FINGER_THICKNESS_DEFAULT;
                hasNotFinishedStart = false;
                HasInitialized = true;
            }
        }


        /// <summary>
        /// Determines all button distances at start
        /// </summary>
        internal void SetupButtonDistances()
        {
            float scale = this.transform.lossyScale.y;
            buttonPushDistance = BUTTON_PUSH_DISTANCE_DEFAULT * scale;
            buttonMovingSpeed = MOVING_SPEED_DEFAULT * scale;
            if (buttonPushDistance < 0)
                buttonPushDistance *= -1f; //correct potential user error
            buttonTriggerDistance = buttonPushDistance * BUTTON_TRIGGER_PERCENTAGE;
            buttonUntriggerDistance = buttonPushDistance * BUTTON_UNTRIGGER_PERCENTAGE;
        }

        /// <summary>
        /// Only run script when target LOD is active
        /// </summary>
        private void Update()
        {
            if (lodLevelRenderer.isVisible || wasPushing)
            {
                if (isVR)
                    RunButtonForVR();
                else
                    RunButtonForDesktop();
            }
        }

        /// <summary>
        /// Is called from my player calibration script (https://reimajo.booth.pm/items/2753511) when the avatar changed
        /// This is externally called after setting _avatarHeight (happening after localPlayer changed their avatar)
        /// </summary>
        internal void OnAvatarChanged()
        {
            if (hasNotFinishedStart)
                return;
            if (isVR)
            {
                if (leftIndexBone == HumanBodyBones.LeftLowerArm || rightIndexBone == HumanBodyBones.RightLowerArm)
                {
                    //enable the "desktop" mode because the player is missing all finger bones
                    desktopButtonCollider.enabled = true;
                    DesktopInteraction.enabled = true;
                    isVR = false;
                    isInDesktopFallbackMode = true;
                }
                else
                {
                    //distances are made for a 1.3m avatar as a reference
                    fingerThickness = FINGER_THICKNESS_DEFAULT * avatarHeight / 1.3f;
                    //determine the furthest bones from all other fingers
                    fingerbone2r = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.RightLittleDistal) == Vector3.zero ? HumanBodyBones.RightLittleIntermediate : HumanBodyBones.RightLittleDistal;
                    fingerbone3r = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.RightMiddleDistal) == Vector3.zero ? HumanBodyBones.RightMiddleIntermediate : HumanBodyBones.RightMiddleDistal;
                    fingerbone4r = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.RightRingDistal) == Vector3.zero ? HumanBodyBones.RightRingIntermediate : HumanBodyBones.RightRingDistal;
                    fingerbone5r = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.RightThumbDistal) == Vector3.zero ? HumanBodyBones.RightThumbIntermediate : HumanBodyBones.RightThumbDistal;
                    fingerbone2l = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.LeftLittleDistal) == Vector3.zero ? HumanBodyBones.LeftLittleIntermediate : HumanBodyBones.LeftLittleDistal;
                    fingerbone3l = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.LeftMiddleDistal) == Vector3.zero ? HumanBodyBones.LeftMiddleIntermediate : HumanBodyBones.LeftMiddleDistal;
                    fingerbone4l = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.LeftRingDistal) == Vector3.zero ? HumanBodyBones.LeftRingIntermediate : HumanBodyBones.LeftRingDistal;
                    fingerbone5l = GameInstances.LocalPlayer.GetBonePosition(HumanBodyBones.LeftThumbDistal) == Vector3.zero ? HumanBodyBones.LeftThumbIntermediate : HumanBodyBones.LeftThumbDistal;
                }
            }
            else if (isInDesktopFallbackMode)
            {
                if (leftIndexBone != HumanBodyBones.LastBone && rightIndexBone != HumanBodyBones.LastBone)
                {
                    isInDesktopFallbackMode = false;
                    if (desktopButtonForVrDisabled)
                    {
                        //enable the regular VR mode again
                        desktopButtonCollider.enabled = false;
                        DesktopInteraction.enabled = false;
                        isVR = true;
                    }
                }
            }
        }

        /// <summary>
        /// After determining where the hand bones are, the button runs in 3 steps:
        /// 1. Move the button down if the hand is in bounds & more pushed then it currently was,
        ///    fire ButtonDown() when the button passes the trigger distance.
        /// 2. Move the button back if the hand is no longer in bounds or less pushed then it currently was
        /// 3. Fire the ButtonUp() event when the button moves back and passes the unTrigger-distance after
        ///    it was triggered
        /// </summary>
        internal void RunButtonForVR()
        {
            CheckAllFingerBones();
            //check if at least one of the bones was in bounds
            if (isPushingRightNow && currentPushedDistance <= handPushDistance)
            {
                if (!wasPushing)
                {
                    wasPushing = true;
                    MakeDynamic();
                }
                //pushing the button down
                currentPushedDistance = Mathf.Min(handPushDistance, buttonPushDistance);
                currentDynamicButtonTop.transform.position = buttonPushDirection.position + (buttonPushDirection.forward * currentPushedDistance);
                //trigger action when limit reached
                if (!wasTriggered && currentPushedDistance >= buttonTriggerDistance && (Time.time - lastTriggerTime) > MIN_TRIGGER_TIME_OFFSET)
                {
                    lastTriggerTime = Time.time;
                    ButtonDownEvent();
                    UpdateDynamicButtonObjects();
                    wasTriggered = true;
                    AudioSource.PlayClipAtPoint(clickDownAudioClip, buttonPushDirection.position, 0.1f);
                    if (leftHandIsClosest)
                        GameInstances.LocalPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Left, 0.1f, 1.0f, 30f); //seconds, 0-320hz, 0-1 aplitude
                    else
                        GameInstances.LocalPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Right, 0.1f, 1.0f, 30f); //seconds, 0-320hz, 0-1 aplitude
                }
            }
            else if (wasPushing)
            {
                //cap hand push distance
                handPushDistance = Mathf.Min(handPushDistance, buttonPushDistance);
                //move it slowly back, but not further than it's currently being pushed
                currentPushedDistance = Mathf.Max(handPushDistance, currentPushedDistance - (Time.deltaTime * buttonMovingSpeed));
                currentDynamicButtonTop.transform.position = buttonPushDirection.position + (buttonPushDirection.forward * currentPushedDistance);
                //stop when it's fully moved back
                if (currentPushedDistance <= 0)
                {
                    wasPushing = false;
                    MakeStatic();
                }
            }
            //wait until the button moved x percent back to set _wastriggered to false
            if (wasTriggered)
            {
                if (currentPushedDistance <= buttonUntriggerDistance)
                {
                    wasTriggered = false;
                    ButtonUpEvent();
                    AudioSource.PlayClipAtPoint(clickUpAudioClip, buttonPushDirection.position, 0.1f);
                    if (isPushingRightNow)
                    {
                        if (leftHandIsClosest)
                            GameInstances.LocalPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Left, 0.1f, 1.0f, 30f); //seconds, 0-320hz, 0-1 amplitude
                        else
                            GameInstances.LocalPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Right, 0.1f, 1.0f, 30f); //seconds, 0-320hz, 0-1 amplitude
                    }
                }
            }
        }

        /// <summary>
        /// Checks all finger bones if they are in bounds to get the highest push distance of all bones
        /// </summary>
        internal void CheckAllFingerBones()
        {
            //check all bones if one is pushing the button
            isPushingRightNow = false;
            //reset to 0, will be set by the following methods to the highest value
            handPushDistance = 0;
            //check all left hand bones
            CheckBoneDistance(leftIndexBone, isLeftHand: true);
            CheckBoneDistance(fingerbone2l, isLeftHand: true);
            CheckBoneDistance(fingerbone3l, isLeftHand: true);
            CheckBoneDistance(fingerbone4l, isLeftHand: true);
            CheckBoneDistance(fingerbone5l, isLeftHand: true);
            //check all right hand bones
            CheckBoneDistance(rightIndexBone, isLeftHand: false);
            CheckBoneDistance(fingerbone2r, isLeftHand: false);
            CheckBoneDistance(fingerbone3r, isLeftHand: false);
            CheckBoneDistance(fingerbone4r, isLeftHand: false);
            CheckBoneDistance(fingerbone5r, isLeftHand: false);
            //check all hand bones
            CheckBoneDistance(HumanBodyBones.RightHand, isLeftHand: false);
            CheckBoneDistance(HumanBodyBones.LeftHand, isLeftHand: true);
        }

        /// <summary>
        /// Checks a single bone if it's inside bounds. If true, the distance to the bone is measured against _buttonPushDirection
        /// </summary>
        internal void CheckBoneDistance(HumanBodyBones bone, bool isLeftHand)
        {
            Vector3 position = GameInstances.LocalPlayer.GetBonePosition(bone);
            if (pushArea.bounds.Contains(position))
            {
                //measure distances to hand bone
                float distanceToHandNew = SignedDistancePlanePoint(buttonPushDirection.transform.forward, buttonPushDirection.position, position) + fingerThickness;
                //only the lowest distance is important for us. Must be lower than 0 to be behind the _buttonPushDirection plane.
                if (distanceToHandNew > 0)
                {
                    //only relevant if the current value is bigger than the last value
                    if (handPushDistance < distanceToHandNew)
                    {
                        handPushDistance = distanceToHandNew;
                        leftHandIsClosest = isLeftHand;
                        isPushingRightNow = true;
                    }
                }
            }
        }

        /// <summary>
        /// Is called when a desktop user clicks on the button collider.
        /// Do not call this method from your own scripts, use the API instead.
        /// </summary>
        internal void Interact()
        {
            if (isVR) //avoid that others use this in VR mode which would lead to unexpected behaviour, use the API instead
                return;
            if (wasTriggered || isMovingDownDesktop || (Time.time - lastTriggerTime) <= MIN_TRIGGER_TIME_OFFSET)
                return;
            if (!wasPushing) //used to determine if the button is currently static or moving
            {
                wasPushing = true;
                MakeDynamic();
            }
            desktopButtonCollider.enabled = false;
            DesktopInteraction.enabled = false;
            isMovingDownDesktop = true;
            wasTriggered = true;
        }

        /// <summary>
        /// Animates the button to move down and then back up while accurately firing the button events like in VR mode
        /// </summary>
        internal void RunButtonForDesktop()
        {
            if (!wasPushing)
                return;
            //check if at least one of the bones was in bounds
            if (isMovingDownDesktop)
            {
                //pushing the button down
                currentPushedDistance = Mathf.Min(buttonPushDistance, currentPushedDistance + (Time.deltaTime * buttonMovingSpeed));
                currentDynamicButtonTop.transform.position = buttonPushDirection.position + (buttonPushDirection.forward * currentPushedDistance);
                //trigger action when limit reached
                if (currentPushedDistance >= buttonTriggerDistance)
                {
                    ButtonDownEvent();
                    UpdateDynamicButtonObjects();
                    AudioSource.PlayClipAtPoint(clickDownAudioClip, buttonPushDirection.position, 0.1f);
                    lastTriggerTime = Time.time;
                    wasTriggered = true;
                    isMovingDownDesktop = false;
                }
            }
            else
            {
                //move it slowly back, but not further than it's currently being pushed
                currentPushedDistance = Mathf.Max(0, currentPushedDistance - (Time.deltaTime * buttonMovingSpeed));
                currentDynamicButtonTop.transform.position = buttonPushDirection.position + (buttonPushDirection.forward * currentPushedDistance);
                //wait until the button moved x percent back to set _wastriggered to false
                if (wasTriggered)
                {
                    if (currentPushedDistance <= buttonUntriggerDistance)
                    {
                        wasTriggered = false;
                        desktopButtonCollider.enabled = true;
                        DesktopInteraction.enabled = true;
                        ButtonUpEvent();
                        AudioSource.PlayClipAtPoint(clickUpAudioClip, buttonPushDirection.position, 0.1f);
                    }
                }
                //stop when it's fully moved back
                if (currentPushedDistance <= 0)
                {
                    wasPushing = false;
                    MakeStatic();
                }
            }
        }

        /// <summary>
        /// Call this event from your own scripts to enable the desktop button for VR users
        /// </summary>
        internal void EnableDesktopButtonForVR()
        {
            if (desktopButtonForVrDisabled)
            {
                desktopButtonForVrDisabled = false;
                //enable the "desktop" mode
                isVR = false;
                //don't access the desktop button collider too early since that one is fetched at start
                if (hasNotFinishedStart)
                    return;
                desktopButtonCollider.enabled = true;
                DesktopInteraction.enabled = true;
            }
        }

        /// <summary>
        /// Call this event from your own scripts to enable the desktop button for VR users
        /// </summary>
        internal void DisableDesktopButtonForVR()
        {
            if (desktopButtonForVrDisabled) { }
            else
            {
                desktopButtonForVrDisabled = true;
                if (isInDesktopFallbackMode)
                    return;
                //disable the "desktop" mode
                isVR = true;
                //don't access the desktop button collider too early since that one is fetched at start
                if (hasNotFinishedStart)
                    return;
                desktopButtonCollider.enabled = false;
                DesktopInteraction.enabled = false;
            }
        }

        /// <summary>
        /// Call this event from your own scripts to toggle the button
        /// </summary>
        internal void ToggleButton()
        {
            if (isOn)
            {
#if DEBUG_TEST
                Log.Debug($"[ButtonController] '{_buttonDebugName}' is TOGGLED to OFF by an external script.");
#endif
            }
            else
            {
#if DEBUG_TEST
                Log.Debug($"[ButtonController] '{_buttonDebugName}' is TOGGLED to ON by an external script.");
#endif
            }
            ButtonDownEvent();
            UpdateButtonState();
        }

        /// <summary>
        /// Sets the button current status without firing the events or animating it.
        /// </summary>
        /// <param name="status"></param>
        internal void SetButtonToggle(bool status)
        {
            if (isToggle)
            {
                this.isOn = status;
            }
            else
            {
                this.isOn = true;
            }
            UpdateButtonState();
        }

        /// <summary>
        /// Update the button appearance.
        /// </summary>
        internal void UpdateButtonState()
        {
            if (wasPushing)
                UpdateDynamicButtonObjects();
            else
                UpdateStaticButtonObjects();
        }

        /// <summary>
        /// Fires when the button goes down and reached the trigger distance while button is dynamic
        /// </summary>
        internal void ButtonDownEvent()
        {
            if (isToggle)
            {
                isOn = !isOn;
            }
            else
            {
                isOn = true;
            }
            OnButtonDown.SafetyRaise();
        }

        /// <summary>
        /// Updates the dynamic button objects (assuming it is currently in the dynamic state)
        /// </summary>
        internal void UpdateDynamicButtonObjects()
        {
            if (isOn)
            {
                dynamicButtonTopOn.transform.position = currentDynamicButtonTop.position;
                currentDynamicButtonTop = dynamicButtonTopOn.transform;
                //MoveText(dynamicButtonTopOn);
                dynamicButtonTopOn.SetActive(true);
                dynamicButtonTopOff.SetActive(false);
            }
            else
            {
                dynamicButtonTopOff.transform.position = currentDynamicButtonTop.position;
                currentDynamicButtonTop = dynamicButtonTopOff.transform;
                //MoveText(dynamicButtonTopOff);
                dynamicButtonTopOn.SetActive(false);
                dynamicButtonTopOff.SetActive(true);
            }
        }

        /// <summary>
        /// Updates the static button objects (assuming it is currently in the static state)
        /// </summary>
        internal void UpdateStaticButtonObjects()
        {
            if (isOn)
            {
                staticButtonOn.SetActive(true);
                staticButtonOff.SetActive(false);
                lodLevelRenderer = lod0RendererWhenOnFromStatic;
            }
            else
            {
                staticButtonOn.SetActive(false);
                staticButtonOff.SetActive(true);
                lodLevelRenderer = lod0RendererWhenOffFromStatic;
            }
        }

        /// <summary>
        /// Fires when button is released after being triggered and reached the un-trigger distance
        /// </summary>
        internal void ButtonUpEvent()
        {
            OnButtonUp.SafetyRaise();
        }

        /// <summary>
        /// To initialize the button switch, all switching components must be disabled
        /// </summary>
        internal void InitializeButtonSwitch()
        {
            staticButtonOn.SetActive(false);
            staticButtonOff.SetActive(false);
            dynamicButtonTopOn.SetActive(false);
            dynamicButtonTopOff.SetActive(false);
        }


        /// <summary>
        /// Switch button to the static version in which it has one drawcall less and can also be marked as static
        /// This state is always active while the button is not in direct operation
        /// </summary>
        internal void MakeStatic()
        {
            dynamicButtonBase.SetActive(false);
            //turn on static button part
            if (isOn)
            {
                dynamicButtonTopOn.SetActive(false); //turn off dynamic part
                staticButtonOn.SetActive(true);

                lodLevelRenderer = lod0RendererWhenOnFromStatic;
            }
            else
            {
                dynamicButtonTopOff.SetActive(false); //turn off dynamic part
                staticButtonOff.SetActive(true);
                lodLevelRenderer = lod0RendererWhenOffFromStatic;
            }
            //Log.Debug($"[ButtonController] '{this.gameObject.name}' turned to static");
        }

        /// <summary>
        /// Switch button to the dynamic version in which it has one drawcall more but can move
        /// This state is only held during direct operation of the button
        /// </summary>
        private void MakeDynamic()
        {
            //turn on dynamic base
            dynamicButtonBase.SetActive(true);
            //turn on moving dynamic part
            if (isOn)
            {
                staticButtonOn.SetActive(false); //turn of static part
                dynamicButtonTopOn.SetActive(true);
                currentDynamicButtonTop = dynamicButtonTopOn.transform;
            }
            else
            {
                staticButtonOff.SetActive(false); //turn of static part
                dynamicButtonTopOff.SetActive(true);
                currentDynamicButtonTop = dynamicButtonTopOff.transform;
            }
            //Log.Debug($"[ButtonController] '{this.gameObject.name}' turned to dynamic");
        }

        /// <summary>
        /// Get the shortest distance between a point and a plane (signed to include the direction as well)
        /// </summary>
        public float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
        {
            return Vector3.Dot(planeNormal, (point - planePoint));
        }
    }
}