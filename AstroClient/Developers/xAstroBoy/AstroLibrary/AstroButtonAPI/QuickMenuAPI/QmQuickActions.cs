namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using Tools;
    using UnityEngine;

    internal class QmQuickActions
    {
        internal string btnType;
        internal GameObject Header;
        internal GameObject QuickActions;
        internal string menuName;


        internal QmQuickActions(int Index, string Menu, string Title, Color32 TextColor)
        {
            initButton(Index, Menu, Title, TextColor);
        }

        internal QmQuickActions(int Index, string Menu, string Title, string TextColor)
        {
            initButton(Index, Menu, Title, TextColor.HexToColor());
        }
        internal string GetMenuName()
        {
            return menuName;
        }


        internal GameObject GetButtonsMenu()
        {
            return QuickActions;
        }


        internal void initButton(int Index, string Menu, string Title, Color32 TextColor)
        {
            btnType = "_QMQuickActions_";
            menuName = Menu;
            switch (Menu)
            {
                case "MainMenu":
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.Header_DashboardTemplate.parent, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    var Text = Header.NewText("Text_Title");
                    Text.text = Title;
                    Text.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.MenuDashboard_ButtonsSection.gameObject, QuickMenuTools.Header_DashboardTemplate.parent, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

                case "SelectedUser":
                    Index += 5;
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.SelectedUserPage.parent, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    var Text2 = Header.NewText("Text_Title");
                    Text2.text = Title;
                    Text2.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.SelectedUserPage_ButtonsSection.gameObject, QuickMenuTools.SelectedUserPage.parent, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;
            }
        }
    }
}