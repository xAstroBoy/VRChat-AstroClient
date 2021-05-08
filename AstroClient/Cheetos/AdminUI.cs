namespace AstroClient
{
	#region Imports
	using AstroClient.variables;
	using RubyButtonAPI;
	#endregion

	/// <summary>
	/// Cheeto's temporary UI for new/wip features
	/// </summary>
	public class AdminUI : GameEvents
	{
		public QMNestedButton MainButton { get; private set; }

		public QMScrollMenu MainScroller { get; private set; }

		public QMSingleButton CloseButton { get; private set; }

		public QMSingleButton RestartButton { get; private set; }

		public QMSingleButton DisconectButton { get; private set; }

		public QMSingleButton ReconnectButton { get; private set; }

		public override void VRChat_OnUiManagerInit()
		{
			if (Bools.IsDeveloper)
			{
				MainButton = new QMNestedButton("ShortcutMenu", 5, 2.5f, "Admin Menu", "AstroClient's Admin Menu", null, null, null, null, true);
				MainScroller = new QMScrollMenu(MainButton);
			}
		}
	}
}