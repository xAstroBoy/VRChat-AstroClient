namespace AstroClient.xAstroBoy.AstroButtonAPI
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QMWings : QMButtonBase
    {
        internal Transform WingPageTransform;

        internal UIPage CurrentPage;

        internal string MenuName;

        internal GameObject backbuttonObject;
        internal Button BackButton;

        internal TextMeshProUGUI ButtonText_Title;
        internal TextMeshProUGUI ButtonText;

        internal QMWings(int Index, bool LeftWing, string MenuName, string btnToolTip, Color? btnBackgroundColor = null, Sprite icon = null)
        {
            btnQMLoc = "WingPage" + MenuName;
            initButton(Index, LeftWing, MenuName, btnToolTip, btnBackgroundColor, icon);
        }

        internal void initButton(int Index, bool LeftWing, string AssignedMenu, string btnToolTip, Color? btnBackgroundColor = null, Sprite icon = null)
        {
            if (LeftWing)
            {
                btnQMLoc += $"_LEFT_{System.Guid.NewGuid().ToString()} ";
                button = UnityEngine.Object.Instantiate(QuickMenuTools.WingButtonTemplate_Left(), QuickMenuTools.Wing_Left().gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = button.NewText("Text_QM_H3");
                ButtonText.text = MenuName;



                SetToolTip(btnToolTip);
                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);
                UIPage Page = QuickMenuTools.UIPageTemplate_Left();
                CurrentPage = UnityEngine.Object.Instantiate(Page, Page.transform.parent, true);
                WingPageTransform = CurrentPage.transform;
                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                ButtonText_Title.text = $"{MenuName}";
                ButtonText_Title.fontSize = 36;
                CurrentPage.field_Public_String_0 = btnQMLoc; //Name
                CurrentPage.gameObject.name = btnQMLoc;
                CurrentPage.field_Public_Boolean_0 = true; //_inited
                CurrentPage.field_Private_MenuStateController_0 = QuickMenuTools.WingMenuStateControllerLeft(); //_menuStateController
                CurrentPage.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>(); //_pageStack
                CurrentPage.field_Private_List_1_UIPage_0.Add(CurrentPage);
                QuickMenuTools.WingMenuStateControllerLeft().field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, CurrentPage); //_uiPages

                var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                GameObject VLG = CurrentPage.gameObject.FindObject("VerticalLayoutGroup");
                VLG.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VLG.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.gameObject.FindObject("Button_Back");
                BackButton = backbuttonObject.GetComponent<Button>();

                //PushPage
                SetAction(() => { QuickMenuTools.Wing_Left().ShowQuickmenuPage(btnQMLoc); });
            }
            else
            {
                btnQMLoc += $"_RIGHT_{System.Guid.NewGuid().ToString()}";
                button = UnityEngine.Object.Instantiate(QuickMenuTools.WingButtonTemplate_Right(), QuickMenuTools.Wing_Right().gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = button.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                SetToolTip(btnToolTip);

                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                UIPage Page = QuickMenuTools.UIPageTemplate_Right();
                CurrentPage = UnityEngine.Object.Instantiate(Page, Page.transform.parent, true);
                WingPageTransform = CurrentPage.transform;
                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");

                ButtonText_Title.text = MenuName;
                ButtonText_Title.fontSize = 36;
                CurrentPage.field_Public_String_0 = btnQMLoc;
                CurrentPage.gameObject.name = btnQMLoc;
                CurrentPage.field_Public_Boolean_0 = true;
                CurrentPage.field_Private_MenuStateController_0 = QuickMenuTools.WingMenuStateControllerRight();
                CurrentPage.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
                CurrentPage.field_Private_List_1_UIPage_0.Add(CurrentPage);
                QuickMenuTools.WingMenuStateControllerRight().field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, CurrentPage);

                var VLGC2 = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC2.spacing = 12;
                VLGC2.m_Spacing = 12;
                VLGC2.childScaleHeight = false;
                VLGC2.childScaleWidth = false;
                VLGC2.childControlHeight = false;
                VLGC2.childControlWidth = false;

                GameObject VLG = CurrentPage.gameObject.FindObject("VerticalLayoutGroup");
                VLG.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VLG.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.gameObject.FindObject("Button_Back");
                BackButton = backbuttonObject.GetComponent<Button>();

                //PushPage
                SetAction(() => { QuickMenuTools.Wing_Right().ShowQuickmenuPage(btnQMLoc); });
            }

            if (icon != null)
                button.LoadSprite(icon, "Icon");
            SetActive(true);
        }

        internal string GetMenuName()
        {
            return btnQMLoc;
        }

        internal UIPage GetPage()
        {
            return CurrentPage;
        }

        internal void SetButtonTitle(string text)
        {
            ButtonText_Title.text = text;
        }

        internal void SetButtonText(string text)
        {
            ButtonText.text = text;
        }

        internal void LoadIcon(Sprite icon)
        {
            if (icon != null)
                button.LoadSprite(icon, "Icon");
        }

        internal void ClickBackButton()
        {
            BackButton.onClick.Invoke();
        }

        internal void SetAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}