namespace AstroClient.Startup.Hooks
{
    #region Imports

    using ExitGames.Client.Photon;
    using MelonLoader;
    using System.Reflection;
    using UnityEngine;
    using VRC.Core;
    using VRC.DataModel;
    using System.Linq;
    using Cheetos;
    using UnhollowerRuntimeLib.XrefScans;
    using VRC;
    using VRC.Udon;
    using xAstroBoy.Utility;

    #endregion Imports
    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class SoftCloneHook : AstroEvents
    {
        private static bool isSoftCloneActive = false;
        private static bool hasCore = false;
        private static Il2CppSystem.Object AvatarDictCache { get; set; }
        private static MethodInfo _loadAvatarMethod;

        //internal static 
        private HarmonyLib.Harmony harmony;

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
            new AstroPatch(typeof(VRCNetworkingClient).GetMethod(nameof(VRCNetworkingClient.OnEvent)), null, GetPatch(nameof(Detour)));

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
        private static void Detour(ref EventData __0)
        {
            if (isSoftCloneActive
                && __0.Code == 253
                && AvatarDictCache != null
                && __0.Sender == Player.prop_Player_0.field_Private_VRCPlayerApi_0.playerId
            ) __0.Parameters[251].Cast<Il2CppSystem.Collections.Hashtable>()["avatarDict"] = AvatarDictCache;
        }

        private static void ComponentInternalCheck(ref Component __result)
        {
            if (__result is UdonBehaviour)
            {
                ModConsole.DebugLog("A UdonBehaviour has been spawned!");
            }
        }
    }
}