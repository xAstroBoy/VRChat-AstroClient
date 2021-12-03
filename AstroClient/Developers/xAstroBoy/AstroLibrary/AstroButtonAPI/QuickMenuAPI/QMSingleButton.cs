namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using System;
    using AstroClient.Tools.Colors;
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

    internal class QMSingleButton : QMButtonBase
    {

        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }
        internal Button Button {get; set;}
        internal UiTooltip ButtonToolTip { get; set; }
        internal RectTransform ButtonRect { get; set; }

        internal QMSingleButton(string baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = baseMenu;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMGridTab baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (btnHalf)
            {
                
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QmQuickActions baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool isUserPage = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (isUserPage)
            {
                ButtonObject = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser_Remote.QuickActions.transform, true);
                ButtonObject.EnableComponents();
                ButtonObject.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            }
        }



        internal QMSingleButton(QMTabMenu baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (btnHalf)
            {
                
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMNestedGridMenu baseMenu, string btnText, Action btnAction, string btnToolTip)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip);
        }

        internal QMSingleButton(QMNestedButton baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (btnHalf)
            {
                
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMNestedGridMenu Parent, string btnText, Action btnAction, string btnToolTip = "", Color? TextColor = null)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
        }
        internal QMSingleButton(QMNestedGridMenu Parent, string btnText, Action btnAction, string btnToolTip = "", System.Drawing.Color? TextColor = null)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, ColorUtils.ColorToHex(TextColor.GetValueOrDefault(System.Drawing.Color.White)));
        }


        internal QMSingleButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");

            if (btnHalf)
            {
                

                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMNestedGridMenu Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
        }

        internal QMSingleButton(QMGridTab Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
            
            ButtonRect.sizeDelta = QuickMenuTools.SingleButtonDefaultSize;
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMTabMenu Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
            
            ButtonRect.sizeDelta = QuickMenuTools.SingleButtonDefaultSize;
            if (btnHalf)
            {
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(string btnQMloc, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", string TextColor = null, bool btnHalf = false)
        {

            btnQMLoc = btnQMloc;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);
            if (btnHalf)
            {
                
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }


        internal QMSingleButton(GameObject btnMenu, string btnQMloc, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", string TextColor = null, bool btnHalf = false)
        {
            ButtonsMenu = btnMenu;
            btnQMLoc = btnQMloc;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);
            if (btnHalf)
            {
                
                ButtonRect.sizeDelta = new Vector2(ButtonRect.sizeDelta.x, ButtonRect.sizeDelta.y / 2 - 10f);
                ButtonRect.anchoredPosition -= new Vector2(0, ButtonRect.sizeDelta.y / 2 + 10);
                ButtonObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }


        internal TextMeshProUGUI ButtonText { get; set; }
        internal string BtnText { get; set; }
        internal string CurrentBtnColor { get; set; }
        private GameObject ButtonsMenu { get; set; }

        internal GameObject Background { get; set; }
        internal Image BackgroundImage { get; set; }
        internal RectTransform buttonRect { get; set; }

        //Creates a button for VRC Menus
        protected void initButton(float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, string TextColor = null)
        {
            btnType = "SingleButton";

            switch (btnQMLoc)
            {
                case "Dashboard":
                    ButtonObject = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, QuickMenuTools.MenuDashboard_ButtonsSection, true);
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                //case "QA_MainMenu":
                //    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_MainMenu.QuickActions.transform, true);
                //    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                //    break;

                case "SelectedUser_Remote":
                    ButtonObject = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser_Remote.QuickActions.transform, true);
                    ButtonObject.EnableComponents();
                    ButtonObject.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                case "SelectedUser_Local":
                    ButtonObject = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser_Local.QuickActions.transform, true);
                    ButtonObject.EnableComponents();
                    ButtonObject.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                default:
                    if (ButtonsMenu == null)
                    {
                        var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindObject(btnQMLoc);
                        ButtonsMenu = Part1.FindObject("Buttons");
                    }
                    ButtonObject = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, ButtonsMenu.transform, true);
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    SetLocation(btnXLocation, btnYLocation);
                    break;
            }

            ButtonText = ButtonObject.GetComponentInChildren<TextMeshProUGUI>(true);
            ButtonToolTip = ButtonObject.GetComponentInChildren<UiTooltip>(true);
            ButtonRect = ButtonObject.GetComponent<RectTransform>();
            SetButtonText(btnText);
            SetToolTip(btnToolTip);

            SetAction(btnAction);

            ButtonObject.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);
            Background = ButtonObject.transform.Find("Background").gameObject;
            if (Background != null)
            {
                BackgroundImage = Background.GetComponent<Image>();
            }
            ButtonText.rectTransform.anchoredPosition += new Vector2(0, 50);
            ButtonText.fontSize = 26;

            if (TextColor != null)
                setTextColorHTML(TextColor);
            else
            SetTextColor(Color.white);

            SetActive(true);
            //QMButtonAPI.allSingleButtons.Add(this);
        }
        internal void SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
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
            try
            {
                Object.Destroy(ButtonObject);
            }
            catch
            {
            }
        }

        internal void SetToolTip(string text)
        {
            ButtonToolTip.SetButtonToolTip(text);
        }


        internal void SetIntractable(bool isIntractable)
        {
            ButtonObject.gameObject.GetComponent<Button>().interactable = isIntractable;
        }


        internal void SetAction(Action buttonAction)
        {
            ButtonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null) ButtonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }

        internal void SetBackgroundColor(Color buttonBackgroundColor)
        {
            ButtonObject.GetComponentInChildren<Image>().color = buttonBackgroundColor;
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
                BackgroundImage.color = Color.white;
                BackgroundImage.MakeBackgroundMoreSolid();
        }

        internal void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            // This zeroifies the position.
            ButtonRect.anchoredPosition = QuickMenuTools.SingleButtonTemplatePos;

            ButtonRect.anchoredPosition += Vector2.right * (420 / 2 * buttonXLoc);
            ButtonRect.anchoredPosition += Vector2.down * (420 / 2 * buttonYLoc);

            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * (buttonXLoc + initShift[0]));
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * (buttonYLoc + initShift[1]));
            //btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            //button.name = btnQMLoc + "/" + btnType + btnTag;
            //button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void SetButtonShortcut(QMNestedButton btn)
        {
           SetAction(() => { btn.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke(); });
        }

        internal void SetButtonShortcut(QMNestedGridMenu btn)
        {
            SetAction(() => { btn.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke(); });
        }

        internal void SetButtonShortcut(QMSingleButton btn)
        {
          SetAction(() => { btn.GetGameObject().GetComponent<Button>().onClick.Invoke(); });
        }

    }
}