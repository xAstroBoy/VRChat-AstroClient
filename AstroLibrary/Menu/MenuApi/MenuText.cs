namespace AstroLibrary.Utility
{
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using UnityEngine;
	using UnityEngine.UI;

	public class MenuText
    {
        public MenuText(QMNestedButton menuBase, float posx, float poxy, string text)
        {
            menuTitle = Object.Instantiate(QuickMenuStuff.GetQuickMenuInstance().transform.Find("ShortcutMenu/EarlyAccessText").gameObject, menuBase.GetBackButton().GetGameObject().transform.parent);
            menuTitle.GetComponent<Text>().fontStyle = FontStyle.Normal;
            menuTitle.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            menuTitle.GetComponent<Text>().text = text;
            menuTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, -poxy);
            menuTitle.GetComponent<Text>().color = Color.white;
            Posx = posx;
            Posy = -poxy;
            Text = text;
            menuTitle.name = $"MenuText_{text}_{posx}_{-Posy}";
        }

        public MenuText(string MenuName, float posx, float poxy, string text)
        {
            menuTitle = Object.Instantiate(Utils.QuickMenu.transform.Find("ShortcutMenu/EarlyAccessText").gameObject, Utils.QuickMenu.transform.Find(MenuName));
            menuTitle.GetComponent<Text>().fontStyle = FontStyle.Normal;
            menuTitle.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            menuTitle.GetComponent<Text>().text = text;
            menuTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, -poxy);
            menuTitle.GetComponent<Text>().color = Color.white;
            Posx = posx;
            Posy = -poxy;
            Text = text;
            menuTitle.name = $"MenuText_{text}_{posx}_{-Posy}";
        }

        public MenuText(Transform parent, float posx, float poxy, string text)
        {
            menuTitle = Object.Instantiate(Utils.QuickMenu.transform.Find("ShortcutMenu/EarlyAccessText").gameObject, parent);
            menuTitle.GetComponent<Text>().fontStyle = FontStyle.Normal;
            menuTitle.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            menuTitle.GetComponent<Text>().text = text;
            menuTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, -poxy);
            menuTitle.GetComponent<Text>().color = Color.white;
            Posx = posx;
            Posy = -poxy;
            Text = text;
            menuTitle.name = $"MenuText_{text}_{posx}_{-Posy}";
        }

        public MenuText(Transform parent, float posx, float poxy, string text, int size)
        {
            menuTitle = Object.Instantiate(Utils.QuickMenu.transform.Find("ShortcutMenu/EarlyAccessText").gameObject, parent);
            menuTitle.name = text;
            menuTitle.GetComponent<Text>().fontStyle = FontStyle.Normal;
            menuTitle.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            menuTitle.GetComponent<Text>().text = text;
            menuTitle.GetComponent<Text>().fontSize = size;
            menuTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, -poxy);
            menuTitle.GetComponent<Text>().color = Color.white;
            Posx = posx;
            Posy = -poxy;
            Text = text;
            menuTitle.name = $"MenuText_{text}_{posx}_{-Posy}";
        }

        public GameObject menuTitle;

        public float Posx;

        public float Posy;

        public string Text;

        public void Setactive(bool value)
        {
            menuTitle.SetActive(value);
        }

        public void Delete()
        {
            Object.Destroy(menuTitle);
        }

        public void SetText(string text)
        {
            menuTitle.GetComponent<Text>().text = text;
        }

        public void SetPos(float x, float y)
        {
            Posy = y;
            Posx = x;
            menuTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(Posx, -Posy);
        }

        public void SetColor(float r, float g, float b, float a)
        {
            menuTitle.GetComponent<Text>().color = new Color(r, g, b, a);
        }

        public void SetColor(Color color)
        {
            menuTitle.GetComponent<Text>().color = color;
        }

        public void SetFontSize(int size)
        {
            menuTitle.GetComponent<Text>().fontSize = size;
        }

        private GameObject UserInfoPage;
        private GameObject AvatarPage;
        private GameObject SettingsPage;
        private GameObject SocialPage;
        private GameObject WorldsPage;
    }
}