namespace QuickMenuAPI
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    internal class QMSingleButton : QMButtonBase
    {
        internal bool State = false;
        internal TMPro.TextMeshProUGUI Text;
        public QMSingleButton(QMWings Parent, string btnText, System.Action btnAction, string btnToolTip, bool IsToggle = false, string TextColor = null)
        {
            initButton2(Parent.WingPage.gameObject, btnText, btnAction, btnToolTip, IsToggle);
        }

        public QMSingleButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
        {
            btnQMLoc = Parent.getMenuName();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);

            if (btnHalf)
            {
                RectTransform Recto = button.GetComponent<RectTransform>();

                if (IsUp)
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition += new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
                else
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
            }
        }

        public QMSingleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, String btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);

            if (btnHalf)
            {
                RectTransform Recto = button.GetComponent<RectTransform>();

                if (IsUp)
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition += new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
                else
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
            }
        }

        //Creates a button for VRC Menus
        private protected void initButton(float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, String btnToolTip, string TextColor = null)
        {
            btnType = "SingleButton";

            switch (btnQMLoc)
            {
                case "Dashboard":
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), QMStuff.MenuDashboard_ButtonsSection(), true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                case "QA_MainMenu":
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), MenuAPI_New.QA_MainMenu.QuickActions.transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                case "QA_SelectedUser":
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplateSelUser(), MenuAPI_New.QA_SelectedUser.QuickActions.transform, true);
                    button.EnableComponents();
                    button.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                default:
                    var Part1 = QMStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    initShift[0] = -1;
                    initShift[1] = -3;
                    setLocation(btnXLocation, btnYLocation);
                    break;
            }

            setButtonText(btnText);
            setToolTip(btnToolTip);

            setAction(btnAction);

            button.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition += new Vector2(0, 50);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 26;

            if (TextColor != null)
                setTextColorHTML(TextColor);
            else
                setTextColorHTML("#blue");


            setActive(true);
            //QMButtonAPI.allSingleButtons.Add(this);
        }




        //Creates button and parents it to a GameObject
        private protected void initButton(GameObject Parent, string btnText, System.Action btnAction, String btnToolTip)
        {
            btnType = "SingleButton";

            button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), Parent.FindObject("Buttons").transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;

            setButtonText(btnText);
            setToolTip(btnToolTip);
            setAction(btnAction);

            button.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition += new Vector2(0, 50);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 30;

            //if (btnBackgroundColor != null)
            //    setBackgroundColor((Color)btnBackgroundColor);
            //else
            //    OrigBackground = button.GetComponentInChildren<UnityEngine.UI.Image>().color;

            //if (btnTextColor != null)
            //    setTextColor((Color)btnTextColor);
            //else
            //    OrigText = button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color;

            setActive(true);
            //QMButtonAPI.allSingleButtons.Add(this);
        }

        internal string BtnText;
        private protected void initButton2(GameObject Parent, string btnText, System.Action btnAction, String btnToolTip, bool IsToggle = false)
        {
            btnType = "SingleButton";

            var Layout = Parent.FindObject("VerticalLayoutGroup");
            button = UnityEngine.Object.Instantiate(QMStuff.WingPageButtonTemplate(), Layout.transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            button.SetActive(true);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 35;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().autoSizeTextContainer = true;
            button.AddComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = btnToolTip;
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);

            if (IsToggle)
            {
                BtnText = btnText;
                setOffText();
                btnAction += delegate ()
                {
                    State = !State;
                };
            }
            else
            {
                setButtonText(btnText);
            }


            setAction(btnAction);


            //if (btnBackgroundColor != null)
            //    setBackgroundColor((Color)btnBackgroundColor);
            //else
            //    OrigBackground = button.GetComponentInChildren<UnityEngine.UI.Image>().color;

            //if (btnTextColor != null)
            //    setTextColor((Color)btnTextColor);
            //else
            //    OrigText = button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color;

            //QMButtonAPI.allSingleButtons.Add(this);
        }

        internal void setButtonText(string buttonText)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = buttonText;
        }

        internal void setOnText()
        {
            string Text = BtnText + " <color=green>ON</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
        }

        internal void setOffText()
        {
            string Text = BtnText + " <color=red>OFF</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
        }

        internal void setAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
            {
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
            }
        }


        internal override void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
        }

        internal override void setTextColor(Color buttonTextColor)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = buttonTextColor;
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            string NewText = $"<color={buttonTextColor}>{button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = NewText;
        }
    }
}