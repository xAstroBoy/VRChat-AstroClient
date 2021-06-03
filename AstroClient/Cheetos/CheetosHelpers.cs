namespace AstroClient.Cheetos
{
	#region Imports

	using DayClientML2.Utility.Extensions;
	using System.IO;
	using UnityEngine;

	#endregion Imports

	public static class CheetosHelpers
	{
		public static Texture2D LoadPNG(string filePath)
		{
			byte[] fileData = ExtractResource(filePath);
			Texture2D tex = new Texture2D(2, 2);
			ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
			return tex;
		}

		/// <summary>
		/// Send a notification message to the player's HUD
		/// </summary>
		/// <param name="msg"></param>
		public static void SendHudNotification(string msg)
		{
			var uiManager = VRCUiManager.prop_VRCUiManager_0;
			PopupManager.QueHudMessage(uiManager, msg);
		}

		public static byte[] ExtractResource(string filename)
		{
			if (!KeyManager.IsAuthed)
			{
				throw new System.Exception("Not Authorized!");
			}
			System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
			using (Stream resFilestream = a.GetManifestResourceStream(filename))
			{
				if (resFilestream == null) return null;
				byte[] ba = new byte[resFilestream.Length];
				resFilestream.Read(ba, 0, ba.Length);
				return ba;
			}
		}
	}
}