namespace AstroButtonAPI
{
    using Blaze.API;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;

    public class QMImage
    {
        protected GameObject ImageObject;
        protected RawImage Image;

        public QMImage(QMNestedButton QMNB, float LocX, float LocY, float SizeX, float SizeY, string ImageURL)
        {
            Initialize(QuickMenuStuff.GetQuickMenuInstance().transform.Find(QMNB.GetMenuName()), LocX, LocY, SizeX, SizeY, ImageURL);
        }

        public QMImage(Transform location, float LocX, float LocY, float SizeX, float SizeY, string ImageURL)
        {
            Initialize(location, LocX, LocY, SizeX, SizeY, ImageURL);
        }

        private void Initialize(Transform location, float LocX, float LocY, float SizeX, float SizeY, string ImageURL)
        {
            ImageObject = UnityEngine.Object.Instantiate(QuickMenuStuff.GetImageInstance(), location);
            ImageObject.name = $"QMImage";

            SetSize(new Vector2(SizeX, SizeY));
            SetLocation(new Vector3(LocX, LocY, 1));
            SetImage(ImageURL);
            BlazesAPIs.allImages.Add(this);
        }

        public void SetSize(Vector2 size)
        {
            ImageObject.GetComponent<RectTransform>().sizeDelta = size;
        }

        public void SetLocation(Vector3 location)
        {
            ImageObject.GetComponent<RectTransform>().anchoredPosition = location;
        }

        public async void SetImage(string url)
        {
            await GetRemoteTexture(Image, url);
        }

        private static async Task<Texture2D> GetRemoteTexture(RawImage Instance, string url)
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
                Instance.texture = DownloadHandlerTexture.GetContent(www);
                Instance.color = Color.white;
                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }
}
