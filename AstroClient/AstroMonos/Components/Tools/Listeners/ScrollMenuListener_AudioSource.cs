namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using CustomMono;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class ScrollMenuListener_AudioSource : GameEventsBehaviour
    {
        internal QMSingleButton Assignedbtn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal UnityEngine.AudioSource source;
        internal bool Lock = true;

        public ScrollMenuListener_AudioSource(IntPtr obj0) : base(obj0)
        {
        }

        private void FixedUpdate()
        {
            if (!Lock)
            {
                if (source != null)
                {
                    if (Assignedbtn != null) Assignedbtn.SetTextColor(source.Get_AudioSource_Active_ToColor());
                    else Destroy(this);
                }
            }
        }

        private void OnDestroy()
        {
            if (Assignedbtn != null) Assignedbtn.DestroyMe();
        }
    }
}