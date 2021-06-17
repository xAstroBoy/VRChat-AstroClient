namespace AstroClient.AntiCrash
{
	using AstroClient.Variables;
	using UnityEngine;
	using VRC.SDKBase;

	/// <summary>
	/// Just calling it AntiCrash, as the name is pretty generic
	/// </summary>
	public class AntiCrash : GameEvents
    {
        public static bool Enabled;

        public override void OnApplicationStart()
        {
            // Just while it's being developed
            if (Bools.IsDebugMode)
            {
                Enabled = true;
            }
        }

        public override void OnAvatarSpawn(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
            if (Enabled)
            {
                // Check and scan :)
                AntiCrashScanner.ScanAvatar(Avatar, VRCAvatarManager.field_Private_VRC_AvatarDescriptor_0);
            }
        }
    }
}