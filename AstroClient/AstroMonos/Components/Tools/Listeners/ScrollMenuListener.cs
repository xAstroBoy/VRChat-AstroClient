namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using AstroClient.Tools.Extensions;
    using xAstroBoy.AstroButtonAPI;

    [RegisterComponent]
    public class ScrollMenuListener : AstroMonoBehaviour
    {
        internal QMSingleButton SingleButton;
        internal QMNestedGridMenu NestedGridButton;
        internal QMToggleButton ToggleButton;

        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public ScrollMenuListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
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