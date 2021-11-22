namespace AstroClient.CheetoLibrary.Menu.MenuApi
{
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class MenuText
    {
        internal MenuText(QMNestedButton menuBase, float posx, float posy, string text)
        {
            menuTitle = Object.Instantiate(QuickMenuTools.QuickMenuInstance.transform.Find("ShortcutMenu/EarlyAccessText").gameObject, menuBase.GetBackButton().transform.parent);
            Init(menuTitle, posx, posy, text);
        }

        internal MenuText(string MenuName, float posx, float posy, string text)
        {
            menuTitle = Object.Instantiate(QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/EarlyAccessText").gameObject, QuickMenuUtils.QuickMenu.transform.Find(MenuName));
            Init(menuTitle, posx, posy, text);
        }

        internal MenuText(Transform parent, float posx, float posy, string text)
        {
            menuTitle = Object.Instantiate(QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/EarlyAccessText").gameObject, parent);
            Init(menuTitle, posx, posy, text);
        }

        internal MenuText(Transform parent, float posx, float posy, string text, int size)
        {
            menuTitle = Object.Instantiate(QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/EarlyAccessText").gameObject, parent);
            Init(menuTitle, posx, posy, text, size);
        }

        internal void Init(GameObject menuTitle, float posx, float posy, string text, int size = 0)
        {
            menuTitle.name = text;
            menuTitle.GetComponent<Text>().fontStyle = FontStyle.Normal;
            menuTitle.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            menuTitle.GetComponent<Text>().text = text;
            if (size != 0)
            {
                menuTitle.GetComponent<Text>().fontSize = size;
            }
            menuTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, -posy);
            menuTitle.GetComponent<Text>().color = Color.white;
            Posx = posx;
            Posy = -posy;
            Text = text;
            menuTitle.name = $"MenuText_{text}_{posx}_{-Posy}";
        }

        internal GameObject menuTitle;

        internal float Posx;

        internal float Posy;

        internal string Text;

        internal void Setactive(bool value)
        {
            menuTitle.SetActive(value);
        }

        internal void Delete()
        {
            Object.Destroy(menuTitle);
        }

        internal void SetText(string text)
        {
            menuTitle.GetComponent<Text>().text = text;
        }

        internal void SetPos(float x, float y)
        {
            Posy = y;
            Posx = x;
            menuTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(Posx, -Posy);
        }

        internal void SetColor(float r, float g, float b, float a)
        {
            menuTitle.GetComponent<Text>().color = new Color(r, g, b, a);
        }

        internal void SetColor(Color color)
        {
            menuTitle.GetComponent<Text>().color = color;
        }

        internal void SetFontSize(int size)
        {
            menuTitle.GetComponent<Text>().fontSize = size;
        }
    }
}