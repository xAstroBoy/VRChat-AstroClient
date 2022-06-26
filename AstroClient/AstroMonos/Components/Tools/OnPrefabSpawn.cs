
namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class OnPrefabSpawnHelper : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public OnPrefabSpawnHelper(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        /// <summary>
        /// Set this to use the actual instantiated root.
        /// </summary>
        internal Action<GameObject> OnSpawn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set;  }

        public void Awake()
        {
            OnSpawn.SafetyRaiseWithParams(gameObject.transform.root);
        }

        public void Start()
        {
            Destroy(this);
        }
    }
}