﻿using VRC.UI.Core.Styles;
using VRC.UI.Elements.Tooltips;

namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using System;
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using ClientResources.Helpers;
    using Extensions;
    using TMPro;
    using Tools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using Utility;
    using Object = UnityEngine.Object;

    internal class QMSingleButton
    {
        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }


        private VRC.UI.Elements.Tooltips.UiTooltip _toolTipCache;
        public VRC.UI.Elements.Tooltips.UiTooltip ButtonToolTip
        {
            get
            {
                if (_toolTipCache != null) return _toolTipCache;
                var attempt1 = (ButtonObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>() ?? ButtonObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true)) ?? ButtonObject.AddComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
                return attempt1 != null ? _toolTipCache = attempt1 : _toolTipCache;
            }
        }
        private GameObject ButtonsMenu { get; set; }
        internal GameObject Background { get; set; }
        internal UIWidgets.ImageAdvanced BackgroundImage { get; set; }
        internal Button Button { get; set; }
        internal GameObject ButtonObject { get; set; }
        internal RectTransform ButtonRect { get; set; }
        internal TextMeshProUGUIPublicBoUnique ButtonText { get; set; }
        internal string BtnText { get; set; }
        internal string CurrentBtnColor { get; set; }
        internal string ToolTipText { get; set; }


        internal QMSingleButton(QMGridTab Parent, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUIPublicBoUnique>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QmQuickActions Parent, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool isUserPage = false)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (isUserPage)
            {
                //ButtonObject = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser_Remote.QuickActions.transform, true);
                //ButtonObject.FindUIObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            }
        }

        internal QMSingleButton(QMTabMenu Parent, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUIPublicBoUnique>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMNestedGridMenu Parent, string btnText, Action btnAction, string btnToolTip)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip);
        }

        internal QMSingleButton(QMNestedButton Parent, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUIPublicBoUnique>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMGridTab Parent, string btnText, Action btnAction, string btnToolTip = "", Color? TextColor = null)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
        }

        internal QMSingleButton(QMGridTab Parent, string btnText, Action btnAction, string btnToolTip = "", System.Drawing.Color? TextColor = null)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, ColorUtils.ColorToHex(TextColor.GetValueOrDefault(System.Drawing.Color.White)));
        }

        internal QMSingleButton(QMNestedGridMenu Parent, string btnText, Action btnAction, string btnToolTip = "", Color? TextColor = null)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
        }

        internal QMSingleButton(QMNestedGridMenu Parent, string btnText, Action btnAction, string btnToolTip = "", System.Drawing.Color? TextColor = null)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, ColorUtils.ColorToHex(TextColor.GetValueOrDefault(System.Drawing.Color.White)));
        }

        internal QMSingleButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUIPublicBoUnique>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMNestedGridMenu Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            if (Parent == null) return;

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
        }

        internal QMSingleButton(QMGridTab Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            if (Parent == null) return;
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUIPublicBoUnique>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMTabMenu Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            if (Parent == null) return;
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUIPublicBoUnique>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }



        internal QMSingleButton(GameObject Parent, string btnQMloc, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", string TextColor = null, bool btnHalf = false)
        {
            if (Parent == null) return;

            btnQMLoc = btnQMloc;
            ButtonsMenu = Parent;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUIPublicBoUnique>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        //Creates a button for VRC Menus
        protected void initButton(float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, string TextColor = null)
        {
            btnType = "SingleButton";

            switch (btnQMLoc)
            {
                case "Dashboard":
                    ButtonObject = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, QuickMenuTools.MenuDashboard_ButtonsSection);
                    ButtonObject.EnableUIComponents();
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    ButtonRect = ButtonObject.GetComponent<RectTransform>();
                    break;

                //case "QA_MainMenu":
                //    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_MainMenu.QuickActions.transform, true);
                //    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                //    break;

                case "Menu_SelectedUser_Remote":
                    ButtonObject = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser_Remote.QuickActions.transform);
                    ButtonObject.EnableUIComponents();
                    //ButtonObject.FindUIObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    ButtonRect = ButtonObject.GetComponent<RectTransform>();
                    break;

                case "Menu_SelectedUser_Local":
                    ButtonObject = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser_Local.QuickActions.transform);
                    ButtonObject.EnableUIComponents();
                   // ButtonObject.FindUIObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    ButtonRect = ButtonObject.GetComponent<RectTransform>();
                    break;
				default:
                    if (ButtonsMenu == null)
                    {
                        var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindUIObject(btnQMLoc);
                        ButtonsMenu = Part1.FindUIObject("Buttons");
                    }
                    ButtonObject = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, ButtonsMenu.transform);
                    ButtonObject.EnableUIComponents();
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    ButtonRect = ButtonObject.GetComponent<RectTransform>();
                    SetLocation(btnXLocation, btnYLocation);
                    break;

            }
            ButtonObject.FindObject("Icon").RemoveComponents<StyleElement>();
            ButtonObject.FindObject("Icon_Secondary").RemoveComponents<StyleElement>();
            var TextRoot  = ButtonObject.FindObject("Text_H4");
            if(TextRoot != null)
            {
                ButtonText = TextRoot.GetComponent<TextMeshProUGUIPublicBoUnique>();
                ButtonText.RemoveComponents<StyleElement>();
            }
            ButtonObject.SetActive(true);
            Button = ButtonObject.GetComponent<Button>();
            if (Button != null)
            {
                Button.onClick = new Button.ButtonClickedEvent();
            }
            if (ButtonRect == null)
            {
                ButtonRect = ButtonObject.GetComponent<RectTransform>();
            }
            ButtonRect.sizeDelta = QuickMenuTools.SingleButtonDefaultSize;
            SetButtonText(btnText);
            SetToolTip(btnToolTip);
            SetAction(btnAction);
            SetToolTip(btnToolTip);
            ButtonObject.transform.Find("Icon").GetComponentInChildren<UIWidgets.ImageAdvanced>().gameObject.SetActive(false);
            Background = ButtonObject.transform.Find("Background").gameObject;
            if (Background != null)
            {
                BackgroundImage = Background.GetComponent<UIWidgets.ImageAdvanced>();
            }
            ButtonText.rectTransform.anchoredPosition += new Vector2(0, 50);
            ButtonText.fontSize = 26;

            if (TextColor.IsNotNullOrEmptyOrWhiteSpace())
                setTextColorHTML(TextColor);
            else
                SetTextColor(Color.white);

            SetActive(true);

            //QMButtonAPI.allSingleButtons.Add(this);
        }


        internal void SetActive(bool isActive)
        {
            ButtonObject.SetActive(isActive);
        }
        internal void Kill_StyleElement()
        {
            ButtonObject.RemoveComponents<StyleElement>();
        }

        internal void SetButtonText(string buttonText)
        {
            BtnText = buttonText;
            var NewText = $"<color={CurrentBtnColor}>{BtnText}</color>";
            ButtonText.text = NewText;
        }

        internal void SetTextColor(Color buttonTextColor)
        {
            setTextColorHTML($"#{ColorUtility.ToHtmlStringRGB(buttonTextColor)}");
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            if (buttonTextColor.IsNotNullOrEmptyOrWhiteSpace())
            {
                CurrentBtnColor = buttonTextColor;
                var NewText = $"<color={buttonTextColor}>{BtnText}</color>";
                ButtonText.text = NewText;
            }
        }

        internal void DestroyMe()
        {
            UnityEngine.Object.Destroy(ButtonObject);
        }

        internal void SetToolTip(string text)
        {
            ToolTipText = text;
            ButtonToolTip.SetButtonToolTip(text);
        }

        internal void SetInteractable(bool isIntractable)
        {
            Button.interactable = isIntractable;
        }

        internal void SetAction(Action buttonAction)
        {
            Button.onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null) ButtonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }

        internal void SetBackgroundColor(Color buttonBackgroundColor)
        {
            ButtonObject.GetComponentInChildren<UIWidgets.ImageAdvanced>().color = buttonBackgroundColor;
        }

        internal GameObject GetGameObject()
        {
            return ButtonObject;
        }

        internal void SetButtonImage(Texture2D image, bool DontUnloadAsset = false)
        {
            if (BackgroundImage != null)
            {
                BackgroundImage.overrideSprite = image.ToSprite();
            }
            
            BackgroundImage.MakeBackgroundMoreSolid();
        }

        internal void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            // This zeroifies the position.
            ButtonRect.anchoredPosition = QuickMenuTools.SingleButtonTemplatePos;
            ButtonRect.anchoredPosition += Vector2.right * (420 / 2 * buttonXLoc);
            ButtonRect.anchoredPosition += Vector2.down * (420 / 2 * buttonYLoc);
        }

        internal void SetButtonShortcut(QMNestedButton btn)
        {
            SetButtonShortcut(btn.GetMainButton());
        }

        internal void SetButtonShortcut(QMNestedGridMenu btn)
        {
            SetButtonShortcut(btn.GetMainButton());
        }

        internal void SetButtonShortcut(QMSingleButton btn)
        {
            SetToolTip(btn.ToolTipText);
            SetButtonText(btn.BtnText);
            SetAction(() => { btn.Button.onClick.Invoke(); });
        }
    }
}