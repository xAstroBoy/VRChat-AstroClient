﻿namespace AstroButtonAPI
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    internal class QMSingleButton : QMButtonBase
    {
        internal TMPro.TextMeshProUGUI Text;
        internal string BtnText;

        public QMSingleButton(QMTabMenu Parent, float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
        {
            btnQMLoc = Parent.GetMenuName();
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

        public QMSingleButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
        {
            btnQMLoc = Parent.GetMenuName();
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

        public QMSingleButton(QMNestedGridMenu Parent, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
        {
            btnQMLoc = Parent.GetMenuName();
            initButton(0, 0, btnText, btnAction, btnToolTip, TextColor);

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



        public QMSingleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
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
        private protected void initButton(float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null)
        {
            btnType = "SingleButton";

            switch (btnQMLoc)
            {
                case "Dashboard":
                    button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), QuickMenuStuff.MenuDashboard_ButtonsSection(), true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                case "QA_MainMenu":
                    button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), MenuAPI_New.QA_SelectedUser.QuickActions.transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                case "QA_SelectedUser":
                    button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplateSelUser(), MenuAPI_New.QA_SelectedUser.QuickActions.transform, true);
                    button.EnableComponents();
                    button.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                default:
                    var Part1 = QuickMenuStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
                    button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    initShift[0] = -1;
                    initShift[1] = -3;
                    SetLocation(btnXLocation, btnYLocation);
                    break;
            }

            SetButtonText(btnText);
            setToolTip(btnToolTip);

            setAction(btnAction);

            button.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition += new Vector2(0, 50);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 26;

            if (TextColor != null)
                setTextColorHTML(TextColor);
            else
                setTextColorHTML("#blue");


            SetActive(true);
            //QMButtonAPI.allSingleButtons.Add(this);
        }


        internal void SetButtonText(string buttonText)
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