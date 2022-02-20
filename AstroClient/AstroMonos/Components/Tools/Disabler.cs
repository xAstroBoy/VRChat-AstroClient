namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class Disabler : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        public Disabler(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
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