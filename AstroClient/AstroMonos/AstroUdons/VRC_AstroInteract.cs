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
        public VRC_AstroInteract(IntPtr ptr)
            : base(ptr)
        {
        }

        private SerializedUdonProgramAsset AssignedProgram { [HideFromIl2Cpp] get; } = UdonPrograms.InteractProgram;

        private void Start()
        {
            if (AssignedProgram == null)
            {
                ModConsole.Error("Custom Trigger Can't Load as Program Asset is null!");
                Destroy(this);
            }

            UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
            if (UdonBehaviour != null)
            {
                UdonBehaviour.serializedProgramAsset = AssignedProgram;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
                UdonBehaviour.interactText = interactText;
            }

            DoChecks();
            RawItem = UdonBehaviour.ToRawUdonBehaviour();
            Initialize_InteractVars();
        }

        private void DoChecks()
        {
            if (UdonBehaviour == null)
            {
                UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
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
            }
        }

        internal void FixedUpdate()
        {
            if (RawItem != null)
            {
                if (Get_OnInteract)
                {
                    OnInteract();
                }
            }
        }

        private AstroUdonVariable<bool> Private_Get_OnInteract { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal void Initialize_InteractVars()
        {
            Private_Get_OnInteract = new AstroUdonVariable<bool>(RawItem, 2u);

        }

        internal void Destroy_InteractVars()
        {
            Private_Get_OnInteract = null;
        }


        private bool Get_OnInteract
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Get_OnInteract != null)
                {
                    var result = Private_Get_OnInteract.Value;
                    if (result)
                    {
                        Private_Get_OnInteract.Value = false;
                    }
                    return result;
                }
                return false;
            }
        }
        internal void OnDestroy()
        {
            if (UdonBehaviour != null)
            {
                Destroy(UdonBehaviour);
            }
            Destroy_InteractVars();
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
        private RawUdonBehaviour RawItem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}