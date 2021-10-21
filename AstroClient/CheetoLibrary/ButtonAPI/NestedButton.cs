namespace CheetoLibrary.ButtonAPI
{
    using UnityEngine;

    public class NestedButton : ButtonBase
    {
        internal DashMenuPage MenuPage { get; }

        public NestedButton(Transform parent, string title, string tooltip, byte[] icon = null, bool jump = false) : base(parent, title, tooltip, icon, null, true)
        {
            MenuPage = new DashMenuPage($"{CheetoButtonAPI.Indentifier}{CheetoButtonAPI.UIElements.Count}{title}");
            SetAction(() => QMUtils.ShowQuickmenuPage(MenuPage.MenuName));
        }
    }
}