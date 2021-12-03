namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using System.Threading.Tasks;
    using Tools;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;
    using VRC.UI.Elements.Tooltips;

    internal class QMButtonBase
    {
        internal GameObject ButtonObject { get; set; }
        internal GameObject QMButtonBase_GetGameObject()
        {
            return ButtonObject;
        }


 
        internal void QMButtonBase_SetLocation(float buttonXLoc, float buttonYLoc)
        {
            // This zeroifies the position.
            ButtonObject.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplatePos;

            ButtonObject.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * buttonXLoc);
            ButtonObject.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * buttonYLoc);

        }



        internal void QMButtonBase_SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
        }


        //internal void SetIntractable(bool isIntractable)
        //{
        //    ButtonObject.gameObject.GetComponent<Button>().interactable = isIntractable;
        //}

        //internal void SetToolTip(string buttonToolTip)
        //{
        //    var tooltip = ButtonObject.GetComponentInChildren<UiTooltip>(true);
        //    if (tooltip != null)
        //    {
        //        tooltip.field_Public_String_0 = buttonToolTip;
        //        //button.GetComponentInChildren<UiTooltip>().field_Public_String_1 = buttonToolTip;
        //    }
        //}

        //internal void ClickMe()
        //{
        //    ButtonObject.GetComponent<Button>().onClick.Invoke();
        //}

        //internal void SetImage(Sprite image)
        //{
        //    ButtonObject.GetComponent<Image>().overrideSprite = image;
        //}

        //internal async void SetImage(string URL)
        //{
        //    await GetRemoteTexture(ButtonObject.GetComponent<Image>(), URL);
        //}

        //private async Task<Texture2D> GetRemoteTexture(Image Instance, string url)
        //{
        //    var www = UnityWebRequestTexture.GetTexture(url);
        //    var asyncOp = www.SendWebRequest();
        //    while (asyncOp.isDone == false)
        //        await Task.Delay(1000 / 30); //30 hertz

        //    if (www.isNetworkError || www.isHttpError)
        //    {
        //        return null;
        //    }

        //    var Sprite = new Sprite();
        //    Sprite = Sprite.CreateSprite(DownloadHandlerTexture.GetContent(www), new Rect(0, 0, DownloadHandlerTexture.GetContent(www).width, DownloadHandlerTexture.GetContent(www).height), Vector2.zero, 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
        //    Instance.sprite = Sprite;
        //    Instance.color = Color.white;
        //    return DownloadHandlerTexture.GetContent(www);
        //}

        //internal void SetShader(string shaderName)
        //{
        //    var Material = new Material(ButtonObject.GetComponent<Image>().material)
        //    {
        //        shader = Shader.Find(shaderName)
        //    };
        //    ButtonObject.gameObject.GetComponent<Image>().material = Material;
        //}

        //internal void SetParent(QMNestedButton Parent)
        //{
        //    ButtonObject.transform.SetParent(QuickMenuTools.QuickMenuInstance.transform.Find(Parent.GetMenuName()));
        //}

        //internal void SetParent(Transform Parent)
        //{
        //    ButtonObject.transform.SetParent(Parent);
        //}
    }
}