namespace AstroClientCore.Managers
{
	using System;
	using System.Collections.Generic;

	public static class EventManager
	{
		public static List<GameEvents> Overridable_List = new List<GameEvents>();

		public static EventHandler<EventArgs> ApplicationStart;
		public static EventHandler<EventArgs> ApplicationQuit;
		public static EventHandler<EventArgs> Update;
		public static EventHandler<EventArgs> LateUpdate;
		public static EventHandler<EventArgs> GUI;
		public static EventHandler<EventArgs> UiManagerInit;
		public static EventHandler<EventArgs> LevelLoaded;
	}
}
