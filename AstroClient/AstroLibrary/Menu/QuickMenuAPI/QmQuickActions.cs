namespace QuickMenuAPI
{
    using UnityEngine;

    internal class QmQuickActions
    {
        internal string btnType;
        internal GameObject Header;
        internal GameObject QuickActions;
        internal QmQuickActions(int Index, string Menu, string Title, Color32 TextColor)
        {
            initButton(Index, Menu, Title, TextColor);
        }

        internal QmQuickActions(int Index, string Menu, string Title, string TextColor)
        {
            initButton(Index, Menu, Title, TextColor.HexToColor());
        }

        internal void initButton(int Index, string Menu, string Title, Color32 TextColor)
        {
            btnType = "_QMQuickActions_";

            switch (Menu)
            {
                case "MainMenu":
                    Header = UnityEngine.Object.Instantiate(QMStuff.Header_DashboardTemplate(), QMStuff.Header_DashboardTemplate().transform.parent, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    var Text = Extensions.NewText(Header, "Text_Title");
                    Text.text = Title;
                    Text.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = UnityEngine.Object.Instantiate(QMStuff.MenuDashboard_ButtonsSection().gameObject, QMStuff.Header_DashboardTemplate().transform.parent, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

                case "SelectedUser":
                    Index += 5;
                    Header = UnityEngine.Object.Instantiate(QMStuff.Header_DashboardTemplate(), QMStuff.SelectedUserPage().transform.parent, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    var Text2 = Extensions.NewText(Header, "Text_Title");
                    Text2.text = Title;
                    Text2.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = UnityEngine.Object.Instantiate(QMStuff.SelectedUserPage_ButtonsSection().gameObject, QMStuff.SelectedUserPage().transform.parent, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;
            }

        }
    }
}