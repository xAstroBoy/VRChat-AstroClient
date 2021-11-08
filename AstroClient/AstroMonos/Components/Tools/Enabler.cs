namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using UnityEngine;

    [RegisterComponent]
    public class Enabler : MonoBehaviour
    {

        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public Enabler(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void Start()
        {
            this.gameObject.SetActive(true);
            InvokeRepeating(nameof(CustomUpdate), 0.1f, 0.3f);
        }

        private void OnDisable()
        {
            this.gameObject.SetActive(true);
        }

        private void CustomUpdate()
        {
            if (gameObject != null && !gameObject.active && this.isActiveAndEnabled)
            {
                this.gameObject.SetActive(true);
            }
        }


    }
}