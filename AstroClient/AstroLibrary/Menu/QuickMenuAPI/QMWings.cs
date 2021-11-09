namespace QuickMenuAPI
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QMWings : QMButtonBase
    {
        internal Transform WingPage;
        internal QMWings(int Index, bool LeftWing, string MenuName, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            btnQMLoc = "WingPage" + MenuName;
            initButton(Index, LeftWing, MenuName, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(int Index, bool LeftWing, string MenuName, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            if (LeftWing)
            {
                btnQMLoc += "_LEFT";
                button = UnityEngine.Object.Instantiate(QuickMenuStuff.WingButtonTemplate_Left(), QuickMenuStuff.Wing_Left().gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                Extensions.NewText(button, "Text_QM_H3").text = MenuName;
                setToolTip(btnToolTip);
                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                UIPage Page = QuickMenuStuff.UIPageTemplate_Left();
                UIPage Wing_UP_1 = UnityEngine.Object.Instantiate(Page, Page.transform.parent, true);
                WingPage = Wing_UP_1.transform;
                Extensions.NewText(Wing_UP_1.gameObject, "Text_Title").text = $"{MenuName}";
                Wing_UP_1.field_Public_String_0 = btnQMLoc;
                Wing_UP_1.gameObject.name = btnQMLoc;
                Wing_UP_1.field_Public_Boolean_0 = true;
                Wing_UP_1.field_Private_MenuStateController_0 = QuickMenuStuff.WingMenuStateControllerLeft();
                Wing_UP_1.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
                Wing_UP_1.field_Private_List_1_UIPage_0.Add(Wing_UP_1);
                QuickMenuStuff.WingMenuStateControllerLeft().field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, Wing_UP_1);

                var VLGC = Wing_UP_1.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                GameObject VLG = Wing_UP_1.gameObject.FindObject("VerticalLayoutGroup");
                VLG.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VLG.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                Wing_UP_1.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = Wing_UP_1.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);

                //GameObject SCB = Wing_UP_1.gameObject.FindObject("Scrollbar");
                //SCB.GetComponentInChildren<Scrollbar>(true).size = 1f;
                //SCB.GetComponentInChildren<RectTransform>(true).anchoredPosition = new Vector2(-4,100);

                //Wing_UP_1.gameObject.CleanButtonsWingMenu();
                setAction(() => { QuickMenuStuff.Wing_Left().field_Private_MenuStateController_0.PushPage(btnQMLoc); });
            }
            else
            {
                btnQMLoc += "_RIGHT";
                button = UnityEngine.Object.Instantiate(QuickMenuStuff.WingButtonTemplate_Right(), QuickMenuStuff.Wing_Right().gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                Extensions.NewText(button, "Text_QM_H3").text = MenuName;
                setToolTip(btnToolTip);

                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                UIPage Page = QuickMenuStuff.UIPageTemplate_Right();
                UIPage Wing_UP_1 = UnityEngine.Object.Instantiate(Page, Page.transform.parent, true);
                WingPage = Wing_UP_1.transform;
                Extensions.NewText(Wing_UP_1.gameObject, "Text_Title").text = MenuName;
                Extensions.NewText(Wing_UP_1.gameObject, "Text_Title").fontSize = 36;
                Wing_UP_1.field_Public_String_0 = btnQMLoc;
                Wing_UP_1.gameObject.name = btnQMLoc;
                Wing_UP_1.field_Public_Boolean_0 = true;
                Wing_UP_1.field_Private_MenuStateController_0 = QuickMenuStuff.WingMenuStateControllerRight();
                Wing_UP_1.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
                Wing_UP_1.field_Private_List_1_UIPage_0.Add(Wing_UP_1);
                QuickMenuStuff.WingMenuStateControllerRight().field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, Wing_UP_1);
                //Wing_UP_1.gameObject.CleanButtonsWingMenu();

                var VLGC2 = Wing_UP_1.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC2.spacing = 12;
                VLGC2.m_Spacing = 12;
                VLGC2.childScaleHeight = false;
                VLGC2.childScaleWidth = false;
                VLGC2.childControlHeight = false;
                VLGC2.childControlWidth = false;

                GameObject VLG = Wing_UP_1.gameObject.FindObject("VerticalLayoutGroup");
                VLG.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VLG.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                Wing_UP_1.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = Wing_UP_1.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);

                setAction(() => { QuickMenuStuff.Wing_Right().field_Private_MenuStateController_0.PushPage(btnQMLoc); });
            }



            if (LoadSprite != "")
                button.LoadSprite(LoadSprite, "Icon");
            SetActive(true);
        }

        internal void setAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}