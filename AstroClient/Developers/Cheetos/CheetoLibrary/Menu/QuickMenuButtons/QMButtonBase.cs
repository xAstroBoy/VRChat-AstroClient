namespace AstroButtonAPI
{
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;

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

        public void ClickMe()
        {
            button.GetComponent<Button>().onClick.Invoke();
        }

        public void SetImage(Sprite image)
        {
            button.GetComponent<Image>().sprite = image;
        }

        public async void SetImage(string URL)
        {
            await GetRemoteTexture(button.GetComponent<Image>(), URL);
        }

        private async Task<Texture2D> GetRemoteTexture(Image Instance, string url)
        {
            var www = UnityWebRequestTexture.GetTexture(url);
            var asyncOp = www.SendWebRequest();
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            if (www.isNetworkError || www.isHttpError)
            {
                return null;
            }
            else
            {
                var Sprite = new Sprite();
                Sprite = Sprite.CreateSprite(DownloadHandlerTexture.GetContent(www), new Rect(0, 0, DownloadHandlerTexture.GetContent(www).width, DownloadHandlerTexture.GetContent(www).height), Vector2.zero, 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
                Instance.sprite = Sprite;
                Instance.color = Color.white;
                return DownloadHandlerTexture.GetContent(www);
            }
        }

        public void SetShader(string shaderName)
        {
            var Material = new Material(button.GetComponent<Image>().material)
            {
                shader = Shader.Find(shaderName)
            };
            button.gameObject.GetComponent<Image>().material = Material;
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