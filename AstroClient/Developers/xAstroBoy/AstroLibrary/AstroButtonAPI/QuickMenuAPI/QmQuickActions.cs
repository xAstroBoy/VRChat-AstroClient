namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using TMPro;
    using Tools;
    using UnityEngine;

    internal class QmQuickActions
    {
        internal GameObject Header { get; set; }
        internal GameObject QuickActions { get; set; }
        internal TextMeshProUGUIPublicBoUnique HeaderText { get; set; }

        internal string menuName { get; set; }
        internal string btnType { get; set; }

        internal void DestroyMe()
        {
            UnityEngine.Object.Destroy(Header);
            UnityEngine.Object.Destroy(QuickActions);
            UnityEngine.Object.Destroy(HeaderText);
        }

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
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.MenuDashboard_VerticalLayoutGroup);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    HeaderText = Header.NewText("Text_Title");
                    HeaderText.text = Title;
                    HeaderText.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.MenuDashboard_ButtonsSection.gameObject, QuickMenuTools.MenuDashboard_VerticalLayoutGroup);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

                case "Menu_SelectedUser_Remote":
                    Index += 5;
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.SelectedUserPage_Remote_VerticalLayoutGroup);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    HeaderText = Header.NewText("Text_Title");
                    HeaderText.text = Title;
                    HeaderText.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.SelectedUserPage_ButtonsSection.gameObject, QuickMenuTools.SelectedUserPage_Remote_VerticalLayoutGroup);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

                case "Menu_SelectedUser_Local":
                    Index += 5;
                    Header = Object.Instantiate(QuickMenuTools.Header_DashboardTemplate.gameObject, QuickMenuTools.SelectedUserPage_Local_VerticalLayoutGroup);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    HeaderText = Header.NewText("Text_Title");
                    HeaderText.text = Title;
                    HeaderText.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = Object.Instantiate(QuickMenuTools.SelectedUserPage_ButtonsSection.gameObject, QuickMenuTools.SelectedUserPage_Local_VerticalLayoutGroup);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;
            }
            Header.SetActive(true);
            QuickActions.SetActive(true);
        }
    }
}