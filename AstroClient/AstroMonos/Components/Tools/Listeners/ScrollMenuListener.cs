namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using CustomMono;
    using System;

    [RegisterComponent]
    public class ScrollMenuListener : GameEventsBehaviour
    {
        internal QMSingleButton SingleButton;
        internal QMNestedGridMenu NestedGridButton;
        internal QMToggleButton ToggleButton;

        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ScrollMenuListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void OnEnable()
        {
            if (NestedGridButton != null)
            {
                NestedGridButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            }
            else if (SingleButton != null)
            {
                SingleButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            }
            else if (SingleButton == null && NestedGridButton == null && ToggleButton == null)
            {
                DestroyImmediate(this);
            }
        }

        private void OnDisable()
        {
            if (NestedGridButton != null)
            {
                NestedGridButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            }
            else if (SingleButton != null)
            {
                SingleButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            }
            else if (SingleButton == null && NestedGridButton == null && ToggleButton == null)
            {
                DestroyImmediate(this);
            }
        }

        private void OnDestroy()
        {
            SingleButton?.DestroyMe();
            NestedGridButton?.DestroyMe();
            ToggleButton?.DestroyMe();
            DestroyImmediate(this);
        }
    }
}