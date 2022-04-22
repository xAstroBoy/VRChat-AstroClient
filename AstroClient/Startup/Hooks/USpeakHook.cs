namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Reflection;
    
    using Cheetos;
    using MelonLoader;
    using Tools.Extensions;
    using System.Linq;
    using HarmonyLib;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class USpeakHook : AstroEvents
    {
        internal static event Action<OnRawAudioEventArgs> Event_OnRawAudio;

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(USpeakHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            MelonCoroutines.Start(Init());
        }

        private IEnumerator Init()
        {
            InitPatch();
            yield break;
        }

        private void InitPatch()
        {
            MethodInfo decompressedAudioReceiver = null;

            string debug_info = "";

            foreach (MethodInfo info in typeof(USpeaker).GetMethods().Where(
                mi => mi.GetParameters().Length == 4
            ))
            {
                debug_info += (String.Format("Method: {1} {0}({2} params)",
                        info.Name,
                        info.ReturnType.ToString(),
                        info.GetParameters().Length.ToString()
                    ));

                int ints = 0;
                int floats = 0;
                foreach (ParameterInfo inf in info.GetParameters())
                {
                    debug_info += (String.Format(" - Param {0}", inf.ParameterType.ToString())) + "\n";
                    if (inf.ParameterType.ToString().Contains("Single")) floats++;
                    if (inf.ParameterType.ToString().Contains("Int32")) ints++;
                }

                if (ints == 2 && floats == 2 && !info.Name.Contains("PDM"))
                {
                    decompressedAudioReceiver = info;
                }
            }

            if (decompressedAudioReceiver == null)
            {
                MelonLogger.Error("Couldn't find decompressedAudioReceiver!");
                MelonLogger.Error(debug_info);
                return;
            }

            try
            {
                new AstroPatch(decompressedAudioReceiver, null, GetPatch(nameof(onDecompressedAudio)));
            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }

        private static void onDecompressedAudio(USpeaker __instance, UnhollowerBaseLib.Il2CppStructArray<float> param_1, float param_2, int param_3, int param_4)
        {
            VRCPlayer player = __instance.field_Private_VRCPlayer_0;
            if (player == null) return;

            int sample_rate = 48000; //default vrchat
            if (__instance.field_Private_AudioClip_0 != null)
                sample_rate = __instance.field_Private_AudioClip_0.frequency;
            Event_OnRawAudio.SafetyRaise(new OnRawAudioEventArgs(player, param_1, sample_rate));
        }

    }
}