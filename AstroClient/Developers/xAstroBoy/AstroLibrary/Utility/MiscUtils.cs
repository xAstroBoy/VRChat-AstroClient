// Credits to Blaze and DayOfThePlay

namespace AstroClient.xAstroBoy.Utility
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using MelonLoader;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;
    using VRC.UI;

    public static class MiscUtils
    {
        public static void CleanRoom()
        {
            GameObject gameObject = (from x in UnityEngine.Object.FindObjectsOfType<GameObject>()
                                     where x.name == "DrawingManager"
                                     select x).First();
            Networking.RPC(0, gameObject, "CleanRoomRPC", null);
        }

        public static void ForceQuit()
        {
            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch { }

            try
            {
                Environment.Exit(0);
            }
            catch { }

            try
            {
                Application.Quit();
            }
            catch { }
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

        public static void DelayFunction(float del, Action action)
        {
            if (action == null)
            {
                ModConsole.Error("DelayFunction: action was null");
                return;
            }
            MelonCoroutines.Start(Delay(del, action));
        }
        public static void ActionAsCoroutine(Action action)
        {
            if (action == null)
            {
                ModConsole.Error("ActionAsCoroutine: action was null");
                return;
            }
            MelonCoroutines.Start(Action(action));
        }

        private static IEnumerator Action( Action action) {
            action.Invoke();
            yield break;
        }


        private static IEnumerator Delay(float del, Action action)
        {
            yield return new WaitForSeconds(del);
            action.Invoke();
            yield break;
        }

        public static void WaitForWorld(Action action)
        {
            MelonCoroutines.Start(WFW(action));
        }

        public static IEnumerator WFW(Action action)
        {
            while (!WorldUtils.IsInWorld && PlayerUtils.GetVRCPlayer() == null) yield return null;
            action.Invoke();
            yield break;
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

        public static void ChangeAvatar(this ApiAvatar instance)
        {
            try
            {
                ChangeAvatar(instance.id);
            }
            catch { ModConsole.Error("Error turning into avatar! Maybe it's non existing?"); }
        }

        public static void ChangeAvatar(this Player instance)
        {
            try
            {
                ChangeAvatar((string)instance.prop_ApiAvatar_0.id);
            }
            catch { ModConsole.Error("Error turning into avatar! Maybe it's non existing?"); }
        }

        public static void ChangeAvatar(this VRCPlayer instance)
        {
            try
            {
                ChangeAvatar((string)instance.prop_ApiAvatar_0.id);
            }
            catch { ModConsole.Error("Error turning into avatar! Maybe it's non existing?"); }
        }

        public static void ChangeAvatar(string id)
        {
            try
            {
                PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
                component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                {
                    id = id
                };
                component.ChangeToSelectedAvatar();
            }
            catch { ModConsole.Error("Error turning into avatar! Maybe it's non existing?"); }
        }

        public static Player GetPlayerByUserId(string userId)
        {
            foreach (var player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
                if (player.prop_APIUser_0 != null && player.prop_APIUser_0.id == userId)
                    return player;
            return null;
        }

        private static AssetBundle BlazeBundle;
        public static Sprite NP1;
        public static Sprite NP2;
        public static Sprite Logo;
        public static Sprite MediaBack;
        public static Sprite MediaPause;
        public static Sprite MediaNext;
        public static Sprite MediaMute;

        public static void LoadBundle()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Blaze.Resources.blaze")) //String is MainNamespace.assetbundlename
            using (var tempStream = new MemoryStream((int)stream.Length))
            {
                stream.CopyTo(tempStream);

                BlazeBundle = AssetBundle.LoadFromMemory_Internal(tempStream.ToArray(), 0);
                BlazeBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            }

            NP1 = BlazeBundle.LoadAsset_Internal("Assets/Blaze/NameplateTex.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            NP1.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            NP2 = BlazeBundle.LoadAsset_Internal("Assets/Blaze/iconPlate.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            NP2.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            Logo = BlazeBundle.LoadAsset_Internal("Assets/Blaze/logo.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            Logo.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            MediaBack = BlazeBundle.LoadAsset_Internal("Assets/Blaze/back.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            MediaBack.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            MediaMute = BlazeBundle.LoadAsset_Internal("Assets/Blaze/mute.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            MediaMute.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            MediaNext = BlazeBundle.LoadAsset_Internal("Assets/Blaze/next.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            MediaNext.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            MediaPause = BlazeBundle.LoadAsset_Internal("Assets/Blaze/pause.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            MediaPause.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        }

        public static void DropPortal(string RoomId)
        {
            string[] Location = RoomId.Split(':');
            DropPortal(Location[0], Location[1], 0,
                GameInstances.CurrentUser.transform.position + (GameInstances.CurrentUser.transform.forward * 2f),
                GameInstances.CurrentUser.transform.rotation);
        }

        public static void DropPortal(string WorldID, string InstanceID, int players, Vector3 vector3,
            Quaternion quaternion)
        {
            GameObject gameObject = Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always,
                "Portals/PortalInternalDynamic", vector3, quaternion);
            string world = WorldID;
            string instance = InstanceID;
            int count = players;
            Networking.RPC(RPC.Destination.AllBufferOne, gameObject, "ConfigurePortal", new Il2CppSystem.Object[]
            {
                (Il2CppSystem.String) world,
                (Il2CppSystem.String) instance,
                new Il2CppSystem.Int32
                {
                    m_value = count
                }.BoxIl2CppObject()
            });
            // MelonCoroutines.Start(MiscUtility.DestroyDelayed(1f, gameObject.GetComponent<PortalInternal>()));
        }

        public static void CopyToClipboard(string copytext)
        {
            TextEditor textEditor = new TextEditor
            {
                text = copytext
            };
            textEditor.SelectAll();
            textEditor.Copy();
            PopupUtils.QueHudMessage("Copied to Clipboard");
        }
    }
}
