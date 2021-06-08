namespace RubyButtonAPI
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.UI;
	using Button = UnityEngine.UI.Button;

	public class QMButtonBase
    {
        protected GameObject button;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;
        protected Color OrigText;

        public GameObject GetGameObject()
        {
            return button;
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
                SetTextColor(OrigText, false);
            }
            else
            {
                SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1), false);
                SetTextColor(new Color(0.7f, 0.7f, 0.7f, 1), false); ;
            }
            button.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        public void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (buttonXLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));

            btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
        }

        public void SetRawLocation(float buttonXLoc, float buttonYLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition = QuickMenuStuff.SingleButtonTemplate().GetComponent<RectTransform>().anchoredPosition + (Vector2.right * (420 * (buttonXLoc + initShift[0])));
            button.GetComponent<RectTransform>().anchoredPosition = QuickMenuStuff.SingleButtonTemplate().GetComponent<RectTransform>().anchoredPosition + (Vector2.down * (420 * (buttonYLoc + initShift[1])));

            btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
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

        public void LoadSprite(string url)
        {
            MelonLoader.MelonCoroutines.Start(LoadSprite(button.GetComponent<Image>(), url));
        }

        private static IEnumerator LoadSprite(Image Instance, string url)
        {
            while (VRCPlayer.field_Internal_Static_VRCPlayer_0 != true) yield return null;
            WWW www = new WWW(url, null, new Il2CppSystem.Collections.Generic.Dictionary<string, string>());
            yield return www;
            Sprite sprite;
            {
                sprite = Sprite.CreateSprite(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            }
            Instance.sprite = sprite;
            Instance.color = Color.white;
            yield break;
        }

        public void SetParent(QMNestedButton Parent)
        {
            button.transform.SetParent(QuickMenuStuff.GetQuickMenuInstance().transform.Find(Parent.GetMenuName()));
        }

        public void SetParent(Transform Parent)
        {
            button.transform.SetParent(Parent);
        }

        public void SetResizeTextForBestFit(bool resizeTextForBestFit)
        {
            button.gameObject.GetComponentInChildren<Text>().resizeTextForBestFit = resizeTextForBestFit;
        }

        public virtual void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
        }

        public virtual void SetTextColor(Color buttonTextColor, bool save = true)
        {
        }

        public virtual void SetTextColorOn(Color buttonTextColorOn, bool save = true)
        {
        }

        public virtual void SetTextColorOff(Color buttonTextColorOff, bool save = true)
        {
        }
    }
}