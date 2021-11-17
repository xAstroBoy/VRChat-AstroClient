namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class Enabler : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public Enabler(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void Start()
        {
            gameObject.SetActive(true);
            InvokeRepeating(nameof(CustomUpdate), 0.1f, 0.3f);
        }

        private void OnDisable()
        {
            gameObject.SetActive(true);
        }

        private void CustomUpdate()
        {
            if (gameObject != null && !gameObject.active && isActiveAndEnabled) gameObject.SetActive(true);
        }
    }
}