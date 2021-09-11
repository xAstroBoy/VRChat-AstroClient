namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using System;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;

    [RegisterComponent]
    public class VRC_AstroUdonTrigger : MonoBehaviour
    {
        public VRC_AstroUdonTrigger(IntPtr ptr)
            : base(ptr)
        {
        }

        public void Start()
        {
            if (gameObject.GetComponent<VRCInteractable>() != null)
            {
                UnityEngine.Object.Destroy(gameObject.GetComponent<VRCInteractable>());
            }

            if (UdonTrigger_Helper.OnInteractUdonProgramEvent == null)
            {
                ModConsole.DebugError("Custom Trigger Can't Load as Program Asset is null!");
            }

            UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
            if (UdonBehaviour != null)
            {
                UdonBehaviour.serializedProgramAsset = UdonTrigger_Helper.OnInteractUdonProgramEvent;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
                UdonBehaviour.interactText = interactText;
            }
        }

        public void FixedUpdate()
        {
            if (UdonBehaviour == null)
            {
                UdonBehaviour = base.gameObject.AddComponent<UdonBehaviour>();
                UdonBehaviour.serializedProgramAsset = UdonTrigger_Helper.OnInteractUdonProgramEvent;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
                UdonBehaviour.interactText = interactText;
            }
            else
            {
                if (UdonBehaviour.serializedProgramAsset == null)
                {
                    UdonBehaviour.serializedProgramAsset = UdonTrigger_Helper.OnInteractUdonProgramEvent;
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

        internal Action OnInteract { get; set; }

        internal UdonBehaviour UdonBehaviour { get; private set; }
        internal IUdonHeap IUdonHeap { get; private set; }
    }
}