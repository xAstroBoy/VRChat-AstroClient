namespace AstroClient.Cheetos
{
    using Config;
    using UnityEngine;

    internal class FrameUnlimiter : AstroEvents
    {
        private static int Default;

        internal override void VRChat_OnUiManagerInit()
        {
            Default = Application.targetFrameRate;

            if (ConfigManager.Performance.UnlimitedFrames)
            {
                Unlock(true);
            }
        }

        internal static bool IsEnabled
        {
            get => ConfigManager.Performance.UnlimitedFrames;
            set => Unlock(value);
        }

        private static void Unlock(bool unlocked)
        {
            Application.targetFrameRate = unlocked ? int.MaxValue : Default;
            ModConsole.DebugLog($"Frame Unlimiter: {unlocked}");
        }
    }
}