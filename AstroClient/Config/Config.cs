namespace AstroClient
{
	using AstroNetworkingLibrary.Serializable;
	using System;
	using System.Collections.Generic;
	using System.Reflection;

	[Serializable, Obfuscation]
    public class ConfigUI
    {
        public bool RemoveVRCPlus = false;

        public bool RemoveReportButton = false;

        public bool RemoveUserIconButton = false;

        public bool RemoveVRCPlusMiniBanner = false;

        public bool RemoveVRCPlusBanner = false;

        public bool RemoveUserIconCameraButton = false;

        public bool RemoveVRCPlusThankYou = false;

        public bool RemoveVRCPlusMenu = false;

        public bool RemoveGalleryButton = false;

        // Player List UI
        public bool ShowPlayersMenu = true;

        public bool ShowPlayersList = true;

        public int PlayerListOffset = 0;
    }

    [Serializable, Obfuscation]
    public class ConfigGeneral
    {
        public bool DebugLog = false;

        public bool JoinLeave = false;

        public bool LogRPCEvents = false;

        public bool LogUdonEvents = false;

        public bool LogTriggerEvents = false;

        public float FOV = 61f;

        public float FarClipPlane = 60f;

        public bool SpoofPing = false;

        public bool SpoofFPS = false;

		public bool SpoofQuest = false;

        public int SpoofedPing = 30;

        public float SpoofedFPS = 60f;
    }

    [Serializable, Obfuscation]
    public class ConfigESP
    {
        public bool PlayerESP = false;

        public float[] PublicESPColor = new float[] { 0f, 1f, 1f, 1f };

        public float[] ESPFriendColor = new float[] { 0f, 1f, 0f, 1f };

        public float[] ESPBlockedColor = new float[] { 1f, 0f, 0f, 1f };
    }

    [Serializable, Obfuscation]
    public class ConfigFlight
    {
        public float VRFlySpeed = 3f;

        public float DesktopFlySpeed = 3f;

        public bool BasicFly = true;
    }

    [Serializable, Obfuscation]
    public class ConfigMovement
    {
        public bool UnlimitedJump = false;

        public bool RocketJump = false;

        public bool QMFreeze = false;
    }

	[Serializable, Obfuscation]
	public class ConfigFavorites
	{
		public List<AvatarData> Avatars = new List<AvatarData>();
	}
}