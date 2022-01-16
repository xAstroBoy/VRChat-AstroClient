namespace AstroClient.CheetoLibrary.Utility
{
    #region Imports

    using System;
    using System.IO;
    using System.Reflection;
    using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Raw;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Core;
    using xAstroBoy;

    //using VRC.UI.Elements;

    #endregion Imports

    public static class CheetoUtils
    {
        //public static MenuStateController GetMenuStateController()
        //{
        //    return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)").GetComponent<MenuStateController>();
        //}

        public static void TryRun(Action[] actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                Action action = actions[i];
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    ModConsole.Exception(e);
                }
            }
        }

        public static Texture2D LoadBundlePng(byte[] bundle)
        {
            try
            {
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, bundle); //..this will auto-resize the texture dimensions.
                return tex;
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
                return null;
            }

        }
        public static Texture2D LoadPNGFromDir(string filePath)
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(filePath);
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
                return tex;
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
                return null;
            }
        }

        public static Texture2D LoadPNG(string filePath)
        {
            try
            {
                byte[] fileData = ExtractResource(Assembly.GetExecutingAssembly(), filePath);
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
                return tex;
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
                return null;
            }
        }

        public static Texture2D LoadPNG(byte[] fileData)
        {
            Texture2D tex = new Texture2D(2, 2);
            ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
            return tex;
        }

        public static byte[] ExtractResource(Assembly assembly, string filename)
        {
            try
            {
                using (Stream resFilestream = assembly.GetManifestResourceStream(filename))
                {
                    if (resFilestream == null) return null;
                    byte[] ba = new byte[resFilestream.Length];
                    resFilestream.Read(ba, 0, ba.Length);
                    return ba;
                }
            }
            catch (Exception e)
            {
                ModConsole.Error($"Failed to extract resource: {filename}");
                ModConsole.Exception(e);
            }
            return null;
        }

        public static void PopupCall(string title, string confirmButtonText, string placeholderText, bool IsNumpad, Action<string> OnAccept, Action OnCancel = null)
        {
            UiManager.ShowUiInputPopup(

                title,
                "",
                InputField.InputType.Standard,
                IsNumpad,
                confirmButtonText,
                UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>(new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>((a, b, c) => { OnAccept?.Invoke(a); })),
                UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(OnCancel),
                placeholderText,
                true,
                null,
                false,
                0
        );
        }

        //internal static void PopupCall(string title, string initialText, InputField.InputType inputType, bool isNumeric, string confirmButtonText, Action<string, List<KeyCode>, Text> onComplete, Action onCancel, string placeholderText, bool closeAfterInput, Action<VRCUiPopup> onPopupShown)
        //{
        //    UiManager.ShowUiInputPopup(title, initialText, inputType, isNumeric, confirmButtonText, onComplete, onCancel, placeholderText, closeAfterInput, onPopupShown, false, 0);
        //}

        //internal static void PopupCall(string title, string initialText, InputField.InputType inputType, bool isNumeric, string confirmButtonText, Action<string, List<KeyCode>, Text> onComplete, Action onCancel = null, string placeholderText = "Enter text...", bool closeAfterInput = true, Action<VRCUiPopup> onPopupShown = null, bool showLimitLabel = false, int textLengthLimit = 0)
        //{
        //    UiManager.ShowUiInputPopup(title, initialText, inputType, isNumeric, confirmButtonText, onComplete, onCancel, placeholderText, closeAfterInput, onPopupShown, showLimitLabel, textLengthLimit);
        //}

    }
}