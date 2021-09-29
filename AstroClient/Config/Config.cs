namespace AstroClient
{
    using AstroNetworkingLibrary.Serializable;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable, Obfuscation]
    internal class ConfigUI
    {
        internal bool RemoveVRCPlus = false;

        internal bool RemoveReportButton = false;

        internal bool RemoveUserIconButton = false;

        internal bool RemoveVRCPlusMiniBanner = false;

        internal bool RemoveVRCPlusBanner = false;

        internal bool RemoveUserIconCameraButton = false;

        internal bool RemoveVRCPlusThankYou = false;

        internal bool RemoveVRCPlusMenu = false;

        internal bool RemoveGalleryButton = false;

        internal bool NamePlates = false;

        // Player List UI
        internal bool ShowPlayersMenu = true;

        internal bool ShowPlayersList = true;

        internal int PlayerListOffset = 0;
    }

    [Serializable, Obfuscation]
    internal class ConfigGeneral
    {
        internal bool DebugLog = false;

        internal bool JoinLeave = false;

        internal bool LogRPCEvents = false;

        internal bool LogUdonEvents = false;

        internal bool LogTriggerEvents = false;

        internal bool LogEvents = false;

        internal float FOV = 61f;

        internal float FarClipPlane = 60f;

        internal bool SpoofPing = false;

        internal bool SpoofFPS = false;

        internal bool SpoofQuest = false;

        internal int SpoofedPing = 30;

        internal float SpoofedFPS = 60f;

        internal bool KeyBinds = false;
    }

    [Serializable, Obfuscation]
    internal class ConfigESP
    {
        internal bool PlayerESP = false;

        internal float[] PublicESPColor = new float[] { 0f, 1f, 1f, 1f };

        internal float[] ESPFriendColor = new float[] { 0f, 1f, 0f, 1f };

        internal float[] ESPBlockedColor = new float[] { 1f, 0f, 0f, 1f };
    }

    [Serializable, Obfuscation]
    internal class ConfigFlight
    {
        internal float VRFlySpeed = 3f;

        internal float DesktopFlySpeed = 3f;

        internal bool BasicFly = true;
    }

    [Serializable, Obfuscation]
    internal class ConfigMovement
    {
        internal bool UnlimitedJump = false;

        internal bool RocketJump = false;

        internal bool QMFreeze = false;
    }

    [Serializable, Obfuscation]
    internal class ConfigFavorites
    {
        internal List<AvatarData> Avatars = new List<AvatarData>();
    }

    [Serializable, Obfuscation]
    internal class ConfigPerformance
    {
        internal bool HighPriority = false;

        internal bool UnlimitedFrames = false;
    }
}