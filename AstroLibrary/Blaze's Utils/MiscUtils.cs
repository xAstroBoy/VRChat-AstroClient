namespace Blaze.Utils
{
	using MelonLoader;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using VRC;
	using VRC.Core;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRC.UI;

	public static class MiscUtils
    {
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

        public static void Restart()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            if (PlayerUtils.SelfIsInVR())
            {
                psi.FileName = Environment.CurrentDirectory + "\\VRChat.exe";
            }
            else
            {
                psi.FileName = Environment.CurrentDirectory + "\\VRChat.exe";
                psi.Arguments = "--no-vr";
            }
            Process.Start(psi);
            ForceQuit();
        }

        public static void LoginFailed()
        {
            Logs.Msg("Authorization to Blaze's Servers has failed. Please restart and check again!", ConsoleColor.Red);
            Console.ReadKey();
            ForceQuit();
        }

        public static void ClearVRAM()
        {
            var currentAvatars = (from player in PlayerManager.prop_PlayerManager_0.prop_ArrayOf_Player_0 where player != null select player.prop_ApiAvatar_0 into apiAvatar where apiAvatar != null select apiAvatar.assetUrl).ToList();

            var dict = new Dictionary<string, AssetBundleDownload>();
            var abdm = AssetBundleDownloadManager.prop_AssetBundleDownloadManager_0;
            foreach (var key in abdm.field_Private_Dictionary_2_String_AssetBundleDownload_0.Keys)
            {
                dict.Add(key, abdm.field_Private_Dictionary_2_String_AssetBundleDownload_0[key]);
            }
            foreach (var key in dict.Keys)
            {
                var assetBundleDownload = abdm.field_Private_Dictionary_2_String_AssetBundleDownload_0[key];
                if (!abdm.field_Private_Dictionary_2_String_AssetBundleDownload_0[key].field_Public_String_0.Contains("wrld_") && !currentAvatars.Contains(key))
                {
                    abdm.field_Private_Dictionary_2_String_AssetBundleDownload_0.Remove(key);
                    if (assetBundleDownload.field_Private_GameObject_0 != null)
                    {
                        UnityEngine.Object.DestroyImmediate(assetBundleDownload.field_Private_GameObject_0, true);
                    }
                }
            }
            dict.Clear();
            Resources.UnloadUnusedAssets();
            Logs.Debug($"<color=green>[OPTIMIZATION]</color> Cleared VRAM!");
        }

        public static void ChangePedestals()
        {

            PopupUtils.InputPopup("Enter Avatar ID for pedestals", "Change Pedestals", "avtr_XXXXXXXX", delegate (string s) 
            {
                if (WorldUtils.GetSDKType() == "SDK2")
                {
                    var cachedPedestals = UnityEngine.Object.FindObjectsOfType<VRC_AvatarPedestal>();
                    if (cachedPedestals.Count != 0)
                    {
                        foreach (var p in cachedPedestals)
                        {
                            p.blueprintId = s;
                        }
                        Logs.Debug($"<color=red>[EXPLOITS]</color> Changed <color=yellow>{cachedPedestals.Count}</color> pedestals!");
                    }
                    else
                    {
                        PopupUtils.HideCurrentPopUp();
                        PopupUtils.InformationAlert("No Pedestals!", "There are currently no avatar pedestals to be found in this world!");
                    }
                }
                else
                {
                    var cachedPedestals = UnityEngine.Object.FindObjectsOfType<VRCAvatarPedestal>();
                    if (cachedPedestals.Count != 0)
                    {
                        foreach (var p in cachedPedestals)
                        {
                            p.blueprintId = s;
                        }
                        Logs.Debug($"<color=red>[EXPLOITS]</color> Changed <color=yellow>{cachedPedestals.Count}</color> pedestals!");
                    }
                    else
                    {
                        PopupUtils.HideCurrentPopUp();
                        PopupUtils.InformationAlert("No Pedestals!", "There are currently no avatar pedestals to be found in this world!");
                    }
                }
                
            });
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
            MelonCoroutines.Start(Delay(del, action));
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
            while (!WorldUtils.IsInWorld() && PlayerUtils.GetCurrentUser() == null) yield return null;
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
                new PageAvatar
                {
                    field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                    {
                        field_Internal_ApiAvatar_0 = new ApiAvatar
                        {
                            id = instance.id
                        }
                    }
                }.ChangeToSelectedAvatar();
            }
            catch { Logs.Msg("Error turning into avatar! Maybe it's non existing?", ConsoleColor.Red); }
        }

        public static void ChangeAvatar(this Player instance)
        {
            try
            {
                new PageAvatar
                {
                    field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                    {
                        field_Internal_ApiAvatar_0 = new ApiAvatar
                        {
                            id = instance.prop_ApiAvatar_0.id
                        }
                    }
                }.ChangeToSelectedAvatar();
            }
            catch { Logs.Msg("Error turning into avatar! Maybe it's non existing?", ConsoleColor.Red); }
        }

        public static void ChangeAvatar(this VRCPlayer instance)
        {
            try
            {
                new PageAvatar
                {
                    field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                    {
                        field_Internal_ApiAvatar_0 = new ApiAvatar
                        {
                            id = instance.prop_ApiAvatar_0.id
                        }
                    }
                }.ChangeToSelectedAvatar();
            }
            catch { Logs.Msg("Error turning into avatar! Maybe it's non existing?", ConsoleColor.Red); }
        }

        public static void ChangeAvatar(string id)
        {
            try
            {
                new PageAvatar
                {
                    field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                    {
                        field_Internal_ApiAvatar_0 = new ApiAvatar
                        {
                            id = id
                        }
                    }
                }.ChangeToSelectedAvatar();
            }
            catch { Logs.Msg("Error turning into avatar! Maybe it's non existing?", ConsoleColor.Red); }
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
                PlayerUtils.GetCurrentUser().transform.position + PlayerUtils.GetCurrentUser().transform.forward * 2f,
                PlayerUtils.GetCurrentUser().transform.rotation);
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
    }
}
