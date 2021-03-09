using AstroClient.ConsoleUtils;
using DayClientML2.Utility.Extensions;
using RubyButtonAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.SDKBase;

namespace DayClientML2.Utility
{
    static class MiscUtility
    {
        public static Vector2 GetButtonPosition(float x, float y)
        {
            return new Vector2(-1050f + x * 420f, 1570 + y * -420f);
        }
        public static Vector2 GetButtonPosition2(float x, float y)
        {
            var quickMenu = Utils.QuickMenu;
            float X = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            float Y = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            return new Vector2(X * x, Y * y);
        }
        public static bool IsNaN(Vector3 v3)
        {
            return float.IsNaN(v3.x) || float.IsNaN(v3.y) || float.IsNaN(v3.z);
        }
        public static bool IsRetardedPos(Vector3 v3)
        {
            return int.MaxValue < v3.x || int.MaxValue < v3.y || int.MaxValue < v3.z || int.MinValue > v3.x || int.MinValue > v3.y || int.MinValue > v3.z;
        }
        public static void RotateButton(QMSingleButton button, float rotation)
        {
            button.getGameObject().transform.Rotate(new Vector3(0f, 0f, rotation));
        }
        public static void SetButtonToArrow(QMSingleButton button)
        {
            button.getGameObject().GetComponent<Image>().sprite = Utils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponent<Image>().sprite;
        }

        public static IEnumerator DestroyDelayed(float seconds, UnityEngine.Object obj)
        {
            yield return new WaitForSeconds(seconds);
            UnityEngine.Object.Destroy(obj);
            yield break;
        }
        public static GameObject[] FindMultiples(string name)
        {
            return Resources.FindObjectsOfTypeAll<GameObject>().Where(m => m.name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 || name.IndexOf(m.name, StringComparison.OrdinalIgnoreCase) >= 0).ToArray();
        }
        public static void SetPosition(Transform transform, float x_pos, float y_pos)
        {
            var quickMenu = Utils.QuickMenu;
            float X = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            float Y = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            transform.transform.localPosition = new Vector3(X * x_pos, Y * y_pos);
        }

        public static void SetSizeButtonfor(GameObject Button, float xSize, float ySize)
        {
            Button.GetComponent<RectTransform>().sizeDelta /= new Vector2(xSize, ySize);
        }

        public static float GetDistandBetweenObjects(GameObject Base, GameObject target)
        {
            Vector3 positionbase = Base.transform.position;
            Vector3 positiontarget = target.transform.position;
            return Vector3.Distance(positionbase, positiontarget);
        }
        public static bool TakeOwnershipIfNecessary(GameObject gameObject)
        {
            if (getOwnerOfGameObject(gameObject) != Utils.CurrentUser.field_Private_Player_0)
                Networking.SetOwner(Utils.CurrentUser.field_Private_VRCPlayerApi_0, gameObject);
            return getOwnerOfGameObject(gameObject) != Utils.CurrentUser.field_Private_Player_0;
        }

