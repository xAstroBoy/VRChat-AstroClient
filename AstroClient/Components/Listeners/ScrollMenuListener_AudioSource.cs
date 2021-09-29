namespace AstroClient.Components
{
    using AstroLibrary.Extensions;
    using RubyButtonAPI;
    using System;

    [RegisterComponent]
    internal class ScrollMenuListener_AudioSource : GameEventsBehaviour
    {
        internal QMSingleButton Assignedbtn { get; set; }

        internal UnityEngine.AudioSource source;

        internal bool Lock = true;

        internal ScrollMenuListener_AudioSource(IntPtr obj0) : base(obj0)
        {
        }

        private void FixedUpdate()
        {
            if (!Lock)
            {
                if (source != null)
                {
                    if (Assignedbtn != null)
                    {
                        Assignedbtn.SetTextColor(source.Get_AudioSource_Active_ToColor());
                    }
                    else
                    {
                        Destroy(this);
                    }
                }
            }
        }

        private void OnDestroy()
        {
            if (Assignedbtn != null)
            {
                Assignedbtn.DestroyMe();
            }
        }
    }
}