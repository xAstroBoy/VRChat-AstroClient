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

	[Serializable, Obfuscation]
	public class ConfigESP
	{
		public bool PlayerESP = false;

		public bool PickupESP = false;

		public bool TriggerESP = false;

		public bool UdonESP = false;

		public bool VRCInteractableESP = false;
	}
}