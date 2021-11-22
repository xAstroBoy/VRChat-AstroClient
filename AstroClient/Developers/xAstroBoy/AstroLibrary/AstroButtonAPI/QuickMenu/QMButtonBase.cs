namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenu
{
    using System.Threading.Tasks;
    using Tools;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;
    using VRC.UI.Elements.Tooltips;

    internal class QMButtonBase
    {
        protected string btnQMLoc;
        protected string btnTag;
        protected string btnType;
        protected GameObject button;
        protected int[] initShift = { 0, 0 };


        internal GameObject GetGameObject()
        {
            return button;
        }

        internal void SetActive(bool isActive)
        {
            button.gameObject.SetActive(isActive);
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
            button.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplate.GetComponent<RectTransform>().anchoredPosition + Vector2.right * (420 * (buttonXLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplate.GetComponent<RectTransform>().anchoredPosition + Vector2.down * (420 * (buttonYLoc + initShift[1]));

            //btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            //button.name = btnQMLoc + "/" + btnType + btnTag;
            //button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void SetToolTip(string buttonToolTip)
        {
            var tooltip = button.GetComponentInChildren<UiTooltip>(true);
            if (tooltip != null)
            {
                tooltip.field_Public_String_0 = buttonToolTip;
                //button.GetComponentInChildren<UiTooltip>().field_Public_String_1 = buttonToolTip;
            }
        }

        internal void SetIntractable(bool isIntractable)
        {
            button.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        internal void DestroyMe()
        {
            try
            {
                Object.Destroy(button);
            }
            catch
            {
            }
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
                await Task.Delay(1000 / 30); //30 hertz

            if (www.isNetworkError || www.isHttpError)
            {
                return null;
            }

            var Sprite = new Sprite();
            Sprite = Sprite.CreateSprite(DownloadHandlerTexture.GetContent(www), new Rect(0, 0, DownloadHandlerTexture.GetContent(www).width, DownloadHandlerTexture.GetContent(www).height), Vector2.zero, 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            Instance.sprite = Sprite;
            Instance.color = Color.white;
            return DownloadHandlerTexture.GetContent(www);
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