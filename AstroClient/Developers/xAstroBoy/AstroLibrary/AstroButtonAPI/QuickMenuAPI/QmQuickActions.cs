namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using TMPro;
    using Tools;
    using UnityEngine;

    internal class QmQuickActions
    {
        internal string btnType { get; set; }
        internal GameObject Header { get; set; }
        internal GameObject QuickActions { get; set; }
        internal string menuName { get; set; }
        internal TextMeshProUGUI HeaderText { get; set; }

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
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.MenuDashboard_VerticalLayoutGroup, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    HeaderText = Header.NewText("Text_Title");
                    HeaderText.text = Title;
                    HeaderText.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.MenuDashboard_ButtonsSection.gameObject, QuickMenuTools.MenuDashboard_VerticalLayoutGroup, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

                case "SelectedUser_Remote":
                    Index += 5;
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.SelectedUserPage_Remote_VerticalLayoutGroup, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    HeaderText = Header.NewText("Text_Title");
                    HeaderText.text = Title;
                    HeaderText.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.SelectedUserPage_ButtonsSection.gameObject, QuickMenuTools.SelectedUserPage_Remote_VerticalLayoutGroup, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

                case "SelectedUser_Local":
                    Index += 5;
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.SelectedUserPage_Local_VerticalLayoutGroup, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    HeaderText = Header.NewText("Text_Title");
                    HeaderText.text = Title;
                    HeaderText.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.SelectedUserPage_ButtonsSection.gameObject, QuickMenuTools.SelectedUserPage_Local_VerticalLayoutGroup, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

            }
        }
    }
}