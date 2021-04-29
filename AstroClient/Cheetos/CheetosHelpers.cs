﻿namespace AstroClient.Cheetos
{
	#region Imports

	using AstroClient.ConsoleUtils;
	using DayClientML2.Utility.Extensions;
	using System.IO;
	using UnityEngine;

	#endregion Imports

	public static class CheetosHelpers
	{
		public static Texture2D LoadPNG(string filePath)
		{
			Texture2D tex;
			byte[] fileData;

			if (File.Exists(filePath))
			{
				fileData = File.ReadAllBytes(filePath);
				tex = new Texture2D(2, 2);
				ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
				return tex;
			}
			else
			{
				ModConsole.Error($"Could not load: {filePath}");
				return null;
			}
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
	}
}