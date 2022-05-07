using Photon.Pun;
using VRC.SDKBase;

namespace AstroClient.PickupBlockerSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class PickupBlocker_Tools
    {
        internal static bool isPickup(this PhotonView instance)
        {
            if (instance != null)
            {
                return instance.GetComponent<VRC_Pickup>() != null || instance.GetComponent<VRCSDK2.VRC_Pickup>() != null || instance.GetComponent<VRC.SDK3.Components.VRCPickup>() != null;
            }
            return false;
        }


    }
}
