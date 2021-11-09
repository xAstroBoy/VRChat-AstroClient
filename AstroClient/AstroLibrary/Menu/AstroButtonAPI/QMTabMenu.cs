namespace AstroButtonAPI
{
    using UnityEngine;

    internal class QMTabMenu
    {
        protected QMTabButton mainButton;
        protected QMSingleButton backButton;
        protected string menuName;
        protected string btnQMLoc;
        protected string btnType;

        internal QMTabMenu(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageData);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageURL = null)
        {
            btnType = "QMTabMenu";

            Transform menu = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform);
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;
            menu.name = menuName;

            mainButton = new QMTabButton(index, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageURL);

            Il2CppSystem.Collections.IEnumerator enumerator = menu.transform.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Il2CppSystem.Object obj = enumerator.Current;
                Transform btnEnum = obj.Cast<Transform>();
                if (btnEnum != null)
                {
                    UnityEngine.Object.Destroy(btnEnum.gameObject);
                }
            }
            if (backbtnTextColor == null)
            {
                backbtnTextColor = Color.yellow;
            }
            // backButton = new QMSingleButton(menuName, 5, 2, "Back", () => { QuickMenuStuff.ShowQuickmenuPage("ShortcutMenu"); }, "Go Back", backbtnBackgroundColor, backbtnTextColor);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
        {
            btnType = "QMTabMenu";

            Transform menu = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform);
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;
            menu.name = menuName;

            mainButton = new QMTabButton(index, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageData);

            Il2CppSystem.Collections.IEnumerator enumerator = menu.transform.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Il2CppSystem.Object obj = enumerator.Current;
                Transform btnEnum = obj.Cast<Transform>();
                if (btnEnum != null)
                {
                    UnityEngine.Object.Destroy(btnEnum.gameObject);
                }
            }
            if (backbtnTextColor == null)
            {
                backbtnTextColor = Color.yellow;
            }
            // backButton = new QMSingleButton(menuName, 5, 2, "Back", () => { QuickMenuStuff.ShowQuickmenuPage("ShortcutMenu"); }, "Go Back", backbtnBackgroundColor, backbtnTextColor);
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

        internal void DestroyMe()
        {
            mainButton.DestroyMe();
            backButton.DestroyMe();
        }

        internal void OpenMe()
        {
            QuickMenuStuff.ShowQuickmenuPage(menuName);
        }
    }
}