namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class Enabler : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        public Enabler(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
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
            if (gameObject != null && !gameObject.active) gameObject.SetActive(true);
        }
    }
}