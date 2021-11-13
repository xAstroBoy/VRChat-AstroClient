namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using CustomMono;
    using System;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class UiListener : GameEventsBehaviour
    {
        [method: HideFromIl2Cpp]
        internal event Action? OnEnabled;

        [method: HideFromIl2Cpp]
        internal event Action? OnDisabled;

        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public UiListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
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
    }
}