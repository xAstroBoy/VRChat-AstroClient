using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#region AstroClient Imports

using AstroClient.ConsoleUtils;
using AstroClient.extensions;

#endregion AstroClient Imports

namespace AstroClient
{
    public class QVPensUtils : Overridables
    {
        public override void OnWorldReveal()
        {
            FindQVPenSet();
        }

        public override void OnLevelLoaded()
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
        }

        public static void FindQVPenSet()
        {
            foreach (var obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
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
                ModConsole.Log("Found " + PenManagers.Count() + " Pen Managers!, Registering Clear Trigger!");
                GetAllResetGlobals();
            }
        }

        public static void GetAllResetGlobals()
        {
            foreach (var pen in PenManagers)
            {
                if (pen != null)
                {
                    foreach (var obj in pen.GetComponentsInChildren<VRC.SDKBase.VRC_Trigger>(true))
                    {
                        if (obj.gameObject.name.ToLower().Contains("interact_clear"))
                        {
                            if (!TriggerSDKBase.Contains(obj))
                            {
                                TriggerSDKBase.Add(obj);
                            }
                        }
                    }

                    foreach (var obj in pen.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true))
                    {
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

            ModConsole.Log("Found " + TriggerSDKBase.Count() + " QVPens Clear SDKBase Triggers.");
            ModConsole.Log("Found " + TriggerSDK2.Count() + " QVPens Clear VRCSDK2 Triggers.");
        }

        public static void ResetQPensGlobal()
        {
            foreach (var item in TriggerSDKBase)
            {
                if (item != null)
                {
                    item.gameObject.TriggerClick();
                }
            }
            foreach (var item in TriggerSDK2)
            {
                if (item != null)
                {
                    item.gameObject.TriggerClick();
                }
            }
        }

        public static List<GameObject> PenManagers = new List<GameObject>();
        public static List<VRC.SDKBase.VRC_Trigger> TriggerSDKBase = new List<VRC.SDKBase.VRC_Trigger>();
        public static List<VRCSDK2.VRC_Trigger> TriggerSDK2 = new List<VRCSDK2.VRC_Trigger>();
    }
}