namespace AstroNetworkingLibrary.Serializable
{
	using System;
	using System.Reflection;

	[Serializable, Obfuscation]
	public class PacketData
	{
		public byte NetworkEventID = 0;

		public string TextData = string.Empty;

		public PacketData(byte networkEventID, string textData = "")
		{
			NetworkEventID = networkEventID;
			TextData = textData;
		}
	}
}