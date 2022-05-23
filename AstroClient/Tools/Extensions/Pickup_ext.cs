using VRC.SDK3.Components;
using VRC.SDKBase;

namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools;
    using Components_exts;
    using UnityEngine;
    using xAstroBoy.Utility;

    internal static class Pickup_ext
    {
        internal static void Pickup_AllowOnlySelfToGrab(this GameObject obj, bool AllowOnlySelfToGrab)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_AllowOnlySelfToGrab(AllowOnlySelfToGrab);
        }

        internal static void Pickup_AllowOnlySelfToGrab(this List<GameObject> items, bool AllowOnlySelfToGrab)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_AllowOnlySelfToGrab(AllowOnlySelfToGrab);
                }
            }
        }

        internal static bool isPickup(this GameObject obj)
        {
            if (obj.GetComponent<VRC_Pickup>() != null) return true;
            if (obj.GetComponent<VRCSDK2.VRC_Pickup>() != null) return true;
            if (obj.GetComponent<VRCPickup>() != null) return true;
            return false;
        }

        internal static void RespawnPickup(this GameObject obj, bool RestoreBodySettings)
        {
            if (obj != null)
            {
                if (!obj.isPickup()) return; // Refuse to respawn it if pickup component is missing.

                obj.TakeOwnership();
                if (RestoreBodySettings)
                {
                    var control = obj.GetOrAddComponent<RigidBodyController>();
                    if (control != null)
                    {
                        if (RestoreBodySettings)
                        {
                            control.RestoreOriginalBody();
                        }
                    }
                }

                var respawner = obj.GetComponent<Respawner>();
                if(respawner != null)
                {
                    respawner.Respawn(); 
                }


            }
            
        }

    }
}