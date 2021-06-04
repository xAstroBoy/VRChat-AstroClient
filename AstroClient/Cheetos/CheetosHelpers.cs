namespace AstroClient.Cheetos
{
	#region Imports

	using DayClientML2.Utility.Extensions;
	using System;
	using System.IO;
	using UnityEngine;
	using UnityEngine.UI;

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

		public static void PopupCall(string title, string confirm, string placeholder, bool IsNumpad, Action<string> OnAccept, Action OnCancel = null)
		{
			VRCUiPopupManager
				.prop_VRCUiPopupManager_0
				.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(
					title,
					"",
					InputField.InputType.Standard,
					IsNumpad,
					confirm,
					UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>(new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>((a, b, c) =>
					{
						OnAccept?.Invoke(a);
					})),
					UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(OnCancel),
					placeholder,
					true,
					null
					);
		}
	}
}