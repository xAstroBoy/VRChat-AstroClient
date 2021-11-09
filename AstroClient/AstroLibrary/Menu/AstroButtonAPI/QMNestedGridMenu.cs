namespace AstroButtonAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QMNestedGridMenu
    {
        internal QMSingleButton mainButton;
        internal QMSingleButton backButton;

        internal string menuName;
        internal string btnQMLoc;
        internal string btnType;
        private bool AutomaticGrid = false;

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
            btnType = QMButtonAPI.identifier + "_GridNested_Menu_";
            menuName = "Page_" + btnType + Title;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate_GameO(), QuickMenuStuff.NestedPages(), true);
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());

            NestedPart.FindObject("Buttons").GetComponentInChildren<GridLayoutGroup>().enabled = true;
            
            UIPage Page_UI = NestedPart.AddComponent<UIPage>();
            Page_UI.name = menuName; 
            Page_UI.field_Public_Boolean_0 = true;
            Page_UI.field_Private_MenuStateController_0 = QuickMenuStuff.QuickMenuController();
            Page_UI.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page_UI.field_Private_List_1_UIPage_0.Add(Page_UI);
            NestedPart.name = menuName;
            Extensions.NewText(NestedPart, "Text_Title").text = Title;
            NestedPart.SetActive(false);
            Extensions.CleanButtonsNestedMenu(NestedPart);
            QuickMenuStuff.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, Page_UI);

            mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, TextColor);

            //Sets image for nested menu if needed

            if (LoadSprite.Contains("_ICON"))
            {
                LoadSprite = LoadSprite.Replace("_ICON", "");
                mainButton.GetGameObject().LoadSprite(LoadSprite, "Icon");
            }
            else if (LoadSprite != "")
            {
                mainButton.GetGameObject().LoadSprite(LoadSprite, "Background");
            }

            //QMButtonAPI.allNestedButtons.Add(this);

            switch (Title)
            {
                case "Main Menu":
                    NestedPart.CreateMainBackButton();
                    break;

                default:
                    NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_GridMenu_" + "Main Menu");
                    break;
            }
        }


        internal string GetMenuName()
        {
            return menuName;
        }

        internal QMSingleButton GetMainButton()
        {
            return mainButton;
        }
        internal QMSingleButton GetBackButton()
        {
            return backButton;
        }

        internal void DestroyMe()
        {
            mainButton.DestroyMe();
            backButton.DestroyMe();
        }
    }
}