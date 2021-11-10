namespace AstroButtonAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QMNestedGridMenu
    {
        public QMSingleButton mainButton;
        internal static GameObject backButton;
        internal GameObject ButtonsMenu;

        internal string menuName;
        internal string btnQMLoc;
        internal string btnType;

        internal QMNestedGridMenu(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = Parent.GetMenuName();
            initButton(btnXLocation, btnYLocation, btnText, btnToolTip, Title, LoadSprite, TextColor);
        }

        internal QMNestedGridMenu(QMNestedGridMenu Parent, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = Parent.GetMenuName();
            initButton(btnXLocation, btnYLocation, btnText, btnToolTip, Title, LoadSprite, TextColor);
        }

        internal QMNestedGridMenu(string btnMenu, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
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
            UnityEngine.Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());

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


        internal string GetMenuName()
        {
            return menuName;
        }

        internal QMSingleButton getMainButton()
        {
            return mainButton;
        }
        internal GameObject getBackButton()
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