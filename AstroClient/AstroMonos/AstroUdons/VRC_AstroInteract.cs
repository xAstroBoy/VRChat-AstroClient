using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;
using UnityEngine;

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
    public class VRC_AstroInteract : MonoBehaviour
    {

        public VRC_AstroInteract(IntPtr ptr) : base(ptr)
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

                        ClientEventActions.Udon_OnInteract += UdonBehaviour_Event_OnInteract;

                    }
                    else
                    {

                        ClientEventActions.Udon_OnInteract -= UdonBehaviour_Event_OnInteract;

                    }
                }
                _HasSubscribed = value;
            }
        }


        private void Start()
        {
            
            UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
            if(UdonBehaviour != null)
            {
                HasSubscribed = true;
                UdonBehaviour._hasInteractiveEvents = true; // This way it activates the interact system in the behaviour
            }
            _ = VRCInteractable; // make the getter not null.
        }

        private void UdonBehaviour_Event_OnInteract(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour)) OnInteract.SafetyRaise();

        }

        internal void OnDestroy()
        {
            HasSubscribed = false;
            if (UdonBehaviour != null)
            {
                Destroy(UdonBehaviour);
            }
        }

        private void OnDisable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = false;
                HasSubscribed = false;
            }
        }

        private void OnEnable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = true;
                HasSubscribed = true;

            }
        }

        private string _interactText = "Use";

        internal string interactText
        {
            [HideFromIl2Cpp] get => _interactText;
            [HideFromIl2Cpp]
            set
            {
                _interactText = value;
                if (UdonBehaviour != null)
                {
                    UdonBehaviour.interactText = value;
                }
                if (VRCInteractable != null)
                {
                    VRCInteractable.interactText = value;
                }
            }
        }
        private string _InteractionText = "Use";

        internal string InteractionText
        {
            [HideFromIl2Cpp]
            get => _InteractionText;
            [HideFromIl2Cpp]
            set
            {
                _InteractionText = value;
                if (UdonBehaviour != null)
                {
                    UdonBehaviour.InteractionText = value;
                }

            }
        }


        private VRCInteractable _VRCInteractable;

        internal VRCInteractable VRCInteractable
        {
            [HideFromIl2Cpp]
            get
            {
                if (_VRCInteractable == null)
                {
                    return _VRCInteractable = gameObject.GetOrAddComponent<VRCInteractable>();
                }

                return _VRCInteractable;
            }
        }

        internal Action OnInteract { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private UdonBehaviour UdonBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}