namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using CustomMono;

    [RegisterComponent]
    public class ScrollMenuListener : GameEventsBehaviour
    {
        internal QMSingleButton SingleButton;
        internal QMNestedGridMenu NestedGridButton;

        public ScrollMenuListener(IntPtr obj0) : base(obj0)
        {
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
            else if(SingleButton == null && NestedGridButton == null)
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
            else if (SingleButton == null && NestedGridButton == null)
            {
                DestroyImmediate(this);
            }
        }

        private void OnDestroy()
        {
            NestedGridButton?.DestroyMe();
            DestroyImmediate(this);
        }
    }
}