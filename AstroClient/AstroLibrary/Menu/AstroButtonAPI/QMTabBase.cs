namespace AstroButtonAPI
{
    using AstroClient.AstroLibrary.Menu.AstroButtonAPI;
    using CheetoLibrary;
    using UnityEngine;
    using UnityEngine.UI;

    internal class QMTabBase
    {
        protected GameObject button;
        protected GameObject Icon;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;

        internal GameObject GetGameObject()
        {
            return button;
        }

        internal GameObject GetIcon()
        {
            if (Icon == null)
                Icon = button.transform.Find("Icon").gameObject;
            return Icon;
        }

        internal void SetActive(bool isActive)
        {
            button.gameObject.SetActive(isActive);
        }

        internal void SetIntractable(bool isIntractable)
        {
            if (isIntractable)
            {
                SetBackgroundColor(OrigBackground, false);
            }
            else
            {
                SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1), false);
            }
            button.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        internal void SetLocation(float buttonXLoc)
        {
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (210 * (buttonXLoc + initShift[0]));
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));
            button.transform.SetSiblingIndex((int)buttonXLoc);
            btnTag = "(" + buttonXLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void SetToolTip(string buttonToolTip)
        {
            button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;
            button.GetComponent<UiTooltip>().field_Public_String_1 = buttonToolTip;
        }

        internal void DestroyMe()
        {
            try
            {
                UnityEngine.Object.Destroy(button);
            }
            catch { }
        }

        internal void LoadSprite(string path)
        {
            var image = GetIcon().GetComponent<Image>();
            var texture = CheetoUtils.LoadPNG(path);
            image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image.color = Color.white;
        }

        internal void LoadSprite(byte[] data)
        {
            var image = GetIcon().GetComponent<Image>();
            var texture = CheetoUtils.LoadPNG(data);
            image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image.color = Color.white;
        }

        internal void SetParent(QMNestedButton Parent)
        {
            button.transform.SetParent(QuickMenuStuff.GetQuickMenuInstance().transform.Find(Parent.GetMenuName()));
        }

        internal void SetParent(Transform Parent)
        {
            button.transform.SetParent(Parent);
        }

        internal virtual void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
        }
    }
}