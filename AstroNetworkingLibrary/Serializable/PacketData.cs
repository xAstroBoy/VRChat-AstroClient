namespace AstroNetworkingLibrary.Serializable
{
	using System;
	using System.Reflection;

	[Serializable, Obfuscation]
	public class PacketData
	{
		public ulong NetworkEventID = 0;

		public string TextData = string.Empty;

		public PacketData(ulong networkEventID, string textData = "")
		{
			NetworkEventID = networkEventID;
			TextData = textData;
		}
	}
}