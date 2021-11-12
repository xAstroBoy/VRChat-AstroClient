namespace CheetoLibrary
{
    #region Imports

    using System;
    using System.IO;
    using System.Reflection;
    using AstroLibrary.Console;
    using UnityEngine;
    using UnityEngine.UI;

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

        public static Texture2D LoadPNG(string filePath)
        {
            try
            {
                byte[] fileData = ExtractResource(Assembly.GetExecutingAssembly(), filePath);
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
                return tex;
            }
            catch(Exception e)
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