namespace AstroClient
{
	using System;
	using VRC_EventHandler = VRC.SDKBase.VRC_EventHandler;

	public class VRC_EventDispatcherRFC_TriggerEventArgs : EventArgs
	{
		public VRC_EventHandler VRC_EventHandler;
		public VRC_EventHandler.VrcEvent VrcEvent;
		public VRC_EventHandler.VrcBroadcastType VrcBroadcastType;
		public int UnknownInt;
		public float UnknownFloat;

		public VRC_EventDispatcherRFC_TriggerEventArgs(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
		{
			this.VRC_EventHandler = VRC_EventHandler;
			this.VrcEvent = VrcEvent;
			this.VrcBroadcastType = VrcBroadcastType;
			this.UnknownInt = UnknownInt;
			this.UnknownFloat = UnknownFloat;
		}
	}
}