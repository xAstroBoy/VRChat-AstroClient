using Photon.Pun;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.Components.Tools.PickupBlocker
{
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
