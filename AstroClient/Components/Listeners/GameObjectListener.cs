namespace AstroClient.Components
{
    using System;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    internal class GameObjectListener : GameEventsBehaviour
    {
        [method: HideFromIl2Cpp]
        public event Action? OnEnabled;

        [method: HideFromIl2Cpp]
        public event Action? OnDisabled;

        [method: HideFromIl2Cpp]
        public event Action? OnDestroyed;

        public GameObjectListener(IntPtr obj0) : base(obj0)
        {
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