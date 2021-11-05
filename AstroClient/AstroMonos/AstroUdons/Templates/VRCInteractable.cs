using UnhollowerBaseLib.Attributes;

namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;

    [RegisterComponent]
    public class AstroInteractable : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public AstroInteractable(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);

            interactable = this.gameObject.AddComponent<VRC_AstroInteractable>();
            if (interactable != null)
            {

                interactable.OnInteract += OnInteract;

            }
        }
        internal string InteractionText
        {
            [HideFromIl2Cpp]
            get => interactable.interactText;
            [HideFromIl2Cpp]
            set => interactable.interactText = value;
        }

        internal virtual void OnInteract() { }

        private VRC_AstroInteractable interactable { [HideFromIl2Cpp] get; }


        internal VRCInteractable VRCInteractableProperties
        {
            [HideFromIl2Cpp]
            get
            {
                return interactable.VRCInteractable;
            }
        }

    }
}