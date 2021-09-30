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

        internal void Start()
        { 

            // Might be not neccessary but let's test it later.
            if (gameObject.GetComponent<VRCInteractable>() != null)
            {
                UnityEngine.Object.Destroy(gameObject.GetComponent<VRCInteractable>());
            }


            if (AssignedProgram == null)
            {
                ModConsole.DebugError("Custom Trigger Can't Load as Program Asset is null!");
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
        }

        internal void FixedUpdate()
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

                if (UdonBehaviour != null && UdonBehaviour._udonVM != null && !UdonBehaviour._udonManager != null)
                {
                    if (IUdonHeap == null)
                    {
                        IUdonHeap = UdonBehaviour._udonVM.InspectHeap();
                    }
                    if (IUdonHeap != null && IUdonHeap.GetHeapVariable(2u).Unbox<bool>())
                    {
                        OnInteract();
                        IUdonHeap.CopyHeapVariable(3u, 2u);
                    }
                }
            }
        }

        internal void OnDestroy()
        {
            if (UdonBehaviour != null)
            {
                Destroy(UdonBehaviour);
            }
        }

        internal void OnDisable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = false;
            }
        }


        internal void OnEnable()
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
            }
        }
        private SerializedUdonProgramAsset AssignedProgram { get; } = UdonPrograms.InteractProgram;

        internal Action OnInteract { get; set; }

        internal UdonBehaviour UdonBehaviour { get; private set; }
        internal IUdonHeap IUdonHeap { get; private set; }
    }
}