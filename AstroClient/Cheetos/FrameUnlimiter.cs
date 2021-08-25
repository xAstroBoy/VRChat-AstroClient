namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using UnityEngine;

	internal class FrameUnlimiter : GameEvents
	{
		private static int Default;

		public override void VRChat_OnUiManagerInit()
		{
			Default = Application.targetFrameRate;

			if (ConfigManager.Performance.UnlimitedFrames)
			{
				Unlock(true);
			}
		}

		public static bool IsEnabled
		{
			get => ConfigManager.Performance.UnlimitedFrames;
			set => Unlock(value);
		}

		private static void Unlock(bool unlocked)
		{
			Application.targetFrameRate = unlocked ? int.MaxValue : Default;
			ModConsole.Log($"Frame Unlimiter: {unlocked}");
		}
    }
}