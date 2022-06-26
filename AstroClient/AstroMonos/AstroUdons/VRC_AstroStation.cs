using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.AstroUdons
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;
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
            Station = gameObject.GetOrAddComponent<VRCStation>();
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
            if (instance.gameObject.name.Equals(Station.gameObject.name))
            {
                OnStationEnterEvent.SafetyRaise();

            }
        }
        private void OnStationExit(VRC.SDKBase.VRCStation instance)
        {
            if (instance.gameObject.name.Equals(Station.gameObject.name))
            {
                OnStationExitEvent.SafetyRaise();
            }
        }

        private void OnStationEnter2(VRC_StationInternal instance)
        {
            if (instance.gameObject.name.Equals(Station.gameObject.name))
            {
                OnStationEnterEvent.SafetyRaise();

            }
        }
        private void OnStationExit2(VRC_StationInternal instance)
        {
            if (instance.gameObject.name.Equals(Station.gameObject.name))
            {
                OnStationExitEvent.SafetyRaise();
            }
        }

        internal void EnterStation()
        {
            Station.UseStation(Networking.LocalPlayer);
        }
        internal void ExitStation()
        {
            Station.ExitStation(Networking.LocalPlayer);
        }



        internal void OnDestroy()
        {
            HasSubscribed = false;
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



        internal Action OnStationEnterEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnStationExitEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal VRC.SDKBase.VRCStation Station { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroInteract StationTrigger  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal bool DenyExits { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
    }
}