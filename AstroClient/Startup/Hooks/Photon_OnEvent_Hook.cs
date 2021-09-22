namespace AstroClient
{
    #region Imports

    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using Photon.Realtime;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    #endregion Imports

    public class PhotonOnEventHook : GameEvents
    {
        //public static
        private HarmonyLib.Harmony harmony;

        public override void ExecutePriorityPatches()
        {
            MiscUtils.DelayFunction(1f, new System.Action(() =>
            {
                InitPatches();
            }));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        public void InitPatches()
        {
            try
            {
                if (harmony == null)
                {
                    harmony = new HarmonyLib.Harmony(BuildInfo.Name + " PhotonOnEventHook");
                }

                _ = harmony.Patch(AccessTools.Method(typeof(LoadBalancingClient), nameof(LoadBalancingClient.OnEvent)), new HarmonyMethod(typeof(PhotonOnEventHook).GetMethod(nameof(OnEvent), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                ModConsole.DebugLog("Photon Hooks Done");
            }
            catch
            {
                harmony.UnpatchAll();
                InitPatches();
            }
        }

        // UDON BEHAVIOURS GETS AFFECTED!
        // Best advice, make each event have his own handler class to translate and remove the useless translations so is faster and better.

        private static bool OnEvent(ref EventData __0)
        {
            try
            {
                if (__0 == null && __0.sender != null)
                {
                    return true; // discard
                }
                object data = MiscUtils_Old.Serialization.FromIL2CPPToManaged<object>(__0.Parameters);
                var code = __0.Code;
                var photon = Utils.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                bool log = false;
                bool block = false;

                StringBuilder line = new StringBuilder();
                StringBuilder prefix = new StringBuilder();
                prefix.Append($"[Event ({code})] ");

                line.Append($"from: ({__0.Sender}) ");
                if (WorldUtils.IsInWorld && photon != null)
                {
                    line.Append($"'{photon.GetDisplayName()}'");
                }
                else
                {
                    line.Append($"'NULL' ");
                }

                switch (code)
                {
                    case 1:// Voice Data TODO : (Parrot Mode)
                        break;

                    case 7: // I believe this is motion, key 245 appears to be base64
                        break;

                    case 2: // Kick Message?
                        string kickMessage = (data as Dictionary<byte, object>)[245].ToString();
                        break;

                    case 6:
                        break;

                    case 8: // Interest - Interested in events
                        break;

                    case 33: // Moderations
                        return PhotonModerationHandler.Handle_Photon_ModerationEvent(__0);
                        break;

                    case 203: // Destroy
                        prefix.Append("Destroy: ");
                        log = true;
                        break;

                    case 210:
                        break;

                    case 223: // This fired with what looked like base64 png data when I uploaded a VRC+ avatar
                        break;

                    case 253: // I think this is avatar switching related
                        break;

                    default:
                        log = true;
                        break;
                }

                string blockText = string.Empty;
                if (block)
                {
                    blockText = "[BLOCKED] ";
                    if (log && ConfigManager.General.LogEvents)
                    {
                        line.Append($"\n{Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented)}");
                        ModConsole.Log($"{blockText}{prefix.ToString()}{line.ToString()}");
                    }
                    line.Clear();
                }
                if (block)
                {
                    return false;
                }
                return true;
            }
            catch (System.Exception e)
            {
                ModConsole.DebugError("Error in Photon OnEvent : ");
                ModConsole.DebugErrorExc(e);
                return true;
            }

            return true;
        }
    }
}