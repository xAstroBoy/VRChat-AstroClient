
using AstroClient.xAstroBoy.Extensions;

namespace AstroClient.Startup.Hooks
{
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Utility;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class AntiMuteExperiment : AstroEvents
    {


        internal override void ExecutePriorityPatches()
        {
            MiscUtils.DelayFunction(10f, () => {
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_0)), GetPatch(nameof(AntiMute_0)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_1)), GetPatch(nameof(AntiMute_1)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_2)), GetPatch(nameof(AntiMute_2)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_3)), GetPatch(nameof(AntiMute_3)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_4)), GetPatch(nameof(AntiMute_4)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_5)), GetPatch(nameof(AntiMute_5)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_6)), GetPatch(nameof(AntiMute_6)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_7)), GetPatch(nameof(AntiMute_7)));
            new AstroPatch(typeof(USpeakPhotonManager3D).GetMethod(nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_8)), GetPatch(nameof(AntiMute_8)));
                });
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(AntiMuteExperiment).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static bool AntiMute_0(Photon.Realtime.Player __0)
        {

            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_0);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }
        private static bool AntiMute_1(Photon.Realtime.Player __0)
        {

            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_1);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }
        private static bool AntiMute_2(Photon.Realtime.Player __0)
        {

            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_2);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }
        private static bool AntiMute_3(Photon.Realtime.Player __0)
        {

            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_3);


            Log.Debug($"Method {methodname} fired for player {DisplayName}");

            return true;
        }
        private static bool AntiMute_4(Photon.Realtime.Player __0)
        {
            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_4);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }
        private static bool AntiMute_5(Photon.Realtime.Player __0)
        {

            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_5);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }
        private static bool AntiMute_6(Photon.Realtime.Player __0)
        {
            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_6);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }
        private static bool AntiMute_7(Photon.Realtime.Player __0)
        {
            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_7);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }
        private static bool AntiMute_8(Photon.Realtime.Player __0)
        {
            var DisplayName = __0.GetDisplayName();
            var methodname = nameof(USpeakPhotonManager3D.Method_Public_Static_Void_Player_PDM_8);
            Log.Debug($"Method {methodname} fired for player {DisplayName}");
            return true;
        }

    }
}