namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class Disabler : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public Disabler(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            gameObject.SetActive(false);
        }

    }
}