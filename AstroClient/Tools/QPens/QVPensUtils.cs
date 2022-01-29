namespace AstroClient.Tools.QPens
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using CustomClasses;
    using Extensions;
    using UnityEngine;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;

    internal class QVPensUtils : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            FindQVPenSetTriggers();
            FindUdonPensEvents();
        }

        internal override void OnRoomLeft()
        {
            if (PenManagers != null)
            {
                PenManagers.Clear();
            }
            if (TriggerSDKBase != null)
            {
                TriggerSDKBase.Clear();
            }
            if (TriggerSDK2 != null)
            {
                TriggerSDK2.Clear();
            }
            if (ClearPensUdonEvents != null)
            {
                ClearPensUdonEvents.Clear();
            }
        }

        internal static void FindQVPenSetTriggers()
        {
            UnhollowerBaseLib.Il2CppArrayBase<GameObject> list = Resources.FindObjectsOfTypeAll<GameObject>();
            for (int i = 0; i < list.Count; i++)
            {
                GameObject obj = list[i];
                if (obj.name.ToLower().Contains("penmanager"))
                {
                    if (PenManagers != null)
                    {
                        if (!PenManagers.Contains(obj))
                        {
                            PenManagers.Add(obj);
                        }
                    }
                }
            }
            if (PenManagers.Count() != 0)
            {
                ModConsole.DebugLog("Found " + PenManagers.Count() + " Pen Managers!, Registering Clear Trigger!");
                GetAllResetGlobals();
            }
        }

        internal static void GetAllResetGlobals()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < PenManagers.Count; i++)
            {
                GameObject pen = PenManagers[i];
                if (pen != null)
                {
                    UnhollowerBaseLib.Il2CppArrayBase<VRC.SDKBase.VRC_Trigger> list1 = pen.GetComponentsInChildren<VRC.SDKBase.VRC_Trigger>(true);
                    for (int i1 = 0; i1 < list1.Count; i1++)
                    {
                        VRC.SDKBase.VRC_Trigger obj = list1[i1];
                        if (obj.gameObject.name.ToLower().Contains("interact_clear"))
                        {
                            if (!TriggerSDKBase.Contains(obj))
                            {
                                TriggerSDKBase.Add(obj);
                            }
                        }
                    }

                    UnhollowerBaseLib.Il2CppArrayBase<VRCSDK2.VRC_Trigger> list = pen.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true);
                    for (int i1 = 0; i1 < list.Count; i1++)
                    {
                        VRCSDK2.VRC_Trigger obj = list[i1];
                        if (obj.gameObject.name.ToLower().Contains("interact_clear"))
                        {
                            if (!TriggerSDK2.Contains(obj))
                            {
                                TriggerSDK2.Add(obj);
                            }
                        }
                    }
                }
            }

            stopwatch.Stop();
            ModConsole.DebugLog("Found " + TriggerSDKBase.Count() + " QVPens Clear SDKBase Triggers.");
            ModConsole.DebugLog("Found " + TriggerSDK2.Count() + " QVPens Clear VRCSDK2 Triggers.");
            ModConsole.DebugLog($"Trigger Search Took: {stopwatch.ElapsedMilliseconds}ms");
        }

        internal static void FindUdonPensEvents()
        {
            VRC.Udon.UdonBehaviour[] array = WorldUtils.UdonScripts;
            for (int i = 0; i < array.Length; i++)
            {
                VRC.Udon.UdonBehaviour item = array[i];
                if (item != null)
                {
                    if (item.name.ToLower().Contains("penmanager"))
                    {
                        var action = item.FindUdonEvent("ClearAll");
                        if (action != null)
                        {
                            if (!ClearPensUdonEvents.Contains(action))
                            {
                                ClearPensUdonEvents.Add(action);
                            }
                        }
                    }
                    if (item.name.ToLower().Equals("pen"))
                    {
                        var action = item.FindUdonEvent("Clear");
                        if (action != null)
                        {
                            if (!ClearPensUdonEvents.Contains(action))
                            {
                                ClearPensUdonEvents.Add(action);
                            }
                        }
                    }
                }
            }
            ModConsole.DebugLog("Found " + ClearPensUdonEvents.Count() + " Clear Pens Udon Events.");
        }

        internal static void ResetQPensGlobal()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (TriggerSDKBase.Count() != 0)
            {
                for (int i = 0; i < TriggerSDKBase.Count; i++)
                {
                    VRC.SDKBase.VRC_Trigger item = TriggerSDKBase[i];
                    if (item != null)
                    {
                        item.gameObject.TriggerClick();
                    }
                }
            }
            if (TriggerSDK2.Count() != 0)
            {
                for (int i = 0; i < TriggerSDK2.Count; i++)
                {
                    VRCSDK2.VRC_Trigger item = TriggerSDK2[i];
                    if (item != null)
                    {
                        item.gameObject.TriggerClick();
                    }
                }
            }
            if (ClearPensUdonEvents.Count() != 0)
            {
                ClearPensUdonEvents.InvokeBehaviour();
            }

            stopwatch.Stop();
            ModConsole.DebugLog($"ResetQPens took: {stopwatch.ElapsedMilliseconds}ms");
        }

        internal static List<GameObject> PenManagers = new List<GameObject>();
        internal static List<VRC.SDKBase.VRC_Trigger> TriggerSDKBase = new List<VRC.SDKBase.VRC_Trigger>();
        internal static List<VRCSDK2.VRC_Trigger> TriggerSDK2 = new List<VRCSDK2.VRC_Trigger>();
        internal static List<UdonBehaviour_Cached> ClearPensUdonEvents = new List<UdonBehaviour_Cached>();
    }
}