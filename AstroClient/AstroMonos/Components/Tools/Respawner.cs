using AstroClient.xAstroBoy.Utility;
using UnhollowerBaseLib.Attributes;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Alternative to SyncPhysics for respawning pickups
    /// </summary>
    [RegisterComponent]
    public class Respawner : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public Respawner(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        //private void Start()
        //{
        //    CaptureSpawnCoords();
        //}

        [HideFromIl2Cpp]
        internal void CaptureSpawnCoords()
        {
            if(!HasTakenPositionAndRotation)
            {
                OriginalLocation = gameObject.transform.position;
                OriginalRotation = gameObject.transform.rotation;
                HasTakenPositionAndRotation = true;
            }
        }


        [HideFromIl2Cpp]
        internal void Respawn()
        {
            gameObject.TakeOwnership();
            gameObject.transform.position = OriginalLocation; 
            gameObject.transform.rotation = OriginalRotation;
        }


        private bool HasTakenPositionAndRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private Vector3 OriginalLocation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion OriginalRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

    }
}