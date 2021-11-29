namespace AstroClient.AstroEventArgs
{
    using System;
    using VRC.SDKBase;

    internal class VRC_EventDispatcherRFC_TriggerEventArgs : EventArgs
    {
        internal float UnknownFloat;
        internal int UnknownInt;
        internal VRC_EventHandler VRC_EventHandler;
        internal VRC_EventHandler.VrcBroadcastType VrcBroadcastType;
        internal VRC_EventHandler.VrcEvent VrcEvent;

        internal VRC_EventDispatcherRFC_TriggerEventArgs(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
        {
            this.VRC_EventHandler = VRC_EventHandler;
            this.VrcEvent = VrcEvent;
            this.VrcBroadcastType = VrcBroadcastType;
            this.UnknownInt = UnknownInt;
            this.UnknownFloat = UnknownFloat;
        }
    }
}