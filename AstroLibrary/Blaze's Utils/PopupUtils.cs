using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Blaze.Utils
{
    internal static class PopupUtils
    {
        public static void HideCurrentPopUp()
        {
            VRCUiManager.prop_VRCUiManager_0.HideScreen("POPUP");
        }

        public static void InformationAlert(string PopupTitle, string Message, float DurationTime = 5)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_Single_0(PopupTitle, Message, DurationTime);
        }

        public static void Alert(string PopupTitle, string Message, string ButtonText, Action Action, Action<VRCUiPopup> OnPopupShown = null)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_1(PopupTitle, Message, ButtonText, Action, OnPopupShown);
        }

        public static void AlertV2(string PopupTitle, string Message, string LeftButtonTXT, Action LeftButtonAction, string RightButtonTXT, Action RightButtonAction, Il2CppSystem.Action<VRCUiPopup> OnPopupShown = null)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_1(PopupTitle, Message, LeftButtonTXT, LeftButtonAction, RightButtonTXT, RightButtonAction, OnPopupShown);
        }

        public static void AlertV2(string PopupTitle, string Message, string ButtonText, Action onSucces, Action<VRCUiPopup> OnPopupShown = null)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_0(PopupTitle, Message, ButtonText, onSucces, OnPopupShown);
        }

        public static void InputPopup(string TitleBarTXT, string AcceptButtonTXT, string DefaultInputBoxTXT, Action<string> AcceptButtonAction, Action CancelButtonAction = null)
        {
            PopupCall(TitleBarTXT, AcceptButtonTXT, DefaultInputBoxTXT, false, AcceptButtonAction, CancelButtonAction);
        }

        public static void NumericPopup(string TitleBarTXT, string AcceptButtonTXT, string DefaultInputBoxTXT, Action<string> AcceptButtonAction, Action CancelButtonAction = null)
        {
            PopupCall(TitleBarTXT, AcceptButtonTXT, DefaultInputBoxTXT, true, AcceptButtonAction, CancelButtonAction);
        }

        private static void PopupCall(string title, string confirm, string placeholder, bool IsNumpad, Action<string> OnAccept, Action OnCancel = null)
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