        public static Player getOwnerOfGameObject(GameObject gameObject)
        {
            foreach (Player player in Utils.PlayerManager.AllPlayers())
            {
                if (player.field_Private_VRCPlayerApi_0.IsOwner(gameObject))
                    return player;
            }
            return null;
        }
        public static string GetPath(GameObject obj)
        {
            string text = "/" + obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                text = "/" + obj.name + text;
            }
            return text;
        }
        internal static void LoadSprite(Image Instance, string url)
        {
            MelonLoader.MelonCoroutines.Start(LoadSpriteEnum(Instance, url));
        }
        private static IEnumerator LoadSpriteEnum(Image Instance, string url)
        {
            while (VRCPlayer.field_Internal_Static_VRCPlayer_0 != true) yield return null;
            var Sprite = new Sprite();
            WWW www = new WWW(url);
            yield return www;
            {
                Sprite = Sprite.CreateSprite(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            }
            Instance.sprite = Sprite;
            Instance.color = Color.white;
            yield break;
        }
        public static int Reverse(this int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }
        internal static IEnumerator LoadAudioAndPlayIt(string url)
        {
            var AudioClip = new AudioClip();
            WWW www = new WWW(url);
            ModConsole.Log("[Debug] Getting File. . .");
            yield return www;
            {
                AudioClip = www.GetAudioClip();
                ModConsole.Log("[Debug] Got File!");
            }
            ModConsole.Log("[Debug] Creating Source!");
            var source = CreateAudioSource(AudioClip, Utils.CurrentUser.gameObject);
            ModConsole.Log("[Debug] Playing Source!");
            source.Play();
            ModConsole.Log("[Debug] Deleting Source!");
            UnityEngine.Object.Destroy(source, AudioClip.length);
            yield break;
        }
        public static List<GameObject> GetWorldPrefabs()
        {
            return VRC_SceneDescriptor.Instance.DynamicPrefabs.ToArray().ToList();
        }
        public static readonly List<string> EmojiType = new List<string>
        {
            ":D",
            "Like",
            "Heart",
            "D:",
            "Dislike",
            "!!!",
            "xD",
            "=O",
            "???",
            ":*",
            "*-*",
            ">:{",
            "=|",
            "^P",
            "O_O",
            "=.=",
            "Fire",
            "M-moneys",
            "</3",
            "Present",
            "Beer",
            "Tomato",
            "Zzz...",
            "Thinking...",
            "Pizza",
            "Sunglasses",
            "Music Note",
            "GO!",
            "Wave",
            "Stop",
            "Clouds",
            "Pumpkin",
            "Spooky Ghost",
            "Skull",
            "Sweet-Candy",
            "Candy-Corn",
            "Boo!!",
            "Scary-bats",
            "Spider-Web",
            "",
            "Mistletoe",
            "Snowball",
            "Snowflake",
            "Coal",
            "Candy Cane",
            "Gingerbread",
            "Confetti",
            "Champagne",
            "Presents",
            "Beach-Ball",
            "Drink",
            "Hang Ten",
            "Ice Cream",
            "Life Ring",
            "Neon Shades",
            "Pineapple",
            "Splash",
            "Sun Lotion"
        };

        // They changed it, there's an empty emote now. So clap would display as wave, point as clap, etc.  - Love
        public static readonly List<string> EmoteType = new List<string>
        {
            "",
            "wave",
            "clap",
            "point",
            "cheer",
            "dance",
            "backflip",
            "die",
            "sadness",
        };

        public static bool IsGrabifyLink(string url)
        {
            List<string> Domains = new List<string>()
            {
                "grabify.link",
                "leancoding.co",
                "stopify.co",
                "freegiftcards.co",
                "joinmy.site",
                "curiouscat.club",
                "catsnthings.fun",
                "catsnthing.com"
            };
            foreach (var domain in Domains) if (url.ToLower().Contains(domain.ToLower())) return true;
            return false;
        }

        public static string RandomString(int length)
        {
            var chars = "abcdefghlijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789`?\\=)(/{][}&%$§!".ToArray();
            string returnstring = "";
            System.Random random = new System.Random(new System.Random().Next(length));
            for (int i = 0; i < length; i++)
                returnstring += chars[random.Next(chars.Length)];
            return returnstring;
        }
        public static string RandomNumberString(int length)
        {
            string nonce = "";
            for (int i = 0; i < length; i++)
            {
                nonce += new System.Random().Next(0, int.MaxValue).ToString("X8");
            }
            return nonce;
        }
        public static  AudioSource CreateAudioSource(AudioClip clip, GameObject parent)
        {
            AudioSource audioSource = parent.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.spatialize = false;
            audioSource.volume = 1f;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = VRCAudioManager.field_Private_Static_VRCAudioManager_0.field_Public_AudioMixerGroup_0;
            return audioSource;
        }
        public static void DelayFunction(float del, Action action)
        {
            MelonLoader.MelonCoroutines.Start(Delay(del, action));
        }
        private static IEnumerator Delay(float del, Action action)
        {
            yield return new WaitForSeconds(del);
            action.Invoke();
            yield break;
        }

        public class Serialization
        {
            public static byte[] ToByteArray(Il2CppSystem.Object obj)
            {
                if (obj == null) return null;
                var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var ms = new Il2CppSystem.IO.MemoryStream();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
            public static byte[] ToByteArray(object obj)
            {
                if (obj == null) return null;
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var ms = new System.IO.MemoryStream();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }

            public static T FromByteArray<T>(byte[] data)
            {
                if (data == null) return default(T);
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream(data))
                {
                    object obj = bf.Deserialize(ms);
                    return (T)obj;
                }
            }
            public static T IL2CPPFromByteArray<T>(byte[] data)
            {
                if (data == null) return default(T);
                var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var ms = new Il2CppSystem.IO.MemoryStream(data);
                 object obj = bf.Deserialize(ms);
                return (T)obj;
            }

            public static T FromIL2CPPToManaged<T>(Il2CppSystem.Object obj)
            {
                return FromByteArray<T>(ToByteArray(obj));
            }
            public static T FromManagedToIL2CPP<T>(object obj)
            {
                return IL2CPPFromByteArray<T>(ToByteArray(obj));
            }
        }
    }
}


