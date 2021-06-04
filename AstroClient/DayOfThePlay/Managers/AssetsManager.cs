namespace DayClientML2.Managers
{
	using AstroLibrary.Console;
	using System;
	using System.Collections;
	using System.Linq;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using UnityEngine.Networking;

	internal class AssetsManager
    {
        private static AssetBundle assetBundle;

        public static IEnumerator LoadAssetBundle(string path = null, string url = null)
        {
            if (path != null)
            {
                ModConsole.Log("Loading assets from File. . . \n" + path);
                AssetBundleCreateRequest dlBundle = AssetBundle.LoadFromFileAsync(path);
                while (!dlBundle.isDone)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                assetBundle = dlBundle.assetBundle;
            }
            if (url != null)
            {
                ModConsole.Log("Loading assets from url. . . \n" + url);
                UnityWebRequest assetBundleRequest;
                assetBundleRequest = UnityWebRequest.Get(url);

                assetBundleRequest.SendWebRequest();
                while (!assetBundleRequest.isDone)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                AssetBundleCreateRequest dlBundle = AssetBundle.LoadFromMemoryAsync(assetBundleRequest.downloadHandler.data);
                while (!dlBundle.isDone)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                assetBundle = dlBundle.assetBundle;
            }
            foreach (var item in assetBundle.AllAssetNames().ToArray())
            {
                Console.WriteLine($"[{assetBundle.name}] Asset: {item}");
            }
            yield break;
        }

        public static Sprite LoadSprite(string sprite)
        {
            try
            {
                Sprite sprite2 = assetBundle.LoadAsset(sprite, Il2CppType.Of<Sprite>()).Cast<Sprite>();
                sprite2.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                return sprite2;
            }
            catch (Exception e)
            {
                ModConsole.Error("ERROR LOADING SPRITE: " + e.Message);
                throw;
            }
        }

        public static GameObject LoadGameobject(string gameobject)
        {
            try
            {
                GameObject @object = assetBundle.LoadAsset(gameobject, Il2CppType.Of<GameObject>()).Cast<GameObject>();
                @object.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                return @object;
            }
            catch (Exception e)
            {
                ModConsole.Error("ERROR LOADING GAME OBJECT: " + e.Message);
                throw;
            }
        }

        public static AudioClip LoadAudioClip(string Audio)
        {
            try
            {
                AudioClip Audioclip = assetBundle.LoadAsset(Audio, Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                Audioclip.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                return Audioclip;
            }
            catch (Exception e)
            {
                ModConsole.Error("ERROR LOADING AUDIO CLIP: " + e.Message);
                throw;
            }
        }

        public static Sprite LoadSprite2(string url)
        {
            WWW www = new WWW(url, null, new Il2CppSystem.Collections.Generic.Dictionary<string, string>());
            Sprite sprite = Sprite.CreateSprite(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            return sprite;
        }
    }
}