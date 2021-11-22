namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenu
{
    using System;
    using AstroClient.Tools.Colors;
    using ClientResources.Helpers;
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
        internal QMSingleButton(string baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = baseMenu;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (btnHalf)
            {
                var Recto = button.GetComponent<RectTransform>();
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMGridTab baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (btnHalf)
            {
                var Recto = button.GetComponent<RectTransform>();
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QmQuickActions baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool isUserPage = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (isUserPage)
            {
                button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser.QuickActions.transform, true);
                button.EnableComponents();
                button.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            }
        }



        internal QMSingleButton(QMTabMenu baseMenu, int btnXLocation, int btnYLocation, string btnText, Action btnAction, string btnToolTip, bool btnHalf = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip);

            if (btnHalf)
            {
                var Recto = button.GetComponent<RectTransform>();
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
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
                var Recto = button.GetComponent<RectTransform>();
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMNestedGridMenu Parent, string btnText, Action btnAction, string btnToolTip = "", Color? TextColor = null)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.cyan))}");
        }
        internal QMSingleButton(QMNestedGridMenu Parent, string btnText, Action btnAction, string btnToolTip = "", System.Drawing.Color? TextColor = null)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(0, 0, btnText, btnAction, btnToolTip, ColorUtils.ColorToHex(TextColor.GetValueOrDefault(System.Drawing.Color.Aqua)));
        }


        internal QMSingleButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.cyan))}");

            if (btnHalf)
            {
                var Recto = button.GetComponent<RectTransform>();

                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMNestedGridMenu Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.cyan))}");
        }

        internal QMSingleButton(QMGridTab Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {
            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.cyan))}");
            var Recto = button.GetComponent<RectTransform>();
            Recto.sizeDelta = QuickMenuTools.SingleButtonDefaultSize;
            if (btnHalf)
            {
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(QMTabMenu Parent, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", Color? BackgroundColor = null, Color? TextColor = null, bool btnHalf = false)
        {

            btnQMLoc = Parent.GetMenuName();
            ButtonsMenu = Parent.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.cyan))}");
            var Recto = button.GetComponent<RectTransform>();
            Recto.sizeDelta = QuickMenuTools.SingleButtonDefaultSize;
            if (btnHalf)
            {
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }

        internal QMSingleButton(string btnQMloc, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", string TextColor = null, bool btnHalf = false)
        {

            btnQMLoc = btnQMloc;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);
            if (btnHalf)
            {
                var Recto = button.GetComponent<RectTransform>();
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
            }
        }


        internal QMSingleButton(GameObject btnMenu, string btnQMloc, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip = "", string TextColor = null, bool btnHalf = false)
        {
            ButtonsMenu = btnMenu;
            btnQMLoc = btnQMloc;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);
            if (btnHalf)
            {
                var Recto = button.GetComponent<RectTransform>();
                Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
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
                    button = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, QuickMenuTools.MenuDashboard_ButtonsSection, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                //case "QA_MainMenu":
                //    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_MainMenu.QuickActions.transform, true);
                //    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                //    break;

                case "QA_SelectedUser":
                    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser.QuickActions.transform, true);
                    button.EnableComponents();
                    button.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                default:
                    if (ButtonsMenu == null)
                    {
                        var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindObject(btnQMLoc);
                        ButtonsMenu = Part1.FindObject("Buttons");
                    }
                    button = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, ButtonsMenu.transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    buttonRect = button.GetComponent<RectTransform>();
                    initShift[0] = -1;
                    initShift[1] = -3;
                    SetLocation(btnXLocation, btnYLocation);
                    break;
            }

            ButtonText = button.GetComponentInChildren<TextMeshProUGUI>(true);
            SetButtonText(btnText);
            SetToolTip(btnToolTip);

            SetAction(btnAction);

            button.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);
            Background = button.transform.Find("Background").gameObject;
            if (Background != null)
            {
                BackgroundImage = Background.GetComponent<Image>();
            }
            button.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition += new Vector2(0, 50);
            button.GetComponentInChildren<TextMeshProUGUI>().fontSize = 26;

            if (TextColor != null)
                setTextColorHTML(TextColor);
            else
                setTextColorHTML("#blue");

            SetActive(true);
            //QMButtonAPI.allSingleButtons.Add(this);
        }

        internal void SetButtonText(string buttonText)
        {
            BtnText = buttonText;
            var NewText = $"<color={CurrentBtnColor}>{BtnText}</color>";
            ButtonText.text = NewText;
        }

        internal void SetAction(Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null) button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }

        internal override void SetBackgroundColor(Color buttonBackgroundColor)
        {
            button.GetComponentInChildren<Image>().color = buttonBackgroundColor;
        }

        internal GameObject GetGameObject()
        {
            return button;
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


        internal override void SetTextColor(Color buttonTextColor)
        {

            setTextColorHTML($"#{ColorUtility.ToHtmlStringRGB(buttonTextColor)}");
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            CurrentBtnColor = buttonTextColor;
            var NewText = $"<color={buttonTextColor}>{BtnText}</color>";
            ButtonText.text = NewText;
        }
    }
}