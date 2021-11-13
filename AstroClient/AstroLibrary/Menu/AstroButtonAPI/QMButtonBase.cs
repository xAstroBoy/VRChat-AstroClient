namespace AstroButtonAPI
{
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;
    using Button = UnityEngine.UI.Button;

    internal class QMButtonBase
    {
        protected GameObject button;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;
        protected Color OrigText;

        internal GameObject GetGameObject()
        {
            return button;
        }

        internal void SetActive(bool isActive)
        {
            button.gameObject.SetActive(isActive);
        }

        internal void SetIntractable(bool isIntractable)
        {
            if (isIntractable)
            {
                SetBackgroundColor(OrigBackground);
                SetTextColor(OrigText);
            }
            else
            {
                SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1));
                SetTextColor(new Color(0.7f, 0.7f, 0.7f, 1)); ;
            }
            button.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        internal void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            // This zeroifies the position.
            button.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplatePos;

            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * buttonXLoc);
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * buttonYLoc);

            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * (buttonXLoc + initShift[0]));
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * (buttonYLoc + initShift[1]));
            //btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            //button.name = btnQMLoc + "/" + btnType + btnTag;
            //button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void SetRawLocation(float buttonXLoc, float buttonYLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplate.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * (420 * (buttonXLoc + initShift[0])));
            button.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplate.GetComponent<RectTransform>().anchoredPosition + (Vector2.down * (420 * (buttonYLoc + initShift[1])));

            //btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            //button.name = btnQMLoc + "/" + btnType + btnTag;
            //button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void SetToolTip(string buttonToolTip)
        {
            button.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true).field_Public_String_0 = buttonToolTip;
            //button.GetComponentInChildren<UiTooltip>().field_Public_String_1 = buttonToolTip;
        }

        internal void DestroyMe()
        {
            try
            {
                UnityEngine.Object.Destroy(button);
            }
            catch { }
        }

        internal void ClickMe()
        {
            button.GetComponent<Button>().onClick.Invoke();
        }

        internal void SetImage(Sprite image)
        {
            button.GetComponent<Image>().overrideSprite = image;
        }

        internal async void SetImage(string URL)
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

        internal void SetShader(string shaderName)
        {
            var Material = new Material(button.GetComponent<Image>().material)
            {
                shader = Shader.Find(shaderName)
            };
            button.gameObject.GetComponent<Image>().material = Material;
        }

        internal void SetParent(QMNestedButton Parent)
        {
            button.transform.SetParent(QuickMenuTools.QuickMenuInstance.transform.Find(Parent.GetMenuName()));
        }

        internal void SetParent(Transform Parent)
        {
            button.transform.SetParent(Parent);
        }

        internal virtual void SetBackgroundColor(Color buttonBackgroundColor)
        {
        }

        internal virtual void SetTextColor(Color buttonTextColor)
        {
        }

        internal virtual void SetTextColorOn(Color buttonTextColorOn)
        {
        }

        internal virtual void SetTextColorOff(Color buttonTextColorOff)
        {
        }
    }
}