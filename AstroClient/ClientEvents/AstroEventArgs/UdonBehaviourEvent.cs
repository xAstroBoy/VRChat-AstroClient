using VRC.Udon;

namespace AstroClient.AstroEventArgs
{
    using System;
    using UnityEngine;
    using VRC;

    internal class UdonBehaviourEvent : EventArgs
    {
        internal UdonBehaviour UdonBehaviour;

        internal UdonBehaviourEvent(UdonBehaviour UdonBehaviour)
        {
            this.UdonBehaviour = UdonBehaviour;
        }
    }
}