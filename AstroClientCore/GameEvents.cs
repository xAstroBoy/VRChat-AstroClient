namespace AstroClientCore
{
	using AstroClientCore.Managers;
	using System;

	class GameEvents
	{
		public GameEvents()
		{
			EventManager.Update += Internal_OnUpdate;
		}

		private void Internal_OnUpdate(object sender, EventArgs e)
		{
			OnUpdate();
		}

		public virtual void OnUpdate()
		{
		}
	}
}
