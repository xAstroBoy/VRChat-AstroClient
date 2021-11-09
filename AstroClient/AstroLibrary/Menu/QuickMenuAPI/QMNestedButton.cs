namespace QuickMenuAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QMNestedButton
    {
        public QMSingleButton mainButton;
        internal static GameObject backButton;
        //internal QMSingleButton NotoriousMainButton;

        internal string menuName;
        internal string btnQMLoc;
        internal string btnType;

        internal QMNestedButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = Parent.getMenuName();
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

            GameObject NestedPart = UnityEngine.Object.Instantiate(QMStuff.NestedMenuTemplate_GameO(), QMStuff.NestedPages(), true);
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            UnityEngine.GameObject.Destroy(NestedPart.FindObject("Buttons").GetComponentInChildren<GridLayoutGroup>());

            UIPage Page_UI = NestedPart.AddComponent<UIPage>();
            Page_UI.name = menuName; 
            Page_UI.field_Public_Boolean_0 = true;
            Page_UI.field_Private_MenuStateController_0 = QMStuff.QuickMenuController();
            Page_UI.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page_UI.field_Private_List_1_UIPage_0.Add(Page_UI);
            NestedPart.name = menuName;
            Extensions.NewText(NestedPart, "Text_Title").text = Title;
            NestedPart.SetActive(false);
            Extensions.CleanButtonsNestedMenu(NestedPart);
            QMStuff.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, Page_UI);

            mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QMStuff.ShowQuickmenuPage(menuName); }, btnToolTip, TextColor);

            //Sets image for nested menu if needed

            if (LoadSprite.Contains("_ICON"))
            {
                LoadSprite = LoadSprite.Replace("_ICON", "");
                mainButton.getGameObject().LoadSprite(LoadSprite, "Icon");
            }
            else if (LoadSprite != "")
            {
                mainButton.getGameObject().LoadSprite(LoadSprite, "Background");
            }

            //QMButtonAPI.allNestedButtons.Add(this);

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


        internal string getMenuName()
        {
            return menuName;
        }

        internal QMSingleButton getMainButton()
        {
            return mainButton;
        }

        internal void DestroyMe()
        {
            //mainButton.DestroyMe();
            //backButton.DestroyMe();
        }
    }
}