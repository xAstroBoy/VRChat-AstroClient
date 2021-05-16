namespace AstroClientCore.Managers
{
	using System;

	public static class EventManager
	{
		public static EventHandler<EventArgs> Start;
		public static EventHandler<EventArgs> Update;
		public static EventHandler<EventArgs> LateUpdate;
		public static EventHandler<EventArgs> VRChat_OnUiManagerInit;
	}
}
