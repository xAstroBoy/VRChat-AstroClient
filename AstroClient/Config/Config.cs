namespace AstroClient
{
	using System;
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

		// Player List UI
		public bool ShowPlayersMenu = true;

		public bool ShowPlayersList = true;
	}

	[Serializable, Obfuscation]
	public class Config
	{
		public bool DebugLog = false;

		public bool JoinLeave = false;

		public bool LogRPCEvents = false;

		public bool LogUdonEvents = false;

		public bool LogTriggerEvents = false;
	}
}