namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using PageGenerators;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using CameraMenu = MonoBehaviour1PublicBuToBuGaBuGaBuGaBuGaUnique;

    internal class QMTabMenu
    {
        internal QMSingleButton backButton { get; set; }
        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal QMTabButton mainButton { get; set; }
        internal string menuName { get; set; }
        internal UIPage page { get; set; }
        internal GameObject NestedPart { get; set; }

        internal QMTabMenu(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, icon);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            Object.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            Object.Destroy(NestedPart.FindObject("Panel_Info"));
            Object.Destroy(NestedPart.FindObject("Button_PhotosFolder"));
            foreach (var item in ButtonsMenu.transform.Get_Childs())
            {
                item.DestroyMeLocal(true);
            }
            page = NestedPart.GenerateQuickMenuPage(menuName);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = btnToolTip;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            mainButton = new QMTabButton(index, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, icon);
        }

        internal string GetMenuName()
        {
            return menuName;
        }

        internal QMTabButton GetMainButton()
        {
            return mainButton;
        }

        internal QMSingleButton GetBackButton()
        {
            return backButton;
        }

        internal GameObject GetButtonsMenu()
        {
            return ButtonsMenu;
        }

        internal UIPage GetPage()
        {
            return page;
        }

        internal void DestroyMe()
        {
            //page.DestroyMeLocal(true);
            ButtonsMenu.DestroyMeLocal(true);
            NestedPart.DestroyMeLocal(true);

            backButton.DestroyMe();
            mainButton.DestroyMe();
        }

        internal void OpenMe()
        {
            QuickMenuTools.ShowQuickmenuPage(menuName);
        }
    }
}