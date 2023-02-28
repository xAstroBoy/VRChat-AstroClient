using AstroClient.ClientAttributes;
using AstroClient.xAstroBoy.Utility;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Player
{
    /// <summary>
    /// Script to track objects to the player's hands or head.
    /// </summary>
    [RegisterComponent]
    public class TrackedObject : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public TrackedObject(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        /// <summary>
        /// "Whether this TrackedObject should be active if you are in desktop mode or VR mode."
        /// </summary>
        internal bool vrEnabled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Which GameObject to enable if vrEnabled matches which mode we are in."
        /// </summary>
        internal GameObject vrEnabledObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Which tracking point to attach this object to."
        /// </summary>
        internal VRCPlayerApi.TrackingDataType trackingType { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        internal void Start()
        {
            if (GameInstances.LocalPlayer != null)
            {
                vrEnabledObject.SetActive(vrEnabled == GameInstances.LocalPlayer.IsInVR());
            }
        }

        internal void Update()
        {
            if (vrEnabled == GameInstances.LocalPlayer.IsUserInVR())
            {
                VRCPlayerApi.TrackingData data = GameInstances.LocalPlayer.GetTrackingData(trackingType);
                transform.SetPositionAndRotation(data.position, data.rotation);
            }
        }
    }
}