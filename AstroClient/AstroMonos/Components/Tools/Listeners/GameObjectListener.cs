namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class GameObjectListener : AstroMonoBehaviour
    {
        [method: HideFromIl2Cpp]
        internal event Action? OnEnabled;

        [method: HideFromIl2Cpp]
        internal event Action? OnDisabled;

        [method: HideFromIl2Cpp]
        internal event Action? OnDestroyed;

        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public GameObjectListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal void RemoveListener()
        {
            OnDestroyed = null;
            OnDisabled = null;
            OnEnabled = null;
            DestroyImmediate(this);
        }

        private void OnEnable()
        {
            OnEnabled?.Invoke();
        }

        private void OnDisable()
        {
            OnDisabled?.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke();
        }
    }
}