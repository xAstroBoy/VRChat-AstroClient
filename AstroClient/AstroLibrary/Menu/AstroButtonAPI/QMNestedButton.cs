namespace AstroButtonAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QMNestedButton
    {
        internal QMSingleButton mainButton;
        internal GameObject backButton;
        internal GameObject ButtonsMenu;

        internal string menuName;
        internal string btnQMLoc;
        internal string btnType;

        internal QMNestedButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = Parent.GetMenuName();
            initButton(btnXLocation, btnYLocation, btnText, btnToolTip, Title, LoadSprite, TextColor);
        }
        internal QMNestedButton(QMTabMenu Parent, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title = null,  string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = Parent.GetMenuName();
            initButton(btnXLocation, btnYLocation, btnText, btnToolTip, Title, LoadSprite, TextColor);
        }
        internal QMNestedButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnText, btnToolTip, Title, LoadSprite, TextColor);
        }

        internal void initButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title, string LoadSprite = "", string TextColor = null, bool CanBeDragged = false)
        {
            btnType = QMButtonAPI.identifier + "_Nested_Menu_";
            menuName = "Page_" + btnType + Title;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages(), true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            UnityEngine.GameObject.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());

            UIPage Page_UI = NestedPart.AddComponent<UIPage>();
            Page_UI.name = menuName;
            Page_UI.field_Public_String_0 = menuName;
            Page_UI.field_Public_Boolean_0 = true;
            Page_UI.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController();
            Page_UI.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page_UI.field_Private_List_1_UIPage_0.Add(Page_UI);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = Title;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            QuickMenuTools.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, Page_UI);

            mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, TextColor);

            if (LoadSprite.Contains("_ICON"))
            {
                LoadSprite = LoadSprite.Replace("_ICON", "");
                mainButton.GetGameObject().LoadSprite(LoadSprite, "Icon");
            }
            else if (LoadSprite != "")
            {
                mainButton.GetGameObject().LoadSprite(LoadSprite, "Background");
            }

            switch (Title)
            {
                case "Main Menu":
                    NestedPart.CreateMainBackButton();
                    break;

                default:
                    NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_Menu_" + "Main Menu");
                    break;
            }
        }



        internal QMNestedButton(QMNestedGridMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }
        internal QMNestedButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }


        internal void InitButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title = "", Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnType = QMButtonAPI.identifier + "_Nested_Menu_";
            menuName = "Page_" + btnType + Title;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages(), true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            UnityEngine.GameObject.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());

            UIPage Page_UI = NestedPart.AddComponent<UIPage>();
            Page_UI.name = menuName;
            Page_UI.field_Public_String_0 = menuName;
            Page_UI.field_Public_Boolean_0 = true;
            Page_UI.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController();
            Page_UI.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page_UI.field_Private_List_1_UIPage_0.Add(Page_UI);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = Title;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            QuickMenuTools.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, Page_UI);
            string TextColorHTML = null;
            if (btnTextColor.HasValue)
            {
                TextColorHTML = ColorUtility.ToHtmlStringRGB(btnTextColor.Value);
            }

            mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, TextColorHTML, btnHalf);

            switch (Title)
            {
                case "Main Menu":
                    NestedPart.CreateMainBackButton();
                    break;

                default:
                    NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_Menu_" + "Main Menu");
                    break;
            }
            //btnType = "NestedButton";

            //Transform menu = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate(), QuickMenuStuff.QuickMenuInstance.transform);
            //menuName = $"{QMButtonAPI.identifier}{btnQMLoc}_{btnXLocation}_{btnYLocation}";
            //menu.name = menuName;

            //mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, btnTextColor, btnHalf);

            //Il2CppSystem.Collections.IEnumerator enumerator = menu.transform.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Il2CppSystem.Object obj = enumerator.Current;
            //    Transform btnEnum = obj.Cast<Transform>();
            //    if (btnEnum != null)
            //    {
            //        UnityEngine.Object.Destroy(btnEnum.gameObject);
            //    }
            //}

            //if (backbtnTextColor == null)
            //{
            //    backbtnTextColor = Color.yellow;
            //}

            //QMButtonAPI.allNestedButtons.Add(this);
            //backButton = new QMSingleButton(this, 5, 2, "Back", () => { QuickMenuStuff.ShowQuickmenuPage(btnQMLoc); }, "Go Back", backbtnBackgroundColor, backbtnTextColor);
        }

        internal string GetMenuName()
        {
            return menuName;
        }

        internal QMSingleButton GetMainButton()
        {
            return mainButton;
        }

        internal GameObject GetBackButton()
        {
            return backButton;
        }

        internal void DestroyMe()
        {
            mainButton.DestroyMe();
            //backButton.DestroyMe();
        }
    }
}
