using AstroClient.ClientActions;

namespace AstroClient.Cheetos
{
    using Config;
    using UnityEngine;

    internal class FrameUnlimiter : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;
        }

        private static int Default;

        private void VRChat_OnUiManagerInit()
        {
            Default = Application.targetFrameRate;
            if (ConfigManager.Performance != null)
            {
                if (ConfigManager.Performance.UnlimitedFrames)
                {
                    Unlock(true);
                }
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
            Log.Debug($"Frame Unlimiter: {unlocked}");
        }
    }
}