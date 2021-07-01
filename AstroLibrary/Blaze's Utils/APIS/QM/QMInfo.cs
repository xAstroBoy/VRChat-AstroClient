using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Blaze.API
{
    public class QMInfo
    {
        public GameObject InfoObject;
        public Text InfoText;
        public GameObject InfoIconObject;

        public QMInfo(Transform location, float PosX, float PosY, float SizeX, float SizeY, string Text, bool? ShowInfoIcon = false)
        {
            Initialize(location, PosX, PosY, SizeX, SizeY, Text, ShowInfoIcon);
        }

        public QMInfo(QMNestedButton QMNB, float PosX, float PosY, float SizeX, float SizeY, string Text, bool? ShowInfoIcon = false)
        {
            Initialize(QMStuff.GetQuickMenuInstance().transform.Find(QMNB.getMenuName()), PosX, PosY, SizeX, SizeY, Text, ShowInfoIcon);
        }

        private void Initialize(Transform location, float PosX, float PosY, float SizeX, float SizeY, string Text, bool? ShowInfoIcon = false)
        {
            InfoObject = UnityEngine.Object.Instantiate(QMStuff.GetQuickMenuInstance().transform.Find("EmoteMenu/ActionMenuInfo2").gameObject, location);
            InfoObject.name = $"{BlazesAPIs.Identifier}-QMInfo";
            InfoText = InfoObject.GetComponentInChildren<Text>();
            InfoIconObject = InfoObject.transform.Find("InfoIcon").gameObject;
            SetSize(new Vector2(SizeX, SizeY));
            SetLocation(new Vector3(PosX, PosY, 1));
            SetText(Text);
            ToggleInfoIcon((bool)ShowInfoIcon);
        }

        public void SetSize(Vector2 size)
        {
            InfoObject.GetComponent<RectTransform>().sizeDelta = size;
            InfoObject.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = new Vector2(-100, size.y - 50);
        }

        public void SetLocation(Vector3 location)
        {
            InfoObject.GetComponent<RectTransform>().anchoredPosition = location;
        }

        public void SetText(string text)
        {
            InfoText.text = text;
        }

        public void ToggleInfoIcon(bool state)
        {
            InfoIconObject.SetActive(state);
        }

        public void ToggleBackground(bool state)
        {
            InfoObject.GetComponent<Image>().enabled = state;
        }

        public async void SetBackground(string URL)
        {
            await GetRemoteTexture(InfoObject.GetComponent<Image>(), URL);
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
    }
}
