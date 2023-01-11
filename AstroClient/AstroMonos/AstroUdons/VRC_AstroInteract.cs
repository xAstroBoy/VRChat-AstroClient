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
            if (UdonBehaviour != null)
            {
                HasSubscribed = true;
                UdonBehaviour._hasInteractiveEvents = true; // This way it activates the interact system in the behaviour
            }
            MiscUtils.DelayFunction(1f, () =>
            {
                if (_interactText != "Use")
                {
                    interactText = _interactText;
                }
                if (_InteractionText != "Use")
                {
                    InteractionText = _InteractionText;
                }

            });
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
                    UdonBehaviour.InteractionText = value                    ;
                }
            }
        }

        internal bool DisableInteractive
        {
            [HideFromIl2Cpp]
            get
            {
                if (UdonBehaviour != null)
                {
                    return UdonBehaviour.DisableInteractive;
                }
                return false;
            }

            [HideFromIl2Cpp]
            set
            {
                if (UdonBehaviour != null)
                {
                    UdonBehaviour.DisableInteractive = value;
                }
            }
        }
        internal float proximity
        {
            [HideFromIl2Cpp]
            get
            {
                if (UdonBehaviour != null)
                {
                    return UdonBehaviour.proximity;
                }
                return default;
            }

            [HideFromIl2Cpp]
            set
            {
                if (UdonBehaviour != null)
                {
                    UdonBehaviour.proximity = value;
                }
            }
        }

        internal Action OnInteract { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private UdonBehaviour UdonBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}