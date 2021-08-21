namespace Blaze.Utils
{
	using System.Threading.Tasks;
	using UnityEngine;
	using UnityEngine.Networking;
	using UnityEngine.UI;
	using VRC;

	public static class QuickMenuUtils
    {
        public static QuickMenu GetQuickMenu()
        {
            return QuickMenu.prop_QuickMenu_0;
        }

        public static void SelectPlayer(Player instance)
        {
            QuickMenu.prop_QuickMenu_0.Method_Public_Void_Player_0(instance);
        }

        public static Player GetUIMPlayer()
        {
            return QuickMenu.prop_QuickMenu_0.field_Private_Player_0;
        }

        public static void OpenQM()
        {
            QuickMenu.prop_QuickMenu_0.Method_Private_Void_Boolean_0(true);
        }

        public static void CloseQM()
        {
            QuickMenu.prop_QuickMenu_0.Method_Private_Void_Boolean_0(false);
        }

        public static void ResizeCollider(Vector3 size)
        {
            QuickMenu.prop_QuickMenu_0.GetComponent<BoxCollider>().size = size;
        }

        public static void ResetCollider()
        {
            QuickMenu.prop_QuickMenu_0.GetComponent<BoxCollider>().size = new Vector3(2517.34f, 1671.213f, 1f);
        }

        //public async static void LoadSprite(Image Instance, string url)
        //{
        //    await GetRemoteTexture(Instance, url);
        //}

        //private static async Task<Texture2D> GetRemoteTexture(Image Instance, string url)
        //{
        //    var www = UnityWebRequestTexture.GetTexture(url);
        //    var asyncOp = www.SendWebRequest();
        //    while (asyncOp.isDone == false)
        //        await Task.Delay(1000 / 30);//30 hertz

        //    if (www.isNetworkError || www.isHttpError)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var Sprite = new Sprite();
        //        Sprite = Sprite.CreateSprite(DownloadHandlerTexture.GetContent(www), new Rect(0, 0, DownloadHandlerTexture.GetContent(www).width, DownloadHandlerTexture.GetContent(www).height), Vector2.zero, 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
        //        Instance.sprite = Sprite;
        //        Instance.color = Color.white;
        //        return DownloadHandlerTexture.GetContent(www);
        //    }
        //}

        //public async static void LoadSprite(Sprite Instance, string url)
        //{
        //    await GetRemoteTexture(Instance, url);
        //}

        //private static async Task<Texture2D> GetRemoteTexture(Sprite Instance, string url)
        //{
        //    var www = UnityWebRequestTexture.GetTexture(url);
        //    var asyncOp = www.SendWebRequest();
        //    while (asyncOp.isDone == false)
        //        await Task.Delay(1000 / 30);//30 hertz

        //    if (www.isNetworkError || www.isHttpError)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        Instance = Sprite.CreateSprite(DownloadHandlerTexture.GetContent(www), new Rect(0, 0, DownloadHandlerTexture.GetContent(www).width, DownloadHandlerTexture.GetContent(www).height), Vector2.zero, 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
        //        return DownloadHandlerTexture.GetContent(www);
        //    }
        //}
    }
}
