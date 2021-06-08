namespace RubyButtonAPI
{
	using UnityEngine;

	public class QMTabMenu
    {
        protected QMTabButton mainButton;
        protected QMSingleButton backButton;
        protected string menuName;
        protected string btnQMLoc;
        protected string btnType;

        public QMTabMenu(float btnXLocation, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageURL = null)
        {
            InitButton(btnXLocation, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageURL);
        }

		public QMTabMenu(float btnXLocation, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
		{
			InitButton(btnXLocation, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageData);
		}

		public void InitButton(float btnXLocation, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageURL = null)
        {
            btnType = "QMTabMenu";

            Transform menu = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform);
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + btnXLocation + "_" + btnToolTip;
            menu.name = menuName;

            mainButton = new QMTabButton(btnXLocation, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageURL);

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

		public void InitButton(float btnXLocation, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
		{
			btnType = "QMTabMenu";

			Transform menu = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform);
			menuName = QMButtonAPI.identifier + btnQMLoc + "_" + btnXLocation + "_" + btnToolTip;
			menu.name = menuName;

			mainButton = new QMTabButton(btnXLocation, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageData);

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

		public string GetMenuName()
        {
            return menuName;
        }

        public QMTabButton GetMainButton()
        {
            return mainButton;
        }

        public QMSingleButton GetBackButton()
        {
            return backButton;
        }

        public void DestroyMe()
        {
            mainButton.DestroyMe();
            backButton.DestroyMe();
        }

        public void OpenMe()
        {
            QuickMenuStuff.ShowQuickmenuPage(menuName);
        }
    }
}