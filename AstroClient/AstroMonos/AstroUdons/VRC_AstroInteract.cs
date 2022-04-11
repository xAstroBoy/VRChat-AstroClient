using AstroClient.Tools.UdonEditor;

namespace AstroClient.AstroMonos.AstroUdons
{
    using System;
    using ClientAttributes;
    using Programs;
    using UnhollowerBaseLib.Attributes;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class VRC_AstroInteract : AstroMonoBehaviour
    {

        public VRC_AstroInteract(IntPtr ptr) : base(ptr)
        {
        }


        private void Start()
        {
            
            UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
            if(UdonBehaviour != null)
            {
                UdonBehaviour._hasInteractiveEvents = true; // This way it activates the trigger system in the behaviour
            }
        }

        internal override void UdonBehaviour_Event_OnInteract(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour)) OnInteract.SafetyRaise();

        }

        internal void OnDestroy()
        {
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
            }
        }

        private void OnEnable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = true;
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