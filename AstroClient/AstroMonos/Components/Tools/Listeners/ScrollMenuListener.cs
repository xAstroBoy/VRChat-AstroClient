namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;

    [RegisterComponent]
    public class ScrollMenuListener : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;
        internal QMNestedGridMenu NestedGridButton;
        internal QMSingleButton SingleButton;
        internal QMToggleButton ToggleButton;

        public ScrollMenuListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void OnEnable()
        {
            if (NestedGridButton != null)
                NestedGridButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton != null)
                SingleButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton == null && NestedGridButton == null && ToggleButton == null) DestroyImmediate(this);
        }

        private void OnDisable()
        {
            if (NestedGridButton != null)
                NestedGridButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton != null)
                SingleButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton == null && NestedGridButton == null && ToggleButton == null) DestroyImmediate(this);
        }

        private void OnDestroy()
        {
            SingleButton?.DestroyMe();
            NestedGridButton?.DestroyMe();
            ToggleButton?.DestroyMe();
            DestroyImmediate(this);
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }
    }
}