namespace AstroClient.xAstroBoy.Extensions
{
    using UnityEngine;
    using Utility;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;

    public static class VRCHandGrasperExtensions
    {
        /// <summary>
        /// Forces HandGrasper to drop any held pickup.
        /// </summary>
        /// <param name="instance">Current Grasper</param>
        /// <param name="Reason">I think this goes in VRChat logs</param>
        internal static void Drop(this VRCHandGrasper instance, string Reason = "Grab button released")
        {
            try
            {
                if (instance != null)
                {
                    instance.Method_Private_Void_String_0(Reason);

                }
            }
            catch{}
        }
    }
}