using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Input;
using AstroClient.xAstroBoy.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC.SDKBase;
using VRCSDK2;

namespace AstroClient.AstroMonos.AstroUdons
{
    using ClientAttributes;
    using System;
    using UnhollowerBaseLib.Attributes;
    using VRC.SDK3.Components;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class VRC_AstroStation : MonoBehaviour
    {
        public VRC_AstroStation(IntPtr ptr) : base(ptr)
        {
        }

        private bool _HasSubscribed = false;

        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnStationEnter += OnStationEnter;
                        ClientEventActions.OnStationExit += OnStationExit;
                        ClientEventActions.OnStationEnter2 += OnStationEnter2;
                        ClientEventActions.OnStationExit2 += OnStationExit2;
                    }
                    else
                    {
                        ClientEventActions.OnStationEnter -= OnStationEnter;
                        ClientEventActions.OnStationExit -= OnStationExit;
                        ClientEventActions.OnStationEnter2 -= OnStationEnter2;
                        ClientEventActions.OnStationExit2 -= OnStationExit2;
                    }
                }
                _HasSubscribed = value;
            }
        }

        private void Start()
        {
            Identifier = "AstroStation_" + Guid.NewGuid().ToString();
            if (SceneUtils.SDKVersion == 2)
            {
                Station = gameObject.GetOrAddComponent<VRC_Station>();
            }
            else if (SceneUtils.SDKVersion == 3)
            {
                Station = gameObject.GetOrAddComponent<VRCStation>();
            }
            inAxisHorizontal = InputUtils.GetInput(VRCInputs.Horizontal);
            inAxisVertical = InputUtils.GetInput(VRCInputs.Vertical);
            StationTrigger = gameObject.GetOrAddComponent<VRC_AstroInteract>();
            if (StationTrigger != null)
            {
                StationTrigger.OnInteract = EnterStation;
                StationTrigger.interactText = "Sit";
                StationTrigger.InteractionText = "Sit";
                HasSubscribed = true;
            }
        }

        private void OnStationEnter(VRC.SDKBase.VRCStation instance)
        {
            var AstroStation = instance.gameObject.GetComponent<VRC_AstroStation>();
            if (AstroStation != null)
            {
                if (AstroStation.Identifier.Equals(Identifier))
                {
                    OnStationEnterEvent.SafetyRaise();
                }
            }
        }

        private void OnStationExit(VRC.SDKBase.VRCStation instance)
        {
            var AstroStation = instance.gameObject.GetComponent<VRC_AstroStation>();
            if (AstroStation != null)
            {
                if (AstroStation.Identifier.Equals(Identifier))
                {
                    OnStationExitEvent.SafetyRaise();
                }
            }
        }

        private void OnStationEnter2(VRC_StationInternal instance)
        {
            var AstroStation = instance.gameObject.GetComponent<VRC_AstroStation>();
            if (AstroStation != null)
            {
                if (AstroStation.Identifier.Equals(Identifier))
                {
                    OnStationEnterEvent.SafetyRaise();
                }
            }
        }

        private void OnStationExit2(VRC_StationInternal instance)
        {
            var AstroStation = instance.gameObject.GetComponent<VRC_AstroStation>();
            if (AstroStation != null)
            {
                if(AstroStation.Identifier.Equals(Identifier))
                {
                    OnStationExitEvent.SafetyRaise();
                }
            }
        }

        internal void EnterStation()
        {
            if (!isSeated)
            {
                Station.UseStation(Player);
                StationTrigger.DisableInteractive = true;
                OnStationEnterEvent.SafetyRaise();
                isSeated = true;
            }
        }

        internal void ExitStation()
        {
            if (isSeated)
            {
                BlockVanillaStationExit = false;
                Station.ExitStation(Player);
                StationTrigger.DisableInteractive = false;
                OnStationExitEvent.SafetyRaise();
                isSeated = false;
            }
        }


        void Update()
        {
            // Makes the chair act as a normal item as the height limit has been reached, aka eject the player, avoiding some bugs as well.
            if (base.transform.position.y < SceneUtils.RespawnHeightY)
            {
                ExitStation();
            }
            if (!BlockVanillaStationExit) return;
            if (!isSeated) return;
            // Needed to Bypass broken Chairs relying on anti-motion sickness, as is bugging some events.
            // taken from VRChat mono version, should be technically the same, if the original one is blocked, act as a replacement.
            Vector2 zero = Vector2.zero;
            if (this.inAxisHorizontal == null || this.inAxisVertical == null)
            {
                Log.Debug("StationUseExit input(s) are null!");
            }
            zero.x = this.inAxisHorizontal.GetAxis();
            zero.y = this.inAxisVertical.GetAxis();
            if (zero.sqrMagnitude > 0f)
            {
                ExitStation();
            }
        }

        internal void OnDestroy()
        {
            HasSubscribed = false;
            BlockVanillaStationExit = false;
            //ExitStation();
            Station.DestroyMeLocal();
        }

        private void OnDisable()
        {
            Station.enabled = false;
        }

        private void OnEnable()
        {
            Station.enabled = true;
        }

        internal VRCPlayerApi Player
        {
            [HideFromIl2Cpp]
            get => Networking.LocalPlayer;
        }

        internal Action OnStationEnterEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnStationExitEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal VRC.SDKBase.VRCStation Station { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroInteract StationTrigger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal bool BlockVanillaStationExit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        private VRCInput inAxisVertical { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private VRCInput inAxisHorizontal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool isSeated { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal string Identifier  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
    }
}