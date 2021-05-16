namespace AstroClientCore.Managers
{
	using System;

	public static class EventManager
	{
		public static EventHandler<EventArgs> ApplicationStart;
		public static EventHandler<EventArgs> ApplicationQuit;
		public static EventHandler<EventArgs> Update;
		public static EventHandler<EventArgs> LateUpdate;
		public static EventHandler<EventArgs> GUI;
		public static EventHandler<EventArgs> UiManagerInit;
	}
}
