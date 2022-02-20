// Credits to Blaze and DayOfThePlay

namespace AstroClient.xAstroBoy.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using MelonLoader;
    using UnhollowerRuntimeLib.XrefScans;
    using UnityEngine;
    using UnityEngine.UI;

    public static class PopupUtils
    {
        public static void Alert(this VRCUiPopupManager instance, string title, string Content, string buttonname, Action onSucces, Action<VRCUiPopup> onPopupShown = null)
        {
            ShowStandart2Popup(title, Content, buttonname, onSucces, onPopupShown);
        }

        public static void Alert(this VRCUiPopupManager instance, string title, string Content, string buttonname, Action action, string button2, Action action2, Action<VRCUiPopup> onPopupShown = null)
        {
            ShowStandart3Popup(title, Content, buttonname, action, button2, action2, onPopupShown);
        }

        public static void AlertV2(this VRCUiPopupManager instance, string title, string Content, string buttonname, Action onSucces, Action<VRCUiPopup> onPopupShown = null)
        {
            ShowStandartV21Popup(title, Content, buttonname, onSucces, onPopupShown);
        }

        public static void AlertV2(this VRCUiPopupManager instance, string title, string Content, string buttonname, Action action, string button2, Action action2, Action<VRCUiPopup> onPopupShown = null)
        {
            ShowStandartV22Popup(title, Content, buttonname, action, button2, action, onPopupShown);
        }

        public static void HideCurrentPopUp(this VRCUiPopupManager instance)
        {
            GameInstances.VRCUiManager.HideScreen("POPUP");
        }

        public static void QueHudMessage(string message)
        {
            //ModConsole.Log($"[HudMessage] {message}");
            if (!WorldUtils.IsInWorld) return;
            if (HudMessage1 == null)
            {
                HudMessage1 = CreateTextNear(CreateImage("yes", 100f), 110f, TextAnchor.LowerCenter);
                HudMessage1.supportRichText = true;
            }
            MelonCoroutines.Start(ShowMessage(HudMessage1, MessagesList, message));
        }

        public static void ClearHudMessages(this VRCUiManager instance)
        {
            instance.field_Private_List_1_String_0.Clear();
            instance.field_Public_Text_0.text = "";
            MessagesList.Clear();
        }

        public static bool IsTyping = false;

        public static void AskInGameInput(this VRCUiPopupManager instance, string title, string okButtonName, Action<string> onSuccess, string def = null)
        {
            IsTyping = true;
            MiscUtils.DelayFunction(15, delegate { IsTyping = false; });
            instance.InputPopUp(title, okButtonName, new Action<string>((g) =>
            {
                onSuccess(g);
                instance.HideCurrentPopUp();
                IsTyping = false;
            }), new Action(() =>
            {
                instance.HideCurrentPopUp();
                IsTyping = false;
            }), def);
        }

        public static List<string> MessagesList = new List<string>();

        private static void InputPopUp(this VRCUiPopupManager instance, string title, string okButtonName, Action<string> onSuccess, Action Button2, string def = null)
        {
            ShowUiInputPopup(title, "", InputField.InputType.Standard, false, okButtonName, new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>((g, l, t) =>
            {
                if (string.Empty == g)
                {
                    g = def;
                }
                onSuccess(g);
            }), Button2, def ?? "");
        }

        internal static void NumericInputPopup(this VRCUiPopupManager instance, string title, string okButtonName, Action<string> onSuccess, string def = null)
        {
            ShowUiInputPopup(title, "", InputField.InputType.Standard, true, okButtonName, new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>((g, l, t) =>
            {
                if (string.Empty == g)
                {
                    g = def;
                }
                onSuccess(g);
            }), new Action(() =>
            {
                instance.HideCurrentPopUp();
                IsTyping = false;
            }), def ?? "");
        }

        internal delegate void ShowUiInputPopupAction(string title, string initialText, InputField.InputType inputType, bool isNumeric, string confirmButtonText, Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> onComplete, Il2CppSystem.Action onCancel, string placeholderText = "Enter text...", bool closeAfterInput = true, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

        private static ShowUiInputPopupAction ourShowUiInputPopupAction;

        internal static ShowUiInputPopupAction ShowUiInputPopup
        {
            get
            {
                if (ourShowUiInputPopupAction != null) return ourShowUiInputPopupAction;

                var targetMethod = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Single(it =>
                    it.GetParameters().Length == 10 &&
                    XrefScanner.XrefScan(it).Any(jt =>
                    jt.Type == XrefType.Global &&
                    jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/InputPopup"));

                ourShowUiInputPopupAction = (ShowUiInputPopupAction)Delegate.CreateDelegate(typeof(ShowUiInputPopupAction), GameInstances.VRCUiPopupManager, targetMethod);

                return ourShowUiInputPopupAction;
            }
        }

        public static void ShowAlert(this VRCUiPopupManager instance, string title, string content, float timeout = 10)
        {
            ShowAlertPopup(title, content, timeout);
        }

        internal delegate void ShowAlertPopupAction(string title, string content, float timeout);

        private static ShowAlertPopupAction ourShowAlertPopupAction;

        internal static ShowAlertPopupAction ShowAlertPopup
        {
            get
            {
                if (ourShowAlertPopupAction != null) return ourShowAlertPopupAction;

                var targetMethod = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Single(it =>
                    it.GetParameters().Length == 3 &&
                    XrefScanner.XrefScan(it).Any(jt =>
                    jt.Type == XrefType.Global &&
                    jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/AlertPopup"));

                ourShowAlertPopupAction = (ShowAlertPopupAction)Delegate.CreateDelegate(typeof(ShowAlertPopupAction), GameInstances.VRCUiPopupManager, targetMethod);

                return ourShowAlertPopupAction;
            }
        }

        internal delegate void ShowStandart1PopupAction(string title, string body, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

        private static ShowStandart1PopupAction ourShowStandartV1PopupAction;

        internal static ShowStandart1PopupAction ShowStandartV1Popup
        {
            get
            {
                if (ourShowStandartV1PopupAction != null) return ourShowStandartV1PopupAction;

                var targetMethod = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Single(it =>
                    it.GetParameters().Length == 3 &&
                    XrefScanner.XrefScan(it).Any(jt =>
                    jt.Type == XrefType.Global &&
                    jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopup"));

                ourShowStandartV1PopupAction = (ShowStandart1PopupAction)Delegate.CreateDelegate(typeof(ShowStandart1PopupAction), VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, targetMethod);

                return ourShowStandartV1PopupAction;
            }
        }

        public delegate void ShowStandart2PopupAction(string title, string body, string middleButtonText, Il2CppSystem.Action middleButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

        private static ShowStandart2PopupAction ourShowStandart2PopupAction;

        internal static ShowStandart2PopupAction ShowStandart2Popup
        {
            get
            {
                if (ourShowStandart2PopupAction != null) return ourShowStandart2PopupAction;

                MethodInfo targetMethod = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single(delegate (MethodInfo it)
                {
                    if (it.GetParameters().Length == 5)
                    {
                        return XrefScanner.XrefScan(it).Any(delegate (XrefInstance jt)
                        {
                            if (jt.Type == XrefType.Global)
                            {
                                Il2CppSystem.Object @object = jt.ReadAsObject();
                                return (@object?.ToString()) == "UserInterface/MenuContent/Popups/StandardPopup";
                            }
                            return false;
                        });
                    }
                    return false;
                });
                ourShowStandart2PopupAction = (ShowStandart2PopupAction)Delegate.CreateDelegate(typeof(ShowStandart2PopupAction), VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, targetMethod);

                return ourShowStandart2PopupAction;
            }
        }

        internal delegate void ShowStandart3PopupAction(string title, string body, string leftButtonText, Il2CppSystem.Action leftButtonAction, string rightButtonText, Il2CppSystem.Action rightButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

        private static ShowStandart3PopupAction ourShowStandart3PopupAction;

        internal static ShowStandart3PopupAction ShowStandart3Popup
        {
            get
            {
                if (ourShowStandart3PopupAction != null) return ourShowStandart3PopupAction;

                var targetMethod = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Single(it =>
                    it.GetParameters().Length == 7 &&
                    XrefScanner.XrefScan(it).Any(jt =>
                    jt.Type == XrefType.Global &&
                    jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopup"));

                ourShowStandart3PopupAction = (ShowStandart3PopupAction)Delegate.CreateDelegate(typeof(ShowStandart3PopupAction), VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, targetMethod);

                return ourShowStandart3PopupAction;
            }
        }

        internal delegate void ShowStandartV21PopupAction(string title, string body, string middleButtonText, Il2CppSystem.Action middleButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

        private static ShowStandartV21PopupAction ourShowStandartV21PopupAction;

        internal static ShowStandartV21PopupAction ShowStandartV21Popup
        {
            get
            {
                if (ourShowStandartV21PopupAction != null) return ourShowStandartV21PopupAction;

                var targetMethod = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Single(it =>
                    it.GetParameters().Length == 5 &&
                    XrefScanner.XrefScan(it).Any(jt =>
                    jt.Type == XrefType.Global &&
                    jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopupV2"));

                ourShowStandartV21PopupAction = (ShowStandartV21PopupAction)Delegate.CreateDelegate(typeof(ShowStandartV21PopupAction), VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, targetMethod);

                return ourShowStandartV21PopupAction;
            }
        }

        internal delegate void ShowStandartV22PopupAction(string title, string body, string leftButtonText, Il2CppSystem.Action leftButtonAction, string rightButtonText, Il2CppSystem.Action rightButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

        private static ShowStandartV22PopupAction ourShowStandartV22PopupAction;

        internal static ShowStandartV22PopupAction ShowStandartV22Popup
        {
            get
            {
                if (ourShowStandartV22PopupAction != null) return ourShowStandartV22PopupAction;

                var targetMethod = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Single(it =>
                    it.GetParameters().Length == 7 &&
                    XrefScanner.XrefScan(it).Any(jt =>
                    jt.Type == XrefType.Global &&
                    jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopupV2"));

                ourShowStandartV22PopupAction = (ShowStandartV22PopupAction)Delegate.CreateDelegate(typeof(ShowStandartV22PopupAction), VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, targetMethod);

                return ourShowStandartV22PopupAction;
            }
        }

        public static Image CreateImage(string name, float offset)
        {
            var hudRoot = GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud");
            var requestedParent = hudRoot.transform.Find("NotificationDotParent");
            var indicator = UnityEngine.Object.Instantiate(hudRoot.transform.Find("NotificationDotParent/NotificationDot").gameObject, requestedParent, false).Cast<GameObject>();
            indicator.name = "NotifyDot-" + name;
            indicator.SetActive(true);
            indicator.transform.localPosition += Vector3.right * offset;
            var image = indicator.GetComponent<Image>();
            image.enabled = false;
            return image;
        }

        public static Text CreateTextNear(Image image, float offset, TextAnchor alignment)
        {
            var gameObject = new GameObject(image.gameObject.name + "-text");
            gameObject.AddComponent<Text>();
            gameObject.transform.SetParent(image.transform, false);
            gameObject.transform.localScale = Vector3.one;
            gameObject.transform.localPosition = Vector3.up * offset + Vector3.right * 300f;
            var text = gameObject.GetComponent<Text>();
            text.color = Color.white;
            text.fontStyle = FontStyle.Bold;
            text.horizontalOverflow = HorizontalWrapMode.Overflow;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.alignment = alignment;
            text.fontSize = 30;
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.supportRichText = true;

            gameObject.SetActive(true);
            return text;
        }

        public static Text HudMessage1;

        public static System.Collections.IEnumerator ShowMessage(Text text, List<string> MessagesList, string message)
        {
            MessagesList.Add(message);
            text.text = string.Join("\n", MessagesList);
            yield return new WaitForSeconds(5f);
            MessagesList.Remove(message);
            text.text = string.Join("\n", MessagesList);
        }
    }
}