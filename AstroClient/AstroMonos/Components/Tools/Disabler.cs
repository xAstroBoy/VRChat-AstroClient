namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using UnityEngine;

    [RegisterComponent]
    public class Disabler : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public Disabler(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void Start()
        {
            this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            this.gameObject.SetActive(false);
        }
    }
}