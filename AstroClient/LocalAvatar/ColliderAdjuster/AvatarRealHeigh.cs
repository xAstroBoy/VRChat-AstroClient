using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.LocalAvatar.ColliderAdjuster
{
    internal class AvatarRealHeight : AstroEvents
    {
        internal static HeightAdjuster Adjuster { get; private set; } = null;

        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomJoined += OnRoomJoined;
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private static void OnRoomJoined()
        {
            MelonLoader.MelonCoroutines.Start(CreateLocalAdjuster());
        }

        private static System.Collections.IEnumerator CreateLocalAdjuster()
        {
            while (GameInstances.CurrentUser == null)
                yield return null;

            Adjuster = GameInstances.CurrentUser.AddComponent<HeightAdjuster>();
            Adjuster.SetEnabled(ConfigManager.AvatarOptions.AdjustAvatarCollider); 
            Adjuster.SetPoseHeight(ConfigManager.AvatarOptions.UsePoseHeight);
        }

        private void OnRoomLeft()
        {
            Adjuster = null;
        }

        public static bool AdjustAvatarCollider
        {
            get
            {
                return ConfigManager.AvatarOptions.AdjustAvatarCollider;
            }
            set
            {
                ConfigManager.AvatarOptions.AdjustAvatarCollider = value;
                if (Adjuster != null)
                {
                    Adjuster.SetEnabled(value);
                }
            }
        }
        public static bool UsePoseHeight
        {
            get
            {
                return ConfigManager.AvatarOptions.UsePoseHeight;
            }
            set
            {
                ConfigManager.AvatarOptions.UsePoseHeight = value;
                if(Adjuster != null)
                {
                    Adjuster.SetPoseHeight(value);
                }
            }
        }
    }
}