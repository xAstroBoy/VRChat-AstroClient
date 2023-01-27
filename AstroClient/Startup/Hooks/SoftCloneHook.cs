using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;
using AstroClient.xAstroBoy.Patching;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using ExitGames.Client.Photon;
    using MelonLoader;
    using System.Reflection;
    using UnityEngine;
    using VRC.Core;
    using VRC.DataModel;
    using System.Linq;
    using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Utilities;
    using CheetoLibrary.Misc;
    using CheetoLibrary.Utility;
    using Cheetos;
    using HarmonyLib;
    using Il2CppSystem.Collections;
    using Newtonsoft.Json;
    using PhotonHook.Structs;
    using PhotonHook.Structs.PhotonBytes;
    using PhotonHook.Tools.Ext;
    using PhotonHook.Tools.PhotonLogger;
    using PhotonHook.Tools.Translators;
    using Tools;
    using Tools.Player;
    using UnhollowerRuntimeLib;
    using UnhollowerRuntimeLib.XrefScans;
    using VRC;
    using VRC.Udon;
    using xAstroBoy.Utility;

    #endregion Imports
    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class SoftCloneHook : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }


        private static bool isSoftCloneActive = false;
        private static Il2CppSystem.Object AvatarDictCache { get; set; }
        private static MethodInfo _loadAvatarMethod;
        private static int PacketMaxLimit { get; set; } = 3; // Increase this based off how much vrchat tries to reload the avatar package.

        private static int _PacketCounter = 0;
        private static int PacketCounter
        {
            get
            {
                return _PacketCounter;
            }
            set
            {
                _PacketCounter = value;
                //if (isSoftCloneActive)
                //{
                //    Log.Debug($"Patched {value} Events");
                //    PopupUtils.QueHudMessage($"Patched {value} Events");

                //}
                if (value == PacketMaxLimit)
                {
                    _PacketCounter = 0;
                    isSoftCloneActive = false;
                    AvatarDictCache = null;
                }
            }
        }
        //internal static 

        private void OnRoomLeft()
        {
            _PacketCounter = 0;
            isSoftCloneActive = false;
            AvatarDictCache = null;
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(VRCNetworkingClient).GetMethod(nameof(VRCNetworkingClient.OnEvent)), GetPatch(nameof(SoftCloneOnEvent)));

            _loadAvatarMethod =
    typeof(VRCPlayer).GetMethods()
    .First(mi =>
        mi.Name.StartsWith("Method_Private_Void_Boolean_")
        && mi.Name.Length < 31
        && mi.GetParameters().Any(pi => pi.IsOptional)
        && XrefScanner.UsedBy(mi) // Scan each method
            .Any(instance => instance.Type == XrefType.Method
                && instance.TryResolve() != null
                && instance.TryResolve().Name == "ReloadAvatarNetworkedRPC"));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(SoftCloneHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        internal static void LocalCloneAvatarPlayer(APIUser user)
        {
            if (user != null)
            {
                AvatarDictCache = null;
                var hashtable = user.GetPlayer().prop_Player_1.prop_Hashtable_0;
                if (hashtable != null)
                {
                    if (hashtable.ContainsKey("avatarDict"))
                    {
                        AvatarDictCache = hashtable["avatarDict"];
                    }
                }
                if (AvatarDictCache != null)
                {
                    isSoftCloneActive = true;
                    PacketCounter = 0;
                    _loadAvatarMethod.Invoke(GameInstances.CurrentUser, new object[] { true }); // Invoke refresh and Hook should locally clone it!
                    Log.Debug("Local Clone Avatar");
                    NewHudNotifier.WriteHudMessage($"This avatar is Local Cloned!!");
                }
            }
        }


        internal static void PrintCurrentAvatarHashtable(APIUser user)
        {
            if (user != null)
            {
                var hashtable = user.GetPlayer().prop_Player_1.prop_Hashtable_0;
                if (hashtable != null)
                {
                    if (hashtable.ContainsKey("avatarDict"))
                    {
                        Log.Debug(JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(hashtable["avatarDict"]), Formatting.Indented));

                    }
                }
            }
        }

        internal static void LocalCloneAvatar(ApiAvatar avatar)
        {
            if (avatar != null)
            {
                var avatardict = AstroClient.Tools.Player.AvatarUtils.ToAvatarDict2(avatar);
                if (avatardict != null)
                {
                    AvatarDictCache = avatardict;
                    isSoftCloneActive = true;
                    PacketCounter = 0;
                    _loadAvatarMethod.Invoke(GameInstances.CurrentUser, new object[] { true }); // Invoke refresh and Hook should locally clone it!
                    Log.Debug("Local Clone Avatar");
                    NewHudNotifier.WriteHudMessage($"This avatar is Local Cloned!!");

                }


            }
        }

        private static bool ShouldToggleSoftClone()
        {
            if (PacketCounter < PacketMaxLimit)
            {
                return false;
            }

            return true;
        }

        private static void SoftCloneOnEvent(ref EventData __0)
        {
            if (__0 == null) return;
            //__0.DumpKeys();
            if (GameInstances.LocalPlayer == null) return;
            if (__0.Code == 42)

            {
                var casted = __0.Parameters[245].Cast<Il2CppSystem.Collections.Hashtable>();
                
                if (casted.IsLocalUser())
                {
                   // Log.Debug("Hey im Being called right now!");


                    if (!isSoftCloneActive) return;
                    if (AvatarDictCache == null) return;
                    if (AvatarDictCache != null)
                    {
                        // Hopefully it works!
                        if (casted != null)
                        {
                            Log.Debug("Swapping AvatarDict...");
                            casted["avatarDict"] = AvatarDictCache;
                            PacketCounter++;
                        }

                    }
                }
            }
        }
    }
}