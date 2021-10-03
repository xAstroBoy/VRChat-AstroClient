﻿namespace AstroLibrary.Utility
{
    #region Imports

    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroButtonAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC;
    using VRC.SDKBase;

    #endregion

    public static class MiscUtils_Old
    {
        public static Vector2 GetButtonPosition(float x, float y) => new Vector2(-1050f + (x * 420f), 1570 + (y * -420f));

        public static Vector2 GetButtonPosition2(float x, float y)
        {
            var quickMenu = QuickMenuUtils.QuickMenu;
            float X = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            float Y = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            return new Vector2(X * x, Y * y);
        }

        public static VRC_EventHandler FindNearestEventHandler(GameObject target)
        {
            VRC_EventHandler vrc_EventHandler = null;
            if (target != null)
            {
                vrc_EventHandler = target.GetComponent<VRC_EventHandler>();
                if (vrc_EventHandler == null)
                {
                    vrc_EventHandler = target.GetComponentInParent<VRC_EventHandler>();
                }
            }
            if (vrc_EventHandler == null)
            {
                vrc_EventHandler = Networking.SceneEventHandler;
            }
            return vrc_EventHandler;
        }

        public static bool IsNaN(Vector3 v3)
        {
            return float.IsNaN(v3.x) || float.IsNaN(v3.y) || float.IsNaN(v3.z);
        }

        public static bool IsRetardedPos(Vector3 v3)
        {
            return int.MaxValue < v3.x || int.MaxValue < v3.y || int.MaxValue < v3.z || int.MinValue > v3.x || int.MinValue > v3.y || int.MinValue > v3.z;
        }

        public static bool IsWeirdPos(Vector3 v3)
        {
            return short.MaxValue < v3.x || short.MaxValue < v3.y || short.MaxValue < v3.z || short.MinValue > v3.x || short.MinValue > v3.y || short.MinValue > v3.z;
        }

        public static bool IsHMMMPos(Vector3 v3)
        {
            return 5000 < v3.x || 5000 < v3.y || 5000 < v3.z || -5000 > v3.x || -5000 > v3.y || -5000 > v3.z;
        }

        public static bool IsSusPos(Vector3 v3)
        {
            return 3000 < v3.x || 3000 < v3.y || 3000 < v3.z || -3000 > v3.x || -3000 > v3.y || -3000 > v3.z;
        }

        public static bool IsSusVelocity(Vector3 v3)
        {
            return 35 < v3.x || 35 < v3.y || 35 < v3.z || -35 > v3.x || -35 > v3.y || -35 > v3.z;
        }

        public static bool IsHMMMVelocity(Vector3 v3)
        {
            return 100 < v3.x || 100 < v3.y || 100 < v3.z || -100 > v3.x || -100 > v3.y || -100 > v3.z;
        }

        public enum SusLevel
        {
            Sus = 0,
            Hmmm = 1,
            Weird = 2,
            Retarded = 3,
            NaN = 4,
        }

        public static void RotateButton(QMSingleButton button, float rotation)
        {
            button.GetGameObject().transform.Rotate(new Vector3(0f, 0f, rotation));
        }

        public static void SetButtonToArrow(QMSingleButton button, ArrowDirection direction)
        {
            button.GetGameObject().GetComponent<Image>().sprite = QuickMenuUtils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponent<Image>().sprite;
            switch (direction)
            {
                case ArrowDirection.Up:
                    // Dont do anything cus its already up
                    break;

                case ArrowDirection.Down:
                    RotateButton(button, 180);
                    break;

                case ArrowDirection.Left:
                    RotateButton(button, -90);
                    break;

                case ArrowDirection.Right:
                    RotateButton(button, 90);
                    break;
            }
        }

        public enum ArrowDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public static IEnumerator DestroyDelayed(float seconds, UnityEngine.Object obj)
        {
            if (obj==null)
            {
                ModConsole.Error("DestroyDelayed: obj was null!");
                yield break;
            }
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
            var quickMenu = QuickMenuUtils.QuickMenu;
            float X = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            float Y = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            transform.transform.localPosition = new Vector3(X * x_pos, Y * y_pos);
        }

        public static void SetSizeButtonfor(GameObject Button, float xSize, float ySize)
        {
            Button.GetComponent<RectTransform>().sizeDelta /= new Vector2(xSize, ySize);
        }

        public static float GetDistandBetweenObjects(GameObject Base, GameObject target) => Vector3.Distance(Base.transform.position, target.transform.position);

        public static Player GetOwnerOfGameObjectButBetter(GameObject gameObject) => Utils.PlayerManager.AllPlayers().Where(plr => plr.GetVRCPlayerApi().IsOwner(gameObject)).FirstOrDefault();

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

        public static int Reverse(this int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = (result * 10) + (num % 10);
                num /= 10;
            }
            return result;
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

        public static System.Random Random = new System.Random();

        public static AudioSource CreateAudioSource(AudioClip clip, GameObject parent)
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
                if (data == null) return default;
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                using (var ms = new System.IO.MemoryStream(data))
                {
                    return (T)bf.Deserialize(ms);
                }
            }

            public static T IL2CPPFromByteArray<T>(byte[] data)
            {
                if (data == null) return default;
                var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)(object)bf.Deserialize(new Il2CppSystem.IO.MemoryStream(data));
            }

            public static T FromIL2CPPToManaged<T>(Il2CppSystem.Object obj)
            {
                return FromByteArray<T>(ToByteArray(obj));
            }

            public static T FromManagedToIL2CPP<T>(object obj)
            {
                return IL2CPPFromByteArray<T>(ToByteArray(obj));
            }

            public static object[] FromIL2CPPArrayToManagedArray(Il2CppSystem.Object[] obj)
            {
                object[] Parameters = new object[obj.Length];
                for (int i = 0; i < obj.Length; i++)
                    Parameters[i] = FromIL2CPPToManaged<object>(obj[i]);
                return Parameters;
            }

            public static Il2CppSystem.Object[] FromManagedArrayToIL2CPPArray(object[] obj)
            {
                Il2CppSystem.Object[] Parameters = new Il2CppSystem.Object[obj.Length];
                for (int i = 0; i < obj.Length; i++)
                    Parameters[i] = FromManagedToIL2CPP<Il2CppSystem.Object>(obj[i]);
                return Parameters;
            }
        }
    }
}