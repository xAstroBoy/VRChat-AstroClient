namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class UiListener : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        public UiListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void OnEnable()
        {
            OnEnabled?.Invoke();
        }

        private void OnDisable()
        {
            OnDisabled?.Invoke();
        }

        [method: HideFromIl2Cpp] internal event Action? OnEnabled;

        [method: HideFromIl2Cpp] internal event Action? OnDisabled;

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }
    }
}