namespace AstroButtonAPI
{
    using CheetoLibrary;
    using UnityEngine;
    using UnityEngine.UI;

    public class QMTabBase
    {
        protected GameObject button;
        protected GameObject Icon;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;

        public GameObject GetGameObject()
        {
            return button;
        }

        public GameObject GetIcon()
        {
            if (Icon == null)
                Icon = button.transform.Find("Icon").gameObject;
            return Icon;
        }

        public void SetActive(bool isActive)
        {
            button.gameObject.SetActive(isActive);
        }

        public void SetIntractable(bool isIntractable)
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

        public void SetLocation(float buttonXLoc)
        {
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (210 * (buttonXLoc + initShift[0]));
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));
            button.transform.SetSiblingIndex((int)buttonXLoc);
            btnTag = "(" + buttonXLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
        }

        public void SetToolTip(string buttonToolTip)
        {
            button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;
            button.GetComponent<UiTooltip>().field_Public_String_1 = buttonToolTip;
        }

        public void DestroyMe()
        {
            try
            {
                UnityEngine.Object.Destroy(button);
            }
            catch { }
        }

        public void LoadSprite(string path)
        {
            var image = GetIcon().GetComponent<Image>();
            var texture = CheetoUtils.LoadPNG(path);
            image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image.color = Color.white;
        }

        public void LoadSprite(byte[] data)
        {
            var image = GetIcon().GetComponent<Image>();
            var texture = CheetoUtils.LoadPNG(data);
            image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image.color = Color.white;
        }

        public void SetParent(QMNestedButton Parent)
        {
            button.transform.SetParent(QuickMenuStuff.GetQuickMenuInstance().transform.Find(Parent.GetMenuName()));
        }

        public void SetParent(Transform Parent)
        {
            button.transform.SetParent(Parent);
        }

        public virtual void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
        }
    }
}