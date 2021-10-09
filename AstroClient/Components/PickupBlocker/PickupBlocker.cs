namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using static AstroClient.Forces;

    [RegisterComponent]
    public class PickupBlocker : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PickupBlocker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        private void Start()
        {
            player = gameObject.GetComponent<Player>().GetVRCPlayer().GetVRCPlayerApi();

        }

        private void Update()
        {
          if(player != null)
            {
                var left = player.GetPickupInHand(VRC_Pickup.PickupHand.Left);
                var right = player.GetPickupInHand(VRC_Pickup.PickupHand.Left);
                if(left != null)
                {
                    left.Drop();
                    left.gameObject.TakeOwnership();
                }
                if (right != null)
                {
                    right.Drop();
                    right.gameObject.TakeOwnership();
                }

            }

        }

        private void OnDestroy()
        {

        }

        private static VRCPlayerApi player { get; set; }
    }
}