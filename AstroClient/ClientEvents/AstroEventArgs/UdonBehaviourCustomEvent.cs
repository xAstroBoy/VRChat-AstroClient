using VRC.Udon;

namespace AstroClient.AstroEventArgs
{
    using System;
    using UnityEngine;
    using VRC;

    internal class UdonBehaviourCustomEvent : EventArgs
    {
        internal UdonBehaviour UdonBehaviour;
        internal string EventName;
        internal UdonBehaviourCustomEvent(UdonBehaviour UdonBehaviour, string EventName)
        {
            this.UdonBehaviour = UdonBehaviour;
            this.EventName = EventName;
        }
    }
}