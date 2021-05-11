namespace AstroNetworkingLibrary.Serializable
{
	using System;
	using System.Reflection;

	[Serializable, Obfuscation]
	public class PacketData
	{
		public ulong NetworkEventID = 0;

		public string TextData = string.Empty;

		public byte[] ByteData;

		public PacketData(ulong networkEventID, string textData = "", byte[] byteData = null)
		{
			NetworkEventID = networkEventID;
			TextData = textData;
			ByteData = byteData;
		}
	}
}