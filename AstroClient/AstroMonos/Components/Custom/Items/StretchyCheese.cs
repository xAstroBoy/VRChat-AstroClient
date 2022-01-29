namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonSearcher;
    using AstroUdons;
    using ClientAttributes;
    using CustomClasses;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using static Constants.CustomLists;

    [RegisterComponent]
    public class StretchyCheeseBehaviour : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        public StretchyCheeseBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private UdonBehaviour_Cached ExtendCheese { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroPickup PickupBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } // let's test.

        private void Start()
        {
            ExtendCheese = UdonSearch.FindUdonEvent(gameObject, "Extend");
            if (ExtendCheese != null)
            {
                var PickupBehaviour = gameObject.AddComponent<VRC_AstroPickup>();
                if (PickupBehaviour != null) PickupBehaviour.OnPickupUseUp += () => { ExtendCheese.InvokeBehaviour(); };
            }
            else
            {
                ModConsole.DebugError($"{gameObject.name} : Failed to Bind StretcyCheese Component because there's no Extend behaviour!");
                Destroy(this);
            }
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private void OnEnable()
        {
            if (PickupBehaviour != null) PickupBehaviour.enabled = true;
        }

        private void OnDisable()
        {
            if (PickupBehaviour != null) PickupBehaviour.enabled = false;
        }

        private void OnDestroy()
        {
            if (PickupBehaviour != null) Destroy(PickupBehaviour);
        }
    }
}