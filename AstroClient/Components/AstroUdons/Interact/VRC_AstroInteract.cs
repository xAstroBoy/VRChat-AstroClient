namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using System;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;

    [RegisterComponent]
    public class VRC_AstroInteract : MonoBehaviour
    {
        public VRC_AstroInteract(IntPtr ptr)
            : base(ptr)
        {
        }

        private SerializedUdonProgramAsset AssignedProgram { get; } = UdonPrograms.InteractProgram;

        private void Start()
        {
            if (AssignedProgram == null)
            {
                ModConsole.DebugError("Custom Trigger Can't Load as Program Asset is null!");
                Destroy(this);
            }

            UdonBehaviour = base.gameObject.AddComponent<UdonBehaviour>();
            if (UdonBehaviour != null)
            {
                UdonBehaviour.serializedProgramAsset = AssignedProgram;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
                UdonBehaviour.interactText = interactText;
            }
            DoChecks();
        }

        private void DoChecks()
        {
            if (UdonBehaviour == null)
            {
                UdonBehaviour = base.gameObject.AddComponent<UdonBehaviour>();
                UdonBehaviour.serializedProgramAsset = AssignedProgram;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
                UdonBehaviour.interactText = interactText;
            }
            else
            {
                if (UdonBehaviour.serializedProgramAsset == null)
                {
                    UdonBehaviour.serializedProgramAsset = AssignedProgram;
                    UdonBehaviour.InitializeUdonContent();
                    UdonBehaviour.Start();
                }

                if (UdonBehaviour != null && UdonBehaviour._udonVM != null)
                {
                    if (IUdonHeap == null)
                    {
                        IUdonHeap = UdonBehaviour._udonVM.InspectHeap();
                    }
                }
            }
        }

        internal void FixedUpdate()
        {
            if (IUdonHeap != null)
            {
                if (Get_OnInteract)
                {
                    OnInteract();
                }
            }
        }

        private bool Get_OnInteract
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(2u).Unbox<bool>();
                IUdonHeap.CopyHeapVariable(3u, 2u);
                return result;
            }
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
            get => _interactText;
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

        internal bool ForceInteractiveText { get; set; } = false;

        private VRCInteractable _VRCInteractable;

        private VRCInteractable VRCInteractable
        {
            get
            {
                if (_VRCInteractable == null)
                {
                    if (ForceInteractiveText)
                    {
                        return _VRCInteractable = gameObject.AddComponent<VRCInteractable>();
                    }
                    return _VRCInteractable = gameObject.GetComponent<VRCInteractable>();
                }
                return _VRCInteractable;
            }
        }

        internal Action OnInteract { get; set; }
        private UdonBehaviour UdonBehaviour { get; set; }
        private IUdonHeap IUdonHeap { get; set; }
    }
}