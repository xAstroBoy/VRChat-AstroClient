﻿namespace AstroClient.Startup.Hooks
{
    #region Imports

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
    using Tools;
    using Tools.Player;
    using UnhollowerRuntimeLib.XrefScans;
    using VRC;
    using VRC.Udon;
    using xAstroBoy.Utility;

    #endregion Imports
    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class SoftCloneHook : AstroEvents
    {

        private static bool isSoftCloneActive = false;
        private static Il2CppSystem.Object AvatarDictCache { get; set; }
        private static MethodInfo _loadAvatarMethod;
        private static int PacketMaxLimit { get; set; } = 2;

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
                if (value == PacketMaxLimit)
                {
                    _PacketCounter = 0;
                    isSoftCloneActive = false;
                    AvatarDictCache = null;
                }
            }
        }
        //internal static 

        internal override void OnRoomLeft()
        {
            _PacketCounter = 0;
            isSoftCloneActive = false;
            AvatarDictCache = null;
        }

        internal override void ExecutePriorityPatches()
        {
            MiscUtils.DelayFunction(1f, new System.Action(() =>
            {
                InitPatches();
            }));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(SoftCloneHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            new AstroPatch(typeof(VRCNetworkingClient).GetMethod(nameof(VRCNetworkingClient.OnEvent)), GetPatch(nameof(Detour)));

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

        internal static void LocalCloneAvatarPlayer(APIUser user)
        {
            if (user != null)
            {
                AvatarDictCache = PlayerManager.prop_PlayerManager_0
                    .field_Private_List_1_Player_0
                    .ToArray()
                    .FirstOrDefault(a => a.field_Private_APIUser_0.id == user.id)
                    ?.prop_Player_1.field_Private_Hashtable_0["avatarDict"];
                if (AvatarDictCache != null)
                {
                    isSoftCloneActive = true;
                    PacketCounter = 0;
                    _loadAvatarMethod.Invoke(GameInstances.CurrentUser, new object[] { true }); // Invoke refresh and Hook should locally clone it!
                    ModConsole.DebugLog("Local Clone Avatar");
                    PopupUtils.QueHudMessage($"This avatar is Local Cloned!!");
                }
            }
        }

        //internal static void LocalCloneAvatar(ApiAvatar avatar)
        //{
        //    if (avatar != null)
        //    {
        //        avatar.ToAvatarDict((avatardict) =>
        //        {
        //            if (avatardict != null)
        //            {
        //                ModifiedAvatarDict = avatardict;
        //                isSoftCloneActive = true;
        //                PacketCounter = 0;
        //                _loadAvatarMethod.Invoke(VRCPlayer.field_Internal_Static_VRCPlayer_0, new object[] { true }); // Invoke refresh and Hook should locally clone it!
        //                ModConsole.DebugLog("Local Clone Avatar");
        //                PopupUtils.QueHudMessage($"This avatar is Local Cloned!!");

        //            }
        //        });

        //    }
        //}

        private static bool ShouldToggleSoftClone()
        {
            if (PacketCounter < PacketMaxLimit)
            {
                return false;
            }

            return true;
        }

        private static void Detour(ref EventData __0)
        {
            if (!isSoftCloneActive) return;
            if (AvatarDictCache == null) return;
            if (__0 == null) return;
            if (__0.Code == null) return;
            if (__0.Sender == null) return;

            if (__0.Code == 253 && __0.Sender == GameInstances.LocalPlayer.playerId)
            {
                if (AvatarDictCache != null)
                {
                    __0.Parameters[251].Cast<Il2CppSystem.Collections.Hashtable>()["avatarDict"] = AvatarDictCache; // Hopefully it works!
                    PacketCounter++;
                }
            }
        }

        //internal override void OnUpdate()
        //{
        //    if (!Input.GetKey(KeyCode.Tab)) return;

        //    if (Input.GetKeyDown(KeyCode.T))
        //    {
        //        if (UserSelectionManager.field_Private_Static_UserSelectionManager_0.field_Private_APIUser_1 == null)
        //        {
        //            Log("Invalid Target");
        //            return;
        //        }

        //        string target = UserSelectionManager.field_Private_Static_UserSelectionManager_0.field_Private_APIUser_1.id;

        //        AvatarDictCache = PlayerManager.prop_PlayerManager_0
        //            .field_Private_List_1_Player_0
        //            .ToArray()
        //            .FirstOrDefault(a => a.field_Private_APIUser_0.id == target)
        //            ?.prop_Player_1.field_Private_Hashtable_0["avatarDict"];

        //        _loadAvatarMethod.Invoke(VRCPlayer.field_Internal_Static_VRCPlayer_0, new object[] { true });
        //    }

        //    if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        _state ^= true;

        //        Log("SoftClone " + (_state ? "On" : "Off"));
        //    }
        //}

    }
}